using System;
using System.Linq;
using Barmetler.RoadSystem.Util;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;

namespace Barmetler.RoadSystem
{
	[RequireComponent(typeof(Road))]
	[RequireComponent(typeof(MeshFilter))]
	public class RoadMeshGenerator : MonoBehaviour
	{
		[Serializable]
		public class RoadMeshSettings
		{
			[Tooltip("Orientation of the Source Mesh")]
			public MeshConversion.MeshOrientation SourceOrientation = MeshConversion.MeshOrientation.Presets["BLENDER"];

			[Tooltip("By how much to displace uvs every time the mesh tiles")]
			public Vector2 uvOffset = Vector2.up;
		}

		[BurstCompile(CompileSynchronously = true)]
		private struct GenerateRoadMeshV2Job : IJob
		{
			public struct OrientedPoint
			{
				public float3 Position;

				public float3 Forward;

				public float3 Normal;
			}

			private struct IndexLists<T> : IDisposable where T : unmanaged
			{
				public NativeList<T> SubMesh0;

				public NativeList<T> SubMesh1;

				public NativeList<T> SubMesh2;

				public NativeList<T> SubMesh3;

				public NativeList<T> SubMesh4;

				public NativeList<T> SubMesh5;

				public NativeList<T> SubMesh6;

				public NativeList<T> SubMesh7;

				public NativeList<T> SubMesh8;

				public NativeList<T> SubMesh9;

				public NativeList<T> SubMesh10;

				public NativeList<T> SubMesh11;

				public NativeList<T> SubMesh12;

				public NativeList<T> SubMesh13;

				public NativeList<T> SubMesh14;

				public NativeList<T> SubMesh15;

				public NativeList<T> SubMesh16;

				public NativeList<T> SubMesh17;

				public NativeList<T> SubMesh18;

				public NativeList<T> SubMesh19;

				public NativeList<T> SubMesh20;

				public NativeList<T> SubMesh21;

				public NativeList<T> SubMesh22;

				public NativeList<T> SubMesh23;

				public NativeList<T> SubMesh24;

				public NativeList<T> SubMesh25;

				public NativeList<T> SubMesh26;

				public NativeList<T> SubMesh27;

				public NativeList<T> SubMesh28;

				public NativeList<T> SubMesh29;

				public NativeList<T> SubMesh30;

				public NativeList<T> SubMesh31;

				public Allocator Allocator;

				private int _subMeshCount;

				public ref NativeList<T> this[int index]
				{
					get
					{
						if (index < 0 || index >= _subMeshCount)
						{
							throw new IndexOutOfRangeException();
						}
						return ref GetUnchecked(index);
					}
				}

				public int SubMeshCount
				{
					get
					{
						return _subMeshCount;
					}
					set
					{
						Resize(value);
					}
				}

				public int TotalIndexCount
				{
					get
					{
						int num = 0;
						for (int i = 0; i < _subMeshCount; i++)
						{
							num += this[i].Length;
						}
						return num;
					}
				}

				public IndexLists(Allocator allocator)
				{
					this = default(IndexLists<T>);
					Allocator = allocator;
				}

				public IndexLists(int subMeshCount, Allocator allocator)
				{
					this = default(IndexLists<T>);
					Allocator = allocator;
					Resize(subMeshCount);
				}

				private unsafe ref NativeList<T> GetUnchecked(int index)
				{
					return ref UnsafeUtility.ArrayElementAsRef<NativeList<T>>(UnsafeUtility.AddressOf(ref SubMesh0), index);
				}

				public void Resize(int subMeshCount)
				{
					if (subMeshCount < 0 || subMeshCount > 32)
					{
						throw new ArgumentOutOfRangeException();
					}
					if (subMeshCount == _subMeshCount)
					{
						return;
					}
					if (subMeshCount < _subMeshCount)
					{
						for (int i = subMeshCount; i < _subMeshCount; i++)
						{
							GetUnchecked(i).Dispose();
						}
					}
					else
					{
						for (int j = _subMeshCount; j < subMeshCount; j++)
						{
							GetUnchecked(j) = new NativeList<T>(Allocator);
						}
					}
					_subMeshCount = subMeshCount;
				}

