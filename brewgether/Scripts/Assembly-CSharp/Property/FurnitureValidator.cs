using System.Collections.Generic;
using Brewery.Items;
using UnityEngine;

namespace Property
{
	public abstract class FurnitureValidator : MonoBehaviour
	{
		public struct DetailedFurnitureStatus
		{
			public bool hasTVTable;

			public bool hasTV;

			public bool hasCouch;

			public bool tvOnTable;

			public bool couchFacesTV;

			public bool hasPlant;

			public bool hasDiningTable;

			public bool hasDiningChair;

			public bool diningTableValid;

			public bool diningChairValid;

			public bool hasBed;

			public bool hasFloorLamp;

			public bool bedValid;

			public bool floorLampValid;

			public bool isFullyFurnished;

			public int totalBonusValue;

			public int maxPossibleBonusValue;

			public int validFurnitureCount;

			public int totalFurnitureCount;
		}

		[Header("Debug")]
		[SerializeField]
		protected bool showDebugLogs;

		[SerializeField]
		protected bool showDebugGizmos;

		public abstract FurnitureType FurnitureType { get; }

		public bool IsValid { get; protected set; }

		public string StatusMessage { get; protected set; }

		public int BonusValue { get; protected set; }

		public string HouseId { get; internal set; }

		public virtual void OnPlaced(string houseId)
		{
		}

		public abstract void Validate();

		protected FurnitureData GetFurnitureData()
		{
			return null;
		}

		protected static bool IsLineOfSightClear(FurnitureValidator from, FurnitureValidator to, float radius, out FurnitureValidator blocker, bool debugLogs = false)
		{
			blocker = null;
			return false;
		}

		public static DetailedFurnitureStatus GetDetailedFurnitureStatus(string houseId, bool debugLog = false)
		{
			return default(DetailedFurnitureStatus);
		}

		public static (bool, int) ValidateHouseFurniture(string houseId)
		{
			return default((bool, int));
		}

		public static List<(FurnitureType, bool, string)> GetFurnitureStatus(string houseId)
		{
			return null;
		}
	}
}
