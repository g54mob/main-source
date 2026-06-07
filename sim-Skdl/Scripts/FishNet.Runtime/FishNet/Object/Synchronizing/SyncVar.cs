using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using FishNet.Transporting;

namespace FishNet.Object.Synchronizing
{
	[StructLayout((LayoutKind)3, CharSet = CharSet.Auto)]
	[APIExclude]
	public class SyncVar<T> : SyncBase
	{
		private struct CachedOnChange
		{
			internal readonly T Previous;

			internal readonly T Next;

			public CachedOnChange(T previous, T next)
			{
				Previous = default(T);
				Next = default(T);
			}
		}

		private CachedOnChange? _serverOnChange;

		private CachedOnChange? _clientOnChange;

		private T _initialValue;

		private T _previousClientValue;

		private T _value;

		public event Action<T, T, bool> OnChange
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public SyncVar(NetworkBehaviour nb, uint syncIndex, WritePermission writePermission, ReadPermission readPermission, float sendRate, Channel channel, T value)
		{
		}

		protected override void Registered()
		{
		}

		private void SetInitialValues(T next)
		{
		}

		private void UpdateValues(T next)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetValue(T nextValue, bool calledByUser)
		{
		}

		private void InvokeOnChange(T prev, T next, bool asServer)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override void OnStartCallback(bool asServer)
		{
		}

		public override void WriteDelta(PooledWriter writer, bool resetSyncTick = true)
		{
		}

		public override void WriteFull(PooledWriter obj0)
		{
		}

		public T GetValue(bool calledByUser)
		{
			return default(T);
		}

		public override void ResetState()
		{
		}
	}
}
