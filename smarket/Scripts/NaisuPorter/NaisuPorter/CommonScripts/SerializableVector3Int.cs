using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableVector3Int
	{
		public int x;

		public int y;

		public int z;

		public SerializableVector3Int(Vector3Int initialValue)
		{
		}

		public SerializableVector3Int(int xValue, int yValue, int zValue)
		{
		}

		public static implicit operator SerializableVector3Int(Vector3Int vector)
		{
			return null;
		}

		public static implicit operator Vector3Int(SerializableVector3Int sVector)
		{
			return default(Vector3Int);
		}
	}
}
