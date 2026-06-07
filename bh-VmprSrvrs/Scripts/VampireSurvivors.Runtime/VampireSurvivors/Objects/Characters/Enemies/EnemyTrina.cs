using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyTrina : EnemyController
	{
		private int _activated;

		private Tween _onEnterTween;

		private float _legsAngle;

		private SpriteRenderer _wings;

		private SpriteRenderer _snakes;

		private SpriteRenderer _legs;

		private SpriteAnimation _wingsSpriteAnimation;

		private SpriteAnimation _snakesSpriteAnimation;

		private SpriteAnimation _legsSpriteAnimation;

		private const float LegsSpeed = 500f;

		protected override void Awake()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
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

		private void GenerateSpritesAndAnims()
		{
		}

		private void UpdateSprites()
		{
		}
	}
}
