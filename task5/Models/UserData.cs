namespace task5.Models;

public class UserData
{
    public long Number { get; set; }
    
    public String Id { get; set; }
    
    public String FullName { get; set; }
    
    public String Address { get; set; }
    
    public String PhoneNumber { get; set; }
    
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0:
                    return Number.ToString();
                case 1:
                    return Id;
                case 2:
                    return FullName;
                case 3:
                    return Address;
                case 4:
                    return PhoneNumber;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
        set
        {
            switch (index)
            {
                case 0:
                    Number = int.Parse(value);
                    break;
                case 1:
                    Id = value;
                    break;
                case 2:
                    FullName = value;
                    break;
                case 3:
                    Address = value;
                    break;
                case 4:
                    PhoneNumber = value;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}