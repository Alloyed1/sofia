using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sofia.ViewModels
{
	public class AddHomeViewModel
	{
		public int TypeSdelki { get; set; }
		public int TypeArenda { get; set; }
		public int TypeCommerce { get; set; }
		public string ObjectText { get; set; }
		public string Adress { get; set; }
		public string Coords { get; set; }

		public int Comnat { get; set; }
		public double PloshadRoom { get; set; }
		public double AllPloshadRoom { get; set; }
		public int AllCountRoom { get; set; }
		public int Etag { get; set; }
		public int EtagAll { get; set; }
		public double Kuxnya { get; set; }
		public string Balkon { get; set; }
		public string SanUzelRazdel { get; set; }
		public string SanUzelVmeste { get; set; }
		public string Remont { get; set; }
		public bool Animals { get; set; }
		public bool Children { get; set; }

		public string ZdanieName { get; set; }
		public string Year { get; set; }
		public double HeightPotolok { get; set; }
		public string Parkovka { get; set; }

		public string Name { get; set; }
		public bool Communal { get; set; }
		public bool Predoplata { get; set; }
		public int Zalog { get; set; }
		public string Sostav { get; set; }

		public List<string> Dop { get; set; }
	}
}
