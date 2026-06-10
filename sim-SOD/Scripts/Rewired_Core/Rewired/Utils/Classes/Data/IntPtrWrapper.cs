using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class IntPtrWrapper
	{
		private IntPtr fjhKhWgNSIaCGznlHdslEVwQMWbC;

		public bool IsValid => false;

		public IntPtrWrapper(IntPtr pointer)
		{
		}

		public void Clear()
		{
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return (IntPtr)0;
		}
	}
}
