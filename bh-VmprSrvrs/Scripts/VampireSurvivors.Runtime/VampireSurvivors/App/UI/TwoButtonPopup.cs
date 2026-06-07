using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI
{
	public class TwoButtonPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TwoButtonPopup _003C_003E4__this;

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
			public _003CWaitAndSelect_003Ed__7(int _003C_003E1__state)
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
		private Button _Button1;

		[SerializeField]
		private Button _Button2;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _Description;

		[SerializeField]
		private TextMeshProUGUI _Button1Text;

		[SerializeField]
		private TextMeshProUGUI _Button2Text;

		public void Initialize(PopupManager manager, string id, string title, string description, string button1Text, string button2Text, Action button1Callback, Action button2Callback, bool titleIsLocalizationTerm = true, bool descriptionIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true, bool button2TextIsLocalizationTerm = true)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__7))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}
	}
}
