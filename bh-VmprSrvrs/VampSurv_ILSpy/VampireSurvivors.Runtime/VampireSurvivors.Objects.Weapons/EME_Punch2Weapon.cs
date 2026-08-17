using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Punch2Weapon : EME_Punch1Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	public EME_Punch2Weapon()
	{
		base._screenPerimeter = 1f;
		base._guayimExecutionDelayDefault = 5000f;
		base._guayimExecutionDelay = 5000f;
		base._playSoundsDuringUpdate = true;
		HitSound = SfxType.Sfx_eme_Punch1;
		base._guayimFiringDelay = 50f;
		((EME_Weapon)this)._002Ector();
	}
}
