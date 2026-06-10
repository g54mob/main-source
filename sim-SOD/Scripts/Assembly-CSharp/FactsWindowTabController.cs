using UnityEngine;

public class FactsWindowTabController : MonoBehaviour
{
	public InfoWindow parentWindow;

	public Evidence evidence;

	public RectTransform rect;

	public RectTransform scrollRectRect;

	public RectTransform parentRect;

	public WindowContentController contentController;

	public Vector2 nativeSize;

	public float fitScale;

	public void Setup(InfoWindow newWindow)
	{
	}

	public void UpdateSlotContent()
	{
	}

	public void OnWindowResize()
	{
	}
}
