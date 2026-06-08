using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace Kitchen
{
	public abstract class BurstIncrementalViewSystemBase<T> : ViewSystemBase where T : struct, IViewData, IViewData.ICheckForChanges<T>
	{
		public struct ViewIdentifierKey : IEquatable<ViewIdentifierKey>
		{
			public ViewIdentifier View;

			public int Nonce;

			public ViewIdentifierKey(ViewIdentifier view, int nonce)
			{
				View = view;
				Nonce = nonce;
			}

			public bool Equals(ViewIdentifierKey other)
			{
				if (View.Equals(other.View))
				{
					return Nonce == other.Nonce;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is ViewIdentifierKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return (int)math.hash(new int2(View.Identifier, Nonce));
			}
		}

		protected struct BurstContext
		{
			public NativeHashMap<ViewIdentifierKey, T> PreviousViewUpdates;

			public NativeList<(ViewIdentifier, T, int)> NewViewUpdates;

			public void ProposeUpdate(ViewIdentifier linked_view, T view_data, int nonce = 0)
			{
				if (!PreviousViewUpdates.TryGetValue(new ViewIdentifierKey(linked_view, nonce), out var item) || item.IsChangedFrom(view_data))
				{
					NewViewUpdates.Add((linked_view, view_data, nonce));
				}
			}
		}

		protected NativeHashMap<ViewIdentifierKey, T> PreviousViewUpdates = new NativeHashMap<ViewIdentifierKey, T>(128, Allocator.Persistent);

		protected NativeList<(ViewIdentifier, T, int)> NewViewUpdates = new NativeList<(ViewIdentifier, T, int)>(Allocator.Persistent);

		private List<ViewIdentifierKey> CachedToRemove = new List<ViewIdentifierKey>();

		protected virtual MessageType MessageType => MessageType.ViewUpdate;

		protected BurstContext GetContext()
		{
			return new BurstContext
			{
				PreviousViewUpdates = PreviousViewUpdates,
				NewViewUpdates = NewViewUpdates
			};
		}

		protected abstract void PopulateNewViewUpdates(BurstContext bctx);

		protected sealed override void OnUpdate()
		{
			NewViewUpdates.Clear();
			PopulateNewViewUpdates(GetContext());
			foreach (var newViewUpdate in NewViewUpdates)
			{
				PreviousViewUpdates[new ViewIdentifierKey(newViewUpdate.Item1, newViewUpdate.Item3)] = newViewUpdate.Item2;
				SendUpdate(newViewUpdate.Item1, newViewUpdate.Item2, MessageType);
			}
		}

		public override void ClearUpdates(ViewIdentifier id)
		{
			CachedToRemove.Clear();
			foreach (KeyValue<ViewIdentifierKey, T> previousViewUpdate in PreviousViewUpdates)
			{
				if (previousViewUpdate.Key.View == id)
				{
					CachedToRemove.Add(previousViewUpdate.Key);
				}
			}
			foreach (ViewIdentifierKey item in CachedToRemove)
			{
				PreviousViewUpdates.Remove(item);
			}
			base.ClearUpdates(id);
		}

		public static void ProposeUpdate(NativeList<(ViewIdentifier, T)> new_updates, NativeHashMap<ViewIdentifier, T> old_updates, ViewIdentifier linked_view, T view_data)
		{
			if (!old_updates.TryGetValue(linked_view, out var item) || item.IsChangedFrom(view_data))
			{
				new_updates.Add((linked_view, view_data));
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (PreviousViewUpdates.IsCreated)
			{
				PreviousViewUpdates.Dispose();
			}
			if (NewViewUpdates.IsCreated)
			{
				NewViewUpdates.Dispose();
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
