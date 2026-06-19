public class RebreatherSceneSprout : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 4);
		Manager.effects.PlayPuff(PuffID.DirtFloorTilesDebris, base.transform.position);
	}
}
