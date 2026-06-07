using System.Collections;
using UnityEngine;

public class WorldInteractable : OverlayBehaviour
{
	[SerializeField]
	[Tooltip("Scale the interactable to the game camera.")]
	private bool _scaleToCamera = true;

	[SerializeField]
	[ConditionalHide("_scaleToCamera")]
	[Tooltip("Height of the interactable to use when scaling to camera.")]
	private float _height = 38f;

	[SerializeField]
	private bool _clip = true;

	[ConditionalHide("_clip")]
	[SerializeField]
	[Tooltip("Distance at which interactable is made invisible.")]
	private float _clipDistance = 50f;

	private Camera _targetCamera;

	private bool _runningTween;

	protected override void Awake()
	{
		base.Awake();
		_targetCamera = CameraController.Instance.UICamera;
	}

	public void FaceCamera()
	{
		if (_clip)
		{
			float num = Vector3.Distance(base.transform.position, _targetCamera.transform.position);
			if (!_runningTween)
			{
				if (num > _clipDistance + 2f && base.gameObject.activeInHierarchy)
				{
					StartCoroutine(DisappearCoroutine());
					return;
				}
				if (num < _clipDistance - 2f && !base.gameObject.activeInHierarchy)
				{
					base.gameObject.SetActive(value: true);
					StartCoroutine(AppearCoroutine());
				}
			}
		}
		base.gameObject.transform.forward = _targetCamera.transform.forward;
	}

	public void ScaleToCamera()
	{
		if (_scaleToCamera)
		{
			Vector3 vector = _targetCamera.WorldToScreenPoint(base.transform.position);
			Vector3 position = new Vector3(vector.x, vector.y + _height, vector.z);
			Vector3 vector2 = _targetCamera.ScreenToWorldPoint(position);
			base.transform.localScale = Vector3.one * (base.transform.position - vector2).magnitude;
		}
	}

	private IEnumerator DisappearCoroutine()
	{
		_runningTween = true;
		yield return Tweener.TweenRoutine(0.2f, EasingFunctions.SineIn, true, new TransformScaleTweener(base.transform, 0f, is2D: true));
		base.gameObject.SetActive(value: false);
		_runningTween = false;
	}

	private IEnumerator AppearCoroutine()
	{
		_runningTween = true;
		yield return Tweener.TweenRoutine(0.3f, EasingFunctions.SineOut, true, new TransformScaleTweener(base.transform, 1f, is2D: true));
		_runningTween = false;
	}
}
