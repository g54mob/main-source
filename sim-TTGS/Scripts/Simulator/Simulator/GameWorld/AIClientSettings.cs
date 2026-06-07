using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("AI/Clients", Scope.Project)]
	public class AIClientSettings : CustomSettings<AIClientSettings>
	{
		[Serializable]
		private struct BuyProbabilityFormula
		{
			[SerializeField]
			private float m_a;

			[SerializeField]
			private float m_b;

			[SerializeField]
			private float m_c;

			[SerializeField]
			private float m_d;

			public float GetBuyProbability(float marketPricePercentage)
			{
				float num = marketPricePercentage * 100f;
				return m_a * Mathf.Exp(num * (m_b - num) / (1000f * m_c)) + m_d;
			}
		}

		[Serializable]
		private struct BuyIterationFormula
		{
			[SerializeField]
			[Min(0f)]
			private int m_lowStandNumberIterations;

			[Tooltip("If stand number is lower or equal, we use LOW stand number iterations\nIf stand number is higher, we use HIGH stand number iterations")]
			[SerializeField]
			[Range(1f, 10f)]
			private int m_standNumberLimit;

			[SerializeField]
			[Min(0f)]
			private int m_highStandNumberIterations;

			public int GetIterationNumber(int standNumber)
			{
				if (standNumber <= m_standNumberLimit)
				{
					return m_lowStandNumberIterations;
				}
				return m_highStandNumberIterations;
			}
		}

		[Header("Spawn Rate")]
		[SerializeField]
		[Min(0f)]
		private int m_startSpawnScore;

		[SerializeField]
		[Min(0f)]
		private int m_spawnScoreGoal = 1000;

		[SerializeField]
		private AnimationCurve m_spawnIncrementMax;

		[SerializeField]
		private AnimationCurve m_spawnIncrementMin;

		[SerializeField]
		[Min(0f)]
		private float m_spawnScoreDayMultiplier = 5f;

		[SerializeField]
		[Min(0f)]
		private float m_spawnScoreAttractionMultiplier = 0.001f;

		[Header("Prefabs")]
		[SerializeField]
		private List<GameObject> m_clientCharacterPrefabs;

		[SerializeField]
		private GameObject m_clientControllerPrefab;

		[Header("Movement")]
		[SerializeField]
		private float m_speed = 3f;

		[SerializeField]
		private float m_acceleration = 5f;

		[SerializeField]
		private float m_angularSpeed = 120f;

		[Header("Shop")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_enterShopPercentage = 0.8f;

		[SerializeField]
		[VectorRange(0f, 20f)]
		private Vector2 m_waitInFrontOfShopTime = new Vector2(5f, 10f);

		[Header("Stands")]
		[SerializeField]
		[VectorRange(0f, 20f)]
		private Vector2 m_waitBetweenBuy = new Vector2(1f, 2f);

		[SerializeField]
		[VectorRange(0f, 20f)]
		private Vector2 m_waitWithoutBuy = new Vector2(5f, 10f);

		[Header("Products")]
		[SerializeField]
		private BuyProbabilityFormula m_buyProbabilityFormula;

		[SerializeField]
		private BuyIterationFormula m_buyIterationFormula;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_probaReducingPerIteration = 0.05f;

		[Space(10f)]
		[SerializeField]
		[VectorRange(1f, 20f)]
		private Vector2Int m_maxProductToBuy = new Vector2Int(1, 10);

		[SerializeField]
		[VectorRange(10f, 100000f)]
		private Vector2 m_maxMoneyToSpend = new Vector2(100f, 800f);

		[SerializeField]
		[VectorRange(1f, 10f)]
		private Vector2Int m_maxStandToVisit = new Vector2Int(4, 6);

		[Header("Checkout")]
		[SerializeField]
		private EnumValues<EPaymentMethod, int> m_paymentMethodsWeight;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_probabilityOfGivingExactAmountOfCashForPayment;

		[SerializeField]
		private int[] m_moneyReturnable;

		[Header("Painting")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_paintingProbability = 0.3f;

		[SerializeField]
		[VectorRange(0f, 500f)]
		private Vector2 m_paintingTimeRange = new Vector2(120f, 240f);

		[Header("Wargame")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_wargameProbability = 0.3f;

		[SerializeField]
		[Range(0f, 1f)]
		private float m_wargameProbaIncrease = 0.5f;

		[SerializeField]
		[VectorRange(0f, 500f)]
		private Vector2 m_wargameTimeRange = new Vector2(120f, 240f);

		[Header("Optional Stands")]
		[SerializeField]
		[VectorRange(0f, 60f)]
		private Vector2 m_completeTasksDuration;

		public static int StartSpawnScore => CustomSettings<AIClientSettings>.I.m_startSpawnScore;

		public static int SpawnScoreGoal => CustomSettings<AIClientSettings>.I.m_spawnScoreGoal;

		public static float SpawnScoreDayMultiplier => CustomSettings<AIClientSettings>.I.m_spawnScoreDayMultiplier;

		public static float SpawnScoreAttractionMultiplier => CustomSettings<AIClientSettings>.I.m_spawnScoreAttractionMultiplier;

		public static GameObject ClientControllerPrefab => CustomSettings<AIClientSettings>.I.m_clientControllerPrefab;

		public static float Speed => CustomSettings<AIClientSettings>.I.m_speed;

		public static float Acceleration => CustomSettings<AIClientSettings>.I.m_acceleration;

		public static float AngularSpeed => CustomSettings<AIClientSettings>.I.m_angularSpeed;

		public static float EnterShopPercentage => CustomSettings<AIClientSettings>.I.m_enterShopPercentage;

		public static Vector2 WaitInFrontOfShopTime => CustomSettings<AIClientSettings>.I.m_waitInFrontOfShopTime;

		public static float WaitBetweenBuy => CustomSettings<AIClientSettings>.I.m_waitBetweenBuy.GetRandomInRange();

		public static float WaitWithoutBuy => CustomSettings<AIClientSettings>.I.m_waitWithoutBuy.GetRandomInRange();

		public static float ProbaReducingPerIteration => CustomSettings<AIClientSettings>.I.m_probaReducingPerIteration;

		public static int MaxProductToBuy => CustomSettings<AIClientSettings>.I.m_maxProductToBuy.GetRandomInRange(maxInclusive: true);

		public static float MaxMoneyToSpend => CustomSettings<AIClientSettings>.I.m_maxMoneyToSpend.GetRandomInRange();

		public static int MaxStandToVisit => CustomSettings<AIClientSettings>.I.m_maxStandToVisit.GetRandomInRange(maxInclusive: true);

		public static float ProbabilityOfGivingExactAmountOfCashForPayment => CustomSettings<AIClientSettings>.I.m_probabilityOfGivingExactAmountOfCashForPayment;

		public static ReadOnlyCollection<int> MoneyReturnable => new ReadOnlyCollection<int>(CustomSettings<AIClientSettings>.I.m_moneyReturnable);

		public static float PaintingProbability => CustomSettings<AIClientSettings>.I.m_paintingProbability;

		public static Vector2 PaintingTimeRange => CustomSettings<AIClientSettings>.I.m_paintingTimeRange;

		public static float WargameProbability => CustomSettings<AIClientSettings>.I.m_wargameProbability;

		public static float WargameProbaIncrease => CustomSettings<AIClientSettings>.I.m_wargameProbaIncrease;

		public static Vector2 WargameTimeRange => CustomSettings<AIClientSettings>.I.m_wargameTimeRange;

		public static float CompleteTasksDuration => CustomSettings<AIClientSettings>.I.m_completeTasksDuration.GetRandomInRange();

		public static float GetRandomSpawnIncrement()
		{
			float num = World.TimeController.NormalizedTime;
			if (num < 0f)
			{
				num = (TimeController.IsDay ? 0f : 1f);
			}
			return UnityEngine.Random.Range(CustomSettings<AIClientSettings>.I.m_spawnIncrementMin.Evaluate(num), CustomSettings<AIClientSettings>.I.m_spawnIncrementMax.Evaluate(num));
		}

		public static GameObject GetClientCharacterPrefab(int modelIndex)
		{
			if (modelIndex < 0)
			{
				return CustomSettings<AIClientSettings>.I.m_clientCharacterPrefabs.GetRandom();
			}
			return CustomSettings<AIClientSettings>.I.m_clientCharacterPrefabs[modelIndex];
		}

		public static float GetBuyProductProbability(float marketPricePercentage)
		{
			return CustomSettings<AIClientSettings>.I.m_buyProbabilityFormula.GetBuyProbability(marketPricePercentage);
		}

		public static int GetBuyIterations(int standNumber)
		{
			return CustomSettings<AIClientSettings>.I.m_buyIterationFormula.GetIterationNumber(standNumber);
		}

		public static IEnumerable<KeyValuePair<EPaymentMethod, int>> GetPaymentMethodsWeight()
		{
			foreach (KeyValuePair<EPaymentMethod, int> item in CustomSettings<AIClientSettings>.I.m_paymentMethodsWeight)
			{
				yield return item;
			}
		}
	}
}
