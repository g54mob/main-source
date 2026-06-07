using UnityEngine;

public class TransparencySwitch : MonoBehaviour
{
	private DisplayChanger _colorkeyTransparency;

	private TransparentWindow _alphaTransparency;

	private PlainWindow _plainWindow;

	private CameraZoomAndMove _cameraZoom;

	private void Awake()
	{
		_colorkeyTransparency = GetComponent<DisplayChanger>();
		_alphaTransparency = GetComponent<TransparentWindow>();
		_cameraZoom = GetComponent<CameraZoomAndMove>();
		_plainWindow = GetComponent<PlainWindow>();
	}

	public void SetColorKey(bool state)
	{
		_colorkeyTransparency.enabled = state;
		if (state)
		{
			_cameraZoom.Restart();
		}
	}

	public void SetAlphaKey(bool state)
	{
		_alphaTransparency.enabled = state;
		if (state)
		{
			_alphaTransparency.ResetGameResolutionOnCurrentDisplay();
			_cameraZoom.Restart();
		}
	}

	public void SetCroppedWindows(bool state)
	{
		_plainWindow.enabled = state;
	}

	public void SwitchTransparency(int index)
	{
		SetColorKey(index == 0 || index == 2);
		SetAlphaKey(index == 1);
		SetCroppedWindows(index == 3);
	}
}
