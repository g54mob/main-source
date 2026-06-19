public class OldRebreather : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 5);
	}
}
