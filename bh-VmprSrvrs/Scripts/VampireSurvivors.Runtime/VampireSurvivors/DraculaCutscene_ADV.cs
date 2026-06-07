using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using VampireSurvivors.Objects.Characters.Enemies;

namespace VampireSurvivors
{
	public class DraculaCutscene_ADV : DraculaCutscene
	{
		[CompilerGenerated]
		private sealed class _003CPlayDeathDialogueCutscene_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene_ADV _003C_003E4__this;

			private Enemy_TP_Death _003CdeathEnemy_003E5__2;

			private int _003Cindex_003E5__3;

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
			public _003CPlayDeathDialogueCutscene_003Ed__1(int _003C_003E1__state)
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
		private sealed class _003CTransitionToDeathFight_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene_ADV _003C_003E4__this;

			public Enemy_TP_Death deathEnemy;

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
			public _003CTransitionToDeathFight_003Ed__2(int _003C_003E1__state)
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

		protected override void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CPlayDeathDialogueCutscene_003Ed__1))]
		protected override IEnumerator PlayDeathDialogueCutscene()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionToDeathFight_003Ed__2))]
		private IEnumerator TransitionToDeathFight(Enemy_TP_Death deathEnemy)
		{
			return null;
		}
	}
}
