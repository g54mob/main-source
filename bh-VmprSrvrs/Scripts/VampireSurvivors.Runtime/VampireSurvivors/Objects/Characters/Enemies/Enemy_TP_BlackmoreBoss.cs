using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_TP_BlackmoreBoss : Enemy_TP_GateBoss
	{
		[Header("Blackmore Boss")]
		[SerializeField]
		private PhaserSprite _shadowSprite;

		[SerializeField]
		private SpriteAnimation _shadowAnim;

		private Vector2 _shadowPos;

		private Sequence _fadeOutShadowTween;

		private readonly Vector2 _shadowOffset;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
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

		private void FadeOutShadow()
		{
		}
	}
}
