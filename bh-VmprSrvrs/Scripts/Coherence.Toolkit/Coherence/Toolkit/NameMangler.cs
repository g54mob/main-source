using System.Text.RegularExpressions;

namespace Coherence.Toolkit
{
	internal static class NameMangler
	{
		private static readonly Regex invalidOnCSharpIdentifierFirstCharacter;

		private static readonly Regex invalidOnCSharpIdentifierSubsequentCharacters;

		private static readonly Regex invalidOnSchemaIdentifierRegex;

		public static string MangleSchemaIdentifier(string s)
		{
			return null;
		}

		public static string MangleCSharpIdentifier(string s)
		{
			return null;
		}

		private static string CharsToInts(Match match)
		{
			return null;
		}
	}
}
