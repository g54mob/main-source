using UnityEngine;
using UnityEngine.EventSystems;

public class CloseWindow : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject windowObj;

	public void OnPointerClick(PointerEventData eventData)
	{
		windowObj.SetActive(value: false);
	}

	public void PressedCloseWindow()
	{
		windowObj.SetActive(value: false);
	}
}
