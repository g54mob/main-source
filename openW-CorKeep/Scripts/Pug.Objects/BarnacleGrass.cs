using UnityEngine;

public class BarnacleGrass : EntityMonoBehaviour
{
	public Transform particleSpawnLocation;

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		if (spriteObjects[0] != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObjects[0]);
		}
		AudioManager.Sfx(SfxID.barnacleGrassInteract, base.transform.position, 0.2f, 1.15f, 0.125f);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 vector = new Vector3(0f, 3f, -3f);
		Manager.effects.ExploDisc(base.transform.position + vector + Vector3.up * 0.25f, 0.33f);
		Manager.effects.PlayPuff(PuffID.BarnacleGrassDebris, particleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.SnowItemDust, particleSpawnLocation.position, 15);
	}
}
