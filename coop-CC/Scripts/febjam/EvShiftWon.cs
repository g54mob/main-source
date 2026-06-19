using Aggro.Core;

public struct EvShiftWon : IEntityEvent, IEntityTyped
{
	public int shift;

	public ContractScore score;

	public EvShiftWon(int shift, ContractScore score)
	{
		this.shift = shift;
		this.score = score;
	}
}
