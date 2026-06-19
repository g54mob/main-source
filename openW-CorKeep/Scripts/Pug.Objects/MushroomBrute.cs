using UnityEngine;

public class MushroomBrute : EntityMonoBehaviour
{
	public ParticleEffectSpawner runParticles;

	private bool vulnerable;

	private Color invulnerableflashColor = Color.yellow;

	private Vector3 invulnerableParticlePos;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimOrientation => true;

	protected override void Awake()
	{
		base.Awake();
		invulnerableflashColor.a *= 0.25f;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		runParticles.enabled = false;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		switch (animID)
		{
		case -1634423587:
			runParticles.enabled = false;
			break;
		case 1433117748:
			runParticles.enabled = true;
			break;
		case -1997722203:
			runParticles.enabled = false;
			Manager.camera.ShakeCameraNow(0.3f, 0.3f, 0.3f);
			break;
		case -601574123:
		case -281135240:
		case -210448114:
		case 1352515405:
			runParticles.enabled = false;
			break;
		}
		base.HandleAnimationTrigger(animID);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		vulnerable = (float)EntityUtility.GetComponentData<DamageReductionCD>(base.entity, base.world).maxDamagePerHit <= 0f;
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if ((animID == -1997722203 && lastAnim == -1997722203) || (lastAnim == -1997722203 && animID == -601574123))
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	protected override void OnTakeDamage()
	{
		if (!vulnerable)
		{
			invulnerableParticlePos = base.transform.position;
			if (particleOptions.particleSpawnLocations.Capacity > 0)
			{
				invulnerableParticlePos = particleOptions.particleSpawnLocations[0].position;
			}
			flashable.FlashLinearNoCurve(invulnerableflashColor);
			AudioManager.Sfx(SfxID.clunk, center, 1f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			Manager.effects.PlayPuff(PuffID.Parry, invulnerableParticlePos, 1);
		}
		else
		{
			base.OnTakeDamage();
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		runParticles.enabled = false;
	}
}
