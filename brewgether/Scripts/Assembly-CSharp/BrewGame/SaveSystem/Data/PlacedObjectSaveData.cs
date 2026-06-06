using System;
using UnityEngine;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class PlacedObjectSaveData
	{
		public int registryId;

		public string sourceItemId;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public string placerSteamId;

		public bool isPlaced;

		public Vector3 Position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion Rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}
	}
}
