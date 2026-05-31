using System;
using UnityEngine;

namespace NaisuPorter.CommonScripts
{
	[Serializable]
	public class SerializableVector2Int
	{
		public int x;

		public int y;

		public SerializableVector2Int(Vector2Int initialValue)
		{
		}

		public SerializableVector2Int(int xValue, int yValue)
		{
		}

		public static implicit operator SerializableVector2Int(Vector2Int vector)
		{
			return null;
		}

		public static implicit operator Vector2Int(SerializableVector2Int sVector)
		{
			return default(Vector2Int);
		}
	}
}
