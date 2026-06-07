using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class LargeMultiOptionPopup : BasePopup
	{
		[CompilerGenerated]
		private sealed class _003CFrameDelays_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LargeMultiOptionPopup _003C_003E4__this;

			private ScrollRect _003CscrollRect_003E5__2;

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
			public _003CFrameDelays_003Ed__11(int _003C_003E1__state)
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
		protected GameObject _OptionPrefab;

		protected int _selectedIndex;

		private Rewired.Player _player;

		protected Action<int> _onSelectedCallback;

		protected Action _onClosedCallback;

		protected void Update()
		{
		}

		public virtual void Initialize(string id, string title, string description, List<OptionDataSet> options, Action<int> callback, Action closedCallback, TextAlignmentOptions? titleTextAlignment = null, bool centerTicks = false)
		{
		}

		[IteratorStateMachine(typeof(_003CFrameDelays_003Ed__11))]
		private IEnumerator FrameDelays()
		{
			return null;
		}

		public void SelectOption(int index)
		{
		}

		public void SelectOption(GameObject g)
		{
		}

		public void Confirm()
		{
		}

		public void Closed()
		{
		}
	}
}
