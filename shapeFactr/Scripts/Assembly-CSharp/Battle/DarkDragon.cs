using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class DarkDragon : BaseEnemy
	{
		[Serializable]
		private class MeteorSetting
		{
			[Label("攻撃倍率")]
			[Tooltip("townAttack * n")]
			public float increaseTownAttack;

			[Label("ヒーローダメージ量")]
			[Tooltip("一度に与えるヒーローへのダメージ量")]
			public int heroAttack;

			public LoopEffect laser;

			public Transform laserHit;
		}

		private enum DragonActionState
		{
			None = 0,
			Spawn = 1,
			Stand = 2,
			Move = 3,
			Charge = 4,
			Attack = 5,
			PreRoar = 6,
			Roar = 7
		}

		[CompilerGenerated]
		private sealed class _003CMeteoRoar_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DarkDragon _003C_003E4__this;

			private float _003CstepRadius_003E5__2;

			private int _003Ci_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CMeteoRoar_003Ed__51(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Dragon固有")]
		[Header("移動設定")]
		[Label("進む間隔(s)")]
		[Tooltip("s秒ごとに一歩ずつ進む")]
		public double moveInterval;

		[Label("攻撃移行距離")]
		public float attackDistance;

		[Header("攻撃設定")]
		[Label("攻撃チャージ時間")]
		public double chargeTime;

		[Label("レーザー時間")]
		public double lazerTime;

		[Label("有効：反動")]
		public bool enableReaction;

		[Label("ダメージ間隔")]
		[Range(0f, 1f)]
		public float damageInterval;

		[SerializeField]
		[Tooltip("柱の数で処理する用")]
		private List<MeteorSetting> meteorSetting;

		[Label("レーザー判定太さ")]
		public float laserTickness;

		[Label("塔全破壊時のレーザー距離")]
		[Range(0f, 1f)]
		[Tooltip("拠点の距離までを1としたときの割合")]
		public float zeroMeteorLaserDistance;

		[Space]
		[Header("パーティクル")]
		public HitEffect roar;

		public LoopEffect charge;

		[Header("柱の設定")]
		public DarkDragonMeteo meteorPrefab;

		[Label("ステータス")]
		[SerializeField]
		private List<ChildLevelStatus> childLevelStatus;

		[Label("柱の数")]
		public int meteorValue;

		[Label("柱個々のインターバル")]
		public EffectInterval attackInterval;

		[Label("柱の出現半径(最小)")]
		[Tooltip("最小から最大まで柱の数によって均一に配置される")]
		public float meteorMinRadius;

		[Label("柱の出現半径(最大)")]
		public float meteorMaxRadius;

		private double _nextActionTime;

		private DragonActionState _nextAction;

		private DragonActionState _nowAction;

		private DragonActionState _prevAction;

		private EnemyBaseInfo _childLevelStatus;

		private List<DarkDragonMeteo> _children;

		private Vector3 _debugLaserPos;

		private float _gateDamagePerInterval;

		private float _gateDamageStack;

		private float _gateRemainDamage;

		private MeteorSetting _targetSetting;

		private bool _isArriveTown;

		private EffectInterval _laserDamageInterval;

		private float _initDistance;

		private int _shieldCache;

		private Vector3 _initialLaserHitLocalPos;

		private float fixedValue;

		private int _debugAttackCount;

		private double _movedDistance;

		private double _overTime;

		private Vector3 _leaserHitGoalPos;

		private int _aliveMeteorCount;

		private void RegisterNextAction(double waitTime, DragonActionState action)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void MovePosition(Vector3 velocity)
		{
		}

		private void StartMotion()
		{
		}

		private void CheckAttackDistance()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		private void LaserAttack(float deltatime)
		{
		}

		private bool SearchCollider(Vector3 position, float radius, out List<IBattleCycle> hits)
		{
			hits = null;
			return false;
		}

		public List<IBattleCycle> SearchStraightLine(Vector3 startPos, Vector3 dir, float length, float tickness)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CMeteoRoar_003Ed__51))]
		public IEnumerator MeteoRoar()
		{
			return null;
		}

		private void CreateMeteo(float theta, float radius)
		{
		}

		public override void DestroyObj()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
