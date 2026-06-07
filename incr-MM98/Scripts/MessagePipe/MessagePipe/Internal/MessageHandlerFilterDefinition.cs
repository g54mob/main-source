using System;
using System.Linq;

namespace MessagePipe.Internal
{
	internal sealed class MessageHandlerFilterDefinition : FilterDefinition
	{
		public Type MessageType { get; }

		public bool IsOpenGenerics { get; }

		public MessageHandlerFilterDefinition(Type filterType, int order, Type interfaceGenericDefinition)
			: base(filterType, order)
		{
			if (filterType.IsGenericType && !filterType.IsConstructedGenericType)
			{
				IsOpenGenerics = true;
				MessageType = null;
				return;
			}
			IsOpenGenerics = false;
			Type[] genericArguments = filterType.GetBaseTypes().First((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == interfaceGenericDefinition).GetGenericArguments();
			MessageType = genericArguments[0];
		}
	}
}
