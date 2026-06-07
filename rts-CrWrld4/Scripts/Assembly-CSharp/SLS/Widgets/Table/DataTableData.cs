using System.Collections.Generic;

namespace SLS.Widgets.Table
{
	public class DataTableData
	{
		public class Population
		{
			public string city { get; set; }

			public string country { get; set; }

			public int rank { get; set; }

			public int population { get; set; }

			public int density { get; set; }

			public float sqkm { get; set; }

			public string extraText { get; set; }

			public int iconIndex { get; set; }

			public Population(string city, string country, int rank, int pop, int den, float sqkm)
			{
			}
		}

		public static List<Population> Generate()
		{
			return null;
		}
	}
}
