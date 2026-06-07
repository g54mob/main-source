namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Confodere3_Weapon : TP_Confodere1_Weapon
	{
		protected override bool bigProjectileEnabled => false;

		protected override bool specialProjectileEnabled => false;

		public override float PInterval()
		{
			return 0f;
		}
	}
}
