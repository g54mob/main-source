using UnityEngine;

public class DynamicResolution : MonoBehaviour
{
	[SerializeField]
	private int _width = 1024;

	[SerializeField]
	private int _height = 768;

	private float _lastWidthScale;

	private float _lastHeightScale;

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DynamicResolution");

	public void OnEnable()
	{
		if (Application.isEditor)
		{
			GetComponent<Camera>().allowDynamicResolution = true;
		}
	}

	public void Update()
	{
		if (!Application.isEditor)
		{
			return;
		}
		float num = Mathf.Clamp01((float)_width / (float)Screen.width);
		float num2 = Mathf.Clamp01((float)_height / (float)Screen.height);
		if (_lastWidthScale != num || _lastHeightScale != num2)
		{
			if (num > 0f && num2 > 0f)
			{
				ScalableBufferManager.ResizeBuffers(num, num2);
				Log.Info("Scaling the resolution by {0}x{1} to emulate {2}x{3}.", num, num2, _width, _height);
			}
			_lastWidthScale = num;
			_lastHeightScale = num2;
		}
	}
}
