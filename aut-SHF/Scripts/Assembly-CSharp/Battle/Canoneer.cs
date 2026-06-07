using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Canoneer : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass23_0
		{
			public Canoneer _003C_003E4__this;

			public double nextBullet;

			public Func<bool> _003C_003E9__2;

			internal void _003CPlayShot_003Eb__0()
			{
			}

			internal bool _003CPlayShot_003Eb__1()
			{
				return false;
			}

			internal bool _003CPlayShot_003Eb__2()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CPlayShot_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Canoneer _003C_003E4__this;

			private _003C_003Ec__DisplayClass23_0 _003C_003E8__1;

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
			public _003CPlayShot_003Ed__23(int _003C_003E1__state)
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

		[Header("Canoneer固有")]
		[Label("着弾地点からの攻撃半径")]
		public float bulletAttackRadius;

		[Header("弾の設定")]
		[Label("着弾数")]
		public int bulletCount;

		[Label("着弾間隔(距離)")]
		public float bulletDistance;

		[Label("着弾間隔(s)")]
		public float bulletInterval;

		[Label("初発ディレイ")]
		[Tooltip("砲兵が発射アニメーションを行ってから弾が出るまでの時間")]
		public float firstBulletDelay;

		[Label("着弾ディレイ")]
		[Tooltip("各弾丸のダメージが発生するまでの時間")]
		public float bulletDelay;

		[SerializeField]
		private TrackingEffect lockOnEffect;

		[SerializeField]
		private HitEffect chargeEffect;

		[SerializeField]
		private HitEffect shotEffect;

		[SerializeField]
		private HitEffect bulletEffect;

		private TrackingEffect _lockOnObj;

		private Vector3 _lockPosCache;

		private Vector3 _shotDir;

		private List<HitEffect> _bullets;

		private List<int> _hitedEnemies;

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

		public override void UpdateUnit(double deltatime)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayShot_003Ed__23))]
		private IEnumerator PlayShot()
		{
			return null;
		}

		private void Shot(int idx)
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
