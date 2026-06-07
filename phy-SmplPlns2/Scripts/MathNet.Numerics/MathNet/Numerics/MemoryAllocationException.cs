using System;

namespace MathNet.Numerics
{
	[Serializable]
	public class MemoryAllocationException : NativeInterfaceException
	{
		public MemoryAllocationException()
			: base("Unable to allocate native memory.")
		{
		}

		public MemoryAllocationException(Exception innerException)
			: base("Unable to allocate native memory.", innerException)
		{
		}
	}
}
