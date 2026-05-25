using System;
using System.Collections.Generic;

namespace V1
{
	[Serializable]
	public class MainData
	{
		public string Version = GetVersion();

		public List<BuildingData> Buildings = new List<BuildingData>();

		public List<CharacterData> Characters = new List<CharacterData>();

		public List<AchivementData> Achievements = new List<AchivementData>();

		public List<int> Garbage_X = new List<int>();

		public List<int> Garbage_GarbageType = new List<int>();

		public List<int> Garbage_CameFrom = new List<int>();

		public List<int> Garbage_Weight = new List<int>();

		public List<int> Garbage_IsEvil = new List<int>();

		public List<int> Garbage_IsZap = new List<int>();

		public DateTime TimeCreated;

		public float TimePlayed;

		public int CanViewOnTop;

		public int SeeAllNodes;

		public int TotalGarbageCreated;

		public int TotalTossedGarbage;

		public int TotalCloudClick;

		public int TotalCloudClickDestroyed;

		public int TotalCloudDestroyed;

		public int TotalPeonTrashThrow;

		public int TotalPeonThrow;

		public int TotalBlockedOutput;

		public int Money;

		public int Book;

		public int ResearchPoint;

		public int HoleFilled;

		public int PrestigeCount;

		public int YellowPoint;

		public int RedPoint;

		public int BluePoint;

		public int DeadPeonCount;

		public int Golem_IsMoving;

		public int Golem_IsDestroyed;

		public int Golem_X;

		public int Golem_TrashWeight;

		public int Golem_TrashSize;

		public int TotalMoney;

		public int TotalBook;

		public int TotalResearchPoint;

		public int TotalYellowPoint;

		public int TotalRedPoint;

		public int TotalBluePoint;

		public List<int> AbilityDelay = new List<int>();

		public List<SaveKeyValueItem> MainUpgrades = new List<SaveKeyValueItem>();

		public int Special;

		public int IsRelax;

		public static string GetVersion()
		{
			if (Installation.IsDemo())
			{
				return "VERSION1.3demo";
			}
			return "VERSION1.3full";
		}
	}
}
