using System.Collections.Generic;
using Easing;
using Factory;
using Motorways.Audio;
using Motorways.UI;
using Screens;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.Views
{
	public abstract class ScrollingButtonScreen : BaseScalingScreen
	{
		public RectTransform buttonParent;

		public ScrollRect scrollRect;

		[SerializeField]
		private float _snapSpeedThreshold = 250f;

		private float _desiredScrollPosition;

		protected readonly List<AnimatedCard> buttons = new List<AnimatedCard>();

		protected int _currentlySelectedButtonIndex;

		private bool _shouldSnapDrag = true;

		private bool _wasDraggedByScrollWheel;

		private Vector3? _originPosition;

		[SerializeField]
		private SafeArea _safeArea;

		private const Easings.Functions ButtonScrollEasing = Easings.Functions.SineEaseInOut;

		protected AnimatedCard CurrentlySelectedButton
		{
			get
			{
				if (Diagnostics.Verify(_currentlySelectedButtonIndex < ButtonCount, "Only have {0}, but trying to get index {1}!", ButtonCount, _currentlySelectedButtonIndex))
				{
					return buttons[_currentlySelectedButtonIndex];
				}
				return buttons[0];
			}
		}

		private bool IsScrolling => _desiredScrollPosition >= 0f;

		public int ButtonCount => buttons.Count;

		public void CancelButtonScrolling()
		{
			_desiredScrollPosition = -1f;
		}

		public override void Tick(float deltaTime)
		{
			base.Tick(deltaTime);
			if (IsScrolling)
			{
				float num = Mathf.Min(deltaTime * 5f, 1f);
				scrollRect.horizontalNormalizedPosition += (_desiredScrollPosition - scrollRect.horizontalNormalizedPosition) * num;
				if (Mathf.Abs(_desiredScrollPosition - scrollRect.horizontalNormalizedPosition) < 0.0001f)
				{
					scrollRect.horizontalNormalizedPosition = _desiredScrollPosition;
					CancelButtonScrolling();
				}
			}
			else if (ButtonCount > 0)
			{
				if (scrollRect.velocity.magnitude < _snapSpeedThreshold && _shouldSnapDrag)
				{
					ScrollToNearestButton();
					_shouldSnapDrag = false;
				}
				if (_wasDraggedByScrollWheel)
				{
					_shouldSnapDrag = true;
					_wasDraggedByScrollWheel = false;
				}
			}
			if (IsVisible())
			{
				_gameCamera.transform.position = GetCameraPosition();
			}
		}

		protected int GetNearestButtonIndex()
		{
			float num = 1f / (float)(buttons.Count - 1);
			return Mathf.RoundToInt(Mathf.Clamp(scrollRect.horizontalNormalizedPosition / num, 0f, buttons.Count - 1));
		}

		public bool HasValidCameraPosition()
		{
			return _originPosition.HasValue;
		}

		public Vector3 GetCameraPosition()
		{
			if (Diagnostics.Verify(_originPosition.HasValue, "Somehow trying to get the camera position when we haven't been initialised!"))
			{
				if (ButtonCount > 1)
				{
					float num = 1f - scrollRect.GetComponent<RectTransform>().sizeDelta.x / buttonParent.sizeDelta.x;
					_rectTransform.anchoredPosition = _originPosition.Value + Vector3.right * (scrollRect.horizontalNormalizedPosition * buttonParent.sizeDelta.x * base.transform.localScale.x * num);
					Vector3 position = base.transform.position;
					position.z = _gameCamera.transform.position.z;
					return position;
				}
				Vector3 value = _originPosition.Value;
				value.z = _gameCamera.transform.position.z;
				return value;
			}
			return Vector3.right * scrollRect.horizontalNormalizedPosition * buttonParent.sizeDelta.x * base.transform.localScale.x;
		}

		public override void TransitionIn(ScreenStack.MotorwaysScreen outScreen)
		{
			base.TransitionIn(outScreen);
			if (Diagnostics.Verify(_safeArea != null, this, "{0} has not been set for {1}", "_safeArea", base.gameObject.name))
			{
				float num = _safeArea.GetComponent<RectTransform>().rect.height / BaseScalingScreen.referenceResolution.y;
				scrollRect.transform.localScale = new Vector3(num, num, num);
			}
			AssignOriginPosition();
			if (buttons.Count != 0)
			{
				ScrollToButton(CurrentlySelectedButton, instantly: true);
			}
			_shouldSnapDrag = true;
		}

		protected void AssignOriginPosition()
		{
			if (!_originPosition.HasValue)
			{
				Vector3 positionFor = _screenStack.GetPositionFor(base.ScreenType);
				float num = 1f - scrollRect.GetComponent<RectTransform>().sizeDelta.x / Mathf.Max(buttonParent.sizeDelta.x, 1f);
				positionFor.z = -0.25f;
				positionFor.x -= scrollRect.horizontalNormalizedPosition * buttonParent.sizeDelta.x * base.transform.localScale.x * num;
				_originPosition = positionFor;
				base.transform.position = positionFor;
			}
		}

		public override void OnTransitionedIn()
		{
			base.OnTransitionedIn();
			_scaleToCamera = false;
		}

		public override void OnCreatedInScope(IScope scope)
		{
			base.OnCreatedInScope(scope);
			scrollRect.onValueChanged.AddListener(SetMapButtonValues);
		}

		public void ScrollToNearestButton()
		{
			if (buttons.Count == 1)
			{
				_desiredScrollPosition = 0f;
				return;
			}
			int nearestButtonIndex = GetNearestButtonIndex();
			if (Diagnostics.Verify(nearestButtonIndex >= 0 && nearestButtonIndex < buttons.Count))
			{
				ScrollToButton(buttons[nearestButtonIndex]);
			}
		}

		public void OnEndDrag()
		{
			_shouldSnapDrag = true;
		}

		public void OnStartDrag()
		{
			_shouldSnapDrag = false;
		}

		public void OnScroll(Vector2 scrollDelta)
		{
			_shouldSnapDrag = false;
			_wasDraggedByScrollWheel = true;
			if (scrollDelta.y > 0f)
			{
				if (_currentlySelectedButtonIndex < buttons.Count - 1)
				{
					ScrollToButton(buttons[_currentlySelectedButtonIndex + 1]);
				}
			}
			else if (scrollDelta.y < 0f && _currentlySelectedButtonIndex > 0)
			{
				ScrollToButton(buttons[_currentlySelectedButtonIndex - 1]);
			}
		}

		protected int IndexOf(AnimatedCard button)
		{
			for (int i = 0; i < buttons.Count; i++)
			{
				if (buttons[i] == button)
				{
					return i;
				}
			}
			Diagnostics.FailAssert("We haven't stored {0} in mapButtons! Defaulting to the first button.", button);
			return 0;
		}

		public virtual void ScrollToButton(AnimatedCard button, bool instantly = false)
		{
			if (buttons != null && buttons.Count > 1)
			{
				if (CurrentlySelectedButton != button)
				{
					_currentlySelectedButtonIndex = IndexOf(button);
				}
				if (instantly)
				{
					scrollRect.horizontalNormalizedPosition = (float)_currentlySelectedButtonIndex / (float)(ButtonCount - 1);
					_desiredScrollPosition = scrollRect.horizontalNormalizedPosition;
				}
				else
				{
					_desiredScrollPosition = (float)_currentlySelectedButtonIndex / (float)(ButtonCount - 1);
					float num = Mathf.Abs(_desiredScrollPosition - scrollRect.horizontalNormalizedPosition);
					if (num > 0.01f)
					{
						SFX.PointerTargetDelta = _desiredScrollPosition - scrollRect.horizontalNormalizedPosition;
						_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Transition, UIAudioProfile.None, num, condition: true, null, ScreenStack.MotorwaysScreen.MapSelect));
						_audioSystem.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.MouseOver, UIAudioProfile.Theme));
					}
				}
			}
			OnSelectButton();
		}

		protected virtual void OnSelectButton()
		{
		}

		protected void SetNewButtons(List<AnimatedCard> newButtons)
		{
			DestroyButtons();
			buttons.AddRange(newButtons);
			foreach (AnimatedCard button in buttons)
			{
				button.transform.SetParent(buttonParent, worldPositionStays: false);
			}
		}

		protected void AddNewButtonToExistingSet(AnimatedCard newButton)
		{
			buttons.Add(newButton);
			Canvas.ForceUpdateCanvases();
			RegisterAllLocalizedTextChildren();
			RegisterButtons();
			RegisterThemeComponents(_themeDatabase.GetTheme());
		}

		protected void SetMapButtonValues(Vector2 position)
		{
			if (ButtonCount <= 0)
			{
				return;
			}
			if (ButtonCount == 1)
			{
				buttons[0].SetHighlightAnimation(0f);
				return;
			}
			float num = 1f / (float)(buttons.Count - 1);
			float x = position.x;
			for (int i = 0; i < buttons.Count; i++)
			{
				float num2 = num * (float)i;
				float num3 = Mathf.Min(Mathf.Abs(x - num2), num);
				float highlightAnimation = Easings.Interpolate(1f - num3 / num, Easings.Functions.SineEaseInOut);
				buttons[i].SetHighlightAnimation(highlightAnimation);
			}
		}

		protected void DestroyButtons()
		{
			if (buttons != null)
			{
				for (int i = 0; i < buttons.Count; i++)
				{
					buttons[i].gameObject.transform.SetParent(null);
					Object.Destroy(buttons[i].gameObject);
				}
				buttons.Clear();
			}
		}

		public override void OnMoveCursor(Selectable currentFocus, MoveDirection direction)
		{
			if (!(currentFocus == firstFocus))
			{
				return;
			}
			switch (direction)
			{
			case MoveDirection.Right:
				if (_currentlySelectedButtonIndex < buttons.Count - 1)
				{
					ScrollToButton(buttons[_currentlySelectedButtonIndex + 1]);
				}
				break;
			case MoveDirection.Left:
				if (_currentlySelectedButtonIndex > 0)
				{
					ScrollToButton(buttons[_currentlySelectedButtonIndex - 1]);
				}
				break;
			}
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			DestroyButtons();
		}

		public override void Reset()
		{
			base.Reset();
			scrollRect.horizontalNormalizedPosition = 0f;
			_desiredScrollPosition = 0f;
			_originPosition = null;
			_scaleToCamera = true;
			_currentlySelectedButtonIndex = 0;
			_shouldSnapDrag = true;
			_wasDraggedByScrollWheel = false;
			base.transform.position = Vector3.zero;
			base.transform.localScale = Vector3.one;
		}
	}
}
