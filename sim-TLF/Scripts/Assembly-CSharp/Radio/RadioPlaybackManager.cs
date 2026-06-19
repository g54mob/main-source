using System;
using System.Collections;
using UnityEngine;

namespace Radio
{
	[RequireComponent(typeof(RadioAudioPlayer))]
	[RequireComponent(typeof(RadioChannelManager))]
	[RequireComponent(typeof(RadioConditionProcessor))]
	public class RadioPlaybackManager : MonoBehaviour
	{
		[Range(0f, 1f)]
		[SerializeField]
		private float _volume = 0.8f;

		private RadioAudioPlayer _player;

		private RadioChannelManager _channels;

		private RadioConditionProcessor _conditions;

		private int _tracksSinceLastAd = -1;

		private Coroutine _playCoroutine;

		private bool _conditionInterruptPending;

		public float Volume
		{
			get
			{
				return _volume;
			}
			set
			{
				_volume = Mathf.Clamp01(value);
				_player.MusicSource.volume = _volume;
			}
		}

		public event Action<RadioTrack> OnTrackChanged;

		private void Awake()
		{
			_player = GetComponent<RadioAudioPlayer>();
			_channels = GetComponent<RadioChannelManager>();
			_conditions = GetComponent<RadioConditionProcessor>();
		}

		private void OnEnable()
		{
			_conditions.OnConditionsChanged += OnConditionsChanged;
		}

		private void OnDisable()
		{
			_conditions.OnConditionsChanged -= OnConditionsChanged;
		}

		private void OnConditionsChanged(RadioCondition active)
		{
			if (HasPendingSpecial(active))
			{
				_conditionInterruptPending = true;
			}
		}

		private bool HasPendingSpecial(RadioCondition active)
		{
			RadioChannel currentChannel = _channels.CurrentChannel;
			if (currentChannel?.specialTracks == null)
			{
				return false;
			}
			RadioTrack[] specialTracks = currentChannel.specialTracks;
			foreach (RadioTrack radioTrack in specialTracks)
			{
				if (radioTrack.requiredConditions != RadioCondition.None && (active & radioTrack.requiredConditions) != RadioCondition.None)
				{
					return true;
				}
			}
			return false;
		}

		public void StartPlayback()
		{
			StopPlayback();
			_playCoroutine = StartCoroutine(PlayLoop());
		}

		public void StopPlayback()
		{
			if (_playCoroutine != null)
			{
				StopCoroutine(_playCoroutine);
				_playCoroutine = null;
			}
		}

		private IEnumerator PlayLoop()
		{
			while (true)
			{
				bool wasAd;
				RadioTrack radioTrack = RadioTrackQueue.PickNext(_channels.CurrentChannel, _tracksSinceLastAd, _conditions, out wasAd);
				if (wasAd)
				{
					_tracksSinceLastAd = 0;
				}
				else
				{
					_tracksSinceLastAd++;
				}
				_player.PlayTrack(radioTrack);
				this.OnTrackChanged?.Invoke(radioTrack);
				float duration = ((radioTrack?.musicFileObject != null) ? radioTrack.musicFileObject.length : 1f);
				float offset = 0.4f;
				float elapsed = 0f;
				while (elapsed < duration + offset)
				{
					if (_conditionInterruptPending)
					{
						_conditionInterruptPending = false;
						bool wasAd2;
						RadioTrack radioTrack2 = RadioTrackQueue.PickNext(_channels.CurrentChannel, _tracksSinceLastAd, _conditions, out wasAd2);
						if (radioTrack2 != null && radioTrack2.type == TrackType.Special)
						{
							_player.StopTrack();
							if (wasAd2)
							{
								_tracksSinceLastAd = 0;
							}
							else
							{
								_tracksSinceLastAd++;
							}
							_player.PlayTrack(radioTrack2);
							this.OnTrackChanged?.Invoke(radioTrack2);
							duration = ((radioTrack2.musicFileObject != null) ? radioTrack2.musicFileObject.length : 1f);
							elapsed = 0f;
							yield return null;
							continue;
						}
					}
					elapsed += Time.deltaTime;
					yield return null;
				}
			}
		}

		public void ResetAdCounter()
		{
			_tracksSinceLastAd = -1;
			_conditionInterruptPending = false;
		}

		private void OnDestroy()
		{
			StopPlayback();
		}
	}
}
