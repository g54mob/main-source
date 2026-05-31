using System;
using ExitGames.Client.Photon;
using UnityEngine.Serialization;

namespace __Project__.Scripts.WallPaintSystem
{
	[Serializable]
	public class BucketData
	{
		public int ProductID;

		[FormerlySerializedAs("colorType")]
		public int colorIndex;

		public int paintAmount;

		private static readonly byte[] m_MemBucketData;

		public BucketData(int id, int index, int paintCount)
		{
		}

		public BucketData()
		{
		}

		public static short Serialize(StreamBuffer outStream, object customObject)
		{
			return 0;
		}

		public static object Deserialize(StreamBuffer inStream, short length)
		{
			return null;
		}
	}
}
