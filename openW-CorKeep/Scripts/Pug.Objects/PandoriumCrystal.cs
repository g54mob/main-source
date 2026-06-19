using UnityEngine;

public class PandoriumCrystal : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	public Transform SparkParticleSpawnLocation;

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 vector = new Vector3(0f, 3f, -3f);
		Manager.effects.ExploDisc(base.transform.position + vector + Vector3.up * 0.25f, 0.33f);
		Manager.effects.PlayPuff(PuffID.PandoriumDebris, particleSpawnLocation.position);
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == -689712656)
		{
			Manager.effects.PlayPuff(PuffID.PandoriumCrystalSpark, SparkParticleSpawnLocation.position, 3);
			AudioManager.Sfx(SfxTableID.pandoriumCrystalSpark, base.transform.position);
		}
		else
		{
			base.HandleAnimationTrigger(animID);
		}
	}
}
