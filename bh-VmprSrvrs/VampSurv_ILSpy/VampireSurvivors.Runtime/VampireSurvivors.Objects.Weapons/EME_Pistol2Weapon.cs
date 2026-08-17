namespace VampireSurvivors.Objects.Weapons;

public class EME_Pistol2Weapon : EME_Pistol1Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	public EME_Pistol2Weapon()
	{
		base._timeSinceLastFalconFire = 3.4028235E+38f;
		((EME_Weapon)this)._002Ector();
	}
}
