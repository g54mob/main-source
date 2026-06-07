using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace GAudio
{
	[RequireComponent(typeof(AudioSource))]
	[ExecuteInEditMode]
	public sealed class GATPlayer : MonoBehaviour, IGATFilterableStream, IGATAudioThreadStreamOwner
	{
		public delegate bool OnShouldMixSample(IGATBufferedSample bufferedSample, int length, float[] audioBuffer);

		private class ObserverList<T>
		{
			private int _mutex;

			private readonly List<T> _observers;

			private readonly List<T> _scratchpad;

			private const int Unlocked = 0;

			private const int Locked = 1;

			public ObserverList(int capacity = 1)
			{
				_observers = new List<T>(capacity);
				_scratchpad = new List<T>(capacity);
			}

			public void Subscribe(T observer)
			{
				Lock();
				_observers.Add(observer);
				Unlock();
			}

			public void Unsubscribe(T observer)
			{
				Lock();
				_observers.Remove(observer);
				Unlock();
			}

			public IEnumerator<T> GetEnumerator()
			{
				_scratchpad.Clear();
				Lock();
				_scratchpad.AddRange(_observers);
				Unlock();
				return _scratchpad.GetEnumerator();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void Lock()
			{
				while (Interlocked.CompareExchange(ref _mutex, 1, 0) != 0)
				{
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void Unlock()
			{
				Thread.MemoryBarrier();
				_mutex = 0;
			}
		}

		public interface IPlayerWillMixHandler
		{
			void OnPlayerWillMix();
		}

		public interface IPlayerDidMixHandler
		{
			void OnPlayerDidMix();
		}

		private class BufferedSample : IGATBufferedSample, IGATBufferedSampleOptions
		{
			public class VoidSampleOptions : IGATBufferedSampleOptions
			{
				public void SetEnd(int numSamples, int fadeLength)
				{
				}
			}

			private static GATData __processingBuffer;

			public BufferedSample next;

			public bool shouldBeRemoved;

			public double scheduledDspTime;

			private OnShouldMixSample _onShouldMixSample;

			private float _gain;

			private GATTrack _track;

			private int _count;

			private int _fadeStart;

			private int _fadeSamples;

			private static int nextId;

			public static VoidSampleOptions VoidOptions;

			public int Id { get; private set; }

			public bool IsFirstChunk { get; set; }

			public bool IsLastChunk { get; set; }

			public AGATPanInfo PanInfo { get; private set; }

			public GATData AudioData { get; private set; }

			public int OffsetInBuffer { get; set; }

			public int NextIndex { get; set; }

			public GATData ProcessingBuffer => __processingBuffer;

			public GATTrack Track => _track;

			public float PlayingGain => _gain;

			public static GATData SharedProcessingBuffer
			{
				get
				{
					return __processingBuffer;
				}
				set
				{
					__processingBuffer = value;
				}
			}

			public void CacheToProcessingBuffer(int length)
			{
				AudioData.CopyTo(__processingBuffer, 0, NextIndex, length);
			}

			public void SetEnd(int numSamples, int fadeLength)
			{
				_count = numSamples;
				_fadeStart = numSamples - fadeLength;
				_fadeSamples = fadeLength;
			}

			public BufferedSample()
			{
				Id = nextId;
				nextId++;
			}

			public void Init(GATData isample, AGATPanInfo panInfo, OnShouldMixSample callback, float gain = 1f)
			{
				AudioData = isample;
				PanInfo = panInfo;
				_onShouldMixSample = callback;
				_gain = gain;
				IsFirstChunk = true;
				_count = isample.Count;
				_fadeStart = -1;
			}

			public void Init(GATData isample, GATTrack track, OnShouldMixSample callback, float gain = 1f)
			{
				AudioData = isample;
				_track = track;
				_onShouldMixSample = callback;
				_gain = gain;
				IsFirstChunk = true;
				_count = isample.Count;
				_fadeStart = -1;
			}

			public void Clear()
			{
				AudioData.Release();
				_onShouldMixSample = null;
				IsLastChunk = false;
				next = null;
				AudioData = null;
				shouldBeRemoved = false;
				PanInfo = null;
				NextIndex = 0;
				_track = null;
			}

			public bool MixNow(float[] audioBuffer)
			{
				if (streamWriter != null)
				{
					streamWriter.WriteLine($"\tmixing {Id} ({AudioData.SampleName}) ...");
				}
				int num = GATInfo.AudioBufferSizePerChannel - OffsetInBuffer;
				bool flag = true;
				if (num > _count - NextIndex)
				{
					num = _count - NextIndex;
					IsLastChunk = true;
				}
				if (_onShouldMixSample != null)
				{
					flag = _onShouldMixSample(this, num, audioBuffer);
				}
				if (flag)
				{
					if (_fadeStart > -1 && NextIndex + num > _fadeStart)
					{
						int num2 = num;
						CacheToProcessingBuffer(num);
						if (NextIndex < _fadeStart)
						{
							num2 = NextIndex + num - _fadeStart;
							float gain = _gain;
							float toGain = Mathf.Lerp(_gain, 0f, (float)num2 / (float)_fadeSamples);
							int num3 = _fadeStart - NextIndex;
							__processingBuffer.Gain(0, num3, _gain);
							__processingBuffer.SmoothedGain(num3, num2, gain, toGain);
						}
						else
						{
							int num4 = NextIndex - _fadeStart;
							float gain = Mathf.Lerp(_gain, 0f, (float)num4 / (float)_fadeSamples);
							float toGain = Mathf.Lerp(_gain, 0f, (float)(num4 + num2) / (float)_fadeSamples);
							__processingBuffer.SmoothedGain(0, num2, gain, toGain);
						}
						if ((object)_track != null)
						{
							_track.MixFrom(__processingBuffer, 0, OffsetInBuffer, num);
						}
						else
						{
							PanInfo.PanMixProcessingBuffer(this, num, audioBuffer);
						}
					}
					else if ((object)_track != null)
					{
						_track.MixFrom(AudioData, NextIndex, OffsetInBuffer, num, _gain);
					}
					else
					{
						PanInfo.PanMixSample(this, num, audioBuffer, _gain);
					}
					NextIndex += num;
				}
				if (IsFirstChunk)
				{
					IsFirstChunk = false;
					OffsetInBuffer = 0;
				}
				if (IsLastChunk)
				{
					shouldBeRemoved = true;
				}
				return shouldBeRemoved;
			}

			static BufferedSample()
			{
				nextId = 1;
				VoidOptions = new VoidSampleOptions();
			}
		}

		private class LinkedHead<T>
		{
			public T next;
		}

		private class SampleQueue
		{
			public LinkedHead<BufferedSample> head;

			public BufferedSample last;

			public SampleQueue()
			{
				head = new LinkedHead<BufferedSample>();
			}

			public void Clear()
			{
				head.next = null;
				last = null;
			}

			public void ReleaseAllAndPool(GATPlayer parentPlayer)
			{
				while (head.next != null)
				{
					parentPlayer.PoolBufferedSample(head.next);
					head.next = head.next.next;
				}
				Clear();
			}

			public void Enqueue(SampleQueue queue)
			{
				if (queue.last != null)
				{
					queue.last.next = head.next;
					head.next = queue.head.next;
					if (last == null)
					{
						last = queue.last;
					}
				}
			}

			public void Enqueue(BufferedSample sample)
			{
				if (last == null)
				{
					last = sample;
					last.next = null;
				}
				sample.next = head.next;
				head.next = sample;
			}

			public void TrimAndKeepDiscarded(SampleQueue refQueue)
			{
				BufferedSample bufferedSample = null;
				refQueue.Clear();
				while (head.next != null && head.next.shouldBeRemoved)
				{
					BufferedSample next = head.next;
					next.shouldBeRemoved = false;
					head.next = next.next;
					refQueue.Enqueue(next);
				}
				if (head.next != null)
				{
					bufferedSample = head.next;
					while (bufferedSample.next != null)
					{
						if (bufferedSample.next.shouldBeRemoved)
						{
							BufferedSample next = bufferedSample.next;
							next.shouldBeRemoved = false;
							bufferedSample.next = next.next;
							refQueue.Enqueue(next);
						}
						else
						{
							bufferedSample = bufferedSample.next;
						}
					}
				}
				if (head.next == null)
				{
					last = null;
				}
				else
				{
					last = bufferedSample;
				}
			}
		}

		private class PlayingSamplesQueue : SampleQueue
		{
			private GATPlayer _parentPlayer;

			public PlayingSamplesQueue(GATPlayer parentPlayer)
			{
				_parentPlayer = parentPlayer;
			}

			public void TrimAndReleaseDiscarded()
			{
				BufferedSample bufferedSample = null;
				while (head.next != null && head.next.shouldBeRemoved)
				{
					BufferedSample next = head.next;
					head.next = next.next;
					_parentPlayer.PoolBufferedSample(next);
				}
				if (head.next != null)
				{
					bufferedSample = head.next;
					while (bufferedSample.next != null)
					{
						if (bufferedSample.next.shouldBeRemoved)
						{
							BufferedSample next = bufferedSample.next;
							bufferedSample.next = next.next;
							_parentPlayer.PoolBufferedSample(next);
						}
						else
						{
							bufferedSample = bufferedSample.next;
						}
					}
				}
				if (head.next == null)
				{
					last = null;
				}
				else
				{
					last = bufferedSample;
				}
			}
		}

		private readonly ObserverList<IPlayerWillMixHandler> _playerWillMixObservers = new ObserverList<IPlayerWillMixHandler>(128);

		private readonly ObserverList<IPlayerDidMixHandler> _playerDidMixObservers = new ObserverList<IPlayerDidMixHandler>(128);

		private SampleQueue _scheduledSamples;

		private SampleQueue _samplesToEnqueue;

		private SampleQueue _discardedSamples;

		private PlayingSamplesQueue _playingSamples;

		private Stack<BufferedSample> _pool;

		private GATAudioThreadStreamProxy _audioThreadStreamProxy;

		private volatile bool _releasePlaying;

		private volatile bool _release;

		[SerializeField]
		private List<GATTrack> _tracks = new List<GATTrack>(4);

		[SerializeField]
		private GATFiltersHandler _FiltersHandler;

		[SerializeField]
		private GATGainFilter _GainFilter;

		[SerializeField]
		private float _Gain = 1f;

		[SerializeField]
		private bool _DoClip = true;

		[SerializeField]
		private float _ClipThreshold = 1f;

		private int _lastSampleCount;

		private double _lastResampleTime;

		private double _lastAudioMixTime;

		private double _lastAudioBufferTime;

		public static StreamWriter streamWriter = null;

		public static Stopwatch ResampleStopwatch = new Stopwatch();

		public float Gain
		{
			get
			{
				return _Gain;
			}
			set
			{
				if (value != _Gain)
				{
					_Gain = value;
					if (_GainFilter != null)
					{
						_GainFilter.Gain = value;
					}
				}
			}
		}

		public bool Clip
		{
			get
			{
				return _DoClip;
			}
			set
			{
				if (value != _DoClip)
				{
					_DoClip = value;
					if (_GainFilter != null)
					{
						_GainFilter.Clip = value;
					}
				}
			}
		}

		public float ClipThreshold
		{
			get
			{
				return _ClipThreshold;
			}
			set
			{
				if (value != _ClipThreshold)
				{
					_ClipThreshold = value;
					if (_GainFilter != null)
					{
						_GainFilter.Threshold = value;
					}
				}
			}
		}

		public int NbOfClippedSamples
		{
			get
			{
				if (_GainFilter == null)
				{
					return 0;
				}
				return _GainFilter.NbOfClippedSamples;
			}
		}

		public GATFiltersHandler FiltersHandler => _FiltersHandler;

		public double LastAudioMixTime => _lastAudioMixTime;

		public double LastAudioBufferTime => _lastAudioBufferTime;

		public int LastSampleCount => _lastSampleCount;

		public double LastAudioResampleTime => _lastResampleTime;

		public int NbOfTracks => _tracks.Count;

		int IGATAudioThreadStreamOwner.NbOfStreams => 1;

		public IGATBufferedSampleOptions PlayData(GATData sample, int trackNb, float gain = 1f, OnShouldMixSample mixCallback = null)
		{
			sample.Retain();
			BufferedSample bufferedSample = GetBufferedSample();
			bufferedSample.Init(sample, _tracks[trackNb], mixCallback, gain);
			lock (_samplesToEnqueue)
			{
				_samplesToEnqueue.Enqueue(bufferedSample);
				return bufferedSample;
			}
		}

		public IGATBufferedSampleOptions PlayData(GATData sample, AGATPanInfo panInfo, float gain = 1f, OnShouldMixSample mixCallback = null)
		{
			sample.Retain();
			BufferedSample bufferedSample = GetBufferedSample();
			bufferedSample.Init(sample, panInfo, mixCallback, gain);
			lock (_samplesToEnqueue)
			{
				_samplesToEnqueue.Enqueue(bufferedSample);
				return bufferedSample;
			}
		}

		public IGATBufferedSampleOptions PlayDataScheduled(GATData sample, double dspTime, int trackNb, float gain = 1f, OnShouldMixSample mixCallback = null)
		{
			if (dspTime < AudioSettings.dspTime + GATInfo.AudioBufferDuration)
			{
				dspTime = AudioSettings.dspTime + GATInfo.AudioBufferDuration;
			}
			sample.Retain();
			BufferedSample bufferedSample = GetBufferedSample();
			bufferedSample.scheduledDspTime = dspTime;
			bufferedSample.Init(sample, _tracks[trackNb], mixCallback, gain);
			lock (_scheduledSamples)
			{
				_scheduledSamples.Enqueue(bufferedSample);
				return bufferedSample;
			}
		}

		public IGATBufferedSampleOptions PlayDataScheduled(GATData sample, double dspTime, AGATPanInfo panInfo, float gain = 1f, OnShouldMixSample mixCallback = null)
		{
			if (dspTime < AudioSettings.dspTime + GATInfo.AudioBufferDuration)
			{
				dspTime = AudioSettings.dspTime + GATInfo.AudioBufferDuration;
			}
			sample.Retain();
			BufferedSample bufferedSample = GetBufferedSample();
			bufferedSample.scheduledDspTime = dspTime;
			bufferedSample.Init(sample, panInfo, mixCallback, gain);
			lock (_scheduledSamples)
			{
				_scheduledSamples.Enqueue(bufferedSample);
				return bufferedSample;
			}
		}

		public void ClearScheduledSamples()
		{
			lock (_scheduledSamples)
			{
				_scheduledSamples.ReleaseAllAndPool(this);
			}
		}

		public void ClearPlayingSamples()
		{
			lock (_samplesToEnqueue)
			{
				_samplesToEnqueue.ReleaseAllAndPool(this);
			}
			_releasePlaying = true;
		}

		public void Stop()
		{
			ClearPlayingSamples();
			_release = true;
		}

		public GATTrack GetTrack(int trackIndex)
		{
			if (trackIndex >= _tracks.Count)
			{
				return null;
			}
			return _tracks[trackIndex];
		}

		public T AddTrack<T>() where T : GATTrack
		{
			T val = ScriptableObject.CreateInstance<T>();
			val.InitTrack(this, _tracks.Count);
			_tracks.Add(val);
			return val;
		}

		public void DeleteTrack(GATTrack track)
		{
			int num = -1;
			for (int i = 0; i < _tracks.Count; i++)
			{
				if (track == _tracks[i])
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				return;
			}
			_tracks.RemoveAt(num);
			if (Application.isPlaying)
			{
				Object.Destroy(track);
			}
			else
			{
				Object.DestroyImmediate(track);
			}
			if (_tracks.Count > num)
			{
				for (int i = num; i < _tracks.Count; i++)
				{
					_tracks[i].TrackNbDidChange(i);
				}
			}
		}

		public void ClearTracks()
		{
			if (Application.isPlaying)
			{
				foreach (GATTrack track in _tracks)
				{
					Object.Destroy(track);
				}
			}
			else
			{
				foreach (GATTrack track2 in _tracks)
				{
					Object.DestroyImmediate(track2);
				}
			}
			_tracks.Clear();
		}

		public IGATAudioThreadStream GetAudioThreadStream(int index)
		{
			return _audioThreadStreamProxy;
		}

		public void OnPlayerWillMix_Subscribe(IPlayerWillMixHandler handler)
		{
			_playerWillMixObservers.Subscribe(handler);
		}

		public void OnPlayerWillMix_Unsubscribe(IPlayerWillMixHandler handler)
		{
			_playerWillMixObservers.Unsubscribe(handler);
		}

		private void OnPlayerWillMix_Invoke()
		{
			foreach (IPlayerWillMixHandler playerWillMixObserver in _playerWillMixObservers)
			{
				playerWillMixObserver.OnPlayerWillMix();
			}
		}

		public void OnPlayerDidMix_Subscribe(IPlayerDidMixHandler handler)
		{
			_playerDidMixObservers.Subscribe(handler);
		}

		public void OnPlayerDidMix_Unsubscribe(IPlayerDidMixHandler handler)
		{
			_playerDidMixObservers.Unsubscribe(handler);
		}

		private void OnPlayerDidMix_Invoke()
		{
			foreach (IPlayerDidMixHandler playerDidMixObserver in _playerDidMixObservers)
			{
				playerDidMixObserver.OnPlayerDidMix();
			}
		}

		private void Awake()
		{
			AudioSource component = GetComponent<AudioSource>();
			component.playOnAwake = false;
			if (component.clip != null)
			{
				component.clip = null;
			}
			if (_FiltersHandler == null)
			{
				InitFilters();
			}
			if (_tracks == null)
			{
				_tracks = new List<GATTrack>(4);
			}
			_scheduledSamples = new SampleQueue();
			_samplesToEnqueue = new SampleQueue();
			_discardedSamples = new SampleQueue();
			_playingSamples = new PlayingSamplesQueue(this);
			_pool = new Stack<BufferedSample>(30);
			for (int i = 0; i < 30; i++)
			{
				_pool.Push(new BufferedSample());
			}
			_audioThreadStreamProxy = new GATAudioThreadStreamProxy(GATInfo.AudioBufferSizePerChannel, GATInfo.NbOfChannels, GATAudioBuffer.AudioBufferPointer, 0, "GATPlayer " + base.gameObject.name);
		}

		private void OnEnable()
		{
			if (_pool == null)
			{
				Awake();
				GetComponent<AudioSource>().Play();
			}
		}

		private void Start()
		{
			GetComponent<AudioSource>().Play();
		}

		private void OnDisable()
		{
			if (_playingSamples != null)
			{
				ClearAllQueues();
			}
			foreach (GATTrack track in _tracks)
			{
				if (track != null)
				{
					track.OnDisable();
				}
			}
		}

		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				foreach (GATTrack track in _tracks)
				{
					Object.Destroy(track);
				}
				Object.Destroy(_FiltersHandler);
				return;
			}
			foreach (GATTrack track2 in _tracks)
			{
				Object.DestroyImmediate(track2);
			}
			Object.DestroyImmediate(_FiltersHandler);
		}

		public static void InitStatics()
		{
			BufferedSample.SharedProcessingBuffer = GATManager.GetFixedDataContainer(GATInfo.AudioBufferSizePerChannel * 2, "Player Processing Buffer");
		}

		public static void CleanUpStatics()
		{
			BufferedSample.SharedProcessingBuffer = null;
		}

		private void ClearAllQueues()
		{
			ClearScheduledSamples();
			lock (_samplesToEnqueue)
			{
				_samplesToEnqueue.ReleaseAllAndPool(this);
			}
			_playingSamples.ReleaseAllAndPool(this);
		}

		private void InitFilters()
		{
			_FiltersHandler = ScriptableObject.CreateInstance<GATFiltersHandler>();
			_FiltersHandler.InitFiltersHandler(GATInfo.NbOfChannels);
			_GainFilter = (GATGainFilter)_FiltersHandler.AddFilter<GATGainFilter>(999);
			_GainFilter.Gain = _Gain;
			_GainFilter.Threshold = _ClipThreshold;
			_GainFilter.Clip = _DoClip;
		}

		private BufferedSample GetBufferedSample()
		{
			lock (_pool)
			{
				if (_pool.Count > 0)
				{
					return _pool.Pop();
				}
			}
			return new BufferedSample();
		}

		private void PoolBufferedSample(BufferedSample sample)
		{
			sample.Clear();
			lock (_pool)
			{
				_pool.Push(sample);
			}
		}

		private void OnAudioFilterRead(float[] data, int numChannels)
		{
			_lastAudioBufferTime = (double)(data.Length / numChannels) / (double)GATInfo.OutputSampleRate;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			ResampleStopwatch.Reset();
			bool flag = false;
			int num = data.Length;
			if (streamWriter != null)
			{
				streamWriter.WriteLine($"\nOnAudioFilterRead: {num} samples, {numChannels} channels.");
			}
			bool flag2 = false;
			BufferedSample next = _scheduledSamples.head.next;
			if (next != null)
			{
				double num2 = AudioSettings.dspTime + GATInfo.AudioBufferDuration;
				while (next != null)
				{
					if (num2 > next.scheduledDspTime)
					{
						next.shouldBeRemoved = true;
						flag2 = true;
						next.OffsetInBuffer = (int)((next.scheduledDspTime - AudioSettings.dspTime) * (double)GATInfo.OutputSampleRate);
						if (next.OffsetInBuffer < 0)
						{
							next.OffsetInBuffer = 0;
						}
						if (streamWriter != null)
						{
							streamWriter.WriteLine($"\tstarting sample {next.Id} ({next.AudioData.SampleName}) at offset {next.OffsetInBuffer} ({num2} > {next.scheduledDspTime})");
						}
					}
					else if (streamWriter != null)
					{
						streamWriter.WriteLine($"\tnot starting sample {next.Id} ({next.AudioData.SampleName}) ({num2} <= {next.scheduledDspTime})");
					}
					next = next.next;
				}
				if (flag2)
				{
					lock (_scheduledSamples)
					{
						_scheduledSamples.TrimAndKeepDiscarded(_discardedSamples);
					}
					_playingSamples.Enqueue(_discardedSamples);
				}
			}
			lock (_samplesToEnqueue)
			{
				if (_samplesToEnqueue.head.next != null)
				{
					_playingSamples.Enqueue(_samplesToEnqueue);
					_samplesToEnqueue.Clear();
				}
			}
			next = _playingSamples.head.next;
			OnPlayerWillMix_Invoke();
			if (next == null)
			{
				flag = true;
				for (int i = 0; i < _tracks.Count; i++)
				{
					if ((object)_tracks[i] != null && _tracks[i].FXAndMixTo(data))
					{
						flag = false;
					}
				}
				if (_FiltersHandler.HasFilters && _FiltersHandler.ApplyFilters(data, 0, num, flag))
				{
					flag = false;
				}
				_audioThreadStreamProxy.BroadcastStream(data, 0, flag);
				OnPlayerDidMix_Invoke();
				stopwatch.Stop();
				_lastAudioMixTime = (double)stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
				_lastResampleTime = (double)ResampleStopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
				return;
			}
			flag2 = false;
			int num3 = 0;
			while (next != null)
			{
				num3++;
				if (next.MixNow(data))
				{
					flag2 = true;
				}
				next = next.next;
			}
			if (flag2)
			{
				_playingSamples.TrimAndReleaseDiscarded();
			}
			for (int i = 0; i < _tracks.Count; i++)
			{
				if ((object)_tracks[i] != null)
				{
					_tracks[i].FXAndMixTo(data);
				}
			}
			if (_FiltersHandler.HasFilters)
			{
				_FiltersHandler.ApplyFilters(data, 0, num, emptyData: false);
			}
			_audioThreadStreamProxy.BroadcastStream(data, 0, isEmptyData: false);
			OnPlayerDidMix_Invoke();
			if (_releasePlaying)
			{
				_playingSamples.ReleaseAllAndPool(this);
				_releasePlaying = false;
				float num4 = 1f / (float)(data.Length / numChannels);
				float num5 = 1f;
				for (int i = 0; i < data.Length; i += numChannels)
				{
					data[i] *= num5;
					if (i + 1 < data.Length)
					{
						data[i + 1] *= num5;
					}
					num5 -= num4;
				}
			}
			if (_release && !_releasePlaying)
			{
				for (int i = 0; i < data.Length; i++)
				{
					data[i] = 0f;
				}
			}
			stopwatch.Stop();
			_lastSampleCount = num3;
			_lastAudioMixTime = (double)stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
			_lastResampleTime = (double)ResampleStopwatch.ElapsedTicks / (double)Stopwatch.Frequency;
		}
	}
}
