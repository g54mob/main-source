namespace VampireSurvivors.Objects.Weapons;

public class EME_Axe2Weapon : EME_Axe1Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	protected override void OnStart()
	{
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
	}
}
