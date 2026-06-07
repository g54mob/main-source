namespace VampireSurvivors.Objects.Weapons
{
	public class SongWeapon : Weapon
	{
		public override float PAmount()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		public override float SecondaryPAmount()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}
	}
}
