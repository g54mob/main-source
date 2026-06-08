using System.Collections.Generic;

namespace CsvHelper
{
	public class InvalidHeader
	{
		public List<string> Names { get; set; } = new List<string>();

		public int Index { get; set; }
	}
}
