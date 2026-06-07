using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTree_BackgroundDragger : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IPointerEnterHandler
{
	private Vector3 dragOffset = Vector3.zero;

	public void OnBeginDrag(PointerEventData eventData)
	{
		dragOffset = base.transform.localPosition - Input.mousePosition;
		UpgradeTreeManager.Singleton.UnHoverOverAllUpgradeTreeTiles();
	}

	public void OnDrag(PointerEventData eventData)
	{
		base.transform.localPosition = Input.mousePosition + dragOffset;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		UpgradeTreeManager.Singleton.UnHoverOverAllUpgradeTreeTiles();
	}
}
