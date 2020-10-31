using System;
using System.Collections.Generic;

namespace super_duper_octo_fortnight.Server.Models
{
    public partial class ItemDetails
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
    }
}
