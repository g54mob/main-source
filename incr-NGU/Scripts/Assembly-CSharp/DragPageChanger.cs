using UnityEngine;
using UnityEngine.EventSystems;

public class DragPageChanger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	public InventoryController ic;

	public int pageID;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (ic.midDrag)
		{
			ic.changePage(pageID);
		}
	}
}
