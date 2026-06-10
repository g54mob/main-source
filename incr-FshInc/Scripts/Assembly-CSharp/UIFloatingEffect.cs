using DG.Tweening;
using UnityEngine;

public class UIFloatingEffect : MonoBehaviour
{
	[Header("Floating Settings")]
	[Tooltip("How far it moves up/down (in pixels)")]
	public float floatDistance = 10f;

	[Tooltip("How long it takes to go up")]
	public float floatDuration = 1.5f;

	[Tooltip("Delay before the floating starts (useful to let the tooltip appear first)")]
	public float startDelay = 0.2f;

	[Tooltip("The ease type. InOutSine is best for smooth floating.")]
	public Ease easeType = Ease.InOutSine;

	private Vector3 _originalLocalPos;

	private bool _isInitialized;

	private void Awake()
	{
		_originalLocalPos = base.transform.localPosition;
		_isInitialized = true;
	}

	private void OnEnable()
	{
		if (!_isInitialized)
		{
			_originalLocalPos = base.transform.localPosition;
		}
		base.transform.localPosition = _originalLocalPos;
		base.transform.DOLocalMoveY(floatDistance, floatDuration).SetDelay(startDelay).SetEase(easeType)
			.SetLoops(-1, LoopType.Yoyo)
			.SetRelative(isRelative: true)
			.SetUpdate(isIndependentUpdate: true);
	}

	private void OnDisable()
	{
		base.transform.DOKill();
		base.transform.localPosition = _originalLocalPos;
	}
}
