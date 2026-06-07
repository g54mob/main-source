using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class AbsetzenInstance
	{
		private readonly List<EME_GreatswordProjectile_Absetzen> _swordProjectiles;

		private readonly BulletPool _swordBulletPool;

		private readonly BulletPool _beamBulletPool;

		private readonly EME_Weapon _parentWeapon;

		private readonly Transform _targetTransform;

		private Timer _glimmerShotTimer;

		private int _amount;

		private int _amountSpawned;

		private readonly float _repeatInterval;

		private bool _beamFired;

		public bool BeamFired => false;

		public AbsetzenInstance(EME_Weapon parentWeapon, Transform targetTransform, BulletPool swordBulletPool, BulletPool beamBulletPool, float repeatInterval)
		{
		}

		public void FireProjectiles(int amount, float2 pos, Transform target)
		{
		}

		public void InternalUpdate()
		{
		}

		private void FireAbsetzenBeam(float2 position, int index)
		{
		}

		public void Cleanup()
		{
		}
	}
}
