using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UI.Core
{
	public class UIManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CVerifyCursorStateLocked_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003Ci_003E5__2;

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
			public _003CVerifyCursorStateLocked_003Ed__38(int _003C_003E1__state)
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

		private static UIManager _instance;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private readonly List<IUIPanel> openPanels;

		private readonly HashSet<string> excludedPanelIds;

		private int _lastPanelClosedFrame;

		private readonly HashSet<string> nonBlockingPanelIds;

		private readonly HashSet<string> nonBlockingCursorSources;

		private float _orphanCheckTimer;

		private const float ORPHAN_CHECK_INTERVAL = 2f;

		public static UIManager Instance => null;

		public bool WasPanelClosedThisFrame => false;

		public bool IsAnyUIOpen => false;

		public int OpenPanelCount => 0;

		public bool IsGameplayInputBlocked => false;

		public bool HasBlockingPanelOpen => false;

		public event Action OnUIOpened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnUIClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnAllUIsClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnApplicationFocus(bool hasFocus)
		{
		}

		private void CleanupStalePanels()
		{
		}

		private void Update()
		{
		}

		private void CleanupOrphanedPanels()
		{
		}

		public void RegisterPanel(IUIPanel panel)
		{
		}

		public void UnregisterPanel(IUIPanel panel)
		{
		}

		[IteratorStateMachine(typeof(_003CVerifyCursorStateLocked_003Ed__38))]
		private IEnumerator VerifyCursorStateLocked()
		{
			return null;
		}

		public bool CloseTopmost()
		{
			return false;
		}

		public void CloseAll()
		{
		}

		public bool IsPanelOpen(string panelId)
		{
			return false;
		}

		public string[] GetOpenPanelIds()
		{
			return null;
		}

		public void LogOpenPanels()
		{
		}

		public void ExcludePanel(string panelId)
		{
		}

		public void IncludePanel(string panelId)
		{
		}

		public void RegisterNonBlockingCursorSource(string sourceId)
		{
		}

		public void UnregisterNonBlockingCursorSource(string sourceId)
		{
		}
	}
}
