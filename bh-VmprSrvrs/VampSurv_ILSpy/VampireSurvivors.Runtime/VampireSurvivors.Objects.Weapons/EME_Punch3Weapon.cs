using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Punch3Weapon : EME_Punch2Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex3;

	protected override int GlimmerTier => 3;

	public EME_Punch3Weapon()
	{
		((EME_Punch1Weapon)this)._screenPerimeter = 1f;
		((EME_Punch1Weapon)this)._guayimExecutionDelayDefault = 5000f;
		((EME_Punch1Weapon)this)._guayimExecutionDelay = 5000f;
		((EME_Punch1Weapon)this)._playSoundsDuringUpdate = true;
		HitSound = SfxType.Sfx_eme_Punch1;
		((EME_Punch1Weapon)this)._guayimFiringDelay = 50f;
		((EME_Weapon)this)._002Ector();
	}
}
