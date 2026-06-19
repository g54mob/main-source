using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.IO.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	internal class DotsSerializationReader : IDisposable
	{
		public struct ReaderHandle : IDisposable
		{
			private unsafe readonly byte* _buffer;

			private readonly MemoryBinaryReader _reader;

			public BinaryReader Reader => _reader;

			internal unsafe ReaderHandle(NodeHandle node)
			{
				_buffer = (byte*)UnsafeUtility.Malloc(node.DataSize, 16, Allocator.TempJob);
				node.ReadData(_buffer, 0L, -1L);
				_reader = new MemoryBinaryReader(_buffer, node.DataSize);
			}

			public unsafe void Dispose()
			{
				UnsafeUtility.Free(_buffer, Allocator.TempJob);
				_reader.Dispose();
			}
		}

		public struct NodeHandle
		{
			public struct PrefetchState : IDisposable
			{
				[NativeDisableUnsafePtrRestriction]
				internal unsafe void* _buffer;

				internal long _size;

				public unsafe void Dispose()
				{
					UnsafeUtility.Free(_buffer, Allocator.Persistent);
					_buffer = null;
				}

				public unsafe MemoryBinaryReader CreateStream()
				{
					return new MemoryBinaryReader((byte*)_buffer, _size);
				}
			}

			private readonly DotsSerializationReader _owner;

			private readonly int _nodeHeaderOffset;

			private unsafe byte* SectionBaseAddress => _owner._nodesSection;

			public ref Unity.Entities.Serialization.DotsSerialization.NodeHeader AsNodeHeader => ref GetHeader(_nodeHeaderOffset);

			public bool IsValid => _owner != null;

			public int ChildrenCount => AsNodeHeader.ChildrenCount;

			public ulong NodeTypeHash => AsNodeHeader.NodeTypeHash;

			public Type NodeDotNetType => StableTypeHash.GetTypeFromTypeHash(AsNodeHeader.NodeTypeHash);

			public bool HasMetadata => AsNodeHeader.MetadataStartingOffset != -1;

			public long DataStartingOffset => AsNodeHeader.DataStartingOffset;

			public long DataSize => AsNodeHeader.DataSize;

			private unsafe ref Unity.Entities.Serialization.DotsSerialization.NodeHeader GetHeader(int offset)
			{
				return ref UnsafeUtility.AsRef<Unity.Entities.Serialization.DotsSerialization.NodeHeader>(SectionBaseAddress + offset);
			}

			public unsafe ref T As<T>() where T : unmanaged
			{
				return ref UnsafeUtility.AsRef<T>(SectionBaseAddress + _nodeHeaderOffset);
			}

			public bool MoveToNextChild(ref NodeHandle node)
			{
				if (!node.IsValid)
				{
					if (AsNodeHeader.ChildrenCount == 0)
					{
						return false;
					}
					node = new NodeHandle(_owner, _nodeHeaderOffset + AsNodeHeader.Size);
					return true;
				}
				int nextSiblingOffset = node.AsNodeHeader.NextSiblingOffset;
				if ((long)nextSiblingOffset == -1)
				{
					node = default(NodeHandle);
					return false;
				}
				node = new NodeHandle(_owner, nextSiblingOffset);
				return true;
			}

			public NodeHandle FindNode<T>(int nestedLevel = int.MaxValue) where T : unmanaged
			{
				ulong stableTypeHash = StableTypeHash.GetStableTypeHash<T>();
				return FindByType(stableTypeHash, nestedLevel);
			}

			public ReaderHandle GetReaderHandle()
			{
				return new ReaderHandle(this);
			}

			internal unsafe PrefetchState PrefetchRawDataRead(out ReadCommand readCommand)
			{
				PrefetchState result = new PrefetchState
				{
					_buffer = UnsafeUtility.Malloc(DataSize, 16, Allocator.Persistent),
					_size = DataSize
				};
				ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref AsNodeHeader;
				readCommand.Buffer = result._buffer;
				readCommand.Offset = asNodeHeader.DataStartingOffset;
				readCommand.Size = result._size;
				return result;
			}

			private NodeHandle FindByType(ulong nodeType, int nestedLevel)
			{
				NodeHandle node = default(NodeHandle);
				if (nestedLevel < 0)
				{
					return node;
				}
				while (MoveToNextChild(ref node))
				{
					if (node.AsNodeHeader.NodeTypeHash == nodeType)
					{
						return new NodeHandle(_owner, node._nodeHeaderOffset);
					}
				}
				if (nestedLevel == 0)
				{
					return default(NodeHandle);
				}
				node = default(NodeHandle);
				while (MoveToNextChild(ref node))
				{
					NodeHandle result = node.FindByType(nodeType, nestedLevel - 1);
					if (result.IsValid)
					{
						return result;
					}
				}
				return default(NodeHandle);
			}

			public bool TryFindNode(Hash128 id, out NodeHandle node, int nestedLevel = int.MaxValue)
			{
				node = FindNode(id, nestedLevel);
				return node.IsValid;
			}

			public NodeHandle FindNode(Hash128 id, int nestedLevel = int.MaxValue)
			{
				NodeHandle node = default(NodeHandle);
				if (nestedLevel <= 0)
				{
					return node;
				}
				while (MoveToNextChild(ref node))
				{
					if (node.AsNodeHeader.Id == id)
					{
						return new NodeHandle(_owner, node._nodeHeaderOffset);
					}
				}
				if (nestedLevel == 1)
				{
					return default(NodeHandle);
				}
				node = default(NodeHandle);
				while (MoveToNextChild(ref node))
				{
					NodeHandle result = node.FindNode(id, nestedLevel - 1);
					if (result.IsValid)
					{
						return result;
					}
				}
				return default(NodeHandle);
			}

			internal NodeHandle(DotsSerializationReader owner, int nodeHeaderOffset)
			{
				_owner = owner;
				_nodeHeaderOffset = nodeHeaderOffset;
			}

			public BlobAssetReference<T> GetMetadata<T>() where T : unmanaged
			{
				return _owner.GetMetadata<T>(this);
			}

			public unsafe bool ReadData(byte* buffer, long startingOffset = 0L, long readSize = -1L)
			{
				return _owner.ReadData(this, buffer, startingOffset, readSize);
			}
		}

		private readonly BinaryReader _reader;

		private unsafe readonly Unity.Entities.Serialization.DotsSerialization.NodeHeader* _rootNodeHeader;

		private unsafe readonly byte* _nodesSection;

		private unsafe readonly byte* _metadataSection;

		public NodeHandle RootNode => new NodeHandle(this, -UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>());

		public BinaryReader Reader => _reader;

		internal unsafe DotsSerializationReader(BinaryReader reader)
		{
			_reader = reader;
			Unity.Entities.Serialization.DotsSerialization.FileHeader fileHeader = default(Unity.Entities.Serialization.DotsSerialization.FileHeader);
			fixed (byte* headerMagic = DotsSerialization.HeaderMagic)
			{
				_reader.ReadBytes(&fileHeader, UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.FileHeader>());
				if (UnsafeUtility.MemCmp(&fileHeader, headerMagic, DotsSerialization.HeaderMagic.Length) != 0)
				{
					throw new Exception("The file doesn't seem to be a DOTS Serialization file.");
				}
			}
			if (fileHeader.FileVersion != 76)
			{
				throw new Exception($"Version mismatch! The file was written with version {fileHeader.FileVersion} but the latest version is {76}.");
			}
			int num = UnsafeUtility.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>();
			_rootNodeHeader = (Unity.Entities.Serialization.DotsSerialization.NodeHeader*)UnsafeUtility.Malloc(fileHeader.NodesSectionSize + num, 16, Allocator.Persistent);
			_nodesSection = (byte*)_rootNodeHeader + Unsafe.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>();
			_reader.Position = fileHeader.NodesSectionOffset;
			_reader.ReadBytes(_nodesSection, fileHeader.NodesSectionSize);
			UnsafeUtility.MemClear(_rootNodeHeader, num);
			_rootNodeHeader->NodeTypeHash = 0uL;
			_rootNodeHeader->Size = num;
			_rootNodeHeader->ChildrenCount = fileHeader.FirstLevelNodesCount;
			_rootNodeHeader->NextSiblingOffset = -1;
			_rootNodeHeader->DataStartingOffset = -1L;
			_rootNodeHeader->MetadataStartingOffset = -1L;
			_metadataSection = (byte*)UnsafeUtility.Malloc(fileHeader.MetadataSectionSize, 16, Allocator.Persistent);
			_reader.Position = fileHeader.MetadataSectionOffset;
			_reader.ReadBytes(_metadataSection, fileHeader.MetadataSectionSize);
		}

		internal unsafe DotsSerializationReader(ref Unity.Entities.Serialization.DotsSerialization.BlobHeader blobHeader)
		{
			_rootNodeHeader = (Unity.Entities.Serialization.DotsSerialization.NodeHeader*)blobHeader.NodeSection.GetUnsafePtr();
			_nodesSection = (byte*)_rootNodeHeader + Unsafe.SizeOf<Unity.Entities.Serialization.DotsSerialization.NodeHeader>();
			_metadataSection = (byte*)blobHeader.MetadataSection.GetUnsafePtr();
		}

		public unsafe void Dispose()
		{
			UnsafeUtility.Free(_rootNodeHeader, Allocator.Persistent);
			UnsafeUtility.Free(_metadataSection, Allocator.Persistent);
		}

		private unsafe bool ReadData(NodeHandle nodeHandle, byte* buffer, long startingOffset, long readSize)
		{
			if (readSize == -1)
			{
				readSize = nodeHandle.DataSize;
			}
			if (startingOffset + readSize > nodeHandle.DataSize)
			{
				return false;
			}
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			_reader.Position = asNodeHeader.DataStartingOffset + startingOffset;
			_reader.ReadBytes(buffer, (int)readSize);
			return true;
		}

		private unsafe BlobAssetReference<T> GetMetadata<T>(NodeHandle nodeHandle) where T : unmanaged
		{
			ref Unity.Entities.Serialization.DotsSerialization.NodeHeader asNodeHeader = ref nodeHandle.AsNodeHeader;
			if (!asNodeHeader.HasMetadata)
			{
				return default(BlobAssetReference<T>);
			}
			byte* ptr = _metadataSection + asNodeHeader.MetadataStartingOffset;
			BlobAssetHeader* ptr2 = (BlobAssetHeader*)ptr;
			ptr2->Allocator = Allocator.None;
			ptr2->ValidationPtr = ptr + sizeof(BlobAssetHeader);
			BlobAssetReference<T> result = default(BlobAssetReference<T>);
			result.m_data.m_Align8Union = 0L;
			result.m_data.m_Ptr = ptr + sizeof(BlobAssetHeader);
			return result;
		}
	}
}
