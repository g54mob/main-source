using System;
using System.Collections;
using DV.Localization;
using DV.LocoRestoration;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Utils;
using UnityEngine;

public class LocoZoneBlocker : ZoneBlocker
{
	public CabTeleportDestination cab;

	[NonSerialized]
	public GeneralLicenseType_v2 additionalLicenseRequired;

	private TrainCar train;

	private BaseControlsOverrider ctrl;

	private GeneralLicenseType_v2 requiredLicense;

	private bool licenseAcquired;

	private bool freeRoamMode;

	private LocoRestorationController restoration;

	private void Awake()
	{
		train = TrainCar.Resolve(base.gameObject);
		ctrl = train.SimController?.controlsOverrider;
		requiredLicense = train?.carLivery?.requiredLicense;
		if (train == null || ctrl == null || requiredLicense == null)
		{
			Debug.LogError("Couldn't find TrainCar, BaseControlsOverrider or requiredLicense! Destroying blocker");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			freeRoamMode = !SingletonBehaviour<UserManager>.Instance || SingletonBehaviour<UserManager>.Instance.CurrentUser.CurrentSession.GameMode == "FreeRoam";
		}
	}

	private void Start()
	{
		base.transform.SetParent(train.interior);
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
		licenseAcquired = SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(requiredLicense);
		if (additionalLicenseRequired != null)
		{
			licenseAcquired = licenseAcquired && SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(additionalLicenseRequired);
		}
		if (licenseAcquired)
		{
			UnblockLoco();
			return;
		}
		train.blockInteriorLoading = true;
		BlockLoco();
		SetupListeners(set: true);
		restoration = LocoRestorationController.GetForTrainCar(train);
	}

	public override string GetHoverText()
	{
		bool flag = additionalLicenseRequired != null && !SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(additionalLicenseRequired);
		return LocalizationAPI.L(freeRoamMode ? "interaction/loco_requires_freeroam" : "interaction/loco_requires", LocalizationAPI.L(flag ? additionalLicenseRequired.localizationKey : requiredLicense.localizationKey));
	}

	protected override string GetHoverTooltipMessage()
	{
		if (restoration != null && restoration.State < LocoRestorationController.RestorationState.S3_RerailedCars)
		{
			return LocoRestorationView.GetStatusMessageFor(train.carLivery, restoration.State, popupMode: false);
		}
		return string.Empty;
	}

	protected override Transform GetHoverTooltipAnchor()
	{
		return train.transform;
	}

	protected override Vector3 GetHoverTooltipOffset()
	{
		return Vector3.up;
	}

	private void BlockLoco()
	{
		if (cab != null)
		{
			cab.gameObject.SetActive(value: false);
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(SetBrakeValuesCoro());
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
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnLicenseAcquired;
		}
		else
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnLicenseAcquired;
		}
	}

	private IEnumerator SetBrakeValuesCoro()
	{
		yield return WaitFor.EndOfFrame;
		SetBrakeValues();
	}

	private void SetBrakeValues()
	{
		ctrl.Brake?.Set(0f);
		ctrl.IndependentBrake?.Set(0f);
		ctrl.Handbrake?.Set(0.25f);
		ctrl.Throttle?.Set(0f);
		ctrl.Reverser?.Set(0.5f);
	}

	private void Update()
	{
		if (!licenseAcquired)
		{
			if (PlayerManager.Car == train)
			{
				SetBrakeValues();
			}
			if ((base.transform.position - train.transform.position).sqrMagnitude >= 0.04f)
			{
				Debug.LogWarning(string.Format("Fixing {0} position on '{1}', dist was {2}", "LocoZoneBlocker", train.name, (base.transform.position - train.transform.position).magnitude), this);
				base.transform.SetPositionAndRotation(train.transform.position, train.transform.rotation);
			}
		}
	}

	private void OnLicenseAcquired(GeneralLicenseType_v2 _)
	{
		licenseAcquired = SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(requiredLicense);
		if (additionalLicenseRequired != null)
		{
			licenseAcquired = licenseAcquired && SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(additionalLicenseRequired);
		}
		if (licenseAcquired)
		{
			SetupListeners(set: false);
			UnblockLoco();
		}
	}

	private void UnblockLoco()
	{
		train.blockInteriorLoading = false;
		DestroyBlockers();
		if (cab != null)
		{
			cab.gameObject.SetActive(value: true);
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}
}
