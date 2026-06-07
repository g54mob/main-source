public class GroundComponent : BaseComponent
{
	public override object[] ReturnSaveData()
	{
		return null;
	}

	public override void ProcessSaveData(object[] data)
	{
	}

	public override object[] VarData()
	{
		return null;
	}

	public override bool ValuesChanged(object[] data)
	{
		return false;
	}

	public override void ProcessVarData(object[] data)
	{
	}

	public override bool PositionValid()
	{
		return false;
	}

	public override void Clear()
	{
	}

	public override void FinishPlacement()
	{
	}
}
