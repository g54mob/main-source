namespace MoonSharp.Interpreter
{
	public static class LuaTypeExtensions
	{
		internal const DataType MaxMetaTypes = DataType.Table;

		internal const DataType MaxConvertibleTypes = DataType.ClrFunction;

		public static bool CanHaveTypeMetatables(this DataType type)
		{
			return false;
		}

		public static string ToErrorTypeString(this DataType type)
		{
			return null;
		}

		public static string ToLuaDebuggerString(this DataType type)
		{
			return null;
		}

		public static string ToLuaTypeString(this DataType type)
		{
			return null;
		}
	}
}
