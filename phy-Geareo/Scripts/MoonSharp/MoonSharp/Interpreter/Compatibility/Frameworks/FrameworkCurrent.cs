using System;

namespace MoonSharp.Interpreter.Compatibility.Frameworks
{
	internal class FrameworkCurrent : FrameworkClrBase
	{
		public override bool IsDbNull(object o)
		{
			return false;
		}

		public override bool StringContainsChar(string str, char chr)
		{
			return false;
		}

		public override Type GetInterface(Type type, string name)
		{
			return null;
		}
	}
}
