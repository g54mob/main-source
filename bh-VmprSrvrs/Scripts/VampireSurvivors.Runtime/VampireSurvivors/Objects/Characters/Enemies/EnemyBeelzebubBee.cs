using System.Collections.Generic;
using Coherence.Toolkit;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyBeelzebubBee : EnemyController
	{
		private enum BeeState
		{
			Entering = 0,
			Circling = 1,
			Attacking = 2
		}

		private float2 _startPos;

		private int _groupIndex;

		private int _groupSize;

		private EnemyBeelzebub _parentBoss;

		private float _age;

		private BeeState _state;

		private float2 _attackVector;

		private bool _hasExplosions;

		private List<PhaserSprite> explosionSprites;

		private float offsetRadius;

		private List<Timer> explosionTimers;

		private int ExplosionsNumber;

		private bool _initialized;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		[Command]
		public void OnlineInit(int groupIndex, int groupSize, float circlingAngle, float attackDelay, CoherenceSync parentBoss)
		{
		}

		public void Init(int groupIndex, int groupSize, float circlingAngle, float attackDelay, EnemyBeelzebub parentBoss)
		{
		}

		private void Attack()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void Die()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupExplosions()
		{
		}

		private void PlayExplosions()
		{
		}
	}
}
