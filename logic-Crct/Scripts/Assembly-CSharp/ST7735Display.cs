using UnityEngine;
using UnityEngine.UI;

public class ST7735Display : PinComponent
{
	public bool powerOn;

	private Texture2D screenTex;

	private bool fill;

	private Color fillColor;

	private bool stroke;

	private Color strokeColor;

	public RenderTexture textRT;

	public Camera textCamera;

	public RectTransform textTransform;

	public Text text;

	public Font[] fonts;

	public int[] fontSizes;

	public MeshRenderer screenRenderer;

	private Material screenMat;

	private bool begin;

	public float checkPixelLineThreshold;

	private ST7735Element stElm;

	private float refreshT;

	public void PowerOn()
	{
	}

	public void PowerOff()
	{
	}

	public void ResetPin()
	{
	}

	public override void Awake()
	{
	}

	private void BackgroundSet(int r, int g, int b)
	{
	}

	public void ProcessCommand(byte cmd)
	{
	}

	private void CMD_SetTextSize()
	{
	}

	private void CMD_Text()
	{
	}

	private void CMD_ClearDisplay()
	{
	}

	private void CMD_Begin()
	{
	}

	private void CMD_Background()
	{
	}

	private void CMD_Fill()
	{
	}

	private void CMD_NoFill()
	{
	}

	private void CMD_Stroke()
	{
	}

	private void CMD_NoStroke()
	{
	}

	private void CMD_Point()
	{
	}

	private void CMD_Rect()
	{
	}

	private void CMD_Line()
	{
	}

	private void CMD_Circle()
	{
	}

	private bool CheckPixelInCircle(int x0, int y0, int x, int y, int r)
	{
		return false;
	}

	private bool CheckPixelCircleEdge(int x0, int y0, int x, int y, int r)
	{
		return false;
	}

	private bool CheckPixelOnLine(float x0, float y0, float x1, float y1, float x2, float y2)
	{
		return false;
	}

	public override void FinishPlacement()
	{
	}

	public void Update()
	{
	}
}
