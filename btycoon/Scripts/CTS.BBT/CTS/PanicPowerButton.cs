using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class PanicPowerButton : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Toggle _toggle;

		[SerializeField]
		[Inject(false)]
		private ActionButton _actionButton;

		[SerializeField]
		[Inject(false)]
		private AreaOfEffectPower _power;

		[SerializeField]
		[Inject(false)]
		private CanvasExclusivity _canvasExclusivity;

		[SerializeField]
		private Image _cooldownImage;

		[SerializeField]
		[Min(0.25f)]
		private float _cooldownDuration = 10f;

		private float _currentCooldown;

		public static event Action PowerCast;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			_power.Stopped += OnPowerStopped;
			_power.PowerCast += OnPowerCast;
			InputManager.pause.pause.onComplete += OnInputPause;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.isOn = false;
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
			_power.Stopped -= OnPowerStopped;
			_power.PowerCast -= OnPowerCast;
			InputManager.pause.pause.onComplete -= OnInputPause;
		}

		private void OnInputPause(InputAction.CallbackContext ctx)
		{
			_toggle.isOn = false;
		}

		private void Update()
		{
			if (!_toggle.interactable)
			{
				_currentCooldown += Time.deltaTime;
				_cooldownImage.fillAmount = _currentCooldown / _cooldownDuration;
				if (!(_currentCooldown < _cooldownDuration))
				{
					_toggle.interactable = true;
				}
			}
		}

		private void OnPowerStopped(SimpleAction obj)
		{
			_toggle.isOn = false;
		}

		private void OnPowerCast()
		{
			_currentCooldown = 0f;
			_toggle.interactable = false;
			_cooldownImage.fillAmount = 0f;
			PanicPowerButton.PowerCast?.Invoke();
		}

		private void OnToggleChanged(bool value)
		{
			if (value)
			{
				_canvasExclusivity.CloseExclusivityGroup();
				_actionButton.QuickPlay();
			}
			else
			{
				_actionButton.EndAction();
			}
		}
	}
}
