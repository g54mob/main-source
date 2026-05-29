using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public class Wise : BaseUnit
	{
		[CompilerGenerated]
		private sealed class _003CPlayEffect_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Wise _003C_003E4__this;

			private float[] _003Cdegrees_003E5__2;

			private int _003Ci_003E5__3;

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
			public _003CPlayEffect_003Ed__28(int _003C_003E1__state)
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

		[Tooltip("攻撃アニメーションから次の攻撃アニメーションまでの時間(発動タイプは共通仕様)")]
		public EffectInterval attaclnterval;

		[Header("Wise固有")]
		[Label("ターゲット接近距離")]
		[Tooltip("レベル0時にターゲットからどれだけ離れた位置に出現するか")]
		public float sallyDistance;

		[Label("ダメージ範囲")]
		public float attackSearchRange;

		[Header("雷の設定")]
		[Label("雷の数")]
		[Tooltip("自動で360°をこの数で割った場所に出現する")]
		public float thunderCount;

		[Label("雷の間隔(s)")]
		public double thunderInterval;

		public bool randomOder;

		public ParticleSystem thunder;

		public Transform groundParticle;

		public StatusEffect statusEffect;

		[Label("有効：無ターゲットで時計配置")]
		public bool clockMode;

		[Label("時計回り分割角度")]
		public int clockSplitAngle;

		private static float[] _thunderDgreees;

		private bool _playEffect;

		private const string EffectKeyName = "Wise_Thunder";

		private readonly List<GameObject> _createdThunder;

		private static int? _maxSplitCount;

		private static int _wisePositionIndex;

		private const int _defaultMaxSplitCount = 12;

		private Vector3 GroundOffset => default(Vector3);

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

		public void Shot()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayEffect_003Ed__28))]
		public IEnumerator PlayEffect()
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

		public override void CheckLifeTime()
		{
		}

		public override float GetTotalAttackTime()
		{
			return 0f;
		}

		private void OnApplicationQuit()
		{
		}
	}
}
