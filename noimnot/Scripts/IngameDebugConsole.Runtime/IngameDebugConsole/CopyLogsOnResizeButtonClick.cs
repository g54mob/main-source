using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace IngameDebugConsole
{
	public class CopyLogsOnResizeButtonClick : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003CScaleAnimationCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CopyLogsOnResizeButtonClick _003C_003E4__this;

			private float _003Ct_003E5__2;

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
			public _003CScaleAnimationCoroutine_003Ed__3(int _003C_003E1__state)
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

		[SerializeField]
		private int maxLogCount;

		[SerializeField]
		private float maxElapsedTime;

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CScaleAnimationCoroutine_003Ed__3))]
		private IEnumerator ScaleAnimationCoroutine()
		{
			return null;
		}
	}
}
