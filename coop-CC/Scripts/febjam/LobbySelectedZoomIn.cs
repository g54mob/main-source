using Aggro.Core;
using UnityEngine;
using UnityEngine.EventSystems;

public class LobbySelectedZoomIn : EntityBehaviourBase, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private bool wasLastSelected;

	protected override void OnUpdatePresentation()
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == base.gameObject)
		{
			wasLastSelected = true;
		}
		else if (currentSelectedGameObject == null && wasLastSelected)
		{
			wasLastSelected = true;
		}
		else
		{
			wasLastSelected = false;
		}
		if (wasLastSelected)
		{
			AggroManagerBase<LobbyCamera>.instance.zoomIn = true;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
