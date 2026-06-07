using System;
using System.IO;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	[Serializable]
	public class BakedSortedFeatureResult
	{
		public float angularSize;

		public int featureID;

		public float minAltitude;

		public static BakedSortedFeatureResult Deserialize(BinaryReader reader)
		{
			return new BakedSortedFeatureResult
			{
				angularSize = reader.ReadSingle(),
				featureID = reader.ReadInt32(),
				minAltitude = reader.ReadSingle()
			};
		}

		public void Serialize(BinaryWriter writer)
		{
			writer.Write(angularSize);
			writer.Write(featureID);
			writer.Write(minAltitude);
		}
	}
}
