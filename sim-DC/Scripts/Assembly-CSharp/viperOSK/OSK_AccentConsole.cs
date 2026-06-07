using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace viperOSK
{
	public class OSK_AccentConsole : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGenerateCoroutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_AccentConsole _003C_003E4__this;

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
			public _003CGenerateCoroutine_003Ed__21(int _003C_003E1__state)
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

		public Dictionary<string, List<string>> accentMap;

		public OSK_AccentAssetObj accentAsset;

		private OSK_LongPressPacket longPressPacket;

		private string baseChar;

		public OSK_Keyboard keyboard;

		public OSK_MiniKeyboard miniKeyboard;

		private bool isVisible;

		private bool BbtnDown;

		private float chrono;

		private PointerEventData pointerEventData;

		public bool IsVisible()
		{
			return false;
		}

		private void Start()
		{
		}

		public void LoadAccentMap(OSK_AccentAssetObj accents)
		{
		}

		private void OnDestroy()
		{
		}

		public void SetConsole(OSK_LongPressPacket packet)
		{
		}

		public bool Set(OSK_LongPressPacket packet)
		{
			return false;
		}

		public void Reset()
		{
		}

		public void ShowBackground(bool show)
		{
		}

		public void RemoveConsole()
		{
		}

		public void AccentCharClick(string accentedChar, OSK_Receiver receiver)
		{
		}

		private void Generate()
		{
		}

		[IteratorStateMachine(typeof(_003CGenerateCoroutine_003Ed__21))]
		private IEnumerator GenerateCoroutine()
		{
			return null;
		}

		private void Update()
		{
		}
	}
}
