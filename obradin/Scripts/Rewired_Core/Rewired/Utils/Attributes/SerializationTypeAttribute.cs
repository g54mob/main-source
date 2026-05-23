using System;

namespace Rewired.Utils.Attributes
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class SerializationTypeAttribute : Attribute
	{
		public enum SerializationType
		{
			Default = 0,
			Object = 1
		}

		private SerializationType _serializationType;

		public SerializationType serializationType
		{
			get
			{
				return _serializationType;
			}
		}

		public SerializationTypeAttribute(SerializationType serializationType)
		{
			while (true)
			{
				int num = 649873428;
				while (true)
				{
					switch (num ^ 0x26BC4815)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 0:
						return;
					}
					break;
					IL_0024:
					_serializationType = serializationType;
					num = 649873429;
				}
			}
		}
	}
}
