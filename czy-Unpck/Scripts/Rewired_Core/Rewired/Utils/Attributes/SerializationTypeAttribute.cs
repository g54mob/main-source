using System;

namespace Rewired.Utils.Attributes
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class SerializationTypeAttribute : Attribute
	{
		public enum SerializationType
		{
			Default = 0,
			Object = 1
		}

		private SerializationType _serializationType;

		public SerializationType serializationType => _serializationType;

		public SerializationTypeAttribute(SerializationType serializationType)
		{
			while (true)
			{
				int num = 1831423404;
				while (true)
				{
					switch (num ^ 0x6D294DAE)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0024;
					case 1:
						return;
					}
					break;
					IL_0024:
					_serializationType = serializationType;
					num = 1831423407;
				}
			}
		}
	}
}
