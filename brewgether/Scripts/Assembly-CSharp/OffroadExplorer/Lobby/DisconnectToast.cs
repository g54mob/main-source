using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class DisconnectToast : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHideAfterDelay_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public DisconnectToast _003C_003E4__this;

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
			public _003CHideAfterDelay_003Ed__24(int _003C_003E1__state)
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

		[Header("UI Settings")]
		[SerializeField]
		private PanelSettings panelSettings;

		[SerializeField]
		private int sortOrder;

		[Header("Timing")]
		[SerializeField]
		private float defaultDuration;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private UIDocument uiDocument;

		private VisualElement root;

		private VisualElement toastContainer;

		private Label messageLabel;

		private Coroutine hideCoroutine;

		private bool isInitialized;

		public static DisconnectToast Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetupUI()
		{
		}

		private VisualElement CreateVisualTree()
		{
			return null;
		}

		public void Show(string message, float duration = 0f)
		{
		}

		public void Hide()
		{
		}

		public void ShowFinalMessage(HostLostReason reason)
		{
		}

		public void ShowConnectionWarning()
		{
		}

		public void ShowConnectionRestored()
		{
		}

		private void SetToastColors(Color borderColor, Color textColor)
		{
		}

		[IteratorStateMachine(typeof(_003CHideAfterDelay_003Ed__24))]
		private IEnumerator HideAfterDelay(float delay)
		{
			return null;
		}
	}
}
