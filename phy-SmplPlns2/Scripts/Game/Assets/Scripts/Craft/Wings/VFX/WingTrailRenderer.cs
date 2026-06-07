using System;
using Assets.Scripts.Craft.Wings.Physics;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Wings.VFX
{
	public sealed class WingTrailRenderer : MonoBehaviour
	{
		private enum GeometryType
		{
			None = 0,
			StartCap = 1,
			EndCap = 2,
			Tube = 3
		}

		private struct Section
		{
			public float age;

			public bool cutoff;

			public GeometryType geometryType;

			public float3 position;

			public float power;

			public float radius;

			public LiftingLineSolver.TrailingVortex vortex;
		}

		private struct Triangle
		{
			public ushort a;

			public ushort b;

			public ushort c;

			public Triangle(ushort a, ushort b, ushort c)
			{
				this.a = a;
				this.b = b;
				this.c = c;
			}

			public Triangle(int a, int b, int c)
			{
				this.a = (ushort)a;
				this.b = (ushort)b;
				this.c = (ushort)c;
			}
		}

		[BurstCompile]
		private struct UpdateMesh : IJob
		{
			public float deltaTime;

			public Mesh.MeshDataArray meshData;

			public float minSegmentLength;

			public LiftingLineSolver.TrailingVortex? newSectionInput;

			public NativeList<Section> sectionsIn;

			public NativeList<Section> sectionsOut;

			public float3 travel;

			[ReadOnly]
			public NativeArray<VertexAttributeDescriptor> vertexDescriptors;

			void IJob.Execute()
			{
				sectionsOut.Clear();
				Section value = default(Section);
				bool flag = false;
				for (int i = 0; i < sectionsIn.Length; i++)
				{
					Section value2 = sectionsIn[i];
					value2.vortex.asymptotePos += travel;
					value2.vortex.sourcePos += travel;
					value2.age += deltaTime;
					value2.vortex.Extract(value2.age, out value2.position, out value2.power, out value2.radius);
					sectionsIn[i] = value2;
				}
				if (newSectionInput.HasValue)
				{
					Section value3 = new Section
					{
						vortex = newSectionInput.Value
					};
					value3.vortex.Extract(0f, out value3.position, out value3.power, out value3.radius);
					sectionsIn.Add(in value3);
				}
				sectionsOut.EnsureCapacity(sectionsIn.Length);
				int num = math.max(0, sectionsIn.Length - 256);
				for (int j = num; j < sectionsIn.Length; j++)
				{
					Section section = sectionsIn[j];
					bool flag2 = section.vortex.lifetime > section.age;
					if (sectionsOut.Length > 1 && math.lengthsq(section.vortex.sourcePos - value.vortex.sourcePos) <= minSegmentLength * minSegmentLength)
					{
						continue;
					}
					if (j == num)
					{
						if (flag2)
						{
							section.geometryType = GeometryType.StartCap;
							sectionsOut.AddNoResize(section);
						}
						value = section;
						flag = flag2;
					}
					else if (j == sectionsIn.Length - 1)
					{
						if (flag && value.geometryType != GeometryType.EndCap)
						{
							section.geometryType = GeometryType.EndCap;
							sectionsOut.AddNoResize(section);
						}
						else if (flag2)
						{
							section.geometryType = GeometryType.None;
							sectionsOut.AddNoResize(section);
						}
					}
					else if (flag2)
					{
						section.geometryType = GeometryType.Tube;
						if (flag)
						{
							if (value.geometryType == GeometryType.EndCap)
							{
								if (!value.cutoff)
								{
									value.geometryType = GeometryType.Tube;
									ref NativeList<Section> reference = ref sectionsOut;
									reference[reference.Length - 1] = value;
								}
								else
								{
									section.geometryType = GeometryType.StartCap;
								}
							}
						}
						else
						{
							value.geometryType = GeometryType.StartCap;
							sectionsOut.AddNoResize(value);
						}
						sectionsOut.AddNoResize(section);
						value = section;
						flag = true;
					}
					else if (flag && value.geometryType != GeometryType.EndCap)
					{
						section.geometryType = GeometryType.EndCap;
						sectionsOut.AddNoResize(section);
						value = section;
						flag = true;
					}
					else
					{
						value = section;
						flag = false;
						if (sectionsOut.Length > 0)
						{
							ref NativeList<Section> reference2 = ref sectionsOut;
							Section value4 = reference2[reference2.Length - 1];
							value4.cutoff = true;
							ref NativeList<Section> reference3 = ref sectionsOut;
							reference3[reference3.Length - 1] = value4;
						}
					}
				}
				if (sectionsOut.Length > 1)
				{
					ref NativeList<Section> reference4 = ref sectionsOut;
					Section value5 = reference4[reference4.Length - 1];
					if (value5.geometryType == GeometryType.Tube)
					{
						value5.geometryType = GeometryType.EndCap;
						ref NativeList<Section> reference5 = ref sectionsOut;
						reference5[reference5.Length - 1] = value5;
					}
					else if (value5.geometryType == GeometryType.StartCap)
					{
						sectionsOut.Length--;
					}
				}
				float num2 = 1f / math.cos(MathF.PI / 4f);
				NativeList<Section> nativeList = sectionsOut;
				Mesh.MeshData meshData = this.meshData[0];
				float3 float5 = math.up();
				if (nativeList.Length < 2)
				{
					meshData.SetVertexBufferParams(0, vertexDescriptors);
					meshData.SetIndexBufferParams(0, IndexFormat.UInt16);
					meshData.SetSubMesh(0, new SubMeshDescriptor
					{
						baseVertex = 0,
						bounds = default(Bounds),
						firstVertex = 0,
						topology = MeshTopology.Triangles,
						indexCount = 0,
						indexStart = 0,
						vertexCount = 0
					});
					return;
				}
				meshData.SetVertexBufferParams(nativeList.Length * 4, vertexDescriptors);
				NativeArray<Vertex> vertexData = meshData.GetVertexData<Vertex>();
				int num3 = 0;
				for (int k = 0; k < nativeList.Length; k++)
				{
					Section section2 = nativeList[k];
					float3 float6;
					if (k == 0)
					{
						float6 = nativeList[k + 1].position - section2.position;
					}
					else if (k == nativeList.Length - 1)
					{
						float6 = section2.position - nativeList[k - 1].position;
					}
					else
					{
						float3 x = nativeList[k + 1].position - section2.position;
						float3 x2 = section2.position - nativeList[k - 1].position;
						float6 = 0.5f * (math.normalize(x) + math.normalize(x2));
					}
					float num4 = section2.radius * num2;
					float3 float7 = math.normalizesafe(math.cross(float5, float6));
					float5 = math.normalizesafe(math.cross(float6, float7));
					for (int l = 0; l < 4; l++)
					{
						math.sincos((float)l * (MathF.PI / 2f), out var s, out var c);
						float3 float8 = s * float7 + c * float5;
						float3 position = section2.position + float8 * num4;
						vertexData[k * 4 + l] = new Vertex
						{
							position = position,
							uv0 = math.float4(section2.vortex.lifetime - section2.age, section2.radius, section2.power, section2.age),
							uv1 = section2.position,
							uv2 = float6
						};
					}
					int num5 = num3;
					num3 = num5 + section2.geometryType switch
					{
						GeometryType.StartCap => 2, 
						GeometryType.EndCap => 10, 
						GeometryType.Tube => 8, 
						_ => 0, 
					};
				}
				meshData.SetIndexBufferParams(num3 * 3, IndexFormat.UInt16);
				NativeArray<Triangle> indexData = meshData.GetIndexData<Triangle>();
				int num6 = 0;
				for (int m = 0; m < nativeList.Length; m++)
				{
					Section section3 = nativeList[m];
					int num7 = m * 4;
					int num8 = (m - 1) * 4;
					if (section3.geometryType == GeometryType.StartCap)
					{
						for (int n = 0; n < 2; n++)
						{
							indexData[num6++] = new Triangle(num7, num7 + n + 1, num7 + n + 2);
						}
					}
					else
					{
						if (section3.geometryType != GeometryType.EndCap && section3.geometryType != GeometryType.Tube)
						{
							continue;
						}
						int num9 = 3;
						int num10 = 0;
						while (num10 < 4)
						{
							indexData[num6++] = new Triangle(num8 + num9, num7 + num9, num8 + num10);
							indexData[num6++] = new Triangle(num8 + num10, num7 + num9, num7 + num10);
							num9 = num10++;
						}
						if (section3.geometryType == GeometryType.EndCap)
						{
							for (int num11 = 0; num11 < 2; num11++)
							{
								indexData[num6++] = new Triangle(num7, num7 + num11 + 2, num7 + num11 + 1);
							}
						}
					}
				}
				meshData.SetSubMesh(0, new SubMeshDescriptor
				{
					baseVertex = 0,
					firstVertex = 0,
					vertexCount = nativeList.Length * 4,
					indexStart = 0,
					indexCount = num3 * 3,
					topology = MeshTopology.Triangles
				});
			}
		}

		private struct Vertex
		{
			public float3 position;

			public float4 uv0;

			public float3 uv1;

			public float3 uv2;

			public static VertexAttributeDescriptor[] Format { get; } = new VertexAttributeDescriptor[4]
			{
				new VertexAttributeDescriptor
				{
					attribute = VertexAttribute.Position,
					dimension = 3,
					format = VertexAttributeFormat.Float32,
					stream = 0
				},
				new VertexAttributeDescriptor
				{
					attribute = VertexAttribute.TexCoord0,
					dimension = 4,
					format = VertexAttributeFormat.Float32,
					stream = 0
				},
				new VertexAttributeDescriptor
				{
					attribute = VertexAttribute.TexCoord1,
					dimension = 3,
					format = VertexAttributeFormat.Float32,
					stream = 0
				},
				new VertexAttributeDescriptor
				{
					attribute = VertexAttribute.TexCoord2,
					dimension = 3,
					format = VertexAttributeFormat.Float32,
					stream = 0
				}
			};
		}

		private const int MaxSegments = 256;

		private float _deltaTime;

		private Material _material;

		private Mesh _mesh;

		private float3 _offset;

		private RenderParams _renderParams;

		private NativeList<Section> _sections;

		private NativeList<Section> _sectionsTemp;

		private NativeArray<VertexAttributeDescriptor> _vertexFormat;

		private LiftingLineSolver.TrailingVortex? _vortex;

		public void AddOffset(float3 offset)
		{
			_offset += offset;
		}

		public void AddTime(float time)
		{
			_deltaTime += time;
		}

		public void SetVortex(LiftingLineSolver.TrailingVortex vortex)
		{
			_vortex = vortex;
		}

		private void OnDestroy()
		{
			if (_mesh != null)
			{
				UnityEngine.Object.Destroy(_mesh);
			}
			_sections.Dispose();
			_sectionsTemp.Dispose();
			_vertexFormat.Dispose();
		}

		private void Start()
		{
			_mesh = new Mesh
			{
				name = "WingTrailRenderer"
			};
			_sections = new NativeList<Section>(257, Allocator.Persistent);
			_sectionsTemp = new NativeList<Section>(257, Allocator.Persistent);
			_vertexFormat = new NativeArray<VertexAttributeDescriptor>(Vertex.Format, Allocator.Persistent);
			_material = Resources.Load<Material>("Craft/WingVFX/WingTrail");
			_renderParams = new RenderParams
			{
				instanceID = base.gameObject.GetInstanceID(),
				layer = base.gameObject.layer,
				lightProbeUsage = LightProbeUsage.Off,
				material = _material,
				motionVectorMode = MotionVectorGenerationMode.ForceNoMotion,
				receiveShadows = true,
				reflectionProbeUsage = ReflectionProbeUsage.Off,
				shadowCastingMode = ShadowCastingMode.Off,
				renderingLayerMask = RenderingLayerMask.defaultRenderingLayerMask
			};
		}

		private void Update()
		{
			Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(_mesh);
			if (_vortex.HasValue)
			{
				LiftingLineSolver.TrailingVortex value = _vortex.Value;
				value.Transform(base.transform.localToWorldMatrix);
				_vortex = value;
			}
			new UpdateMesh
			{
				sectionsIn = _sections,
				sectionsOut = _sectionsTemp,
				deltaTime = _deltaTime,
				meshData = meshDataArray,
				minSegmentLength = 0.01f,
				vertexDescriptors = _vertexFormat,
				newSectionInput = _vortex,
				travel = _offset
			}.Run();
			_deltaTime = 0f;
			_vortex = null;
			_offset = 0f;
			NativeList<Section> sectionsTemp = _sectionsTemp;
			NativeList<Section> sections = _sections;
			_sections = sectionsTemp;
			_sectionsTemp = sections;
			Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, _mesh);
			_mesh.RecalculateBounds();
			_mesh.UploadMeshData(markNoLongerReadable: false);
			_renderParams.worldBounds = _mesh.bounds;
			Graphics.RenderMesh(in _renderParams, _mesh, 0, Matrix4x4.identity);
		}
	}
}
