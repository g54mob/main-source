using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleWhenHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private const float hoverScale = 1.1f;

	private const float duration = 0.2f;

	public void OnPointerEnter(PointerEventData eventData)
	{
		ActivateButton();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		DeactivateButton();
	}

	public void ActivateButton()
	{
		base.transform.DOScale(Vector3.one * 1.1f, 0.2f);
	}

	public void DeactivateButton()
	{
		base.transform.DOComplete();
		base.transform.localScale = Vector3.one;
	}
}
