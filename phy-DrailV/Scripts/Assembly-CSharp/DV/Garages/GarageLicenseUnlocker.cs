using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

namespace DV.Garages
{
	public class GarageLicenseUnlocker : MonoBehaviour
	{
		public GeneralLicenseType_v2 license;

		private GarageCarSpawner garageSpawner;

		private bool isCareer;

		private void Awake()
		{
			garageSpawner = GetComponent<GarageCarSpawner>();
			if (garageSpawner == null)
			{
				Debug.LogError("Unexpected state: " + base.gameObject.GetPath() + ": garageSpawner is not set!");
			}
			isCareer = SingletonBehaviour<UserManager>.Instance?.CurrentUser?.CurrentSession?.GameMode == "Career";
			if (SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(license))
			{
				OnLicenseAcquired(license);
			}
			else
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnLicenseAcquired;
			}
		}

		private void OnDestroy()
		{
			if (SingletonBehaviour<LicenseManager>.Instance != null)
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnLicenseAcquired;
			}
		}

		private void OnLicenseAcquired(GeneralLicenseType_v2 acquiredLicense)
		{
			if (isCareer && license == acquiredLicense)
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnLicenseAcquired;
				SingletonBehaviour<LicenseManager>.Instance.UnlockGarage(garageSpawner.garageType);
				garageSpawner.AllowSpawning();
			}
		}
	}
}
