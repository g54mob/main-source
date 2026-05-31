using System.Collections.Generic;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("Count = {UnorderedExtensions.Count}")]
	[DebuggerTypeProxy(typeof(ExtensionCollectionDebugView))]
	public sealed class ExtensionCollection
	{
		private sealed class ExtensionCollectionDebugView
		{
			private readonly ExtensionCollection list;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public FieldDescriptor[] Items => null;

			public ExtensionCollectionDebugView(ExtensionCollection list)
			{
			}
		}

		private IDictionary<MessageDescriptor, IList<FieldDescriptor>> extensionsByTypeInDeclarationOrder;

		private IDictionary<MessageDescriptor, IList<FieldDescriptor>> extensionsByTypeInNumberOrder;

		public IList<FieldDescriptor> UnorderedExtensions { get; }

		internal ExtensionCollection(FileDescriptor file, Extension[] extensions)
		{
		}

		internal ExtensionCollection(MessageDescriptor message, Extension[] extensions)
		{
		}

		public IList<FieldDescriptor> GetExtensionsInDeclarationOrder(MessageDescriptor descriptor)
		{
			return null;
		}

		public IList<FieldDescriptor> GetExtensionsInNumberOrder(MessageDescriptor descriptor)
		{
			return null;
		}

		internal void CrossLink()
		{
		}
	}
}
