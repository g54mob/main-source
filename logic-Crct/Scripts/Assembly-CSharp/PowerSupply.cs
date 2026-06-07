using Simulation;
using TMPro;
using UnityEngine;

public class PowerSupply : GroundComponent
{
	[Header("Vars")]
	public int orientation;

	public Vector3[] orientations;

	public Transform bodyTransform;

	public float dcVoltage;

	public bool on;

	[Header("Interaction")]
	public TextMeshProUGUI[] voltageTextMesh;

	public TextMeshProUGUI[] currentTextMesh;

	public Transform rocker;

	public Vector3[] rockerRotation;

	public Transform knob;

	public float minVoltage;

	public float maxVoltage;

	public float knobSensitivity;

	public float voltSensitivity;

	[Header("Connections")]
	public bool isConnected;

	public PhysicalWire[] wires;

	public VoltageInput voltageInput;

	public CircuitModel vInput;

	public CircuitModel ground;

	private Vector3 baseTouchPosition;

	private Vector3 deltaTouchPosition;

	private object[] prevVals;

	public float baseKnobRotation;

	private Vector3 knobRotation;

	private float startVoltage;

	private float t;

	public override void Awake()
	{
	}

	public void RockerClick()
	{
	}

	public void KnobInitDrag()
	{
	}

	public void KnobDrag()
	{
	}

	public void KnobEndDrag()
	{
	}

	private void InteractUpdate()
	{
	}

	private void Update()
	{
	}

	public void CompleteConnect()
	{
	}

	public override void ParentCalledUpdate(params object[] args)
	{
	}

	public override void FinishPlacement()
	{
	}

	public override void AttachToSim()
	{
	}

	public override void DetachFromSim()
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
}
