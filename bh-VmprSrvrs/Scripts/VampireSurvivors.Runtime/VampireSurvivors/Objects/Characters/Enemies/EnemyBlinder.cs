using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBlinder : EnemyController
	{
		private bool _hasLostTreasure;

		private bool _done;

		private float _sineF;

		private Sequence _onSineTween;

		private GameObject _spritte;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public void MulSpeed(float factor)
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void SpawnSpritte()
		{
		}
	}
}
