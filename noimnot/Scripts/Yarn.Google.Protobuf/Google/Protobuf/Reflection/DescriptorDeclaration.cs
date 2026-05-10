using System.Collections.Generic;

namespace Google.Protobuf.Reflection
{
	public sealed class DescriptorDeclaration
	{
		public IDescriptor Descriptor { get; }

		public int StartLine { get; }

		public int StartColumn { get; }

		public int EndLine { get; }

		public int EndColumn { get; }

		public string LeadingComments { get; }

		public string TrailingComments { get; }

		public IReadOnlyList<string> LeadingDetachedComments { get; }

		private DescriptorDeclaration(IDescriptor descriptor, SourceCodeInfo.Types.Location location)
		{
		}

		internal static DescriptorDeclaration FromProto(IDescriptor descriptor, SourceCodeInfo.Types.Location location)
		{
			return null;
		}
	}
}
