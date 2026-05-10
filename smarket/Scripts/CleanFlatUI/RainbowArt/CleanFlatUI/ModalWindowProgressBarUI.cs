using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class ModalWindowProgressBarUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CUpdateTransition_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ModalWindowProgressBarUI _003C_003E4__this;

			private float _003CcurProgress_003E5__2;

			private float _003CmaxProgress_003E5__3;

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
			public _003CUpdateTransition_003Ed__8(int _003C_003E1__state)
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
		private Button button;

		[SerializeField]
		private ModalWindowProgressBar modalWindow;

		private IEnumerator updateCoroutine;

		public void Start()
		{
		}

		private void OnButtonClick()
		{
		}

		private void ModalWindowCancel()
		{
		}

		private void ModalWindowFinish()
		{
		}

		private void UpdateProgress()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateTransition_003Ed__8))]
		private IEnumerator UpdateTransition()
		{
			return null;
		}
	}
}
