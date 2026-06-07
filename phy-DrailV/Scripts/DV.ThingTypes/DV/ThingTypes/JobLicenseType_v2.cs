using System;
using System.Collections.Generic;
using DV.ThingTypes.TransitionHelpers;
using UnityEngine;

namespace DV.ThingTypes
{
	[CreateAssetMenu(menuName = "DV/Object Model/Job License")]
	public class JobLicenseType_v2 : Thing_v2_from_v1_enum<JobLicenses>, IFreeRoamAvailability
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
		private FreeRoamAvailability freeRoamAvailability = FreeRoamAvailability.ALWAYS;

		private static readonly JobLicenses[] JobLicenseValues = (JobLicenses[])Enum.GetValues(typeof(JobLicenses));

		public FreeRoamAvailability FreeRoamAvailability => freeRoamAvailability;

		protected override void PopulateErrors(ErrorPopulator AddError)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				AddError("id is empty");
			}
			if (v1 == JobLicenses.Basic && id != "Basic")
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

		public static List<JobLicenseType_v2> ToV2List(JobLicenses flags)
		{
			List<JobLicenseType_v2> list = new List<JobLicenseType_v2>();
			JobLicenses[] jobLicenseValues = JobLicenseValues;
			foreach (JobLicenses jobLicenses in jobLicenseValues)
			{
				if ((flags & jobLicenses) != JobLicenses.Basic)
				{
					list.Add(jobLicenses.ToV2());
				}
			}
			return list;
		}

		public static JobLicenses ListToFlags(IEnumerable<JobLicenseType_v2> list)
		{
			JobLicenses jobLicenses = JobLicenses.Basic;
			foreach (JobLicenseType_v2 item in list)
			{
				jobLicenses |= item.v1;
			}
			return jobLicenses;
		}
	}
}
