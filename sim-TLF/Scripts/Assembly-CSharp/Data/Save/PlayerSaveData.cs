using System;
using UnityEngine;

namespace Data.Save
{
	[Serializable]
	public class PlayerSaveData
	{
		public Vector3 Position;

		public Vector3 Rotation;

		public float Nicotine;

		public float Alcohol;

		public PlayerData MoneyData = new PlayerData();

		public PlayerGameData GameData = new PlayerGameData();
	}
}
