using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	[Serializable]
	public class BulletSetting : EffectInterval
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass35_0
		{
			public BulletSetting _003C_003E4__this;

			public double nextTime;

			public Func<bool> _003C_003E9__0;

			internal bool _003CCreateBulletsSpan_003Eb__0()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CCreateBulletsSpan_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BulletSetting _003C_003E4__this;

			public float span;

			private _003C_003Ec__DisplayClass35_0 _003C_003E8__1;

			public UnityAction finishAction;

			private int _003Ci_003E5__2;

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
			public _003CCreateBulletsSpan_003Ed__35(int _003C_003E1__state)
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

		[Header("投擲物の設定")]
		public BaseBullet bulletPrefab;

		[Label("投擲物攻撃力")]
		public int attackPoint;

		[Label("投擲物スピード")]
		public float speed;

		[Label("投擲物耐久値")]
		public int endurance;

		[Label("投擲物寿命")]
		public double lifeTime;

		[Label("投擲物スケール倍率")]
		public float scaleFactor;

		[Label("1度の発射量")]
		public int value;

		[Label("最大回数")]
		[Tooltip("どれだけ強化されてもこの数を超えて発射はされない")]
		public int maxValue;

		[Label("打ち終わったら消滅")]
		public bool isVanishedAfterDie;

		private int currentInitId;

		private static int globalInitIdCounter;

		protected List<BaseBullet> bullets;

		public Func<int, int, Vector2> SallyPositionSetting;

		public IBattleCycle Parent { get; private set; }

		public bool IsVanished => false;

		public bool IsNoBullet => false;

		public bool IsFinishAllBullet => false;

		public bool IsPause { get; private set; }

		public void Pause()
		{
		}

		public void ReleasePouse()
		{
		}

		public void ResetBullet()
		{
		}

		public override bool IsEffectable()
		{
			return false;
		}

		public virtual void Init(IBattleCycle parent, Func<int, int, Vector2> sallyPositionSetting)
		{
		}

		public override void InitParameter(EffectInterval setting)
		{
		}

		public virtual void SetBuff(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public void CreateBullet()
		{
		}

		[IteratorStateMachine(typeof(_003CCreateBulletsSpan_003Ed__35))]
		public IEnumerator CreateBulletsSpan(float span, UnityAction finishAction = null)
		{
			return null;
		}

		public void PlayBullet()
		{
		}

		public void CheckVanished()
		{
		}

		public void DestroyAll()
		{
		}
	}
}
