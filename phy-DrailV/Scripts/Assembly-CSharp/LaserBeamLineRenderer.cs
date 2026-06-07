using DV.CabControls;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

[ExecuteAfter(typeof(CustomFirstPersonController))]
public class LaserBeamLineRenderer : MonoBehaviour
{
	public LineRenderer beamRender;

	public float lookAtDistance = 200f;

	public bool customColorGradient;

	private bool isNonVr;

	private ItemBase item;

	private bool uniqueMaterial;

	private VRTK_InteractGrab_DV grabController;

	private Material material
	{
		get
		{
			uniqueMaterial = true;
			return beamRender.material;
		}
	}

	private void Awake()
	{
		if (beamRender == null)
		{
			Debug.LogError("beamRender not set!", this);
		}
		if (!customColorGradient)
		{
			LineRenderer lineRenderer = beamRender;
			Color startColor = (beamRender.endColor = Color.white);
			lineRenderer.startColor = startColor;
		}
		isNonVr = !VRManager.IsVREnabled();
	}

	private void Start()
	{
		item = GetComponentInParent<ItemBase>();
	}

	private void OnDestroy()
	{
		if (uniqueMaterial)
		{
			Object.Destroy(material);
		}
	}

	public void SetBeamColor(Color beamColor)
	{
		material.color = beamColor;
	}

	public void EnableBeam(bool enableBeam, bool disableLaserPositionUpdate = false)
	{
		base.gameObject.SetActive(enableBeam);
		if (enableBeam && isNonVr)
		{
			base.enabled = !disableLaserPositionUpdate;
		}
	}

	private void Update()
	{
		base.transform.localRotation = Quaternion.identity;
		if (isNonVr)
		{
			Transform transform = ((PlayerManager.PlayerCamera != null) ? PlayerManager.PlayerCamera.transform : null);
			if (!(transform == null))
			{
				Vector3 vector = transform.position + transform.forward * lookAtDistance;
				base.transform.rotation = Quaternion.LookRotation(vector - base.transform.position);
			}
		}
		else
		{
			Transform transform2 = GetGrabbingController().transform.Find("[telegrab]");
			if ((bool)transform2)
			{
				base.transform.forward = transform2.forward;
			}
		}
	}

	private VRTK_InteractGrab_DV GetGrabbingController()
	{
		if (grabController == null)
		{
			SearchForController();
		}
		if ((bool)grabController && grabController.GetGrabbedObject() != item.gameObject)
		{
			SearchForController();
		}
		return grabController;
	}

	private void SearchForController()
	{
		grabController = VRTK_DeviceFinder.GetControllerLeftHand()?.GetComponent<VRTK_InteractGrab_DV>();
		if (!grabController || !(grabController.GetGrabbedObject() == item.gameObject))
		{
			grabController = VRTK_DeviceFinder.GetControllerRightHand()?.GetComponent<VRTK_InteractGrab_DV>();
			if ((bool)grabController)
			{
				_ = grabController.GetGrabbedObject() == item.gameObject;
			}
		}
	}
}
