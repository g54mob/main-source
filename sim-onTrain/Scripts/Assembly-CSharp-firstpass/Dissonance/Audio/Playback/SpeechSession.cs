using System;
using NAudio.Wave;
using UnityEngine;

namespace Dissonance.Audio.Playback
{
	public struct SpeechSession
	{
		private static readonly Log Log = Logs.Create(LogCategory.Playback, typeof(SpeechSession).Name);

		private static readonly float[] PreplayDesyncFixBuffer = new float[1024];

		private const float MinimumDelayFactor = 1.25f;

		private const float MaximumDelay = 0.75f;

		private static readonly int FixedDelayToleranceTicks = (int)TimeSpan.FromMilliseconds(33.0).Ticks;

		private static readonly float InitialBufferDelay = 0.1f;

		private readonly float _minimumDelay;

		private readonly IRemoteChannelProvider _channels;

		private readonly IDecoderPipeline _pipeline;

		private readonly SessionContext _context;

		private readonly DateTime _creationTime;

		private readonly IJitterEstimator _jitter;

		private DateTime _startTime;

		public int BufferCount => _pipeline.BufferCount;

		public SessionContext Context => _context;

		public PlaybackOptions PlaybackOptions => _pipeline.PlaybackOptions;

		[NotNull]
		public WaveFormat OutputWaveFormat => _pipeline.OutputFormat;

		internal float PacketLoss => _pipeline.PacketLoss;

		internal IRemoteChannelProvider Channels => _channels;

		public DateTime TargetActivationTime => _creationTime + Delay;

		public DateTime ActivationTime => _startTime + Delay;

		public TimeSpan Delay => TimeSpan.FromSeconds(Mathf.Clamp(Mathf.LerpUnclamped(InitialBufferDelay, _jitter.Jitter * 2.5f, _jitter.Confidence), _minimumDelay, 0.75f));

		private SpeechSession(SessionContext context, IJitterEstimator jitter, IDecoderPipeline pipeline, IRemoteChannelProvider channels, DateTime now)
		{
			_context = context;
			_pipeline = pipeline;
			_channels = channels;
			_creationTime = now;
			_jitter = jitter;
			_startTime = now;
			_minimumDelay = (float)(1.25 * _pipeline.InputFrameTime.TotalSeconds);
		}

		internal static SpeechSession Create(SessionContext context, IJitterEstimator jitter, IDecoderPipeline pipeline, IRemoteChannelProvider channels, DateTime now)
		{
			return new SpeechSession(context, jitter, pipeline, channels, now);
		}

		public void Prepare(DateTime now, DateTime timeOfFirstDequeueAttempt)
		{
			_startTime = now - Delay;
			_pipeline.Prepare(_context);
			if ((double)_jitter.Confidence >= 0.75 && _jitter.Jitter >= 0.375f)
			{
				Log.Warn("Beginning playback with very large network jitter: {0}s {1}confidence", _jitter.Jitter, _jitter.Confidence);
			}
			long num = Math.Max(0L, (timeOfFirstDequeueAttempt - _creationTime - Delay).Ticks);
			TimeSpan bufferTime = _pipeline.BufferTime;
			if (bufferTime.Ticks <= Delay.Ticks * 3 + FixedDelayToleranceTicks + num)
			{
				return;
			}
			TimeSpan timeSpan = TimeSpan.FromTicks(bufferTime.Ticks - Delay.Ticks);
			int num2 = (int)(timeSpan.TotalSeconds * (double)OutputWaveFormat.SampleRate);
			Log.Warn("Detected oversized buffer before playback started. Jitter:{0}ms ({1}) Buffered:{2}ms Expected:{3}ms. Discarding {4}ms of audio...", _jitter.Jitter, _jitter.Confidence, _pipeline.BufferTime.TotalMilliseconds, Delay.TotalMilliseconds, timeSpan.TotalMilliseconds);
			while (num2 > 0)
			{
				int num3 = Math.Min(num2, PreplayDesyncFixBuffer.Length);
				if (num3 != 0)
				{
					Read(new ArraySegment<float>(PreplayDesyncFixBuffer, 0, num3));
					num2 -= num3;
					continue;
				}
				break;
			}
		}

		public bool Read(ArraySegment<float> samples)
		{
			return _pipeline.Read(samples);
		}
	}
}
