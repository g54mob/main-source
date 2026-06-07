using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class EME_Katana2Weapon : EME_Katana1Weapon
	{
		protected override int GlimmerTier => 0;

		protected override int ComboIndexFinal => 0;

		public void OnEnteredScatteredPetalStage(ScatteredPetalsStage scatteredPetalsStage)
		{
		}
	}
}
