using System;
using System.Collections.Generic;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class GarbageChuteWeapon : Weapon
	{
		private float _chuteDefaultWidth;

		private float _chuteMaxWidth;

		[NonSerialized]
		public float ChuteArea;

		[NonSerialized]
		public float ChuteWidth;

		[NonSerialized]
		public List<GarbageChuteMovement> _garbageChutes;

		private List<float> _projectileCount;

		private List<Timer> _projectileTimer;

		public override void CheckArcanas()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void startFiringProjectile(int chuteIndex)
		{
		}

		private void startNewChute()
		{
		}

		private int freeChuteIndex()
		{
			return 0;
		}

		public void ProjectileComplete(int chuteIndex)
		{
		}

		private void LateUpdate()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
