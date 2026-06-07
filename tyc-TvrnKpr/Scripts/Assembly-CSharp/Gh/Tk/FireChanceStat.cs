using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class FireChanceStat : GameObjectXStat
	{
		private const float LowFlammabilityChance = 0.04f;

		private const float MediumFlammabilityChance = 0.2f;

		private const float HighFlammabilityChance = 0.4f;

		private const float AlertFireChance = 0.5f;

		public List<GameObjectX> SparkingGoxsNearby;

		private TooltipData _breakdownTooltipData;

		[PersistenceOptIn]
		private bool _errorInfoSet;

		[JsonIgnore]
		private static float _flammabilityGameBalanceModifier;

		private float _currentDamageModifier;

		private DamageStat _damageStat;

		private float _currentFilthModifier;

		private float _currentTemperatureModifier;

		[PersistenceOptIn]
		private float _fireChanceAboveAlertThresholdTime;

		[PersistenceOptIn]
		private float _fireChanceBelowAlertThresholdTime;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		[Preserve]
		protected FireChanceStat()
		{
		}

		[Preserve]
		public FireChanceStat(GameObjectX owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}

		public override void Init()
		{
		}

		private void OnEditModeExited(object sender, EventArgs e)
		{
		}

		public override void OnRemoving()
		{
		}

		public override TooltipData GenerateTooltipData()
		{
			return null;
		}

		protected override string GetTooltipTextKey()
		{
			return null;
		}

		public void RefreshFireChance()
		{
		}

		private void UpdateDamageModifier()
		{
		}

		private void UpdateFilthModifier()
		{
		}

		private void UpdateTemperatureModifier()
		{
		}

		private static float GetFlammabilityExtremeTemperatureThreshold()
		{
			return 0f;
		}

		private static float GetFlammabilityGameBalanceModifier()
		{
			return 0f;
		}

		private static void UpdateFlammabilityGameBalanceModifier()
		{
		}

		public Flammability GetFlammabilityRating()
		{
			return default(Flammability);
		}

		private static Flammability GetFlammabilityRating(float fireChance)
		{
			return default(Flammability);
		}

		private static float GetFlammabilityChance(Flammability flammability)
		{
			return 0f;
		}

		public void TriggerFireChance(float fireChanceMultiplier, float startingTempBoost = 0f)
		{
		}

		public override void Update()
		{
		}

		public void RefreshErrorInfo(bool forceRefresh = false)
		{
		}

		private void ClearErrorInfo()
		{
		}
	}
}
