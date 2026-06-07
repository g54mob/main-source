using Presentation.UI.OperatorUIs.OperatorPanelUIs;
using UnityEngine;
using UnityEngine.EventSystems;

public class SupplyTankUnassignAllButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private SupplyTankUI _supplyTankUI;

	public void OnPointerEnter(PointerEventData eventData)
	{
		_supplyTankUI.HideAllUnlinks();
		_supplyTankUI.ShowAllUnlinks();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_supplyTankUI.HideAllUnlinks();
	}
}
