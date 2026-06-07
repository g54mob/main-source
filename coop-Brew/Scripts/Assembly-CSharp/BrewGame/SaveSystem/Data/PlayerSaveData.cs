using System;
using System.Collections.Generic;
using UnityEngine;

namespace BrewGame.SaveSystem.Data
{
	[Serializable]
	public class PlayerSaveData
	{
		public string steamId;

		public string playerName;

		public float posX;

		public float posY;

		public float posZ;

		public float rotX;

		public float rotY;

		public float rotZ;

		public float dollars;

		public float currentHealth;

		public bool isDead;

		public List<InventorySlotSaveData> inventorySlots;

		public int selectedSlotIndex;

		public bool isMale;

		public int hatID;

		public int glassesID;

		public bool hasWheat;

		public int skinColorID;

		public int totalSkillLevels;

		public int standSalesCount;

		public int barSalesCount;

		public int propertiesOwned;

		public float currentStamina;

		public string equippedWeaponId;

		public float arrestProgress;

		public bool isArrested;

		public int wantedStatus;

		public int unpunishedOffenseCount;

		public bool isSpeedBoostActive;

		public bool isJumpBoostActive;

		public float effectRemainingDuration;

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

		public static PlayerSaveData CreateDefault(string steamId, string playerName)
		{
			return null;
		}
	}
}