				public void Dispose()
				{
					for (int i = 0; i < _subMeshCount; i++)
					{
						this[i].Dispose();
					}
				}
			}

			[ReadOnly]
			public float StepSize;

			[ReadOnly]
			public float2 UVOffset;

			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeArray<OrientedPoint> Points;

			[ReadOnly]
			public MeshConversion.MeshOrientation SourceOrientation;

			[ReadOnly]
			public Mesh.MeshData SourceMeshData;

			[ReadOnly]
			[DeallocateOnJobCompletion]
			public NativeArray<VertexAttributeDescriptor> SourceVertexAttributes;

			[ReadOnly]
			public Bounds SourceBounds;

			public Mesh.MeshData ResultMeshData;

			[WriteOnly]
			public NativeArray<float3> ResultBounds;

			public void Execute()
			{
				VertexAttributeData vertexAttributeData = new VertexAttributeData(SourceMeshData, SourceVertexAttributes);
				try
				{
					float num = ((Points.Length > 1) ? (StepSize * (float)(Points.Length - 2) + math.length(Points[Points.Length - 2].Position - Points[Points.Length - 1].Position)) : 0f);
					float num2 = SourceOrientation.forward switch
					{
						MeshConversion.MeshOrientation.AxisDirection.X_POSITIVE => SourceBounds.size.x, 
						MeshConversion.MeshOrientation.AxisDirection.X_NEGATIVE => SourceBounds.size.x, 
						MeshConversion.MeshOrientation.AxisDirection.Y_POSITIVE => SourceBounds.size.y, 
						MeshConversion.MeshOrientation.AxisDirection.Y_NEGATIVE => SourceBounds.size.y, 
						MeshConversion.MeshOrientation.AxisDirection.Z_POSITIVE => SourceBounds.size.z, 
						MeshConversion.MeshOrientation.AxisDirection.Z_NEGATIVE => SourceBounds.size.z, 
						_ => throw new ArgumentOutOfRangeException(), 
					};
					float num3 = SourceOrientation.forward switch
					{
						MeshConversion.MeshOrientation.AxisDirection.X_POSITIVE => SourceBounds.min.x, 
						MeshConversion.MeshOrientation.AxisDirection.X_NEGATIVE => SourceBounds.max.x, 
						MeshConversion.MeshOrientation.AxisDirection.Y_POSITIVE => SourceBounds.min.y, 
						MeshConversion.MeshOrientation.AxisDirection.Y_NEGATIVE => SourceBounds.max.y, 
						MeshConversion.MeshOrientation.AxisDirection.Z_POSITIVE => SourceBounds.min.z, 
						MeshConversion.MeshOrientation.AxisDirection.Z_NEGATIVE => SourceBounds.max.z, 
						_ => throw new ArgumentOutOfRangeException(), 
					};
					int num4 = (int)math.ceil(num / num2);
					int vertexCount = SourceMeshData.vertexCount;
					int subMeshCount = SourceMeshData.subMeshCount;
					int num5 = num4 * vertexCount;
					IndexLists<ushort> indexLists = new IndexLists<ushort>(subMeshCount, Allocator.Temp);
					for (int i = 0; i < subMeshCount; i++)
					{
						SubMeshDescriptor subMesh = SourceMeshData.GetSubMesh(i);
						ref NativeList<ushort> reference = ref indexLists[i];
						reference.ResizeUninitialized(subMesh.indexCount);
						SourceMeshData.GetIndices(reference.AsArray(), i);
						if (SourceOrientation.isRightHanded)
						{
							for (int j = 0; j < reference.Length; j += 3)
							{
								int index = j;
								int index2 = j + 2;
								ushort num6 = reference[j + 2];
								ushort num7 = reference[j];
								ushort num8 = (reference[index] = num6);
								num8 = (reference[index2] = num7);
							}
						}
					}
					NativeList<float3> positions = new NativeList<float3>(Allocator.Temp);
					positions.ResizeUninitialized(num5);
					NativeList<float3> normals = new NativeList<float3>(Allocator.Temp);
					normals.ResizeUninitialized(num5);
					NativeList<float4> tangents = new NativeList<float4>(Allocator.Temp);
					tangents.ResizeUninitialized(num5);
					NativeList<float2> uvs = new NativeList<float2>(Allocator.Temp);
					uvs.ResizeUninitialized(num5 * vertexAttributeData.UVChannelCount);
					IndexLists<ushort> indexLists2 = new IndexLists<ushort>(subMeshCount, Allocator.Temp);
					float3 float5 = SourceOrientation.forward.ToFloat3();
					float3 float6 = SourceOrientation.up.ToFloat3();
					float3 x = (SourceOrientation.isRightHanded ? math.cross(float5, float6) : math.cross(float6, float5));
					for (int k = 0; k < num4; k++)
					{
						float num11 = (float)k * num2;
						for (int l = 0; l < vertexCount; l++)
						{
							int num12 = k * vertexCount + l;
							vertexAttributeData.GetFloat3(l, VertexAttribute.Position, out var result);
							result -= num3 * float5;
							result = math.float3(math.dot(x, result), math.dot(float6, result), math.dot(float5, result) + num11);
							vertexAttributeData.GetFloat3(l, VertexAttribute.Normal, out var result2);
							result2 = math.float3(math.dot(x, result2), math.dot(float6, result2), math.dot(float5, result2));
							vertexAttributeData.GetFloat4(l, VertexAttribute.Tangent, out var result3);
							result3 = math.float4(math.dot(x, result3.xyz), math.dot(float6, result3.xyz), math.dot(float5, result3.xyz), result3.w);
							positions[num12] = result;
							normals[num12] = result2;
							tangents[num12] = result3;
							for (int m = 0; m < vertexAttributeData.UVChannelCount; m++)
							{
								vertexAttributeData.GetFloat2(l, (VertexAttribute)(4 + m), out var result4);
								uvs[num12 * vertexAttributeData.UVChannelCount + m] = result4 + UVOffset * k;
							}
						}
						if (k == num4 - 1)
						{
							continue;
						}
						for (int n = 0; n < subMeshCount; n++)
						{
							NativeList<ushort> nativeList = indexLists[n];
							NativeList<ushort> nativeList2 = indexLists2[n];
							nativeList2.ResizeUninitialized(nativeList2.Length + nativeList.Length);
							for (int num13 = 0; num13 < nativeList.Length; num13++)
							{
								nativeList2[nativeList2.Length - nativeList.Length + num13] = (ushort)(k * vertexCount + nativeList[num13]);
							}
						}
					}
					if (num4 >= 1)
					{
						NativeHashMap<int2, ushort> intersectedIndices = new NativeHashMap<int2, ushort>(128, Allocator.Temp);
						for (int num14 = 0; num14 < subMeshCount; num14++)
						{
							NativeList<ushort> nativeList3 = indexLists[num14];
							NativeList<ushort> nativeList4 = indexLists2[num14];
							ushort num15 = (ushort)((num4 - 1) * vertexCount);
							for (int num16 = 0; num16 + 2 < nativeList3.Length; num16 += 3)
							{
								ushort value = (ushort)(nativeList3[num16] + num15);
								ushort value2 = (ushort)(nativeList3[num16 + 1] + num15);
								ushort value3 = (ushort)(nativeList3[num16 + 2] + num15);
								float3 float7 = positions[value];
								float3 float8 = positions[value2];
								float3 float9 = positions[value3];
								int num17 = 0;
								if (float7.z <= num)
								{
									num17++;
								}
								if (float8.z <= num)
								{
									num17++;
								}
								if (float9.z <= num)
								{
									num17++;
								}
								switch (num17)
								{
								case 3:
									nativeList4.Add(in value);
									nativeList4.Add(in value2);
									nativeList4.Add(in value3);
									break;
								case 2:
								{
									if (float7.z > num)
									{
										ushort num20 = value2;
										ushort num7 = value3;
										ushort num6 = value;
										value = num20;
										value2 = num7;
										value3 = num6;
										float3 obj3 = float8;
										float3 float10 = float9;
										float3 float11 = float7;
										float7 = obj3;
										float8 = float10;
										float9 = float11;
									}
									else if (float8.z > num)
									{
										ushort num21 = value3;
										ushort num6 = value;
										ushort num7 = value2;
										value = num21;
										value2 = num6;
										value3 = num7;
										float3 obj4 = float9;
										float3 float11 = float7;
										float3 float10 = float8;
										float7 = obj4;
										float8 = float11;
										float9 = float10;
									}
									AddBetween(positions, normals, tangents, uvs, vertexAttributeData.UVChannelCount, value, value3, (num - float7.z) / (float9.z - float7.z), intersectedIndices, out var resultIndex3);
									AddBetween(positions, normals, tangents, uvs, vertexAttributeData.UVChannelCount, value2, value3, (num - float8.z) / (float9.z - float8.z), intersectedIndices, out var resultIndex4);
									nativeList4.Add(in value);
									nativeList4.Add(in value2);
									nativeList4.Add(in resultIndex3);
									nativeList4.Add(in resultIndex3);
									nativeList4.Add(in value2);
									nativeList4.Add(in resultIndex4);
									break;
								}
								case 1:
								{
									if (float8.z <= num)
									{
										ushort num18 = value2;
										ushort num7 = value3;
										ushort num6 = value;
										value = num18;
										value2 = num7;
										value3 = num6;
										float3 obj = float8;
										float3 float10 = float9;
										float3 float11 = float7;
										float7 = obj;
										float8 = float10;
										float9 = float11;
									}
									else if (float9.z <= num)
									{
										ushort num19 = value3;
										ushort num6 = value;
										ushort num7 = value2;
										value = num19;
										value2 = num6;
										value3 = num7;
										float3 obj2 = float9;
										float3 float11 = float7;
										float3 float10 = float8;
										float7 = obj2;
										float8 = float11;
										float9 = float10;
									}
									AddBetween(positions, normals, tangents, uvs, vertexAttributeData.UVChannelCount, value, value2, (num - float7.z) / (float8.z - float7.z), intersectedIndices, out var resultIndex);
									AddBetween(positions, normals, tangents, uvs, vertexAttributeData.UVChannelCount, value, value3, (num - float7.z) / (float9.z - float7.z), intersectedIndices, out var resultIndex2);
									nativeList4.Add(in value);
									nativeList4.Add(in resultIndex);
									nativeList4.Add(in resultIndex2);
									break;
								}
								}
							}
						}
					}
					int length = positions.Length;
					for (int num22 = 0; num22 < length; num22++)
					{
						float3 float12 = positions[num22];
						int num23 = math.clamp((int)math.floor(float12.z / StepSize), 0, Points.Length - 2);
						float t = math.clamp((num23 < Points.Length - 2) ? (float12.z / StepSize - (float)num23) : ((float12.z - StepSize * (float)num23) / math.distance(Points[Points.Length - 1].Position, Points[Points.Length - 2].Position)), 0f, 1f);
						float3 float13 = math.lerp(Points[num23].Position, Points[num23 + 1].Position, t);
						float3 float14 = math.normalize(math.lerp(Points[num23].Forward, Points[num23 + 1].Forward, t));
						float3 float15 = math.normalize(math.lerp(Points[num23].Normal, Points[num23 + 1].Normal, t));
						float3 float16 = math.cross(float15, float14);
						positions[num22] = float13 + float16 * float12.x + float15 * float12.y;
						normals[num22] = float16 * normals[num22].x + float15 * normals[num22].y + float14 * normals[num22].z;
						tangents[num22] = math.float4(float16 * tangents[num22].x + float15 * tangents[num22].y + float14 * tangents[num22].z, tangents[num22].w);
					}
					NativeArray<VertexAttributeDescriptor> attributes = new NativeArray<VertexAttributeDescriptor>(3 + vertexAttributeData.UVChannelCount, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
					attributes[0] = new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0);
					attributes[1] = new VertexAttributeDescriptor(VertexAttribute.Normal, VertexAttributeFormat.Float32, 3, 1);
					attributes[2] = new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4, 2);
					for (int num24 = 0; num24 < vertexAttributeData.UVChannelCount; num24++)
					{
						VertexAttributeDescriptor value4 = SourceVertexAttributes[4 + num24];
						value4.stream = 3;
						attributes[3 + num24] = value4;
					}
					ResultMeshData.SetVertexBufferParams(length, attributes);
					attributes.Dispose();
					NativeArray<float3> vertexData = ResultMeshData.GetVertexData<float3>();
					NativeArray<float3> vertexData2 = ResultMeshData.GetVertexData<float3>(1);
					NativeArray<float4> vertexData3 = ResultMeshData.GetVertexData<float4>(2);
					NativeArray<float2> vertexData4 = ResultMeshData.GetVertexData<float2>(3);
					vertexData.CopyFrom(positions.AsArray());
					vertexData2.CopyFrom(normals.AsArray());
					vertexData3.CopyFrom(tangents.AsArray());
					vertexData4.CopyFrom(uvs.AsArray());
					float3 float17 = new float3(float.MaxValue);
					float3 float18 = new float3(float.MinValue);
					foreach (float3 item in positions)
					{
						float17 = math.min(float17, item);
						float18 = math.max(float18, item);
					}
					if (positions.Length == 0)
					{
						float17 = (float18 = 0);
					}
					ResultBounds[0] = float17;
					ResultBounds[1] = float18;
					ResultMeshData.SetIndexBufferParams(indexLists2.TotalIndexCount, IndexFormat.UInt16);
					ResultMeshData.subMeshCount = subMeshCount;
					NativeArray<ushort> indexData = ResultMeshData.GetIndexData<ushort>();
					int num25 = 0;
					for (int num26 = 0; num26 < subMeshCount; num26++)
					{
						SubMeshDescriptor subMesh2 = SourceMeshData.GetSubMesh(num26);
						NativeList<ushort> nativeList5 = indexLists2[num26];
						indexData.GetSubArray(num25, nativeList5.Length).CopyFrom(nativeList5);
						float17 = new float3(float.MaxValue);
						float18 = new float3(float.MinValue);
						int num27 = int.MaxValue;
						using NativeHashSet<int> nativeHashSet = new NativeHashSet<int>(nativeList5.Length, Allocator.Temp);
						for (int num28 = 0; num28 < nativeList5.Length; num28++)
						{
							ushort num29 = nativeList5[num28];
							float17 = math.min(float17, positions[num29]);
							float18 = math.max(float18, positions[num29]);
							num27 = math.min(num27, num29);
							nativeHashSet.Add(num29);
						}
						ResultMeshData.SetSubMesh(num26, new SubMeshDescriptor
						{
							bounds = new Bounds
							{
								min = float17,
								max = float18
							},
							topology = subMesh2.topology,
							indexStart = num25,
							indexCount = nativeList5.Length,
							firstVertex = num27,
							vertexCount = nativeHashSet.Count
						}, MeshUpdateFlags.DontRecalculateBounds);
						num25 += nativeList5.Length;
					}
					positions.Dispose();
					normals.Dispose();
					tangents.Dispose();
					uvs.Dispose();
					indexLists.Dispose();
					indexLists2.Dispose();
				}
				finally
				{
					((IDisposable)vertexAttributeData/*cast due to .constrained prefix*/).Dispose();
				}
			}

