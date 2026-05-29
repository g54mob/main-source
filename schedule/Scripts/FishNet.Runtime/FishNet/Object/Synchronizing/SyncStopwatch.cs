using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;

namespace FishNet.Object.Synchronizing
{
	public class SyncStopwatch : SyncBase, ICustomSync
	{
		private struct ChangeData
		{
			public readonly SyncStopwatchOperation Operation;

			public readonly float Previous;

			public ChangeData(SyncStopwatchOperation operation, float previous)
			{
				Operation = default(SyncStopwatchOperation);
				Previous = 0f;
			}
		}

		public delegate void SyncTypeChanged(SyncStopwatchOperation op, float prev, bool asServer);

		private List<ChangeData> _changed;

		private readonly List<ChangeData> _serverOnChanges;

		private readonly List<ChangeData> _clientOnChanges;

		public float Elapsed { get; private set; }

		public bool Paused { get; private set; }

		public event SyncTypeChanged OnChange
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

		public void StartStopwatch(bool sendElapsedOnStop = true)
		{
		}

		public void PauseStopwatch(bool sendElapsed = false)
		{
		}

		public void UnpauseStopwatch()
		{
		}

		public void StopStopwatch(bool sendElapsed = false)
		{
		}

		private void AddOperation(SyncStopwatchOperation operation, float prev)
		{
		}

		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public override void WriteFull(PooledWriter writer)
		{
		}

		private void WriteStartStopwatch(Writer w, float elapsed, bool includeOperationByte)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public override void Read(PooledReader reader, bool asServer)
		{
		}

		private bool CanSetValues(bool asServer)
		{
			return false;
		}

		private void StopStopwatch_Internal(bool asServer)
		{
		}

		private void InvokeOnChange(SyncStopwatchOperation operation, float prev, bool asServer)
		{
		}

		public override void OnStartCallback(bool asServer)
		{
		}

		public void Update(float delta)
		{
		}

		public object GetSerializedType()
		{
			return null;
		}
	}
}
