using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.Demo.Cockpit
{
	public class PropertyListenerBase : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFadeOut_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Graphic image;

			public PropertyListenerBase _003C_003E4__this;

			private float _003CelapsedTime_003E5__2;

			private Color _003Cc_003E5__3;

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
			public _003CFadeOut_003Ed__4(int _003C_003E1__state)
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

		public Graphic UpdateIndicator;

		private YieldInstruction fadeInstruction;

		private float Duration;

		public void OnValueChanged()
		{
		}

		[IteratorStateMachine(typeof(_003CFadeOut_003Ed__4))]
		private IEnumerator FadeOut(Graphic image)
		{
			return null;
		}
	}
}
