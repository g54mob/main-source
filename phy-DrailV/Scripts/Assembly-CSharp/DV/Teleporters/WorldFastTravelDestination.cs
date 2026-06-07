using DV.Localization;

namespace DV.Teleporters
{
	public class WorldFastTravelDestination : FastTravelDestination
	{
		public string markerName;

		public string localizationKey;

		public override string MarkerName
		{
			get
			{
				if (!string.IsNullOrEmpty(localizationKey))
				{
					return LocalizationAPI.L(localizationKey);
				}
				return markerName;
			}
		}

		public override bool IsDynamic => false;
	}
}
