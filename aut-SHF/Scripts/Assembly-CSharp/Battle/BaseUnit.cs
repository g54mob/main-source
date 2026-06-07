using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public abstract class BaseUnit : MonoBehaviour, IBattleCycle
	{
		[Serializable]
		public struct UnitBaseInfo
		{
			[Label("ユニットタイプ")]
			public eUnit unitType;

			[Label("ユニットアクションタイプ")]
			public eUnitActionType actionType;

			[Label("攻撃力")]
			public int attackPoint;

			[Label("スピード")]
			public float speed;

			[Label("耐久値")]
			public int endurance;

			[Label("寿命(s)")]
			public double lifeTime;

			[Label("シールド")]
			public int shield;

			public string desc;

			public int MaxHp { get; set; }
		}

		[CompilerGenerated]
		private sealed class _003CAnyTimer_003Ed__95 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public UnityAction preAction;

			public UnityAction postAction;

			public BaseUnit _003C_003E4__this;

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
			public _003CAnyTimer_003Ed__95(int _003C_003E1__state)
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

		public SpriteAnimation spriteAnimation;

		public Transform rotationPoint;

		[Label("UnitBaseInfo(参照用)")]
		public UnitBaseInfo unitBaseInfo;

		public UnitCollider collider;

		[Header("エフェクト関係")]
		[Tooltip("敵側に表示されるエフェクト")]
		public HitEffect hitEffect;

		[Tooltip("ヒーロー側に表示されるエフェクト")]
		public HitEffect attackEffect;

		protected double unitEndLifeTime;

		protected Vector2 directionVector;

		protected int firstSallyCount;

		private int minAttackPoint;

		private TrailRenderer[] trailRenderers;

		private Material _defaultMaterial;

		public eBattleTag Tag => default(eBattleTag);

		public int TypeNum => 0;

		public int UniquTypeNum => 0;

		public bool Alive { get; protected set; }

		public bool FinishInit { get; protected set; }

		public bool Moveable { get; protected set; }

		public GameObject GameObj => null;

		public Transform Tf { get; set; }

		public double UnitEndLifeTime => 0.0;

		public double TotalHealPoint { get; private set; }

		public bool IsInvincibleLife { get; set; }

		public bool IsInvincibleEndurance { get; set; }

		public bool IsFinishLifetime => false;

		public eUnit GetUnitId => default(eUnit);

		public eLuggage LuggageId { get; set; }

		public virtual int AttackPoint => 0;

		public virtual int CurrentHp => 0;

		public virtual int MaxHp => 0;

		public virtual int Shield => 0;

		public virtual float Speed => 0f;

		public virtual double Lifetime => 0.0;

		public void LifePlus(double add)
		{
		}

		public void ReceiveIsInvincibleLife(float time, TrackingEffect buffEffectObj = null)
		{
		}

		public void ReceiveInvincibleEndurance(float time, TrackingEffect buffEffectObj)
		{
		}

		private void Awake()
		{
		}

		public virtual void OverWriteWithMstData(MstUnitDataEntities entity)
		{
		}

		public virtual void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		protected void BaseMove(double deltatime)
		{
		}

		protected virtual void Move(Vector3 velocity)
		{
		}

		public void CommonInit(BaseUnit unit)
		{
		}

		protected abstract void InitAdditionalParameter(BaseUnit unit);

		public abstract void Init();

		public abstract void UpdateUnit(double deltatime);

		public virtual void LastUpdate()
		{
		}

		protected void FlipSprite()
		{
		}

		public virtual void BillboardRotation()
		{
		}

		public virtual void CheckLifeTime()
		{
		}

		public virtual void CheckOuterRect()
		{
		}

		public virtual void HitEndurance(int enemyAttackPoint, bool bullet = false)
		{
		}

		public abstract Vector2 SallyPositionSetting();

		public abstract void HitEnemy(GameObject enemyObj);

		public abstract void DestroyObj();

		private void OnReturn(GameObject obj)
		{
		}

		protected void SafeReturn(GameObject obj)
		{
		}

		public void StopMove(float stopTime)
		{
		}

		[IteratorStateMachine(typeof(_003CAnyTimer_003Ed__95))]
		public IEnumerator AnyTimer(float time, UnityAction preAction = null, UnityAction postAction = null)
		{
			return null;
		}

		public void NockBack(float knockBackPower)
		{
		}

		public void NockBack(Vector2 knockVelocity)
		{
		}

		public void CreateLevelEffect(GameObject ef)
		{
		}

		public virtual int GetTotalPower()
		{
			return 0;
		}

		protected void SetFirstSally()
		{
		}

		protected virtual void BulletHitProcess(GameObject enemyObj)
		{
		}

		public virtual float GetTotalAttackTime()
		{
			return 0f;
		}

		public void Pertrifaction()
		{
		}

		public float GetMaxMoveDistance(float speed, double lifetime)
		{
			return 0f;
		}

		public virtual void PlayAppearSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayAppearVCSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayStandbySound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayHitSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayShootingSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayDisappearSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayDisappearRockSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayActivateSound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayUniqueAction01Sound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayUniqueAction02Sound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayUniqueAction03Sound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public virtual void PlayUniqueAction04Sound(Vector3? targetPosition = null, Vector3? correctPosition = null)
		{
		}

		public string DebugDetailLog()
		{
			return null;
		}
	}
}
