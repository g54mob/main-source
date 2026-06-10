using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.UI.ControlMapper;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class ControlMapperDemoMessage : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSelectDefaultDeferred_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ControlMapperDemoMessage _003C_003E4__this;

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
			public _003CSelectDefaultDeferred_003Ed__7(int _003C_003E1__state)
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

		public ControlMapper controlMapper;

		public Selectable defaultSelectable;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnControlMapperClosed()
		{
		}

		private void OnControlMapperOpened()
		{
		}

		private void SelectDefault()
		{
		}

		[IteratorStateMachine(typeof(_003CSelectDefaultDeferred_003Ed__7))]
		private IEnumerator SelectDefaultDeferred()
		{
			return null;
		}
	}
}
