using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Camera/Pinch-Zoom")]
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(PinchRecognizer))]
public class TBPinchZoom : MonoBehaviour
{
	public enum ZoomMethod
	{
		Position = 0,
		FOV = 1
	}

	public ZoomMethod zoomMethod;

	public float zoomSpeed = 5f;

	public float minZoomAmount;

	public float maxZoomAmount = 50f;

	public float SmoothSpeed = 4f;

	private Vector3 defaultPos = Vector3.zero;

	private float defaultFov;

	private float defaultOrthoSize;

	private float idealZoomAmount;

	private float zoomAmount;

	public Vector3 DefaultPos
	{
		get
		{
			return defaultPos;
		}
		set
		{
			defaultPos = value;
		}
	}

	public float DefaultFov
	{
		get
		{
			return defaultFov;
		}
		set
		{
			defaultFov = value;
		}
	}

	public float DefaultOrthoSize
	{
		get
		{
			return defaultOrthoSize;
		}
		set
		{
			defaultOrthoSize = value;
		}
	}

	public float IdealZoomAmount
	{
		get
		{
			return idealZoomAmount;
		}
		set
		{
			idealZoomAmount = Mathf.Clamp(value, minZoomAmount, maxZoomAmount);
		}
	}

	public float ZoomAmount
	{
		get
		{
			return zoomAmount;
		}
		set
		{
			zoomAmount = Mathf.Clamp(value, minZoomAmount, maxZoomAmount);
			switch (zoomMethod)
			{
			case ZoomMethod.Position:
				base.transform.position = defaultPos + zoomAmount * base.transform.forward;
				break;
			case ZoomMethod.FOV:
				if (GetComponent<Camera>().orthographic)
				{
					GetComponent<Camera>().orthographicSize = Mathf.Max(defaultOrthoSize - zoomAmount, 0.1f);
				}
				else
				{
					CameraFov = Mathf.Max(defaultFov - zoomAmount, 0.1f);
				}
				break;
			}
		}
	}

	private float CameraFov
	{
		get
		{
			return GetComponent<Camera>().fieldOfView;
		}
		set
		{
			GetComponent<Camera>().fieldOfView = value;
		}
	}

	public float ZoomPercent => (ZoomAmount - minZoomAmount) / (maxZoomAmount - minZoomAmount);

	private void Start()
	{
		if (!GetComponent<PinchRecognizer>())
		{
			Debug.LogWarning("No pinch recognizer found on " + base.name + ". Disabling TBPinchZoom.");
			base.enabled = false;
		}
		SetDefaults();
	}

	private void Update()
	{
		ZoomAmount = Mathf.Lerp(ZoomAmount, IdealZoomAmount, Time.unscaledDeltaTime * SmoothSpeed);
	}

	public void SetDefaults()
	{
		DefaultPos = base.transform.position;
		DefaultFov = CameraFov;
		DefaultOrthoSize = GetComponent<Camera>().orthographicSize;
	}

	private void OnPinch(PinchGesture gesture)
	{
		IdealZoomAmount += zoomSpeed * gesture.Delta.Centimeters();
	}
}
