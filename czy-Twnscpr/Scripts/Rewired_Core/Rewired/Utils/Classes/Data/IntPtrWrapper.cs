using System;

namespace Rewired.Utils.Classes.Data
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class IntPtrWrapper
	{
		private IntPtr eOMJVlEIasgXGlPhHMNJvUPxVGx;

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
