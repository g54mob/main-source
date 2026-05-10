using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class EnumDescriptor : DescriptorBase
	{
		internal EnumDescriptorProto Proto { get; }

		public override string Name => null;

		public Type ClrType { get; }

		public MessageDescriptor ContainingType { get; }

		public IList<EnumValueDescriptor> Values { get; }

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		internal EnumDescriptor(EnumDescriptorProto proto, FileDescriptor file, MessageDescriptor parent, int index, Type clrType)
			: base(null, null, 0)
		{
		}

		public EnumDescriptorProto ToProto()
		{
			return null;
		}

		internal override IReadOnlyList<DescriptorBase> GetNestedDescriptorListForField(int fieldNumber)
		{
			return null;
		}

		public EnumValueDescriptor FindValueByNumber(int number)
		{
			return null;
		}

		public EnumValueDescriptor FindValueByName(string name)
		{
			return null;
		}

		public EnumOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<EnumOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<EnumOptions, T> extension)
		{
			return null;
		}
	}
}
