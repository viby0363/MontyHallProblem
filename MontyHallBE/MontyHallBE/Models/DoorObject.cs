namespace MontyHallBE.Models
{
    public class DoorObject
    {
        public BehindDoor Prize { get; set; }
        public bool IsOpen { get; set; } = false;
    }

    public static class DoorHelpers
    {
        public static List<DoorObject> GetRandomDoorList()
        {
            var list = new List<DoorObject>
        {
            new()
            {
                Prize = BehindDoor.Car
            },
            new()
            {
                Prize = BehindDoor.Goat
            },
            new()
            {
                Prize = BehindDoor.Goat
            }
        };

            var random = new Random();
            return list.OrderBy(x => random.Next()).ToList();
        }
    }

    public enum BehindDoor
    {
        Car,
        Goat
    }
}
