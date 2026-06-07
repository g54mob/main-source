using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
	public const float MIN_FOV = 30f;

	public const float MAX_FOV = 120f;

	public const float ON = 1f;

	public const float OFF = 0f;

	public Camera cam;

	[SerializeField]
	private float normalFOV = 50f;

	[SerializeField]
	private float zoomedFOV = 20f;

	[SerializeField]
	private float zoomInTime = 0.1f;

	[SerializeField]
	private float zoomOutTime = 0.2f;

	private float currentZoomVelocity;

	private bool disableZoomForced;

	private bool isZoomPressed;

	private bool mouseZoomed;

	private bool screenspaceMode;

	private int lastScreenspaceFrame = -1;

	private Vector3 pointVector;

	private Quaternion rotationStart;

	private Quaternion rotationParentStart;

	private Quaternion rotationEnd;

	private Quaternion rotationParentEnd;

	private bool aimNested;

	private Transform aimReference;

	private Quaternion aimStart;

	private Quaternion aimStop;

	private RequestSystem requestSystem = new RequestSystem(1f);

	private CustomFirstPersonController firstPersonController;

	private CameraAnchorLeanCrouch leanCrouch;

	private CameraDampening cameraDampening;

	public bool IsMouseZoomedIn => mouseZoomed;

	private void Awake()
	{
		if (cam == null)
		{
			Debug.LogError("Camera is not set on CameraZoom! Destroying script", this);
			Object.Destroy(this);
			return;
		}
		requestSystem.ValueChanged += delegate(float value)
		{
			disableZoomForced = value == 0f;
		};
		OnFieldOfViewPreferenceUpdated();
		GamePreferences.RegisterToPreferenceUpdated(Preferences.FieldOfView, OnFieldOfViewPreferenceUpdated);
		SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceMouseOnValueChanged;
		firstPersonController = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>();
		leanCrouch = firstPersonController.GetComponent<CameraAnchorLeanCrouch>();
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			GamePreferences.UnregisterFromPreferenceUpdated(Preferences.FieldOfView, OnFieldOfViewPreferenceUpdated);
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceMouseOnValueChanged;
		}
	}

	private void ScreenspaceMouseOnValueChanged(bool on)
	{
		if (!on)
		{
			lastScreenspaceFrame = Time.frameCount;
		}
		screenspaceMode = on;
	}

	private void OnFieldOfViewPreferenceUpdated()
	{
		SetFOV(GamePreferences.Get<float>(Preferences.FieldOfView));
	}

	public void RequestZoomDisable(object caller, float value, int priority = 0)
	{
		requestSystem.RequestValue(caller, value, priority);
	}

	public void RemoveZoomDisableRequest(object caller)
	{
		requestSystem.RemoveValue(caller);
	}

	public void SetFOV(float value)
	{
		normalFOV = Mathf.Clamp(value, 30f, 120f);
		if (!InputManager.NewPlayer.GetButton(InputManager.Actions.Zoom))
		{
			cam.fieldOfView = normalFOV;
		}
	}

	private void LateUpdate()
	{
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Zoom) && !disableZoomForced)
		{
			if (!isZoomPressed && (SingletonBehaviour<ScreenspaceMouse>.Instance.on || lastScreenspaceFrame == Time.frameCount))
			{
				Vector3 forward = cam.transform.forward;
				pointVector = cam.ScreenPointToRay(Input.mousePosition).direction;
				Vector3 normalized = Vector3.Lerp(forward, pointVector, 0.75f).normalized;
				rotationStart = cam.transform.rotation;
				rotationEnd = Quaternion.LookRotation(normalized, cam.transform.up);
				mouseZoomed = true;
				Quaternion quaternion = Quaternion.Inverse(cam.transform.parent.rotation);
				rotationStart = quaternion * rotationStart;
				rotationParentStart = cam.transform.parent.localRotation;
				rotationEnd = quaternion * rotationEnd;
				if (cam.transform.childCount > 0)
				{
					aimReference = (cam.transform.parent ? cam.transform.parent.parent : null);
					aimNested = aimReference != null;
					Quaternion rotation = ((aimReference != null) ? aimReference.rotation : Quaternion.identity);
					aimStart = Quaternion.Inverse(rotation) * cam.transform.GetChild(0).rotation;
				}
				cameraDampening = cam.GetComponentInParent<CameraDampening>();
				if ((bool)cameraDampening)
				{
					cameraDampening.enabled = false;
				}
			}
			isZoomPressed = true;
		}
		else if (isZoomPressed && (!InputManager.NewPlayer.GetButton(InputManager.Actions.Zoom) || disableZoomForced))
		{
			if (isZoomPressed && mouseZoomed)
			{
				rotationEnd = cam.transform.rotation;
				rotationEnd = Quaternion.Inverse(cam.transform.parent.rotation) * rotationEnd;
				rotationParentEnd = cam.transform.parent.localRotation;
				if (cam.transform.childCount > 0)
				{
					aimStop = cam.transform.GetChild(0).localRotation;
				}
			}
			isZoomPressed = false;
		}
		if (isZoomPressed && cam.fieldOfView > zoomedFOV)
		{
			float t = Mathf.InverseLerp(normalFOV, zoomedFOV, cam.fieldOfView);
			if (Time.deltaTime > 0f)
			{
				cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, zoomedFOV, ref currentZoomVelocity, zoomInTime);
			}
			if (mouseZoomed)
			{
				float t2 = Mathf.InverseLerp(normalFOV, zoomedFOV, cam.fieldOfView);
				Quaternion rotation2 = Quaternion.Slerp(rotationStart, rotationEnd, t);
				Quaternion quaternion2 = Quaternion.Slerp(rotationStart, rotationEnd, t2) * Quaternion.Inverse(rotation2);
				Quaternion rotation3 = cam.transform.rotation;
				firstPersonController.m_MouseLook.ForceRotationNoTilt(PlayerManager.PlayerTransform, PlayerManager.PlayerCamera.transform, rotation3 * quaternion2);
				cam.transform.rotation *= leanCrouch.LeanRelativeRotation;
			}
			if (Mathf.Abs(cam.fieldOfView - zoomedFOV) < 0.01f)
			{
				cam.fieldOfView = zoomedFOV;
			}
		}
		if (isZoomPressed && mouseZoomed && cam.transform.childCount > 0)
		{
			Transform transform = (cam.transform.parent ? cam.transform.parent.parent : null);
			if (transform != aimReference || transform != null != aimNested)
			{
				Quaternion rotation4 = ((transform != null) ? transform.rotation : Quaternion.identity) * aimStart;
				aimStart *= Quaternion.Inverse(rotation4) * cam.transform.GetChild(0).rotation;
				aimReference = transform;
				aimNested = aimReference != null;
			}
			Quaternion quaternion3 = ((aimReference != null) ? aimReference.rotation : Quaternion.identity);
			cam.transform.GetChild(0).rotation = quaternion3 * aimStart;
		}
		if (isZoomPressed || !(cam.fieldOfView < normalFOV))
		{
			return;
		}
		if (Time.deltaTime > 0f)
		{
			cam.fieldOfView = Mathf.SmoothDamp(cam.fieldOfView, normalFOV, ref currentZoomVelocity, zoomOutTime);
		}
		if (mouseZoomed)
		{
			float t3 = Mathf.InverseLerp(normalFOV, zoomedFOV, cam.fieldOfView);
			Quaternion quaternion4 = Quaternion.Slerp(rotationStart, rotationEnd, t3);
			Quaternion localRotation = Quaternion.Slerp(rotationParentStart, rotationParentEnd, t3);
			cam.transform.parent.localRotation = localRotation;
			firstPersonController.m_MouseLook.ForceRotationNoTilt(PlayerManager.PlayerTransform, PlayerManager.PlayerCamera.transform, cam.transform.parent.rotation * quaternion4);
			cam.transform.rotation *= leanCrouch.LeanRelativeRotation;
			if (cam.transform.childCount > 0)
			{
				cam.transform.GetChild(0).localRotation = Quaternion.Slerp(Quaternion.identity, aimStop, t3);
			}
		}
		if (Mathf.Abs(cam.fieldOfView - normalFOV) < 0.01f)
		{
			if (mouseZoomed && (bool)cameraDampening)
			{
				cameraDampening.enabled = true;
			}
			mouseZoomed = false;
			cam.fieldOfView = normalFOV;
			if (cam.transform.childCount > 0)
			{
				cam.transform.GetChild(0).localRotation = Quaternion.identity;
			}
		}
	}
}
