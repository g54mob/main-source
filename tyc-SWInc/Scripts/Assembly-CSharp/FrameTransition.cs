using UnityEngine;

public class FrameTransition : MonoBehaviour
{
	private static float _delta;

	private static bool _isActive;

	private static bool _waitForReload;

	private static RenderTexture _frame;

	private static Material _blitMat;

	private static FrameTransition _instance;

	public Material BlitMat;

	private Camera _mainCam;

	private void Awake()
	{
		if (_instance != null)
		{
			Object.Destroy(_instance.gameObject);
		}
		if (_blitMat == null)
		{
			_blitMat = new Material(BlitMat);
		}
		_instance = this;
		_mainCam = GetComponent<Camera>();
		if (_waitForReload)
		{
			_waitForReload = false;
			_isActive = true;
			_delta = 0f;
		}
		_instance.enabled = _isActive;
	}

	private void OnDestroy()
	{
		if (_instance == this)
		{
			_instance = null;
		}
	}

	private void Update()
	{
		_delta = Mathf.Clamp01(_delta + Time.deltaTime * 2f);
		if (_delta >= 1f)
		{
			_isActive = false;
			base.enabled = false;
		}
		else
		{
			_blitMat.SetFloat("_Delta", _delta);
		}
	}

	public static void StartTransition(bool waitForReload)
	{
		if (_instance != null)
		{
			_instance.InstanceStartTransition(waitForReload);
		}
	}

	private void InstanceStartTransition(bool waitForReload)
	{
		if (_isActive)
		{
			return;
		}
		_blitMat.SetFloat("_Delta", 0f);
		RenderTexture targetTexture = _mainCam.targetTexture;
		int num = ((targetTexture != null) ? targetTexture.width : Screen.width);
		int num2 = ((targetTexture != null) ? targetTexture.height : Screen.height);
		if (_frame == null || _frame.width != num || _frame.height != num2)
		{
			if (_frame != null)
			{
				Object.Destroy(_frame);
			}
			_frame = new RenderTexture(num, num2, 24, RenderTextureFormat.ARGB32);
			_frame.Create();
			_blitMat.SetTexture("_Overlay", _frame);
		}
		if (targetTexture != null)
		{
			Graphics.Blit(targetTexture, _frame);
		}
		else
		{
			_mainCam.targetTexture = _frame;
			_mainCam.Render();
			_mainCam.targetTexture = null;
		}
		if (waitForReload)
		{
			_waitForReload = true;
			return;
		}
		_waitForReload = false;
		base.enabled = true;
		_isActive = true;
		_delta = 0f;
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, _blitMat);
	}
}
