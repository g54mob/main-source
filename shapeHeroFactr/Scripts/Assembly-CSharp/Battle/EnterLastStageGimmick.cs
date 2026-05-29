using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class EnterLastStageGimmick : BaseStageGimmick
	{
		[CompilerGenerated]
		private sealed class _003CPlayChainBreakSECoroutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CPlayChainBreakSECoroutine_003Ed__20(int _003C_003E1__state)
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
		private sealed class _003CPlayOrdealGlowSECoroutine_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CPlayOrdealGlowSECoroutine_003Ed__18(int _003C_003E1__state)
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

		[SerializeField]
		private SkeletonAnimationController avatorSpine;

		[SerializeField]
		private SkeletonAnimationController fieldSpine;

		[SerializeField]
		private ParticleSystem openEffect;

		[SerializeField]
		private GameObject openEffectObj;

		[SerializeField]
		private ParticleSystem ordealBreakEffect;

		[SerializeField]
		private GameObject ordealBreakEffectObj;

		[SerializeField]
		private SpriteMask spriteMask;

		public static readonly string AVATOR_FADEIN;

		public static readonly string AVATOR_FADEOUT;

		public static readonly string AVATOR_LOOP;

		public static readonly string AVATOR_LOOP_LAUGH;

		public static readonly string BOSS_ANIMATION;

		public static readonly string SEALED_02_CHAINBREAK;

		private Coroutine _seCoroutine;

		public override Sequence PlayBattleGimmick()
		{
			return null;
		}

		public override Sequence PlayBossBattleGimmick()
		{
			return null;
		}

		public override Sequence GetFirstStageSequence()
		{
			return null;
		}

		private void PlayOrdealGlowSE()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayOrdealGlowSECoroutine_003Ed__18))]
		private IEnumerator PlayOrdealGlowSECoroutine()
		{
			return null;
		}

		private void PlayChainBreakSE()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayChainBreakSECoroutine_003Ed__20))]
		private IEnumerator PlayChainBreakSECoroutine()
		{
			return null;
		}
	}
}
