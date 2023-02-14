namespace TP.CRM;

public class Client{

    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string State { get; set; }= null!;
    public int TVA { get; set; } 
    public double TotalCaHt { get; set; }
    public string Comment { get; set; }= null!;
    public int id_user { get; set; }
    
    public User user { get; set; } = null!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<Order> ListOrders { get; } = new List<Order>();



    public Client(){
    }

    public Client(string name, string state, int TVA, double TotalCaHt, string comment)
    {
        this.Name = name;
        this.State = state;
        this.TVA = TVA;
        this.TotalCaHt = TotalCaHt;
        this.Comment = comment;
    }

    // public Client(string name, string state, int TVA, double TotalCaHt, string comment, User id_user)
    // {
    //     this.Name = name;
    //     this.State = state;
    //     this.TVA = TVA;
    //     this.TotalCaHt = TotalCaHt;
    //     this.Comment = comment;
    //     this.user = id_user;
    //     this.id_user = id_user.ID;
    // }
}