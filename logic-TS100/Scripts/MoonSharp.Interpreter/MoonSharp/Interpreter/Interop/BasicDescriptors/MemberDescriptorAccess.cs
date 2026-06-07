using System;

namespace MoonSharp.Interpreter.Interop.BasicDescriptors
{
	[Flags]
	public enum MemberDescriptorAccess
	{
		CanRead = 0,
		CanWrite = 1,
		CanExecute = 2
	}
}
