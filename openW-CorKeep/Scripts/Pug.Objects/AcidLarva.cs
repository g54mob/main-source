using Pug.Sprite;
using UnityEngine;

public class AcidLarva : EntityMonoBehaviour
{
	public ParticleSystem digParticles;

	public ParticleSystem trailParticles;

	private PoolableAudioSource digAudioLoop;

	private readonly int m_BurrowEvent = SpriteAsset.StringToHash("burrow");

	private readonly int m_UnburrowEvent = SpriteAsset.StringToHash("unburrow");

	private readonly int m_DigSoundEvent = SpriteAsset.StringToHash("digSound");

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		bool flag = (lastAnim == -1533413595 || lastAnim == 618391746) && (animID == -601574123 || animID == -1442707745);
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return !flag;
		}
		return false;
	}

	private void HandleAnimationEvent(int hash)
	{
		if (m_BurrowEvent == hash)
		{
			if ((bool)digParticles)
			{
				digParticles.Play(withChildren: true);
			}
			if ((bool)trailParticles)
			{
				trailParticles.Play(withChildren: true);
			}
			if ((bool)digAudioLoop)
			{
				digAudioLoop.StopNow(antiPop: false);
			}
			digAudioLoop = AudioManager.SfxFollowTransform(SfxID.EarthquakeLoop, base.transform, 0.12f, 3f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true);
		}
		if (m_UnburrowEvent == hash)
		{
			if ((bool)digParticles)
			{
				digParticles.Stop(withChildren: true);
			}
			if ((bool)trailParticles)
			{
				trailParticles.Stop(withChildren: true);
			}
			if ((bool)digAudioLoop)
			{
				digAudioLoop.FadeOutAndStop(0.25f);
				digAudioLoop = null;
			}
		}
		if (m_DigSoundEvent == hash)
		{
			AudioManager.SfxFollowTransform(SfxID.snowfootstep, base.transform, 0.2f, 0.5f, 0.1f);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.AcidPuff, base.transform.position, 30);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.AcidSplat, base.transform.position + new Vector3(0f, 0.3125f, -0.1875f));
		if ((bool)digParticles)
		{
			digParticles.Stop(withChildren: true);
		}
		if ((bool)trailParticles)
		{
			trailParticles.Stop(withChildren: true);
		}
		if (hasShadow)
		{
			shadow.SetActive(value: false);
		}
		if ((bool)digAudioLoop)
		{
			digAudioLoop.StopNow();
			digAudioLoop = null;
		}
	}
}
