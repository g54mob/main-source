using Pug.UnityExtensions;
using PugTilemap;

public class Critter : EntityMonoBehaviour
{
	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override void OnDeath()
	{
		bool flag = !Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.pit);
		if (Manager.prefs.squashBugs && flag)
		{
			Squash();
		}
	}

	protected virtual void Squash()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		Manager.effects.PlayPuff(PuffID.SlimeFootstep, particleOptions.particleSpawnLocations[0].position);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepSlime, particleOptions.particleSpawnLocations[0].position, 0.4f, 0.5f);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.SmallSlimeSplat, particleOptions.particleSpawnLocations[0].position, 1f, 1.5f);
	}
}
