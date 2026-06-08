namespace MoonSharp.Interpreter.CoreLib.StringLib
{
	internal class StringRange
	{
		public int Start { get; set; }

		public int End { get; set; }

		public StringRange()
		{
		}

		public StringRange(int start, int end)
		{
		}

		public static StringRange FromLuaRange(DynValue start, DynValue end, int? defaultEnd = null)
		{
			return null;
		}

		public string ApplyToString(string value)
		{
			return null;
		}

		public int Length()
		{
			return 0;
		}
	}
}
