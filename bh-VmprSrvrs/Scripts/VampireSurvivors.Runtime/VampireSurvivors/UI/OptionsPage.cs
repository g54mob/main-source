using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class OptionsPage : BaseUIPage
	{
		[CompilerGenerated]
		private sealed class _003CFrameDelay_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OptionsPage _003C_003E4__this;

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
			public _003CFrameDelay_003Ed__4(int _003C_003E1__state)
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
		private TextMeshProUGUI LanguageButtonName;

		[SerializeField]
		private OptionsController _Controller;

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		[IteratorStateMachine(typeof(_003CFrameDelay_003Ed__4))]
		private IEnumerator FrameDelay()
		{
			return null;
		}

		protected override void OnHideFinish(GameObject g)
		{
		}

		private void OnEnable()
		{
		}
	}
}
