namespace NSMedieval.Goap
{
	public interface IRopableAgent
	{
		bool RopeTo(IGoapTargetable target, bool matchSpeed = false);

		IGoapTargetable RopedTo();
	}
}
