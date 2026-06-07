using System;

namespace Epic.OnlineServices
{
	internal class ArrayAllocationException : AllocationException
	{
		public ArrayAllocationException(IntPtr address, int foundLength, int expectedLength)
			: base(null)
		{
		}
	}
}
