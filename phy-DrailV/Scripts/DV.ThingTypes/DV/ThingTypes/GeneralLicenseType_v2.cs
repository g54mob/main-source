using UnityEngine;

namespace DV.ThingTypes
{
	public class GeneralLicenseType_v2 : Thing_v2_from_v1_enum<GeneralLicenseType>, IFreeRoamAvailability
	{
		public Sprite icon;

		public GameObject licensePrefab;

		public GameObject licenseInfoPrefab;

		public string localizationKey;

		public string[] localizationKeysDescription;

		public Color color;

		public float price;

		public float insuranceFeeQuotaIncrease;

		public float bonusTimeDecreasePercentage;

		public GeneralLicenseType_v2 requiredGeneralLicense;

		public JobLicenseType_v2 requiredJobLicense;

		[SerializeField]
		private FreeRoamAvailability freeRoamAvailability;

		public FreeRoamAvailability FreeRoamAvailability => freeRoamAvailability;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == GeneralLicenseType.NotSet)
			{
				AddError("v1 is default");
			}
			if (icon == null)
			{
				AddError("icon is null");
			}
			if (licensePrefab == null)
			{
				AddError("licensePrefab is null");
			}
			if (licenseInfoPrefab == null)
			{
				AddError("licenseInfoPrefab is null");
			}
			if (string.IsNullOrWhiteSpace(localizationKey))
			{
				AddError("localizationKey is empty");
			}
			if (localizationKeysDescription == null || localizationKeysDescription.Length == 0)
			{
				AddError("localizationKeysDescription is null or empty");
			}
			if (price < 0f)
			{
				AddError("price is negative");
			}
			if (insuranceFeeQuotaIncrease < 0f)
			{
				AddError("insuranceFeeQuotaIncrease is negative");
			}
			if (bonusTimeDecreasePercentage < -1f || bonusTimeDecreasePercentage > 1f)
			{
				AddError("bonusTimeDecreasePercentage out of range");
			}
		}
	}
}
