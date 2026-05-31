using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class IntPtrWrapper
	{
		private IntPtr bTBYkvbedIFVHMNStTauvbJZdKq;

		public bool IsValid => bTBYkvbedIFVHMNStTauvbJZdKq != IntPtr.Zero;

		public IntPtrWrapper(IntPtr pointer)
		{
			bTBYkvbedIFVHMNStTauvbJZdKq = pointer;
		}

		public void Clear()
		{
			bTBYkvbedIFVHMNStTauvbJZdKq = IntPtr.Zero;
		}

		public static implicit operator IntPtr(IntPtrWrapper obj)
		{
			return obj?.bTBYkvbedIFVHMNStTauvbJZdKq ?? IntPtr.Zero;
		}
	}
}
