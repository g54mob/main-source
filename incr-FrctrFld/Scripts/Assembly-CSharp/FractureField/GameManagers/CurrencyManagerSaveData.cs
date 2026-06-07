using FractureField.Currencies;
using Newtonsoft.Json;

namespace FractureField.GameManagers
{
	public class CurrencyManagerSaveData : IConvertableSaveData
	{
		[JsonProperty("Dust")]
		public CurrencySaveData DustSaveData { get; set; }

		[JsonProperty("DroneCores")]
		public CurrencySaveData DroneCoresSaveData { get; set; }

		[JsonProperty("StoneFragments")]
		public CurrencySaveData StoneFragmentsSaveData { get; set; }

		[JsonProperty("ClayTablets")]
		public CurrencySaveData ClayTabletsSaveData { get; set; }

		[JsonProperty("SandstoneShards")]
		public CurrencySaveData SandstoneShardsSaveData { get; set; }

		[JsonProperty("QuartzCrystals")]
		public CurrencySaveData QuartzCrystalsSaveData { get; set; }

		[JsonProperty("IronOre")]
		public CurrencySaveData IronOreSaveData { get; set; }

		[JsonProperty("SilverNuggets")]
		public CurrencySaveData SilverNuggetsSaveData { get; set; }

		[JsonProperty("GoldNuggets")]
		public CurrencySaveData GoldNuggetsSaveData { get; set; }

		[JsonProperty("DiamondCrystals")]
		public CurrencySaveData DiamondCrystalsSaveData { get; set; }

		[JsonProperty("ObsidianSplinters")]
		public CurrencySaveData ObsidianSplintersSaveData { get; set; }

		[JsonProperty("StardustMotes")]
		public CurrencySaveData StardustMotesSaveData { get; set; }

		[JsonProperty("VoidSlivers")]
		public CurrencySaveData VoidSliversSaveData { get; set; }

		[JsonProperty("ChroniteShards")]
		public CurrencySaveData ChroniteShardsSaveData { get; set; }

		[JsonProperty("CoreFragments")]
		public CurrencySaveData CoreFragmentsSaveData { get; set; }

		[JsonProperty("RealityShards")]
		public CurrencySaveData RealityShardsSaveData { get; set; }

		protected CurrencyManagerSaveData Save(CurrencyManager data)
		{
			return null;
		}
	}
}
