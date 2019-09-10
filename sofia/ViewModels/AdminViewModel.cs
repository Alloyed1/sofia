using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sofia.ViewModels
{
    public class AdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public string about { get; set; }
        public int Price { get; set; }
        public string Coords { get; set; }
    }
}
