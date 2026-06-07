using System;
using System.Collections.Generic;
using System.Diagnostics;
using Coherence.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Coherence.Toolkit
{
	public class CoherenceInputDebugger
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum Event
		{
			Error = 0,
			ClientJoined = 1,
			ClientLeft = 2,
			Rollback = 3,
			Pause = 4,
			UnPause = 5,
			InputSent = 6,
			InputReceived = 7
		}

		private class FrameSample
		{
			public long Frame;

			public long AckFrame;

			public long ReceiveFrame;

			public long AckedAt;

			public long MispredictionFrame;

			public string Hash;

			public string Time;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public long UpdatedAt;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public bool ShouldPause;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public object UpdatedState;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public Dictionary<string, string> UpdatedInputs;

			public object InitialState;

			public Dictionary<string, string> InitialInputs;

			public Dictionary<string, InputBufferState> InputBufferStates;

			[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
			public List<EventData> Events;

			public FrameSample(CoherenceInputManager inputManager)
			{
			}
		}

		private struct InputBufferState
		{
			public long LastFrame;

			public long LastSentFrame;

			public long LastReceivedFrame;

			public long LastAcknowledgedFrame;

			public long? MispredictionFrame;

			public int QueueCount;

			public bool ShouldPause;
		}

		private struct EventData
		{
			public string Event;

			public string Time;

			public object Data;

			public EventData(string @event, object data)
			{
				Event = null;
				Time = null;
				Data = null;
			}
		}

		public const string DEBUG_CONDITIONAL = "COHERENCE_INPUT_DEBUG";

		public Action<string> OnDump;

		private readonly CoherenceInputManager inputManager;

		private FrameSample currentSample;

		private long lastAcknowledgedFrame;

		private readonly Logger logger;

		private readonly SortedDictionary<long, FrameSample> allSamples;

		private readonly Dictionary<ICoherenceInput, string> idByInput;

		public int? FramesToKeep { get; set; }

		public CoherenceInputDebugger(CoherenceInputManager inputManager, Action<string> onDataDump = null)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AddInput(CoherenceInput input, string id)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void RemoveInput(CoherenceInput input)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void PushSample()
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void SetInputBufferStates()
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AddEvent(Event inputEvent, object eventData)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AddEvent(string inputEvent, object eventData)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AddState(long frame, object state)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AddInputs(long frame, IEnumerable<DebugInput> inputs, bool simulationEnabled)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void AcknowledgeFrame(long frame)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void HandleInputReceived(CoherenceInput coherenceInput, long frame, object input)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void HandleInputSent(CoherenceInput coherenceInput, long frame, object input)
		{
		}

		[Conditional("COHERENCE_INPUT_DEBUG")]
		public void Dump()
		{
		}

		private void SaveToFile(string data)
		{
		}
	}
}
