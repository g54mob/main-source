using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace viperOSK
{
	public class OSK_Cursor : MonoBehaviour, I_OSK_Cursor
	{
		[CompilerGenerated]
		private sealed class _003CBlinkCoroutine_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_Cursor _003C_003E4__this;

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
			public _003CBlinkCoroutine_003Ed__14(int _003C_003E1__state)
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

		private bool blink;

		public float bps;

		private Vector3 startingCursorPos;

		private Vector3 cursorPos;

		public OSK_Receiver input;

		public TMP_Text textComponent;

		private TMP_TextInfo textInfo;

		private TMP_CharacterInfo charInfo;

		public SpriteRenderer cursorImg;

		private Color cursorImgColor;

		public T FindComponentInParentOrSiblings<T>() where T : Component
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void Cursor()
		{
		}

		[IteratorStateMachine(typeof(_003CBlinkCoroutine_003Ed__14))]
		private IEnumerator BlinkCoroutine()
		{
			return null;
		}

		public void Show(bool show)
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		private void Update()
		{
		}
	}
}
