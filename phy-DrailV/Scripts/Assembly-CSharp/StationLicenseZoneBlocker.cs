using DV.Localization;
using DV.ThingTypes;
using DV.Utils;

public class StationLicenseZoneBlocker : ZoneBlocker
{
	public JobLicenseType_v2 requiredJobLicense;

	public GeneralLicenseType_v2 requiredGeneralLicense;

	private bool jobLicenseAcquired;

	private bool generalLicenseAcquired;

	private void Start()
	{
		jobLicenseAcquired = requiredJobLicense == null;
		if (requiredJobLicense != null)
		{
			jobLicenseAcquired = SingletonBehaviour<LicenseManager>.Instance.IsJobLicenseAcquired(requiredJobLicense);
		}
		generalLicenseAcquired = requiredGeneralLicense == null;
		if (requiredGeneralLicense != null)
		{
			generalLicenseAcquired = SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(requiredGeneralLicense);
		}
		if (generalLicenseAcquired && jobLicenseAcquired)
		{
			DestroyBlockers();
		}
		else
		{
			SetupListeners(set: true);
		}
	}

	public override string GetHoverText()
	{
		return LocalizationAPI.L("interaction/area_requires", LocalizationAPI.L((!generalLicenseAcquired) ? requiredGeneralLicense.localizationKey : requiredJobLicense.localizationKey));
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(set: false);
		}
	}

	private void SetupListeners(bool set)
	{
		if (set)
		{
			if (requiredGeneralLicense != null && !generalLicenseAcquired)
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnGeneralLicenseAcquired;
			}
			if (requiredJobLicense != null && !jobLicenseAcquired)
			{
				SingletonBehaviour<LicenseManager>.Instance.JobLicenseAcquired += OnJobLicenseAcquired;
			}
		}
		else
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnGeneralLicenseAcquired;
			SingletonBehaviour<LicenseManager>.Instance.JobLicenseAcquired -= OnJobLicenseAcquired;
		}
	}

	private void OnGeneralLicenseAcquired(GeneralLicenseType_v2 license)
	{
		if (license == requiredGeneralLicense)
		{
			generalLicenseAcquired = true;
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnGeneralLicenseAcquired;
			if (jobLicenseAcquired)
			{
				DestroyBlockers();
			}
		}
	}

	private void OnJobLicenseAcquired(JobLicenseType_v2 license)
	{
		if (license == requiredJobLicense)
		{
			jobLicenseAcquired = true;
			SingletonBehaviour<LicenseManager>.Instance.JobLicenseAcquired -= OnJobLicenseAcquired;
			if (generalLicenseAcquired)
			{
				DestroyBlockers();
			}
		}
	}
}
