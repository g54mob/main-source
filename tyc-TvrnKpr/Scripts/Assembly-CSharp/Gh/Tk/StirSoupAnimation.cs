using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class StirSoupAnimation : BaseAnimationOld
	{
		[CompilerGenerated]
		private sealed class _003CDuration_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StirSoupAnimation _003C_003E4__this;

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
			public _003CDuration_003Ed__11(int _003C_003E1__state)
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
		private sealed class _003CTimerToInitStir_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StirSoupAnimation _003C_003E4__this;

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
			public _003CTimerToInitStir_003Ed__9(int _003C_003E1__state)
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

		public SpawnObject spoonToSpawnOnActor;

		private GameObject _itemSpawned;

		private bool _keepStirring;

		public Transform spoonRoot;

		public Transform spoon;

		public Transform ingredients;

		private Action _callback;

		private float _duration;

		public override void Animate(Activity activity, Actor actor, Action callback, float duration = 4f, Func<bool> endCondition = null, Action pausedCallback = null)
		{
		}

		[IteratorStateMachine(typeof(_003CTimerToInitStir_003Ed__9))]
		private IEnumerator TimerToInitStir()
		{
			return null;
		}

		private void InitStir()
		{
		}

		[IteratorStateMachine(typeof(_003CDuration_003Ed__11))]
		private IEnumerator Duration()
		{
			return null;
		}

		private void AnimIngredientSwirlStart()
		{
		}

		private void AnimIngredientSwirlContinue()
		{
		}

		private void AnimStirContinue()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
