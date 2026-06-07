using System;

namespace Mirror.RemoteCalls
{
	public class Invoker
	{
		public Type invokeClass;

		public MirrorInvokeType invokeType;

		public CmdDelegate invokeFunction;

		public bool cmdRequiresAuthority;

		public bool AreEqual(Type invokeClass, MirrorInvokeType invokeType, CmdDelegate invokeFunction)
		{
			return false;
		}
	}
}
