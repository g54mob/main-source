using FractureField.Shared.Enums;

namespace FractureField.Rocks
{
	public static class RockLayerTypeExtensions
	{
		public static RockLayerType GetPreviousLayer(this RockLayerType currentLayer)
		{
			return default(RockLayerType);
		}

		public static RockLayerType GetNextLayer(this RockLayerType currentLayer)
		{
			return default(RockLayerType);
		}

		public static CurrencyType GetCurrencyType(this RockLayerType layerType)
		{
			return default(CurrencyType);
		}
	}
}
