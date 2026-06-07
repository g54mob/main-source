public class EssenceFactory : Processor
{
	private SimpleSoundAnimationEvent simpleSoundAnimationEvent;

	private ParticleSystemAnimationEvents particleSystemAnimationEvents;

	protected override void Awake()
	{
		base.Awake();
		simpleSoundAnimationEvent = GetComponent<SimpleSoundAnimationEvent>();
		particleSystemAnimationEvents = GetComponent<ParticleSystemAnimationEvents>();
	}

	protected override void StoreRecipe()
	{
		base.StoreRecipe();
		simpleSoundAnimationEvent.AnimationSimpleSoundEvent();
		particleSystemAnimationEvents.Emit(1);
	}
}
