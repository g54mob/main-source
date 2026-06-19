using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;

public class CrystalBigSnail : EntityMonoBehaviour
{
	private enum ShellState
	{
		NONE = 0,
		HEALTHY = 1,
		CRACKED = 2,
		DAMAGED = 3,
		BROKEN = 4,
		UNDEFINED = 5
	}

	public SpriteObject shellSpriteObject;

	public DataBlockRef<SpriteAssetSkin> crackedSkinRef;

	public DataBlockRef<SpriteAssetSkin> damagedSkinRef;

	public SFXTableIDField shellTakeDamageSfx;

	public SFXTableIDField takeDamageSfx;

	public ParticleSystem slimeTrail;

	private ShellState shellState;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public SpriteAssetSkin crackedSpriteAssetSkin => crackedSkinRef.Get();

	public SpriteAssetSkin damagedSpriteAssetSkin => damagedSkinRef.Get();

	public override void OnOccupied()
	{
		base.OnOccupied();
		shellState = ShellState.UNDEFINED;
		UpdateGraphicsFromObjectInfo(base.objectInfo);
		if ((bool)slimeTrail)
		{
			slimeTrail.Play(withChildren: true);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (shellSpriteObject.gameObject.activeInHierarchy && animID == -1533413595)
		{
			return;
		}
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
			if ((bool)slimeTrail)
			{
				slimeTrail.Stop(withChildren: true);
			}
		}
	}

	protected override void OnTakeDamage()
	{
		if (shellSpriteObject.gameObject.activeInHierarchy)
		{
			shellSpriteObject.PlayTransformAnimation(-1838420484);
		}
		else if (hasFlashable)
		{
			flashable.FlashLinearNoCurve(Color.red);
		}
		AudioManager.SfxFollowTransform(soundOptions.takeDamageSfx.value, base.transform);
		TakeDamageEffect(Vector3.zero);
		TryAddWaterImpulse();
	}

	protected override void TakeDamageEffect(Vector3 offset)
	{
		int num = 1;
		if (Random.value < 0.5f)
		{
			num = -1;
		}
		Manager.effects.PlayTempSprite(SpriteTempEffectID.HitEffect, center + new Vector3(0f, 2f, -2f) + offset, (float)num * 0.8f);
	}

	protected override void DeathEffect()
	{
		Vector3 vector = new Vector3(0f, 2f, -2f);
		Manager.effects.ExploDisc(center + vector);
	}

	protected override void UpdateSpriteObjectsOrientation()
	{
		base.UpdateSpriteObjectsOrientation();
		shellSpriteObject.SetVariant(m_spriteObjectOrientationHash);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (EntityUtility.HasComponentData<AnimationOrientationCD>(base.entity, base.world))
		{
			Direction facingDirection = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world).facingDirection;
			slimeTrail.transform.localPosition = ((facingDirection.id == Direction.forward) ? Vector3.zero : (-normalizedFacingVector * 0.8f));
		}
		HealthCD componentData = EntityUtility.GetComponentData<HealthCD>(base.entity, base.world);
		int num = (int)(EntityUtility.GetComponentData<EnemyActAsDestructibleCD>(base.entity, base.world).healthThreshold * (float)componentData.maxHealth);
		int num2 = componentData.maxHealth - num;
		float num3 = (float)(componentData.health - num) / (float)num2;
		ShellState shellState = (((double)num3 > 0.66) ? ShellState.HEALTHY : (((double)num3 > 0.33) ? ShellState.CRACKED : ((!(num3 > 0f)) ? ShellState.BROKEN : ShellState.DAMAGED)));
		if (this.shellState == shellState)
		{
			return;
		}
		bool flag = this.shellState == ShellState.UNDEFINED;
		this.shellState = shellState;
		switch (this.shellState)
		{
		case ShellState.HEALTHY:
			shellSpriteObject.skinRef = null;
			shellSpriteObject.ApplyVisualChange();
			break;
		case ShellState.CRACKED:
			shellSpriteObject.skinRef = crackedSpriteAssetSkin;
			shellSpriteObject.ApplyVisualChange();
			break;
		case ShellState.DAMAGED:
			shellSpriteObject.skinRef = damagedSpriteAssetSkin;
			shellSpriteObject.ApplyVisualChange();
			break;
		}
		if (!flag)
		{
			ShellState shellState2 = this.shellState;
			if ((uint)(shellState2 - 2) <= 2u)
			{
				PlayShellBreakEffect();
			}
		}
		soundOptions.takeDamageSfx = ((this.shellState != ShellState.BROKEN) ? shellTakeDamageSfx : takeDamageSfx);
		shellSpriteObject.gameObject.SetActive(this.shellState != ShellState.BROKEN);
	}

	private void PlayShellBreakEffect()
	{
		Vector3 vector = base.transform.position + new Vector3(0f, 1.25f, 0f);
		EntityUtility.PlayEffectEventClient(new EffectEventCD
		{
			effectID = EffectID.snailShellBreaking,
			entity = base.entity,
			position1 = vector
		});
	}
}
