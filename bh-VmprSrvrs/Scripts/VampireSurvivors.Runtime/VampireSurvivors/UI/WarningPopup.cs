using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class WarningPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WarningPopup _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__5(int _003C_003E1__state)
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
		private Button _OkButton;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _Description;

		private PopupManager _manager;

		public void Initialize(PopupManager manager, string id, string title, string description, Action callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__5))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}
	}
}
