using UnityEngine;
using UnityEngine.UI;

public class ScreenShapeFitter : MonoBehaviour
{
	public Camera cam;

	public CanvasScaler scaler;

	private int lastWidth;

	private int lastHeight;

	private float referenceAspect;

	private float referenceFOV;

	private void Awake()
	{
		if (cam == null)
		{
			cam = GetComponent<Camera>();
			if (!cam)
			{
				Debug.LogError("ScreenShapeFitter couldn't find a Camera, and none was assigned, destroying");
				Object.Destroy(this);
				return;
			}
		}
		if (cam.stereoEnabled)
		{
			Object.Destroy(this);
			return;
		}
		referenceFOV = cam.fieldOfView;
		if (scaler == null)
		{
			scaler = GetComponentInParent<CanvasScaler>();
			if (!scaler)
			{
				Debug.LogError("ScreenShapeFitter couldn't find a CanvasScaler, and none was assigned, destroying");
				Object.Destroy(this);
				return;
			}
		}
		referenceAspect = scaler.referenceResolution.x / scaler.referenceResolution.y;
		Update();
	}

	private void Update()
	{
		if (Screen.width != lastWidth || Screen.height != lastHeight)
		{
			lastWidth = Screen.width;
			lastHeight = Screen.height;
			if ((float)lastWidth / (float)lastHeight < referenceAspect)
			{
				float num = (float)lastWidth / referenceAspect;
				cam.fieldOfView = referenceFOV * ((float)lastHeight / num);
			}
			else
			{
				cam.fieldOfView = referenceFOV;
			}
		}
	}
}
