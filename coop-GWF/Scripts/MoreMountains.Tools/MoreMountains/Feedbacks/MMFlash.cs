using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Feedbacks
{
	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(CanvasGroup))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Various/MMFlash")]
	public class MMFlash : MMMonoBehaviour
	{
		[MMInspectorGroup("Flash", true, 121, false)]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMFEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMFEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Tooltip("the ID of this MMFlash object. When triggering a MMFlashEvent you can specify an ID, and only MMFlash objects with this ID will answer the call and flash, allowing you to have more than one flash object in a scene")]
		public int FlashID;

		[Tooltip("if this is true, the MMFlash will stop before playing on every new event received")]
		public bool Interruptable;

		[MMInspectorGroup("Interpolation", true, 122, false)]
		[Tooltip("the animation curve to use when flashing in")]
		public MMTweenType FlashInTween = new MMTweenType(MMTween.MMTweenCurve.LinearTween);

		[Tooltip("the animation curve to use when flashing out")]
		public MMTweenType FlashOutTween = new MMTweenType(MMTween.MMTweenCurve.LinearTween);

		[MMInspectorGroup("Debug", true, 123, false)]
		[Tooltip("the set of test settings to use when pressing the DebugTest button")]
		public MMFlashDebugSettings DebugSettings;

		[Tooltip("a test button that calls the DebugTest method")]
		[MMFInspectorButton("DebugTest")]
		public bool DebugTestButton;

		protected Image _image;

		protected CanvasGroup _canvasGroup;

		protected bool _flashing;

		protected float _targetAlpha;

		protected Color _initialColor;

		protected float _delta;

		protected float _flashStartedTimestamp;

		protected int _direction = 1;

		protected float _duration;

		protected TimescaleModes _timescaleMode;

		protected MMTweenType _currentTween;

		public virtual float GetTime()
		{
			if (_timescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (_timescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Start()
		{
			_image = GetComponent<Image>();
			_canvasGroup = GetComponent<CanvasGroup>();
			_initialColor = _image.color;
		}

		protected virtual void Update()
		{
			if (_flashing)
			{
				_image.enabled = true;
				_currentTween = FlashInTween;
				if (GetTime() - _flashStartedTimestamp > _duration / 2f)
				{
					_direction = -1;
					_currentTween = FlashOutTween;
				}
				if (_direction == 1)
				{
					_delta += GetDeltaTime() / (_duration / 2f);
				}
				else
				{
					_delta -= GetDeltaTime() / (_duration / 2f);
				}
				if (GetTime() - _flashStartedTimestamp > _duration)
				{
					_flashing = false;
				}
				float t = MMMaths.Remap(_delta, 0f, _duration / 2f, 0f, 1f);
				float t2 = _currentTween.Evaluate(t);
				_canvasGroup.alpha = Mathf.Lerp(0f, _targetAlpha, t2);
			}
			else
			{
				_image.enabled = false;
			}
		}

		public virtual void DebugTest()
		{
			MMFlashEvent.Trigger(DebugSettings.FlashColor, DebugSettings.FlashDuration, DebugSettings.FlashAlpha, DebugSettings.FlashID, new MMChannelData(DebugSettings.ChannelMode, DebugSettings.Channel, DebugSettings.MMChannelDefinition), TimescaleModes.Unscaled);
		}

		public virtual void OnMMFlashEvent(Color flashColor, float duration, float alpha, int flashID, MMChannelData channelData, TimescaleModes timescaleMode, bool stop = false)
		{
			if (flashID == FlashID)
			{
				if (stop)
				{
					_flashing = false;
				}
				else if (MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
				{
					Flash(flashColor, duration, alpha, timescaleMode);
				}
			}
		}

		public virtual void Flash(Color flashColor, float duration, float alpha, TimescaleModes timescaleMode)
		{
			if (_flashing && Interruptable)
			{
				_flashing = false;
			}
			if (!_flashing)
			{
				_flashing = true;
				_direction = 1;
				_canvasGroup.alpha = 0f;
				_targetAlpha = alpha;
				_delta = 0f;
				_image.color = flashColor;
				_duration = duration;
				_timescaleMode = timescaleMode;
				_flashStartedTimestamp = GetTime();
			}
		}

		protected virtual void OnEnable()
		{
			MMFlashEvent.Register(OnMMFlashEvent);
		}

		protected virtual void OnDisable()
		{
			MMFlashEvent.Unregister(OnMMFlashEvent);
		}
	}
}
