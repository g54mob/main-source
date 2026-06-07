using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(CanvasGroup))]
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("More Mountains/Tools/GUI/MM Fader")]
	public class MMFader : MMMonoBehaviour, MMEventListener<MMFadeEvent>, MMEventListenerBase, MMEventListener<MMFadeInEvent>, MMEventListener<MMFadeOutEvent>, MMEventListener<MMFadeStopEvent>
	{
		public enum ForcedInitStates
		{
			None = 0,
			Active = 1,
			Inactive = 2
		}

		[MMInspectorGroup("Identification", true, 122, false)]
		[Tooltip("the ID for this fader (0 is default), set more IDs if you need more than one fader")]
		public int ID;

		[MMInspectorGroup("Opacity", true, 123, false)]
		[Tooltip("the opacity the fader should be at when inactive")]
		public float InactiveAlpha;

		[Tooltip("the opacity the fader should be at when active")]
		public float ActiveAlpha = 1f;

		[Tooltip("determines whether a state should be forced on init")]
		public ForcedInitStates ForcedInitState = ForcedInitStates.Inactive;

		[MMInspectorGroup("Timing", true, 124, false)]
		[Tooltip("the default duration of the fade in/out")]
		public float DefaultDuration = 0.2f;

		[Tooltip("the default curve to use for this fader")]
		public MMTweenType DefaultTween = new MMTweenType(MMTween.MMTweenCurve.LinearTween, "", "");

		[Tooltip("whether or not the fade should happen in unscaled time")]
		public bool IgnoreTimescale = true;

		[Tooltip("whether or not this fader can cause a fade if the requested final alpha is the same as the current one")]
		public bool CanFadeToCurrentAlpha = true;

		[MMInspectorGroup("Interaction", true, 125, false)]
		[Tooltip("whether or not the fader should block raycasts when visible")]
		public bool ShouldBlockRaycasts;

		[MMInspectorGroup("Debug", true, 126, false)]
		[MMInspectorButtonBar(new string[] { "FadeIn1Second", "FadeOut1Second", "DefaultFade", "ResetFader" }, new string[] { "FadeIn1Second", "FadeOut1Second", "DefaultFade", "ResetFader" }, new bool[] { true, true, true, true }, new string[] { "main-call-to-action", "", "", "" })]
		public bool DebugToolbar;

		protected CanvasGroup _canvasGroup;

		protected Image _image;

		protected float _initialAlpha;

		protected float _currentTargetAlpha;

		protected float _currentDuration;

		protected MMTweenType _currentCurve;

		protected bool _fading;

		protected float _fadeStartedAt;

		protected bool _frameCountOne;

		protected virtual void ResetFader()
		{
			_canvasGroup.alpha = InactiveAlpha;
		}

		protected virtual void DefaultFade()
		{
			MMFadeEvent.Trigger(DefaultDuration, ActiveAlpha, DefaultTween, ID);
		}

		protected virtual void FadeIn1Second()
		{
			MMFadeInEvent.Trigger(1f, new MMTweenType(MMTween.MMTweenCurve.LinearTween, "", ""));
		}

		protected virtual void FadeOut1Second()
		{
			MMFadeOutEvent.Trigger(1f, new MMTweenType(MMTween.MMTweenCurve.LinearTween, "", ""));
		}

		protected virtual void Awake()
		{
			Initialization();
		}

		protected virtual void Initialization()
		{
			_canvasGroup = GetComponent<CanvasGroup>();
			_image = GetComponent<Image>();
			if (ForcedInitState == ForcedInitStates.Inactive)
			{
				_canvasGroup.alpha = InactiveAlpha;
				_image.enabled = false;
			}
			else if (ForcedInitState == ForcedInitStates.Active)
			{
				_canvasGroup.alpha = ActiveAlpha;
				_image.enabled = true;
			}
		}

		protected virtual void Update()
		{
			if (!(_canvasGroup == null) && _fading)
			{
				Fade();
			}
		}

		protected virtual void Fade()
		{
			float num = (IgnoreTimescale ? Time.unscaledTime : Time.time);
			if (_frameCountOne)
			{
				if (Time.frameCount <= 2)
				{
					_canvasGroup.alpha = _initialAlpha;
					return;
				}
				_fadeStartedAt = (IgnoreTimescale ? Time.unscaledTime : Time.time);
				num = _fadeStartedAt;
				_frameCountOne = false;
			}
			float endTime = _fadeStartedAt + _currentDuration;
			if (num - _fadeStartedAt < _currentDuration)
			{
				float alpha = MMTween.Tween(num, _fadeStartedAt, endTime, _initialAlpha, _currentTargetAlpha, _currentCurve);
				_canvasGroup.alpha = alpha;
			}
			else
			{
				StopFading();
			}
		}

		protected virtual void StopFading()
		{
			_canvasGroup.alpha = _currentTargetAlpha;
			_fading = false;
			if (_canvasGroup.alpha == InactiveAlpha)
			{
				DisableFader();
			}
		}

		protected virtual void DisableFader()
		{
			_image.enabled = false;
			if (ShouldBlockRaycasts)
			{
				_canvasGroup.blocksRaycasts = false;
			}
		}

		protected virtual void EnableFader()
		{
			_image.enabled = true;
			if (ShouldBlockRaycasts)
			{
				_canvasGroup.blocksRaycasts = true;
			}
		}

		protected virtual void StartFading(float initialAlpha, float endAlpha, float duration, MMTweenType curve, bool ignoreTimeScale)
		{
			if (CanFadeToCurrentAlpha || _canvasGroup.alpha != endAlpha)
			{
				IgnoreTimescale = ignoreTimeScale;
				EnableFader();
				_fading = true;
				_initialAlpha = initialAlpha;
				_currentTargetAlpha = endAlpha;
				_fadeStartedAt = (IgnoreTimescale ? Time.unscaledTime : Time.time);
				_currentCurve = curve;
				_currentDuration = duration;
				if (Time.frameCount == 1)
				{
					_frameCountOne = true;
				}
			}
		}

		public virtual void OnMMEvent(MMFadeEvent fadeEvent)
		{
			if (fadeEvent.ID == ID)
			{
				Fade(fadeEvent.TargetAlpha, fadeEvent.Duration, fadeEvent.Curve, fadeEvent.IgnoreTimeScale);
			}
		}

		public virtual void OnMMEvent(MMFadeInEvent fadeEvent)
		{
			if (fadeEvent.ID == ID)
			{
				FadeIn(fadeEvent.Duration, fadeEvent.Curve, fadeEvent.IgnoreTimeScale);
			}
		}

		public virtual void OnMMEvent(MMFadeOutEvent fadeEvent)
		{
			if (fadeEvent.ID == ID)
			{
				FadeOut(fadeEvent.Duration, fadeEvent.Curve, fadeEvent.IgnoreTimeScale);
			}
		}

		public virtual void Fade(float targetAlpha, float duration, MMTweenType curve, bool ignoreTimeScale)
		{
			_currentTargetAlpha = ((targetAlpha == -1f) ? ActiveAlpha : targetAlpha);
			StartFading(_canvasGroup.alpha, _currentTargetAlpha, duration, curve, ignoreTimeScale);
		}

		public virtual void FadeIn(float duration, MMTweenType curve, bool ignoreTimeScale = true)
		{
			StartFading(InactiveAlpha, ActiveAlpha, duration, curve, ignoreTimeScale);
		}

		public virtual void FadeOut(float duration, MMTweenType curve, bool ignoreTimeScale = true)
		{
			StartFading(ActiveAlpha, InactiveAlpha, duration, curve, ignoreTimeScale);
		}

		public virtual void OnMMEvent(MMFadeStopEvent fadeStopEvent)
		{
			if (fadeStopEvent.ID == ID)
			{
				_fading = false;
				if (fadeStopEvent.Restore)
				{
					_canvasGroup.alpha = _initialAlpha;
				}
			}
		}

		protected virtual void OnEnable()
		{
			this.MMEventStartListening<MMFadeEvent>();
			this.MMEventStartListening<MMFadeStopEvent>();
			this.MMEventStartListening<MMFadeInEvent>();
			this.MMEventStartListening<MMFadeOutEvent>();
		}

		protected virtual void OnDisable()
		{
			this.MMEventStopListening<MMFadeEvent>();
			this.MMEventStopListening<MMFadeStopEvent>();
			this.MMEventStopListening<MMFadeInEvent>();
			this.MMEventStopListening<MMFadeOutEvent>();
		}
	}
}
