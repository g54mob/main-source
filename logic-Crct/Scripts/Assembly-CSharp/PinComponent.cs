using TMPro;
using UnityEngine;

public class PinComponent : BaseComponent
{
	public Transform[] pinRayTrs;

	public TextMeshPro codeText;

	protected TiePointID[] tempTiePointIDs { get; set; }

	private bool CheckNotCommonNode(TiePoint tp)
	{
		return false;
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
