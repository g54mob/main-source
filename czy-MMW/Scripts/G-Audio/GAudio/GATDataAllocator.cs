using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GAudio
{
	public sealed class GATDataAllocator : IDisposable
	{
		public class GATManagedData : GATData
		{
			protected readonly GATDataAllocator _manager;

			public GATManagedData next;

			public int allocatedSize;

			public virtual int MaxSize => next.MemOffset - _offset;

			public override int Count => allocatedSize;

			public GATManagedData(GATDataAllocator manager)
				: base(manager._mainBuffer)
			{
				_manager = manager;
			}

			protected override void Discard()
			{
				allocatedSize = 0;
				_manager.AddToFreeChunksBins(this);
			}

			public void AllocateFree(int offset, GATManagedData inext)
			{
				next = inext;
				_offset = offset;
				allocatedSize = 0;
				_retainCount = 0;
			}

			public override IntPtr GetPointer()
			{
				return _manager._mainBufferPointer;
			}
		}

		public class GATFixedData : GATManagedData
		{
			public override int MaxSize => allocatedSize;

			public string Description { get; protected set; }

			public GATFixedData(GATDataAllocator manager, string description)
				: base(manager)
			{
				Description = description;
			}

			protected override void Discard()
			{
			}
		}

		[Serializable]
		public class InitializationSettings
		{
			public float preAllocatedAudioDuration = 100f;

			public int maxConcurrentSamples = 50;

			public int binWidth = 16384;

			public int nbOfBins = 20;
		}

		private int _fixedAllocationsSize;

		private readonly float[] _mainBuffer;

		private GATManagedData _firstCursor;

		private GATManagedData _unallocatedCursor;

		private GATManagedData _endCursor;

		private readonly Stack<GATManagedData> _pool;

		private readonly Stack<GATManagedData>[] _freeChunksBins;

		private readonly int _binWidth;

		private readonly int _nbOfBins;

		private readonly int _maxBinSize;

		private readonly int _totalSize;

		private GCHandle _mainBufferHandle;

		private IntPtr _mainBufferPointer;

		private bool _disposed;

		public int LargestFreeChunkSize
		{
			get
			{
				if (_unallocatedCursor.MaxSize >= _maxBinSize)
				{
					return _maxBinSize;
				}
				for (int num = _nbOfBins - 1; num >= 0; num--)
				{
					if (_freeChunksBins[num].Count > 0)
					{
						return _binWidth + num * _binWidth;
					}
				}
				return 0;
			}
		}

		public int TotalSize => _totalSize;

		public int BinWidth => _binWidth;

		public int NbOfBins => _freeChunksBins.Length;

		public int UnfragmentedSize => _unallocatedCursor.MaxSize;

		public int FixedAllocationsSize => _fixedAllocationsSize;

		public int TotalNonFixedSize => _totalSize - _fixedAllocationsSize;

		public int NbOfAvailableChunksForSize(int size)
		{
			int i = GetBinIndexForSize(size);
			int num = 0;
			for (; i < _nbOfBins; i++)
			{
				num += _freeChunksBins[i].Count;
			}
			return num + _unallocatedCursor.MaxSize / size;
		}

		public GATDataAllocator(InitializationSettings initSettings)
		{
			_totalSize = (int)(initSettings.preAllocatedAudioDuration * (float)GATInfo.OutputSampleRate);
			_mainBuffer = new float[_totalSize];
			_pool = new Stack<GATManagedData>(initSettings.maxConcurrentSamples);
			_binWidth = initSettings.binWidth;
			_nbOfBins = initSettings.nbOfBins;
			for (int i = 0; i < initSettings.maxConcurrentSamples; i++)
			{
				GATManagedData item = new GATManagedData(this);
				_pool.Push(item);
			}
			_freeChunksBins = new Stack<GATManagedData>[_nbOfBins];
			for (int i = 0; i < _nbOfBins; i++)
			{
				_freeChunksBins[i] = new Stack<GATManagedData>(20);
			}
			InitCursors();
			_maxBinSize = _nbOfBins * _binWidth;
			_mainBufferHandle = GCHandle.Alloc(_mainBuffer, GCHandleType.Pinned);
			_mainBufferPointer = _mainBufferHandle.AddrOfPinnedObject();
		}

		public GATData GetDataContainer(int size)
		{
			GATManagedData chunk = null;
			int binIndexForSize = GetBinIndexForSize(size);
			int num = _binWidth + binIndexForSize * _binWidth;
			if (_freeChunksBins[binIndexForSize].Count != 0)
			{
				chunk = _freeChunksBins[binIndexForSize].Pop();
			}
			else if (_unallocatedCursor.MaxSize >= num)
			{
				chunk = _unallocatedCursor;
				chunk.allocatedSize = size;
				_unallocatedCursor = GetOrMakeChunk();
				_unallocatedCursor.AllocateFree(chunk.MemOffset + num, _endCursor);
				chunk.next = _unallocatedCursor;
			}
			else if (!TryFragmentBins(binIndexForSize + 1, num, ref chunk))
			{
				Defragment();
				if (_freeChunksBins[binIndexForSize].Count != 0)
				{
					chunk = _freeChunksBins[binIndexForSize].Pop();
				}
				else if (_unallocatedCursor.MaxSize >= num)
				{
					chunk = _unallocatedCursor;
					chunk.allocatedSize = size;
					_unallocatedCursor = GetOrMakeChunk();
					_unallocatedCursor.AllocateFree(chunk.MemOffset + num, _endCursor);
					chunk.next = _unallocatedCursor;
				}
				else if (!TryFragmentBins(binIndexForSize + 1, num, ref chunk))
				{
					throw new GATException("Out of memory!");
				}
			}
			chunk.allocatedSize = size;
			return chunk;
		}

		public GATData GetFixedDataContainer(int size, string description)
		{
			if (_unallocatedCursor.MaxSize < size)
			{
				throw new GATException("Out of fixed memory!");
			}
			int offset = _endCursor.MemOffset - size;
			GATFixedData gATFixedData = new GATFixedData(this, description);
			gATFixedData.AllocateFree(offset, _endCursor.next);
			gATFixedData.allocatedSize = size;
			_endCursor.AllocateFree(offset, gATFixedData);
			_fixedAllocationsSize += size;
			return gATFixedData;
		}

		public void Defragment()
		{
			GATManagedData gATManagedData = _firstCursor.next;
			if (gATManagedData == _unallocatedCursor)
			{
				return;
			}
			GATManagedData next = gATManagedData.next;
			for (int i = 0; i < _freeChunksBins.Length; i++)
			{
				_freeChunksBins[i].Clear();
			}
			while (next != _unallocatedCursor)
			{
				if (gATManagedData.allocatedSize == 0)
				{
					if (next.allocatedSize == 0)
					{
						gATManagedData.next = next.next;
						_pool.Push(next);
						next = gATManagedData.next;
						continue;
					}
					while (gATManagedData.MaxSize > _maxBinSize)
					{
						GATManagedData orMakeChunk = GetOrMakeChunk();
						orMakeChunk.AllocateFree(gATManagedData.MemOffset + _maxBinSize, next);
						gATManagedData.next = orMakeChunk;
						AddToFreeChunksBins(gATManagedData);
						gATManagedData = orMakeChunk;
					}
					if (gATManagedData.MaxSize != 0)
					{
						AddToFreeChunksBins(gATManagedData);
					}
					else
					{
						_pool.Push(gATManagedData);
					}
					gATManagedData = next;
					next = next.next;
				}
				else
				{
					gATManagedData = next;
					next = next.next;
				}
			}
			if (gATManagedData.allocatedSize == 0)
			{
				_pool.Push(_unallocatedCursor);
				_unallocatedCursor = gATManagedData;
				_unallocatedCursor.next = _endCursor;
			}
		}

		public void CleanUp()
		{
			if (_mainBufferHandle.IsAllocated)
			{
				_mainBufferHandle.Free();
				_mainBufferPointer = IntPtr.Zero;
			}
		}

		public List<GATMemDebugInfo> GetDebugInfo()
		{
			int num = 0;
			List<GATMemDebugInfo> list = new List<GATMemDebugInfo>();
			GATManagedData next = _firstCursor.next;
			while (next.next != _endCursor)
			{
				list.Add(new GATMemDebugInfo(num, next.allocatedSize, next.MaxSize));
				num++;
				next = next.next;
			}
			return list;
		}

		public List<GATFixedMemDebugInfo> GetFixedDebugInfo()
		{
			int num = 0;
			List<GATFixedMemDebugInfo> list = new List<GATFixedMemDebugInfo>();
			for (GATManagedData next = _endCursor.next; next != null; next = next.next)
			{
				GATFixedData gATFixedData = next as GATFixedData;
				list.Add(new GATFixedMemDebugInfo(num, gATFixedData.allocatedSize, gATFixedData.Description));
				num++;
			}
			return list;
		}

		private void InitCursors()
		{
			_endCursor = new GATFixedData(this, "");
			_endCursor.AllocateFree(_mainBuffer.Length, null);
			_unallocatedCursor = new GATManagedData(this);
			_unallocatedCursor.AllocateFree(0, _endCursor);
			_firstCursor = new GATManagedData(this);
			_firstCursor.AllocateFree(0, _unallocatedCursor);
		}

		private GATManagedData GetOrMakeChunk()
		{
			if (_pool.Count != 0)
			{
				return _pool.Pop();
			}
			return new GATManagedData(this);
		}

		private int GetBinIndexForSize(int size)
		{
			if (size <= _binWidth)
			{
				return 0;
			}
			int num = (size - _binWidth - 1) / _binWidth + 1;
			if (num >= _nbOfBins)
			{
				Debug.LogError("no such bin");
				return -1;
			}
			return num;
		}

		private void AddToFreeChunksBins(GATManagedData chunk)
		{
			int num = (chunk.MaxSize - _binWidth) / _binWidth;
			_freeChunksBins[num].Push(chunk);
		}

		private bool TryFragmentBins(int fromBinIndex, int binSize, ref GATManagedData chunk)
		{
			for (int i = fromBinIndex; i < _nbOfBins; i++)
			{
				if (_freeChunksBins[i].Count != 0)
				{
					chunk = _freeChunksBins[i].Pop();
					GATManagedData orMakeChunk = GetOrMakeChunk();
					orMakeChunk.AllocateFree(chunk.MemOffset + binSize, chunk.next);
					chunk.next = orMakeChunk;
					AddToFreeChunksBins(orMakeChunk);
					return true;
				}
			}
			return false;
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				CleanUp();
				_disposed = true;
			}
		}

		~GATDataAllocator()
		{
			Dispose(explicitly: false);
		}
	}
}
