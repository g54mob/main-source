using UnityEngine;

public class BlunderBomb : Bomb
{
	public ParticleSystem fireParticles;

	protected override bool updateAnimOrientation => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		HandleAnimationTrigger(-601574123);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == 1490946511)
		{
			base.HandleAnimationTrigger(animID);
			AudioManager.SfxFollowTransform(SfxTableID.mediumBombExplode, base.transform, 0.5f, 0.9f);
			fireParticles.Play(withChildren: true);
		}
		else
		{
			base.HandleAnimationTrigger(animID);
		}
	}

	protected override void PlayTickEvent(int index)
	{
		switch (index)
		{
		default:
			Debug.LogError("Bomb is attempting to play an unknown or missing event.");
			break;
		case 0:
			EnableSparkParticles();
			if (!skipFuseSound)
			{
				AudioManager.SfxFollowTransform(SfxID.bombFuse, base.transform, 0.5f, 0.9f, 0.15f);
			}
			break;
		case 1:
			PlayWobbleEffect();
			break;
		case 2:
			PlayWobbleEffect();
			DisableSparkParticles();
			break;
		case 3:
			break;
		}
	}
}
