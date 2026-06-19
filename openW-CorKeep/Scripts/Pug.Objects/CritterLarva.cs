public class CritterLarva : Critter
{
	protected override void Squash()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
		Manager.effects.PlayPuff(PuffID.PoisonFootstep, particleOptions.particleSpawnLocations[0].position);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.FootstepPoison, particleOptions.particleSpawnLocations[0].position, 0.4f, 0.5f);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.SmallLarvaSplat, particleOptions.particleSpawnLocations[0].position, 1f, 1.5f);
	}
}
