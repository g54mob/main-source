using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class CavelingBrute : EntityMonoBehaviour
{
	public ParticleSystem runParticles;

	private readonly int m_AttackEvent = SpriteAsset.StringToHash("attack");

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void Awake()
	{
		base.Awake();
		spriteObjects[0].onAnimationEvent += HandleAnimationEvent;
	}

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.MediumPurplePuff, base.transform.position, 80);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
		if (animID == 1433117748)
		{
			runParticles.Play(withChildren: true);
		}
		else
		{
			runParticles.Stop(withChildren: true);
		}
	}

	private void HandleAnimationEvent(int hash)
	{
		int sfxTableID = ((base.objectData.objectID == ObjectID.VoidCavelingBrute) ? SfxTableID.voidBruteTauntSfx : SfxTableID.cavelingBruteRoar);
		if (m_AttackEvent == hash)
		{
			Manager.audio.FadeOutAndStopSfx(sfxTableID);
			AE_AttackEffects();
		}
	}

	private void AE_AttackEffects()
	{
		AnimationOrientationCD componentData = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world);
		Vector3 position = base.transform.position;
		Vector3 position2 = position + componentData.facingDirection.vec3 * 1.5f;
		if (componentData.facingDirection.vec3.z > -0.5f)
		{
			position2 += componentData.facingDirection.vec3 * 1f;
		}
		if (componentData.facingDirection.vec3.z > 0.5f)
		{
			position2 += componentData.facingDirection.vec3 * 0.35f;
		}
		AudioManager.Sfx(SfxTableID.voidBruteAttackSfx, position);
		PuffID puff = ((Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2()).tileset == 1) ? PuffID.StoneImpact : PuffID.DirtImpact);
		Manager.effects.PlayPuff(puff, position2);
		WaterSim.AddImpulse(position2, 2f, 2f);
	}

	protected override void OnTakeDamage()
	{
		soundOptions.takeDamageSfx.value = ((base.objectData.objectID == ObjectID.VoidCavelingBrute) ? SfxTableID.voidBruteTakeDamageSfx : SfxTableID.cavelingBruteTakeDamage);
		base.OnTakeDamage();
	}

	protected override void OnDeath()
	{
		soundOptions.deathSfx.value = ((base.objectData.objectID == ObjectID.VoidCavelingBrute) ? SfxTableID.voidBruteDeathSfx : SfxTableID.cavelingBruteDeath);
		base.OnDeath();
	}
}
