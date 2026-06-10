using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser.Implementation
{
	public class ViewportRestraint : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[CompilerGenerated]
		private sealed class _003CTransition_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform parent;

			public Vector2 end;

			public bool lockX;

			public bool lockY;

			private Vector2 _003Cstart_003E5__2;

			private Vector2 _003Cdistance_003E5__3;

			private float _003CtimePassed_003E5__4;

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
			public _003CTransition_003Ed__13(int _003C_003E1__state)
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
		private sealed class _003CTransitionHorizontally_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector2 end;

			public Transform parent;

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
			public _003CTransitionHorizontally_003Ed__14(int _003C_003E1__state)
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
		private sealed class _003CTransitionVertically_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Vector2 end;

			public Transform parent;

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
			public _003CTransitionVertically_003Ed__15(int _003C_003E1__state)
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

		public float PercentPaddingHorizontal;

		public float PercentPaddingVertical;

		public bool adjustHorizontally;

		public bool adjustVertically;

		private static float transitionTime;

		public RectTransform Viewport;

		public RectTransform DefaultViewportContainer;

		public RectTransform HorizontalViewportContainer;

		private static IEnumerator HorizontalTransitionCoroutine;

		public void OnSelect(BaseEventData eventData)
		{
		}

		private void BeginTransition(IEnumerator coroutineHandle, IEnumerator coroutine, Vector2 containersNewTargetPosition)
		{
		}

		public void CheckSelectionHorizontalVisibility()
		{
		}

		public void CheckSelectionVerticalVisibility()
		{
		}

		[IteratorStateMachine(typeof(_003CTransition_003Ed__13))]
		private static IEnumerator Transition(Vector2 end, Transform parent, bool lockX, bool lockY)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionHorizontally_003Ed__14))]
		private static IEnumerator TransitionHorizontally(Vector2 end, Transform parent)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTransitionVertically_003Ed__15))]
		private static IEnumerator TransitionVertically(Vector2 end, Transform parent)
		{
			return null;
		}
	}
}
