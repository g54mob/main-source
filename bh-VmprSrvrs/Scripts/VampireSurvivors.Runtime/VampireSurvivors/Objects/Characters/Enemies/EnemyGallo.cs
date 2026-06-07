using System.Collections.Generic;
using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyGallo : EnemyController
	{
		[SerializeField]
		private GameObject _LancetPierceEffectPrefab;

		[SerializeField]
		private GameObject _EnemyLancetPrefab;

		private DiContainer _diContainer;

		private ObjectPool _effectPool;

		private ObjectPool _enemyLancetPool;

		private int _keepMoving;

		private new const float Distance = 50000f;

		private float _fireTime;

		private float _fireDelay;

		private float _previousDistance;

		private int _ticks;

		private List<float> _angles;

		private List<Vector2> _targets;

		private List<EnemyLancet> _enemyLancetProjectiles;

		private EnemyType _bulletType;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private Tween _lancetTween;

		protected override void FakeConstruct()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void OnLancetDied(EnemyLancet enemyLancet)
		{
		}

		private void InitLancet()
		{
		}

		private void GenerateEffectPool()
		{
		}

		private void GenerateEnemyLancetPool()
		{
		}

		protected override void Die()
		{
		}

		private void Fire()
		{
		}

		private void FireOneLancet(int index, float angle, Vector2 targetPos)
		{
		}

		protected void SetLancetPoolItemsDuration(float duration)
		{
		}
	}
}
