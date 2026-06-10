using System;
using System.Collections.Generic;
using System.Linq;
using GlobalStats;
using Models;
using NSEipix;
using NSEipix.Model;
using NSMedieval.GameEventSystem;
using NSMedieval.StatsSystem;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class NPC : HumanoidBlueprint, IEnemyPurchaseUnit
	{
		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private List<string> bannedEquipment;

		[SerializeField]
		private List<SkillType> bannedSkills;

		[SerializeField]
		private string equipmentID;

		[SerializeField]
		private IntRange age;

		[SerializeField]
		private FloatRange height;

		[SerializeField]
		private FloatRange weightCoefficient;

		[SerializeField]
		private int price = 40;

		[SerializeField]
		private float priceThreshold = 1f;

		[SerializeField]
		private string category = string.Empty;

		[SerializeField]
		private string type = "none";

		[SerializeField]
		private string[] allowedFactionTypes;

		[SerializeField]
		private List<TimedWounds> fireWounds;

		[SerializeField]
		private float flameSpawnInterval;

		[SerializeField]
		private float setProductionBuildingOnFireChance = 0.1f;

		[SerializeField]
		private GlobalStatModifier[] addToGlobalStatOnKilledByPlayer;

		[SerializeField]
		private string visitorIdleInRoom;

		[SerializeField]
		private string visitorIdleAroundRelic;

		[NonSerialized]
		private NPCType cachedNpcType;

		public IntRange Age => age;

		public FloatRange Height => height;

		public FloatRange WeightCoefficient => weightCoefficient;

		public List<string> BannedEquipment => bannedEquipment;

		public List<SkillType> BannedSkills => bannedSkills;

		public string EquipmentID => equipmentID;

		public int Price => price;

		public float PriceThreshold
		{
			get
			{
				if (priceThreshold < 0f)
				{
					priceThreshold = Mathf.Clamp01(priceThreshold);
				}
				return priceThreshold;
			}
		}

		public string Category => category;

		public NPCType Type
		{
			get
			{
				if (cachedNpcType == NPCType.None)
				{
					cachedNpcType = Enum.Parse<NPCType>(type.CapitalizeFirst());
				}
				return cachedNpcType;
			}
		}

		public LocKeys[] LocKeys => locKeys;

		public string[] AllowedFactionTypes => allowedFactionTypes;

		public List<TimedWounds> FireWounds => fireWounds;

		public float SetProductionBuildingOnFireChance => setProductionBuildingOnFireChance;

		public GlobalStatModifier[] AddToGlobalStatOnKilledByPlayer => addToGlobalStatOnKilledByPlayer;

		public string VisitorIdleInRoom => visitorIdleInRoom;

		public string VisitorIdleAroundRelic => visitorIdleAroundRelic;

		public int GetPrice()
		{
			return Price;
		}

		public float GetPriceThreshold()
		{
			return PriceThreshold;
		}

		public bool IsTrader()
		{
			return Type == NPCType.Trader;
		}

		public bool TryGetRandomValidOriginVillage(out VillagePlace villagePlace, HashSet<FactionFriendliness> friendliness = null)
		{
			IEnumerable<VillagePlace> source = GlobalSaveController.CurrentVillageData.WorldMapData.VillagePlaces.Where(delegate(VillagePlace village)
			{
				if (friendliness != null && !friendliness.Contains(village.FactionInstance.GetFriendliness()))
				{
					return false;
				}
				return (allowedFactionTypes == null || allowedFactionTypes.Contains(village.FactionInstance.Blueprint.FactionType.GetID())) ? true : false;
			});
			villagePlace = source.PickRandom();
			return villagePlace != null;
		}
	}
}
