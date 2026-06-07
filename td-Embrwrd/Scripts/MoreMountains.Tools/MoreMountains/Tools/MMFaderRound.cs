using UnityEngine;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/GUI/MMFaderRound")]
	[RequireComponent(typeof(CanvasGroup))]
	public class MMFaderRound : MonoBehaviour, MMEventListener<MMFadeEvent>, MMEventListenerBase, MMEventListener<MMFadeInEvent>, MMEventListener<MMFadeOutEvent>, MMEventListener<MMFadeStopEvent>
	{
		public enum CameraModes
		{
			Main = 0,
			Override = 1
		}

		[Header("Bindings")]
		public CameraModes CameraMode;

		[MMEnumCondition("CameraMode", new int[] { 1 })]
		public Camera TargetCamera;

		public RectTransform FaderBackground;

		public RectTransform FaderMask;

		[Header("Identification")]
		public int ID;

		[Header("Mask")]
		[MMVector(new string[] { "min", "max" })]
		public Vector2 MaskScale;

		[Header("Timing")]
		public float DefaultDuration;

		public MMTweenType DefaultTween;

		public bool IgnoreTimescale;

		[Header("Interaction")]
		public bool ShouldBlockRaycasts;

		[Header("Debug")]
		public Transform DebugWorldPositionTarget;

		[MMInspectorButton("FadeIn1Second")]
		public bool FadeIn1SecondButton;

		[MMInspectorButton("FadeOut1Second")]
		public bool FadeOut1SecondButton;

		[MMInspectorButton("DefaultFade")]
		public bool DefaultFadeButton;

		[MMInspectorButton("ResetFader")]
		public bool ResetFaderButton;

		protected CanvasGroup _canvasGroup;

		protected float _initialScale;

		protected float _currentTargetScale;

		protected float _currentDuration;

		protected MMTweenType _currentCurve;

		protected bool _fading;

		protected float _fadeStartedAt;

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

		protected virtual void StartFading(float initialAlpha, float endAlpha, float duration, MMTweenType curve, int id, bool ignoreTimeScale, Vector3 worldPosition)
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
