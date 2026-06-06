using System;
using System.Linq;

namespace MessagePipe.Internal
{
	internal sealed class RequestHandlerFilterDefinition : FilterDefinition
	{
		public Type RequestType { get; }

		public Type ResponseType { get; }

		public bool IsOpenGenerics { get; }

		public RequestHandlerFilterDefinition(Type filterType, int order, Type interfaceGenericDefinition)
			: base(filterType, order)
		{
			if (filterType.IsGenericType && !filterType.IsConstructedGenericType)
			{
				IsOpenGenerics = true;
				RequestType = null;
				ResponseType = null;
				return;
			}
			IsOpenGenerics = false;
			Type[] genericArguments = filterType.GetBaseTypes().First((Type x) => x.IsGenericType && x.GetGenericTypeDefinition() == interfaceGenericDefinition).GetGenericArguments();
			RequestType = genericArguments[0];
			ResponseType = genericArguments[1];
		}
	}
}
