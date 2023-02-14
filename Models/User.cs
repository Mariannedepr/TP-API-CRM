namespace TP.CRM;

public class User{

    public int ID { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; }= null!;
    public string FirstName { get; set; }= null!;
    public string LastName { get; set; }= null!;
    public string ConfirmedPassword { get; set; }= null!;
    public string Grants { get; set; }= null!;

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<Client> ListClients { get; } = new List<Client>();
    //virtual : autorise la surcharge
    

    public User(){
    }

    public User(string email, string password, string firstName, string lastName, string confirmedPassword, string grants)
    {
        this.Email = email;
        this.Password = password;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.ConfirmedPassword = confirmedPassword;
        this.Grants = grants;
    }


}