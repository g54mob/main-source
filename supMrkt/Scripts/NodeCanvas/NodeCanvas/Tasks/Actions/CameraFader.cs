using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class CameraFader : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CCoroutineFadeIn_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CameraFader _003C_003E4__this;

			public float time;

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
			public _003CCoroutineFadeIn_003Ed__9(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CCoroutineFadeOut_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CameraFader _003C_003E4__this;

			public float time;

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
			public _003CCoroutineFadeOut_003Ed__10(int _003C_003E1__state)
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

		private static CameraFader _current;

		private float alpha;

		private Texture2D _blackTexture;

		private Texture2D blackTexture => null;

		public static CameraFader current => null;

		public void FadeIn(float time)
		{
		}

		public void FadeOut(float time)
		{
		}

		[IteratorStateMachine(typeof(_003CCoroutineFadeIn_003Ed__9))]
		private IEnumerator CoroutineFadeIn(float time)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCoroutineFadeOut_003Ed__10))]
		private IEnumerator CoroutineFadeOut(float time)
		{
			return null;
		}

		private void OnGUI()
		{
		}
	}
}
