using System.Collections.Generic;
using FractureField.Currencies;
using FractureField.Shared.Enums;

namespace FractureField.GameManagers
{
	public class CurrencyManager : CurrencyManagerSaveData, ISaveData<CurrencyManager, CurrencyManagerSaveData>
	{
		private readonly Dictionary<CurrencyType, Currency> _currencies;

		private List<Currency> _rockLayerCurrencies;

		private List<Currency> _prestigeCurrencies;

		private List<Currency> _allCurrencies;

		public Currency Dust { get; set; }

		public Currency DroneCores { get; set; }

		public Currency StoneFragments { get; set; }

		public Currency ClayTablets { get; set; }

		public Currency SandstoneShards { get; set; }

		public Currency QuartzCrystals { get; set; }

		public Currency IronOre { get; set; }

		public Currency SilverNuggets { get; set; }

		public Currency GoldNuggets { get; set; }

		public Currency DiamondCrystals { get; set; }

		public Currency ObsidianSplinters { get; set; }

		public Currency StardustMotes { get; set; }

		public Currency VoidSlivers { get; set; }

		public Currency ChroniteShards { get; set; }

		public Currency CoreFragments { get; set; }

		public Currency RealityShards { get; set; }

		public List<Currency> RockLayerCurrencies => null;

		public List<Currency> PrestigeCurrencies => null;

		public List<Currency> AllCurrencies => null;

		public CurrencyManager Load()
		{
			return null;
		}

		public CurrencyManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		public Currency GetCurrency(CurrencyType type)
		{
			return null;
		}

		public void Add(CurrencyType type, float amount, string sourceType, string sourceId)
		{
		}

		public bool TrySpend(CurrencyType type, float amount, string reasonType, string reasonId)
		{
			return false;
		}

		public float GetAvailable(CurrencyType type)
		{
			return 0f;
		}
	}
}
