using System.Runtime.CompilerServices;
using FishNet.Documenting;
using FishNet.Object.Synchronizing;
using FishNet.Object.Synchronizing.Internal;
using FishNet.Serializing;
using UnityEngine;

namespace FishNet.Example.ComponentStateSync
{
	public class ComponentStateSync<T> : SyncBase, ICustomSync where T : MonoBehaviour
	{
		public delegate void StateChanged(T component, bool prevState, bool nextState, bool asServer);

		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public T Component { get; private set; }

		public event StateChanged OnChange
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

		public void Initialize(T component)
		{
		}

		private void SetState(bool enabled)
		{
		}

		private bool GetState()
		{
			return false;
		}

		private void AddOperation(T component, bool prev, bool next)
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

		public object GetSerializedType()
		{
			return null;
		}
	}
}
