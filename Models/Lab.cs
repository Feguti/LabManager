namespace LabManager.Models;

class Lab 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public String Name { get; set; }
    public String Block { get; set; }

    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }

    public Lab()
    {
        
    }
}