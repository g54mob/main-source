using System;
using System.Collections.Generic;
using System.Diagnostics;
using ModApi.Craft.Parts;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class FuselageSmoother
	{
		[BurstCompile(CompileSynchronously = true)]
		private struct CopyMeshJob : IJobParallelFor
		{
			[ReadOnly]
			public Mesh.MeshDataArray InputArray;

			public Mesh.MeshDataArray OutputArray;

			public void Execute(int i)
			{
				NativeArray<int> vertexData = InputArray[i].GetVertexData<int>();
				NativeArray<int> vertexData2 = OutputArray[i].GetVertexData<int>();
				NativeArray<int>.Copy(vertexData, vertexData2);
				NativeArray<byte> indexData = InputArray[i].GetIndexData<byte>();
				NativeArray<byte> indexData2 = OutputArray[i].GetIndexData<byte>();
				NativeArray<byte>.Copy(indexData, indexData2);
			}
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct SmoothingJob : IJobParallelFor
		{
			internal struct MeshInfo
			{
				public int VertexLength;

				public float4x4 PositionTransform;

				public float4x4 InversePositionTransform;

				public float3x3 NormalTransform;

				public float3x3 InverseNormalTransform;
			}

			internal struct Vertex
			{
				public float3 Position;

				public float3 Normal;
			}

			internal struct SmoothedSlice
			{
				public int RangeIndexOffset;

				public int RangeIndexCount;

				public int TotalVertices;
			}

			internal struct VertexRange
			{
				public int MeshIndex;

				public int VertexOffset;

				public int VertexCount;
			}

			internal struct SmoothPair
			{
				public int SliceIndex1;

				public int SliceIndex2;

				public byte Smooth1;

				public byte Smooth2;
			}

			[NativeDisableParallelForRestriction]
			[ReadOnly]
			public Mesh.MeshDataArray InputMeshes;

			[NativeDisableParallelForRestriction]
			public Mesh.MeshDataArray OutputMeshes;

			[ReadOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<MeshInfo> ExtraInfo;

			[ReadOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<SmoothedSlice> Slices;

			[ReadOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<VertexRange> Ranges;

			[ReadOnly]
			public NativeArray<SmoothPair> SmoothedPairs;

			[ReadOnly]
			public float SqrDistanceThreshold;

			public unsafe void Execute(int pairIndex)
			{
				if (pairIndex >= SmoothedPairs.Length)
				{
					return;
				}
				SmoothPair smoothPair = SmoothedPairs[pairIndex];
				SmoothedSlice smoothedSlice = Slices[smoothPair.SliceIndex1];
				SmoothedSlice smoothedSlice2 = Slices[smoothPair.SliceIndex2];
				for (int i = smoothedSlice.RangeIndexOffset; i < smoothedSlice.RangeIndexOffset + smoothedSlice.RangeIndexCount; i++)
				{
					VertexRange vertexRange = Ranges[i];
					Mesh.MeshData meshData = InputMeshes[vertexRange.MeshIndex];
					Mesh.MeshData meshData2 = OutputMeshes[vertexRange.MeshIndex];
					MeshInfo meshInfo = ExtraInfo[vertexRange.MeshIndex];
					NativeArray<int> vertexData = meshData.GetVertexData<int>();
					NativeArray<int> vertexData2 = meshData2.GetVertexData<int>();
					for (int j = vertexRange.VertexOffset; j < vertexRange.VertexOffset + vertexRange.VertexCount; j++)
					{
						Vertex* unsafeReadOnlyPtr = (Vertex*)vertexData.Slice(j * (meshInfo.VertexLength >> 2), sizeof(Vertex) >> 2).GetUnsafeReadOnlyPtr();
						float4 float5 = math.mul(meshInfo.PositionTransform, math.float4(unsafeReadOnlyPtr->Position, 1f));
						if ((double)(math.abs(unsafeReadOnlyPtr->Normal.x) + math.abs(unsafeReadOnlyPtr->Normal.z)) < 0.0001)
						{
							continue;
						}
						float3 float6 = math.mul(meshInfo.NormalTransform, unsafeReadOnlyPtr->Normal);
						VertexRange vertexRange2 = Ranges[smoothedSlice2.RangeIndexOffset];
						float3 float7 = default(float3);
						float4 float8 = default(float4);
						float num = 0f;
						int num2 = 0;
						int num3 = -1;
						for (int k = smoothedSlice2.RangeIndexOffset; k < smoothedSlice2.RangeIndexOffset + smoothedSlice2.RangeIndexCount; k++)
						{
							vertexRange2 = Ranges[k];
							Mesh.MeshData meshData3 = InputMeshes[vertexRange2.MeshIndex];
							MeshInfo meshInfo2 = ExtraInfo[vertexRange2.MeshIndex];
							NativeArray<int> vertexData3 = meshData3.GetVertexData<int>();
							for (int l = vertexRange2.VertexOffset; l < vertexRange2.VertexOffset + vertexRange2.VertexCount; l++)
							{
								num3++;
								Vertex* unsafeReadOnlyPtr2 = (Vertex*)vertexData3.Slice(l * (meshInfo2.VertexLength >> 2), sizeof(Vertex) >> 2).GetUnsafeReadOnlyPtr();
								float4 float9 = math.mul(meshInfo2.PositionTransform, math.float4(unsafeReadOnlyPtr2->Position, 1f));
								if ((double)(math.abs(unsafeReadOnlyPtr2->Normal.x) + math.abs(unsafeReadOnlyPtr2->Normal.z)) < 0.0001)
								{
									continue;
								}
								float4 float10 = float5 - float9;
								float10.w = 0f;
								float num4 = math.dot(float10, float10);
								if (num4 <= SqrDistanceThreshold)
								{
									float3 float11 = math.mul(meshInfo2.NormalTransform, unsafeReadOnlyPtr2->Normal);
									float num5 = math.dot(float6, float11);
									if (num2 == 0 || num5 > num)
									{
										num = num5;
										float7 = float11;
										float8 = float9;
										_ = ref meshInfo2;
										num2 = 1;
									}
								}
							}
						}
						if (num2 != 0)
						{
							float4 float12;
							float3 b;
							if (smoothPair.Smooth1 == 1 && smoothPair.Smooth2 == 1)
							{
								float12 = (float5 + float8) / 2f;
								b = (float6 + float7) / 2f;
							}
							else if (smoothPair.Smooth1 == 1)
							{
								float12 = float8;
								b = float7;
							}
							else
							{
								float12 = float5;
								b = float6;
							}
							float12.w = 1f;
							Vertex* unsafePtr = (Vertex*)vertexData2.Slice(j * (meshInfo.VertexLength >> 2), sizeof(Vertex) >> 2).GetUnsafePtr();
							unsafePtr->Normal = math.mul(meshInfo.InverseNormalTransform, b);
						}
					}
				}
			}
		}

		private static readonly VertexAttributeDescriptor[] VertexLayout = new VertexAttributeDescriptor[2]
		{
			new VertexAttributeDescriptor
			{
				attribute = VertexAttribute.Position,
				format = VertexAttributeFormat.Float32,
				dimension = 3,
				stream = 0
			},
			new VertexAttributeDescriptor
			{
				attribute = VertexAttribute.Normal,
				format = VertexAttributeFormat.Float32,
				dimension = 3,
				stream = 0
			}
		};

		private const Allocator allocator = Allocator.Persistent;

		private static SmoothingJob.MeshInfo ValidateAndGetMeshInfo(MeshFilter meshFilter)
		{
			VertexAttributeDescriptor[] vertexAttributes = meshFilter.mesh.GetVertexAttributes();
			bool flag = vertexAttributes.Length >= VertexLayout.Length;
			int num = 0;
			if (flag)
			{
				for (int i = 0; i < vertexAttributes.Length; i++)
				{
					if (i < VertexLayout.Length && vertexAttributes[i] != VertexLayout[i])
					{
						flag = false;
						break;
					}
					if (vertexAttributes[i].stream == 0)
					{
						int num2;
						switch (vertexAttributes[i].format)
						{
						case VertexAttributeFormat.UNorm8:
						case VertexAttributeFormat.SNorm8:
						case VertexAttributeFormat.UInt8:
						case VertexAttributeFormat.SInt8:
							num2 = 1;
							break;
						case VertexAttributeFormat.Float16:
						case VertexAttributeFormat.UNorm16:
						case VertexAttributeFormat.SNorm16:
						case VertexAttributeFormat.UInt16:
						case VertexAttributeFormat.SInt16:
							num2 = 2;
							break;
						case VertexAttributeFormat.Float32:
						case VertexAttributeFormat.UInt32:
						case VertexAttributeFormat.SInt32:
							num2 = 4;
							break;
						default:
							throw new ArgumentException($"Unknown vertex attribute format: {(int)vertexAttributes[i].format}");
						}
						num += num2 * vertexAttributes[i].dimension;
					}
				}
			}
			if (!flag)
			{
				throw new ArgumentException("Cannot smooth mesh normals because mesh buffer is in the wrong layout. MeshFilter = " + meshFilter.name);
			}
			Transform transform = meshFilter.transform;
			float3x3 float3x5 = math.float3x3(transform.localToWorldMatrix);
			return new SmoothingJob.MeshInfo
			{
				PositionTransform = transform.localToWorldMatrix,
				InversePositionTransform = transform.worldToLocalMatrix,
				NormalTransform = float3x5,
				InverseNormalTransform = math.inverse(float3x5),
				VertexLength = num
			};
		}

		private static void CloneMeshDataArray(Mesh.MeshDataArray readOnly, Mesh.MeshDataArray writable, List<Mesh> meshes)
		{
			for (int i = 0; i < readOnly.Length; i++)
			{
				Mesh.MeshData meshData = writable[i];
				meshData.subMeshCount = readOnly[i].subMeshCount;
				writable[i].SetVertexBufferParams(meshes[i].vertexCount, meshes[i].GetVertexAttributes());
				uint num = 0u;
				for (int j = 0; j < meshes[i].subMeshCount; j++)
				{
					num += meshes[i].GetIndexCount(j);
				}
				writable[i].SetIndexBufferParams((int)num, meshes[i].indexFormat);
			}
			IJobParallelForExtensions.Schedule(new CopyMeshJob
			{
				InputArray = readOnly,
				OutputArray = writable
			}, readOnly.Length, 2).Complete();
			for (int k = 0; k < readOnly.Length; k++)
			{
				for (int l = 0; l < readOnly[k].subMeshCount; l++)
				{
					writable[k].SetSubMesh(l, readOnly[k].GetSubMesh(l));
				}
			}
		}

		public static void FlightSmooth(IEnumerable<FuselageScript> fuselages, float distanceThreshold = 0.01f)
		{
			Stopwatch.StartNew();
			NativeArray<SmoothingJob.SmoothPair> smoothedPairs = default(NativeArray<SmoothingJob.SmoothPair>);
			NativeArray<SmoothingJob.SmoothedSlice> slices = default(NativeArray<SmoothingJob.SmoothedSlice>);
			NativeArray<SmoothingJob.MeshInfo> extraInfo = default(NativeArray<SmoothingJob.MeshInfo>);
			NativeArray<SmoothingJob.VertexRange> ranges = default(NativeArray<SmoothingJob.VertexRange>);
			Mesh.MeshDataArray meshDataArray = default(Mesh.MeshDataArray);
			bool flag = false;
			try
			{
				List<FuselageScript> includedFuselages = new List<FuselageScript>();
				List<SmoothingJob.SmoothPair> pairs = new List<SmoothingJob.SmoothPair>();
				foreach (FuselageScript fuselage2 in fuselages)
				{
					FuselageScript fuselage = fuselage2;
					int thisFuselage;
					if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.None && fuselage.AdaptiveMeshes.Count > 0)
					{
						thisFuselage = FuselageToID(fuselage);
						if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.Bottom)
						{
							ProcessAttached("Top");
						}
						if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.Top)
						{
							ProcessAttached("Bottom");
						}
					}
					void ProcessAttached(string tag)
					{
						var (fuselageScript, flag2) = fuselage.GetConnectedFuselage(tag);
						if (fuselageScript != null && fuselageScript.AdaptiveMeshes.Count > 0)
						{
							int num2 = FuselageToID(fuselageScript);
							bool flag3 = false;
							foreach (SmoothingJob.SmoothPair item in pairs)
							{
								if (item.SliceIndex1 == num2 && item.SliceIndex2 == thisFuselage)
								{
									flag3 = true;
									break;
								}
							}
							if (!flag3)
							{
								pairs.Add(new SmoothingJob.SmoothPair
								{
									SliceIndex1 = thisFuselage,
									SliceIndex2 = num2,
									Smooth1 = 1,
									Smooth2 = (byte)(flag2 ? 1 : 0)
								});
								if (flag2)
								{
									pairs.Add(new SmoothingJob.SmoothPair
									{
										SliceIndex1 = num2,
										SliceIndex2 = thisFuselage,
										Smooth1 = 1,
										Smooth2 = 1
									});
								}
							}
						}
					}
				}
				smoothedPairs = new NativeArray<SmoothingJob.SmoothPair>(pairs.ToArray(), Allocator.Persistent);
				List<Mesh> meshes = new List<Mesh>();
				List<MeshFilter> meshFilters = new List<MeshFilter>();
				List<SmoothingJob.VertexRange> list = new List<SmoothingJob.VertexRange>();
				slices = new NativeArray<SmoothingJob.SmoothedSlice>(includedFuselages.Count, Allocator.Persistent);
				int num = 0;
				foreach (FuselageScript item2 in includedFuselages)
				{
					PartGroupScript partGroupScript = (PartGroupScript)item2.PartScript.PartGroup;
					SmoothingJob.SmoothedSlice value = new SmoothingJob.SmoothedSlice
					{
						RangeIndexOffset = list.Count,
						RangeIndexCount = 0,
						TotalVertices = 0
					};
					foreach (IRendererMaterialMap rendererMap in item2.PartScript.PartMaterialScript.RendererMaps)
					{
						if (rendererMap.WasMeshCombined)
						{
							list.Add(new SmoothingJob.VertexRange
							{
								MeshIndex = MeshToID(partGroupScript.CombinedMeshFilter.mesh, partGroupScript.CombinedMeshFilter),
								VertexOffset = rendererMap.CombinedMeshVertexOffset,
								VertexCount = rendererMap.CombinedMeshVertexCount
							});
							value.RangeIndexCount++;
							value.TotalVertices += rendererMap.CombinedMeshVertexCount;
						}
						else
						{
							Mesh mesh = rendererMap.Mesh;
							list.Add(new SmoothingJob.VertexRange
							{
								MeshIndex = MeshToID(rendererMap.Mesh, rendererMap.Renderer.GetComponent<MeshFilter>()),
								VertexOffset = 0,
								VertexCount = mesh.vertexCount
							});
							value.RangeIndexCount++;
							value.TotalVertices += mesh.vertexCount;
						}
					}
					slices[num++] = value;
				}
				extraInfo = new NativeArray<SmoothingJob.MeshInfo>(meshFilters.Count, Allocator.Persistent);
				ranges = new NativeArray<SmoothingJob.VertexRange>(list.ToArray(), Allocator.Persistent);
				num = 0;
				foreach (MeshFilter item3 in meshFilters)
				{
					extraInfo[num++] = ValidateAndGetMeshInfo(item3);
				}
				using (Mesh.MeshDataArray meshDataArray2 = Mesh.AcquireReadOnlyMeshData(meshes))
				{
					meshDataArray = Mesh.AllocateWritableMeshData(meshes.Count);
					flag = true;
					CloneMeshDataArray(meshDataArray2, meshDataArray, meshes);
					IJobParallelForExtensions.Schedule(new SmoothingJob
					{
						SqrDistanceThreshold = distanceThreshold * distanceThreshold,
						InputMeshes = meshDataArray2,
						OutputMeshes = meshDataArray,
						ExtraInfo = extraInfo,
						Ranges = ranges,
						Slices = slices,
						SmoothedPairs = smoothedPairs
					}, smoothedPairs.Length, 5).Complete();
					Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, meshes);
					flag = false;
				}
				int FuselageToID(FuselageScript script)
				{
					int num2 = includedFuselages.IndexOf(script);
					if (num2 != -1)
					{
						return num2;
					}
					includedFuselages.Add(script);
					return includedFuselages.Count - 1;
				}
				int MeshToID(Mesh item, MeshFilter meshFilter)
				{
					int num2 = meshes.IndexOf(item);
					if (num2 != -1)
					{
						return num2;
					}
					meshes.Add(item);
					meshFilters.Add(meshFilter);
					return meshes.Count - 1;
				}
			}
			finally
			{
				if (smoothedPairs.IsCreated)
				{
					smoothedPairs.Dispose();
				}
				if (slices.IsCreated)
				{
					slices.Dispose();
				}
				if (extraInfo.IsCreated)
				{
					extraInfo.Dispose();
				}
				if (ranges.IsCreated)
				{
					ranges.Dispose();
				}
				if (flag)
				{
					meshDataArray.Dispose();
				}
			}
		}

		public static void BatchDesignerSmooth(IEnumerable<FuselageScript> fuselages, float distanceThreshold = 0.01f)
		{
			NativeArray<SmoothingJob.SmoothPair> smoothedPairs = default(NativeArray<SmoothingJob.SmoothPair>);
			NativeArray<SmoothingJob.SmoothedSlice> slices = default(NativeArray<SmoothingJob.SmoothedSlice>);
			NativeArray<SmoothingJob.MeshInfo> extraInfo = default(NativeArray<SmoothingJob.MeshInfo>);
			NativeArray<SmoothingJob.VertexRange> ranges = default(NativeArray<SmoothingJob.VertexRange>);
			Mesh.MeshDataArray meshDataArray = default(Mesh.MeshDataArray);
			bool flag = false;
			try
			{
				List<FuselageScript> included = new List<FuselageScript>();
				List<SmoothingJob.SmoothPair> pairs = new List<SmoothingJob.SmoothPair>();
				foreach (FuselageScript fuselage in fuselages)
				{
					int thisIndex;
					if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.None && fuselage.AdaptiveMeshes.Count != 0)
					{
						(FuselageScript, bool) connected = default((FuselageScript, bool));
						(FuselageScript, bool) connected2 = default((FuselageScript, bool));
						if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.Bottom)
						{
							connected = fuselage.GetConnectedFuselage("Top");
						}
						if (fuselage.Data.FlattenNormals != FuselageData.FlattenNormalsOptions.Top)
						{
							connected2 = fuselage.GetConnectedFuselage("Bottom");
						}
						if (!(connected.Item1 == null) || !(connected2.Item1 == null))
						{
							thisIndex = FuselageToIndex(fuselage);
							ProcessConnected(connected);
							ProcessConnected(connected2);
						}
					}
					void ProcessConnected((FuselageScript script, bool otherSmoothed) tuple2)
					{
						var (fuselageScript2, flag2) = tuple2;
						if (fuselageScript2 != null && fuselageScript2.AdaptiveMeshes.Count > 0)
						{
							int num3 = FuselageToIndex(fuselageScript2);
							bool flag3 = false;
							foreach (SmoothingJob.SmoothPair item in pairs)
							{
								if (item.SliceIndex1 == num3 && item.SliceIndex2 == thisIndex)
								{
									flag3 = true;
									break;
								}
							}
							if (!flag3)
							{
								pairs.Add(new SmoothingJob.SmoothPair
								{
									SliceIndex1 = thisIndex,
									SliceIndex2 = num3,
									Smooth1 = 1,
									Smooth2 = (byte)(flag2 ? 1 : 0)
								});
								if (flag2)
								{
									pairs.Add(new SmoothingJob.SmoothPair
									{
										SliceIndex1 = num3,
										SliceIndex2 = thisIndex,
										Smooth1 = 1,
										Smooth2 = 1
									});
								}
							}
						}
					}
				}
				if (included.Count < 2)
				{
					return;
				}
				smoothedPairs = new NativeArray<SmoothingJob.SmoothPair>(pairs.ToArray(), Allocator.Persistent);
				slices = new NativeArray<SmoothingJob.SmoothedSlice>(included.Count, Allocator.Persistent);
				List<MeshFilter> list = new List<MeshFilter>();
				List<Mesh> list2 = new List<Mesh>();
				for (int i = 0; i < included.Count; i++)
				{
					FuselageScript fuselageScript = included[i];
					int num = 0;
					int count = list.Count;
					int num2 = 0;
					foreach (AdaptiveMesh adaptiveMesh in fuselageScript.AdaptiveMeshes)
					{
						if (!(adaptiveMesh.MeshCollider != null))
						{
							Mesh mesh = adaptiveMesh.MeshFilter.mesh;
							list.Add(adaptiveMesh.MeshFilter);
							list2.Add(mesh);
							num += mesh.vertexCount;
							num2++;
						}
					}
					slices[i] = new SmoothingJob.SmoothedSlice
					{
						RangeIndexOffset = count,
						RangeIndexCount = num2,
						TotalVertices = num
					};
				}
				extraInfo = new NativeArray<SmoothingJob.MeshInfo>(list.Count, Allocator.Persistent);
				ranges = new NativeArray<SmoothingJob.VertexRange>(list.Count, Allocator.Persistent);
				for (int j = 0; j < list.Count; j++)
				{
					extraInfo[j] = ValidateAndGetMeshInfo(list[j]);
					int vertexCount = list[j].mesh.vertexCount;
					ranges[j] = new SmoothingJob.VertexRange
					{
						MeshIndex = j,
						VertexCount = vertexCount,
						VertexOffset = 0
					};
				}
				using (Mesh.MeshDataArray meshDataArray2 = Mesh.AcquireReadOnlyMeshData(list2))
				{
					flag = true;
					meshDataArray = Mesh.AllocateWritableMeshData(list2.Count);
					CloneMeshDataArray(meshDataArray2, meshDataArray, list2);
					IJobParallelForExtensions.Schedule(new SmoothingJob
					{
						SqrDistanceThreshold = distanceThreshold * distanceThreshold,
						InputMeshes = meshDataArray2,
						OutputMeshes = meshDataArray,
						ExtraInfo = extraInfo,
						Ranges = ranges,
						Slices = slices,
						SmoothedPairs = smoothedPairs
					}, smoothedPairs.Length, 5).Complete();
					Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, list2);
					flag = false;
				}
				int FuselageToIndex(FuselageScript f)
				{
					int num3 = included.IndexOf(f);
					if (num3 == -1)
					{
						num3 = included.Count;
						included.Add(f);
					}
					return num3;
				}
			}
			catch (Exception arg)
			{
				UnityEngine.Debug.LogError($"Smoothing error: {arg}");
			}
			finally
			{
				if (smoothedPairs.IsCreated)
				{
					smoothedPairs.Dispose();
				}
				if (slices.IsCreated)
				{
					slices.Dispose();
				}
				if (extraInfo.IsCreated)
				{
					extraInfo.Dispose();
				}
				if (ranges.IsCreated)
				{
					ranges.Dispose();
				}
				if (flag)
				{
					meshDataArray.Dispose();
				}
			}
		}
	}
}
