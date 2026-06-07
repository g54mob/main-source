using UnityEngine;

[SelectionBase]
public class Obj_CorruptedGrid : ACorruptedPowerGrid
{
	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnCorruptGridMoveStart(Vector3 targetPosition)
	{
	}

	protected override void OnCorruptGridMoveEnd()
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
