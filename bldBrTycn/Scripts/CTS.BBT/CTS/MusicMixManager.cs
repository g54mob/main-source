using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MusicMixManager : CTSSingleton<MusicMixManager>, IRepaint
	{
		private enum EPlayState
		{
			Idle = 0,
			Playing = 1,
			Cooldown = 2
		}

		[SerializeField]
		private AudioSource _audioSourcePrefab;

		public int numberOfLayers;

		public List<BarStyleValues> ponderation;

		[SerializeField]
		private SongPlaylist _playlist;

		[SerializeField]
		private List<BarStyleValues> _defaultStyle;

		private Song _currentSong;

		private MusicMix _currentMix;

		private readonly Stack<AudioSource> _sourcePool = new Stack<AudioSource>();

		private readonly Dictionary<int, (AudioSource, EBarStyle)> _currentlyPlaying = new Dictionary<int, (AudioSource, EBarStyle)>();

		[SerializeField]
		private float _crossfadeDuration;

		[SerializeField]
		private AnimationCurve _crossfadeCurve;

		[SerializeField]
		[MinMaxSlider(0f, 300f)]
		private Vector2 _delayInSecondsBetweenTunes;

		private readonly Dictionary<AudioSource, Coroutine> _crossfades = new Dictionary<AudioSource, Coroutine>();

		private EPlayState _playState;

		[Header("Debug")]
		[SerializeField]
		private bool debug;

		private bool _initialized;

		private bool _canPlay;

		private bool _shouldRefresh = true;

		private Coroutine _crossfadeCoroutine;

		protected override void SingletonAwake()
		{
			_currentSong = _playlist.GetNextMusicClip();
			_currentSong.Initialize();
			StartCoroutine(CooldownPlaylist());
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void Start()
		{
			_currentMix = new MusicMix();
			List<BarStyleValues> barStyleValues = GetBarStyleValues(CTSSingleton<BarStyleInfluence>.Instance);
			_currentMix._ponderation = ComputePonderation(barStyleValues);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			BarStyleInfluence.StylesInfluenceChanged += OnBarInfluenceChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			BarStyleInfluence.StylesInfluenceChanged -= OnBarInfluenceChanged;
		}

		private void Update()
		{
			if ((bool)_playlist && _canPlay)
			{
				if (_playState == EPlayState.Idle)
				{
					StartCoroutine(PlayCurrentPlaylistNextSong());
				}
				if (_shouldRefresh)
				{
					_shouldRefresh = false;
					List<BarStyleValues> barStyleValues = GetBarStyleValues(CTSSingleton<BarStyleInfluence>.Instance);
					PlayNewMix(barStyleValues);
				}
			}
		}

		private bool IsAnyPlaying()
		{
			foreach (var value in _currentlyPlaying.Values)
			{
				AudioSource item = value.Item1;
				if (item.isPlaying)
				{
					return true;
				}
			}
			return false;
		}

		[Button(null, EButtonEnableMode.Playmode)]
		private void PrintState()
		{
			foreach (var value in _currentlyPlaying.Values)
			{
				AudioSource item = value.Item1;
				if (item.isPlaying)
				{
					_ = item.volume;
					_ = 0f;
				}
			}
		}

		private AudioSource GetAudioSource()
		{
			if (!_sourcePool.TryPop(out var result))
			{
				return UnityEngine.Object.Instantiate(_audioSourcePrefab, base.transform);
			}
			return result;
		}

		public void Play()
		{
			_canPlay = true;
		}

		public void Stop()
		{
			_canPlay = false;
			_playState = EPlayState.Idle;
			StopAllLayers();
		}

		private void PushAudioSourceToPool(AudioSource source)
		{
			if (!_sourcePool.Contains(source))
			{
				_sourcePool.Push(source);
			}
		}

		private void StopAllLayers()
		{
			for (int i = 0; i < numberOfLayers; i++)
			{
				StopAudioSource(i);
			}
		}

		private void StopAudioSource(int index)
		{
			if (_currentlyPlaying.Remove(index, out var value))
			{
				var (source, _) = value;
				StartRoutine(source, CrossFadeOut(source));
			}
		}

		private List<BarStyleValues> GetBarStyleValues(BarStyleInfluence barStyleInfluence)
		{
			List<BarStyleValues> list = new List<BarStyleValues>();
			foreach (KeyValuePair<EBarStyle, float> styleInfluence in barStyleInfluence.StyleInfluences)
			{
				BarStyleValues item = new BarStyleValues
				{
					_style = styleInfluence.Key,
					_value = styleInfluence.Value
				};
				list.Add(item);
			}
			if (list.Count == 0)
			{
				list = new List<BarStyleValues>(_defaultStyle);
			}
			return list;
		}

		private void PlayNewMix(List<BarStyleValues> barStyleValues, bool force = false)
		{
			MusicMix musicMix = new MusicMix
			{
				_ponderation = ComputePonderation(barStyleValues)
			};
			if (force || (_currentMix != null && !_currentMix.Equals(musicMix)))
			{
				PlayMix(musicMix);
			}
		}

		private void OnBarInfluenceChanged(BarStyleInfluence obj)
		{
			_shouldRefresh = true;
		}

		private IEnumerator PlayCurrentPlaylistNextSong()
		{
			if (!_playlist)
			{
				yield return null;
			}
			_currentSong = _playlist.GetNextMusicClip();
			_currentSong.Initialize();
			List<BarStyleValues> barStyleValues = GetBarStyleValues(CTSSingleton<BarStyleInfluence>.Instance);
			PlayNewMix((barStyleValues.Count > 0) ? barStyleValues : _defaultStyle, force: true);
			_playState = EPlayState.Playing;
			yield return Coroutines.WaitForSecondsUnscaled(1f);
			while (IsAnyPlaying())
			{
				yield return null;
			}
			StopAllLayers();
			yield return CooldownPlaylist();
		}

		private IEnumerator CooldownPlaylist()
		{
			_playState = EPlayState.Cooldown;
			yield return Coroutines.WaitForSecondsUnscaled(_delayInSecondsBetweenTunes.RandomInRange());
			_playState = EPlayState.Idle;
		}

		public EBarStyle[] ComputePonderation(List<BarStyleValues> barStyleValues)
		{
			ponderation = new List<BarStyleValues>();
			float num = barStyleValues.Sum((BarStyleValues x) => x._value);
			EBarStyle[] array = new EBarStyle[numberOfLayers];
			int num2 = 0;
			foreach (BarStyleValues barStyleValue in barStyleValues)
			{
				if (!(barStyleValue._value <= 0f))
				{
					BarStyleValues item = new BarStyleValues
					{
						_value = barStyleValue._value * 4f / num
					};
					while (item._value > 1f)
					{
						item._value -= 1f;
						array[num2] = barStyleValue._style;
						num2++;
					}
					item._style = barStyleValue._style;
					ponderation.Add(item);
				}
			}
			ponderation.Sort((BarStyleValues a, BarStyleValues b) => b._value.CompareTo(a._value));
			int num3 = 0;
			for (; num2 < numberOfLayers; num2++)
			{
				array[num2] = ponderation[num3]._style;
				num3++;
			}
			return array;
		}

		private MusicStyle GetMusicStyle(EBarStyle barStyle)
		{
			if (_currentSong.styles.TryGetValue(barStyle, out var value))
			{
				return value;
			}
			foreach (BarStyleValues item in _defaultStyle)
			{
				if (_currentSong.styles.TryGetValue(item._style, out value))
				{
					return value;
				}
			}
			return null;
		}

		private int GetTimeSample()
		{
			int num = 0;
			int num2 = 0;
			foreach (var value in _currentlyPlaying.Values)
			{
				AudioSource item = value.Item1;
				if (item.isPlaying && !(item.volume <= 0f))
				{
					num += item.timeSamples;
					num2++;
				}
			}
			if (num2 > 0)
			{
				num /= num2;
			}
			return num;
		}

		private void PlayMix(MusicMix musicMix)
		{
			double time = AudioSettings.dspTime + 1.0;
			System.Random random = new System.Random();
			if (_playState == EPlayState.Idle)
			{
				random.Shuffle(musicMix._ponderation);
				for (int i = 0; i < numberOfLayers; i++)
				{
					EBarStyle eBarStyle = musicMix._ponderation[i];
					AudioSource audioSource = GetAudioSource();
					StopAudioSource(i);
					_currentlyPlaying[i] = (audioSource, eBarStyle);
					MusicStyle musicStyle = GetMusicStyle(eBarStyle);
					if ((object)musicStyle == null)
					{
						Debug.LogException(new NullReferenceException("Couldn't find a music style"));
						continue;
					}
					audioSource.clip = musicStyle.layers[i].audioClip;
					audioSource.volume = 1f;
					audioSource.PlayScheduled(time);
					audioSource.timeSamples = 0;
				}
				return;
			}
			Dictionary<EBarStyle, int> styleDifferences = _currentMix.GetStyleDifferences(musicMix);
			List<int> list = new List<int>();
			List<EBarStyle> list2 = new List<EBarStyle>();
			foreach (KeyValuePair<EBarStyle, int> item2 in styleDifferences)
			{
				var (style, num2) = (KeyValuePair<EBarStyle, int>)(ref item2);
				if (num2 > 0)
				{
					List<int> list3 = (from num7 in Enumerable.Range(0, _currentMix._ponderation.Length)
						where _currentMix._ponderation[num7] == style
						select num7).ToList();
					for (int num3 = num2; num3 > 0; num3--)
					{
						int item = list3[random.Next(list3.Count)];
						while (list.Contains(item))
						{
							item = list3[random.Next(list3.Count)];
						}
						list.Add(item);
					}
				}
				if (num2 < 0)
				{
					for (int num4 = -num2; num4 > 0; num4--)
					{
						list2.Add(style);
					}
				}
			}
			EBarStyle[] array = list2.ToArray();
			random.Shuffle(array);
			int num5 = 0;
			int timeSample = GetTimeSample();
			for (int num6 = 0; num6 < numberOfLayers; num6++)
			{
				EBarStyle eBarStyle3 = _currentMix._ponderation[num6];
				if (list.Contains(num6))
				{
					eBarStyle3 = array[num5];
					num5++;
					MusicStyle musicStyle2 = GetMusicStyle(eBarStyle3);
					if ((object)musicStyle2 == null)
					{
						Debug.LogException(new NullReferenceException("Couldn't find a music style"));
						continue;
					}
					if (_playState == EPlayState.Playing)
					{
						AudioSource audioSource2 = GetAudioSource();
						StopAudioSource(num6);
						_currentlyPlaying[num6] = (audioSource2, eBarStyle3);
						audioSource2.clip = musicStyle2.layers[num6].audioClip;
						audioSource2.volume = 0f;
						audioSource2.PlayScheduled(time);
						audioSource2.timeSamples = timeSample + (int)(1f * (float)audioSource2.clip.frequency);
						StartRoutine(audioSource2, CrossFade(audioSource2));
					}
				}
				musicMix._ponderation[num6] = eBarStyle3;
			}
			_currentMix = musicMix;
		}

		private void StartRoutine(AudioSource source, IEnumerator routine)
		{
			if (_crossfades.TryGetValue(source, out var value))
			{
				StopCoroutine(value);
			}
			_crossfades[source] = StartCoroutine(routine);
		}

		private IEnumerator CrossFade(AudioSource source, float target = 1f)
		{
			yield return Coroutines.WaitForSecondsRealtime(1f);
			float startVolume = source.volume;
			for (float time = 0f; time < 1f; time += Time.unscaledDeltaTime / _crossfadeDuration)
			{
				source.volume = Mathf.Lerp(startVolume, target, _crossfadeCurve.Evaluate(time));
				yield return null;
			}
			source.volume = target;
			_crossfades.Remove(source);
		}

		private IEnumerator CrossFadeOut(AudioSource source)
		{
			yield return CrossFade(source, 0f);
			source.Stop();
			PushAudioSourceToPool(source);
		}

		[Button(null, EButtonEnableMode.Playmode)]
		public void Resync()
		{
			int timeSample = GetTimeSample();
			double time = AudioSettings.dspTime + 0.10000000149011612;
			foreach (var value in _currentlyPlaying.Values)
			{
				AudioSource item = value.Item1;
				item.PlayScheduled(time);
				item.timeSamples = timeSample + (int)(1f * (float)item.clip.frequency);
			}
		}

		public void Repaint()
		{
			Resync();
		}
	}
}
