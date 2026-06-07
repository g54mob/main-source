using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace UMA
{
	[Serializable]
	public class BinaryDefinition
	{
		public AvatarDefinition adf;

		public BinaryDefinition(AvatarDefinition Adf)
		{
		}

		public static byte[] ToBinary(BinaryFormatter bf, AvatarDefinition adf)
		{
			return null;
		}

		public AvatarDefinition FromBinary(byte[] bin, BinaryFormatter bf)
		{
			return default(AvatarDefinition);
		}
	}
}
