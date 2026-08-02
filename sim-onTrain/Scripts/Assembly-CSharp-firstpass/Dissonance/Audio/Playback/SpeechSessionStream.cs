using System;
using System.Collections.Generic;
using Dissonance.Datastructures;
using Dissonance.Networking;

namespace Dissonance.Audio.Playback
{
	internal class SpeechSessionStream : IJitterEstimator
	{
		private static readonly Log Log = Logs.Create(LogCategory.Playback, typeof(SpeechSessionStream).Name);

		private readonly Queue<SpeechSession> _awaitingActivation;

		private readonly IVolumeProvider _volumeProvider;

		private DateTime? _queueHeadFirstDequeueAttempt;

		private DecoderPipeline _active;

		private uint _currentId;

		private string _playerName;

		private readonly WindowDeviationCalculator _arrivalJitterMeter = new WindowDeviationCalculator(128u);

		private static readonly Dictionary<FrameFormat, ConcurrentPool<DecoderPipeline>> FreePipelines = new Dictionary<FrameFormat, ConcurrentPool<DecoderPipeline>>();

		public string PlayerName
		{
			get
			{
				return _playerName;
			}
			set
			{
				if (_playerName != value)
				{
					_playerName = value;
					_arrivalJitterMeter.Clear();
				}
			}
		}

		float IJitterEstimator.Jitter => _arrivalJitterMeter.StdDev;

		float IJitterEstimator.Confidence => _arrivalJitterMeter.Confidence;

		public SpeechSessionStream(IVolumeProvider volumeProvider)
		{
			_volumeProvider = volumeProvider;
			_awaitingActivation = new Queue<SpeechSession>();
		}

		public void StartSession(FrameFormat format, DateTime? now = null, [CanBeNull] IJitterEstimator jitter = null)
		{
			if (PlayerName == null)
			{
				throw Log.CreatePossibleBugException("Attempted to `StartSession` but `PlayerName` is null", "0C0F3731-8D6B-43F6-87C1-33CEC7A26804");
			}
			_active = GetOrCreateDecoderPipeline(format, _volumeProvider);
			SpeechSession item = SpeechSession.Create(new SessionContext(PlayerName, _currentId++), jitter ?? this, _active, _active, now ?? DateTime.UtcNow);
			_awaitingActivation.Enqueue(item);
		}

		public SpeechSession? TryDequeueSession(DateTime? now = null)
		{
			DateTime dateTime = now ?? DateTime.UtcNow;
			if (_awaitingActivation.Count > 0)
			{
				if (!_queueHeadFirstDequeueAttempt.HasValue)
				{
					_queueHeadFirstDequeueAttempt = dateTime;
				}
				SpeechSession value = _awaitingActivation.Peek();
				if (value.TargetActivationTime < dateTime)
				{
					value.Prepare(dateTime, _queueHeadFirstDequeueAttempt.Value);
					_awaitingActivation.Dequeue();
					_queueHeadFirstDequeueAttempt = null;
					return value;
				}
			}
			return null;
		}

		public void ReceiveFrame(VoicePacket packet, DateTime? now = null)
		{
			if (packet.SenderPlayerId != PlayerName)
			{
				throw Log.CreatePossibleBugException($"Attempted to deliver voice from player {packet.SenderPlayerId} to playback queue for player {PlayerName}", "F55DB7D5-621B-4F5B-8C19-700B1FBC9871");
			}
			float added = _active.Push(packet, now ?? DateTime.UtcNow);
			_arrivalJitterMeter.Update(added);
		}

		public void StopSession(bool logNoSessionError = true)
		{
			if (_active != null)
			{
				_active.Stop();
			}
			else if (logNoSessionError)
			{
				Log.Warn(Log.PossibleBugMessage("Attempted to stop a session, but there is no active session", "6DB702AA-D683-47AA-9544-BE4857EF8160"));
			}
		}

		[NotNull]
		private static DecoderPipeline GetOrCreateDecoderPipeline(FrameFormat format, [NotNull] IVolumeProvider volume)
		{
			if (volume == null)
			{
				throw new ArgumentNullException("volume");
			}
			if (!FreePipelines.TryGetValue(format, out var value))
			{
				value = new ConcurrentPool<DecoderPipeline>(3, () => new DecoderPipeline(DecoderFactory.Create(format), format.FrameSize, delegate(DecoderPipeline p)
				{
					p.Reset();
					Recycle(format, p);
				}));
				FreePipelines[format] = value;
			}
			DecoderPipeline decoderPipeline = value.Get();
			decoderPipeline.Reset();
			decoderPipeline.VolumeProvider = volume;
			return decoderPipeline;
		}

		private static void Recycle(FrameFormat format, DecoderPipeline pipeline)
		{
			if (!FreePipelines.TryGetValue(format, out var value))
			{
				Log.Warn(Log.PossibleBugMessage("Tried to recycle a pipeline but the pool for this pipeline format does not exist", "A6212BCF-9318-4224-B69F-BA4B5A651785"));
			}
			else
			{
				value.Put(pipeline);
			}
		}
	}
}
