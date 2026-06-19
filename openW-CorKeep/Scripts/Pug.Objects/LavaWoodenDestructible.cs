using UnityEngine;

public class LavaWoodenDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
			Vector3 vector = new Vector3(0f, 3f, -3f);
			Manager.effects.ExploDisc(variationsParticleSpawnLocation.position + vector + Vector3.up * 0.5f, 0.33f);
			AudioManager.Sfx(SfxID.wall, base.transform.position, 0.4f, 1f, 0.1f);
			AudioManager.Sfx(SfxID.breakCrate, base.transform.position, 1f, 0.7f, 0.1f);
			switch (base.objectData.variation)
			{
			case 0:
				Manager.effects.PlayPuff(PuffID.BlackWoodDebris, variationsParticleSpawnLocation.position);
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, variationsParticleSpawnLocation.position);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position);
				break;
			case 1:
				Manager.effects.PlayPuff(PuffID.BlackWoodDebris, variationsParticleSpawnLocation.position, 20);
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, variationsParticleSpawnLocation.position, 15);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 15);
				break;
			case 2:
				Manager.effects.PlayPuff(PuffID.BlackWoodDebris, variationsParticleSpawnLocation.position, 30);
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, variationsParticleSpawnLocation.position, 25);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 20);
				break;
			case 3:
				Manager.effects.PlayPuff(PuffID.BlackWoodDebris, variationsParticleSpawnLocation.position, 20);
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, variationsParticleSpawnLocation.position, 15);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 15);
				break;
			default:
				Manager.effects.PlayPuff(PuffID.BlackWoodDebris, variationsParticleSpawnLocation.position);
				Manager.effects.PlayPuff(PuffID.SmallBlackPuff, variationsParticleSpawnLocation.position);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position);
				break;
			}
		}
	}
}
