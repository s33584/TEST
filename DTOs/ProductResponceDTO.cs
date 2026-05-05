

public class ProductResponceDTO
{
    public int Id {get; set; }
    public string Name {get; set;} = null!;
    public string Description {get; set; } = null!; 
    public string StickerPrice {get; set; } = null!;
    public int ProductTypeId {get; set;}
    public int MakerId {get; set; }

}