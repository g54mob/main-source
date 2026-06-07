using Simulation;
using UnityEngine;

public class SlideSwitch : BaseComponent
{
	public Transform[] pinRayTrs;

	public Simulation.SlideSwitch switchElm;

	[Header("Interaction")]
	public Transform switchTr;

	public Vector3[] switchPositions;

	private int pos;

	private TiePointID[] tempTiePointIDs { get; set; }

	public override void InteractDown()
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
