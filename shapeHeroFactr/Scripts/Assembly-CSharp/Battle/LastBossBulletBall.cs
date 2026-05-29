using System;
using UnityEngine;

namespace Battle
{
	public class LastBossBulletBall : BaseEnemy
	{
		[SerializeField]
		private LoopEffect energyBall;

		private LastBoss _parent;

		private BulletSetting _energyBullet;

		public void StartBullet(LastBoss parent, BulletSetting bullet, Func<int, int, Vector2> positionSet)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
