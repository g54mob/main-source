using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClickHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Card linked_card;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			linked_card.Click();
		}
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			linked_card.RClick();
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
