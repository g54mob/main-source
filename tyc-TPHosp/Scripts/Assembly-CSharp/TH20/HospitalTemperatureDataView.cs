using UnityEngine;

namespace TH20
{
	public class HospitalTemperatureDataView : HospitalDataView
	{
		public HospitalTemperatureDataView(DataViewManager.Config config, HospitalMapAttributesVisualisation mapAttributesVisualisation, WorldState worldState, BuildEvents buildEvents)
			: base(config, mapAttributesVisualisation, worldState, buildEvents)
		{
		}

		protected override Color PositiveColor()
		{
			return _config.HotItemColor;
		}

		protected override Color NegativeColor()
		{
			return _config.ColdItemColor;
		}

		protected override HospitalAttributeMap.Attribute AttributeToShow()
		{
			return HospitalAttributeMap.Attribute.Temperature;
		}
	}
}
