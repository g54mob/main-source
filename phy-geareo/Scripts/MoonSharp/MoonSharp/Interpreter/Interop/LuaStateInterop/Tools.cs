using System.IO;
using System.Text.RegularExpressions;

namespace MoonSharp.Interpreter.Interop.LuaStateInterop
{
	internal static class Tools
	{
		internal static Regex r;

		public static bool IsNumericType(object o)
		{
			return false;
		}

		public static bool IsPositive(object Value, bool ZeroIsPositive)
		{
			return false;
		}

		public static object ToUnsigned(object Value)
		{
			return null;
		}

		public static object ToInteger(object Value, bool Round)
		{
			return null;
		}

		public static long UnboxToLong(object Value, bool Round)
		{
			return 0L;
		}

		public static string ReplaceMetaChars(string input)
		{
			return null;
		}

		private static string ReplaceMetaCharsMatch(Match m)
		{
			return null;
		}

		public static void fprintf(TextWriter Destination, string Format, params object[] Parameters)
		{
		}

		public static string sprintf(string Format, params object[] Parameters)
		{
			return null;
		}

		private static string FormatOct(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, char Padding, object Value)
		{
			return null;
		}

		private static string FormatHex(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, char Padding, object Value)
		{
			return null;
		}

		private static string FormatNumber(string NativeFormat, bool Alternate, int FieldLength, int FieldPrecision, bool Left2Right, bool PositiveSign, bool PositiveSpace, char Padding, object Value)
		{
			return null;
		}
	}
}
