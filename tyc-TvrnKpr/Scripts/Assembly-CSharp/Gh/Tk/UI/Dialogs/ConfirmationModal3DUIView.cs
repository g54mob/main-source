using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ConfirmationModal3DUIView : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCancelCountdown_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConfirmationModal3DUIView _003C_003E4__this;

			public float timeInSeconds;

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
			public _003CCancelCountdown_003Ed__7(int _003C_003E1__state)
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
		private TextMeshProI18n _messageText;

		[SerializeField]
		private Button3DUIView _confirmationButton;

		[SerializeField]
		private Button3DUIView _cancelButton;

		private string _rawText;

		private float _timeRemaining;

		private float _lastTime;

		public void ConfirmWithUser(string text, Action onConfirm, Action onCancelAndRevert, float autoCancelInSeconds = -1f)
		{
		}

		[IteratorStateMachine(typeof(_003CCancelCountdown_003Ed__7))]
		private IEnumerator CancelCountdown(float timeInSeconds)
		{
			return null;
		}
	}
}
