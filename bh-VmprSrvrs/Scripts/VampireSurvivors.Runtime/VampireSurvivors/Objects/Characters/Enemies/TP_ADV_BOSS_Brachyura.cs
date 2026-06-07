using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class TP_ADV_BOSS_Brachyura : EnemyControllerBoss
	{
		[Header("Brachyura Boss")]
		[SerializeField]
		private PhaserSprite _pincerSpriteL;

		[SerializeField]
		private PhaserSprite _pincerSpriteR;

		[SerializeField]
		private SpriteAnimation _pincerLAnim;

		[SerializeField]
		private SpriteAnimation _pincerRAnim;

		private Vector2 _leftPincerPos;

		private Vector2 _rightPincerPos;

		private Sequence _fadeOutPincersTween;

		private readonly Vector2 _leftOffset;

		private readonly Vector2 _rightOffset;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}

		public override void SetFlipX(bool flip)
		{
		}

		public override void Disappear()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		private void UpdatePincerTransforms()
		{
		}

		private void FadeOutPincers()
		{
		}
	}
}
