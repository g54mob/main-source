using UnityEngine;

namespace Battle
{
	public class Brave : BaseUnit
	{
		private enum BraveAction
		{
			None = 0,
			Spawn = 1,
			PreAttackWait = 2,
			Attack = 3,
			PostAttackWait = 4,
			SubAttack = 5,
			Finish = 6
		}

		public CircleSpawn sallyPoint;

		public Target target;

		public KnockBack knockBack;

		public StatusEffect statusEffect;

		[Header("勇者固有")]
		[Label("剣の太さ")]
		[Tooltip("そのまま当たり判定の大きさになっている")]
		public float swordThickness;

		[Label("剣の長さ")]
		public float swordLength;

		[Label("波状攻撃距離")]
		public float waveAttackRadius;

		[Label("連続ヒット回数")]
		public int waveAttackCount;

		[Label("連続ヒットで1体に与える総ダメージ")]
		[Tooltip("連続ヒットででているのはダメージだけで、最後にまとめてダメージを与える。※剣のダメージは勇者のattackPoint値")]
		public int waveAttackTotalPower;

		[Label("ボスターゲット割合")]
		[Range(0f, 1f)]
		[Tooltip("高いほどボスを狙う")]
		public float bossTargetRatio;

		[Header("パーティクル関係")]
		public Transform excaliburRoot;

		public SpriteAnimation excaliburAnimeRoot;

		public Transform slashRoot;

		public Transform groundRoot;

		public BattleParticle excalibur;

		public BattleParticle slash;

		public BattleParticle ground;

		private const float SplitAngle = 45f;

		private float _maxAngleIdx;

		private BaseEnemy[] _targetEnemies;

		private double _nextActionTime;

		private BraveAction _nextAction;

		private BraveAction _nowAction;

		private Quaternion _changeRotation;

		private int _onceAttackPower;

		private int _maxWaveAttackCount;

		private void RegisterNextAction(double waitTime, BraveAction action)
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

		public void StartMotion()
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public void AttackEnemy(BaseEnemy enemy, int attackPower, bool displayDamage = true)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		private void PreBarrage()
		{
		}

		private void Barrage()
		{
		}

		private void PostBarrage()
		{
		}
	}
}
