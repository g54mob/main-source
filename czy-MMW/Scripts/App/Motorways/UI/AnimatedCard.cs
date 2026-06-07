using System;
using Easing;
using Factory;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways.UI
{
	public abstract class AnimatedCard : TouchButton
	{
		public enum ExpansionLevel
		{
			Narrow = 0,
			Medium = 1,
			Wide = 2
		}

		[SerializeField]
		private Vector2 minimumShadowOffset = new Vector2(15f, -15f);

		[SerializeField]
		private float selectedZoomLevel = 2.5f;

		[SerializeField]
		private RectTransform _shadowRect;

		[SerializeField]
		private RectTransform _mainPanelRect;

		[SerializeField]
		private RectTransform _offsetRect;

		[SerializeField]
		private DelegateCanvasGroup _canvasGroup;

		[SerializeField]
		private Easings.Functions expandedPushOutEaseType = Easings.Functions.CubicEaseIn;

		[SerializeField]
		private Easings.Functions expandedReturnEaseType = Easings.Functions.CubicEaseOut;

		[SerializeField]
		private float _expandedPushOutDuration = 0.335f;

		[SerializeField]
		protected Animator _animator;

		private const float DefaultWidth = 432f;

		private const float MediumWidth = 550f;

		private const float ExpandedWidth = 770f;

		private const float MediumNeighbourOffset = 100f;

		private const float WideNeighbourOffset = 200f;

		private bool _isHiddenLeft;

		private bool _isHiddenRight;

		private bool _pushLeft;

		private float _delayBeforePush = -1f;

		private IScope _scope;

		private Action OnAppear;

		private readonly TweenFloat _pushOffset = new TweenFloat();

		private static readonly int Flip = Animator.StringToHash("Flip");

		private static readonly int PushedLeft = Animator.StringToHash("PushedLeft");

		private static readonly int PushedRight = Animator.StringToHash("PushedRight");

		private static readonly int Confirmed = Animator.StringToHash("Confirmed");

		private static readonly int HiddenLeft = Animator.StringToHash("HiddenLeft");

		private static readonly int HiddenRight = Animator.StringToHash("HiddenRight");

		public DelegateCanvasGroup CanvasGroup => _canvasGroup;

		public bool IsHidden
		{
			get
			{
				if (!_isHiddenLeft)
				{
					return _isHiddenRight;
				}
				return true;
			}
		}

		public event Action onAnimationMidFlip;

		public event Action onFlipAnimationComplete;

		public virtual void RegisterThemeComponents()
		{
		}

		public virtual void UnregisterThemeComponents()
		{
		}

		protected virtual void Update()
		{
			if (_pushOffset.IsActive)
			{
				_pushOffset.Tick(Time.deltaTime);
				_offsetRect.localPosition = Vector3.right * _pushOffset.Value;
			}
			if (!(_delayBeforePush >= 0f))
			{
				return;
			}
			_delayBeforePush -= Time.deltaTime;
			if (_delayBeforePush < 0f)
			{
				if (_pushLeft)
				{
					_animator.SetBool(PushedLeft, value: true);
				}
				else
				{
					_animator.SetBool(PushedRight, value: true);
				}
			}
		}

		public static void SetNavigationOnRight(Selectable selectable, Selectable selectOnRight)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnRight = selectOnRight;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnLeft(Selectable selectable, Selectable selectOnLeft)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnLeft = selectOnLeft;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnUp(Selectable selectable, Selectable selectOnUp)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnUp = selectOnUp;
			selectable.navigation = navigation;
		}

		public static void SetNavigationOnDown(Selectable selectable, Selectable selectOnDown)
		{
			Navigation navigation = selectable.navigation;
			navigation.selectOnDown = selectOnDown;
			selectable.navigation = navigation;
		}

		public void SetHighlightAnimation(float transitionAmount)
		{
			SetHeightOffGrid(transitionAmount);
		}

		public void SetHeightOffGrid(float relativeHeight)
		{
			_shadowRect.anchoredPosition = minimumShadowOffset + new Vector2(selectedZoomLevel * (minimumShadowOffset.x / 2f) * relativeHeight, selectedZoomLevel * (minimumShadowOffset.y / 2f) * relativeHeight);
			_shadowRect.localScale = Vector3.one + new Vector3(relativeHeight * 0.1f * selectedZoomLevel, relativeHeight * 0.1f * selectedZoomLevel);
			_mainPanelRect.localScale = Vector3.one + new Vector3(relativeHeight * 0.1f * selectedZoomLevel, relativeHeight * 0.1f * selectedZoomLevel);
			SetSelectedValue(relativeHeight);
		}

		public virtual void SetSelectedValue(float distance)
		{
		}

		public void SetOffset(ExpansionLevel offsetLevel, bool isPushedLeft = false)
		{
			float num = offsetLevel switch
			{
				ExpansionLevel.Narrow => 0f, 
				ExpansionLevel.Medium => 100f, 
				ExpansionLevel.Wide => 200f, 
				_ => 0f, 
			};
			if (isPushedLeft)
			{
				num *= -1f;
			}
			_pushOffset.Start(_offsetRect.localPosition.x, num, _expandedPushOutDuration, expandedPushOutEaseType);
		}

		public virtual void OnOtherCardConfirmed(bool pushLeft, float delay)
		{
			_delayBeforePush = delay;
			_pushLeft = pushLeft;
			_canvasGroup.SetInteractable(isInteractable: false);
		}

		public virtual void OnCardConfirmed()
		{
			_animator.SetBool(Confirmed, value: true);
			_canvasGroup.SetInteractable(isInteractable: false);
		}

		protected virtual void SetExpanded(ExpansionLevel expansionLevel)
		{
			GetComponent<RectTransform>().sizeDelta = new Vector2(expansionLevel switch
			{
				ExpansionLevel.Narrow => 432f, 
				ExpansionLevel.Medium => 550f, 
				ExpansionLevel.Wide => 770f, 
				_ => 432f, 
			}, GetComponent<RectTransform>().sizeDelta.y);
		}

		public void ResetAnimations()
		{
			_animator.SetBool(PushedLeft, value: false);
			_animator.SetBool(PushedRight, value: false);
			_animator.SetBool(Confirmed, value: false);
			_animator.Update(1f);
		}

		[UsedImplicitly]
		public void OnAnimationMidFlip()
		{
			this.onAnimationMidFlip?.Invoke();
		}

		[UsedImplicitly]
		public void OnFlipAnimationComplete()
		{
			this.onFlipAnimationComplete?.Invoke();
		}

		public virtual void OnTabSelectMidFlip()
		{
			onAnimationMidFlip -= OnTabSelectMidFlip;
		}

		public void TweenToNextCard()
		{
			_animator.SetTrigger(Flip);
		}

		public void SetHideLeft()
		{
			_animator.SetBool(HiddenLeft, value: true);
			_canvasGroup.Alpha = 0f;
			_isHiddenLeft = true;
		}

		public void EnterFromHidden(Action onComplete = null)
		{
			_canvasGroup.Alpha = 1f;
			OnAppear = onComplete;
			if (_isHiddenLeft)
			{
				_animator.SetBool(HiddenLeft, value: false);
			}
			else if (_isHiddenRight)
			{
				_animator.SetBool(HiddenRight, value: false);
			}
		}

		public void OnEnteredFromLeft()
		{
			_isHiddenLeft = false;
			OnAppear?.Invoke();
		}

		public void SetHideRight()
		{
			_animator.SetBool(HiddenRight, value: true);
			_canvasGroup.Alpha = 0f;
			_isHiddenRight = true;
		}

		public void OnEnteredFromRight()
		{
			_isHiddenRight = false;
			OnAppear?.Invoke();
		}
	}
}