			private static void AddBetween(NativeList<float3> positions, NativeList<float3> normals, NativeList<float4> tangents, NativeList<float2> uvs, int uvChannelCount, ushort ia, ushort ib, float t, NativeHashMap<int2, ushort> intersectedIndices, out ushort resultIndex)
			{
				if (intersectedIndices.TryGetValue(new int2(ia, ib), out var item))
				{
					resultIndex = item;
					return;
				}
				positions.Add(math.lerp(positions[ia], positions[ib], t));
				normals.Add(math.normalize(math.lerp(normals[ia], normals[ib], t)));
				tangents.Add(math.float4(math.normalize(math.lerp(tangents[ia].xyz, tangents[ib].xyz, t)), 1f));
				for (int i = 0; i < uvChannelCount; i++)
				{
					uvs.Add(math.lerp(uvs[ia * uvChannelCount + i], uvs[ib * uvChannelCount + i], t));
				}
				intersectedIndices[new int2(ia, ib)] = (resultIndex = (ushort)(positions.Length - 1));
			}
		}

		[Tooltip("Settings regarding mesh generation")]
		public RoadMeshSettings settings;

		[SerializeField]
		[HideInInspector]
		private bool autoGenerate;

		[Tooltip("Drag the model to be used for mesh generation into this slot")]
		public MeshFilter SourceMesh;

