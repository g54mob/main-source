using System;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class MethodDescriptor : DescriptorBase
	{
		public ServiceDescriptor Service { get; }

		public MessageDescriptor InputType { get; private set; }

		public MessageDescriptor OutputType { get; private set; }

		public bool IsClientStreaming => false;

		public bool IsServerStreaming => false;

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		internal MethodDescriptorProto Proto { get; private set; }

		public override string Name => null;

		public MethodOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<MethodOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<MethodOptions, T> extension)
		{
			return null;
		}

		internal MethodDescriptor(MethodDescriptorProto proto, FileDescriptor file, ServiceDescriptor parent, int index)
			: base(null, null, 0)
		{
		}

		public MethodDescriptorProto ToProto()
		{
			return null;
		}

		internal void CrossLink()
		{
		}
	}
}
