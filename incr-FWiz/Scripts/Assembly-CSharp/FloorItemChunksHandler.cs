using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloorItemChunksHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUpdateChunksCoroutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public FloorItemChunksHandler _003C_003E4__this;

		private int _003Cprocessed_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUpdateChunksCoroutine_003Ed__16(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public float chunkSize;

	private Dictionary<Vector2Int, HashSet<FloorItem>> chunkedItems;

	private List<FloorItem> _allItems;

	private int _updateIndex;

	public const float _updateItemsPerFrame = 1f;

	private Coroutine _updatingChunksCoroutine;

	public List<FloorItem> GetAllItems()
	{
		return null;
	}

	public Vector2Int WorldToChunk(Vector2 position)
	{
		return default(Vector2Int);
	}

	public void RegisterItem(FloorItem item)
	{
	}

	public void UnregisterItem(FloorItem item)
	{
	}

	public void UpdateItemPosition(FloorItem item)
	{
	}

	public List<FloorItem> GetItemsInChunkRadius(Vector2 position, int radiusChunks = 1)
	{
		return null;
	}

	public void GetItemsInChunkRadius(Vector2 position, List<FloorItem> results, int radiusChunks = 1)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void StartUpdatingChunks()
	{
	}

	[IteratorStateMachine(typeof(_003CUpdateChunksCoroutine_003Ed__16))]
	private IEnumerator UpdateChunksCoroutine()
	{
		return null;
	}
}
