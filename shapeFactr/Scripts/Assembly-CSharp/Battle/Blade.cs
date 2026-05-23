using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Blade : BaseEnemy
	{
		private enum BladeActionState
		{
			None = 0,
			Spawn = 1,
			Move = 2,
			Wait = 3,
			PreAttackWait = 4,
			Attack = 5,
			Back = 6
		}

		[SerializeField]
		private ActionState<BladeActionState> state;

		[Header("固有設定")]
		private float _speedCache;

		[Label("止まる距離(半径)")]
		public float waitRadius;

		[Label("攻撃前待機時間")]
		public float attackWaitTime;

		[Header("子の設定")]
		[Label("子Prefab")]
		[SerializeField]
		private BladeChild childPrefab;

		[SerializeField]
		private Transform innerRotationGroup;

		[SerializeField]
		private Transform outerRotationGroup;

		[SerializeField]
		private float warpTime;

		[Label("内側個数")]
		public int innerValue;

		[Label("内側半径")]
		public float innerRadius;

		[Label("内側回転速度")]
		[Tooltip("n秒/1回転")]
		public float innerRotationSpeed;

		[Label("外側個数")]
		public int outerValue;

		[Label("外側半径")]
		public float outerRadius;

		[Label("外側回転速度")]
		[Tooltip("n秒/1回転")]
		public float outerRotationSpeed;

		[Label("ブレード発射間隔")]
		public float shootInterval;

		[Label("ブレードステータス")]
		[SerializeField]
		private List<ChildLevelStatus> childLevelStatus;

		[Header("minとmaxを入力して楕円状の出現範囲を設定")]
		public Vector2 minRadius;

		public Vector2 maxRadius;

		public Vector2 offset;

		private int minChildCount;

		private BladeChild[] _children;

		private float _iRotationSpeed;

		private float _oRotationSpeed;

		private Vector3 _initPos;

		private EnemyBaseInfo _childLevelStatus;

		private bool CheckGateDistance => false;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void Motion()
		{
		}

		private void Move()
		{
		}

		private void PreAttackWait()
		{
		}

		private void Attack()
		{
		}

		private void Back()
		{
		}

		private void WarpEnd()
		{
		}

		private Vector3 GetWarpPosition()
		{
			return default(Vector3);
		}

		private void RotationAroundBlade(float deltaTime)
		{
		}

		private void CreateEdges()
		{
		}

		private Vector3 PositionSetting(float radius, float radian)
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
