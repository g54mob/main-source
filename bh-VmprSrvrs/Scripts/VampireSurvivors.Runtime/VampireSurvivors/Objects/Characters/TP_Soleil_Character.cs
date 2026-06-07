using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters
{
	public class TP_Soleil_Character : TP_Character
	{
		private Weapon whip1;

		private Weapon whip2;

		private Weapon whip3;

		private Weapon hWhip1;

		private Weapon hWhip2;

		private Weapon hWhip3;

		private bool _canRetaliate;

		private float RetaliationDelay;

		public override void AfterFullInitialization()
		{
		}

		public override bool GetDamaged(float damageAmount)
		{
			return false;
		}

		public override void LevelUp()
		{
		}
	}
}
