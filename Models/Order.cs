namespace TP.CRM;
public class Order
{
    public int ID { get; set; }
    public  string TypePresta { get; set; } = null!;
    public string Client { get; set; } = null!;
    public int NbJours { get; set; }
    public int TjmHt { get; set; }
    public int TVA { get; set; }
    public string State { get; set; }= null!;
    public string Comment { get; set; }= null!;
    public int id_clients { get; set; }
    
//   [System.Text.Json.Serialization.JsonIgnore]
    public virtual Client bob { get; set; } = null!;
   
   
    

    public Order()
    {
    }

    public Order(string typePresta, string client, int NbJours, int TjmHt, int TVA, string State, string Comment)
    {
        this.TypePresta = typePresta;
        this.Client = client;
        this.NbJours = NbJours;
        this.TjmHt = TjmHt;
        this.TVA = TVA;
        this.State = State;
        this.Comment = Comment;

    }

    // public Order(string typePresta, string client, int NbJours, int TjmHt, int TVA, string State, string Comment, Client id_clients)
    // {
    //     this.TypePresta = typePresta;
    //     this.Client = client;
    //     this.NbJours = NbJours;
    //     this.TjmHt = TjmHt;
    //     this.TVA = TVA;
    //     this.State = State;
    //     this.Comment = Comment;
    //     this.bob = id_clients;
    //     this.id_clients = id_clients.ID;
    // }
}