using System.Collections.Generic;
using Factory;
using JetBrains.Annotations;
using Motorways.Audio;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class DestinationPinAnimatorView : MonoBehaviour
	{
		public bool supportsUpgrading = true;

		public bool supportsPinCountParameter;

		public List<DestinationPinView> pins;

		public List<DestinationPinView> overflowPins;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private TimerPinView _timerPin;

		[SerializeField]
		private Transform _timerPinCenter;

		private IAudioSystem _audioSystem;

		private VisualConstantsData _constants;

		private static readonly int BigPinActiveParameterId = Animator.StringToHash("BigPinActive");

		private static readonly int IsUpgradedParameterId = Animator.StringToHash("IsUpgraded");

		private static readonly int PinCountParameterId = Animator.StringToHash("PinCount");

		private DestinationView _destination;

		private float _newPinCooldown;

		private float _newPinPostponement;

		private int _visiblePins = -1;

		private const float MaxAnimationClipDuration = 2f;

		private const int MaxTransitionsToReachIdleState = 6;

		public Vector2 BigPinAlertPosition => _timerPinCenter.position;

		public int VisiblePinCount => _visiblePins;

		private bool IsBigPinVisible
		{
			get
			{
				return _animator.GetBool(BigPinActiveParameterId);
			}
			set
			{
				if (IsBigPinVisible != value)
				{
					_animator.enabled = true;
					_animator.SetBool(BigPinActiveParameterId, value);
				}
				if (!value)
				{
					_newPinPostponement = _constants.PostponementForNewPinsAfterPinRemoved;
					SetPinCount(_visiblePins);
				}
				else
				{
					_newPinPostponement = _constants.PostponementForOverflowPinsAfterBigPin;
				}
			}
		}

		private bool IsUpgraded
		{
			get
			{
				if (supportsUpgrading)
				{
					return _animator.GetBool(IsUpgradedParameterId);
				}
				return false;
			}
			set
			{
				if (supportsUpgrading && IsUpgraded != value)
				{
					_animator.enabled = true;
					_animator.SetBool(IsUpgradedParameterId, value);
				}
			}
		}

		public void Initialize(DestinationView destination, IScope scope)
		{
			Reset();
			_destination = destination;
			_audioSystem = scope.Get<IAudioSystem>();
			_constants = scope.Get<VisualConstantsData>();
			_timerPin.Initialize(scope);
			if (!supportsUpgrading)
			{
				_animator.enabled = true;
			}
			IsUpgraded = _destination.Model.IsUpgraded;
			IsBigPinVisible = _destination.Model.IsOvercrowding;
			SetPinCount(_destination.Model.TotalDemand);
			Theme theme = scope.Get<MotorwaysThemeDatabase>().GetTheme() as Theme;
			if (Diagnostics.Verify(theme != null))
			{
				SetPinColors(theme.GetBuildingColor(destination.groupIndex, ThemeComponentGroupTarget.BuildingTop));
			}
		}

		public void Tick(TimeInterval timeInterval, float stepAlpha, float gracePeriod)
		{
			if (!(_destination != null))
			{
				return;
			}
			if (_newPinPostponement > 0f)
			{
				_newPinPostponement = Mathf.Max(0f, _newPinPostponement - timeInterval.ScaledDelta);
			}
			if (_newPinCooldown > 0f)
			{
				_newPinCooldown = Mathf.Max(0f, _newPinCooldown - timeInterval.ScaledDelta);
			}
			if (_visiblePins < _destination.Model.TotalDemand)
			{
				if (_newPinPostponement <= 0f && _newPinCooldown <= 0f)
				{
					SetPinCount(_visiblePins + 1);
					_newPinCooldown = _constants.CooldownTimeBetweenNewPins;
				}
			}
			else if (_visiblePins > _destination.Model.TotalDemand)
			{
				SetPinCount(_visiblePins - 1);
			}
			float midStepOvercrowdingTime = _destination.Model.GetMidStepOvercrowdingTime(stepAlpha);
			if (!IsBigPinVisible)
			{
				if (midStepOvercrowdingTime > _constants.MinOvercrowdingTimeBeforeTimerPin)
				{
					IsBigPinVisible = true;
					_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.DestinationOvercrowding, _destination));
				}
				return;
			}
			if (midStepOvercrowdingTime <= 0f)
			{
				IsBigPinVisible = false;
				_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.DestinationOvercrowding, _destination, condition: false));
			}
			_timerPin.SetTime(timeInterval.Delta, midStepOvercrowdingTime, _destination.MaxOvercrowdingTime, gracePeriod, _destination.Model.IsOvercrowding, TransitionStyle.Tween);
		}

		public void Upgrade()
		{
			IsUpgraded = true;
		}

		public void SetPinColors(Color color)
		{
			foreach (DestinationPinView pin in pins)
			{
				pin.SetPinColor(color);
			}
			foreach (DestinationPinView overflowPin in overflowPins)
			{
				overflowPin.SetPinColor(color);
			}
		}

		public bool RemovePinForVehicleArrival()
		{
			int num = SetPinCount(_visiblePins - 1);
			_newPinPostponement = _constants.PostponementForNewPinsAfterPinRemoved;
			_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.VehicleFulfillsDemand, _destination));
			_timerPin.StartHoldAnimation();
			return num < 0;
		}

		public void Reset()
		{
			if (supportsUpgrading)
			{
				_animator.SetBool(IsUpgradedParameterId, value: false);
			}
			if (supportsPinCountParameter)
			{
				_animator.SetInteger(PinCountParameterId, 0);
			}
			_animator.SetBool(BigPinActiveParameterId, value: false);
			FlushAnimator();
			_animator.enabled = false;
			_newPinCooldown = 0f;
			_visiblePins = -1;
			_destination = null;
		}

		private void Awake()
		{
			_animator.enabled = false;
			foreach (DestinationPinView pin in pins)
			{
				pin.Hidden += OnPinHidden;
			}
			foreach (DestinationPinView overflowPin in overflowPins)
			{
				overflowPin.Hidden += OnPinHidden;
			}
		}

		private void OnEnable()
		{
			foreach (DestinationPinView pin in pins)
			{
				pin.Reset();
			}
			foreach (DestinationPinView overflowPin in overflowPins)
			{
				overflowPin.Reset();
			}
			if (!(_destination != null) || _destination.Model == null)
			{
				return;
			}
			SetPinCount(_destination.Model.TotalDemand);
			FlushAnimator();
			foreach (DestinationPinView pin2 in pins)
			{
				pin2.FlushAnimator();
			}
			foreach (DestinationPinView overflowPin2 in overflowPins)
			{
				overflowPin2.FlushAnimator();
			}
			IsUpgraded = _destination.Model.IsUpgraded;
		}

		[UsedImplicitly]
		private void OnBigPinFinishAppearing()
		{
			_destination.CreateBigPinAlert();
			_newPinPostponement = _constants.PostponementForOverflowPinsAfterBigPin;
		}

		private int SetPinCount(int count)
		{
			int visiblePins = _visiblePins;
			if (supportsPinCountParameter)
			{
				_animator.SetInteger(PinCountParameterId, count);
			}
			_visiblePins = count;
			int num = 0;
			if (count > _destination.Model.MaximumDemandBeforeTimerStarts)
			{
				num = count - _destination.Model.MaximumDemandBeforeTimerStarts;
				count = _destination.Model.MaximumDemandBeforeTimerStarts;
				if (!IsBigPinVisible)
				{
					_visiblePins = count;
				}
			}
			if (_visiblePins > 0 && _visiblePins > visiblePins)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.DestinationDemanded, _destination));
			}
			int num2 = 0;
			for (int i = 0; i < pins.Count; i++)
			{
				DestinationPinView destinationPinView = pins[i];
				bool isVisible = destinationPinView.IsVisible;
				if (i < count && !IsBigPinVisible)
				{
					if (!isVisible)
					{
						num2++;
					}
					destinationPinView.Show();
				}
				else
				{
					if (isVisible)
					{
						num2--;
					}
					destinationPinView.Hide();
				}
			}
			for (int j = 0; j < overflowPins.Count; j++)
			{
				DestinationPinView destinationPinView2 = overflowPins[j];
				bool isVisible2 = destinationPinView2.IsVisible;
				if (j < num && IsBigPinVisible)
				{
					if (!isVisible2)
					{
						num2++;
					}
					destinationPinView2.Show();
				}
				else
				{
					if (isVisible2)
					{
						num2--;
					}
					destinationPinView2.Hide();
				}
			}
			return num2;
		}

		private void OnPinHidden(DestinationPinView pinView)
		{
			if (_destination != null)
			{
				_destination.OnPinHidden();
			}
		}

		[UsedImplicitly]
		private void OnSquareIdle()
		{
			if (!IsBigPinVisible && !IsUpgraded && supportsUpgrading)
			{
				DisableAnimator();
			}
		}

		[UsedImplicitly]
		private void OnSquareBigPinIdle()
		{
			if (IsBigPinVisible && !IsUpgraded && supportsUpgrading)
			{
				DisableAnimator();
			}
		}

		[UsedImplicitly]
		private void OnCircleIdle()
		{
			if (!IsBigPinVisible && IsUpgraded && supportsUpgrading)
			{
				DisableAnimator();
			}
		}

		[UsedImplicitly]
		private void OnCircleBigPinIdle()
		{
			if (IsBigPinVisible && IsUpgraded && supportsUpgrading)
			{
				DisableAnimator();
			}
		}

		private void DisableAnimator()
		{
			_animator.enabled = false;
			_animator.Update(float.Epsilon);
		}

		private void FlushAnimator()
		{
			for (int i = 0; i < 6; i++)
			{
				if (_animator.gameObject.activeInHierarchy)
				{
					_animator.Update(2f);
				}
			}
		}
	}
}
