using System;

namespace Epic.OnlineServices
{
	internal class TypeAllocationException : AllocationException
	{
		public TypeAllocationException(IntPtr address, Type foundType, Type expectedType)
			: base(null)
		{
		}
	}
}
