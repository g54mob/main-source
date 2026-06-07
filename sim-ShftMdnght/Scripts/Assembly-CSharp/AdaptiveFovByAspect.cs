using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AdaptiveFovByAspect : MonoBehaviour
{
	[Tooltip("FOV to use for 16:9 or wider (default).")]
	public float normalFov = 35f;

	[Tooltip("FOV to use for aspect ratios narrower than 16:9 (e.g., 4:3).")]
	public float squashedFov = 50f;

	[Tooltip("Reference aspect ratio threshold (16:9). If current aspect < this, we use squashedFov.")]
	private float referenceAspect = 1.4545455f;

	private Camera _cam;

	private int _lastW;

	private int _lastH;

	private void Awake()
	{
		_cam = GetComponent<Camera>();
		if (_cam == null)
		{
			Debug.LogError("[AdaptiveFovByAspect] No Camera component found.");
			base.enabled = false;
		}
	}

	private void OnEnable()
	{
		_lastW = 0;
		_lastH = 0;
		ApplyFovIfNeeded();
	}

	private void OnDisable()
	{
		if (_cam != null)
		{
			_cam.fieldOfView = normalFov;
		}
	}

	private void ApplyFovIfNeeded()
	{
		_lastW = Screen.width;
		_lastH = Screen.height;
		if (_lastH > 0)
		{
			float num = (float)_lastW / (float)_lastH;
			_cam.fieldOfView = ((num < referenceAspect) ? squashedFov : normalFov);
		}
	}
}
