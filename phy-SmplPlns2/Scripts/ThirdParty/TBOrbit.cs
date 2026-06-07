using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Camera/Orbit")]
public class TBOrbit : MonoBehaviour
{
	public enum PanMode
	{
		Disabled = 0,
		OneFinger = 1,
		TwoFingers = 2
	}

	public Transform target;

	public float initialDistance = 10f;

	public float minDistance = 1f;

	public float maxDistance = 30f;

	public float yawSensitivity = 45f;

	public float pitchSensitivity = 45f;

	public bool clampYawAngle;

	public float minYaw = -75f;

	public float maxYaw = 75f;

	public bool clampPitchAngle = true;

	public float minPitch = -20f;

	public float maxPitch = 80f;

	public bool allowPinchZoom = true;

	public float pinchZoomSensitivity = 5f;

	public bool smoothMotion = true;

	public float smoothZoomSpeed = 5f;

	public float smoothOrbitSpeed = 10f;

	public bool allowPanning;

	public bool invertPanningDirections;

	public float panningSensitivity = 1f;

	public Transform panningPlane;

	public bool smoothPanning = true;

	public float smoothPanningSpeed = 12f;

	public LayerMask collisionLayerMask;

	private float distance = 10f;

	private float yaw;

	private float pitch;

	private float idealDistance;

	private float idealYaw;

	private float idealPitch;

	private Vector3 idealPanOffset = Vector3.zero;

	private Vector3 panOffset = Vector3.zero;

	private PinchRecognizer pinchRecognizer;

	private float nextDragTime;

	public bool OnlyRotateWhenDragStartsOnObject;

	public float Distance => distance;

	public float IdealDistance
	{
		get
		{
			return idealDistance;
		}
		set
		{
			idealDistance = Mathf.Clamp(value, minDistance, maxDistance);
		}
	}

	public float Yaw => yaw;

	public float IdealYaw
	{
		get
		{
			return idealYaw;
		}
		set
		{
			idealYaw = (clampYawAngle ? ClampAngle(value, minYaw, maxYaw) : value);
		}
	}

	public float Pitch => pitch;

	public float IdealPitch
	{
		get
		{
			return idealPitch;
		}
		set
		{
			idealPitch = (clampPitchAngle ? ClampAngle(value, minPitch, maxPitch) : value);
		}
	}

	public Vector3 IdealPanOffset
	{
		get
		{
			return idealPanOffset;
		}
		set
		{
			idealPanOffset = value;
		}
	}

	public Vector3 PanOffset => panOffset;

	private void InstallGestureRecognizers()
	{
		List<GestureRecognizer> list = new List<GestureRecognizer>(GetComponents<GestureRecognizer>());
		DragRecognizer dragRecognizer = list.Find((GestureRecognizer r) => r.EventMessageName == "OnDrag") as DragRecognizer;
		DragRecognizer dragRecognizer2 = list.Find((GestureRecognizer r) => r.EventMessageName == "OnTwoFingerDrag") as DragRecognizer;
		PinchRecognizer obj = list.Find((GestureRecognizer r) => r.EventMessageName == "OnPinch") as PinchRecognizer;
		if (OnlyRotateWhenDragStartsOnObject && !base.gameObject.GetComponent<ScreenRaycaster>())
		{
			base.gameObject.AddComponent<ScreenRaycaster>();
		}
		if (!dragRecognizer)
		{
			dragRecognizer = base.gameObject.AddComponent<DragRecognizer>();
			dragRecognizer.RequiredFingerCount = 1;
			dragRecognizer.IsExclusive = true;
			dragRecognizer.MaxSimultaneousGestures = 1;
			dragRecognizer.SendMessageToSelection = GestureRecognizer.SelectionType.None;
		}
		if (!obj)
		{
			base.gameObject.AddComponent<PinchRecognizer>();
		}
		if (!dragRecognizer2)
		{
			dragRecognizer2 = base.gameObject.AddComponent<DragRecognizer>();
			dragRecognizer2.RequiredFingerCount = 2;
			dragRecognizer2.IsExclusive = true;
			dragRecognizer2.MaxSimultaneousGestures = 1;
			dragRecognizer2.ApplySameDirectionConstraint = true;
			dragRecognizer2.EventMessageName = "OnTwoFingerDrag";
		}
	}

