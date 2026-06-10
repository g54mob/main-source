using DG.Tweening;
using UnityEngine;

public class ReactiveProp : MonoBehaviour
{
	[Header("Settings")]
	[Tooltip("How much to scale up when hovered")]
	public float hoverScaleFactor = 1.1f;

	[Tooltip("How much to rotate (wiggle) when hovered")]
	public float wiggleStrength = 15f;

	[Tooltip("How fast the animations play")]
	public float animDuration = 0.2f;

	private Vector3 _originalScale;

	private Quaternion _originalRotation;

	private void Awake()
	{
		_originalScale = base.transform.localScale;
		_originalRotation = base.transform.localRotation;
	}

	private void OnMouseEnter()
	{
		base.transform.DOKill();
		base.transform.DOScale(_originalScale * hoverScaleFactor, animDuration).SetEase(Ease.OutBack);
		base.transform.DOShakeRotation(animDuration, new Vector3(0f, 0f, wiggleStrength), 10, 90f, fadeOut: false);
	}

	private void OnMouseExit()
	{
		base.transform.DOKill();
		base.transform.DOScale(_originalScale, animDuration).SetEase(Ease.OutQuad);
		base.transform.DOLocalRotateQuaternion(_originalRotation, animDuration);
	}

	private void OnMouseDown()
	{
		base.transform.DOKill();
		base.transform.DOScale(_originalScale * 0.9f, 0.1f).SetEase(Ease.OutQuad);
	}

	private void OnMouseUp()
	{
		base.transform.DOScale(_originalScale * hoverScaleFactor, 0.2f).SetEase(Ease.OutBack);
	}

	public void AnimateEntrance(float delay)
	{
		base.transform.localScale = Vector3.zero;
		base.transform.DOScale(_originalScale, 0.5f).SetEase(Ease.OutBack).SetDelay(delay);
	}
}
