using System;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
	public sealed class OneofAccessor
	{
		private readonly Func<IMessage, int> caseDelegate;

		private readonly Action<IMessage> clearDelegate;

		public OneofDescriptor Descriptor { get; }

		private OneofAccessor(OneofDescriptor descriptor, Func<IMessage, int> caseDelegate, Action<IMessage> clearDelegate)
		{
		}

		internal static OneofAccessor ForRegularOneof(OneofDescriptor descriptor, PropertyInfo caseProperty, MethodInfo clearMethod)
		{
			return null;
		}

		internal static OneofAccessor ForSyntheticOneof(OneofDescriptor descriptor)
		{
			return null;
		}

		public void Clear(IMessage message)
		{
		}

		public FieldDescriptor GetCaseFieldDescriptor(IMessage message)
		{
			return null;
		}
	}
}
