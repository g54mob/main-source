using Simulation;
using UnityEngine;

public class TactileSwitch : BaseComponent
{
	public Transform[] pinRayTrs;

	public Simulation.TactileSwitch switchElm;

	[Header("Interaction")]
	public Transform button;

	public Vector3 buttonBasePos;

	public Vector3 buttonPressedPos;

	private TiePointID[] tempTiePointIDs;

	public override void InteractDown()
	{
	}

	public override void InteractUp()
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
