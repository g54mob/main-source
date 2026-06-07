using System;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class FieldDescriptor : DescriptorBase, IComparable<FieldDescriptor>
	{
		private EnumDescriptor enumType;

		private MessageDescriptor extendeeType;

		private MessageDescriptor messageType;

		private FieldType fieldType;

		private IFieldAccessor accessor;

		public MessageDescriptor ContainingType { get; }

		public OneofDescriptor ContainingOneof { get; }

		public OneofDescriptor RealContainingOneof => null;

		public string JsonName { get; }

		public string PropertyName { get; }

		public bool HasPresence => false;

		internal FieldDescriptorProto Proto { get; }

		public Extension Extension { get; }

		public override string Name => null;

		public IFieldAccessor Accessor => null;

		public bool IsRepeated => false;

		public bool IsRequired => false;

		public bool IsMap => false;

		public bool IsPacked => false;

		public bool IsExtension => false;

		public FieldType FieldType => default(FieldType);

		public int FieldNumber => 0;

		public EnumDescriptor EnumType => null;

		public MessageDescriptor MessageType => null;

		public MessageDescriptor ExtendeeType => null;

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		public FieldDescriptorProto ToProto()
		{
			return null;
		}

		internal FieldDescriptor(FieldDescriptorProto proto, FileDescriptor file, MessageDescriptor parent, int index, string propertyName, Extension extension)
			: base(null, null, 0)
		{
		}

		private static FieldType GetFieldTypeFromProtoType(FieldDescriptorProto.Types.Type type)
		{
			return default(FieldType);
		}

		public int CompareTo(FieldDescriptor other)
		{
			return 0;
		}

		public FieldOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<FieldOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<FieldOptions, T> extension)
		{
			return null;
		}

		internal void CrossLink()
		{
		}

		private IFieldAccessor CreateAccessor()
		{
			return null;
		}
	}
}
