namespace PhotoShare.Models
{
    public class Tag
    {
        //Primary key
        public int TagId { get; set; }

        public string Name { get; set; } = string.Empty;

        //Foreign key
        public int PhotoID { get; set; }

        //Navigation property - we use it to load the related object. A tag belongs to a photo. Should always be nullable
        public Photo? Photo { get; set; } //nullable

    }   
}

