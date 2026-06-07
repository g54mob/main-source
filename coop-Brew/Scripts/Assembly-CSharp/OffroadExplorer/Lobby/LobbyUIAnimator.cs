using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace OffroadExplorer.Lobby
{
	public class LobbyUIAnimator : MonoBehaviour
	{
		public enum SlideDirection
		{
			Left = 0,
			Right = 1,
			Up = 2,
			Down = 3,
			None = 4
		}

		public enum AnimationType
		{
			FadeSlide = 0,
			FadeScale = 1,
			SlideOnly = 2,
			FadeOnly = 3,
			Instant = 4
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass30_0
		{
			public bool exitComplete;

			internal void _003CTransitionCoroutine_003Eb__0()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass30_1
		{
			public bool enterComplete;

			internal void _003CTransitionCoroutine_003Eb__1()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CEnterAnimationCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public Action onComplete;

			public LobbyUIAnimator _003C_003E4__this;

			public SlideDirection direction;

			public AnimationType animationType;

			private Vector2 _003CstartOffset_003E5__2;

			private float _003CstartOpacity_003E5__3;

			private float _003CstartScale_003E5__4;

			private float _003CstartTime_003E5__5;

			private float _003CendTime_003E5__6;

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
			public _003CEnterAnimationCoroutine_003Ed__31(int _003C_003E1__state)
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
		private sealed class _003CExitAnimationCoroutine_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public Action onComplete;

			public LobbyUIAnimator _003C_003E4__this;

			public SlideDirection direction;

			public AnimationType animationType;

			private Vector2 _003CendOffset_003E5__2;

			private float _003CendOpacity_003E5__3;

			private float _003CendScale_003E5__4;

			private float _003CstartTime_003E5__5;

			private float _003CendTime_003E5__6;

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
			public _003CExitAnimationCoroutine_003Ed__32(int _003C_003E1__state)
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
		private sealed class _003CPopInCoroutine_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement element;

			public float duration;

			public LobbyUIAnimator _003C_003E4__this;

			public Action onComplete;

			private float _003CstartTime_003E5__2;

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
			public _003CPopInCoroutine_003Ed__34(int _003C_003E1__state)
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
		private sealed class _003CPunchScaleCoroutine_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public float punchAmount;

			public VisualElement element;

			private float _003CstartTime_003E5__2;

			private float _003ChalfDuration_003E5__3;

			private float _003CmidTime_003E5__4;

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
			public _003CPunchScaleCoroutine_003Ed__33(int _003C_003E1__state)
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
		private sealed class _003CTransitionCoroutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public LobbyUIAnimator _003C_003E4__this;

			public SlideDirection direction;

			public VisualElement exitScreen;

			public AnimationType animationType;

			private _003C_003Ec__DisplayClass30_0 _003C_003E8__1;

			public VisualElement enterScreen;

			private _003C_003Ec__DisplayClass30_1 _003C_003E8__2;

			public Action onComplete;

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
			public _003CTransitionCoroutine_003Ed__30(int _003C_003E1__state)
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

		[Header("Animation Timing")]
		[Tooltip("Duration of screen exit animation")]
		[SerializeField]
		private float exitDuration;

		[Tooltip("Duration of screen enter animation")]
		[SerializeField]
		private float enterDuration;

		[Tooltip("Delay between exit and enter animations")]
		[SerializeField]
		private float transitionDelay;

		[Header("Slide Animation")]
		[Tooltip("How far screens slide (in pixels)")]
		[SerializeField]
		private float slideDistance;

		[Tooltip("Direction for slide animations")]
		[SerializeField]
		private SlideDirection defaultSlideDirection;

		[Header("Scale Animation")]
		[Tooltip("Enable scale animation")]
		[SerializeField]
		private bool useScale;

		[Tooltip("Starting scale for enter animation")]
		[SerializeField]
		private float enterStartScale;

		[Tooltip("Ending scale for exit animation")]
		[SerializeField]
		private float exitEndScale;

		[Header("Easing")]
		[Tooltip("Easing curve for enter animations")]
		[SerializeField]
		private AnimationCurve enterEase;

		[Tooltip("Easing curve for exit animations")]
		[SerializeField]
		private AnimationCurve exitEase;

		private Dictionary<VisualElement, Coroutine> _activeAnimations;

		private bool _isTransitioning;

		public static LobbyUIAnimator Instance { get; private set; }

		public bool IsTransitioning => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void TransitionScreens(VisualElement exitScreen, VisualElement enterScreen, SlideDirection direction = SlideDirection.Right, Action onComplete = null)
		{
		}

		public void TransitionScreens(VisualElement exitScreen, VisualElement enterScreen, SlideDirection direction, AnimationType animationType, Action onComplete = null)
		{
		}

		public void AnimateEnter(VisualElement element, SlideDirection direction = SlideDirection.Right, Action onComplete = null)
		{
		}

		public void AnimateExit(VisualElement element, SlideDirection direction = SlideDirection.Left, Action onComplete = null)
		{
		}

		public void ShowImmediate(VisualElement element)
		{
		}

		public void HideImmediate(VisualElement element)
		{
		}

		public void PunchScale(VisualElement element, float punchAmount = 0.1f, float duration = 0.15f)
		{
		}

		public void PopIn(VisualElement element, float duration = 0.3f, Action onComplete = null)
		{
		}

		[IteratorStateMachine(typeof(_003CTransitionCoroutine_003Ed__30))]
		private IEnumerator TransitionCoroutine(VisualElement exitScreen, VisualElement enterScreen, SlideDirection direction, AnimationType animationType, Action onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CEnterAnimationCoroutine_003Ed__31))]
		private IEnumerator EnterAnimationCoroutine(VisualElement element, SlideDirection direction, AnimationType animationType, Action onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExitAnimationCoroutine_003Ed__32))]
		private IEnumerator ExitAnimationCoroutine(VisualElement element, SlideDirection direction, AnimationType animationType, Action onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPunchScaleCoroutine_003Ed__33))]
		private IEnumerator PunchScaleCoroutine(VisualElement element, float punchAmount, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPopInCoroutine_003Ed__34))]
		private IEnumerator PopInCoroutine(VisualElement element, float duration, Action onComplete)
		{
			return null;
		}

		private void StopAnimationFor(VisualElement element)
		{
		}

		private Vector2 GetSlideOffset(SlideDirection direction, float distance)
		{
			return default(Vector2);
		}

		private SlideDirection GetOppositeDirection(SlideDirection direction)
		{
			return default(SlideDirection);
		}

		private float OvershootEase(float t)
		{
			return 0f;
		}

		public SlideDirection GetDirectionForNavigation(string fromScreen, string toScreen)
		{
			return default(SlideDirection);
		}

		private int GetScreenDepth(string screen)
		{
			return 0;
		}

		private int GetScreenPosition(string screen)
		{
			return 0;
		}
	}
}
