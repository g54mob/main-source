using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingController : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Setup Components")]
	public RectTransform container;

	public RawImage img;

	public RectTransform drawBrushRect;

	public RawImage brushImage;

	[Header("Generated Components")]
	public Texture2D drawingTex;

	[Header("State")]
	public bool isOver;

	public bool drawingActive;

	public bool eraserMode;

	private bool lastPosValid;

	private Vector2 lastValidLocalPos;

	[Header("Settings")]
	public Color brushColour;

	public Texture2D brush;

	public Vector2 brushSize;

	public bool startedDraw;

	[Header("Buttons")]
	public bool setupButtons;

	public WindowExtraControlsController windowButtonsController;

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

	public void SetDrawingActive(bool val)
	{
	}

	public void ResetDrawingTexture()
	{
	}

	public void SetEraserMode(bool val)
	{
	}

	public void SetBrushColour(Color newCol)
	{
	}

	public void SetBrushImage(Texture2D newBrush)
	{
	}

	private void Update()
	{
	}
}
