using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Thunderbird : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public Thunderbird _003C_003E4__this;

			public double delayHitTimer;

			internal bool _003CPlayShot_003Eb__0()
			{
				return false;
			}

			internal void _003CPlayShot_003Eb__1()
			{
			}

			internal bool _003CPlayShot_003Eb__2()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CPlayShot_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Thunderbird _003C_003E4__this;

			private _003C_003Ec__DisplayClass15_0 _003C_003E8__1;

			private List<BaseEnemy> _003Cenemies_003E5__2;

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

		public EffectInterval attackInterval;

		[Header("サンダーバード固有")]
		public HitEffect groundHit;

		public HitEffect charge;

		public HitEffect shout;

		[Label("ヒット数")]
		public int hitCount;

		public float hitDelay;

		[Label("出現してからの検索範囲")]
		public float searchRadius;

		private StatusEffect _statusEffect;

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

		private void ThunderBirdSearch(ref List<BaseEnemy> enemies, int value)
		{
		}

		public override void UpdateUnit(double deltatime)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayShot_003Ed__15))]
		private IEnumerator PlayShot()
		{
			return null;
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override void DestroyObj()
		{
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}
	}
}
