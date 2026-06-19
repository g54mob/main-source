namespace TMPEffects.Components.Animator
{
	public interface IAnimatorTimingsProvider
	{
		float DeltaTime { get; }

		float PassedTime { get; }
	}
}
