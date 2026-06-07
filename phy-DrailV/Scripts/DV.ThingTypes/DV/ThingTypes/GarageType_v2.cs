using UnityEngine;

namespace DV.ThingTypes
{
	public class GarageType_v2 : Thing_v2_from_v1_enum<Garage>, IFreeRoamAvailability
	{
		public string localizationKey;

		public TrainCarLivery[] garageCarLiveries;

		public float summonPrice;

		[SerializeField]
		private FreeRoamAvailability freeRoamAvailability;

		public FreeRoamAvailability FreeRoamAvailability => freeRoamAvailability;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == Garage.NotSet)
			{
				AddError("v1 is default");
			}
			if (garageCarLiveries == null || garageCarLiveries.Length == 0)
			{
				AddError("garageCarLiveries is not set");
			}
			if (summonPrice < 0f)
			{
				AddError("summonPrice is negative");
			}
			if (string.IsNullOrWhiteSpace(localizationKey))
			{
				AddError("localizationKey is empty");
			}
		}
	}
}
