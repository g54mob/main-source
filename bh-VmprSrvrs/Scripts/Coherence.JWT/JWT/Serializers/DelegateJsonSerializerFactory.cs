using System;

namespace JWT.Serializers
{
	internal sealed class DelegateJsonSerializerFactory : IJsonSerializerFactory
	{
		private readonly Func<IJsonSerializer> _factory;

		public DelegateJsonSerializerFactory(IJsonSerializer jsonSerializer)
		{
		}

		public DelegateJsonSerializerFactory(IJsonSerializerFactory factory)
		{
		}

		public DelegateJsonSerializerFactory(Func<IJsonSerializer> factory)
		{
		}

		public IJsonSerializer Create()
		{
			return null;
		}
	}
}
