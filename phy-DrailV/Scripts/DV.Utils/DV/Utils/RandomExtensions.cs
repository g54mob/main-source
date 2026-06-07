using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DV.Utils
{
	public static class RandomExtensions
	{
		public static RandomState Save(this Random random)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream memoryStream = new MemoryStream())
			{
				binaryFormatter.Serialize(memoryStream, random);
				return new RandomState(memoryStream.ToArray());
			}
		}

		public static Random Restore(this RandomState state)
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			using (MemoryStream serializationStream = new MemoryStream(state.State))
			{
				return (Random)binaryFormatter.Deserialize(serializationStream);
			}
		}
	}
}
