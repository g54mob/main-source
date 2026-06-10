namespace NSMedieval.Goap
{
	public interface IHaulAgent
	{
		HaulTargetingMode HaulTargetMode { get; }

		bool ShouldFireHaulEndEffector { get; }

		string HaulEndEffectorName { get; }

		float HaulEndEffectorDuration { get; }
	}
}
