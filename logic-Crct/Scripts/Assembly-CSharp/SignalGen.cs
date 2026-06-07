using Simulation;
using TMPro;
using UnityEngine;

public class SignalGen : GroundComponent
{
	[Header("Test Audio")]
	public AudioClip soundClip;

	public float[] soundClipData;

	[Header("Vars")]
	public int orientation;

	public Vector3[] orientations;

	public Transform bodyTransform;

	public float voltage;

	public float frequency;

	public bool on;

	[Header("Interaction")]
	public TextMeshProUGUI[] voltageTextMesh;

	public TextMeshProUGUI[] hzTextMesh;

	public Transform rocker;

	public Vector3[] rockerRotation;

	public Transform voltageKnob;

	public Transform FKnob;

	public Transform modeKnob;

	public int modeKnobPos;

	public float minVoltage;

	public float maxVoltage;

	public int minHz;

	public int maxHz;

	public float knobSensitivity;

	public float voltSensitivity;

	public float hzSensitivity;

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

	private Vector3 VknobRotation;

	private float startVoltage;

	private Vector3 FknobRotation;

	private float startFrequency;

	public Vector3[] modeKnobPositions;

	private int prevModeKnobPos;

	public float modeKnobMoveThreshold;

	private float t;

	public override void Awake()
	{
	}

	public void RockerClick()
	{
	}

	public void VKnobInitDrag()
	{
	}

	public void VKnobDrag()
	{
	}

	public void FKnobInitDrag()
	{
	}

	public void FKnobDrag()
	{
	}

	public void MKnobInitDrag()
	{
	}

	public void MKnobDrag()
	{
	}

	public void KnobEndDrag()
	{
	}

	private void InteractUpdate()
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
