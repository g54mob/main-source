using UnityEngine;

namespace TH20
{
	public class HospitalAttractivenessDataView : HospitalDataView
	{
		public HospitalAttractivenessDataView(DataViewManager.Config config, HospitalMapAttributesVisualisation mapAttributesVisualisation, WorldState worldState, BuildEvents buildEvents)
			: base(config, mapAttributesVisualisation, worldState, buildEvents)
		{
		}

		protected override Color PositiveColor()
		{
			return _config.AttractiveItemColor;
		}

		protected override Color NegativeColor()
		{
			return _config.UglyItemColor;
		}

		protected override HospitalAttributeMap.Attribute AttributeToShow()
		{
			return HospitalAttributeMap.Attribute.Attractiveness;
		}
	}
}
