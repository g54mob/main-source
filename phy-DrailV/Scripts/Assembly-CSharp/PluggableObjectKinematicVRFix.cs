using UnityEngine;
using VRTK;

public class PluggableObjectKinematicVRFix : MonoBehaviour
{
	private PluggableObject pluggableObject;

	private VRTK_InteractableObject interactableObject;

	private void Start()
	{
		if (!VRManager.IsVREnabled())
		{
			Debug.LogError("PluggableObjectKinematicVRFix should only be used when VR is enabled. Destroying self.", base.gameObject);
			Object.Destroy(this);
			return;
		}
		pluggableObject = GetComponent<PluggableObject>();
		if (pluggableObject == null)
		{
			Debug.LogError("PluggableObjectKinematicVRFix requires a valid PluggableObject reference. Destroying self.", base.gameObject);
			Object.Destroy(this);
			return;
		}
		interactableObject = pluggableObject.GetComponent<VRTK_InteractableObject>();
		if (interactableObject == null)
		{
			Debug.LogError("PluggableObjectKinematicVRFix requires a valid VRTK_InteractableObject reference. Destroying self.", base.gameObject);
			Object.Destroy(this);
		}
		else
		{
			pluggableObject.PluggedIn += OnPluggedIn;
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && pluggableObject != null)
		{
			pluggableObject.PluggedIn -= OnPluggedIn;
		}
	}

	private void OnPluggedIn(PluggableObject _, PlugSocket __)
	{
		if (interactableObject == null)
		{
			Debug.LogError("PluggableObjectKinematicVRFix: VRTK_InteractableObject is null. Skipping previous state override. This should not happen.", base.gameObject);
			return;
		}
		interactableObject.GetPreviousState(out var previousParent, out var _, out var previousGrabbable);
		interactableObject.OverridePreviousState(previousParent, previousKinematic: true, previousGrabbable);
	}
}
