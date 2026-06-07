using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class UnlockedIslandsSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 0;

		public List<Vector3Int> UnlockedIslands;

		public List<Vector3Int> AvaliableIslands;

		public UnlockedIslandsSaveData(List<Vector3Int> unlockedIslands, List<Vector3Int> avaliableIslands)
			: base(0)
		{
			AvaliableIslands = avaliableIslands;
			UnlockedIslands = unlockedIslands;
		}
	}
}
