using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasMouseOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private static CanvasMouseOver _instance;

	public GameObject currentHover;

	public static CanvasMouseOver Instance => null;

	private void Awake()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
