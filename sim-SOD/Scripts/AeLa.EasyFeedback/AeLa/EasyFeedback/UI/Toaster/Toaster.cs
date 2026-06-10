using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace AeLa.EasyFeedback.UI.Toaster
{
	public class Toaster : MonoBehaviour
	{
		public enum PopoutDirection
		{
			Up = 0,
			Down = 1,
			Right = 2,
			Left = 3
		}

		public enum ToastAnchor
		{
			TopLeft = 0,
			TopRight = 1,
			BottomRight = 2,
			BottomLeft = 3
		}

		[CompilerGenerated]
		private sealed class _003CShowToast_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Toaster _003C_003E4__this;

			public string message;

			private Toast _003Ctoast_003E5__2;

			private RectTransform _003Crt_003E5__3;

			private float _003Cspeed_003E5__4;

			private Vector2 _003CpivotIn_003E5__5;

			private Vector2 _003CpivotOut_003E5__6;

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
			public _003CShowToast_003Ed__7(int _003C_003E1__state)
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
		private sealed class _003CSlideAnim_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RectTransform rt;

			public Vector2 from;

			public Vector2 to;

			public float speed;

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
			public _003CSlideAnim_003Ed__8(int _003C_003E1__state)
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

		[FormerlySerializedAs("toastPrefab")]
		[Tooltip("The toast prefab object")]
		[SerializeField]
		protected Toast ToastPrefab;

		[FormerlySerializedAs("viewportAnchor")]
		[Tooltip("Where the toast will appear on screen")]
		[SerializeField]
		protected ToastAnchor ViewportAnchor;

		[Tooltip("Direction the toast will move when it appears")]
		[FormerlySerializedAs("popupDirection")]
		[SerializeField]
		protected PopoutDirection PopupDirection;

		[Tooltip("How long (seconds) a message remains on screen")]
		[FormerlySerializedAs("duration")]
		[SerializeField]
		protected float Duration;

		[FormerlySerializedAs("animationDuration")]
		[Tooltip("How long (seconds) the slide in/out animation takes")]
		[SerializeField]
		protected float AnimationDuration;

		private List<Toast> inactive;

		public void Toast(string message)
		{
		}

		[IteratorStateMachine(typeof(_003CShowToast_003Ed__7))]
		private IEnumerator ShowToast(string message)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSlideAnim_003Ed__8))]
		private IEnumerator SlideAnim(RectTransform rt, Vector2 from, Vector2 to, float speed)
		{
			return null;
		}

		private Toast GetToast(string message)
		{
			return null;
		}

		private void ReturnToast(Toast toast)
		{
		}

		private Vector2 GetAnimationDirection(PopoutDirection direction)
		{
			return default(Vector2);
		}
	}
}
