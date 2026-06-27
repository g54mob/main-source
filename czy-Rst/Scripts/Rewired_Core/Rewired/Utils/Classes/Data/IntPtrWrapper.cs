using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr jtpUUhWwYNjvfBJwORhgdkagFDKgA;

		public bool IsValid => jtpUUhWwYNjvfBJwORhgdkagFDKgA != IntPtr.Zero;

		public IntPtrWrapper(IntPtr P_0)
		{
			jtpUUhWwYNjvfBJwORhgdkagFDKgA = P_0;
		}

		public void Clear()
		{
			jtpUUhWwYNjvfBJwORhgdkagFDKgA = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.jtpUUhWwYNjvfBJwORhgdkagFDKgA ?? IntPtr.Zero;
		}
	}
}
