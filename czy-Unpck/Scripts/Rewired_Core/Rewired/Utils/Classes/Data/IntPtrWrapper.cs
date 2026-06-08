using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr LtawfeQxLhUCbaPETyueHwZrGmP;

		public bool IsValid => LtawfeQxLhUCbaPETyueHwZrGmP != IntPtr.Zero;

		public IntPtrWrapper(IntPtr pointer)
		{
			LtawfeQxLhUCbaPETyueHwZrGmP = pointer;
		}

		public void Clear()
		{
			LtawfeQxLhUCbaPETyueHwZrGmP = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.LtawfeQxLhUCbaPETyueHwZrGmP ?? IntPtr.Zero;
		}
	}
}
