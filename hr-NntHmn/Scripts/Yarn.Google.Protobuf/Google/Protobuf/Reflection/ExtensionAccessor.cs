namespace Google.Protobuf.Reflection
{
	internal sealed class ExtensionAccessor : IFieldAccessor
	{
		private readonly Extension extension;

		private readonly ReflectionUtil.IExtensionReflectionHelper helper;

		public FieldDescriptor Descriptor { get; }

		internal ExtensionAccessor(FieldDescriptor descriptor)
		{
		}

		public void Clear(IMessage message)
		{
		}

		public bool HasValue(IMessage message)
		{
			return false;
		}

		public object GetValue(IMessage message)
		{
			return null;
		}

		public void SetValue(IMessage message, object value)
		{
		}
	}
}
