using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Serialization;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class DotsSerializationWriter : IDisposable
	{
		public struct WriterHandle<T> : IDisposable where T : unmanaged, IComponentData
		{
			private DotsSerializationWriter _owner;

			private readonly NodeHandle<T> _node;

			private readonly long _startPosition;

			public BinaryWriter Writer => _owner._writer;

			internal WriterHandle(DotsSerializationWriter owner, NodeHandle<T> node)
			{
				_owner = owner;
				_node = node;
				_startPosition = _owner.InitWriteData(node);
			}

			public void Dispose()
			{
				_owner.EndWriteData(_node, _startPosition);
				_owner = null;
			}
		}

		public struct DeferredWriterHandle<T> : IDisposable where T : unmanaged, IComponentData
		{
			private DotsSerializationWriter _owner;

			private readonly NodeHandle<T> _node;

			private readonly MemoryBinaryWriter _writer;

			public bool IsValid => _owner != null;

			public BinaryWriter Writer => _writer;

			internal DeferredWriterHandle(DotsSerializationWriter owner, NodeHandle<T> node)
			{
				_owner = owner;
				_node = node;
				_writer = new MemoryBinaryWriter();
			}

			public unsafe void Dispose()
			{
				_node.SubmitDeferredNodeData(_writer.Data, _writer.Length);
				_writer.Dispose();
				_owner = null;
			}
		}

		public struct NodeHandle<T> : IDisposable where T : unmanaged, IComponentData
		{
			private readonly DotsSerializationWriter _owner;

			internal unsafe readonly byte* NodeHeaderAddress;

			internal unsafe int TrackedSegmentDataWrite
			{
				get
				{
					return _owner.GetNodeTrackedSegmentDataWrite(NodeHeaderAddress);
				}
				set
				{
					_owner.SetNodeTrackedSegmentDataWrite(NodeHeaderAddress, value);
				}
			}

			public unsafe ref T NodeHeader => ref UnsafeUtility.AsRef<T>(NodeHeaderAddress);

			internal unsafe ref Unity.Entities.Serialization.DotsSerialization.NodeHeader AsNodeHeader => ref UnsafeUtility.AsRef<Unity.Entities.Serialization.DotsSerialization.NodeHeader>(NodeHeaderAddress);

			internal unsafe NodeHandle(DotsSerializationWriter owner, byte* nodeHeaderAddress)
			{
				_owner = owner;
				NodeHeaderAddress = nodeHeaderAddress;
				TrackedSegmentDataWrite = -1;
			}

			public void Dispose()
			{
				_owner.PopNode(ref this);
			}

			public bool SetMetadata<TB>(BlobAssetReference<TB> blobAssetReference) where TB : unmanaged
			{
				return _owner.SetNodeMetadata(this, blobAssetReference);
			}

			public unsafe void WriteData(void* data, int dataLength)
			{
				_owner.WriteData(this, data, dataLength);
			}

			public WriterHandle<T> GetWriterHandle()
			{
				return new WriterHandle<T>(_owner, this);
			}

			public DeferredWriterHandle<T> GetDeferredWriteHandle()
			{
				return new DeferredWriterHandle<T>(_owner, this);
			}

			internal unsafe void SubmitDeferredNodeData(byte* rawData, int rawDataLength)
			{
				WriteData(rawData, rawDataLength);
			}
		}

		private readonly BinaryWriter _writer;

		private Unity.Entities.Serialization.DotsSerialization.FileHeader _header;

		private readonly PagedAllocation _nodesAllocation;

		private UnsafeList<byte> _metadataSection;

		private byte _isDisposed;

		private byte _headerWritten;

		private int _trackedNodeCounter;

		private unsafe Unity.Entities.Serialization.DotsSerialization.NodeHeader* _rootNodeHeader;

		private NodeHandle<Unity.Entities.Serialization.DotsSerialization.NodeHeader> _rootNode;

		private readonly Dictionary<IntPtr, IntPtr> _currentLastChildOffset;

		private UnsafeList<IntPtr> _nodesStack;

		private readonly Dictionary<IntPtr, int> _trackedSegmentDataWriteByNode;

		public unsafe void Dispose()
		{
			if (_headerWritten == 0)
			{
				WriteHeader();
				_headerWritten = 1;
			}
			if (_isDisposed != 1)
			{
				UnsafeUtility.Free(_rootNodeHeader, Allocator.Persistent);
				_metadataSection.Dispose();
				_nodesAllocation.Dispose();
				_nodesStack.Dispose();
				_isDisposed = 1;
			}
		}

		public unsafe void WriteHeader()
		{
			long position = _writer.Position;
			_header.FirstLevelNodesCount = _rootNode.NodeHeader.ChildrenCount;
			_header.DataSectionSize = position - _header.DataSectionOffset;
			_header.MetadataSectionOffset = position;
			_header.MetadataSectionSize = _metadataSection.Length;
			_header.NodesSectionOffset = _header.MetadataSectionOffset + _header.MetadataSectionSize;
			_header.NodesSectionSize = _nodesAllocation.CurrentGlobalOffset;
			WriteHeaderToFile();
			_writer.WriteBytes(_metadataSection.Ptr, _metadataSection.Length);
			ref UnsafeList<PagedAllocation.PageInfo> pages = ref _nodesAllocation.Pages;
			for (int i = 0; i < pages.Length; i++)
			{
				_writer.WriteBytes(pages[i].Buffer, pages[i].FreeOffset);
			}
		}

		public unsafe BlobAssetReference<Unity.Entities.Serialization.DotsSerialization.BlobHeader> WriteHeaderAndBlob()
		{
			BlobBuilder blobBuilder = new BlobBuilder(Allocator.Persistent);
			ref Unity.Entities.Serialization.DotsSerialization.BlobHeader reference = ref blobBuilder.ConstructRoot<Unity.Entities.Serialization.DotsSerialization.BlobHeader>();
			long position = _writer.Position;
			_header.FirstLevelNodesCount = _rootNode.NodeHeader.ChildrenCount;
			_header.DataSectionSize = position - _header.DataSectionOffset;
			_header.MetadataSectionOffset = position;
			_header.MetadataSectionSize = _metadataSection.Length;
			_header.NodesSectionOffset = _header.MetadataSectionOffset + _header.MetadataSectionSize;
			_header.NodesSectionSize = _nodesAllocation.CurrentGlobalOffset;
			reference.FileHeader = _header;
			WriteHeaderToFile();
			_writer.WriteBytes(_metadataSection.Ptr, _metadataSection.Length);
			UnsafeUtility.MemCpy(blobBuilder.Allocate(ref reference.MetadataSection, _metadataSection.Length).GetUnsafePtr(), _metadataSection.Ptr, _metadataSection.Length);
			int num = UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>();
			ref UnsafeList<PagedAllocation.PageInfo> pages = ref _nodesAllocation.Pages;
			int num2 = num;
			for (int i = 0; i < pages.Length; i++)
			{
				num2 += pages[i].FreeOffset;
			}
			Unity.Entities.Serialization.DotsSerialization.NodeHeader* unsafePtr = (Unity.Entities.Serialization.DotsSerialization.NodeHeader*)blobBuilder.Allocate(ref reference.NodeSection, num2).GetUnsafePtr();
			UnsafeUtility.MemClear(unsafePtr, num);
			unsafePtr->NodeTypeHash = 0uL;
			unsafePtr->Size = num;
			unsafePtr->ChildrenCount = _rootNode.NodeHeader.ChildrenCount;
			unsafePtr->NextSiblingOffset = -1;
			unsafePtr->DataStartingOffset = -1L;
			unsafePtr->MetadataStartingOffset = -1L;
			byte* ptr = (byte*)unsafePtr + Unsafe.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>();
			for (int j = 0; j < pages.Length; j++)
			{
				_writer.WriteBytes(pages[j].Buffer, pages[j].FreeOffset);
				UnsafeUtility.MemCpy(ptr, pages[j].Buffer, pages[j].FreeOffset);
				ptr += _metadataSection.Length;
			}
			BlobAssetReference<Unity.Entities.Serialization.DotsSerialization.BlobHeader> result = blobBuilder.CreateBlobAssetReference<Unity.Entities.Serialization.DotsSerialization.BlobHeader>(Allocator.Persistent);
			blobBuilder.Dispose();
			return result;
		}

		public unsafe NodeHandle<T> CreateNode<T>(Hash128 id = default(Hash128)) where T : unmanaged, IComponentData
		{
			byte* ptr = (byte*)(void*)_nodesStack[_nodesStack.Length - 1];
			int nodeOffset;
			byte* ptr2 = AllocateNodeData<T>(out nodeOffset);
			NodeHandle<T> result = new NodeHandle<T>(this, ptr2);
			TypeManager.TypeInfo typeInfo = TypeManager.GetTypeInfo<T>();
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref result.AsNodeHeader;
			asNodeHeader.NodeTypeHash = StableTypeHash.GetStableTypeHash(typeInfo.Type);
			asNodeHeader.Size = typeInfo.TypeSize;
			asNodeHeader.Id = id;
			asNodeHeader.NextSiblingOffset = -1;
			asNodeHeader.DataStartingOffset = -1L;
			asNodeHeader.MetadataStartingOffset = -1L;
			((Unity.Entities.Serialization.DotsSerialization.NodeHeader*)ptr)->ChildrenCount++;
			SetNextSiblingOffset(ptr, ptr2, nodeOffset);
			_nodesStack.Add((IntPtr)ptr2);
			_trackedNodeCounter++;
			return result;
		}

		private unsafe int GetNodeTrackedSegmentDataWrite(byte* nodeHeaderAddress)
		{
			if (!_trackedSegmentDataWriteByNode.TryGetValue((IntPtr)nodeHeaderAddress, out var value))
			{
				return -1;
			}
			return value;
		}

		private unsafe void SetNodeTrackedSegmentDataWrite(byte* nodeHeaderAddress, int value)
		{
			IntPtr key = (IntPtr)nodeHeaderAddress;
			if (!_trackedSegmentDataWriteByNode.ContainsKey(key))
			{
				_trackedSegmentDataWriteByNode.Add(key, value);
			}
			else
			{
				_trackedSegmentDataWriteByNode[key] = value;
			}
		}

		private unsafe bool SetNodeMetadata<T, TB>(NodeHandle<T> nodeHandle, BlobAssetReference<TB> blobAssetReference) where T : unmanaged, IComponentData where TB : unmanaged
		{
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			if (asNodeHeader.MetadataStartingOffset != -1)
			{
				return false;
			}
			int length = blobAssetReference.m_data.Header->Length;
			BlobAssetHeader blobAssetHeader = BlobAssetHeader.CreateForSerialize(length, blobAssetReference.m_data.Header->Hash);
			asNodeHeader.MetadataStartingOffset = _metadataSection.Length;
			_metadataSection.AddRange(&blobAssetHeader, sizeof(BlobAssetHeader));
			_metadataSection.AddRange(blobAssetReference.m_data.Header + 1, length);
			return true;
		}

		private long InitWriteData<T>(NodeHandle<T> nodeHandle) where T : unmanaged, IComponentData
		{
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			nodeHandle.TrackedSegmentDataWrite = _trackedNodeCounter;
			asNodeHeader.DataStartingOffset = _writer.Position;
			asNodeHeader.DataSize = 0L;
			return _writer.Position;
		}

		private void EndWriteData<T>(NodeHandle<T> nodeHandle, long startPosition) where T : unmanaged, IComponentData
		{
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			if (nodeHandle.TrackedSegmentDataWrite != _trackedNodeCounter)
			{
				throw new InvalidOperationException($"Can't write data for the node {asNodeHeader.Id} before and after processing its children. You must pack your write before or after processing the children ");
			}
			asNodeHeader.DataSize = _writer.Position - startPosition;
		}

		private unsafe void WriteData<T>(NodeHandle<T> nodeHandle, void* data, int dataLength) where T : unmanaged, IComponentData
		{
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			if (nodeHandle.TrackedSegmentDataWrite == -1)
			{
				nodeHandle.TrackedSegmentDataWrite = _trackedNodeCounter;
				asNodeHeader.DataStartingOffset = _writer.Position;
				asNodeHeader.DataSize = 0L;
			}
			if (nodeHandle.TrackedSegmentDataWrite != _trackedNodeCounter)
			{
				throw new InvalidOperationException($"Can't write data for the node {asNodeHeader.Id} before and after processing its children. You must pack your write before or after processing the children ");
			}
			_writer.WriteBytes(data, dataLength);
			asNodeHeader.DataSize += dataLength;
		}

		private unsafe void SetNextSiblingOffset(byte* parentNode, byte* newChildNode, int newChildOffset)
		{
			_currentLastChildOffset.TryGetValue((IntPtr)parentNode, out var value);
			_currentLastChildOffset.Add((IntPtr)newChildNode, IntPtr.Zero);
			if (value != IntPtr.Zero)
			{
				((Unity.Entities.Serialization.DotsSerialization.NodeHeader*)(void*)value)->NextSiblingOffset = newChildOffset;
			}
			_currentLastChildOffset[(IntPtr)parentNode] = (IntPtr)newChildNode;
		}

		private unsafe byte* AllocateNodeData<T>(out int nodeOffset) where T : unmanaged, IComponentData
		{
			int size = UnsafeUtility.SizeOf<T>();
			nodeOffset = _nodesAllocation.CurrentGlobalOffset;
			return _nodesAllocation.Reserve(size);
		}

		private unsafe void PopNode<T>(ref NodeHandle<T> nodeHandle) where T : unmanaged, IComponentData
		{
			_currentLastChildOffset.Remove((IntPtr)nodeHandle.NodeHeaderAddress);
			_nodesStack.RemoveAt(_nodesStack.Length - 1);
		}

		internal unsafe DotsSerializationWriter(BinaryWriter writer, Hash128 fileId, FixedString64Bytes fileType)
		{
			_writer = writer;
			_currentLastChildOffset = new Dictionary<IntPtr, IntPtr>();
			_metadataSection = new UnsafeList<byte>(1048576, Allocator.Temp);
			_nodesAllocation = new PagedAllocation(Allocator.Persistent);
			_trackedNodeCounter = 0;
			_trackedSegmentDataWriteByNode = new Dictionary<IntPtr, int>();
			_rootNodeHeader = (Unity.Entities.Serialization.DotsSerialization.NodeHeader*)UnsafeUtility.Malloc(Unsafe.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>(), 16, Allocator.Persistent);
			UnsafeUtility.MemClear(_rootNodeHeader, Unsafe.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>());
			_rootNodeHeader->NodeTypeHash = 0uL;
			byte* rootNodeHeader = (byte*)_rootNodeHeader;
			_rootNode = new NodeHandle<Unity.Entities.Serialization.DotsSerialization.NodeHeader>(this, rootNodeHeader);
			_currentLastChildOffset.Add((IntPtr)rootNodeHeader, IntPtr.Zero);
			_nodesStack = new UnsafeList<IntPtr>(16, Allocator.Persistent);
			_nodesStack.Add((IntPtr)rootNodeHeader);
			fixed (byte* headerMagic = DotsSerialization.HeaderMagic)
			{
				UnsafeUtility.MemCpy(UnsafeUtility.AddressOf(ref _header.MagicValue), headerMagic, DotsSerialization.HeaderMagic.Length);
			}
			_header.FileVersion = 76;
			_header.FileId = fileId;
			_header.HeaderSize = UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.FileHeader>();
			_header.FileType = fileType;
			_header.DataSectionOffset = _header.HeaderSize;
			_writer.Position = _header.DataSectionOffset;
		}

		private unsafe void WriteHeaderToFile()
		{
			long position = _writer.Position;
			_writer.Position = 0L;
			_writer.WriteBytes(UnsafeUtility.AddressOf(ref _header), UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.FileHeader>());
			_writer.Position = position;
		}
	}
}
