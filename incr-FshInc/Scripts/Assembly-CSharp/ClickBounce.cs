using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ClickBounce : MonoBehaviour
{
	[Header("Bounce Settings")]
	[Tooltip("How much to squash/stretch (1.3 = 30% bigger)")]
	public float bounceScale = 1.3f;

	[Tooltip("Duration of the bounce animation")]
	public float bounceDuration = 0.3f;

	[Tooltip("How many times it bounces before settling")]
	public int vibrato = 1;

	[Tooltip("How elastic the bounce feels (0 = none, 1 = full)")]
	[Range(0f, 1f)]
	public float elasticity = 0.5f;

	[Header("Hover Settings")]
	[Tooltip("Scale multiplier on hover (1.1 = 10% bigger)")]
	public float hoverScale = 1.1f;

	[Tooltip("Duration of the hover scale-up/down")]
	public float hoverDuration = 0.15f;

	private Vector3 _originalScale;

	private bool _isBouncing;

	private bool _isHovered;

	private Tween _hoverTween;

	private void Start()
	{
		_originalScale = base.transform.localScale;
	}

	private void OnMouseEnter()
	{
		_isHovered = true;
		if (!_isBouncing)
		{
			AnimateToHover();
		}
	}

	private void OnMouseExit()
	{
		_isHovered = false;
		if (!_isBouncing)
		{
			AnimateToNormal();
		}
	}

	private void OnMouseDown()
	{
		if (_isBouncing)
		{
			return;
		}
		_isBouncing = true;
		_hoverTween?.Kill();
		base.transform.localScale = _originalScale;
		base.transform.DOPunchScale(_originalScale * (bounceScale - 1f), bounceDuration, vibrato, elasticity).SetUpdate(isIndependentUpdate: true).OnComplete(delegate
		{
			base.transform.localScale = _originalScale;
			_isBouncing = false;
			if (_isHovered)
			{
				AnimateToHover();
			}
		});
	}

	private void AnimateToHover()
	{
		_hoverTween?.Kill();
		_hoverTween = base.transform.DOScale(_originalScale * hoverScale, hoverDuration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
	}

	private void AnimateToNormal()
	{
		_hoverTween?.Kill();
		_hoverTween = base.transform.DOScale(_originalScale, hoverDuration).SetEase(Ease.OutQuad).SetUpdate(isIndependentUpdate: true);
	}
}
