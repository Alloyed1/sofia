using sofia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sofia.ViewModels
{
    public class ItemViewModel
    {
        public Home Home { get; set; }
        public List<string> Dop { get; set; }
        public List<byte[]> Photos { get; set; }
    }
}
