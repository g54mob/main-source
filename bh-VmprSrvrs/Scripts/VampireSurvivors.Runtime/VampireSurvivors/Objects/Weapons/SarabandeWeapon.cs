namespace VampireSurvivors.Objects.Weapons
{
	public class SarabandeWeapon : Weapon
	{
		public bool UseJuliaAttack;

		public float _healAmount;

		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override void ResetFiringTimer()
		{
		}
	}
}
