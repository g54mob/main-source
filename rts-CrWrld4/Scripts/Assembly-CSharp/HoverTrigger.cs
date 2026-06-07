using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public GameObject objectToSetActive;

	public GameObject objectToSetInactive;

	public GameObject objectToSetActive2;

	public GameObject objectToSetInactive2;

	public Image objToRaycast;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
