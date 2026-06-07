using Unity.Mathematics;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_QuantisedAngleWeapon : Weapon
	{
		protected float _firingAngleDegrees;

		public virtual float SecondsToRotateAim360 => 0f;

		public virtual float QuantisationStep => 0f;

		public override void InternalUpdate()
		{
		}

		public override float2 GetFiringVector()
		{
			return default(float2);
		}
	}
}
