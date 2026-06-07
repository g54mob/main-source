using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr mKWCgbXJAXRaChivvKayOlhJznpC;

		public bool IsValid => mKWCgbXJAXRaChivvKayOlhJznpC != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			mKWCgbXJAXRaChivvKayOlhJznpC = P_0;
		}

		public void Clear()
		{
			mKWCgbXJAXRaChivvKayOlhJznpC = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.mKWCgbXJAXRaChivvKayOlhJznpC ?? IntPtr.Zero;
		}
	}
}
