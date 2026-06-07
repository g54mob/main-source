using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_DeathScythe : EnemyController
	{
		private float2 _targetScreenPoint;

		[Sync]
		public Vector2 BodyVelocity
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		private void PickRandomScreenPoint()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
