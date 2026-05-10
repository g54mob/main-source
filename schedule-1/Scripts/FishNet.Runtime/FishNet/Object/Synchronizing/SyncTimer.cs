using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;

namespace FishNet.Object.Synchronizing
{
	public class SyncTimer : SyncBase, ICustomSync
	{
		private struct ChangeData
		{
			public readonly SyncTimerOperation Operation;

			public readonly float Previous;

			public readonly float Next;

			public ChangeData(SyncTimerOperation operation, float previous, float next)
			{
				Operation = default(SyncTimerOperation);
				Previous = 0f;
				Next = 0f;
			}
		}

		public delegate void SyncTypeChanged(SyncTimerOperation op, float prev, float next, bool asServer);

		private List<ChangeData> _changed;

		private readonly List<ChangeData> _serverOnChanges;

		private readonly List<ChangeData> _clientOnChanges;

		public float Remaining { get; private set; }

		public float Elapsed => 0f;

		public float Duration { get; private set; }

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

		public void StartTimer(float remaining, bool sendRemainingOnStop = true)
		{
		}

		public void PauseTimer(bool sendRemaining = false)
		{
		}

		public void UnpauseTimer()
		{
		}

		public void StopTimer(bool sendRemaining = false)
		{
		}

		private void AddOperation(SyncTimerOperation operation, float prev, float next)
		{
		}

		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public override void WriteFull(PooledWriter writer)
		{
		}

		private void WriteStartTimer(Writer w, bool includeOperationByte)
		{
		}

		private bool CanSetValues(bool asServer)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public override void Read(PooledReader reader, bool asServer)
		{
		}

		private void StopTimer_Internal(bool asServer)
		{
		}

		private void InvokeOnChange(SyncTimerOperation operation, float prev, float next, bool asServer)
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
