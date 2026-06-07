using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public abstract class BaseMiracle : MonoBehaviour, IBattleCycle
	{
		[Serializable]
		public struct MiracleBaseInfo
		{
			[Label("スペルタイプ")]
			public eMiracle id;

			public eUnitActionType actionType;

			public int attackPoint;

			public float speed;

			public int endurance;

			public double lifeTime;

			public int hitCount;

			public float radiusSize;

			public bool isClick;

			public int MaxHp { get; set; }
		}

		[CompilerGenerated]
		private sealed class _003CAnyTimer_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public UnityAction preAction;

			public UnityAction postAction;

			public BaseMiracle _003C_003E4__this;

			private double _003CwaitEndTime_003E5__2;

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
			public _003CAnyTimer_003Ed__68(int _003C_003E1__state)
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

		[Label("スペルステータス(確認用)")]
		public MiracleBaseInfo miracleBaseInfo;

		public SpriteAnimation spriteAnimation;

		public Transform rotationPoint;

		public UnitCollider collider;

		[Header("エフェクト関係")]
		[Tooltip("敵側に表示されるエフェクト")]
		public HitEffect hitEffect;

		[Tooltip("ヒーロー側に表示されるエフェクト")]
		public HitEffect attackEffect;

		[Label("有効：石化演出")]
		public bool enabledPertrifactionEffect;

		protected double unitEndLifeTime;

		private Vector2 directionVector;

		protected InputActionController input;

		private Material _defaultMaterial;

		public eBattleTag Tag => default(eBattleTag);

		public int TypeNum => 0;

		public int UniquTypeNum => 0;

		public bool Alive { get; protected set; }

		public bool FinishInit { get; protected set; }

		public bool Moveable { get; protected set; }

		public GameObject GameObj => null;

		public Transform Tf { get; set; }

		public virtual int AttackPoint => 0;

		public virtual int CurrentHp => 0;

		public virtual int MaxHp => 0;

		public virtual int Shield => 0;

		public virtual float Speed => 0f;

		public virtual double Lifetime => 0.0;

		public bool IsFinishLifetime => false;

		public Vector2 DirectionVector
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public bool IsAutoMode => false;

		public eLuggage LuggageId { get; set; }

		private void Awake()
		{
		}

		protected void BaseMove(double deltatime)
		{
		}

		protected void Move(Vector3 velocity)
		{
		}

		public abstract void Init();

		public abstract void UpdateMiracle(double deltatime);

		public virtual void LastUpdate()
		{
		}

		public virtual void BillboardRotation()
		{
		}

		public virtual void OverWriteWithMstData(MstMiracleDataEntities entity)
		{
		}

		public virtual void CheckLifeTime()
		{
		}

		[IteratorStateMachine(typeof(_003CAnyTimer_003Ed__68))]
		public IEnumerator AnyTimer(float time, UnityAction preAction = null, UnityAction postAction = null)
		{
			return null;
		}

		public virtual void CheckOuterRect()
		{
		}

		public virtual void HitEndurance(int enemyAttackPoint)
		{
		}

		public abstract void SallyPositionSetting();

		public abstract void HitEnemy(GameObject enemyObj);

		public abstract void DestroyObj();

		protected void CommonDestroyProcess()
		{
		}

		protected Ray GetMousePosRay()
		{
			return default(Ray);
		}

		public void Pertrifaction()
		{
		}

		public virtual void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public void PlayShootingSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayHitSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public void PlayMissSE(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public string DebugDetailLog()
		{
			return null;
		}
	}
}
