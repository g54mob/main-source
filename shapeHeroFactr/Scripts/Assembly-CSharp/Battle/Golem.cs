using UnityEngine;

namespace Battle
{
	public class Golem : BaseEnemy
	{
		private enum GolemActionState
		{
			None = 0,
			Spawn = 1,
			Wait = 2,
			Attack = 3,
			Warp = 4,
			WarpEnd = 5,
			Move = 6,
			Damage = 7
		}

		[SerializeField]
		private ActionState<GolemActionState> state;

		[SerializeField]
		[Label("待機移行範囲")]
		private float waitRadius;

		[SerializeField]
		[Label("ワープ時出現範囲")]
		private Vector2 warpRadius;

		[Header("攻撃関連")]
		[SerializeField]
		private EffectInterval attackInterval;

		[SerializeField]
		[Label("ダメージディレイ")]
		[Tooltip("攻撃アニメーションが始まってから拠点にダメージが入るまでの時間")]
		private float attackDamageDelay;

		[SerializeField]
		[Label("有効： 最大攻撃回数")]
		private bool enabledMaxAttackCount;

		[SerializeField]
		[Label("最大攻撃回数")]
		private int maxAttackCount;

		[Header("Body関連")]
		[SerializeField]
		[Label("サイズ増加割合")]
		private float sizeUpIncrease;

		[SerializeField]
		[Label("サイズ上限")]
		private float maxSize;

		[SerializeField]
		private float warpTime;

		public HitEffect attackEffect;

		private float _speedCache;

		private int _remainAttackCount;

		private float _initSize;

		private int _warpCount;

		private float _postAttackTime;

		private HitEffect _hitEffect;

		private bool CheckGateDistance => false;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public void Motion(double deltatime)
		{
		}

		private void Wait()
		{
		}

		private void Move()
		{
		}

		private void Attack()
		{
		}

		private void Damage()
		{
		}

		private void Warp()
		{
		}

		private void WarpEnd()
		{
		}

		protected override void AttackTown()
		{
		}

		public Vector3 GetWarpPosition()
		{
			return default(Vector3);
		}

		public override void DestroyObj()
		{
		}
	}
}
