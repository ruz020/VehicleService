namespace VehicleServiceAPI.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public override bool Equals(object other)
        {
            var toCompareWith = other as Vehicle;
            if (toCompareWith == null)
                return false;
            return this.Id == toCompareWith.Id &&
                this.Year == toCompareWith.Year &&
                this.Make == toCompareWith.Make &&
                this.Model == toCompareWith.Model;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
