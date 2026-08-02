using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RadialColorSwatch : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public RadialColorPicker picker;

	public RectTransform rootRect;

	public GameObject ring;

	public int ringIndex;

	public Color color = Color.white;

	[Header("Anim")]
	public float hoverScale = 1.28f;

	public float openDuration = 0.45f;

	public float spiralDegrees = 150f;

	private float homeRadius;

	private float homeAngleRad;

	private bool homeCached;

	private Tween moveTween;

	private Tween scaleTween;

	private void Awake()
	{
		CacheHome();
		if (ring != null)
		{
			ring.SetActive(value: false);
		}
	}

	private void CacheHome()
	{
		if (rootRect == null)
		{
			rootRect = (RectTransform)base.transform.parent;
		}
		Vector2 anchoredPosition = rootRect.anchoredPosition;
		homeRadius = anchoredPosition.magnitude;
		homeAngleRad = Mathf.Atan2(anchoredPosition.y, anchoredPosition.x);
		homeCached = true;
	}

	public void PlayOpen(float delay)
	{
		if (!homeCached)
		{
			CacheHome();
		}
		moveTween?.Kill();
		ApplySpiral(0f);
		moveTween = DOVirtual.Float(0f, 1f, openDuration, ApplySpiral).SetEase(Ease.OutBack).SetDelay(delay)
			.SetUpdate(isIndependentUpdate: true);
	}

	public void PlayClose(float delay)
	{
		moveTween?.Kill();
		if (ring != null)
		{
			ring.SetActive(value: false);
		}
		moveTween = DOVirtual.Float(1f, 0f, openDuration * 0.7f, ApplySpiral).SetEase(Ease.InBack).SetDelay(delay)
			.SetUpdate(isIndependentUpdate: true);
	}

	private void ApplySpiral(float p)
	{
		if (!(rootRect == null))
		{
			float num = homeRadius * p;
			float f = homeAngleRad + (1f - p) * spiralDegrees * (MathF.PI / 180f);
			rootRect.anchoredPosition = new Vector2(Mathf.Cos(f), Mathf.Sin(f)) * num;
			float num2 = Mathf.Clamp01(p);
			rootRect.localScale = new Vector3(num2, num2, 1f);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		scaleTween?.Kill();
		scaleTween = rootRect.DOScale(hoverScale, 0.15f).SetUpdate(isIndependentUpdate: true);
		if (ring != null)
		{
			ring.SetActive(value: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		scaleTween?.Kill();
		scaleTween = rootRect.DOScale(1f, 0.15f).SetUpdate(isIndependentUpdate: true);
		if (ring != null)
		{
			ring.SetActive(value: false);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (picker != null)
		{
			picker.Select(color);
		}
	}

	private void OnDisable()
	{
		moveTween?.Kill();
		scaleTween?.Kill();
	}
}
