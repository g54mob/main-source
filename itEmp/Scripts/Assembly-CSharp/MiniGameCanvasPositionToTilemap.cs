using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MiniGameCanvasPositionToTilemap : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public RawImage window;

	private bool isHovering;

	private void Update()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private Vector2 GetMousePositionRelativeToRawImage()
	{
		return default(Vector2);
	}
}
