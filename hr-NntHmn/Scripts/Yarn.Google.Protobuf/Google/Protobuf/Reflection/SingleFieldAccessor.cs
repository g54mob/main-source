using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
	internal sealed class SingleFieldAccessor : FieldAccessorBase
	{
		private readonly Action<IMessage, object> setValueDelegate;

		private readonly Action<IMessage> clearDelegate;

		private readonly Func<IMessage, bool> hasDelegate;

		internal SingleFieldAccessor([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type messageType, PropertyInfo property, FieldDescriptor descriptor)
			: base(null, null)
		{
		}

		private static object GetDefaultValue(FieldDescriptor descriptor)
		{
			return null;
		}

		public override void Clear(IMessage message)
		{
		}

		public override bool HasValue(IMessage message)
		{
			return false;
		}

		public override void SetValue(IMessage message, object value)
		{
		}
	}
}
