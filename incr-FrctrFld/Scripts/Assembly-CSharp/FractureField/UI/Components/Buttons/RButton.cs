using System;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.Events;

namespace FractureField.UI.Components.Buttons
{
	[RequireComponent(typeof(ColliderRect))]
	public class RButton : RComponent
	{
		[Serializable]
		public class OnClickEvent : UnityEvent
		{
		}

		[Serializable]
		public class OnDisabledClickEvent : UnityEvent
		{
		}

		[Header("Base")]
		public bool ClickDisabled;

		public bool ExecuteOnMouseDown;

		public bool DisableButtonDownAnimation;

		public bool DisableButtonUpAnimation;

		public bool DoNotAnimate;

		public bool DoNotPlaySound;

		public bool ShowCursorPointer;

		public bool DoNotOverrideZPosition;

		[SerializeField]
		protected BoxCollider2D _collider;

		[SerializeField]
		protected Animator _animator;

		[Header("Events")]
		[SerializeField]
		private OnClickEvent _onClick;

		[SerializeField]
		private OnDisabledClickEvent _onDisabledClick;

		private bool _isMouseDown;

		private Vector3 _startTouchPosition;

		private Vector3 _currentTouchPosition;

		private int _touchId;

		private bool _isDisabled;

		private bool _buttonDownAnimationActive;

		public OnClickEvent OnClick
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OnDisabledClickEvent OnDisabledClick
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RectTransform MustBeInsideRect { get; set; }

		public bool IsDisabled
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		protected virtual void OnIsDisabledChanged()
		{
		}

		protected override void Awake()
		{
		}

		private void Reset()
		{
		}

		protected override void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void HandleMobileTouch()
		{
		}

		private void CancelClickIfMovedTooMuch()
		{
		}

		private bool WithinRectBounds()
		{
			return false;
		}

		private bool HandleMouseDown()
		{
			return false;
		}

		private bool HandleMouseUp(bool triggerOnClick)
		{
			return false;
		}

		private bool MouseUpReturn(bool returnValue)
		{
			return false;
		}

		protected virtual void PlayButtonDownAnimation()
		{
		}

		protected virtual void PlayButtonUpAnimation(float normalizedTime)
		{
		}

		private void ExecuteAction()
		{
		}

		public bool TryMouseDown(Vector3 clickPosition, int touchId)
		{
			return false;
		}

		public bool TryMouseUp()
		{
			return false;
		}
	}
}
