using System.Collections.Generic;

namespace RTLTMPro
{
	public static class TashkeelFixer
	{
		private static readonly List<TashkeelLocation> TashkeelLocations;

		private static readonly string ShaddaDammatan;

		private static readonly string ShaddaKasratan;

		private static readonly string ShaddaSuperscriptAlef;

		private static readonly string ShaddaFatha;

		private static readonly string ShaddaDamma;

		private static readonly string ShaddaKasra;

		private static readonly string ShaddaWithFathaIsolatedForm;

		private static readonly string ShaddaWithDammaIsolatedForm;

		private static readonly string ShaddaWithKasraIsolatedForm;

		private static readonly string ShaddaWithDammatanIsolatedForm;

		private static readonly string ShaddaWithKasratanIsolatedForm;

		private static readonly string ShaddaWithSuperscriptAlefIsolatedForm;

		private static readonly HashSet<char> TashkeelCharactersSet;

		private static readonly Dictionary<char, char> ShaddaCombinationMap;

		public static void RemoveTashkeel(FastStringBuilder input)
		{
		}

		public static void RestoreTashkeel(FastStringBuilder letters)
		{
		}

		public static void FixShaddaCombinations(FastStringBuilder input)
		{
		}
	}
}
