using UnityEngine;
using UnityEngine.EventSystems;

public class doubleClickOpen : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public AppPropertiesEthernet appPropertiesEthernet;

	private float lastClickTime;

	private float doubleClickThreshold;

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
