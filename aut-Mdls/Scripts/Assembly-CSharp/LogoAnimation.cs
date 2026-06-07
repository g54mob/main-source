using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{
	[SerializeField]
	private float _moveAmount = 0.2f;

	[SerializeField]
	private float _moveDuration = 4f;

	private float _rotationSpeed = -90f;

	[SerializeField]
	private bool _canRotate = true;

	private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

	private TweenerCore<Quaternion, Vector3, QuaternionOptions> _rotateTween;

	private void Start()
	{
		float endValue = base.transform.position.y + _moveAmount;
		_tween = base.transform.DOMoveY(endValue, _moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
		if (_canRotate)
		{
			RotateObject();
		}
	}

	private void OnDisable()
	{
		_tween?.Kill();
		_rotateTween?.Kill();
	}

	private void RotateObject()
	{
		if (!(base.transform == null))
		{
			_rotateTween = base.transform.DORotate(new Vector3(0f, 360f, 0f), 1f / (_rotationSpeed / 360f), RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
		}
	}
}
