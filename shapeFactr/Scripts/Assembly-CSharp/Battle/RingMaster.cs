using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class RingMaster : BaseEnemy
	{
		private enum eRingMode
		{
			None = 0,
			Reduction = 1,
			Wait = 2,
			Attack = 3
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateRingCollision_003Ed__30 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public RingMaster _003C_003E4__this;

			private float _003CanglePerRing_003E5__2;

			private int _003CsymbolCount_003E5__3;

			private int _003CgroupId_003E5__4;

			private AsyncInstantiateOperation<Ring> _003Chandler_003E5__5;

			private AsyncInstantiateOperation<Ring>.Awaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Header("リング固有設定")]
		public ParticleSystem circleParticle;

		public Ring ringPrefab;

		[Label("衝突機配置数")]
		public int ringCount;

		[Label("初期リング半径")]
		public float ringRadius;

		[Label("ゴール半径")]
		public float goalRadius;

		[Label("ゴールEmission")]
		public float goalRateOverTime;

		[Label("攻撃モーションまでの待機時間(s)")]
		public double entryActionTime;

		[Label("シンボル設置角度")]
		[Tooltip("0～360度で入力")]
		public float[] symbolAngles;

		[Label("ストップ時間(s)")]
		[Tooltip("攻撃を受けた際に一定時間止まる")]
		public float stopTime;

		[Label("攻撃態勢中もストップ受ける")]
		public bool isStopAttackPhase;

		[Label("攻撃時の輪縮小時間(s)")]
		public float attackSecond;

		public float mergeDistance;

		private List<Ring> _collisionGroup;

		private EnemyBaseInfo _copyInfo;

		private ParticleSystem.ShapeModule _shapeModule;

		private ParticleSystem.EmissionModule _emissionModule;

		private float _initialEmissionOverTime;

		private double _attackTimer;

		private Tween _actionTween;

		private Ring _statusDamagePoint;

		public ParticleSystem.ShapeModule ParticleShape => default(ParticleSystem.ShapeModule);

		private eRingMode Mode { get; set; }

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private void ReductionRing(double deltaTime)
		{
		}

		[AsyncStateMachine(typeof(_003CCreateRingCollision_003Ed__30))]
		private void CreateRingCollision()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override bool ReceiveStatusDamage(int damagePoint, eLuggage giverLuggage, SpriteNo.eDamageType damageType, bool displayDamage = true)
		{
			return false;
		}

		private void StartAttackMotion()
		{
		}

		protected override void AttackTown()
		{
		}

		protected override int GetTownAttackPoint()
		{
			return 0;
		}

		public override void DestroyObj()
		{
		}

		public override void Withdrawal()
		{
		}
	}
}
