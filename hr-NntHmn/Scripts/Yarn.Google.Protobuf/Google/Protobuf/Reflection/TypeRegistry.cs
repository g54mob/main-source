using System.Collections.Generic;
using System.Diagnostics;

namespace Google.Protobuf.Reflection
{
	[DebuggerDisplay("Count = {fullNameToMessageMap.Count}")]
	[DebuggerTypeProxy(typeof(TypeRegistryDebugView))]
	public sealed class TypeRegistry
	{
		private class Builder
		{
			private readonly Dictionary<string, MessageDescriptor> types;

			private readonly HashSet<string> fileDescriptorNames;

			internal Builder()
			{
			}

			internal void AddFile(FileDescriptor fileDescriptor)
			{
			}

			private void AddMessage(MessageDescriptor messageDescriptor)
			{
			}

			internal TypeRegistry Build()
			{
				return null;
			}
		}

		private sealed class TypeRegistryDebugView
		{
			private readonly TypeRegistry list;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public KeyValuePair<string, MessageDescriptor>[] Items => null;

			public TypeRegistryDebugView(TypeRegistry list)
			{
			}
		}

		private readonly Dictionary<string, MessageDescriptor> fullNameToMessageMap;

		public static TypeRegistry Empty { get; }

		private TypeRegistry(Dictionary<string, MessageDescriptor> fullNameToMessageMap)
		{
		}

		public MessageDescriptor Find(string fullName)
		{
			return null;
		}

		public static TypeRegistry FromFiles(params FileDescriptor[] fileDescriptors)
		{
			return null;
		}

		public static TypeRegistry FromFiles(IEnumerable<FileDescriptor> fileDescriptors)
		{
			return null;
		}

		public static TypeRegistry FromMessages(params MessageDescriptor[] messageDescriptors)
		{
			return null;
		}

		public static TypeRegistry FromMessages(IEnumerable<MessageDescriptor> messageDescriptors)
		{
			return null;
		}
	}
}
