using System;

namespace Rewired.Utils.Attributes
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	public class SerializationTypeAttribute : Attribute
	{
		public enum SerializationType
		{
			Default = 0,
			Object = 1
		}

		private SerializationType _serializationType;

		public SerializationType serializationType => default(SerializationType);

		public SerializationTypeAttribute(SerializationType serializationType)
		{
		}
	}
}
