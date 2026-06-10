using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WindowExtraControlsController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool isOver;

	public float fade;

	public RawImage mouseOverDetector;

	[Header("Drawing Controls")]
	public bool drawingControlsEnabled;

	public RectTransform drawingControls;

	[ReorderableList]
	public List<CanvasRenderer> drawingRenderers;

	public DrawingController drawingController;

	public ButtonController toggleDrawingButton;

	public ColourSelectorButtonController colourButton;

	public ButtonController eraserButton;

	public ButtonController clearButton;

	private void Awake()
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}

	public void SetEnableDrawingControls(bool val)
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void ToggleDrawingMode(ButtonController pressedButton)
	{
	}

	public void OnChangeDrawingColour()
	{
	}

	public void ToggleEraser(ButtonController pressedButton)
	{
	}

	public void ClearDrawing(ButtonController pressedButton)
	{
	}
}
