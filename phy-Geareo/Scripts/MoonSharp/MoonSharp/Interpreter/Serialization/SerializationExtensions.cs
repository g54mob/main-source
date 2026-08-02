using System.Collections.Generic;

namespace MoonSharp.Interpreter.Serialization
{
	public static class SerializationExtensions
	{
		private static HashSet<string> LUAKEYWORDS;

		public static string Serialize(this Table table, bool prefixReturn = false, int tabs = 0)
		{
			return null;
		}

		private static bool IsStringIdentifierValid(DynValue dynValue)
		{
			return false;
		}

		public static string SerializeValue(this DynValue dynValue, int tabs = 0)
		{
			return null;
		}

		private static string EscapeString(string s)
		{
			return null;
		}
	}
}
