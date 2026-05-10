using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class MessageDescriptor : DescriptorBase
	{
		[DebuggerDisplay("Count = {InFieldNumberOrder().Count}")]
		[DebuggerTypeProxy(typeof(FieldCollectionDebugView))]
		public sealed class FieldCollection
		{
			private sealed class FieldCollectionDebugView
			{
				private readonly FieldCollection collection;

				[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
				public FieldDescriptor[] Items => null;

				public FieldCollectionDebugView(FieldCollection collection)
				{
				}
			}

			private readonly MessageDescriptor messageDescriptor;

			public FieldDescriptor this[int number] => null;

			public FieldDescriptor this[string name] => null;

			internal FieldCollection(MessageDescriptor messageDescriptor)
			{
			}

			public IList<FieldDescriptor> InDeclarationOrder()
			{
				return null;
			}

			public IList<FieldDescriptor> InFieldNumberOrder()
			{
				return null;
			}

			internal IDictionary<string, FieldDescriptor> ByJsonName()
			{
				return null;
			}
		}

		private static readonly HashSet<string> WellKnownTypeNames;

		private readonly IList<FieldDescriptor> fieldsInDeclarationOrder;

		private readonly IList<FieldDescriptor> fieldsInNumberOrder;

		private readonly IDictionary<string, FieldDescriptor> jsonFieldMap;

		private Func<IMessage, bool> extensionSetIsInitialized;

		public override string Name => null;

		internal DescriptorProto Proto { get; }

		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)]
		public Type ClrType { get; }

		public MessageParser Parser { get; }

		internal bool IsWellKnownType => false;

		internal bool IsWrapperType => false;

		public MessageDescriptor ContainingType { get; }

		public FieldCollection Fields { get; }

		public ExtensionCollection Extensions { get; }

		public IList<MessageDescriptor> NestedTypes { get; }

		public IList<EnumDescriptor> EnumTypes { get; }

		public IList<OneofDescriptor> Oneofs { get; }

		public int RealOneofCount { get; }

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		internal MessageDescriptor(DescriptorProto proto, FileDescriptor file, MessageDescriptor parent, int typeIndex, GeneratedClrTypeInfo generatedCodeInfo)
			: base(null, null, 0)
		{
		}

		private static ReadOnlyDictionary<string, FieldDescriptor> CreateJsonFieldMap(IList<FieldDescriptor> fields)
		{
			return null;
		}

		internal override IReadOnlyList<DescriptorBase> GetNestedDescriptorListForField(int fieldNumber)
		{
			return null;
		}

		public DescriptorProto ToProto()
		{
			return null;
		}

		internal bool IsExtensionsInitialized(IMessage message)
		{
			return false;
		}

		public FieldDescriptor FindFieldByName(string name)
		{
			return null;
		}

		public FieldDescriptor FindFieldByNumber(int number)
		{
			return null;
		}

		public T FindDescriptor<T>(string name) where T : class, IDescriptor
		{
			return null;
		}

		public MessageOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<MessageOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<MessageOptions, T> extension)
		{
			return null;
		}

		internal void CrossLink()
		{
		}
	}
}
