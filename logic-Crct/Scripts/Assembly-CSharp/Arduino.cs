using Simulation;
using UnityEngine;

public class Arduino : BaseComponent
{
	public Transform[] pinRayTrs;

	[Header("Board LEDS")]
	public Renderer pwrLED;

	public Renderer txLED;

	public Renderer rxLED;

	public Renderer lLED;

	public Color pwrLEDCol;

	public Color txLEDCol;

	public Color rxLEDCol;

	public Color lLEDCol;

	private Material pwrLEDMat;

	private Material txLEDMat;

	private Material rxLEDMat;

	private Material lLEDMat;

	public ArduinoElm arduinoElm;

	public string arduinoCode;

	[Header("Interaction")]
	public Transform button;

	public Vector3 buttonBasePos;

	public Vector3 buttonPressedPos;

	private TiePointID[] tempTiePointIDs { get; set; }

	public override void InteractDown()
	{
	}

	public override void InteractUp()
	{
	}

	private void Update()
	{
	}

	public override void Awake()
	{
	}

	private void SetLED(Material mat, Color col, bool on)
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void BeginMove()
	{
	}

	public override void CompleteMove()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void ParentCalledUpdate(params object[] args)
	{
	}

	public override bool PositionValid(BaseComponent c)
	{
		return false;
	}
}
