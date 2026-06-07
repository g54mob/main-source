using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Obj_CardSlot : MonoBehaviour, IDropHandler, IEventSystemHandler
{
	[SerializeField]
	private Image image_Debug_SlotStatus;

	[SerializeField]
	private UI_DraggableCard currentCard;

	private bool isDraggable;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public bool HasCardInSlot()
	{
		return false;
	}

	public UI_DraggableCard GetCurrentCard()
	{
		return null;
	}

	public void PutCardOnSlot(UI_DraggableCard card)
	{
	}

	public void MoveCurrentCardToSlot(UI_Obj_CardSlot targetSlot)
	{
	}

	public void RemoveCardFromSlot(UI_DraggableCard card)
	{
	}

	public void ToggleDraggable(bool isDraggable)
	{
	}

	public void OnDrop(PointerEventData eventData)
	{
	}
}
