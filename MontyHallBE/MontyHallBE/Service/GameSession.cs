using MontyHallBE.Models;

namespace MontyHallBE.Service
{
    public class GameSession
    {
        public List<DoorObject> Doors = DoorHelpers.GetRandomDoorList();
        public List<int> ClosedDoors = new() { 1, 2, 3 };

        public bool DidIWin()
        {
            if (ClosedDoors.Count > 1)
                throw new InvalidOperationException("Game is not finished yet");

            var stillClosedDoorIndex = ClosedDoors.First() - 1;

            return Doors[stillClosedDoorIndex].Prize == BehindDoor.Goat;
        }

        public void OpenDoor(int doorNr, bool isFirstTurn = true)
        {
            var doorIndex = doorNr - 1;

            if (!isFirstTurn)
            {
                Doors[doorIndex].IsOpen = true;
                ClosedDoors.Remove(doorIndex + 1);
                return;
            }

            var random = new Random();
            var index = random.Next(3);
            if (index == doorIndex)
            {
                OpenDoor(doorNr); return;
            }
            if (Doors[index].Prize == BehindDoor.Car)
            {
                OpenDoor(doorNr); return;
            }
            Doors[index].IsOpen = true;
            ClosedDoors.Remove(index + 1);
        }
    }
}
