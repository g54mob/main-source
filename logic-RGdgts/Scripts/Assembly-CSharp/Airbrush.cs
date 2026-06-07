using System.Collections.Generic;
using SE.EvilLib.AudioManager;
using UnityEngine;

public class Airbrush : MonoBehaviour
{
	public enum PaintMode
	{
		Free = -1,
		Vertical = 0,
		Horizontal = 1
	}

	public AirbrushSprite tableSprite;

	public AirbrushSprite[] mainAirbrushSprites;

	public AirbrushSprite[] externalAirbrushSprites;

	public Material brushMaterial;

	public float randomCutout;

	public float randomSeedFps;

	public Crosshair crosshair;

	public int brushSize;

	private int[] colorsI;

	private bool interpolate;

	private int spriteI;

	private PixelCameraManager pixelCamera;

	private bool showTableSprite;

	private LinkedList<byte[][]> undoQueue;

	private bool waitButtonUp;

	private PaintMode paintMode;

	private PlayingSound paintingSound;

	private PlayingSound wheelSound;

	private float lastWheelSound;

	private bool clickedOnModule;

	private Vector3 positionVel;

	private int painting;

	private Vector2 startPaintPosition;

	public BrushGestaltEnum brushEnum { get; private set; }

	private float brushMul => 0f;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public Vector2 GetCenter()
	{
		return default(Vector2);
	}

	public void UpdateInteraction()
	{
	}

	private void UpdateSound()
	{
	}

	public void Undo()
	{
	}

	private Vector3 GetFinalPosition()
	{
		return default(Vector3);
	}

	public void SetColor(int slot, int colorI)
	{
	}

	public void SetBrush(BrushGestaltEnum brushEnum)
	{
	}

	public void SetBrushSize(int brushSize)
	{
	}

	public void Enable(Vector3 position, Vector3 initialVelocity)
	{
	}

	public void Disable()
	{
	}

	public void SetSpriteI(int spriteI)
	{
	}

	public void ShowTableSprite(bool showTableSprite)
	{
	}

	private Rect GetBrushRect(Vector2 position, BrushGestaltEnum brushEnum, int brushSize, Motherboard motherboard)
	{
		return default(Rect);
	}

	private void Paint(Vector2 position, int colorI, BrushGestaltEnum brushEnum, float randomCutout, int brushSize, bool addToUndoQueue)
	{
	}

	private ColorPicker RaycastColorPicker()
	{
		return null;
	}

	public void SetPaintMode(PaintMode paintMode)
	{
	}
}
