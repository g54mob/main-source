using System;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class SerializationTypeAttribute : Attribute
	{
		public enum SerializationType
		{
			Default = 0,
			Object = 1
		}

		private SerializationType _serializationType;

		public SerializationType serializationType => _serializationType;

		public SerializationTypeAttribute(SerializationType P_0)
		{
			_serializationType = P_0;
		}
	}
}
