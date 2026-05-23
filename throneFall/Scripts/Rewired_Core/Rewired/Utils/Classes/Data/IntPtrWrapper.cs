using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr LXohULJAWNQJkQdPDwFPWWxbncoc;

		public bool IsValid => LXohULJAWNQJkQdPDwFPWWxbncoc != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			LXohULJAWNQJkQdPDwFPWWxbncoc = P_0;
		}

		public void Clear()
		{
			LXohULJAWNQJkQdPDwFPWWxbncoc = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.LXohULJAWNQJkQdPDwFPWWxbncoc ?? IntPtr.Zero;
		}
	}
}
