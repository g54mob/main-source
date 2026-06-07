using UnityEngine;

public class LED : WireComponent
{
	[Header("Var")]
	public double forwardVoltage;

	public int colorId;

	public float wirePenetration;

	public float wireRadius;

	public double maxCurrent;

	public float fadeSpeed;

	public float maxLight;

	public float current;

	public float leakage;

	[Header("Renderering")]
	public WireRenderer anodeRend;

	public WireRenderer cathodeRend;

	public Renderer bodyRenderer;

	public Transform bodyTransform;

	public Light lighting;

	public AnimationCurve lumCurve;

	public float maxLighting;

	private MaterialPropertyBlock props;

	private float actualVal;

	private float val;

	private float prevVal;

	public float lightSpeed;

	private float deltaVal;

	private float prevHigh;

	private float prevHighT;

	private float deltaT;

	private double avgCurrent;

	private float smoothingFactor;

	public float SmoothRatio;

	private float currentEmissionPower { get; set; }

	public override void Awake()
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void GenerateWire(bool finish = false)
	{
	}

	public void Update()
	{
	}

	public override void TickUpdate()
	{
	}
}
