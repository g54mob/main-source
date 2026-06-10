using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuPanelController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public RectTransform rect;

	private bool isOver;

	public ContextMenuController cmc;

	public List<ContextButtonController> spawnedButtons;

	public void Setup(ContextMenuController newController)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void Update()
	{
	}
}
