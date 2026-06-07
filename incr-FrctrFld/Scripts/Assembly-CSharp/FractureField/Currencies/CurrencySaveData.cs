using FractureField.Prestige;
using FractureField.Shared.Enums;
using Newtonsoft.Json;
using Reactivity;

namespace FractureField.Currencies
{
	public class CurrencySaveData : IConvertableSaveData
	{
		public CurrencyType Type { get; set; }

		public PrestigeLayerType PrestigeLayerType { get; set; }

		public RFloat Available { get; set; }

		[JsonProperty]
		protected RDictionary<PrestigeLayerType, RFloat> AmountForPrestigeLayer { get; set; }

		public RFloat AllTime { get; set; }

		public RFloat Highest { get; set; }

		public CurrencySaveData()
		{
		}

		public CurrencySaveData(CurrencyType type, PrestigeLayerType prestigeLayerType = PrestigeLayerType.None)
		{
		}

		protected CurrencySaveData Save(Currency data)
		{
			return null;
		}
	}
}
