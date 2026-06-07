using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class OneofDescriptor : DescriptorBase
	{
		private MessageDescriptor containingType;

		private IList<FieldDescriptor> fields;

		private readonly OneofAccessor accessor;

		public override string Name => null;

		internal OneofDescriptorProto Proto { get; }

		public MessageDescriptor ContainingType => null;

		public IList<FieldDescriptor> Fields => null;

		public bool IsSynthetic { get; }

		public OneofAccessor Accessor => null;

		[Obsolete("CustomOptions are obsolete. Use the GetOptions method.")]
		public CustomOptions CustomOptions => null;

		internal OneofDescriptor(OneofDescriptorProto proto, FileDescriptor file, MessageDescriptor parent, int index, string clrName)
			: base(null, null, 0)
		{
		}

		public OneofDescriptorProto ToProto()
		{
			return null;
		}

		public OneofOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<OneofOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<OneofOptions, T> extension)
		{
			return null;
		}

		internal void CrossLink()
		{
		}

		private OneofAccessor CreateAccessor(string clrName)
		{
			return null;
		}
	}
}
