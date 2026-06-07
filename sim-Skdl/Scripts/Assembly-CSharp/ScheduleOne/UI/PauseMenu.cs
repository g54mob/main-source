using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.MainMenu;
using UnityEngine;

namespace ScheduleOne.UI
{
	public class PauseMenu : Singleton<PauseMenu>
	{
		[CompilerGenerated]
		private sealed class _003CDelayPanelSelect_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PauseMenu _003C_003E4__this;

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
			public _003CDelayPanelSelect_003Ed__27(int _003C_003E1__state)
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

		public Canvas Canvas;

		public RectTransform Container;

		public MainMenuScreen Screen;

		public FeedbackForm FeedbackForm;

		[Header("Custom UI")]
		public UIScreen uiScreen;

		public UIPanel uiPanel;

		private bool justPaused;

		private bool justResumed;

		private bool couldLook;

		private bool lockedMouse;

		private bool crosshairVisible;

		private bool hudVisible;

		public Action onPause;

		public Action onResume;

		private bool _togglePausePressed;

		private bool _backWasTriggeredThisFrame;

		public bool IsPaused { get; protected set; }

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Exit(ExitAction action)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void CheckTogglePause()
		{
		}

		public void Pause()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayPanelSelect_003Ed__27))]
		private IEnumerator DelayPanelSelect()
		{
			return null;
		}

		public void Resume()
		{
		}

		public void StuckButtonClicked()
		{
		}
	}
}
