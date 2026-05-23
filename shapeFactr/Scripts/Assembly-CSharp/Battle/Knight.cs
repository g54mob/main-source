using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Knight : BaseUnit
	{
		private enum KnightState
		{
			None = 0,
			Spawn = 1,
			Search = 2,
			PreAttack = 3,
			Attack = 4,
			PostAttack = 5,
			Barrage = 6,
			Wait = 7
		}

		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public StatusEffect status;

		[Header("騎士固有")]
		[Label("道中ダメージ")]
		[SerializeField]
		private int loadDamage;

		[Label("道中ヒット最大回数")]
		[SerializeField]
		private int hitCount;

		[Label("待機時間")]
		[SerializeField]
		private double waitTime;

		public LoopEffect loopEffect;

		public HitEffect kiraEffect;

		public HitEffect barrageHitEffect;

		[Label("1度の連撃回数")]
		[SerializeField]
		private float barrageCount;

		private double _nextActionTime;

		private KnightState _nextAction;

		private KnightState _nowAction;

		private float _dirDegree;

		private int? _prevTargetId;

		private float _barrageInterval;

		private float _barrageCounter;

		private int _barrageAttackPower;

		private HashSet<int> _damagedEnemies;

		private void RegisterNextAction(double waitTime, KnightState action)
		{
		}

		protected override void InitAdditionalParameter(BaseUnit unit)
		{
		}

		public override void Init()
		{
		}

		public override Vector2 SallyPositionSetting()
		{
			return default(Vector2);
		}

		public override void UpdateUnit(double deltatime)
		{
		}

		public void Action()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		private void Search()
		{
		}

		private void Barrage(BaseEnemy enemy)
		{
		}

		private void PostBarrage(BaseEnemy enemy)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override int GetTotalPower()
		{
			return 0;
		}
	}
}
