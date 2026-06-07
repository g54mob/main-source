using Simulation;
using UnityEngine;

public class SevenSegDisplay : BaseComponent
{
	public Transform[] pinRayTrs;

	public Renderer rend;

	public Material mat;

	public AnimationCurve lumCurve;

	public double maxCurrent;

	public double fVoltage;

	public bool anode;

	public float maxLight;

	public float lightSpeed;

	private string[] powerStrings;

	private float[] prevVals;

	private float[] actualVals;

	private float[] prevHigh;

	private float[] prevHighT;

	private float[] deltaT;

	private double[] avgCurrents;

	private float val;

	public float smoothingFactor;

	private SevenSegmentDisplayElement segElm { get; set; }

	private double[] currents { get; set; }

	private float currentEmissionPower { get; set; }

	private TiePointID[] tempTiePointIDs { get; set; }

	public override void TickUpdate()
	{
	}

	public void Update()
	{
	}

	public override void Awake()
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
