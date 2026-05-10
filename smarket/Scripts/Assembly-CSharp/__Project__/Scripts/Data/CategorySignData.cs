using System;
using ExitGames.Client.Photon;
using NaisuPorter.CommonScripts;

namespace __Project__.Scripts.Data
{
	[Serializable]
	public class CategorySignData
	{
		public string SignName;

		public int SignNameColorIndex;

		public int NameBackGroundColorIndex;

		public int AtlasIndex;

		public SerializableVector2Int AtlasPosition;

		public int IconIndex;

		public int FurnitureID;

		public TransformData Transform;

		private static readonly byte[] m_Bytes;

		public void Clear()
		{
		}

		private static int GetSize()
		{
			return 0;
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
