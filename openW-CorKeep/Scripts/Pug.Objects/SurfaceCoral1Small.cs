public class SurfaceCoral1Small : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		AudioManager.Sfx(SfxID.coralDestroy2, base.transform.position, 0.8f, 1.2f, 0.125f);
	}

	protected override void OnTakeDamage()
	{
		base.OnTakeDamage();
		AudioManager.Sfx(SfxID.coralDamage, base.transform.position, 0.8f, 1.2f, 0.125f);
	}
}
