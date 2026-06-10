using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Camera/MM Camera Zoom")]
	public class MMCameraZoom : MonoBehaviour
	{
		[Header("Channel")]
		[MMFInspectorGroup("Shaker Settings", true, 3, false, false)]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMFEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMFEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Header("Transition Speed")]
		[Tooltip("the animation curve to apply to the zoom transition")]
		public MMTweenType ZoomTween = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f)), "", "");

		[Header("Test Zoom")]
		[Tooltip("the mode to apply the zoom in when using the test button in the inspector")]
		public MMCameraZoomModes TestMode;

		[Tooltip("the target field of view to apply the zoom in when using the test button in the inspector")]
		public float TestFieldOfView = 30f;

		[Tooltip("the transition duration to apply the zoom in when using the test button in the inspector")]
		public float TestTransitionDuration = 0.1f;

		[Tooltip("the duration to apply the zoom in when using the test button in the inspector")]
		public float TestDuration = 0.05f;

		[MMFInspectorButton("TestZoom")]
		public bool TestZoomButton;

		protected Camera _camera;

		protected float _initialFieldOfView;

		protected MMCameraZoomModes _mode;

		protected bool _zooming;

		protected float _startFieldOfView;

		protected float _transitionDuration;

		protected float _duration;

		protected float _targetFieldOfView;

		protected int _direction = 1;

		protected float _reachedDestinationTimestamp;

		protected bool _destinationReached;

		protected float _elapsedTime;

		protected float _zoomStartedAt;

		public virtual TimescaleModes TimescaleMode { get; set; }

		public virtual float GetTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Awake()
		{
			_camera = base.gameObject.GetComponent<Camera>();
			_initialFieldOfView = _camera.fieldOfView;
		}

		protected virtual void Update()
		{
			if (!_zooming)
			{
				return;
			}
			_elapsedTime = GetTime() - _zoomStartedAt;
			if (_elapsedTime <= _transitionDuration)
			{
				float t = MMMaths.Remap(_elapsedTime, 0f, _transitionDuration, 0f, 1f);
				_camera.fieldOfView = Mathf.LerpUnclamped(_startFieldOfView, _targetFieldOfView, ZoomTween.Evaluate(t));
				return;
			}
			if (!_destinationReached)
			{
				_reachedDestinationTimestamp = GetTime();
				_destinationReached = true;
			}
			if (_mode == MMCameraZoomModes.For && _direction == 1)
			{
				if (GetTime() - _reachedDestinationTimestamp > _duration)
				{
					_direction = -1;
					_zoomStartedAt = GetTime();
					_startFieldOfView = _targetFieldOfView;
					_targetFieldOfView = _initialFieldOfView;
				}
			}
			else
			{
				_zooming = false;
			}
		}

		public virtual void Zoom(MMCameraZoomModes mode, float newFieldOfView, float transitionDuration, float duration, bool useUnscaledTime, bool relative = false, MMTweenType tweenType = null)
		{
			if (!_zooming)
			{
				_zooming = true;
				_elapsedTime = 0f;
				_mode = mode;
				TimescaleMode = (useUnscaledTime ? TimescaleModes.Unscaled : TimescaleModes.Scaled);
				_startFieldOfView = _camera.fieldOfView;
				_transitionDuration = transitionDuration;
				_duration = duration;
				_transitionDuration = transitionDuration;
				_direction = 1;
				_destinationReached = false;
				_zoomStartedAt = GetTime();
				if (tweenType != null)
				{
					ZoomTween = tweenType;
				}
				switch (mode)
				{
				case MMCameraZoomModes.For:
					_targetFieldOfView = newFieldOfView;
					break;
				case MMCameraZoomModes.Set:
					_targetFieldOfView = newFieldOfView;
					break;
				case MMCameraZoomModes.Reset:
					_targetFieldOfView = _initialFieldOfView;
					break;
				}
				if (relative)
				{
					_targetFieldOfView += _initialFieldOfView;
				}
			}
		}

		protected virtual void TestZoom()
		{
			Zoom(TestMode, TestFieldOfView, TestTransitionDuration, TestDuration, useUnscaledTime: false, relative: false, ZoomTween);
		}

		public virtual void OnCameraZoomEvent(MMCameraZoomModes mode, float newFieldOfView, float transitionDuration, float duration, MMChannelData channelData, bool useUnscaledTime, bool stop = false, bool relative = false, bool restore = false, MMTweenType tweenType = null)
		{
			if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				if (stop)
				{
					_zooming = false;
				}
				else if (restore)
				{
					_camera.fieldOfView = _initialFieldOfView;
				}
				else
				{
					Zoom(mode, newFieldOfView, transitionDuration, duration, useUnscaledTime, relative, tweenType);
				}
			}
		}

		protected virtual void OnEnable()
		{
			MMCameraZoomEvent.Register(OnCameraZoomEvent);
		}

		protected virtual void OnDisable()
		{
			MMCameraZoomEvent.Unregister(OnCameraZoomEvent);
		}
	}
}
