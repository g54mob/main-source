using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VoxelBusters.CoreLibrary.NativePlugins.DemoKit
{
	public class ConsoleRect : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CMoveScrollerToBottom_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ConsoleRect _003C_003E4__this;

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
			public _003CMoveScrollerToBottom_003Ed__5(int _003C_003E1__state)
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

		private const int MAX_LENGTH = 10000;

		[SerializeField]
		private Text m_text;

		[SerializeField]
		private ScrollRect m_textScroller;

		private void Awake()
		{
		}

		public void Log(string message, bool append)
		{
		}

		[IteratorStateMachine(typeof(_003CMoveScrollerToBottom_003Ed__5))]
		private IEnumerator MoveScrollerToBottom()
		{
			return null;
		}

		private void Reset()
		{
		}
	}
}
