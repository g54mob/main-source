using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Sniper : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003CPlayShot_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Sniper _003C_003E4__this;

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
			public _003CPlayShot_003Ed__20(int _003C_003E1__state)
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

		public KnockBack knockBack;

		public EffectInterval attackInterval;

		[Header("スナイパー固有")]
		[SerializeField]
		[Label("弾丸の横幅")]
		public float bulletTickness;

		[Label("飛距離")]
		public float bulletRange;

		[Label("未ターゲット時エフェクト距離")]
		public float noTargetEffectDistance;

		[Label("威力減衰")]
		public Attenuation attenuation;

		[Header("エフェクト")]
		[SerializeField]
		private TrackingEffect lockOnEffect;

		[SerializeField]
		private HitEffect shotEffect;

		private TrackingEffect _lockOnObj;

		private Vector3 _lockPosCache;

		private StatusEffect _statusEffect;

		private Vector2 _shotDir;

		private GameObject _sniperLockPos;

		private int _initAttackPoint;

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

		[IteratorStateMachine(typeof(_003CPlayShot_003Ed__20))]
		private IEnumerator PlayShot()
		{
			return null;
		}

		private void Shot()
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

		public override float GetTotalAttackTime()
		{
			return 0f;
		}

		public override void BuffPlus(BuffSet<eAbilityEffectId> buffSet)
		{
		}
	}
}
