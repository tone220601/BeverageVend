using BeverageVend.Enums;

namespace BeverageVend.Data
{
    public class Vend
    {
        public Beverage Beverage { get; set; }      
        public bool Milk { get; set; }
        public bool Sugar { get; set; }
        public bool Lemon { get; set; }
        public TimeSpan Boil { get; set; }
        public TimeSpan Dispense { get; set; }
        public string? Message { get; set; }
    }
}
