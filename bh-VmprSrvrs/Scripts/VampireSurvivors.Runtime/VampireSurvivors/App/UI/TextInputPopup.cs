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
	public class TextInputPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndSelect_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TextInputPopup _003C_003E4__this;

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
		private Button _Button1;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private TextMeshProUGUI _Button1Text;

		[SerializeField]
		private TMP_InputField _InputField;

		public void Initialize(PopupManager manager, string id, string title, string button1Text, Action<string> button1Callback, bool titleIsLocalizationTerm = true, bool button1TextIsLocalizationTerm = true)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndSelect_003Ed__5))]
		private IEnumerator WaitAndSelect()
		{
			return null;
		}
	}
}
