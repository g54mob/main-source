using System;
using System.Threading.Tasks;
using GLTFast.Jobs;
using GLTFast.Logging;
using GLTFast.Schema;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace GLTFast
{
	internal abstract class VertexBufferGeneratorBase : IDisposable
	{
		public const int maxUvSetCount = 8;

		public const Allocator defaultAllocator = Allocator.Persistent;

		protected Attributes[] m_Attributes;

		protected int m_AttributeCount;

		public bool calculateNormals;

		public bool calculateTangents;

		protected VertexAttributeDescriptor[] m_Descriptors;

		protected GltfImportBase m_GltfImport;

		public abstract int VertexCount { get; }

		public abstract int[] VertexIntervals { get; protected set; }

		protected VertexBufferGeneratorBase(int primitiveCount, GltfImportBase gltfImport)
		{
			m_Attributes = new Attributes[primitiveCount];
			m_GltfImport = gltfImport;
		}

		public abstract void AddPrimitive(Attributes att);

		public abstract void Initialize();

		public abstract Task<bool> CreateVertexBuffer();

		public abstract void ApplyOnMesh(UnityEngine.Mesh msh, MeshUpdateFlags flags = MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);

		public abstract void GetVertexRange(int subMesh, out int baseVertex, out int vertexCount);

		public abstract bool TryGetBounds(int subMesh, out Bounds bounds);

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected abstract void Dispose(bool disposing);

		public unsafe static JobHandle? GetVector3Job(IGltfBuffers buffers, AccessorBase accessor, float3* output, int outputByteStride, bool normalized = false, bool ensureUnitLength = true)
		{
			JobHandle? result;
			if (accessor.componentType == GltfComponentType.Float)
			{
				ReadOnlyNativeStridedArray<float3> stridedAccessorData = buffers.GetStridedAccessorData<float3>(accessor.bufferView, accessor.count, accessor.byteOffset);
				ConvertVector3FloatToFloatInterleavedJob jobData = new ConvertVector3FloatToFloatInterleavedJob
				{
					input = stridedAccessorData,
					outputByteStride = outputByteStride,
					result = output
				};
				result = jobData.ScheduleBatch(accessor.count, 512);
			}
			else if (accessor.componentType == GltfComponentType.UnsignedShort)
			{
				ReadOnlyNativeStridedArray<ushort3> stridedAccessorData2 = buffers.GetStridedAccessorData<ushort3>(accessor.bufferView, accessor.count, accessor.byteOffset);
				if (normalized)
				{
					ConvertPositionsUInt16ToFloatInterleavedNormalizedJob jobData2 = new ConvertPositionsUInt16ToFloatInterleavedNormalizedJob
					{
						input = stridedAccessorData2,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData2.ScheduleBatch(accessor.count, 512);
				}
				else
				{
					ConvertPositionsUInt16ToFloatInterleavedJob jobData3 = new ConvertPositionsUInt16ToFloatInterleavedJob
					{
						input = stridedAccessorData2,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData3.ScheduleBatch(accessor.count, 512);
				}
			}
			else if (accessor.componentType == GltfComponentType.Short)
			{
				ReadOnlyNativeStridedArray<short3> stridedAccessorData3 = buffers.GetStridedAccessorData<short3>(accessor.bufferView, accessor.count, accessor.byteOffset);
				if (normalized)
				{
					if (ensureUnitLength)
					{
						ConvertNormalsInt16ToFloatInterleavedNormalizedJob jobData4 = new ConvertNormalsInt16ToFloatInterleavedNormalizedJob
						{
							input = stridedAccessorData3,
							outputByteStride = outputByteStride,
							result = output
						};
						result = jobData4.ScheduleBatch(accessor.count, 512);
					}
					else
					{
						ConvertVector3Int16ToFloatInterleavedNormalizedJob jobData5 = new ConvertVector3Int16ToFloatInterleavedNormalizedJob
						{
							input = stridedAccessorData3,
							outputByteStride = outputByteStride,
							result = output
						};
						result = jobData5.ScheduleBatch(accessor.count, 512);
					}
				}
				else
				{
					ConvertPositionsInt16ToFloatInterleavedJob jobData6 = new ConvertPositionsInt16ToFloatInterleavedJob
					{
						input = stridedAccessorData3,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData6.ScheduleBatch(accessor.count, 512);
				}
			}
			else if (accessor.componentType == GltfComponentType.Byte)
			{
				ReadOnlyNativeStridedArray<sbyte3> stridedAccessorData4 = buffers.GetStridedAccessorData<sbyte3>(accessor.bufferView, accessor.count, accessor.byteOffset);
				if (normalized)
				{
					if (ensureUnitLength)
					{
						ConvertNormalsInt8ToFloatInterleavedNormalizedJob jobData7 = new ConvertNormalsInt8ToFloatInterleavedNormalizedJob
						{
							input = stridedAccessorData4,
							outputByteStride = outputByteStride,
							result = output
						};
						result = jobData7.ScheduleBatch(accessor.count, 512);
					}
					else
					{
						ConvertVector3Int8ToFloatInterleavedNormalizedJob jobData8 = new ConvertVector3Int8ToFloatInterleavedNormalizedJob
						{
							input = stridedAccessorData4,
							outputByteStride = outputByteStride,
							result = output
						};
						result = jobData8.ScheduleBatch(accessor.count, 512);
					}
				}
				else
				{
					ConvertPositionsInt8ToFloatInterleavedJob jobData9 = new ConvertPositionsInt8ToFloatInterleavedJob
					{
						input = stridedAccessorData4,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData9.ScheduleBatch(accessor.count, 512);
				}
			}
			else if (accessor.componentType == GltfComponentType.UnsignedByte)
			{
				ReadOnlyNativeStridedArray<byte3> stridedAccessorData5 = buffers.GetStridedAccessorData<byte3>(accessor.bufferView, accessor.count, accessor.byteOffset);
				if (normalized)
				{
					ConvertPositionsUInt8ToFloatInterleavedNormalizedJob jobData10 = new ConvertPositionsUInt8ToFloatInterleavedNormalizedJob
					{
						input = stridedAccessorData5,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData10.ScheduleBatch(accessor.count, 512);
				}
				else
				{
					ConvertPositionsUInt8ToFloatInterleavedJob jobData11 = new ConvertPositionsUInt8ToFloatInterleavedJob
					{
						input = stridedAccessorData5,
						outputByteStride = outputByteStride,
						result = output
					};
					result = jobData11.ScheduleBatch(accessor.count, 512);
				}
			}
			else
			{
				Debug.LogError("Unknown componentType");
				result = null;
			}
			return result;
		}

		protected unsafe JobHandle? GetTangentsJob(void* input, int count, GltfComponentType inputType, int inputByteStride, float4* output, int outputByteStride, bool normalized = false)
		{
			JobHandle? result;
			switch (inputType)
			{
			case GltfComponentType.Float:
			{
				ConvertTangentsFloatToFloatInterleavedJob jobData = new ConvertTangentsFloatToFloatInterleavedJob
				{
					inputByteStride = ((inputByteStride > 0) ? inputByteStride : 16),
					input = (byte*)input,
					outputByteStride = outputByteStride,
					result = output
				};
				result = jobData.ScheduleBatch(count, 512);
				break;
			}
			case GltfComponentType.Short:
			{
				ConvertTangentsInt16ToFloatInterleavedNormalizedJob jobData2 = new ConvertTangentsInt16ToFloatInterleavedNormalizedJob
				{
					inputByteStride = ((inputByteStride > 0) ? inputByteStride : 8),
					input = (short*)input,
					outputByteStride = outputByteStride,
					result = output
				};
				result = jobData2.ScheduleBatch(count, 512);
				break;
			}
			case GltfComponentType.Byte:
			{
				ConvertTangentsInt8ToFloatInterleavedNormalizedJob jobData3 = new ConvertTangentsInt8ToFloatInterleavedNormalizedJob
				{
					inputByteStride = ((inputByteStride > 0) ? inputByteStride : 4),
					input = (sbyte*)input,
					outputByteStride = outputByteStride,
					result = output
				};
				result = jobData3.ScheduleBatch(count, 512);
				break;
			}
			default:
				m_GltfImport.Logger?.Error(LogCode.TypeUnsupported, "Tangent", inputType.ToString());
				result = null;
				break;
			}
			return result;
		}

		public unsafe static JobHandle? GetVector3SparseJob(void* indexBuffer, void* valueBuffer, int sparseCount, GltfComponentType indexType, GltfComponentType valueType, float3* output, int outputByteStride, ref JobHandle? dependsOn, bool normalized = false)
		{
			ConvertVector3SparseJob jobData = new ConvertVector3SparseJob
			{
				indexBuffer = indexBuffer,
				indexConverter = CachedFunction.GetIndexConverter(indexType),
				inputByteStride = 3 * AccessorBase.GetComponentTypeSize(valueType),
				input = valueBuffer,
				valueConverter = CachedFunction.GetPositionConverter(valueType, normalized),
				outputByteStride = outputByteStride,
				result = output
			};
			return IJobParallelForExtensions.Schedule(jobData, sparseCount, 512, dependsOn.GetValueOrDefault());
		}
	}
}
