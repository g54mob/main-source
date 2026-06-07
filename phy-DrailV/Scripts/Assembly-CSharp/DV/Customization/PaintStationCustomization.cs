namespace DV.Customization
{
	public class PaintStationCustomization : StaticParentCustomization<PaintStationCustomization>
	{
		public const string KEY = ":paint_station:";

		public override string GetIdentificationKey()
		{
			return ":paint_station:";
		}

		private void OnEnable()
		{
			Enable();
		}

		private void OnDisable()
		{
			Disable();
		}
	}
}
