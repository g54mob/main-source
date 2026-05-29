using UnityEngine;

namespace Battle
{
	public class Bomb : BaseEnemy
	{
		private enum BombActionState
		{
			None = 0,
			Spawn = 1,
			Count = 2,
			Attack = 3,
			Warp = 4,
			Move = 6
		}

		[Header("minとmaxを入力して楕円状の出現範囲を設定")]
		public Vector2 minRadius;

		public Vector2 maxRadius;

		public Vector2 offset;

		[Label("ワープするHP(%), 高い順に登録")]
		public float[] warpHpPoint;

		[Label("ボムの溜め回数")]
		public int bombCount;

		public ParticleSystem bombEffect;

		[Label("停止半径")]
		[Tooltip("ボムがゲート付近で止まるために使う判定")]
		public float waitRadius;

		[SerializeField]
		private float warpTime;

		[Header("ラストで召喚されたとき用の設定")]
		[SerializeField]
		private AnimationCurve lastSummonKnockCurve;

		[SerializeField]
		private int lastSummonKnockMaxCount;

		private int warpIndex;

		private Vector3 _warpPosition;

		private int _bombCounter;

		private float _speedCache;

		private double _nextActionTime;

		private BombActionState _nextAction;

		private BombActionState _nowAction;

		private bool CheckGateDistance => false;

		private void RegisterNextAction(double waitTime, BombActionState action)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void Motion()
		{
		}

		private bool CheckHpAction()
		{
			return false;
		}

		private void Count()
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

		public override bool IsOverKill(bool plusStatus = false)
		{
			return false;
		}
	}
}
