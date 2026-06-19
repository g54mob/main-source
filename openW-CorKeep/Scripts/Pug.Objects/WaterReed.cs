public class WaterReed : EntityMonoBehaviour
{
	public void AE_Shake()
	{
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 4);
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		if (spriteObjects[0] != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObjects[0], 2f);
			WaterSim.AddImpulse(base.transform.position, 1f, 2f);
		}
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}
}
