using UnityEngine;
using UnityEngine.EventSystems;

public class GetMouse : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool isMouseOver;

	public void OnPointerEnter(PointerEventData eventData)
	{
		isMouseOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isMouseOver = false;
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
