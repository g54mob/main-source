using System;
using System.IO;
using System.IO.Compression;
using Pug.ECS.Serialization.DOTS100;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Profiling;
using UnityEngine;

namespace Pug.ECS.Serialization
{
	public class WorldDeserializer
	{
		private const int BUFFER_SIZE = 1048576;

		private static readonly ProfilerMarker GetSizeMarker = new ProfilerMarker("GetSize");

		private static readonly ProfilerMarker ReadStreamMarker = new ProfilerMarker("ReadStream");

		private readonly byte[] _buffer = new byte[1048576];

		public DeserializationStates DeserializeWorld(World world, byte[] fileData)
		{
			DeserializationStates deserializationStates = DeserializationStates.Invalid;
			try
			{
				NativeList<byte> fileData2 = DecompressSerializedWorld(fileData, Allocator.Temp);
				if (ShouldPatch(fileData2, out var version))
				{
					deserializationStates = DeserializationStates.Patching;
				}
				else
				{
					switch (version)
					{
					case 76:
						Debug.Log("Loading an older post DOTS 1.1 world file");
						DeserializeWorldDOTS100(fileData2, world);
						deserializationStates = DeserializationStates.Finished;
						break;
					case 77:
						DeserializeWorld(fileData2, world);
						deserializationStates = DeserializationStates.Finished;
						break;
					default:
						throw new NotImplementedException($"World version {version} is new and not yet supported.");
					}
				}
			}
			catch (Exception exception)
			{
				deserializationStates = DeserializationStates.SaveFileCorrupt;
				Debug.LogException(exception);
			}
			return deserializationStates;
		}

		private NativeList<byte> DecompressSerializedWorld(byte[] fileData, Allocator allocator)
		{
			uint size;
			bool flag = FileCompressionUtility.TryGetGzipCompressedSize(fileData, out size);
			bool flag2 = !flag && FileCompressionUtility.TryGetBrotliCompressedSize(fileData, out size, _buffer);
			if (!flag && !flag2)
			{
				throw new ArgumentException("Provided buffer is not GZIP or Brotli compressed");
			}
			if (size > 1073741824)
			{
				throw new ArgumentException("Decompressed size is too large");
			}
			int num = (int)size;
			NativeList<byte> nativeList = new NativeList<byte>(num, allocator);
			nativeList.ResizeUninitialized(num);
			using MemoryStream stream = new MemoryStream(fileData);
			using Stream stream2 = (flag ? ((Stream)new GZipStream(stream, CompressionMode.Decompress)) : ((Stream)new BrotliStream(stream, CompressionMode.Decompress)));
			ReadStream(stream2, nativeList);
			string arg = (flag ? "gzip" : "brotli");
			Debug.Log($"Decompressed {arg} compressed world file: {fileData.Length} bytes -> {num} bytes");
			return nativeList;
		}

		private unsafe void ReadStream(Stream stream, NativeArray<byte> decompressedData)
		{
			fixed (byte* buffer = _buffer)
			{
				int num2;
				for (int i = 0; i < decompressedData.Length; i += num2)
				{
					int num = Math.Min(_buffer.Length, decompressedData.Length - i);
					num2 = stream.Read(_buffer, 0, num);
					if (num2 != num)
					{
						throw new ArgumentException("Decompressed data is smaller than expected");
					}
					UnsafeUtility.MemCpy((byte*)decompressedData.GetUnsafePtr() + i, buffer, num2);
				}
			}
			if (stream.ReadByte() != -1)
			{
				throw new ArgumentException("Stream has more data than expected");
			}
		}

		private unsafe static bool ShouldPatch(NativeList<byte> fileData, out int version)
		{
			if (fileData.Length < 4)
			{
				throw new ArgumentException("Way too small fileData for world save");
			}
			byte* unsafePtr = fileData.GetUnsafePtr();
			using Unity.Entities.Serialization.MemoryBinaryReader reader = new Unity.Entities.Serialization.MemoryBinaryReader(unsafePtr, fileData.Length);
			version = *(int*)unsafePtr;
			if (version == 57)
			{
				return true;
			}
			version = SerializationExtensions.ReadSerializationVersion(reader);
			return version < 76;
		}

		private unsafe static void DeserializeWorldDOTS100(NativeList<byte> fileData, World world)
		{
			if (fileData.Length < 4)
			{
				throw new ArgumentException("Way too small fileData for world save");
			}
			world.EntityManager.PrepareForDeserialize();
			using Pug.ECS.Serialization.DOTS100.MemoryBinaryReader reader = new Pug.ECS.Serialization.DOTS100.MemoryBinaryReader(fileData.GetUnsafePtr(), fileData.Length);
			ExclusiveEntityTransaction manager = world.EntityManager.BeginExclusiveEntityTransaction();
			try
			{
				Pug.ECS.Serialization.DOTS100.SerializeUtility.DeserializeWorld(manager, reader);
			}
			finally
			{
				world.EntityManager.EndExclusiveEntityTransaction();
			}
		}

		private unsafe static void DeserializeWorld(NativeList<byte> fileData, World world)
		{
			if (fileData.Length < 4)
			{
				throw new ArgumentException("Way too small fileData for world save");
			}
			world.EntityManager.PrepareForDeserialize();
			using Unity.Entities.Serialization.MemoryBinaryReader reader = new Unity.Entities.Serialization.MemoryBinaryReader(fileData.GetUnsafePtr(), fileData.Length);
			ExclusiveEntityTransaction manager = world.EntityManager.BeginExclusiveEntityTransaction();
			try
			{
				Unity.Entities.Serialization.SerializeUtility.DeserializeWorld(manager, reader);
			}
			finally
			{
				world.EntityManager.EndExclusiveEntityTransaction();
			}
		}
	}
}
