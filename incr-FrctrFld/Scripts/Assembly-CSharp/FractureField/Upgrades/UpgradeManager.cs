using System.Collections.Generic;
using FractureField.Shared.Enums;
using Reactivity;

namespace FractureField.Upgrades
{
	public class UpgradeManager
	{
		private CBool _anyDustCanUpgrade;

		private CBool _anyCanUpgrade;

		public Dictionary<string, Upgrade> Upgrades { get; }

		public CBool AnyDustCanUpgrade => null;

		public CBool AnyCanUpgrade => null;

		public void Init(params string[] upgradeIds)
		{
		}

		public void Init(Dictionary<string, string> upgradeMapping)
		{
		}

		private void InitUpgrade(string id, string shortId = null)
		{
		}

		public Upgrade Get(string key)
		{
			return null;
		}

		public float GetEffect(string key, float defaultValue = 0f)
		{
			return 0f;
		}

		public bool Purchase(string key)
		{
			return false;
		}

		public bool TryAutomaticallyPurchaseCheapest(CurrencyType currencyType = CurrencyType.None)
		{
			return false;
		}

		public List<UpgradeState> GetStates()
		{
			return null;
		}

		public void LoadStates(List<UpgradeState> states)
		{
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
