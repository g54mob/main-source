using UnityEngine;

public class SlimeBlob : EntityMonoBehaviour
{
	protected override void HandleInitialAnimationTrigger(int animID)
	{
		base.HandleInitialAnimationTrigger(animID);
		if (animID == -1878077465 && base.objectData.objectID == ObjectID.RoyalSlimeBlob)
		{
			Manager.effects.PlayPuff(PuffID.SlipperyPuff, base.transform.position, 30);
			AudioManager.Sfx(SfxID.slimeFootstep, base.transform.position, 1f, 0.9f, 0.1f);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		bool flag = (lastAnim == -601574123 || lastAnim == -281135240) && (animID == -601574123 || animID == -281135240);
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return !flag;
		}
		return false;
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.slimeAnticipation, base.transform.position, 0.8f, 1f, 0.1f);
	}

	private void AE_Jump()
	{
		AudioManager.Sfx(SfxID.jump2, base.transform.position, 0.8f, 1f, 0.1f);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		DeathEffect();
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		ObjectID objectID = base.objectData.objectID;
		if (Manager.prefs.season == Season.Christmas)
		{
			if (objectID == ObjectID.SlimeBlob || objectID == ObjectID.AggressiveSlimeBlob)
			{
				Manager.effects.PlayPuff(PuffID.SlimeBlobDeathSnow, position, 25);
			}
		}
		else
		{
			if (objectID == ObjectID.SlimeBlob)
			{
				Manager.effects.PlayPuff(PuffID.SlimeBlobDeathOrange, position, 25);
			}
			if (objectID == ObjectID.AggressiveSlimeBlob)
			{
				Manager.effects.PlayPuff(PuffID.SlimeBlobDeathRed, position, 25);
			}
		}
		if (objectID == ObjectID.RoyalSlimeBlob)
		{
			AudioManager.SfxFollowTransform(SfxID.TerrariaSlime_Death, base.transform, 0.8f, 1f, 0.1f);
		}
		else
		{
			AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		}
	}

	protected override void OnTakeDamage()
	{
		if (base.objectData.objectID == ObjectID.RoyalSlimeBlob)
		{
			if (hasFlashable)
			{
				flashable.FlashLinearNoCurve(Color.red);
			}
			TakeDamageEffect(Vector3.zero);
			AudioManager.Sfx(SfxID.TerrariaSlime_Hurt, base.transform.position, 1f, 1f, 0.1f);
		}
		else
		{
			base.OnTakeDamage();
		}
	}
}
