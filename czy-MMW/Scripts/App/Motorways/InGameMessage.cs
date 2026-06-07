using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Motorways
{
	public class InGameMessage : MonoBehaviour, IReusable
	{
		private static readonly int Disappear = Animator.StringToHash("Disappear");

		private static readonly int DismissAppear = Animator.StringToHash("DismissAppear");

		[Dependency]
		private Scope _scope;

		[Dependency]
		private MainMenuScreen _mainMenu;

		[Dependency]
		private VisualConstantsData _constants;

		[SerializeField]
		private LocalizedTextUI _text;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private TouchButton _button;

		[SerializeField]
		private Image _dismissIcon;

		private Action _onDismissed;

		private Vector3 _desiredPosition;

		private Vector3 _startPosition;

		private float _currentMovementTimer = -1f;

		private List<IThemeComponent> _messageThemeComponents = new List<IThemeComponent>();

		public void SetMessage(StandaloneLocString standaloneLocString, Action onDismissed)
		{
			_onDismissed = onDismissed;
			_button.Initialize(_scope);
			_text.HandleParentAllocated(_scope);
			_text.LocString = standaloneLocString;
			GetComponentsInChildren(includeInactive: true, _messageThemeComponents);
			_mainMenu.RegisterAdditionalThemeComponents(_messageThemeComponents);
			base.transform.SetParent(_mainMenu.transform, worldPositionStays: false);
			base.transform.position = _mainMenu.inGameMessageStartingPosition.position;
			Canvas.ForceUpdateCanvases();
		}

		public void MoveMessage(Vector3 position)
		{
			_currentMovementTimer = 0f;
			_startPosition = base.transform.position;
			_desiredPosition = position;
		}

		public void SetIcon(bool hasNextMessage)
		{
			_dismissIcon.sprite = (hasNextMessage ? _constants.InGameMessageQueuedIcon : _constants.InGameMessageDismissIcon);
		}

		private void Update()
		{
			if (_currentMovementTimer < _constants.InGameMessageAppearEasingDuration && _currentMovementTimer >= 0f)
			{
				_currentMovementTimer += Time.deltaTime;
				base.transform.position = Vector2.Lerp(_startPosition, _desiredPosition, Easings.Interpolate(_currentMovementTimer / _constants.InGameMessageAppearEasingDuration, _constants.InGameMessageAppearEasingFunction));
				if (_currentMovementTimer >= _constants.InGameMessageAppearEasingDuration)
				{
					base.transform.position = _desiredPosition;
					ShowDismissIcon();
				}
			}
		}

		public void Reset()
		{
			base.transform.localScale = Vector3.one;
			base.transform.localPosition = Vector3.zero;
			_currentMovementTimer = -1f;
			_desiredPosition = Vector3.zero;
			_startPosition = Vector3.zero;
		}

		public void ShowDismissIcon()
		{
			_animator.SetTrigger(DismissAppear);
		}

		public void DismissMessage(bool instantly = false)
		{
			if (instantly)
			{
				OnMessageFullyDismissed();
			}
			else
			{
				_animator.SetTrigger(Disappear);
			}
		}

		public void OnMessageTapped()
		{
			DismissMessage();
		}

		public void OnMessageFullyDismissed()
		{
			_onDismissed?.Invoke();
			_scope.Release(this);
			_mainMenu.UnregisterAdditionalThemeComponents(_messageThemeComponents);
		}
	}
}
