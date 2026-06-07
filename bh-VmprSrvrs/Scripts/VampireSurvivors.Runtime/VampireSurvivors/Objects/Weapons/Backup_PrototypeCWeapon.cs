using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons
{
	public class Backup_PrototypeCWeapon : FB_QuantisedAngleWeapon
	{
		private int PlanePoolAmount;

		private int ExplosionPerPlaneAmount;

		private List<Backup_PlaneData> _planeDatas;

		private Timer _planeStartingTimer;

		private PhaserSpline _spline;

		private float _maxPathWidth;

		private float _maxPathHeight;

		private BulletPool _explosionPool;

		private readonly List<float> CurveData;

		public override void Fire()
		{
		}

		public override float PAmount()
		{
			return 0f;
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private Backup_PlaneData nextPlane()
		{
			return null;
		}

		private void startPlanes(int planeAmount)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