	private void Start()
	{
		InstallGestureRecognizers();
		if (!panningPlane)
		{
			panningPlane = base.transform;
		}
		Vector3 eulerAngles = base.transform.eulerAngles;
		float num = (IdealDistance = initialDistance);
		distance = num;
		num = (IdealYaw = eulerAngles.y);
		yaw = num;
		num = (IdealPitch = eulerAngles.x);
		pitch = num;
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		Apply();
	}

	private void OnDrag(DragGesture gesture)
	{
		if (OnlyRotateWhenDragStartsOnObject)
		{
			if (gesture.Phase == ContinuousGesturePhase.Started)
			{
				if (!gesture.Recognizer.Raycaster)
				{
					Debug.LogWarning("The drag recognizer on " + gesture.Recognizer.name + " has no ScreenRaycaster component set. This will prevent OnlyRotateWhenDragStartsOnObject flag from working.");
					OnlyRotateWhenDragStartsOnObject = false;
					return;
				}
				if ((bool)target && !target.GetComponent<Collider>())
				{
					Debug.LogWarning("The target object has no collider set. OnlyRotateWhenDragStartsOnObject won't work.");
					OnlyRotateWhenDragStartsOnObject = false;
					return;
				}
			}
			if (!target || gesture.StartSelection != target.gameObject)
			{
				return;
			}
		}
		if (!(Time.time < nextDragTime) && (bool)target)
		{
			IdealYaw += gesture.DeltaMove.x.Centimeters() * yawSensitivity;
			IdealPitch -= gesture.DeltaMove.y.Centimeters() * pitchSensitivity;
		}
	}

	private void OnPinch(PinchGesture gesture)
	{
		if (allowPinchZoom)
		{
			IdealDistance -= gesture.Delta.Centimeters() * pinchZoomSensitivity;
			nextDragTime = Time.time + 0.25f;
		}
	}

	private void OnTwoFingerDrag(DragGesture gesture)
	{
		if (allowPanning)
		{
			Vector3 vector = (0f - panningSensitivity) * (panningPlane.right * gesture.DeltaMove.x.Centimeters() + panningPlane.up * gesture.DeltaMove.y.Centimeters());
			if (invertPanningDirections)
			{
				IdealPanOffset -= vector;
			}
			else
			{
				IdealPanOffset += vector;
			}
			nextDragTime = Time.time + 0.25f;
		}
	}

	private void Apply()
	{
		if (smoothMotion)
		{
			distance = Mathf.Lerp(distance, IdealDistance, Time.unscaledDeltaTime * smoothZoomSpeed);
			yaw = Mathf.Lerp(yaw, IdealYaw, Time.unscaledDeltaTime * smoothOrbitSpeed);
			pitch = Mathf.LerpAngle(pitch, IdealPitch, Time.unscaledDeltaTime * smoothOrbitSpeed);
		}
		else
		{
			distance = IdealDistance;
			yaw = IdealYaw;
			pitch = IdealPitch;
		}
		if (smoothPanning)
		{
			panOffset = Vector3.Lerp(panOffset, idealPanOffset, Time.unscaledDeltaTime * smoothPanningSpeed);
		}
		else
		{
			panOffset = idealPanOffset;
		}
		base.transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
		Vector3 vector = target.position + panOffset;
		Vector3 vector2 = vector - distance * base.transform.forward;
		if ((int)collisionLayerMask != 0)
		{
			Vector3 vector3 = vector2 - vector;
			float magnitude = vector3.magnitude;
			vector3.Normalize();
			if (Physics.Raycast(vector, vector3, out var hitInfo, magnitude, collisionLayerMask))
			{
				vector2 = hitInfo.point - vector3 * 0.1f;
				distance = hitInfo.distance;
			}
		}
		base.transform.position = vector2;
	}

	private void LateUpdate()
	{
		Apply();
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public void ResetPanning()
	{
		IdealPanOffset = Vector3.zero;
	}
}
