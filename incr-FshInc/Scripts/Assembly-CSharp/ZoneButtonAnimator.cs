using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneButtonAnimator : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	[Header("UI Data Binding")]
	public TMP_Text zoneNameText;

	public TMP_Text priceText;

	public Image iconImage;

	[Header("Visual Targets")]
	public Transform visualTarget;

	public Image shadowImage;

	[Header("Lock Settings")]
	public Animator lockAnimator;

	public string lockedParamName = "Locked";

	[Header("Animation Settings")]
	public float hoverHeight = 20f;

	public float hoverScale = 1.1f;

	public float animDuration = 0.25f;

	public float shadowRestingAlpha = 0.3f;

	public float shadowMaxAlpha = 0.6f;

	public float shadowTargetScale = 1.5f;

	public float shadowVerticalDrop = 15f;

	public float selectedHeight = 20f;

	public float floatAmplitude = 5f;

	public float floatSpeed = 1f;

	[HideInInspector]
	public ZoneData zoneData;

	private Vector3 iconOrigPos;

	private Vector3 iconOrigScale;

	private Vector3 shadowOrigPos;

	private Vector3 shadowOrigScale;

	private bool isSelected;

	private bool isLocked;

	private void Awake()
	{
		if (visualTarget == null)
		{
			visualTarget = base.transform;
		}
		iconOrigPos = visualTarget.localPosition;
		iconOrigScale = visualTarget.localScale;
		if (shadowImage != null)
		{
			shadowOrigPos = shadowImage.transform.localPosition;
			shadowOrigScale = shadowImage.transform.localScale;
			Color color = shadowImage.color;
			color.a = shadowRestingAlpha;
			shadowImage.color = color;
		}
	}

	public void InitializeLock(bool isUnlocked)
	{
		isLocked = !isUnlocked;
		if (lockAnimator != null)
		{
			lockAnimator.SetBool(lockedParamName, isLocked);
			lockAnimator.gameObject.SetActive(isLocked);
		}
	}

	public void UnlockZone()
	{
		if (lockAnimator != null && lockAnimator.gameObject.activeSelf)
		{
			lockAnimator.SetBool(lockedParamName, value: false);
			StartCoroutine(DisableLockAfterAnim());
		}
	}

	private IEnumerator DisableLockAfterAnim()
	{
		yield return null;
		float seconds = 1f;
		if (lockAnimator.layerCount > 0)
		{
			seconds = lockAnimator.GetCurrentAnimatorStateInfo(0).length;
		}
		yield return new WaitForSeconds(seconds);
		lockAnimator.gameObject.SetActive(value: false);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isSelected)
		{
			AnimateState(isRaised: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!isSelected)
		{
			AnimateState(isRaised: false);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		visualTarget.DOScale(iconOrigScale * 0.95f, 0.1f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!isSelected)
		{
			visualTarget.DOScale(iconOrigScale * hoverScale, 0.1f);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void SetSelected(bool selected)
	{
		isSelected = selected;
		visualTarget.DOKill();
		if (shadowImage != null)
		{
			shadowImage.transform.DOKill();
			shadowImage.DOKill();
		}
		if (isSelected)
		{
			AnimateState(isRaised: true);
			visualTarget.DOLocalMoveY(iconOrigPos.y + selectedHeight, animDuration).OnComplete(delegate
			{
				visualTarget.DOLocalMoveY(iconOrigPos.y + selectedHeight + floatAmplitude, floatSpeed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
			});
		}
		else
		{
			AnimateState(isRaised: false);
		}
	}

	private void AnimateState(bool isRaised)
	{
		visualTarget.DOKill();
		if (isRaised)
		{
			visualTarget.DOLocalMoveY(iconOrigPos.y + hoverHeight, animDuration).SetEase(Ease.OutBack);
			visualTarget.DOScale(iconOrigScale * hoverScale, animDuration).SetEase(Ease.OutBack);
			if (shadowImage != null)
			{
				shadowImage.DOFade(shadowMaxAlpha, animDuration);
				shadowImage.transform.DOLocalMoveY(shadowOrigPos.y - shadowVerticalDrop, animDuration).SetEase(Ease.OutBack);
				shadowImage.transform.DOScale(shadowOrigScale * shadowTargetScale, animDuration).SetEase(Ease.OutBack);
			}
		}
		else
		{
			visualTarget.DOLocalMoveY(iconOrigPos.y, animDuration).SetEase(Ease.OutQuad);
			visualTarget.DOScale(iconOrigScale, animDuration).SetEase(Ease.OutQuad);
			if (shadowImage != null)
			{
				shadowImage.DOFade(shadowRestingAlpha, animDuration);
				shadowImage.transform.DOLocalMoveY(shadowOrigPos.y, animDuration);
				shadowImage.transform.DOScale(shadowOrigScale, animDuration);
			}
		}
	}
}
