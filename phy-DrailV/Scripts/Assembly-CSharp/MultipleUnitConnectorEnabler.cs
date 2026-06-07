using DV.CabControls;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

public class MultipleUnitConnectorEnabler : MonoBehaviour
{
	private const string NON_VR_PREFAB = "[mu_license_req_info_nonvr]";

	private const string VR_PREFAB = "[mu_license_req_info_vr]";

	private GizmoBase hoseConnectorGizmo;

	private GameObject infoAreaGO;

	private void Start()
	{
		LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
		if (!instance.IsGeneralLicenseAcquired(GeneralLicenseType.MultipleUnit.ToV2()))
		{
			hoseConnectorGizmo = GetComponent<GizmoBase>();
			hoseConnectorGizmo.InteractionAllowed = false;
			instance.LicenseAcquired += OnLicenseAcquired;
			string path = (VRManager.IsVREnabled() ? "[mu_license_req_info_vr]" : "[mu_license_req_info_nonvr]");
			infoAreaGO = (GameObject)Object.Instantiate(Resources.Load(path, typeof(GameObject)), base.transform.position, base.transform.rotation, base.transform);
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void OnLicenseAcquired(GeneralLicenseType_v2 acquiredLicense)
	{
		if (acquiredLicense.v1 == GeneralLicenseType.MultipleUnit)
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnLicenseAcquired;
			hoseConnectorGizmo.InteractionAllowed = true;
			Object.Destroy(infoAreaGO);
			Object.Destroy(this);
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnLicenseAcquired;
		}
	}
}
