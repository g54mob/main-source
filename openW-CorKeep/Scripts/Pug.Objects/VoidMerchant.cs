public class VoidMerchant : NPC
{
	public override void PlayInteractSound()
	{
		base.PlayInteractSound();
		AudioManager.Sfx(SfxTableID.voidMerchantInteractSfx, base.transform.position);
	}
}
