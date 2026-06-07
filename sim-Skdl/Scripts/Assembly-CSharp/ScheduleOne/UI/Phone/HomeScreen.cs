using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone
{
	public class HomeScreen : PlayerSingleton<HomeScreen>
	{
		[CompilerGenerated]
		private sealed class _003CDelayedSetCanvasActive_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public HomeScreen _003C_003E4__this;

			public bool active;

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
			public _003CDelayedSetCanvasActive_003Ed__21(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CSelectUIPanel_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public HomeScreen _003C_003E4__this;

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
			public _003CSelectUIPanel_003Ed__24(int _003C_003E1__state)
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
		[Header("References")]
		protected Canvas canvas;

		[SerializeField]
		protected Text timeText;

		[SerializeField]
		protected RectTransform appIconContainer;

		[Header("Prefabs")]
		[SerializeField]
		protected GameObject appIconPrefab;

		[Header("Custom UI")]
		[SerializeField]
		protected UIScreen uiScreen;

		[SerializeField]
		protected UIPanel uiPanel;

		protected List<Button> appIcons;

		private Coroutine delayedSetOpenRoutine;

		private UISelectable lastSelectedSelectable;

		public bool isOpen { get; protected set; }

		public UISelectable LastSelectedSelectable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Start()
		{
		}

		public override void OnStartClient(bool IsOwner)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected void PhoneOpened()
		{
		}

		protected void PhoneClosed()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedSetCanvasActive_003Ed__21))]
		private IEnumerator DelayedSetCanvasActive(bool active, float delay)
		{
			return null;
		}

		public void SetIsOpen(bool o)
		{
		}

		public void SetCanvasActive(bool a)
		{
		}

		[IteratorStateMachine(typeof(_003CSelectUIPanel_003Ed__24))]
		private IEnumerator SelectUIPanel()
		{
			return null;
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnUncappedMinPass()
		{
		}

		public Button GenerateAppIcon<T>(App<T> prog) where T : PlayerSingleton<T>
		{
			return null;
		}
	}
}
