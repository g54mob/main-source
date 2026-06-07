using Presentation.UI.OperatorUIs.OperatorPanelUIs.HarvesterPad;
using UnityEngine;
using UnityEngine.EventSystems;

public class HarvesterPadUnassignAllButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private HarvesterPadUI _harvesterPadUI;

	public void OnPointerEnter(PointerEventData eventData)
	{
		_harvesterPadUI.HideAllUnlinks();
		_harvesterPadUI.ShowAllUnlinks();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_harvesterPadUI.HideAllUnlinks();
	}
}
