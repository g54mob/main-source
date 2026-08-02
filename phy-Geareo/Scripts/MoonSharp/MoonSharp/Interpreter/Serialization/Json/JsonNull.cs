namespace MoonSharp.Interpreter.Serialization.Json
{
	public sealed class JsonNull
	{
		public static bool isNull()
		{
			return false;
		}

		[MoonSharpHidden]
		public static bool IsJsonNull(DynValue v)
		{
			return false;
		}

		[MoonSharpHidden]
		public static DynValue Create()
		{
			return null;
		}
	}
}
