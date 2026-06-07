using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Coherence.Toolkit
{
	public class CoherenceInputManager
	{
		private long? pendingMisprediction;

		private bool processingEnabled;

		private readonly List<ICoherenceInput> allInputs;

		private readonly ICoherenceBridge bridge;

		public long CommonReceivedFrame { get; private set; }

		public long AcknowledgedFrame { get; private set; }

		public long? MispredictionFrame { get; private set; }

		public bool ShouldPause { get; private set; }

		public bool ProcessingEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public long CurrentFixedSimulationFrame => 0L;

		public event PauseHandler OnPauseChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public CoherenceInputManager(ICoherenceBridge bridge)
		{
		}

		internal void Reset()
		{
		}

		internal void AddInput(ICoherenceInput input)
		{
		}

		internal void RemoveInput(ICoherenceInput input)
		{
		}

		internal void Update()
		{
		}

		private void FixedNetworkUpdate()
		{
		}

		private void LateFixedNetworkUpdate()
		{
		}

		private void UpdateLastReceivedFrame()
		{
		}

		private void UpdateMispredictionFrame()
		{
		}

		private void CheckPause()
		{
		}

		private void CheckUnPause()
		{
		}

		private void HandleTimeReset()
		{
		}
	}
}