		private Road _road;

		private MeshFilter _mf;

		private static ProfilerMarker _extractResultsMarker = new ProfilerMarker("Extract Results");

		private static ProfilerMarker _disposeMarker = new ProfilerMarker("Dispose");

		private static ProfilerMarker _setVerticesMarker = new ProfilerMarker("Set Vertices");

		private static ProfilerMarker _setIndicesMarker = new ProfilerMarker("Set Indices");

		private static ProfilerMarker _setUVsMarker = new ProfilerMarker("Set UVs");

		private static ProfilerMarker _recalculateNormalsMarker = new ProfilerMarker("Recalculate Normals");

		private static ProfilerMarker _recalculateTangentsMarker = new ProfilerMarker("Recalculate Tangents");

		private static ProfilerMarker _recalculateBoundsMarker = new ProfilerMarker("Recalculate Bounds");

		public bool AutoGenerate
		{
			get
			{
				return autoGenerate;
			}
			set
			{
				if (value)
				{
					GenerateRoadMesh();
				}
				autoGenerate = value;
			}
		}

		public bool Valid { get; private set; }

		private void OnValidate()
		{
			_road = GetComponent<Road>();
			_mf = GetComponent<MeshFilter>();
		}

		public void GenerateRoadMesh(float stepSize = 1f)
		{
			if (!_road)
			{
				_road = GetComponent<Road>();
			}
			if (!_mf)
			{
				_mf = GetComponent<MeshFilter>();
			}
			if (!_road || !_mf || !SourceMesh)
			{
				return;
			}
			GenerateRoadMeshV2Job.OrientedPoint[] array = (from p in _road.GetEvenlySpacedPoints(stepSize)
				select new GenerateRoadMeshV2Job.OrientedPoint
				{
					Position = p.position,
					Forward = p.forward,
					Normal = p.normal
				}).ToArray();
			Mesh sharedMesh = SourceMesh.sharedMesh;
			VertexAttribute[] array2 = (VertexAttribute[])Enum.GetValues(typeof(VertexAttribute));
			NativeArray<VertexAttributeDescriptor> sourceVertexAttributes = new NativeArray<VertexAttributeDescriptor>(array2.Length, Allocator.TempJob);
			VertexAttributeDescriptor[] vertexAttributes = sharedMesh.GetVertexAttributes();
			for (int num = 0; num < vertexAttributes.Length; num++)
			{
				VertexAttributeDescriptor value = vertexAttributes[num];
				sourceVertexAttributes[(int)value.attribute] = value;
			}
			using Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(sharedMesh);
			Bounds bounds = sharedMesh.bounds;
			Mesh.MeshDataArray data = Mesh.AllocateWritableMeshData(1);
			using NativeArray<float3> resultBounds = new NativeArray<float3>(2, Allocator.TempJob);
			new GenerateRoadMeshV2Job
			{
				StepSize = stepSize,
				UVOffset = settings.uvOffset,
				Points = new NativeArray<GenerateRoadMeshV2Job.OrientedPoint>(array, Allocator.TempJob),
				SourceOrientation = settings.SourceOrientation,
				SourceMeshData = meshDataArray[0],
				SourceVertexAttributes = sourceVertexAttributes,
				SourceBounds = bounds,
				ResultMeshData = data[0],
				ResultBounds = resultBounds
			}.Run();
			Mesh mesh = new Mesh
			{
				name = "Road Mesh"
			};
			Mesh.ApplyAndDisposeWritableMeshData(data, mesh);
			mesh.bounds = new Bounds
			{
				min = resultBounds[0],
				max = resultBounds[1]
			};
			_mf.mesh = mesh;
			if ((bool)GetComponent<MeshCollider>().Let(out var result))
			{
				result.sharedMesh = _mf.sharedMesh;
			}
			Valid = true;
		}

		public void Invalidate(bool update = true)
		{
			Valid = false;
			if (AutoGenerate && update)
			{
				GenerateRoadMesh();
			}
		}
	}
}
