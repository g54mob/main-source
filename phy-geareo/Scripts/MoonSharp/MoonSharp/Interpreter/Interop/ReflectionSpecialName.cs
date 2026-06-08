namespace MoonSharp.Interpreter.Interop
{
	public struct ReflectionSpecialName
	{
		public ReflectionSpecialNameType Type { get; private set; }

		public string Argument { get; private set; }

		public ReflectionSpecialName(ReflectionSpecialNameType type, string argument = null)
		{
			Type = default(ReflectionSpecialNameType);
			Argument = null;
		}

		public ReflectionSpecialName(string name)
		{
			Type = default(ReflectionSpecialNameType);
			Argument = null;
		}
	}
}
