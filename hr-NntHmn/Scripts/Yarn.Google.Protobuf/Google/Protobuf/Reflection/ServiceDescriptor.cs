using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace Google.Protobuf.Reflection
{
	public sealed class ServiceDescriptor : DescriptorBase
	{
		public override string Name => null;

		internal ServiceDescriptorProto Proto { get; }

		public IList<MethodDescriptor> Methods { get; }

		[Obsolete("CustomOptions are obsolete. Use the GetOptions() method.")]
		public CustomOptions CustomOptions => null;

		internal ServiceDescriptor(ServiceDescriptorProto proto, FileDescriptor file, int index)
			: base(null, null, 0)
		{
		}

		internal override IReadOnlyList<DescriptorBase> GetNestedDescriptorListForField(int fieldNumber)
		{
			return null;
		}

		public ServiceDescriptorProto ToProto()
		{
			return null;
		}

		public MethodDescriptor FindMethodByName(string name)
		{
			return null;
		}

		public ServiceOptions GetOptions()
		{
			return null;
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public T GetOption<T>(Extension<ServiceOptions, T> extension)
		{
			return default(T);
		}

		[Obsolete("GetOption is obsolete. Use the GetOptions() method.")]
		public RepeatedField<T> GetOption<T>(RepeatedExtension<ServiceOptions, T> extension)
		{
			return null;
		}

		internal void CrossLink()
		{
		}
	}
}
