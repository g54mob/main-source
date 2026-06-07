using System;
using Unity.Netcode;

namespace Brewery.Systems.Processing
{
	public struct ProcessStepState<TStep> : INetworkSerializable where TStep : struct, Enum
	{
		public TStep Step;

		public float DurationSeconds;

		public float Progress;

		public bool IsComplete;

		public ProcessStepState(TStep step, float durationSeconds)
		{
			Step = default(TStep);
			DurationSeconds = 0f;
			Progress = 0f;
			IsComplete = false;
		}

		public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
		{
		}
	}
}
