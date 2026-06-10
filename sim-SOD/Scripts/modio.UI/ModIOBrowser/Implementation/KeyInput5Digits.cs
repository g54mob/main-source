using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	public class KeyInput5Digits : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGetRelevantKeys_003Ed__10 : IEnumerable<KeyCode>, IEnumerable, IEnumerator<KeyCode>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private KeyCode _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private KeyCode begin;

			public KeyCode _003C_003E3__begin;

			private KeyCode end;

			public KeyCode _003C_003E3__end;

			private KeyCode _003Ck_003E5__2;

			KeyCode IEnumerator<KeyCode>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(KeyCode);
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
			public _003CGetRelevantKeys_003Ed__10(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<KeyCode> IEnumerable<KeyCode>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public bool copyPasteMode;

		public bool debug;

		public string currentInputString;

		public int index;

		private int maxDigits;

		private Action<string> onFinish;

		private Action<string> renderOutput;

		private List<KeyCode> keyCodes;

		private Dictionary<KeyCode, string> keyCodeOverrides;

		public void Setup()
		{
		}

		[IteratorStateMachine(typeof(_003CGetRelevantKeys_003Ed__10))]
		private IEnumerable<KeyCode> GetRelevantKeys(KeyCode begin, KeyCode end)
		{
			return null;
		}

		private void SetupKeyCodeStringOverrides()
		{
		}

		public void NewSession(int maxDigits, Action<string> renderOutput, Action<string> onFinish)
		{
		}

		public void EndSession()
		{
		}

		private void AddToInput(KeyCode keyCode)
		{
		}

		private void SetToInput(string s)
		{
		}

		private void Update()
		{
		}

		private bool Enter()
		{
			return false;
		}

		private bool Backspace()
		{
			return false;
		}

		public bool CopyPaste()
		{
			return false;
		}

		public string GetValues()
		{
			return null;
		}

		public void SetIndex(int i)
		{
		}

		public static bool GetKeyDown(KeyCode keyCode)
		{
			return false;
		}

		public static bool GetKeyUp(KeyCode keyCode)
		{
			return false;
		}

		public static bool GetKey(KeyCode keyCode)
		{
			return false;
		}

		public static float GetAxis(string axis)
		{
			return 0f;
		}
	}
}
