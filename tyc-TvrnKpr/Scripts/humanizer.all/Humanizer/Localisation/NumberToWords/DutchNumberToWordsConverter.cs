using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class DutchNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private class Fact
		{
			public long Value { get; set; }

			public string Name { get; set; }

			public string Prefix { get; set; }

			public string Postfix { get; set; }

			public bool DisplayOneUnit { get; set; }
		}

		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly Fact[] Hunderds;

		private static readonly Dictionary<string, string> OrdinalExceptions;

		private static readonly char[] EndingCharForSte;

		public override string Convert(long input)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}
	}
}
