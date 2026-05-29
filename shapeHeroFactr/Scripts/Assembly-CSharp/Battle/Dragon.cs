using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Dragon : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public double brethTimer;

			public double floorTimer;

			internal bool _003CPlayShot_003Eb__0()
			{
				return false;
			}

			internal bool _003CPlayShot_003Eb__1()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CPlayShot_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Dragon _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

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
			public _003CPlayShot_003Ed__15(int _003C_003E1__state)
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

		public CircleSpawn sallyPoint;

		public Target target;

		public StatusEffect statusEffect;

		public EffectInterval attackInterval;

		[Header("ドラゴン固有")]
		public HitEffect charge;

		public LoopEffect breath;

		public LoopEffect floor;

		[Label("ダメージインターバル")]
		public float damageInterval;

		[Label("ブレス時間")]
		public float breathTime;

		[Label("残留時間")]
		public float floorTime;

		private double _nextDamageTime;

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

		[IteratorStateMachine(typeof(_003CPlayShot_003Ed__15))]
		public IEnumerator PlayShot()
		{
			return null;
		}

		public List<BaseEnemy> SearchHitEnemy()
		{
			return null;
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
