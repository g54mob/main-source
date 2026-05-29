using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public abstract class BaseBullet : MonoBehaviour, IBattleCycle
	{
		public struct BulletBaseInfo
		{
			public int attackPoint;

			public float speed;

			public int endurance;

			public double lifeTime;

			public int MaxHp { get; private set; }

			public BulletBaseInfo(int attackPoint, float speed, int endurance, double lifeTime)
			{
				this.attackPoint = 0;
				this.speed = 0f;
				this.endurance = 0;
				MaxHp = 0;
				this.lifeTime = 0.0;
			}
		}

		[CompilerGenerated]
		private sealed class _003CAnyTimer_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float time;

			public UnityAction preAction;

			public UnityAction postAction;

			public BaseBullet _003C_003E4__this;

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

		[CompilerGenerated]
		private sealed class _003CSetStopMove_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float stopTime;

			public BaseBullet _003C_003E4__this;

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
			public _003CSetStopMove_003Ed__70(int _003C_003E1__state)
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

		protected double unitEndLifeTime;

		protected Vector2 directionVector;

		protected BulletBaseInfo bulletBaseInfo;

		public UnityAction hitEvent;

		private TrailRenderer[] trailRenderers;

		public virtual eBattleTag Tag { get; set; }

		public virtual int TypeNum { get; set; }

		public virtual int UniquTypeNum { get; }

		public bool Alive { get; set; }

		public bool FinishInit { get; set; }

		public bool Moveable { get; set; }

		public GameObject GameObj => null;

		public Transform Tf { get; set; }

		public virtual int AttackPoint => 0;

		public virtual int CurrentHp => 0;

		public virtual int MaxHp => 0;

		public virtual int Shield => 0;

		public virtual float Speed => 0f;

		public virtual double Lifetime => 0.0;

		public int InitId { get; set; }

		public BulletBaseInfo BulletInfo
		{
			get
			{
				return default(BulletBaseInfo);
			}
			set
			{
			}
		}

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

		public void CommonInit(BaseBullet bullet)
		{
		}

		protected abstract void InitAdditionalParameter(BaseBullet bullet);

		public abstract void UpdateBullet(double deltatime);

		public virtual void LastUpdate()
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

		public virtual void HitEndurance(int enemyAttackPoint)
		{
		}

		[IteratorStateMachine(typeof(_003CAnyTimer_003Ed__68))]
		public IEnumerator AnyTimer(float time, UnityAction preAction = null, UnityAction postAction = null)
		{
			return null;
		}

		public void StopMove(float stopTime)
		{
		}

		[IteratorStateMachine(typeof(_003CSetStopMove_003Ed__70))]
		public virtual IEnumerator SetStopMove(float stopTime)
		{
			return null;
		}

		public abstract void RegisterParent(IBattleCycle parent);

		public abstract void DestroyObj();

		public string DebugDetailLog()
		{
			return null;
		}

		private void OnReturn(GameObject obj)
		{
		}

		protected void SafeReturn(GameObject obj)
		{
		}
	}
}
