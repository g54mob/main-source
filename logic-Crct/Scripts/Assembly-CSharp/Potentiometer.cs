using Simulation;
using TMPro;
using UnityEngine;

public class Potentiometer : BaseComponent
{
	public Transform[] pinRayTrs;

	public Simulation.Potentiometer potElm;

	public TextMeshPro rating;

	[Header("Interaction")]
	public Transform knob;

	public float knobSensitivity;

	public float posSensitivity;

	public float pos;

	public double maxOhms;

	private Vector3 baseTouchPosition;

	private Vector3 deltaTouchPosition;

	private object[] prevVals;

	public float baseKnobRotation;

	private Vector3 knobRotation;

	private float startPos;

	private TiePointID[] tempTiePointIDs { get; set; }

	public void SetRatingLabel()
	{
	}

	public void KnobInitDrag()
	{
	}

	public void KnobDrag()
	{
	}

	public void InteractUpdate()
	{
	}

	public void KnobEndDrag()
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
