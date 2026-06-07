using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyCrabbino : EnemyController
	{
		[SerializeField]
		protected PhaserSprite _pincerSpriteL;

		[SerializeField]
		protected PhaserSprite _pincerSpriteR;

		[SerializeField]
		protected SpriteAnimation _pincerLAnim;

		[SerializeField]
		protected SpriteAnimation _pincerRAnim;

		private Vector2 _leftPincerPos;

		private Vector2 _rightPincerPos;

		protected Sequence _fadeOutPincersTween;

		protected Vector2 LeftOffset;

		protected Vector2 RightOffset;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected virtual void SetupPincers()
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

		protected override void Die()
		{
		}

		protected virtual void UpdatePincerTransforms()
		{
		}

		private void FadeOutPincers()
		{
		}
	}
}
