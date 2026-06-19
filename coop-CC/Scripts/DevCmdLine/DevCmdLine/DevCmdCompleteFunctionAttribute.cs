using System;

namespace DevCmdLine
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class DevCmdCompleteFunctionAttribute : Attribute
	{
		public readonly string cmdName;

		public readonly string argName;

		public readonly int varIndex;

		public readonly DevCmdCompleteFlags flags;

		public DevCmdCompleteFunctionAttribute(string cmdName, string argName, DevCmdCompleteFlags flags)
			: this(cmdName, argName, 0, flags)
		{
		}

		public DevCmdCompleteFunctionAttribute(string cmdName, string argName, int varIndex, DevCmdCompleteFlags flags)
		{
			this.cmdName = cmdName.ToLower();
			this.argName = argName.ToLower();
			this.varIndex = varIndex;
			this.flags = flags;
		}
	}
}
