using System.Collections.Generic;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal static class SVGStyleSheetUtils
	{
		public static SVGStyleSheet Parse(string cssText)
		{
			return null;
		}

		public static SVGPropertySheet ParseInline(string cssText)
		{
			return null;
		}

		private static bool ParseSelector(List<string> tokens, SVGStyleSheet sheet)
		{
			return false;
		}

		private static void CombineProperties(SVGPropertySheet first, SVGPropertySheet second)
		{
		}

		private static SVGPropertySheet CopyProperties(SVGPropertySheet props)
		{
			return null;
		}

		private static bool ParseProperties(List<string> tokens, SVGPropertySheet props)
		{
			return false;
		}

		private static bool ParseProperty(List<string> tokens, out string name, out string value)
		{
			name = null;
			value = null;
			return false;
		}

		private static string ParseParenValue(List<string> tokens)
		{
			return null;
		}

		public static List<string> Tokenize(string cssText)
		{
			return null;
		}

		private static string PeekToken(List<string> tokens)
		{
			return null;
		}

		private static string PopToken(List<string> tokens)
		{
			return null;
		}

		private static bool IsSeparator(char ch)
		{
			return false;
		}

		private static bool IsWhitespace(char ch)
		{
			return false;
		}
	}
}
