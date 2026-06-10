using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Various/MM Time Manager")]
	public class MMTimeManager : MMSingleton<MMTimeManager>
	{
		[Header("Default Values")]
		[Tooltip("The reference time scale, to which the system will go back to after all time is changed")]
		public float NormalTimeScale = 1f;

		[Header("Impacted Values")]
		[Tooltip("whether or not to update Time.timeScale when changing time scale")]
		public bool UpdateTimescale = true;

		[Tooltip("whether or not to update Time.fixedDeltaTime when changing time scale")]
		public bool UpdateFixedDeltaTime = true;

		[Tooltip("whether or not to update Time.maximumDeltaTime when changing time scale")]
		public bool UpdateMaximumDeltaTime = true;

		[Header("Debug")]
		[Tooltip("the current, real time, time scale")]
		[MMReadOnly]
		public float CurrentTimeScale = 1f;

		[Tooltip("the time scale the system is lerping towards")]
		[MMReadOnly]
		public float TargetTimeScale = 1f;

		[MMInspectorButton("TestButtonToSlowDownTime")]
		public bool TestButton;

		protected Stack<TimeScaleProperties> _timeScaleProperties;

		protected TimeScaleProperties _currentProperty;

		protected TimeScaleProperties _resetProperty;

		protected float _initialFixedDeltaTime;

		protected float _initialMaximumDeltaTime;

		protected float _startedAt;

		protected bool _lerpingBackToNormal;

		protected float _timeScaleLastTime = float.NegativeInfinity;

		protected float _initialTimeScale = 1f;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		protected static void InitializeStatics()
		{
			MMSingleton<MMTimeManager>._instance = null;
		}

		protected virtual void TestButtonToSlowDownTime()
		{
			MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, 0.5f, 3f, lerp: true, 1f, infinite: false);
		}

		protected override void Awake()
		{
			base.Awake();
			PreInitialization();
		}

		public virtual void PreInitialization()
		{
			_timeScaleProperties = new Stack<TimeScaleProperties>();
		}

		protected virtual void Start()
		{
			Initialization();
		}

		public virtual void Initialization()
		{
			TargetTimeScale = NormalTimeScale;
			_initialFixedDeltaTime = Time.fixedDeltaTime;
			_initialMaximumDeltaTime = Time.maximumDeltaTime;
			ApplyTimeScale(NormalTimeScale);
		}

		protected virtual void Update()
		{
			while (_timeScaleProperties.Count > 0)
			{
				_currentProperty = _timeScaleProperties.Peek();
				TargetTimeScale = _currentProperty.TimeScale;
				_currentProperty.Duration -= Time.unscaledDeltaTime;
				_timeScaleProperties.Pop();
				_timeScaleProperties.Push(_currentProperty);
				if (_currentProperty.Duration > 0f || _currentProperty.Infinite)
				{
					break;
				}
				Unfreeze();
			}
			if (_timeScaleProperties.Count == 0)
			{
				TargetTimeScale = NormalTimeScale;
			}
			if (_currentProperty.TimeScaleLerp)
			{
				if (_currentProperty.TimeScaleLerpMode == MMTimeScaleLerpModes.Speed)
				{
					if (_currentProperty.LerpSpeed <= 0f)
					{
						_currentProperty.LerpSpeed = 1f;
					}
					ApplyTimeScale(Mathf.Lerp(Time.timeScale, TargetTimeScale, Time.unscaledDeltaTime * _currentProperty.LerpSpeed));
				}
				else
				{
					if (_currentProperty.TimeScaleLerpMode != MMTimeScaleLerpModes.Duration)
					{
						return;
					}
					float num = Time.unscaledTime - _startedAt;
					float t = MMMaths.Remap(num, 0f, _currentProperty.TimeScaleLerpDuration, 0f, 1f);
					float newValue = MMMaths.Remap(_currentProperty.TimeScaleLerpCurve.Evaluate(t), 0f, 1f, _initialTimeScale, TargetTimeScale);
					ApplyTimeScale(newValue);
					if (num > _currentProperty.TimeScaleLerpDuration)
					{
						ApplyTimeScale(TargetTimeScale);
						if (_lerpingBackToNormal)
						{
							_lerpingBackToNormal = false;
							_timeScaleProperties.Pop();
						}
					}
				}
			}
			else
			{
				ApplyTimeScale(TargetTimeScale);
			}
		}

		protected virtual void ApplyTimeScale(float newValue)
		{
			if (newValue != _timeScaleLastTime)
			{
				if (UpdateTimescale)
				{
					Time.timeScale = newValue;
				}
				if (UpdateFixedDeltaTime && newValue != 0f)
				{
					Time.fixedDeltaTime = _initialFixedDeltaTime * newValue;
				}
				if (UpdateMaximumDeltaTime)
				{
					Time.maximumDeltaTime = _initialMaximumDeltaTime * newValue;
				}
				CurrentTimeScale = Time.timeScale;
				_timeScaleLastTime = CurrentTimeScale;
			}
		}

		protected virtual void SetTimeScale(float newTimeScale)
		{
			_timeScaleProperties.Clear();
			ApplyTimeScale(newTimeScale);
		}

		protected virtual void SetTimeScale(TimeScaleProperties timeScaleProperties)
		{
			if (timeScaleProperties.TimeScaleLerp && timeScaleProperties.TimeScaleLerpMode == MMTimeScaleLerpModes.Duration)
			{
				timeScaleProperties.Duration += timeScaleProperties.TimeScaleLerpDuration;
			}
			_startedAt = Time.unscaledTime;
			_timeScaleProperties.Push(timeScaleProperties);
		}

		public virtual void ResetTimeScale()
		{
			SetTimeScale(NormalTimeScale);
		}

		public virtual void Unfreeze()
		{
			if (_timeScaleProperties.Count > 0)
			{
				_resetProperty = _timeScaleProperties.Peek();
				_timeScaleProperties.Pop();
			}
			if (_timeScaleProperties.Count == 0)
			{
				if (_resetProperty.TimeScaleLerp && _resetProperty.TimeScaleLerpMode == MMTimeScaleLerpModes.Duration && _resetProperty.TimeScaleLerpOnUnfreeze)
				{
					_lerpingBackToNormal = true;
					MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, NormalTimeScale, _resetProperty.TimeScaleLerpDurationOnUnfreeze, _resetProperty.TimeScaleLerp, _resetProperty.LerpSpeed, infinite: true, MMTimeScaleLerpModes.Duration, _resetProperty.TimeScaleLerpCurveOnUnfreeze, _resetProperty.TimeScaleLerpDurationOnUnfreeze);
				}
				else
				{
					ResetTimeScale();
				}
			}
		}

		public virtual void SetTimeScaleTo(float newNormalTimeScale)
		{
			MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, newNormalTimeScale, 0f, lerp: false, 0f, infinite: true);
		}

		public virtual void OnTimeScaleEvent(MMTimeScaleMethods timeScaleMethod, float timeScale, float duration, bool lerp, float lerpSpeed, bool infinite, MMTimeScaleLerpModes timeScaleLerpMode = MMTimeScaleLerpModes.Speed, MMTweenType timeScaleLerpCurve = null, float timeScaleLerpDuration = 0.2f, bool timeScaleLerpOnUnfreeze = false, MMTweenType timeScaleLerpCurveOnUnfreeze = null, float timeScaleLerpDurationOnUnfreeze = 0.2f)
		{
			TimeScaleProperties timeScale2 = new TimeScaleProperties
			{
				TimeScale = timeScale,
				Duration = duration,
				TimeScaleLerp = lerp,
				LerpSpeed = lerpSpeed,
				Infinite = infinite,
				TimeScaleLerpOnUnfreeze = timeScaleLerpOnUnfreeze,
				TimeScaleLerpCurveOnUnfreeze = timeScaleLerpCurveOnUnfreeze,
				TimeScaleLerpDurationOnUnfreeze = timeScaleLerpDurationOnUnfreeze,
				TimeScaleLerpMode = timeScaleLerpMode,
				TimeScaleLerpCurve = timeScaleLerpCurve,
				TimeScaleLerpDuration = timeScaleLerpDuration
			};
			_initialTimeScale = Time.timeScale;
			switch (timeScaleMethod)
			{
			case MMTimeScaleMethods.Reset:
				ResetTimeScale();
				break;
			case MMTimeScaleMethods.For:
				SetTimeScale(timeScale2);
				break;
			case MMTimeScaleMethods.Unfreeze:
				Unfreeze();
				break;
			}
		}

		public virtual void OnMMFreezeFrameEvent(float duration)
		{
			SetTimeScale(new TimeScaleProperties
			{
				Duration = duration,
				TimeScaleLerp = false,
				LerpSpeed = 0f,
				TimeScale = 0f
			});
		}

		private void OnEnable()
		{
			MMFreezeFrameEvent.Register(OnMMFreezeFrameEvent);
			MMTimeScaleEvent.Register(OnTimeScaleEvent);
		}

		private void OnDisable()
		{
			MMFreezeFrameEvent.Unregister(OnMMFreezeFrameEvent);
			MMTimeScaleEvent.Unregister(OnTimeScaleEvent);
		}
	}
}
