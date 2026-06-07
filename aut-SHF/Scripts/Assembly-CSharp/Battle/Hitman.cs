using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Hitman : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			public bool beforeAttackMotion;

			public Hitman _003C_003E4__this;

			internal void _003CPlayShot_003Eb__2()
			{
			}

			internal bool _003CPlayShot_003Eb__3()
			{
				return false;
			}

			internal void _003CPlayShot_003Eb__4()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CPlayShot_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Hitman _003C_003E4__this;

			private _003C_003Ec__DisplayClass17_0 _003C_003E8__1;

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
			public _003CPlayShot_003Ed__17(int _003C_003E1__state)
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

		private StatusEffect _status;

		public EffectInterval attackInterval;

		[Header("ヒットマン固有")]
		public int hitCount;

		[Label("弾丸の横幅")]
		public float bulletTickness;

		[Tooltip("扇の角度")]
		public float searchMaxAngle;

		public TrackingEffect lockOnEffect;

		public HitEffect shotEffect;

		private List<Vector3> _searchDirs;

		private List<BaseEnemy> _targetList;

		private List<Vector3> _lockPosCache;

		private Vector2 _shotDir;

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

		[IteratorStateMachine(typeof(_003CPlayShot_003Ed__17))]
		private IEnumerator PlayShot()
		{
			return null;
		}

		private void ShotEffect(Vector3 targetPos)
		{
		}

		private void Shot(Vector3 targetPos)
		{
		}

		public override void HitEnemy(GameObject enemyObj)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void CheckLifeTime()
		{
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}
	}
}
