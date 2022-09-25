using MontyHallBE.Models;

namespace MontyHallBE.Service
{
    public class Simulator
    {
        readonly bool _changeDoor;
        readonly decimal _nrOfGames;
        decimal _gamesWon;
        decimal _gamesLost => _nrOfGames - _gamesWon;
        public Simulator(int nrOfGames, bool changeDoor)
        {
            _nrOfGames = nrOfGames;
            _changeDoor = changeDoor;
        }

        public async Task<MontyHallResponse> GetSimulationResult()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < _nrOfGames; i++)
            {
                tasks.Add(Task.Run(() => Run()));
            }

            await Task.WhenAll(tasks);

            return new MontyHallResponse {
                NumberOfGamesWon = Convert.ToInt32(_gamesWon),
                WinRate = CalcWinRate()
            };
        }

        private decimal CalcWinRate()
        {
            return (_gamesWon / _nrOfGames) * 100;
        }

        private void Run()
        {
            var gameSession = new GameSession();
            var chosenNr = new Random().Next(1, 4);
            gameSession.OpenDoor(chosenNr);
            var doorToOpen = _changeDoor ? gameSession.ClosedDoors.First(x => x != chosenNr) : chosenNr;
            gameSession.OpenDoor(doorToOpen, false);
            var won = gameSession.DidIWin();
            if (won)
                _gamesWon++;
        }
    }
}
