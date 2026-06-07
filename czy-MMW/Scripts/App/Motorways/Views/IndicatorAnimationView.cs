using System;
using Client;
using Easing;
using Factory.Pools;
using FixMath;
using JetBrains.Annotations;
using UnityEngine;

namespace Motorways.Views
{
	public class IndicatorAnimationView : MonoBehaviour, IView, IReusable
	{
		public enum AnimationType
		{
			Tap = 0,
			Drag = 1,
			Highlight = 2,
			Alert = 3
		}

		private enum AnimationState
		{
			Started = 0,
			ExplicitlyControlled = 1,
			Finished = 2
		}

		private AnimationType _animationType;

		private Vector3 _startingPoint;

		private Vector3 _endPoint;

		private Animator _animator;

		[SerializeField]
		private SpriteRenderer _icon;

		[SerializeField]
		[EnumTypedArray(typeof(NotificationView.AlertIconType))]
		private Sprite[] _iconTypes = new Sprite[Enum.GetValues(typeof(NotificationView.AlertIconType)).Length];

		private float _dragLerp;

		private AnimationState _animationState;

		private const float DragDuration = 3f;

		private static readonly int TapTrigger = Animator.StringToHash("tap");

		private static readonly int StartDragTrigger = Animator.StringToHash("startDrag");

		private static readonly int EndDragTrigger = Animator.StringToHash("endDrag");

		private static readonly int HighlightTrigger = Animator.StringToHash("startHighlight");

		private static readonly int EndHighlightTrigger = Animator.StringToHash("endHighlight");

		private static readonly int AlertStartTrigger = Animator.StringToHash("startAlert");

		private static readonly int AlertEndTrigger = Animator.StringToHash("endAlert");

		public AnimationType Animation => _animationType;

		public Fix64 Duration
		{
			get
			{
				if (Animation == AnimationType.Tap)
				{
					return Fix64Consts.Two;
				}
				if (Animation == AnimationType.Drag)
				{
					return (Fix64)3f + Fix64Consts.Two + Fix64Consts.Two;
				}
				return Fix64Consts.Two;
			}
		}

		public void Reset()
		{
			_animator = null;
			_dragLerp = 0f;
			_animationState = AnimationState.Started;
			base.transform.position = Vector3.zero;
			_animationType = AnimationType.Tap;
			_startingPoint = default(Vector3);
			_endPoint = default(Vector3);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_animationType == AnimationType.Drag)
			{
				if (_animationState == AnimationState.ExplicitlyControlled && _dragLerp < 1f)
				{
					_dragLerp += timeInterval.Delta * (1f / 3f);
					base.transform.position = Vector3.Lerp(_startingPoint, _endPoint, Easings.QuadraticEaseInOut(_dragLerp));
					if (_dragLerp >= 1f)
					{
						_animator.SetTrigger(EndDragTrigger);
					}
				}
				return TickResult.ContinueTicking;
			}
			if (_animationState != AnimationState.Finished)
			{
				return TickResult.ContinueTicking;
			}
			return TickResult.Destroy;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		[UsedImplicitly]
		public void Animator_OnDragStartFinished()
		{
			_animationState = AnimationState.ExplicitlyControlled;
		}

		[UsedImplicitly]
		public void Animator_OnDragEndFinished()
		{
			_animationState = AnimationState.Finished;
		}

		[UsedImplicitly]
		public void Animator_OnHighlightEndFinished()
		{
			_animationState = AnimationState.Finished;
		}

		[UsedImplicitly]
		public void Animator_OnTapFinished()
		{
			_animationState = AnimationState.Finished;
		}

		[UsedImplicitly]
		public void Animator_OnAlertFinished()
		{
			_animationState = AnimationState.Finished;
		}

		public void OnAnimationRelease()
		{
			_dragLerp = 0f;
			if (_animationType == AnimationType.Highlight)
			{
				_animator.SetTrigger(EndHighlightTrigger);
			}
			else if (_animationType == AnimationType.Alert)
			{
				_animator.SetTrigger(AlertEndTrigger);
			}
		}

		public void SetAlertType(NotificationView.AlertIconType type)
		{
			_icon.sprite = _iconTypes[(int)type];
		}

		public void Initialize(AnimationType type, Vector3 start, Vector3? end = null)
		{
			_animationType = type;
			_startingPoint = start;
			_endPoint = end ?? ((Vector3)Vector2.zero);
			_animator = base.gameObject.GetComponent<Animator>();
			base.transform.position = start;
			if (_animationType == AnimationType.Drag)
			{
				_animator.SetTrigger(StartDragTrigger);
			}
			else if (_animationType == AnimationType.Tap)
			{
				_animator.SetTrigger(TapTrigger);
			}
			else if (_animationType == AnimationType.Highlight)
			{
				_animator.SetTrigger(HighlightTrigger);
			}
			else if (_animationType == AnimationType.Alert)
			{
				_animator.SetTrigger(AlertStartTrigger);
			}
		}
	}
}
