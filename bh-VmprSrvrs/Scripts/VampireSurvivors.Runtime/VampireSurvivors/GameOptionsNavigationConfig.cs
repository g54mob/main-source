using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors
{
	public class GameOptionsNavigationConfig : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitFrame_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameOptionsNavigationConfig _003C_003E4__this;

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
			public _003CWaitFrame_003Ed__7(int _003C_003E1__state)
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
		private Button _QuitButton;

		[SerializeField]
		private Button _ResumeButton;

		[SerializeField]
		private Selectable _FancyBackground;

		[SerializeField]
		private Selectable _VisibleJoystick;

		[SerializeField]
		private Selectable _DamageNumbers;

		[SerializeField]
		private Selectable _FlashingVFX;

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitFrame_003Ed__7))]
		private IEnumerator WaitFrame()
		{
			return null;
		}

		protected void SetNavigationUp(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationDown(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationLeft(Selectable origin, Selectable target = null)
		{
		}

		protected void SetNavigationRight(Selectable origin, Selectable target = null)
		{
		}
	}
}
