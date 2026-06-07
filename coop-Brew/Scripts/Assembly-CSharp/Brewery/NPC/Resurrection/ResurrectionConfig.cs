using InventorySystem;
using UnityEngine;

namespace Brewery.NPC.Resurrection
{
	[CreateAssetMenu(fileName = "ResurrectionConfig", menuName = "Brewery/NPC/Resurrection Config")]
	public class ResurrectionConfig : ScriptableObject
	{
		[Header("Scaling Cost")]
		[Tooltip("Base money cost for the 1st resurrection.")]
		[SerializeField]
		private float baseMoneyCost;

		[Tooltip("Money cost increase per resurrection tier.")]
		[SerializeField]
		private float moneyIncrement;

		[Tooltip("Base wine cost for the 1st resurrection.")]
		[SerializeField]
		private int baseWineCost;

		[Tooltip("Wine cost increase per resurrection tier.")]
		[SerializeField]
		private int wineIncrement;

		[Tooltip("Maximum resurrection tier (costs stop scaling after this).")]
		[SerializeField]
		private int maxTier;

		[Tooltip("The wine item required for resurrection (PlainWine).")]
		[SerializeField]
		private Item wineItem;

		[Header("Death Chance")]
		[Tooltip("Chance (0-1) that an NPC actually dies when health reaches 0. Otherwise they get knocked out. Default 0.25 = 25% chance of permanent death.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float permanentDeathChance;

		[Header("Timing")]
		[Tooltip("Duration of body fade-out after death (seconds).")]
		[SerializeField]
		private float deathFadeOutDuration;

		[Tooltip("Duration the priest spends at each grave during ceremony (seconds).")]
		[SerializeField]
		private float ceremonyDurationPerGrave;

		[Tooltip("Timeout for priest pathfinding to a single grave (seconds). Skips grave if exceeded.")]
		[SerializeField]
		private float priestPathfindingTimeout;

		[Header("Grave Animation")]
		[Tooltip("Duration of grave LeanTween pop-in animation (seconds).")]
		[SerializeField]
		private float gravePopInDuration;

		[Tooltip("Duration of grave LeanTween pop-out animation after resurrection (seconds).")]
		[SerializeField]
		private float gravePopOutDuration;

		public float PermanentDeathChance => 0f;

		public float BaseMoneyCost => 0f;

		public float MoneyIncrement => 0f;

		public int BaseWineCost => 0;

		public int WineIncrement => 0;

		public int MaxTier => 0;

		public Item WineItem => null;

		public float DeathFadeOutDuration => 0f;

		public float CeremonyDurationPerGrave => 0f;

		public float PriestPathfindingTimeout => 0f;

		public float GravePopInDuration => 0f;

		public float GravePopOutDuration => 0f;

		public float GetMoneyCostForTier(int tier)
		{
			return 0f;
		}

		public int GetWineCostForTier(int tier)
		{
			return 0;
		}

		public float GetTotalMoneyCost(int startTier, int count)
		{
			return 0f;
		}

		public int GetTotalWineCost(int startTier, int count)
		{
			return 0;
		}

		private void OnValidate()
		{
		}
	}
}
