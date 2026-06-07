using UnityEngine;

public class PinBasedMobileTool : ToolBase
{
	public int pId;

	protected readonly int compMask;

	protected readonly int defMask;

	protected Ray ray;

	protected RaycastHit hit;

	protected TiePoint curPoint;

	protected BaseComponent hitComp;

	public override void _IPC_BeginCreate()
	{
	}

	public override void BeginCreate()
	{
	}

	public override void CompleteCreate()
	{
	}

	public override void CancelCreation()
	{
	}

	public override void LoadEdit(BaseComponent comp)
	{
	}

	private void IPC_ApplyChanges()
	{
	}

	private void IPC_CancelEdit()
	{
	}

	public override void ApplyChanges()
	{
	}

	public override void CancelEdit()
	{
	}

	public override void Delete()
	{
	}

	public override void CreateFromSaveFile(params object[] args)
	{
	}

	public override void UndoDelete(params object[] args)
	{
	}

	public override void RedoCreate(params object[] args)
	{
	}

	public override void CreateFromVarData(params object[] args)
	{
	}

	public override void UndoValueChanges(params object[] args)
	{
	}

	public override void RedoValueChanges(params object[] args)
	{
	}

	public override void UpdateTransformValues()
	{
	}
}
