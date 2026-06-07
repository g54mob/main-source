using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	public class MMSoundManagerTrackVolumeSlider : MonoBehaviour, MMEventListener<MMSoundManagerEvent>, MMEventListenerBase, MMEventListener<MMSoundManagerTrackEvent>, MMEventListener<MMSoundManagerTrackFadeEvent>
	{
		public enum Modes
		{
			Read = 0,
			Write = 1
		}

		[Header("Track Volume Settings")]
		[Tooltip("The track to change volume on")]
		public MMSoundManager.MMSoundManagerTracks Track;

		[Tooltip("The volume to apply to the track when the slider is at its minimum")]
		public float MinVolume;

		[Tooltip("The volume to apply to the track when the slider is at its maximum")]
		public float MaxVolume = 1f;

		[Header("Read/Write Mode")]
		[Tooltip("in read mode, the value of the slider will be applied to the volume of the track. in read mode, the slider will move to reflect the volume of the track")]
		public Modes Mode = Modes.Write;

		[Tooltip("if this is true, the slider will automatically switch to read mode for the required duration when a track fade event is caught")]
		public bool ChangeModeOnTrackFade = true;

		[Tooltip("if this is true, the slider will automatically switch to read mode for the required duration when a track mute event is caught")]
		public bool ChangeModeOnMute = true;

		[Tooltip("if this is true, the slider will automatically switch to read mode for the required duration when a track unmute event is caught")]
		public bool ChangeModeOnUnmute = true;

		[Tooltip("if this is true, the slider will automatically switch to read mode for the required duration when a track volume change event is caught")]
		public bool ChangeModeOnTrackVolumeChange;

		[Tooltip("when switching automatically (and temporarily) to Read Mode, the minimum duration the slider will remain in that mode")]
		public float ModeSwitchBufferTime = 0.1f;

		protected Slider _slider;

		protected Modes _resetToMode;

		protected bool _resetNeeded;

		protected float _resetTimestamp;

		protected virtual void Awake()
		{
			_slider = base.gameObject.GetComponent<Slider>();
		}

		protected virtual void Start()
		{
			if (MMPersistentSingleton<MMSoundManager>.HasInstance)
			{
				UpdateSliderValueWithTrackVolume();
			}
		}

		protected virtual void LateUpdate()
		{
			if (Mode == Modes.Read)
			{
				float trackVolume = MMPersistentSingleton<MMSoundManager>.Instance.GetTrackVolume(Track, mutedVolume: false);
				_slider.value = trackVolume;
			}
			if (_resetNeeded && Time.unscaledTime >= _resetTimestamp)
			{
				Mode = _resetToMode;
				_resetNeeded = false;
			}
		}

		public virtual void ChangeModeToRead(float duration)
		{
			_resetToMode = Modes.Write;
			Mode = Modes.Read;
			_resetTimestamp = Time.unscaledTime + duration;
			_resetNeeded = true;
		}

		public virtual void UpdateVolume(float newValue)
		{
			if (Mode != Modes.Read)
			{
				float volume = MMMaths.Remap(newValue, 0f, 1f, MinVolume, MaxVolume);
				MMSoundManagerTrackEvent.Trigger(MMSoundManagerTrackEventTypes.SetVolumeTrack, Track, volume);
			}
		}

		public void OnMMEvent(MMSoundManagerEvent soundManagerEvent)
		{
			if (soundManagerEvent.EventType == MMSoundManagerEventTypes.SettingsLoaded)
			{
				UpdateSliderValueWithTrackVolume();
			}
		}

		public virtual void UpdateSliderValueWithTrackVolume()
		{
			_slider.value = MMMaths.Remap(MMPersistentSingleton<MMSoundManager>.Instance.GetTrackVolume(Track, mutedVolume: false), 0f, 1f, MinVolume, MaxVolume);
		}

		public void OnMMEvent(MMSoundManagerTrackEvent trackEvent)
		{
			switch (trackEvent.TrackEventType)
			{
			case MMSoundManagerTrackEventTypes.MuteTrack:
				if (ChangeModeOnMute)
				{
					ChangeModeToRead(ModeSwitchBufferTime);
				}
				break;
			case MMSoundManagerTrackEventTypes.UnmuteTrack:
				if (ChangeModeOnUnmute)
				{
					ChangeModeToRead(ModeSwitchBufferTime);
				}
				break;
			case MMSoundManagerTrackEventTypes.SetVolumeTrack:
				if (ChangeModeOnTrackVolumeChange)
				{
					ChangeModeToRead(ModeSwitchBufferTime);
				}
				break;
			}
		}

		public void OnMMEvent(MMSoundManagerTrackFadeEvent fadeEvent)
		{
			if (ChangeModeOnTrackFade)
			{
				ChangeModeToRead(fadeEvent.FadeDuration + ModeSwitchBufferTime);
			}
		}

		protected virtual void OnEnable()
		{
			this.MMEventStartListening<MMSoundManagerEvent>();
			this.MMEventStartListening<MMSoundManagerTrackEvent>();
			this.MMEventStartListening<MMSoundManagerTrackFadeEvent>();
		}

		protected virtual void OnDisable()
		{
			this.MMEventStopListening<MMSoundManagerEvent>();
			this.MMEventStopListening<MMSoundManagerTrackEvent>();
			this.MMEventStopListening<MMSoundManagerTrackFadeEvent>();
		}
	}
}
