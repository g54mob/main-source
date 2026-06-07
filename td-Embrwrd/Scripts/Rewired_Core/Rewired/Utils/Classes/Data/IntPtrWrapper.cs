using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr yPyRcMocHPNlTzVSgPShvYVVBqFI;

		public bool IsValid => false;

		public IntPtrWrapper(IntPtr P_0)
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
