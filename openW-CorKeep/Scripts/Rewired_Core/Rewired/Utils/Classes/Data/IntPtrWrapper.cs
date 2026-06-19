using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr eqUBQznMjXZXuAdIsfRLjTvsBalmA;

		public bool IsValid => eqUBQznMjXZXuAdIsfRLjTvsBalmA != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			eqUBQznMjXZXuAdIsfRLjTvsBalmA = P_0;
		}

		public void Clear()
		{
			eqUBQznMjXZXuAdIsfRLjTvsBalmA = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.eqUBQznMjXZXuAdIsfRLjTvsBalmA ?? IntPtr.Zero;
		}
	}
}
