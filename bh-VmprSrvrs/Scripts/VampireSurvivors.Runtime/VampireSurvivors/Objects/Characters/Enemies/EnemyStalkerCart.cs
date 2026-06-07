using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStalkerCart : EnemyController
	{
		protected float2 _CartOffset;

		private bool _hasLostTreasure;

		private bool _done;

		private float _sineF;

		private Sequence _onSineTween;

		private GameObject _spritte;

		private PhaserSprite _frontSprite;

		private PhaserSprite _backSprite;

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
