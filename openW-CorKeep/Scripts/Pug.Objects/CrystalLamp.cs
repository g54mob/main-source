public class CrystalLamp : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 3);
		Manager.effects.PlayPuff(PuffID.FireFloaters, particleOptions.particleSpawnLocations[0].position, 5);
		Manager.effects.PlayPuff(PuffID.SparksMachine, particleOptions.particleSpawnLocations[0].position, 2);
	}
}
