using System;

namespace Factory
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class SerializeAttribute : Attribute
	{
		public bool IsSerialized { get; private set; }

		public ISerializer CustomSerializer { get; private set; }

		public SerializeAttribute(bool serialize = true, Type serializer = null)
		{
			IsSerialized = serialize;
			if (serializer != null)
			{
				CustomSerializer = Activator.CreateInstance(serializer) as ISerializer;
			}
		}
	}
}
