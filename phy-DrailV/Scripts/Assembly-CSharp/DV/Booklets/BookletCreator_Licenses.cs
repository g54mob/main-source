using System.Text;
using DV.Localization;
using DV.RenderTextureSystem.BookletRender;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_Licenses
	{
		public static GameObject CreateLicense(JobLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null, bool dontAddToStorage = false)
		{
			if (license.licensePrefab == null)
			{
				Debug.LogError("License " + license.id + " doesn't have licensePrefab set. Ignoring license creation request");
				return null;
			}
			return SpawnLicenseRelatedPrefab(license.licensePrefab, position, rotation, isPlayerOwned: true, parent, dontAddToStorage);
		}

		public static GameObject CreateLicense(GeneralLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null, bool dontAddToStorage = false)
		{
			if (license.licensePrefab == null)
			{
				Debug.LogError("License " + license.id + " doesn't have licensePrefab set. Ignoring license creation request");
				return null;
			}
			return SpawnLicenseRelatedPrefab(license.licensePrefab, position, rotation, isPlayerOwned: true, parent, dontAddToStorage);
		}

		public static GameObject CreateLicenseInfo(JobLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null, bool dontAddToStorage = false)
		{
			if (license.licenseInfoPrefab == null)
			{
				Debug.LogError("License " + license.id + " doesn't have licenseInfoPrefab set. Ignoring license creation request");
				return null;
			}
			return SpawnLicenseRelatedPrefab(license.licenseInfoPrefab, position, rotation, isPlayerOwned: false, parent, dontAddToStorage);
		}

		public static GameObject CreateLicenseInfo(GeneralLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null, bool dontAddToStorage = false)
		{
			if (license.licenseInfoPrefab == null)
			{
				Debug.LogError("License " + license.id + " doesn't have licenseInfoPrefab set. Ignoring license creation request");
				return null;
			}
			return SpawnLicenseRelatedPrefab(license.licenseInfoPrefab, position, rotation, isPlayerOwned: false, parent, dontAddToStorage);
		}

		private static GameObject SpawnLicenseRelatedPrefab(GameObject prefab, Vector3 position, Quaternion rotation, bool isPlayerOwned, Transform parent = null, bool dontAddToStorage = false)
		{
			GameObject gameObject = Object.Instantiate(prefab, position, rotation, parent);
			if (!dontAddToStorage)
			{
				InventoryItemSpec component = gameObject.GetComponent<InventoryItemSpec>();
				if (component != null)
				{
					if (isPlayerOwned)
					{
						component.BelongsToPlayer = true;
						SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorageAfterOneFrame(gameObject);
					}
				}
				else
				{
					Debug.LogError(string.Format("Prefab: {0} is missing {1} script! Can't set belongsToPlayer to true!", prefab, "InventoryItemSpec"));
				}
			}
			return gameObject;
		}

		public static LicenseTemplatePaperData GetJobLicenseTemplateData(JobLicenseType_v2 jobLicense)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] localizationKeysDescription = jobLicense.localizationKeysDescription;
			foreach (string translationKey in localizationKeysDescription)
			{
				stringBuilder.AppendLine(LocalizationAPI.L(translationKey));
			}
			Sprite requiredLicenseIconSprite = null;
			GeneralLicenseType_v2 requiredGeneralLicense = jobLicense.requiredGeneralLicense;
			JobLicenseType_v2 requiredJobLicense = jobLicense.requiredJobLicense;
			if (requiredGeneralLicense != null)
			{
				requiredLicenseIconSprite = requiredGeneralLicense.icon;
			}
			else if (requiredJobLicense != null)
			{
				requiredLicenseIconSprite = requiredJobLicense.icon;
			}
			float price = jobLicense.price;
			string cost = ((price != 0f) ? ("$" + price.ToString("N2", LocalizationAPI.CC)) : "N/A");
			float insuranceFeeQuotaIncrease = jobLicense.insuranceFeeQuotaIncrease;
			string insuranceParticipation = ((insuranceFeeQuotaIncrease != 0f) ? ("+$" + insuranceFeeQuotaIncrease.ToString("N2", LocalizationAPI.CC)) : "N/A");
			float num = jobLicense.bonusTimeDecreasePercentage * 100f;
			string timeBonusDecrease = ((num != 0f) ? (((num > 0f) ? "-" : "+") + Mathf.Abs(num).ToString("N2", LocalizationAPI.CC) + "%") : "N/A");
			return new LicenseTemplatePaperData(LocalizationAPI.L(jobLicense.localizationKey), stringBuilder.ToString(), jobLicense.color, cost, insuranceParticipation, timeBonusDecrease, jobLicense.icon, requiredLicenseIconSprite);
		}

		public static LicenseTemplatePaperData GetGeneralLicenseTemplateData(GeneralLicenseType_v2 generalLicense)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] localizationKeysDescription = generalLicense.localizationKeysDescription;
			foreach (string translationKey in localizationKeysDescription)
			{
				stringBuilder.AppendLine(LocalizationAPI.L(translationKey));
			}
			Sprite requiredLicenseIconSprite = null;
			GeneralLicenseType_v2 requiredGeneralLicense = generalLicense.requiredGeneralLicense;
			JobLicenseType_v2 requiredJobLicense = generalLicense.requiredJobLicense;
			if (requiredGeneralLicense != null)
			{
				requiredLicenseIconSprite = requiredGeneralLicense.icon;
			}
			else if (requiredJobLicense != null)
			{
				requiredLicenseIconSprite = requiredJobLicense.icon;
			}
			float price = generalLicense.price;
			string cost = ((price != 0f) ? ("$" + price.ToString("N2", LocalizationAPI.CC)) : "N/A");
			float insuranceFeeQuotaIncrease = generalLicense.insuranceFeeQuotaIncrease;
			string insuranceParticipation = ((insuranceFeeQuotaIncrease != 0f) ? ("+$" + insuranceFeeQuotaIncrease.ToString("N2", LocalizationAPI.CC)) : "N/A");
			float num = generalLicense.bonusTimeDecreasePercentage * 100f;
			string timeBonusDecrease = ((num != 0f) ? (((num > 0f) ? "-" : "+") + Mathf.Abs(num).ToString("N2", LocalizationAPI.CC) + "%") : "N/A");
			return new LicenseTemplatePaperData(LocalizationAPI.L(generalLicense.localizationKey), stringBuilder.ToString(), generalLicense.color, cost, insuranceParticipation, timeBonusDecrease, generalLicense.icon, requiredLicenseIconSprite);
		}
	}
}
