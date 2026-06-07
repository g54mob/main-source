using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_RightFacing_CartRider : EnemyController
	{
		private PhaserSprite _frontSprite;

		private PhaserSprite _backSprite;

		protected float2 _CartOffset;

		private MultiTargetTween cartScaleTween;

		private SoundManager.SoundConfig sfxConfig;

		private Sprite _resetfrontSprite;

		private Sprite _resetbackSprite;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnRecycleEnemy()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		public override void Disappear()
		{
		}
	}
}
