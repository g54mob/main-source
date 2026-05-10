using System.Collections.Generic;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("Type = {GetType().Name,nq}, FullName = {FullName}")]
	public abstract class DescriptorBase : IDescriptor
	{
		public int Index { get; }

		public abstract string Name { get; }

		public string FullName { get; }

		public FileDescriptor File { get; }

		public DescriptorDeclaration Declaration => null;

		internal DescriptorBase(FileDescriptor file, string fullName, int index)
		{
		}

		internal virtual IReadOnlyList<DescriptorBase> GetNestedDescriptorListForField(int fieldNumber)
		{
			return null;
		}
	}
}
