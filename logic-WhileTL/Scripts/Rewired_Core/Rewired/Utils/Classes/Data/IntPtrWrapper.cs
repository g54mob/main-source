using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IntPtrWrapper
	{
		private IntPtr zypAcHiqOcqQaBxJKFOafDPKZjcBc;

		public bool IsValid => zypAcHiqOcqQaBxJKFOafDPKZjcBc != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			zypAcHiqOcqQaBxJKFOafDPKZjcBc = P_0;
		}

		public void Clear()
		{
			zypAcHiqOcqQaBxJKFOafDPKZjcBc = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.zypAcHiqOcqQaBxJKFOafDPKZjcBc ?? IntPtr.Zero;
		}
	}
}
