using System;
using FractureField.Shared.Enums;
using Reactivity;

namespace FractureField.Upgrades
{
	[Serializable]
	public class Upgrade
	{
		private CBool _canPurchase;

		public UpgradeDefinition Definition { get; private set; }

		public string Id => null;

		public CurrencyType CostCurrency => default(CurrencyType);

		public RInt Level { get; private set; }

		public RBool ForemanEnabled { get; private set; }

		public bool IsUpgraded => false;

		public bool IsMaxLevel => false;

		public bool CanAfford => false;

		public bool IsDisabledDroneHubUpgrade => false;

		public bool IsLockedInDemo => false;

		public bool IsHidden => false;

		public bool IsPurchaseDisabled => false;

		public CBool CanPurchase => null;

		public static RTrigger OnPurchased { get; }

		public Upgrade(UpgradeDefinition definition)
		{
		}

		public void Init()
		{
		}

		public void LoadState(UpgradeState state)
		{
		}

		private void OnGameInitialized()
		{
		}

		public UpgradeState GetState()
		{
			return null;
		}

		public int GetMaxLevel()
		{
			return 0;
		}

		private float GetCostReduction()
		{
			return 0f;
		}

		public float GetCost()
		{
			return 0f;
		}

		public float GetCostForLevel_Default(int level)
		{
			return 0f;
		}

		public float GetEffect(int level)
		{
			return 0f;
		}

		public float GetEffect()
		{
			return 0f;
		}

		public string GetFormattedEffect(int level)
		{
			return null;
		}

		public string GetFormattedEffect()
		{
			return null;
		}

		public string GetFormattedNextIncrease()
		{
			return null;
		}

		public int TryPurchaseMax()
		{
			return 0;
		}

		public bool TryPurchase(bool isManual = true, bool forceForFree = false)
		{
			return false;
		}

		private int GetLevelToRetain()
		{
			return 0;
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
