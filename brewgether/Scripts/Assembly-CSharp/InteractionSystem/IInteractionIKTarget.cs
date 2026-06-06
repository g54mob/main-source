namespace InteractionSystem
{
	public interface IInteractionIKTarget
	{
		float IKReachDuration { get; }

		bool EnableIKReach { get; }
	}
}
