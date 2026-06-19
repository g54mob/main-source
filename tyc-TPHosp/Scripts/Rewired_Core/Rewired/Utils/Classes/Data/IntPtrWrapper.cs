using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr FPpcdJSxWXwvPVhduHTzpLaxyjS;

		public bool IsValid => FPpcdJSxWXwvPVhduHTzpLaxyjS != IntPtr.Zero;

		public IntPtrWrapper(IntPtr pointer)
		{
			FPpcdJSxWXwvPVhduHTzpLaxyjS = pointer;
		}

		public void Clear()
		{
			FPpcdJSxWXwvPVhduHTzpLaxyjS = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.FPpcdJSxWXwvPVhduHTzpLaxyjS ?? IntPtr.Zero;
		}
	}
}
