using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Coffee.UIEffects
{
	[ExecuteAlways]
	[RequireComponent(typeof(UIEffectBase))]
	public class UIEffectTweener : MonoBehaviour
	{
		[Serializable]
		public class TweenerEvent : UnityEvent<float>
		{
		}

		[Flags]
		public enum CullingMask
		{
			Tone = 1,
			Color = 2,
			Sampling = 4,
			Transition = 8,
			GradiationOffset = 0x20,
			GradiationRotation = 0x40,
			EdgeShiny = 0x100,
			Event = -2147483648
		}

		public enum UpdateMode
		{
			Normal = 0,
			Unscaled = 1,
			Manual = 2
		}

		public enum WrapMode
		{
			Once = 0,
			Loop = 1,
			PingPongOnce = 2,
			PingPongLoop = 3
		}

		public enum Direction
		{
			Forward = 0,
			Reverse = 1
		}

		public enum PlayOnEnable
		{
			None = 0,
			Forward = 1,
			Reverse = 2,
			KeepDirection = 3
		}

		[Tooltip("The culling mask of the tween.")]
		[SerializeField]
		private CullingMask m_CullingMask;

		[Tooltip("The direction of the tween.")]
		[SerializeField]
		private Direction m_Direction;

		[Tooltip("The curve to tween the properties.")]
		[SerializeField]
		private AnimationCurve m_Curve;

		[SerializeField]
		private bool m_SeparateReverseCurve;

		[Tooltip("The curve to tween the properties.")]
		[SerializeField]
		private AnimationCurve m_ReverseCurve;

		[Tooltip("The delay in seconds before the tween starts.")]
		[SerializeField]
		[Range(0f, 10f)]
		private float m_Delay;

		[Tooltip("The duration in seconds of the tween.")]
		[SerializeField]
		[Range(0.05f, 10f)]
		private float m_Duration;

		[Tooltip("The interval in seconds between each loop.")]
		[SerializeField]
		[Range(0f, 10f)]
		private float m_Interval;

		[FormerlySerializedAs("m_ResetTimeOnEnable")]
		[Tooltip("Play the tween when the component is enabled.")]
		[SerializeField]
		private PlayOnEnable m_PlayOnEnable;

		[Tooltip("Reset the tweening time when the component is enabled.")]
		[SerializeField]
		private bool m_ResetTimeOnEnable;

		[Tooltip("The wrap mode of the tween.\n  Once: Clamp the tween value (not loop).\n  Loop: Loop the tween value.\n  PingPongOnce: PingPong the tween value (not loop).\n  PingPong: PingPong the tween value.")]
		[SerializeField]
		private WrapMode m_WrapMode;

		[Tooltip("Specifies how to get delta time.\n  Normal: Use `Time.deltaTime`.\n  Unscaled: Use `Time.unscaledDeltaTime`.\n  Manual: Not updated automatically and update manually with `UpdateTime` or `SetTime` method.")]
		[SerializeField]
		private UpdateMode m_UpdateMode;

		[Tooltip("Event to invoke when the tween has completed.")]
		[SerializeField]
		private UnityEvent m_OnComplete;

		[Tooltip("Event to invoke when the rate was changed.")]
		[SerializeField]
		private TweenerEvent m_OnChangedRate;

		private bool _isPaused;

		private float _rate;

		private float _time;

		private UIEffectBase _target;

		private UIEffectBase target => null;

		public CullingMask cullingMask
		{
			get
			{
				return default(CullingMask);
			}
			set
			{
			}
		}

		public Direction direction
		{
			get
			{
				return default(Direction);
			}
			set
			{
			}
		}

		public float rate
		{
			get
			{
				return 0f;
			}
			private set
			{
			}
		}

		public float duration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float delay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float interval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float time => 0f;

		public float totalTime => 0f;

		public PlayOnEnable playOnEnable
		{
			get
			{
				return default(PlayOnEnable);
			}
			set
			{
			}
		}

		public bool resetTimeOnEnable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public WrapMode wrapMode
		{
			get
			{
				return default(WrapMode);
			}
			set
			{
			}
		}

		public UpdateMode updateMode
		{
			get
			{
				return default(UpdateMode);
			}
			set
			{
			}
		}

		public AnimationCurve curve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool separateReverseCurve
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public AnimationCurve reverseCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public UnityEvent onComplete => null;

		public TweenerEvent onChangedRate => null;

		public bool isTweening => false;

		public bool isPaused => false;

		public bool isDelaying => false;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void Play(bool resetTime)
		{
		}

		public void Play()
		{
		}

		public void PlayForward(bool resetTime)
		{
		}

		public void PlayForward()
		{
		}

		public void PlayReverse(bool resetTime)
		{
		}

		public void PlayReverse()
		{
		}

		public void Stop()
		{
		}

		public void SetPause(bool pause)
		{
		}

		public void ResetTime()
		{
		}

		public void ResetTime(Direction dir)
		{
		}

		[Obsolete("UIEffectTweener.Restart has been deprecated. Use UIEffectTweener.ResetTime instead (UnityUpgradable) -> ResetTime")]
		public void Restart()
		{
		}

		public void SetTime(float sec)
		{
		}

		public void UpdateTime(float deltaSec)
		{
		}
	}
}
