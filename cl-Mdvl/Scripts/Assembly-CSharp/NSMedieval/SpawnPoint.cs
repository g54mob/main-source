using System;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class SpawnPoint
	{
		[SerializeField]
		public Vec3Int Position;

		[SerializeField]
		public SpawnPointType Type;

		[SerializeField]
		public int SetIndex;

		public SpawnPoint()
		{
		}

		public SpawnPoint(Vec3Int position, SpawnPointType type, int setIndex = 0)
		{
			Position = position;
			Type = type;
			SetIndex = setIndex;
		}
	}
}
