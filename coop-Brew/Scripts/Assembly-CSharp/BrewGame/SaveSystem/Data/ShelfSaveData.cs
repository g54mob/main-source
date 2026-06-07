using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class ShelfSaveData
	{
		public int registryId;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public List<InventorySlotSaveData> inventorySlots;

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
