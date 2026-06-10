using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	internal class InputFieldCoadjutant : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, ISubmitHandler
	{
		[CompilerGenerated]
		private sealed class _003CUnFocusByDefault_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InputFieldCoadjutant _003C_003E4__this;

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
			public _003CUnFocusByDefault_003Ed__8(int _003C_003E1__state)
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
		private bool editOnFocus;

		[SerializeField]
		private string inputFieldTitle;

		[SerializeField]
		private string inputFieldPlaceholderText;

		[SerializeField]
		private Browser.VirtualKeyboardType keyboardtype;

		[SerializeField]
		private TMP_InputField inputField;

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CUnFocusByDefault_003Ed__8))]
		private IEnumerator UnFocusByDefault()
		{
			return null;
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnSubmit(BaseEventData eventData)
		{
		}

		private void OpenKeyboard()
		{
		}

		private void OnCloseVirtualKeyboard(string text)
		{
		}
	}
}
