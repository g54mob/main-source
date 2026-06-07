namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Kick2Weapon : EME_Kick1Weapon
	{
		protected override int GlimmerTier => 0;

		protected override int ComboIndexFinal => 0;

		public override bool IsEvolved => false;

		public override int WallBounces => 0;
	}
}
