using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(CanvasGroup))]
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("More Mountains/Tools/GUI/MMFader")]
	public class MMFader : MonoBehaviour, MMEventListener<MMFadeEvent>, MMEventListenerBase, MMEventListener<MMFadeInEvent>, MMEventListener<MMFadeOutEvent>, MMEventListener<MMFadeStopEvent>
	{
		public enum ForcedInitStates
		{
			None = 0,
			Active = 1,
			Inactive = 2
		}

		[Tooltip("the ID for this fader (0 is default), set more IDs if you need more than one fader")]
		[Header("Identification")]
		public int ID;

		[Tooltip("the opacity the fader should be at when inactive")]
		[Header("Opacity")]
		public float InactiveAlpha;

		[Tooltip("the opacity the fader should be at when active")]
		public float ActiveAlpha;

		[Tooltip("determines whether a state should be forced on init")]
		public ForcedInitStates ForcedInitState;

		[Header("Timing")]
		[Tooltip("the default duration of the fade in/out")]
		public float DefaultDuration;

		[Tooltip("the default curve to use for this fader")]
		public MMTweenType DefaultTween;

		[Tooltip("whether or not the fade should happen in unscaled time")]
		public bool IgnoreTimescale;

		[Tooltip("whether or not this fader can cause a fade if the requested final alpha is the same as the current one")]
		public bool CanFadeToCurrentAlpha;

		[Header("Interaction")]
		[Tooltip("whether or not the fader should block raycasts when visible")]
		public bool ShouldBlockRaycasts;

		[Header("Debug")]
		[MMInspectorButton("FadeIn1Second")]
		public bool FadeIn1SecondButton;

		[MMInspectorButton("FadeOut1Second")]
		public bool FadeOut1SecondButton;

		[MMInspectorButton("DefaultFade")]
		public bool DefaultFadeButton;

		[MMInspectorButton("ResetFader")]
		public bool ResetFaderButton;

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
		}

		protected virtual void DefaultFade()
		{
		}

		protected virtual void FadeIn1Second()
		{
		}

		protected virtual void FadeOut1Second()
		{
		}

		protected virtual void Awake()
		{
		}

		protected virtual void Initialization()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void Fade()
		{
		}

		protected virtual void StopFading()
		{
		}

		protected virtual void DisableFader()
		{
		}

		protected virtual void EnableFader()
		{
		}

		protected virtual void StartFading(float initialAlpha, float endAlpha, float duration, MMTweenType curve, int id, bool ignoreTimeScale)
		{
		}

		public virtual void OnMMEvent(MMFadeEvent fadeEvent)
		{
		}

		public virtual void OnMMEvent(MMFadeInEvent fadeEvent)
		{
		}

		public virtual void OnMMEvent(MMFadeOutEvent fadeEvent)
		{
		}

		public virtual void OnMMEvent(MMFadeStopEvent fadeStopEvent)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
