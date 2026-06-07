using Unity.Mathematics;

namespace VampireSurvivors.Objects.Weapons
{
	public class Phaser2Weapon : PhaserWeapon
	{
		protected override void Setuppo()
		{
		}

		protected override float GetTimeUnit()
		{
			return 0f;
		}

		protected override float GetProjectilesAmount()
		{
			return 0f;
		}

		public override float2 PickRandomEnemyOnScreenRect()
		{
			return default(float2);
		}
	}
}
