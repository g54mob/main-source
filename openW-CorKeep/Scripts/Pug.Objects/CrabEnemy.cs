using Pug.Sprite;

public class CrabEnemy : EntityMonoBehaviour
{
	public ParticleEffectSpawner bubbles;

	private readonly int m_startParticles = SpriteAsset.StringToHash("startParticles");

	private readonly int m_stopParticles = SpriteAsset.StringToHash("stopParticles");

	protected override bool updateAnimOrientation => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		bubbles.enabled = false;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_startParticles == hash)
		{
			bubbles.enabled = true;
		}
		else if (m_stopParticles == hash)
		{
			bubbles.enabled = false;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		bubbles.enabled = false;
	}
}
