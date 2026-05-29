using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;

namespace FishNet.Example.CustomSyncObject
{
	public class StructySync : SyncBase, ICustomSync
	{
		private struct ChangeData
		{
			internal CustomOperation Operation;

			internal Structy Data;

			public ChangeData(CustomOperation operation, Structy data)
			{
				Operation = default(CustomOperation);
				Data = default(Structy);
			}
		}

		public enum CustomOperation : byte
		{
			Full = 0,
			Name = 1,
			Age = 2
		}

		public delegate void CustomChanged(CustomOperation op, Structy oldItem, Structy newItem, bool asServer);

		public Structy Value;

		private Structy _initialValue;

		private readonly List<ChangeData> _changed;

		private bool _valuesChanged;

		private Structy _lastDirtied;

		public event CustomChanged OnChange
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

		protected override void Registered()
		{
		}

		private void AddOperation(CustomOperation operation, Structy prev, Structy next)
		{
		}

		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public override void WriteFull(PooledWriter writer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[APIExclude]
		public override void Read(PooledReader reader, bool asServer)
		{
		}

		public void ValuesChanged()
		{
		}

		public override void ResetState()
		{
		}

		public object GetSerializedType()
		{
			return null;
		}
	}
}
