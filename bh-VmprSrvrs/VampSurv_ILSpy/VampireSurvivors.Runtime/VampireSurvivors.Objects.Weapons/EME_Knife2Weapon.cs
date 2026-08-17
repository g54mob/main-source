namespace VampireSurvivors.Objects.Weapons;

public class EME_Knife2Weapon : EME_Knife1Weapon
{
	protected override int ComboIndexFinal => base.ComboIndex2;

	protected override int GlimmerTier => 2;

	protected override bool IsEvolved => true;
}
