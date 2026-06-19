public class AmoebaBomb : Bomb
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		PlaySpriteObjectAnimation(-1878077465);
		AudioManager.Sfx(SfxTableID.amoebaBombSpawn, base.transform.position);
	}
}
