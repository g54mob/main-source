using System;

namespace IngameDebugConsole
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	public class ConsoleCustomTypeParserAttribute : ConsoleAttribute
	{
		public readonly Type type;

		public readonly string readableName;

		public override int Order => 0;

		public ConsoleCustomTypeParserAttribute(Type type, string readableName = null)
		{
		}

		public override void Load()
		{
		}
	}
}
