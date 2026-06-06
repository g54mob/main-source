using UnityEngine;
using UnityEngine.EventSystems;

public class LinkableItemCounterSlot : ItemCounterSlot, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private float _defaultScale = 1f;

	[SerializeField]
	private float _hoverScale = 1.2f;

	public void SelectInSurvivalGuide()
	{
		new StringEvent(GameEventType.OpenSurvivalGuidePage, _properties.SurvivalGuideIdentifier).Dispatch();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		base.transform.localScale = Vector3.one * _hoverScale;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		base.transform.localScale = Vector3.one * _defaultScale;
	}
}
