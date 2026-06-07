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
	public class LargeLoadableDLCSelectionPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CFrameDelays_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LargeLoadableDLCSelectionPopup _003C_003E4__this;

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
			public _003CFrameDelays_003Ed__9(int _003C_003E1__state)
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
		protected TextMeshProUGUI _Title;

		[SerializeField]
		protected TextMeshProUGUI _Description;

		[SerializeField]
		protected RectTransform _Container;

		[SerializeField]
		protected Button _Confirm;

		[SerializeField]
		protected Button _Back;

		[SerializeField]
		protected LargeLoadableDLCSelectionPopupItem _DLCOptionPrefab;

		protected List<DLCOptionDataSet> _Options;

		protected Action _onConfirmCallback;

		public virtual void Initialize(string id, string title, string description, List<DLCOptionDataSet> options, Action callback, bool showBackButton)
		{
		}

		[IteratorStateMachine(typeof(_003CFrameDelays_003Ed__9))]
		private IEnumerator FrameDelays()
		{
			return null;
		}

		public void Confirm()
		{
		}

		public void Close()
		{
		}
	}
}
