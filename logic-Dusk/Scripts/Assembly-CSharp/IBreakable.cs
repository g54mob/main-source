public interface IBreakable
{
	BrokenStateEnum BrokenState { get; }

	string RepairId { get; }

	void ReduceQuality();

	void Break();

	bool Fix(out string fixMessage);

	void OverrideBrokenState(BrokenStateEnum state);
}
