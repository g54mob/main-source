using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class StationSaveData
	{
		public int registryId;

		public string stationType;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public int stationState;

		public float processingProgress;

		public int currentStep;

		public List<InventorySlotSaveData> inputSlots;

		public List<InventorySlotSaveData> outputSlots;

		public bool hasTier1Upgrade;

		public bool hasTier2Upgrade;

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
