using Aggro.Core;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnableOnSelectUI : EntityBehaviourBase, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject objectToEnable;

	public bool hover;

	public void OnPointerEnter(PointerEventData eventData)
	{
		hover = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hover = false;
	}

	protected override void OnUpdatePresentation()
	{
		bool active = false;
		EventSystem current = EventSystem.current;
		if (AggroInputManager.mode == InputMode.Gamepad)
		{
			if (current.currentSelectedGameObject == null)
			{
				active = false;
			}
			else if (current.currentSelectedGameObject == base.gameObject)
			{
				active = true;
			}
			objectToEnable.SetActive(active);
		}
		else
		{
			objectToEnable.SetActive(hover);
		}
	}
}
