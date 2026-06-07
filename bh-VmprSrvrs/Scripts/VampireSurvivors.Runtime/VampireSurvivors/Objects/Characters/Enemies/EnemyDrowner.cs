using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDrowner : EnemyController
	{
		private Stage _stage;

		private bool _hasLostTreasure;

		private bool _dismissed;

		private bool _invul;

		private bool _isFresh;

		private bool _done;

		private EnemyBulletW _bullet;

		private GameObject _spritte;

		private ParticleSystem _pfxEmitter;

		public bool _FromTrisection;

		public bool Dismissed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected override void FakeConstruct()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void Dismiss()
		{
		}

		public override void Disappear()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void SpawnBullet()
		{
		}

		private void SpawnSpritte()
		{
		}

		private void HandleDrownerUpdate()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
