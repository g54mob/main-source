namespace Humanizer.Localisation.NumberToWords
{
	internal class SwedishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private class Fact
		{
			public int Value { get; set; }

			public string Name { get; set; }

			public string Prefix { get; set; }

			public string Postfix { get; set; }

			public bool DisplayOneUnit { get; set; }

			public GrammaticalGender Gender { get; set; }
		}

		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly Fact[] Hunderds;

		private static string[] ordinalNumbers;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

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
