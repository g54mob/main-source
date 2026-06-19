public class CritterShrew : Critter
{
	protected override void Squash()
	{
		AudioManager.SfxFollowTransform(SfxTableID.squeakyToy, base.transform, 0.5f);
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, particleOptions.particleSpawnLocations[0].position, 3);
	}
}
