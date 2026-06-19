using Aggro.Core;

public struct EvShiftLost : IEntityEvent, IEntityTyped
{
	public int shift;

	public EvShiftLost(int shift)
	{
		this.shift = shift;
	}
}
