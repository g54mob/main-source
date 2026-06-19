using UnityEngine;

public class VoidBomb : Bomb
{
	public GameObject distortionObject;

	protected override void DisableSparkParticles()
	{
		if ((bool)sparks)
		{
			sparks.enabled = false;
		}
		distortionObject.SetActive(value: false);
	}

	protected override void EnableSparkParticles()
	{
		if ((bool)sparks)
		{
			sparks.enabled = true;
		}
		distortionObject.SetActive(value: true);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		DisableSparkParticles();
	}

	protected override void PlayTickEvent(int index)
	{
		switch (index)
		{
		default:
			Debug.LogError("Bomb is attempting to play an unknown or missing event.");
			break;
		case 0:
			DisableSparkParticles();
			AudioManager.SfxFollowTransform(SfxTableID.voidBombTick, base.transform);
			AudioManager.SfxFollowTransform(SfxTableID.voidBombFuse, base.transform);
			break;
		case 1:
			PlayWobbleEffect();
			break;
		case 2:
			PlayWobbleEffect();
			DisableSparkParticles();
			break;
		case 3:
			PlayWobbleEffect();
			EnableSparkParticles();
			break;
		case 4:
			Manager.effects.PlayPuff(PuffID.VoidPreExplosion, base.transform.position, 1);
			AudioManager.SfxFollowTransform(SfxTableID.voidBombPreExplode, base.transform);
			break;
		}
	}
}
