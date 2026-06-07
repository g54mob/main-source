using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CModPreview : MonoBehaviour
{
	private GameObject previewObject;

	public GameObject buildBar;

	public GameObject healthBar;

	public GameObject ammoBar;

	public LineDrawer colliderPreview;

	public Slider ySlider;

	public Slider xSlider;

	private bool leftDragging;

	private bool rightDragging;

	private bool middleDragging;

	private bool mouseOver;

	private bool docked;

	public void Refresh()
	{
	}

	public void OnYSliderChanged(float val)
	{
	}

	public void OnXSliderChanged(float val)
	{
	}

	public void OnZoomIn()
	{
	}

	public void OnZoomOut()
	{
	}

	public void OnReset()
	{
	}

	public void Update()
	{
	}

	public void OnPointerEnter(BaseEventData ed)
	{
	}

	public void OnPointerExit(BaseEventData ed)
	{
	}

	public void OnBeginDrag(BaseEventData ed)
	{
	}

	public void OnDrag(BaseEventData ed)
	{
	}

	public void OnEndDrag(BaseEventData ed)
	{
	}

	public void OnDock()
	{
	}
}
