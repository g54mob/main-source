using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TongueProjectile : Projectile
	{
		[SerializeField]
		protected TrailRenderer _trail;

		[SerializeField]
		protected float _attackSpeed;

		protected Sprite _trailSprite;

		protected float _AttackLerp;

		private float _minAngleRotDeg;

		private float _maxAngleRotDeg;

		private float _angleRng;

		protected bool _retracting;

		protected float2 _lastTargetPoint;

		protected bool _hasHitAnObject;

		protected EnemyController _targetEnemy;

		protected SfxType[] s_sounds;

		protected override void Awake()
		{
		}

		protected virtual void InitTrailSprite()
		{
		}

		protected void SetupTrail()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetTargetEnemy(EnemyController enemy)
		{
		}

		private void InitTrail()
		{
		}

		protected float2 GetMouthPosition()
		{
			return default(float2);
		}

		protected virtual Vector3[] GetCurve(float2 startPoint, float2 currentPoint)
		{
			return null;
		}

		protected void UpdateTrail()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected void PlayLickSound()
		{
		}

		public override void Despawn()
		{
		}
	}
}
