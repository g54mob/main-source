using System.Collections.Generic;
using FractureField.Rocks;
using FractureField.Upgrades;
using Reactivity;
using UnityEngine;

namespace FractureField.Bombs
{
	public class BombManager : BombManagerSaveData, ISaveData<BombManager, BombManagerSaveData>
	{
		public const RockLayerType MinLayerType = RockLayerType.Clay;

		public const int BaseMaxCharges = 1;

		public CInt MaxCharges;

		public const float BaseCooldown = 30f;

		public CFloat Cooldown;

		public const float BaseRadius = 1f;

		public CFloat Radius;

		public const float BaseDamageMultiplier = 5f;

		public CFloat DamageMultiplier;

		public CFloat TimeUntilNextCharge;

		public UpgradeManager UpgradeManager { get; private set; }

		public Ref<Vector3> OnBombUsed { get; }

		public BombManager Load()
		{
			return null;
		}

		public BombManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		private void InitializeUpgradeManager()
		{
		}

		public void FixedTick()
		{
		}

		private void HandlePendingChargeTimers()
		{
		}

		public bool CanUseBomb()
		{
			return false;
		}

		public bool TryPlaceBomb(Vector2 worldPosition)
		{
			return false;
		}

		public bool IsPositionInQuarry(Vector2 position)
		{
			return false;
		}

		public List<Rock> GetRocksInBlastRadius(Vector2 worldPosition)
		{
			return null;
		}

		public bool WouldHitTargets(Vector2 worldPosition)
		{
			return false;
		}

		public bool UseBomb(Vector2 worldPosition)
		{
			return false;
		}

		public Upgrade GetUpgrade(string upgradeId)
		{
			return null;
		}

		public bool PurchaseUpgrade(string upgradeId)
		{
			return false;
		}

		public List<UpgradeState> GetAllUpgradeStates()
		{
			return null;
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
