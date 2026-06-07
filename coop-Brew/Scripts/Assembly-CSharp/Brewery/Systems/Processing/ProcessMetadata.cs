using System;
using Unity.Collections;
using Unity.Netcode;

namespace Brewery.Systems.Processing
{
	public struct ProcessMetadata<TStep> : INetworkSerializable where TStep : struct, Enum
	{
		public TStep CurrentStep;

		public double CurrentStepStartTime;

		public float CurrentStepElapsed;

		public ProcessStepState<TStep>[] Steps;

		public ProcessOptionState[] Options;

		public int TotalBatches;

		public int CurrentBatch;

		public int BatchesCompleted;

		public static ProcessMetadata<TStep> Create(TStep initialStep, ReadOnlySpan<ProcessStepDefinition<TStep>> stepDefinitions, ReadOnlySpan<ProcessOptionDefinition> optionDefinitions)
		{
			return default(ProcessMetadata<TStep>);
		}

		public ProcessStepState<TStep> GetStepState(TStep step)
		{
			return default(ProcessStepState<TStep>);
		}

		public void UpdateStepState(ProcessStepState<TStep> state)
		{
		}

		public bool TryGetOption(FixedString64Bytes key, out ProcessOptionState option)
		{
			option = default(ProcessOptionState);
			return false;
		}

		public void SetOption(FixedString64Bytes key, bool enabled)
		{
		}

		public void SetOption(string key, bool enabled)
		{
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
