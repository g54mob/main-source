using System;

namespace Google.Protobuf.Reflection
{
	public sealed class DescriptorValidationException : Exception
	{
		public string ProblemSymbolName { get; }

		public string Description { get; }

		internal DescriptorValidationException(IDescriptor problemDescriptor, string description)
		{
		}

		internal DescriptorValidationException(IDescriptor problemDescriptor, string description, Exception cause)
		{
		}
	}
}
