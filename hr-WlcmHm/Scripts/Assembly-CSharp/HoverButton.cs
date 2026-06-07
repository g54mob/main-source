using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
	[SerializeField]
	private float scaleFactor = 1.2f;

	[SerializeField]
	private float animationDuration = 0.3f;

	[SerializeField]
	private Ease hoverEase = Ease.OutBack;

	[SerializeField]
	private Ease exitEase = Ease.InBack;

	private Image[] images;

	private TMP_Text[] textComponents;

	private Vector3 originalScale;

	private void Awake()
	{
		originalScale = base.transform.localScale;
		if (GetComponentsInChildren<Image>() != null)
		{
			images = GetComponentsInChildren<Image>();
			Image[] array = images;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
		}
		if (GetComponentsInChildren<TMP_Text>() != null)
		{
			textComponents = GetComponentsInChildren<TMP_Text>();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShowHoverEffects();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HideHoverEffects();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		HideHoverEffects();
	}

	public void OnSelect(BaseEventData eventData)
	{
		ShowHoverEffects();
	}

	public void OnDeselect(BaseEventData eventData)
	{
		HideHoverEffects();
	}

	private void OnDisable()
	{
		HideHoverEffects();
	}

	private void ShowHoverEffects()
	{
		Image[] array = images;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = true;
		}
		TMP_Text[] array2 = textComponents;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].transform.DOScale(originalScale * scaleFactor, animationDuration).SetEase(hoverEase).SetUpdate(isIndependentUpdate: true);
		}
	}

	private void HideHoverEffects()
	{
		Image[] array = images;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
		TMP_Text[] array2 = textComponents;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].transform.DOScale(originalScale, animationDuration).SetEase(exitEase).SetUpdate(isIndependentUpdate: true);
		}
	}
}
