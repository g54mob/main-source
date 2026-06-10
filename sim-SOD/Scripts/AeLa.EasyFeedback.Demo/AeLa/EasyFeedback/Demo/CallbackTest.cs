using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.Demo
{
	[RequireComponent(typeof(Text))]
	public class CallbackTest : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeCoroutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CallbackTest _003C_003E4__this;

			private float _003Ca_003E5__2;

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
			public _003CFadeCoroutine_003Ed__6(int _003C_003E1__state)
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

		public float FadeTime;

		private Text text;

		private Coroutine coroutine;

		private void Start()
		{
		}

		private void SetAlpha(float a)
		{
		}

		public void OnEvent()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeCoroutine_003Ed__6))]
		private IEnumerator FadeCoroutine()
		{
			return null;
		}
	}
}
