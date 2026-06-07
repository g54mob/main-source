using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace viperOSK
{
	[ExecuteInEditMode]
	public class OSK_UI_Keyboard : OSK_Keyboard
	{
		[CompilerGenerated]
		private sealed class _003CSelectKey_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_UI_Key selKey;

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
			public _003CSelectKey_003Ed__21(int _003C_003E1__state)
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

		private new List<List<OSK_UI_Key>> keyLayout;

		private OSK_UI_Key currentSelUIKey;

		private OSK_UI_Key nextKey;

		private Transform keyboardAssets;

		public override Vector3 SpanTopLeft()
		{
			return default(Vector3);
		}

		public override Vector3 SpanBottomRight()
		{
			return default(Vector3);
		}

		public override Vector3 KeyScreenSize()
		{
			return default(Vector3);
		}

		public void ShowHideKeyboard(bool show)
		{
		}

		public override void SetInteractable(bool isInteractable)
		{
		}

		public override bool HasKey(OSK_KeyCode k)
		{
			return false;
		}

		public override void Reset()
		{
		}

		public override void ResizeKeyToFit(Vector2 scrSize)
		{
		}

		public override void Generate()
		{
		}

		public override void Traverse()
		{
		}

		private void GamepadWrapNavigation()
		{
		}

		public override void RemapPhysicalKeyboard()
		{
		}

		public override void KeyCallBase(OSK_KeyCode k, OSK_Receiver receiver)
		{
		}

		public override void KeyCall(OSK_KeyCode k, OSK_Receiver receiver)
		{
		}

		public override void ButtonA()
		{
		}

		public OSK_UI_Key SelectedKey()
		{
			return null;
		}

		public override void SetSelectedKey(OSK_KeyCode k)
		{
		}

		[IteratorStateMachine(typeof(_003CSelectKey_003Ed__21))]
		private IEnumerator SelectKey(OSK_UI_Key selKey)
		{
			return null;
		}

		public override void SetSelectedKey(string c)
		{
		}

		public void SetSelectedKey(OSK_UI_Key k)
		{
		}

		public override void DpadMove(Vector2 dir)
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void PrepAssetGroup()
		{
		}

		private void OnGUI()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
