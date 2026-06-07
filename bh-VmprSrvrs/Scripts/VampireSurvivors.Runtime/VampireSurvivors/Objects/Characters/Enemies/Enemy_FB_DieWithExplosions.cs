using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_FB_DieWithExplosions : EnemyController
	{
		[SerializeField]
		private float OnDeathScaleMultiplier;

		private bool hasExplosions;

		private float _defaultScale;

		private List<PhaserSprite> explosionSprites;

		private float offsetRadius;

		private List<Timer> explosionTimers;

		private int ExplosionsNumber;

		private Vector2 _SpriteOffset;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		private void PlayExplosions()
		{
		}
	}
}
