using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Model;
using NSMedieval.UI.Utils;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	[Serializable]
	public class RoomType : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private bool locked;

		[SerializeField]
		private int priority;

		[SerializeField]
		private List<RoomTypeMustHave> mustHave;

		[SerializeField]
		private List<string> cantHave;

		[SerializeField]
		private bool cantHaveOtherProductionBuildings;

		[SerializeField]
		private List<string> textKeyCantHaveBuildings;

		[SerializeField]
		private RoomProductionSpeedMultiplier productionSpeedMultiplier;

		[SerializeField]
		private string color;

		[SerializeField]
		private int minimumArea = -1;

		[SerializeField]
		private bool isReligious;

		[SerializeField]
		private bool isGreatHall;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private LocKeys[] locKeysIndividualRoom;

		[SerializeField]
		private RoomEffectors[] sleepEffectors;

		[SerializeField]
		private RoomEffectors[] eatEffectors;

		[SerializeField]
		private string[] residenceEffectors;

		[SerializeField]
		private bool canBeIndividual;

		[SerializeField]
		private bool medical;

		[SerializeField]
		private bool prison;

		[SerializeField]
		private string unlockAchievementOnBuilt;

		[NonSerialized]
		private Dictionary<string, RoomEffectors> sleepEffectorsCache;

		[NonSerialized]
		private Dictionary<string, RoomEffectors> eatEffectorsCache;

		[NonSerialized]
		private bool colorCacheInit;

		[NonSerialized]
		private Color colorCache;

		[NonSerialized]
		private string nameLocalized = string.Empty;

		[NonSerialized]
		private string nameIndividualRoomLocalized = string.Empty;

		[NonSerialized]
		private HashSet<string> forbiddenProductionBuildingsCache;

		public int MinimumArea => minimumArea;

		public List<RoomTypeMustHave> MustHave => mustHave;

		public List<string> CantHave => cantHave;

		public string[] ResidenceEffectors => residenceEffectors;

		public bool IsReligious => isReligious;

		public bool CantHaveOtherProductionBuildings => cantHaveOtherProductionBuildings;

		public List<string> TextKeyCantHaveBuildings => textKeyCantHaveBuildings;

		public bool CanBeIndividual => canBeIndividual;

		public bool Medical => medical;

		public bool Prison => prison;

		public bool Locked => locked;

		public int Priority => priority;

		public string UnlockAchievementOnBuilt => unlockAchievementOnBuilt;

		public string NameLocalized
		{
			get
			{
				if (nameLocalized.Equals(string.Empty))
				{
					nameLocalized = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(locKeys));
				}
				return nameLocalized;
			}
		}

		public string NameIndividualRoomLocalized
		{
			get
			{
				if (nameIndividualRoomLocalized.Equals(string.Empty))
				{
					nameIndividualRoomLocalized = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(locKeysIndividualRoom));
				}
				return nameIndividualRoomLocalized;
			}
		}

		public Color Color
		{
			get
			{
				if (!colorCacheInit)
				{
					ColorUtility.TryParseHtmlString(color, out colorCache);
					colorCacheInit = true;
				}
				return colorCache;
			}
		}

		private HashSet<string> ForbiddenProductionBuildings
		{
			get
			{
				if (forbiddenProductionBuildingsCache == null)
				{
					forbiddenProductionBuildingsCache = new HashSet<string>();
				}
				if (forbiddenProductionBuildingsCache.Count == 0 && cantHaveOtherProductionBuildings)
				{
					HashSet<string> hashSet = new HashSet<string>();
					foreach (RoomTypeMustHave item in mustHave.Where((RoomTypeMustHave mh) => mh.MinCount > 0))
					{
						hashSet.UnionWith(item.Content);
					}
					foreach (BaseBuildingBlueprint item2 in Repository<BaseBuildingRepository, BaseBuildingBlueprint>.Instance.GetByBuildingType(BuildingType.ProductionBuilding))
					{
						if (!hashSet.Contains(item2.GetID()))
						{
							forbiddenProductionBuildingsCache.Add(item2.GetID());
						}
					}
				}
				return forbiddenProductionBuildingsCache;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public bool IsGreatHall => isGreatHall;

		public override string GetID()
		{
			return id;
		}

		public bool HasForbiddenBuilding(Room room)
		{
			foreach (string item in cantHave)
			{
				if (room.GetBuildingContentCount(item) > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasForbiddenProductionBuilding(Room room)
		{
			foreach (string forbiddenProductionBuilding in ForbiddenProductionBuildings)
			{
				if (room.GetBuildingContentCount(forbiddenProductionBuilding) > 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasAllMustHaveContent(Room room)
		{
			foreach (RoomTypeMustHave item in mustHave)
			{
				int num = 0;
				foreach (string item2 in item.Content)
				{
					int num2 = room.GetBuildingContentCount(item2) + room.GetResourceCount(item2);
					if (num2 > 0)
					{
						num += num2;
					}
				}
				if (num < item.MinCount || (item.MaxCount != -1 && num > item.MaxCount))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsAreaOk(Room room)
		{
			if (minimumArea > 0)
			{
				return room.AllNodes.Count >= minimumArea;
			}
			return true;
		}

		public bool Unlock()
		{
			if (!locked)
			{
				return false;
			}
			bool num = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.UnlockedRoomTypes.Add(GetID());
			if (num)
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeUnlocked(this);
			}
			return num;
		}

		public static bool IsRoomTypeUnlocked(RoomType roomType)
		{
			if (!roomType.locked)
			{
				return true;
			}
			return MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.UnlockedRoomTypes.Contains(roomType.GetID());
		}

		public bool CheckRoom(Room room)
		{
			if (!IsRoomTypeUnlocked(this))
			{
				return false;
			}
			if (!IsAreaOk(room))
			{
				return false;
			}
			if (HasForbiddenBuilding(room))
			{
				return false;
			}
			if (!HasAllMustHaveContent(room))
			{
				return false;
			}
			if (HasForbiddenProductionBuilding(room))
			{
				return false;
			}
			return true;
		}

		public float GetProductionSpeedMultiplier(string productionBuildingId)
		{
			if (productionSpeedMultiplier == null)
			{
				return 1f;
			}
			return productionSpeedMultiplier.GetSpeedMultiplier(productionBuildingId);
		}

		public List<string> GetSleepEffectors(RoomImpressivenessSettings.Setting impressiveness)
		{
			if (sleepEffectors == null)
			{
				return null;
			}
			RoomEffectors.CheckCreateCache(ref sleepEffectors, ref sleepEffectorsCache);
			if (!sleepEffectorsCache.TryGetValue(impressiveness.Name, out var value))
			{
				return null;
			}
			return value.Effectors;
		}

		public List<string> GetEatEffectors(RoomImpressivenessSettings.Setting impressiveness)
		{
			if (eatEffectors == null)
			{
				return null;
			}
			RoomEffectors.CheckCreateCache(ref eatEffectors, ref eatEffectorsCache);
			if (!eatEffectorsCache.TryGetValue(impressiveness.Name, out var value))
			{
				return null;
			}
			return value.Effectors;
		}
	}
}
