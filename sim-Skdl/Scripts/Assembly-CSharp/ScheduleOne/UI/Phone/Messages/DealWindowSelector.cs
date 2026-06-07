using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Messaging;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages
{
	public class DealWindowSelector : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelaySelectPanel_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DealWindowSelector _003C_003E4__this;

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
			public _003CDelaySelectPanel_003Ed__24(int _003C_003E1__state)
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

		public const float TIME_ARM_ROTATION_0000 = 0f;

		public const float TIME_ARM_ROTATION_2400 = -360f;

		public const int WINDOW_CUTOFF_MINS = 120;

		public UnityEvent<EDealWindow> OnSelected;

		[Header("References")]
		public GameObject Container;

		public WindowSelectorButton MorningButton;

		public WindowSelectorButton AfternoonButton;

		public WindowSelectorButton NightButton;

		public WindowSelectorButton LateNightButton;

		public RectTransform CurrentTimeArm;

		public Text CurrentTimeLabel;

		[Header("Custom UI")]
		public UIScreen uiScreen;

		public UIPanel uiPanel;

		private Action<EDealWindow> callback;

		private WindowSelectorButton[] buttons;

		private bool hintShown;

		public bool IsOpen { get; private set; }

		private void Start()
		{
		}

		public void Exit(ExitAction action)
		{
		}

		public void SetIsOpen(bool open)
		{
		}

		public void SetIsOpen(bool open, MSGConversation conversation, Action<EDealWindow> callback = null)
		{
		}

		[IteratorStateMachine(typeof(_003CDelaySelectPanel_003Ed__24))]
		private IEnumerator DelaySelectPanel()
		{
			return null;
		}

		public void Update()
		{
		}

		private void UpdateTime()
		{
		}

		private void UpdateWindowValidity()
		{
		}

		private void Close()
		{
		}

		private void ButtonClicked(EDealWindow window)
		{
		}
	}
}
