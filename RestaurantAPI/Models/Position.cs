namespace RestaurantAPI.Models
{
    public class Position: BaseEntity
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }   
    }
}
