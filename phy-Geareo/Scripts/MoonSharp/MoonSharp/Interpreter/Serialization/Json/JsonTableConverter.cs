using System.Text;
using MoonSharp.Interpreter.Tree;

namespace MoonSharp.Interpreter.Serialization.Json
{
	public static class JsonTableConverter
	{
		public static string TableToJson(this Table table)
		{
			return null;
		}

		private static void TableToJson(StringBuilder sb, Table table)
		{
		}

		public static string ObjectToJson(object obj)
		{
			return null;
		}

		private static void ValueToJson(StringBuilder sb, DynValue value)
		{
		}

		private static string EscapeString(string s)
		{
			return null;
		}

		private static bool IsValueJsonCompatible(DynValue value)
		{
			return false;
		}

		public static Table JsonToTable(string json, Script script = null)
		{
			return null;
		}

		private static void AssertToken(Lexer L, TokenType type)
		{
		}

		private static Table ParseJsonArray(Lexer L, Script script)
		{
			return null;
		}

		private static Table ParseJsonObject(Lexer L, Script script)
		{
			return null;
		}

		private static DynValue ParseJsonValue(Lexer L, Script script)
		{
			return null;
		}
	}
}
