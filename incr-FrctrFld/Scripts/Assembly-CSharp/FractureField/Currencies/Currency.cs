using FractureField.Prestige;
using FractureField.Shared.Enums;
using Reactivity;

namespace FractureField.Currencies
{
	public class Currency : CurrencySaveData, ISaveData<Currency, CurrencySaveData>
	{
		public RFloat WorldFracture => null;

		public RFloat RealityShatter => null;

		public RFloat OnCurrencyAdded { get; }

		public RFloat OnCurrencySpent { get; }

		public Currency Load()
		{
			return null;
		}

		public CurrencySaveData Save()
		{
			return null;
		}

		public Currency()
		{
		}

		public Currency(CurrencyType type, PrestigeLayerType prestigeLayerType = PrestigeLayerType.None)
		{
		}

		public void Init()
		{
		}

		public RFloat GetAmountForPrestigeLayer(PrestigeLayerType prestigeLayerType)
		{
			return null;
		}

		public void Add(float amount, string sourceType, string sourceId)
		{
		}

		public bool TrySpend(float amount, string reasonType, string reasonId)
		{
			return false;
		}

		public void DoPrestigeLayerReset()
		{
		}
	}
}
