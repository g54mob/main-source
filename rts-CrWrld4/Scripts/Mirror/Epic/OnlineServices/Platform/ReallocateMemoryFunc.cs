using System;

namespace Epic.OnlineServices.Platform
{
	public delegate IntPtr ReallocateMemoryFunc(IntPtr pointer, UIntPtr sizeInBytes, UIntPtr alignment);
}
