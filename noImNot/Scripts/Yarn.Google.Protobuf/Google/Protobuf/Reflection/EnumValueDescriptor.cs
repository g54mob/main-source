using System;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class EnumValueDescriptor : DescriptorBase
	{
		internal EnumValueDescriptorProto Proto { get; }

		public override string Name => null;

		public int Number => 0;

		public EnumDescriptor EnumDescriptor { get; }

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		internal EnumValueDescriptor(EnumValueDescriptorProto proto, FileDescriptor file, EnumDescriptor parent, int index)
			: base(null, null, 0)
		{
		}

		public EnumValueDescriptorProto ToProto()
		{
			return null;
		}

		public EnumValueOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<EnumValueOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<EnumValueOptions, T> extension)
		{
			return null;
		}
	}
}
