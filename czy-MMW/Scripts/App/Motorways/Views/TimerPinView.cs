using Easing;
using Factory;
using Motorways.Audio;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	public class TimerPinView : MonoBehaviour
	{
		private enum InnerPinState
		{
			None = 0,
			DecreasingScale = 1,
			IncreasingScale = 2
		}

		private const float InnerPinTransitionDuration = 0.6f;

		private const float InnerPinIncreasingScale = 0.69f;

		private const float InnerPinDecreasingScale = 1f;

		[Tooltip("The time a large, instant reduction in the timer will be highlighted and held. This does not include the collapse duration.")]
		[SerializeField]
		private float HoldDuration = 0.5f;

		[Tooltip("How quickly, in units / second, a held portion of the timer will collapse once the hold duration has ended.")]
		[SerializeField]
		private float HoldCollapseSpeed = 0.05f;

		[SerializeField]
		private Easings.Functions _holdCollapseEasing;

		[SerializeField]
		[Tooltip("How far through the timer must be before it will send an alerts. This should be a value from 0 to 1.")]
		private float MinimumProgressForAlert = 0.5f;

		[Tooltip("The time between alerts when the timer is at the minimum for alerts.")]
		[SerializeField]
		private float MaximumTimeBetweenAlerts = 10f;

		[SerializeField]
		[Tooltip("The time between alerts when the timer is full.")]
		private float MinimumTimeBetweenAlerts = 2f;

		[SerializeField]
		[Tooltip("The colour of the timer while it is ticking up.")]
		private Gradient InnerPinIncreasingColor;

		[Tooltip("The colour of the timer while it is ticking down.")]
		[SerializeField]
		private Color InnerPinDecreasingColor = Color.white;

		[Tooltip("The colour of the timer section that is removed when a vehicle picks a pin up from the destination, while the timer is ticking up.")]
		[SerializeField]
		private Gradient InnerPinIncreasingHoldColor;

		[Tooltip("The colour of the timer section that is removed when a vehicle picks a pin up from the destination, while the timer is ticking down.")]
		[SerializeField]
		private Gradient InnerPinDecreasingHoldColor;

		[SerializeField]
		private AnimationCurve _timerCurve = new AnimationCurve();

		private readonly TweenFloat _innerPinScaleTween = new TweenFloat();

		private readonly TweenFloat _innerPinColorTween = new TweenFloat();

		private float _lastTimerProgress;

		private float _timeSinceAlert;

		private bool _isNextAlertInitial;

		private bool _isHoldingProgress;

		private float _holdProgress;

		private float _holdTimer;

		private float _holdProgressAtCollapse;

		private readonly TweenFloat _holdCollapseTween = new TweenFloat();

		[SerializeField]
		private DestinationView _destinationView;

		[SerializeField]
		private MeshRenderer _timerRenderer;

		[SerializeField]
		private Transform _timerPinInterior;

		private ISimulation _simulation;

		private IAudioSystem _audioSystem;

		private GameCamera _gameCamera;

		private static readonly int InnerProgressPropertyId = Shader.PropertyToID("_InnerProgress");

		private static readonly int InnerColorPropertyId = Shader.PropertyToID("_InnerColor");

		private static readonly int OuterProgressPropertyId = Shader.PropertyToID("_OuterProgress");

		private static readonly int OuterColorPropertyId = Shader.PropertyToID("_OuterColor");

		private InnerPinState _innerPinAnimationState;

		public void Initialize(IScope scope)
		{
			_simulation = scope.Get<ISimulation>();
			_audioSystem = scope.Get<IAudioSystem>();
			_gameCamera = scope.Get<GameCamera>();
		}

		public void Reset()
		{
			_innerPinAnimationState = InnerPinState.None;
			_innerPinColorTween.Stop();
			_innerPinScaleTween.Stop();
			_lastTimerProgress = 0f;
			_timeSinceAlert = 0f;
			_isNextAlertInitial = false;
			_isHoldingProgress = false;
			_holdProgress = 0f;
			_holdTimer = 0f;
			_holdProgressAtCollapse = 0f;
			_holdCollapseTween.Reset();
		}

		public void StartHoldAnimation()
		{
			_isHoldingProgress = true;
			_holdProgress = Mathf.Max(_holdProgress, _lastTimerProgress);
			if (_holdProgress > 0f)
			{
				_holdTimer = HoldDuration;
			}
			_holdCollapseTween.Reset();
		}

		public void SetTime(float tickTime, float time, float maxTime, float graceTime, bool isIncreasing, TransitionStyle transitionStyle)
		{
			float num = time / (maxTime - graceTime);
			float num2 = _timerCurve.Evaluate(Mathf.Clamp01(num));
			bool flag = time > maxTime - graceTime;
			if (flag)
			{
				_timerRenderer.material.SetFloat(InnerProgressPropertyId, num);
			}
			else
			{
				_timerRenderer.material.SetFloat(InnerProgressPropertyId, num2);
			}
			float value;
			if (_isHoldingProgress)
			{
				if (_holdProgress > num2)
				{
					if (_holdCollapseTween.IsActive)
					{
						_holdCollapseTween.Tick(tickTime);
						_holdProgress = Mathf.Lerp(_holdProgressAtCollapse, num2, Easings.Interpolate(_holdCollapseTween.Value, _holdCollapseEasing));
						if (!_holdCollapseTween.IsActive)
						{
							_isHoldingProgress = false;
						}
					}
					else
					{
						_holdTimer -= tickTime;
						if (_holdTimer <= 0f)
						{
							_holdTimer = 0f;
							_holdCollapseTween.Start(0f, 1f, (_holdProgress - num2) / HoldCollapseSpeed, Easings.Functions.Linear);
							_holdProgressAtCollapse = _holdProgress;
						}
					}
				}
				else
				{
					_isHoldingProgress = false;
					_holdTimer = 0f;
					_holdProgress = num2;
					_holdCollapseTween.Reset();
				}
				value = _holdProgress;
			}
			else
			{
				_holdProgress = num2;
				value = (flag ? num : _holdProgress);
			}
			_timerRenderer.material.SetFloat(OuterProgressPropertyId, value);
			float num3 = (isIncreasing ? 0.69f : 1f);
			Color color = InnerPinIncreasingColor.Evaluate(num2);
			Color value2 = (isIncreasing ? color : InnerPinDecreasingColor);
			Color color2 = InnerPinIncreasingHoldColor.Evaluate(num2);
			Color color3 = InnerPinDecreasingHoldColor.Evaluate(num2);
			Color value3 = (isIncreasing ? color2 : color3);
			InnerPinState innerPinState = ((!isIncreasing) ? InnerPinState.DecreasingScale : InnerPinState.IncreasingScale);
			if (innerPinState != _innerPinAnimationState)
			{
				_innerPinAnimationState = innerPinState;
				if (transitionStyle == TransitionStyle.Tween && _lastTimerProgress > 0f)
				{
					_innerPinScaleTween.Start(_timerPinInterior.localScale.x, num3, 0.6f, Easings.Functions.SineEaseInOut);
					_innerPinColorTween.Start(_innerPinColorTween.Value, isIncreasing ? 0f : 1f, 0.6f, Easings.Functions.SineEaseInOut);
				}
				else
				{
					_innerPinScaleTween.Stop();
					_innerPinColorTween.Stop();
				}
			}
			if (_innerPinScaleTween.IsActive)
			{
				_innerPinScaleTween.Tick(tickTime);
				_innerPinColorTween.Tick(tickTime);
				num3 = _innerPinScaleTween.Value;
				value2 = Color.Lerp(color, InnerPinDecreasingColor, _innerPinColorTween.Value);
				value3 = Color.Lerp(color2, color3, _innerPinColorTween.Value);
			}
			_timerPinInterior.localScale = new Vector3(num3, num3, 1f);
			_timerRenderer.material.SetColor(InnerColorPropertyId, value2);
			_timerRenderer.material.SetColor(OuterColorPropertyId, value3);
			if (!_simulation.IsPaused)
			{
				UpdateAlertTimer(tickTime, num2, isIncreasing);
			}
			_lastTimerProgress = num2;
		}

		private void UpdateAlertTimer(float tickTime, float timerProgress, bool isTimerIncreasing)
		{
			if (!_simulation.IsPaused)
			{
				_timeSinceAlert += tickTime;
			}
			if (timerProgress < MinimumProgressForAlert || !isTimerIncreasing)
			{
				_isNextAlertInitial = true;
				return;
			}
			float num = Mathf.Lerp(MaximumTimeBetweenAlerts, MinimumTimeBetweenAlerts, (timerProgress - MinimumProgressForAlert) / (1f - MinimumProgressForAlert));
			if (_timeSinceAlert > num)
			{
				_destinationView.CreateImminentFailAlert(_isNextAlertInitial);
				_isNextAlertInitial = false;
				_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.RippleAlert, _destinationView));
				_timeSinceAlert = 0f;
			}
		}
	}
}
