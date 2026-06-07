using TMPro;
using UnityEngine;

public class HD44780 : PinComponent
{
	public struct SaveData
	{
		public bool powerOn;

		public bool functionSet;

		public bool increment;

		public bool shiftDisplay;

		public bool dataLength;

		public bool blink;

		public bool displayOn;

		public bool cursorOn;

		public bool twoLines;

		public char[] DDRAM;

		public char[] charArray;

		public char[] cursorArray;

		public int DDAddress;
	}

	private const int BLOCK = 2959;

	private const char CURSOR = '_';

	[Header("Function")]
	public bool powerOn;

	public bool functionSet;

	[Header("Characters")]
	public TextMeshPro charLine0;

	public TextMeshPro charLine1;

	public TextMeshPro cursorLine0;

	public TextMeshPro cursorLine1;

	public Color characterColor;

	[Header("Contrast")]
	public Color backingColor;

	public TextMeshPro backing;

	public TextMeshPro backingCursorLine;

	public float contrastValue;

	public float contrastHighV;

	public float contrastLowV;

	[Header("Back Light")]
	public Material backLightMaterial;

	public MeshRenderer meshRenderer;

	public Color backLightColor;

	public float backLightValue;

	public AnimationCurve lumCurve;

	public char[] DDRAM;

	public char[] charArray;

	public char[] cursorArray;

	public int DDAddress;

	public bool increment;

	public bool shiftDisplay;

	public int dispShift;

	public bool blink;

	public bool displayOn;

	public bool cursorOn;

	public bool _8Bit;

	public bool twoLines;

	private float blinkT;

	private bool blinked;

	private int cursorAddress;

	private int cursorDDAddress;

	private HD44780Element displayElm;

	private float current;

	private float val;

	private float prevVal;

	private float actualVal;

	private float maxCurrent;

	private float prevHigh;

	private float prevHighT;

	private float deltaT;

	private float contrastVal;

	private float prevContrastVal;

	public SaveData ReturnDisplaySaveData()
	{
		return default(SaveData);
	}

	public override void Awake()
	{
	}

	private void Start()
	{
	}

	public void PowerOn()
	{
	}

	public void PowerOff()
	{
	}

	public void DisplayOff()
	{
	}

	private void ResetDisplay()
	{
	}

	public void ClearDisplay()
	{
	}

	private void EmptyArray(char[] arr)
	{
	}

	public void ReturnHome()
	{
	}

	public void EntryMode(bool ID, bool S)
	{
	}

	public void DisplayControl(bool D, bool C, bool B)
	{
	}

	public void CursorDisplayShift(bool SC, bool RL)
	{
	}

	public void FunctionSet(bool DL, bool N, bool F)
	{
	}

	public void SetCGRAMAddress(int adr)
	{
	}

	public void SetDDRAMAddress(int adr)
	{
	}

	private void UpdateDisplay()
	{
	}

	private void Update()
	{
	}

	private void Blink()
	{
	}

	private void EndCharBlink()
	{
	}

	public void WriteData(int adr)
	{
	}

	private void UpdateView()
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void TickUpdate()
	{
	}
}
