using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Core
{
	[RequireComponent(typeof(UIDocument))]
	public class UIDocumentSleeper : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSleepDeferred_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIDocumentSleeper _003C_003E4__this;

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
			public _003CSleepDeferred_003Ed__7(int _003C_003E1__state)
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

		[Tooltip("If true, this document is never put to sleep (use for always-visible HUDs).")]
		[SerializeField]
		private bool alwaysAwake;

		[Tooltip("If true, the document starts asleep after a 1-frame delay (use for panels that are hidden by default).")]
		[SerializeField]
		private bool startAsleep;

		private UIDocument uiDocument;

		private bool isSleeping;

		public bool IsSleeping => false;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CSleepDeferred_003Ed__7))]
		private IEnumerator SleepDeferred()
		{
			return null;
		}

		public void Wake()
		{
		}

		public void Sleep()
		{
		}
	}
}
