using System;
using System.Collections.Generic;
using Brewery.Core;
using UnityEngine;

namespace Port
{
	[CreateAssetMenu(fileName = "PortConfig", menuName = "Port/Port Config")]
	public class PortConfig : ScriptableObject
	{
		[Header("Reputation Tiers")]
		[Tooltip("Reputation thresholds for each tier (index 0 = Tier 1 threshold, always 0)")]
		[SerializeField]
		private int[] tierThresholds;

		[Tooltip("Max active docks per tier (index 0 = Tier 1)")]
		[SerializeField]
		private int[] docksPerTier;

		[Tooltip("Min contracts per ship per tier")]
		[SerializeField]
		private int[] minContractsPerShip;

		[Tooltip("Max contracts per ship per tier")]
		[SerializeField]
		private int[] maxContractsPerShip;

		[Header("Ship Scheduling")]
		[Tooltip("Probability (0-1) that an empty dock gets a ship each morning")]
		[SerializeField]
		private float shipSpawnChance;

		[Tooltip("NormalizedTime for earliest ship arrival (e.g., 0.29 = ~7am)")]
		[SerializeField]
		private float arrivalHourMin;

		[Tooltip("NormalizedTime for latest ship arrival")]
		[SerializeField]
		private float arrivalHourMax;

		[Tooltip("NormalizedTime for ship departure (e.g., 0.75 = ~6pm)")]
		[SerializeField]
		private float departureHour;

		[Header("Ship Names")]
		[SerializeField]
		private string[] shipNamePrefixes;

		[SerializeField]
		private string[] shipNameSuffixes;

		[Header("Contract Rewards")]
		[Tooltip("Base material reward range per tier [min, max] — for catalyst-only contracts")]
		[SerializeField]
		private Vector2Int[] catalystRewardRange;

		[Tooltip("Base material reward range per tier [min, max] — for drink-only contracts")]
		[SerializeField]
		private Vector2Int[] drinkRewardRange;

		[Tooltip("Bonus materials for mixed contracts (drink + catalyst)")]
		[SerializeField]
		private int mixedContractBonus;

		[Tooltip("Bonus materials per required tag on drinks")]
		[SerializeField]
		private int bonusPerTag;

		[Tooltip("Bonus materials per illegal tag")]
		[SerializeField]
		private int bonusPerIllegalTag;

		[Tooltip("Bonus materials for legendary drink contracts")]
		[SerializeField]
		private int legendaryBonus;

		[Header("Contract Quantities")]
		[Tooltip("Drink quantity options per tier")]
		[SerializeField]
		private int[] drinkQuantitiesTier1;

		[SerializeField]
		private int[] drinkQuantitiesTier2;

		[SerializeField]
		private int[] drinkQuantitiesTier3;

		[SerializeField]
		private int[] drinkQuantitiesTier4;

		[SerializeField]
		private int[] drinkQuantitiesTier5;

		[Tooltip("Catalyst quantity range per tier [min, max]")]
		[SerializeField]
		private Vector2Int[] catalystQuantityRange;

		[Header("Ship Stay Duration")]
		[Tooltip("Ship stay duration in days per tier [min, max]")]
		[SerializeField]
		private Vector2Int[] stayDurationRange;

		[Header("Catalyst Pools")]
		[Tooltip("Catalyst IDs available from Tier 1 (Common)")]
		[SerializeField]
		private string[] commonCatalysts;

		[Tooltip("Catalyst IDs added at Tier 2 (Uncommon)")]
		[SerializeField]
		private string[] uncommonCatalysts;

		[Tooltip("Catalyst IDs added at Tier 3 (Rare)")]
		[SerializeField]
		private string[] rareCatalysts;

		[Tooltip("Catalyst IDs added at Tier 4 (Illegal)")]
		[SerializeField]
		private string[] illegalCatalysts;

		[Header("Player Limits")]
		[Tooltip("Max active contracts per player")]
		[SerializeField]
		private int maxActiveContractsPerPlayer;

		public int MaxActiveContractsPerPlayer => 0;

		public float ShipSpawnChance => 0f;

		public float ArrivalHourMin => 0f;

		public float ArrivalHourMax => 0f;

		public float DepartureHour => 0f;

		public int MixedContractBonus => 0;

		public int BonusPerTag => 0;

		public int BonusPerIllegalTag => 0;

		public int LegendaryBonus => 0;

		public int MaxTier => 0;

		public int GetTier(int reputation)
		{
			return 0;
		}

		public int GetTierThreshold(int tier)
		{
			return 0;
		}

		public int GetNextTierThreshold(int currentTier)
		{
			return 0;
		}

		public int GetActiveDocks(int tier)
		{
			return 0;
		}

		public (int, int) GetContractsPerShip(int tier)
		{
			return default((int, int));
		}

		public Vector2Int GetCatalystRewardRange(int tier)
		{
			return default(Vector2Int);
		}

		public Vector2Int GetDrinkRewardRange(int tier)
		{
			return default(Vector2Int);
		}

		public int[] GetDrinkQuantities(int tier)
		{
			return null;
		}

		public Vector2Int GetCatalystQuantityRange(int tier)
		{
			return default(Vector2Int);
		}

		public Vector2Int GetStayDurationRange(int tier)
		{
			return default(Vector2Int);
		}

		public List<string> GetCatalystPool(int tier)
		{
			return null;
		}

		public string GenerateShipName(System.Random rng)
		{
			return null;
		}

		public List<BrewTag> GetDrinkTagPool(int tier)
		{
			return null;
		}

		public static bool AreTagsCompatible(BrewTag tags)
		{
			return false;
		}
	}
}
