using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SummonSpirit2_Weapon : TP_SummonSpirit_Weapon
	{
		private float _deltaTime;

		private const float Percentage = 0.0625f;

		private const float Radius = 1f;

		private const float SpeedModifier = 25f;

		protected override float2 BulletSpawnPos => default(float2);

		protected override SpriteTextureData PortalSprite => default(SpriteTextureData);

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void DoTweens()
		{
		}

		private void UpdatePortalPosition()
		{
		}

		private void UpdatePortalRotation()
		{
		}

		protected override void SetPortalPosition()
		{
		}

		protected override void DoPortalTween()
		{
		}

		public override void CheckArcanas()
		{
		}
	}
}
