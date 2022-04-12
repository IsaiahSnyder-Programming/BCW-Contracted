namespace Contracted.Models
{
    public class Company : Virtual<int>
    {

        public string Name { get; set; }
        public string Location { get; set; }
    }
}