using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Barmetler.RoadSystem.Util
{
	[GenerateTestsForBurstCompatibility]
	public struct VertexAttributeData : IDisposable
	{
		private struct VertexAttributeInfo
		{
			public int Offset;

			public int Size;
		}

		[ReadOnly]
		private Mesh.MeshData _sourceMeshData;

		[ReadOnly]
		private NativeArray<VertexAttributeDescriptor> _sourceVertexAttributes;

		private NativeArray<byte> _stream0;

		private NativeArray<byte> _stream1;

		private NativeArray<byte> _stream2;

		private NativeArray<byte> _stream3;

		private readonly int _stream0Stride;

		private readonly int _stream1Stride;

		private readonly int _stream2Stride;

		private readonly int _stream3Stride;

		public readonly int UVChannelCount;

		private NativeArray<VertexAttributeInfo> _vertexAttributeInfos;

		public VertexAttributeData(Mesh.MeshData sourceMeshData, NativeArray<VertexAttributeDescriptor> sourceVertexAttributes)
		{
			_sourceMeshData = sourceMeshData;
			_sourceVertexAttributes = sourceVertexAttributes;
			_stream0 = ((_sourceMeshData.vertexBufferCount >= 1) ? _sourceMeshData.GetVertexData<byte>() : default(NativeArray<byte>));
			_stream1 = ((_sourceMeshData.vertexBufferCount >= 2) ? _sourceMeshData.GetVertexData<byte>(1) : default(NativeArray<byte>));
			_stream2 = ((_sourceMeshData.vertexBufferCount >= 3) ? _sourceMeshData.GetVertexData<byte>(2) : default(NativeArray<byte>));
			_stream3 = ((_sourceMeshData.vertexBufferCount >= 4) ? _sourceMeshData.GetVertexData<byte>(3) : default(NativeArray<byte>));
			_stream0Stride = 0;
			_stream1Stride = 0;
			_stream2Stride = 0;
			_stream3Stride = 0;
			UVChannelCount = 0;
			_vertexAttributeInfos = new NativeArray<VertexAttributeInfo>(_sourceVertexAttributes.Length, Allocator.Temp);
			foreach (VertexAttributeDescriptor sourceVertexAttribute in _sourceVertexAttributes)
			{
				if (sourceVertexAttribute.dimension != 0)
				{
					VertexAttributeInfo value = default(VertexAttributeInfo);
					value.Size = sourceVertexAttribute.format switch
					{
						VertexAttributeFormat.UNorm8 => 1, 
						VertexAttributeFormat.SNorm8 => 1, 
						VertexAttributeFormat.UInt8 => 1, 
						VertexAttributeFormat.SInt8 => 1, 
						VertexAttributeFormat.Float16 => 2, 
						VertexAttributeFormat.UNorm16 => 2, 
						VertexAttributeFormat.SNorm16 => 2, 
						VertexAttributeFormat.UInt16 => 2, 
						VertexAttributeFormat.SInt16 => 2, 
						VertexAttributeFormat.Float32 => 4, 
						VertexAttributeFormat.UInt32 => 4, 
						VertexAttributeFormat.SInt32 => 4, 
						_ => value.Size, 
					};
					value.Size *= sourceVertexAttribute.dimension;
					switch (sourceVertexAttribute.stream)
					{
					case 0:
						value.Offset = _stream0Stride;
						_stream0Stride += value.Size;
						break;
					case 1:
						value.Offset = _stream1Stride;
						_stream1Stride += value.Size;
						break;
					case 2:
						value.Offset = _stream2Stride;
						_stream2Stride += value.Size;
						break;
					case 3:
						value.Offset = _stream3Stride;
						_stream3Stride += value.Size;
						break;
					}
					_vertexAttributeInfos[(int)sourceVertexAttribute.attribute] = value;
					VertexAttribute attribute = sourceVertexAttribute.attribute;
					if ((uint)(attribute - 4) <= 7u)
					{
						UVChannelCount++;
					}
				}
			}
		}

		private bool GetVertexData(int index, VertexAttribute attribute, out NativeArray<byte> result, out VertexAttributeDescriptor attributeDescriptor, out VertexAttributeInfo attributeInfo)
		{
			attributeDescriptor = _sourceVertexAttributes[(int)attribute];
			attributeInfo = _vertexAttributeInfos[(int)attribute];
			if (attributeDescriptor.dimension != 0 && attributeDescriptor.stream >= 0 && attributeDescriptor.stream < _sourceMeshData.vertexBufferCount)
			{
				NativeArray<byte> nativeArray = attributeDescriptor.stream switch
				{
					0 => _stream0, 
					1 => _stream1, 
					2 => _stream2, 
					3 => _stream3, 
					_ => throw new ArgumentOutOfRangeException(), 
				};
				int start = index * attributeDescriptor.stream switch
				{
					0 => _stream0Stride, 
					1 => _stream1Stride, 
					2 => _stream2Stride, 
					3 => _stream3Stride, 
					_ => throw new ArgumentOutOfRangeException(), 
				} + attributeInfo.Offset;
				result = nativeArray.GetSubArray(start, attributeInfo.Size);
				return true;
			}
			result = default(NativeArray<byte>);
			return false;
		}

		public unsafe bool GetFloat(int index, VertexAttribute vertexAttribute, out float result)
		{
			if (GetVertexData(index, vertexAttribute, out var result2, out var attributeDescriptor, out var _))
			{
				switch (attributeDescriptor.format)
				{
				case VertexAttributeFormat.Float32:
					result = UnsafeUtility.AsRef<float>(result2.GetUnsafeReadOnlyPtr());
					return true;
				case VertexAttributeFormat.Float16:
					result = UnsafeUtility.AsRef<half>(result2.GetUnsafeReadOnlyPtr());
					return true;
				}
			}
			result = 0f;
			return false;
		}

		public unsafe bool GetFloat2(int index, VertexAttribute vertexAttribute, out float2 result)
		{
			if (GetVertexData(index, vertexAttribute, out var result2, out var attributeDescriptor, out var _))
			{
				switch (attributeDescriptor.format)
				{
				case VertexAttributeFormat.Float32:
					result = UnsafeUtility.AsRef<float2>(result2.GetUnsafeReadOnlyPtr());
					return true;
				case VertexAttributeFormat.Float16:
					result = UnsafeUtility.AsRef<half2>(result2.GetUnsafeReadOnlyPtr());
					return true;
				}
			}
			result = default(float2);
			return false;
		}

		public unsafe bool GetFloat3(int index, VertexAttribute vertexAttribute, out float3 result)
		{
			if (GetVertexData(index, vertexAttribute, out var result2, out var attributeDescriptor, out var _))
			{
				switch (attributeDescriptor.format)
				{
				case VertexAttributeFormat.Float32:
					result = UnsafeUtility.AsRef<float3>(result2.GetUnsafeReadOnlyPtr());
					return true;
				case VertexAttributeFormat.Float16:
					result = UnsafeUtility.AsRef<half3>(result2.GetUnsafeReadOnlyPtr());
					return true;
				}
			}
			result = default(float3);
			return false;
		}

		public unsafe bool GetFloat4(int index, VertexAttribute vertexAttribute, out float4 result)
		{
			if (GetVertexData(index, vertexAttribute, out var result2, out var attributeDescriptor, out var _))
			{
				switch (attributeDescriptor.format)
				{
				case VertexAttributeFormat.Float32:
					result = UnsafeUtility.AsRef<float4>(result2.GetUnsafeReadOnlyPtr());
					return true;
				case VertexAttributeFormat.Float16:
					result = UnsafeUtility.AsRef<half4>(result2.GetUnsafeReadOnlyPtr());
					return true;
				}
			}
			result = default(float4);
			return false;
		}

		public void Dispose()
		{
			if (_stream0.IsCreated)
			{
				_stream0.Dispose();
			}
			if (_stream1.IsCreated)
			{
				_stream1.Dispose();
			}
			if (_stream2.IsCreated)
			{
				_stream2.Dispose();
			}
			if (_stream3.IsCreated)
			{
				_stream3.Dispose();
			}
			_vertexAttributeInfos.Dispose();
		}
	}
}
