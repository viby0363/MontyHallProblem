using MontyHallBE.Service;
namespace MontyHallBE.Tests
{
    public class GameSessionTests
    {
        public class When_creating_gamesession
        {
            [Fact]
            public void Initial_doors_should_be_in_random_order_and_always_have_two_goats_and_one_car()
            {
                var gameSessions = new List<GameSession>();
                
                for (int i = 0; i < 10000; i++)
                {
                    gameSessions.Add(new GameSession());
                }

                Assert.NotNull(gameSessions.FirstOrDefault(x => x.Doors[0].Prize == Models.BehindDoor.Car));
                Assert.NotNull(gameSessions.FirstOrDefault(x => x.Doors[1].Prize == Models.BehindDoor.Car));
                Assert.NotNull(gameSessions.FirstOrDefault(x => x.Doors[2].Prize == Models.BehindDoor.Car));
                
                foreach (var gameSession in gameSessions)
                {
                    var goatCount = gameSession.Doors.Where(x => x.Prize == Models.BehindDoor.Goat).Count();
                    var carCount = gameSession.Doors.Where(x => x.Prize == Models.BehindDoor.Car).Count();
                    Assert.True(goatCount is 2);
                    Assert.True(carCount is 1);
                }
            }
            [Fact]
            public void All_doors_should_initially_be_closed()
            {
                var gameSession = new GameSession();
                Assert.False(gameSession.Doors[0].IsOpen);
                Assert.False(gameSession.Doors[1].IsOpen);
                Assert.False(gameSession.Doors[2].IsOpen);
                Assert.True(gameSession.ClosedDoors.Count == 3);
            }
        }

        public class When_opening_doors
        {
            [Fact]
            public void The_first_opened_door_should_always_be_a_goat()
            {
                var gameSession1 = new GameSession();
                gameSession1.OpenDoor(1);
                var firstOpenedDoor1 = gameSession1.Doors.First(x => x.IsOpen);
                Assert.True(firstOpenedDoor1.Prize == Models.BehindDoor.Goat);

                var gameSession2 = new GameSession();
                gameSession2.OpenDoor(2);
                var firstOpenedDoor2 = gameSession2.Doors.First(x => x.IsOpen);
                Assert.True(firstOpenedDoor2.Prize == Models.BehindDoor.Goat);

                var gameSession3 = new GameSession();
                gameSession3.OpenDoor(3);
                var firstOpenedDoor3 = gameSession3.Doors.First(x => x.IsOpen);
                Assert.True(firstOpenedDoor3.Prize == Models.BehindDoor.Goat);
            }

            public class And_checking_if_game_was_won
            {
                [Fact]
                public void It_should_not_be_possible_before_second_choice()
                {
                    var gameSession = new GameSession();
                    Assert.Throws<InvalidOperationException>(() => gameSession.DidIWin());
                    
                    gameSession.OpenDoor(1);
                    Assert.Throws<InvalidOperationException>(() => gameSession.DidIWin());
                    
                    gameSession.OpenDoor(1, false);
                    Assert.IsType<bool>(gameSession.DidIWin());
                }

                [Fact]
                public void True_should_be_returned_if_the_last_closed_door_is_a_goat_otherwise_false()
                {
                    var gameSessions = new List<GameSession>();
                    
                    for (int i = 0; i < 10000; i++)
                    {
                        gameSessions.Add(new GameSession());
                    }

                    foreach (var gameSession in gameSessions)
                    {
                        gameSession.OpenDoor(1);
                        gameSession.OpenDoor(1, false);
                        var lastClosedDoor = gameSession.ClosedDoors.First();
                        var lastClosedDoorIndex = lastClosedDoor - 1;

                        if (gameSession.Doors[lastClosedDoorIndex].Prize == Models.BehindDoor.Goat)
                        {
                            Assert.True(gameSession.DidIWin());
                        }
                        else
                        {
                            Assert.False(gameSession.DidIWin());
                        }
                    }
                }
            }
        }
    }
}
