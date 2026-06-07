using System;
using System.IO;
using System.Text;
using Assets.Scripts.Craft.MeshGen;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Extensions;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public static class FuselageCutter
	{
		public enum SliceResult
		{
			Success = 0,
			MeshFormatError = 1,
			GenericSliceError = 2,
			PlaneFillError = 3,
			AllShown = 4,
			AllHidden = 5,
			MeshApplyError = 6
		}

		[BurstCompile]
		private struct ConvertSubmeshes : IJobFor
		{
			[ReadOnly]
			public NativeArray<ushort> VertexSubmeshIds;

			[ReadOnly]
			public NativeArray<Triangle> Triangles;

			[WriteOnly]
			public NativeArray<ushort> Output;

			public void Execute(int index)
			{
				Output[index] = VertexSubmeshIds[Triangles[index].A];
			}
		}

		[BurstCompile]
		private struct ConvertIndexBuffer : IJobFor
		{
			[ReadOnly]
			public NativeArray<int> Input;

			[WriteOnly]
			public NativeArray<ushort> Output;

			public void Execute(int index)
			{
				Output[index] = (ushort)Input[index];
			}
		}

		[BurstCompile]
		private struct ConvertMeshOutSimple : IJob
		{
			[ReadOnly]
			public NativeArray<int> OutputCounts;

			[ReadOnly]
			public NativeArray<Triangle> Triangles;

			public NativeList<int3> OutTriangles;

			public void Execute()
			{
				int i = 0;
				for (int j = 1; j < OutputCounts.Length; j++)
				{
					int num = i + OutputCounts[j];
					OutTriangles.EnsureFreeCapacity(OutputCounts[j]);
					for (; i < num; i++)
					{
						Triangle triangle = Triangles[i];
						OutTriangles.AddNoResize(new int3(triangle.A, triangle.B, triangle.C));
					}
				}
			}
		}

		[BurstCompile]
		private struct ConvertMeshOut : IJob
		{
			[ReadOnly]
			public NativeArray<int> OutputCounts;

			[ReadOnly]
			public NativeArray<Triangle> Triangles;

			public NativeList<int3> OutTriangles;

			[WriteOnly]
			public NativeArray<ushort> OutSubmeshIndices;

			public void Execute()
			{
				int i = 0;
				for (int j = 1; j < OutputCounts.Length; j++)
				{
					ushort value = (ushort)(j - 1);
					int num = i + OutputCounts[j];
					OutTriangles.EnsureCapacity(num);
					for (; i < num; i++)
					{
						Triangle triangle = Triangles[i];
						OutTriangles.AddNoResize(new int3(triangle.A, triangle.B, triangle.C));
						OutSubmeshIndices[triangle.A] = value;
						OutSubmeshIndices[triangle.B] = value;
						OutSubmeshIndices[triangle.C] = value;
					}
				}
			}
		}

		[BurstCompile]
		private struct GetSubmeshIndices : IJob
		{
			public Mesh.MeshDataArray Mesh;

			public NativeArray<ushort> Output;

			public void Execute()
			{
				Mesh.MeshData meshData = Mesh[0];
				for (int i = 0; i < Output.Length; i++)
				{
					Output[i] = ushort.MaxValue;
				}
				for (ushort num = 0; num < meshData.subMeshCount; num++)
				{
					SubMeshDescriptor subMesh = meshData.GetSubMesh(num);
					int num2 = subMesh.indexStart / 3;
					int num3 = (subMesh.indexStart + subMesh.indexCount) / 3;
					for (int j = num2; j < Output.Length && j < num3; j++)
					{
						Output[j] = num;
					}
				}
			}
		}

		[BurstCompile(CompileSynchronously = true, FloatMode = FloatMode.Strict, FloatPrecision = FloatPrecision.High)]
		private struct CutJob : IJob
		{
			private struct MyEdge
			{
				public int Face1;

				public int Face2;

				public ushort Submesh;

				public int Vertex1;

				public int Vertex2;

				public bool Visibile;

				public int NumFaces
				{
					get
					{
						if (Vertex1 == -1 || Vertex2 == -1)
						{
							if (Vertex1 == -1 && Vertex2 == -1)
							{
								return 0;
							}
							return 1;
						}
						return 2;
					}
				}

				public void AddFace(int face)
				{
					if (Face1 == -1)
					{
						Face1 = face;
					}
					else
					{
						Face2 = face;
					}
				}

				public int GetOtherVertex(int vert)
				{
					if (Vertex1 == vert)
					{
						return Vertex2;
					}
					if (Vertex2 == vert)
					{
						return Vertex1;
					}
					return -1;
				}
			}

			private struct MyFace
			{
				public UnsafeList<int> Edges;

				public float3 Normal;

				public ushort Submesh;

				public bool Visible;
			}

			private struct MyVert
			{
				public ushort Appindex;

				public unsafe Vertex* Appvertex;

				public float Distance;

				public float3 Normal;

				public int Occurs;

				public float3 Position;

				public bool Visible;
			}

			private struct PlaneEdge
			{
				public bool Found;

				public float3 Normal;

				public PlanePoint P1;

				public PlanePoint P2;

				public ushort Submesh;
			}

			private struct PlanePoint
			{
				public float3 MeshPos;

				public float2 PlanePos;

				public unsafe Vertex* SourceVertex;
			}

			private struct PlanePolygon
			{
				public float Area;

				public UnsafeList<PlanePoint> Points;

				public bool ContainsPoint(float2 point)
				{
					bool flag = false;
					int index = Points.Length - 1;
					int num = 0;
					while (num < Points.Length)
					{
						float2 planePos = Points[index].PlanePos;
						float2 planePos2 = Points[num].PlanePos;
						if (((planePos.y <= point.y && planePos2.y > point.y) || (planePos.y >= point.y && planePos2.y < point.y)) && math.lerp(planePos.x, planePos2.x, math.unlerp(planePos.y, planePos2.y, point.y)) < point.x)
						{
							flag = !flag;
						}
						index = num++;
					}
					return flag;
				}

				public void Dispose()
				{
					if (Points.IsCreated)
					{
						Points.Dispose();
					}
				}

				public unsafe SliceResult GobbleHole(PlanePolygon* other, ref int vertexCount, in Plane plane)
				{
					UnsafeList<PlanePoint> points = other->Points;
					int num = 0;
					float num2 = points[num].PlanePos.x;
					for (int i = 1; i < points.Length; i++)
					{
						float x = points[i].PlanePos.x;
						if (x > num2)
						{
							num2 = x;
							num = i;
						}
					}
					PlanePoint planePoint = points[num];
					float2 planePos = planePoint.PlanePos;
					bool flag = false;
					int num3 = -1;
					float num4 = float.PositiveInfinity;
					int num5 = Points.Length - 1;
					int num6 = 0;
					while (num6 < Points.Length)
					{
						float2 planePos2 = Points[num5].PlanePos;
						float2 planePos3 = Points[num6].PlanePos;
						if (math.distance(planePos3.y, planePos.y) < 1.1920929E-07f && planePos3.x >= planePos.x)
						{
							float num7 = planePos3.x - planePos.x;
							if (num7 < num4)
							{
								flag = false;
								num3 = num6;
								num4 = num7;
							}
						}
						else if ((planePos2.y < planePos.y && planePos3.y > planePos.y) || (planePos2.y > planePos.y && planePos3.y < planePos.y))
						{
							float num8 = math.lerp(planePos2.x, planePos3.x, math.unlerp(planePos2.y, planePos3.y, planePos.y)) - planePos.x;
							if (num8 >= 0f && num8 < num4)
							{
								flag = true;
								num3 = num5;
								num4 = num8;
							}
						}
						num5 = num6++;
					}
					if (num3 == -1)
					{
						return SliceResult.GenericSliceError;
					}
					if (flag)
					{
						float2 float5 = planePos;
						float5.x += num4;
						PlanePoint value = new PlanePoint
						{
							PlanePos = planePos + math.float2(num4, 0f),
							MeshPos = planePoint.MeshPos + plane.PlaneX * num4,
							SourceVertex = Points[num3].SourceVertex
						};
						vertexCount++;
						int length = Points.Length;
						Points.Resize(Points.Length + points.Length + 3);
						UnsafeUtility.MemMove(Points.Ptr + (num3 + points.Length + 4), Points.Ptr + (num3 + 1), (length - (num3 + 1)) * sizeof(PlanePoint));
						int num9 = num3 + 1;
						Points[num9] = value;
						num9++;
						for (int j = num; j < points.Length; j++)
						{
							Points[num9] = points[j];
							num9++;
						}
						for (int k = 0; k <= num; k++)
						{
							Points[num9] = points[k];
							num9++;
						}
						Points[num9] = value;
						num9++;
					}
					else if (num4 < 1.1920929E-07f)
					{
						vertexCount -= 2;
						int length2 = Points.Length;
						Points.Resize(Points.Length + points.Length);
						UnsafeUtility.MemMove(Points.Ptr + (num3 + 1 + points.Length), Points.Ptr + (num3 + 1), (length2 - (num3 + 1)) * sizeof(PlanePoint));
						int num10 = num3 + 1;
						for (int l = num + 1; l < points.Length; l++)
						{
							Points[num10] = points[l];
							num10++;
						}
						for (int m = 0; m < num; m++)
						{
							Points[num10] = points[m];
							num10++;
						}
						Points[num10] = Points[num3];
					}
					else
					{
						int length3 = Points.Length;
						Points.Resize(Points.Length + points.Length + 2);
						UnsafeUtility.MemMove(Points.Ptr + (num3 + points.Length + 3), Points.Ptr + (num3 + 1), (length3 - (num3 + 1)) * sizeof(PlanePoint));
						int num11 = num3 + 1;
						for (int n = num; n < points.Length; n++)
						{
							Points[num11] = points[n];
							num11++;
						}
						for (int num12 = 0; num12 <= num; num12++)
						{
							Points[num11] = points[num12];
							num11++;
						}
						Points[num11] = Points[num3];
					}
					return SliceResult.Success;
				}

				public unsafe bool IsInside(PlanePolygon* other)
				{
					for (int i = 0; i < Points.Length; i++)
					{
						if (!other->ContainsPoint(Points[i].PlanePos))
						{
							return false;
						}
					}
					return true;
				}

				public void RecalculateArea()
				{
					float num = 0f;
					int index = Points.Length - 1;
					int num2 = 0;
					while (num2 < Points.Length)
					{
						float2 planePos = Points[index].PlanePos;
						float2 planePos2 = Points[num2].PlanePos;
						num += planePos.x * planePos2.y - planePos2.x * planePos.y;
						index = num2++;
					}
					Area = num * 0.5f;
				}

				private unsafe static SliceResult InsertSpace<T>(ref UnsafeList<T> list, int start, int length) where T : unmanaged
				{
					int length2 = list.Length;
					if (start > length2)
					{
						return SliceResult.GenericSliceError;
					}
					list.Resize(list.Length + length);
					if (start < length2)
					{
						byte* ptr = (byte*)list.Ptr;
						int num = sizeof(T);
						UnsafeUtility.MemMove(ptr + start * num, ptr + (start + length) * num, (length2 - start) * num);
					}
					return SliceResult.Success;
				}
			}

			public const float ClippingEpsilon = 0.0001f;

			public const float MinPlaneEdgeLength = 1E-05f;

			public const float NormalEpsilon = 0.001f;

			public const float PositionEpsilon = 0.0005f;

			[ReadOnly]
			public Plane CutPlane;

			[NativeDisableContainerSafetyRestriction]
			public NativeArray<int> VertexBuffer;

			[NativeDisableContainerSafetyRestriction]
			public NativeArray<Triangle> IndexBuffer;

			public NativeArray<ushort> SubmeshIndices;

			public NativeArray<int> OutputCounts;

			public NativeArray<Triangle> OutputTriangles;

			public NativeArray<int> OutputVertices;

			[ReadOnly]
			public float2 PlaneFaceUv0;

			[ReadOnly]
			public float3 PlaneFaceUv1;

			[ReadOnly]
			public int PlaneSubmesh;

			public NativeArray<SliceResult> Result;

			[ReadOnly]
			public byte ReversePlaneFaces;

			[ReadOnly]
			public int Uv0Offset;

			[ReadOnly]
			public int Uv1Offset;

			[ReadOnly]
			public int VertexSize;

			public int InitialVertices;

			public int SubmeshCount;

			public unsafe void Execute()
			{
				Result[0] = SliceResult.GenericSliceError;
				NativeArray<int> vertexBuffer = VertexBuffer;
				NativeArray<Triangle> indexBuffer = IndexBuffer;
				Vertex* unsafePtr = (Vertex*)vertexBuffer.GetUnsafePtr();
				UnsafeList<MyVert> verts = new UnsafeList<MyVert>(InitialVertices, Allocator.Temp);
				UnsafeList<MyEdge> edges = new UnsafeList<MyEdge>(indexBuffer.Length * 2, Allocator.Temp);
				UnsafeList<MyFace> faces = new UnsafeList<MyFace>(indexBuffer.Length, Allocator.Temp);
				UnsafeList<PlaneEdge> edges2 = new UnsafeList<PlaneEdge>(16, Allocator.Temp);
				UnsafeList<PlanePolygon> unsafeList = new UnsafeList<PlanePolygon>(8, Allocator.Temp);
				try
				{
					MyVert** ptr = &verts.Ptr;
					MyEdge** ptr2 = &edges.Ptr;
					MyFace** ptr3 = &faces.Ptr;
					float3 point = CutPlane.Point;
					float3 normal = CutPlane.Normal;
					bool flag = false;
					bool flag2 = false;
					for (int i = 0; i < InitialVertices; i++)
					{
						Vertex* unsafePtr2 = (Vertex*)vertexBuffer.Slice(i * VertexSize >> 2, sizeof(Vertex) >> 2).GetUnsafePtr();
						float num = math.dot(unsafePtr2->position - point, normal);
						MyVert value = new MyVert
						{
							Appvertex = unsafePtr2,
							Appindex = (ushort)i,
							Position = unsafePtr2->position,
							Normal = unsafePtr2->normal,
							Distance = num,
							Occurs = 0,
							Visible = (num > -0.0001f)
						};
						if (num >= 0.0001f)
						{
							flag = true;
						}
						else if (num <= -0.0001f)
						{
							flag2 = true;
							value.Visible = false;
						}
						else
						{
							value.Distance = 0f;
						}
						verts.AddNoResize(value);
						if (value.Visible)
						{
							flag = true;
						}
						else
						{
							flag2 = true;
						}
					}
					if (!flag)
					{
						Result[0] = SliceResult.AllHidden;
						return;
					}
					if (!flag2)
					{
						Result[0] = SliceResult.AllShown;
						return;
					}
					for (int j = 0; j < indexBuffer.Length; j++)
					{
						ushort num2 = SubmeshIndices[j];
						if (num2 != ushort.MaxValue)
						{
							Triangle triangle = indexBuffer[j];
							float3 position = verts[triangle.A].Position;
							float3 position2 = verts[triangle.B].Position;
							float3 x = math.cross(y: verts[triangle.C].Position - position, x: position2 - position);
							x -= math.dot(x, normal) * normal;
							MyFace value2 = new MyFace
							{
								Edges = new UnsafeList<int>(3, Allocator.Temp),
								Visible = true,
								Submesh = num2,
								Normal = math.normalizesafe(x)
							};
							int value3 = AddOrGetEdge(triangle.A, triangle.B, faces.Length, num2, ref edges);
							value2.Edges.AddNoResize(value3);
							value3 = AddOrGetEdge(triangle.B, triangle.C, faces.Length, num2, ref edges);
							value2.Edges.AddNoResize(value3);
							value3 = AddOrGetEdge(triangle.C, triangle.A, faces.Length, num2, ref edges);
							value2.Edges.AddNoResize(value3);
							faces.Add(in value2);
						}
					}
					for (int k = 0; k < edges.Length; k++)
					{
						MyVert myVert = verts[edges[k].Vertex1];
						MyVert myVert2 = verts[edges[k].Vertex2];
						float distance = myVert.Distance;
						float distance2 = myVert2.Distance;
						if (distance <= 0f && distance2 <= 0f)
						{
							CullEdge(k, ref faces, ref edges);
						}
						else if (!(distance >= 0f) || !(distance2 >= 0f))
						{
							float num3 = distance / (distance - distance2);
							MyVert value4 = new MyVert
							{
								Position = math.lerp(verts[edges[k].Vertex1].Position, verts[edges[k].Vertex2].Position, num3),
								Normal = math.lerp(verts[edges[k].Vertex1].Normal, verts[edges[k].Vertex2].Normal, num3),
								Distance = 0f,
								Occurs = 0,
								Visible = true,
								Appvertex = ((num3 <= 0.5f) ? myVert.Appvertex : myVert2.Appvertex),
								Appindex = ((num3 <= 0.5f) ? myVert.Appindex : myVert2.Appindex)
							};
							int length = verts.Length;
							verts.Add(in value4);
							if (distance >= 0f)
							{
								(*ptr2)[k].Vertex2 = length;
							}
							else
							{
								(*ptr2)[k].Vertex1 = length;
							}
						}
					}
					for (int l = 0; l < faces.Length; l++)
					{
						if (!faces[l].Visible)
						{
							continue;
						}
						for (int m = 0; m < faces[l].Edges.Length; m++)
						{
							MyEdge myEdge = edges[faces[l].Edges[m]];
							(*ptr)[myEdge.Vertex1].Occurs = 0;
							(*ptr)[myEdge.Vertex2].Occurs = 0;
						}
						if (!GetOpenPolyline(faces[l], out var start, out var final, out var intervening, ref verts, ref edges))
						{
							continue;
						}
						ushort submesh = edges[faces[l].Edges[0]].Submesh;
						MyEdge value5 = new MyEdge
						{
							Vertex1 = start,
							Vertex2 = final,
							Face1 = l,
							Face2 = -1,
							Visibile = true,
							Submesh = submesh
						};
						int value6 = edges.Length;
						edges.Add(in value5);
						float3 float5 = verts[final].Position - verts[start].Position;
						if (math.lengthsq(float5) >= 9.9999994E-11f)
						{
							PlaneEdge value7 = new PlaneEdge
							{
								Submesh = submesh,
								Normal = faces[l].Normal,
								Found = false
							};
							PlanePoint planePoint = new PlanePoint
							{
								MeshPos = verts[start].Position,
								PlanePos = PointToPlane(verts[start].Position),
								SourceVertex = verts[start].Appvertex
							};
							PlanePoint planePoint2 = new PlanePoint
							{
								MeshPos = verts[final].Position,
								PlanePos = PointToPlane(verts[final].Position),
								SourceVertex = verts[final].Appvertex
							};
							if (math.dot(math.cross(normal, value7.Normal), float5) > 0f)
							{
								value7.P1 = planePoint;
								value7.P2 = planePoint2;
							}
							else
							{
								value7.P1 = planePoint2;
								value7.P2 = planePoint;
							}
							edges2.Add(in value7);
						}
						if (faces[l].Edges.Length == 3)
						{
							int length2 = faces.Length;
							int num4 = -1;
							int value8 = -1;
							int num5 = -1;
							for (int n = 0; n < faces[l].Edges.Length; n++)
							{
								MyEdge myEdge2 = edges[faces[l].Edges[n]];
								if (myEdge2.Vertex1 == final)
								{
									num4 = myEdge2.Vertex2;
									value8 = faces[l].Edges[n];
									num5 = n;
									break;
								}
								if (myEdge2.Vertex2 == final)
								{
									num4 = myEdge2.Vertex1;
									value8 = faces[l].Edges[n];
									num5 = n;
									break;
								}
							}
							if (num4 == -1)
							{
								Result[0] = SliceResult.GenericSliceError;
								return;
							}
							int length3 = edges.Length;
							edges.Add(new MyEdge
							{
								Face1 = l,
								Face2 = length2,
								Vertex1 = start,
								Vertex2 = num4,
								Visibile = true,
								Submesh = submesh
							});
							MyFace value9 = new MyFace
							{
								Edges = new UnsafeList<int>(3, Allocator.Temp),
								Visible = true,
								Submesh = submesh,
								Normal = faces[l].Normal
							};
							if (intervening == 2)
							{
								value9.Edges.AddNoResize(value6);
								value9.Edges.AddNoResize(length3);
								value9.Edges.AddNoResize(value8);
							}
							else
							{
								value9.Edges.AddNoResize(value6);
								value9.Edges.AddNoResize(value8);
								value9.Edges.AddNoResize(length3);
							}
							faces[l].Edges.Ptr[num5] = length3;
							faces.Add(in value9);
						}
						else
						{
							(*ptr3)[l].Edges.Add(in value6);
						}
					}
					int vertexCount = 0;
					if (PlaneSubmesh != -1)
					{
						for (int num6 = 0; num6 < edges2.Length; num6++)
						{
							PlaneEdge* ptr4 = edges2.Ptr + num6;
							if (ptr4->Found)
							{
								continue;
							}
							UnsafeList<PlanePoint> points = new UnsafeList<PlanePoint>(16, Allocator.Temp);
							try
							{
								while (true)
								{
									points.Add(in ptr4->P2);
									int num7 = FindEdgeWithVert1(ptr4->P2, ref edges2, ref verts);
									if (num7 < 0)
									{
										Result[0] = SliceResult.PlaneFillError;
										break;
									}
									if (num7 == num6)
									{
										PlanePolygon value10 = new PlanePolygon
										{
											Points = points
										};
										value10.RecalculateArea();
										if (value10.Area > 1.1920929E-07f)
										{
											vertexCount += points.Length;
										}
										else
										{
											if (!(value10.Area < -1.1920929E-07f))
											{
												points.Dispose();
												points = default(UnsafeList<PlanePoint>);
												break;
											}
											vertexCount += points.Length + 2;
										}
										unsafeList.Add(in value10);
										points = default(UnsafeList<PlanePoint>);
										break;
									}
									ptr4 = edges2.Ptr + num7;
									ptr4->Found = true;
								}
							}
							finally
							{
								if (points.IsCreated)
								{
									points.Dispose();
								}
							}
						}
						bool flag3 = true;
						while (flag3)
						{
							flag3 = false;
							for (int num8 = 0; num8 < unsafeList.Length; num8++)
							{
								PlanePolygon* ptr5 = unsafeList.Ptr + num8;
								if (!(ptr5->Area < 0f))
								{
									continue;
								}
								flag3 = true;
								PlanePolygon* ptr6 = null;
								for (int num9 = 0; num9 < unsafeList.Length; num9++)
								{
									PlanePolygon* ptr7 = unsafeList.Ptr + num9;
									if (ptr7->Area > 0f - ptr5->Area && (ptr6 == null || ptr7->Area < ptr6->Area) && ptr5->IsInside(ptr7))
									{
										ptr6 = ptr7;
									}
								}
								if (ptr6 == null)
								{
									Debug.LogError("Couldn't find parent of hole");
								}
								else
								{
									SliceResult sliceResult = ptr6->GobbleHole(ptr5, ref vertexCount, in CutPlane);
									if (sliceResult != SliceResult.Success)
									{
										Result[0] = sliceResult;
										return;
									}
								}
								ptr5->Dispose();
								unsafeList.RemoveAtSwapBack(num8);
								break;
							}
						}
					}
					for (int num10 = 0; num10 < verts.Length; num10++)
					{
						if (verts[num10].Visible)
						{
							vertexCount++;
						}
					}
					int num11 = 0;
					for (int num12 = 0; num12 < faces.Length; num12++)
					{
						if (faces[num12].Visible && faces[num12].Edges.Length == 3)
						{
							num11++;
						}
					}
					NativeArray<Triangle> outputTriangles = OutputTriangles;
					if (num11 > outputTriangles.Length)
					{
						Result[0] = SliceResult.GenericSliceError;
						return;
					}
					NativeArray<int> outputVertices = OutputVertices;
					if (VertexSize * vertexCount >> 2 > outputVertices.Length)
					{
						Result[0] = SliceResult.GenericSliceError;
						return;
					}
					ushort num13 = 0;
					for (int num14 = 0; num14 < verts.Length; num14++)
					{
						if (verts[num14].Visible)
						{
							Vertex* appvertex = verts[num14].Appvertex;
							Vertex* ptr8 = (Vertex*)((byte*)outputVertices.GetUnsafePtr() + (nint)(num13 * VertexSize >> 2) * (nint)4);
							UnsafeUtility.MemCpy(ptr8, appvertex, VertexSize);
							ptr8->position = verts[num14].Position;
							ptr8->normal = verts[num14].Normal;
							(*ptr)[num14].Appvertex = ptr8;
							(*ptr)[num14].Appindex = num13++;
						}
					}
					int num15 = 0;
					for (ushort num16 = 0; num16 < SubmeshCount; num16++)
					{
						int num17 = 0;
						for (int num18 = 0; num18 < faces.Length; num18++)
						{
							if (faces[num18].Visible && faces[num18].Submesh == num16 && faces[num18].Edges.Length == 3)
							{
								MyEdge e = edges[faces[num18].Edges[0]];
								MyEdge e2 = edges[faces[num18].Edges[1]];
								int sharedVertex = GetSharedVertex(e, e2);
								if (sharedVertex == -1)
								{
									Result[0] = SliceResult.GenericSliceError;
									return;
								}
								int otherVertex = e.GetOtherVertex(sharedVertex);
								int otherVertex2 = e2.GetOtherVertex(sharedVertex);
								if (otherVertex == -1 || otherVertex2 == -1)
								{
									Result[0] = SliceResult.GenericSliceError;
									return;
								}
								Triangle value11 = new Triangle
								{
									A = verts[otherVertex].Appindex,
									B = verts[sharedVertex].Appindex,
									C = verts[otherVertex2].Appindex
								};
								outputTriangles[num15++] = value11;
								num17++;
							}
						}
						if (num16 == PlaneSubmesh)
						{
							for (int num19 = 0; num19 < unsafeList.Length; num19++)
							{
								PlanePolygon* ptr9 = unsafeList.Ptr + num19;
								NativeArray<int> V = new NativeArray<int>(ptr9->Points.Length, Allocator.Temp);
								NativeArray<Triangle> triangles = new NativeArray<Triangle>(ptr9->Points.Length - 2, Allocator.Temp);
								try
								{
									int num20 = num13;
									int num21 = Triangulate(num20, ptr9->Area, ReversePlaneFaces, ref ptr9->Points, ref triangles, ref V);
									for (int num22 = 0; num22 < ptr9->Points.Length; num22++)
									{
										PlanePoint planePoint3 = ptr9->Points[num22];
										Vertex* ptr10 = (Vertex*)((byte*)outputVertices.GetUnsafePtr() + (nint)(num13 * VertexSize >> 2) * (nint)4);
										UnsafeUtility.MemCpy(ptr10, planePoint3.SourceVertex, VertexSize);
										ptr10->position = planePoint3.MeshPos;
										ptr10->normal = -CutPlane.Normal;
										if (Uv0Offset != -1)
										{
											*GetUV0(ptr10) = PlaneFaceUv0;
										}
										if (Uv1Offset != -1)
										{
											*GetUV1(ptr10) = PlaneFaceUv1;
										}
										num13++;
									}
									for (int num23 = 0; num23 < num21; num23++)
									{
										Triangle value12 = triangles[num23];
										float3 meshPos = ptr9->Points[value12.A - num20].MeshPos;
										float3 meshPos2 = ptr9->Points[value12.B - num20].MeshPos;
										float3 meshPos3 = ptr9->Points[value12.C - num20].MeshPos;
										if (math.dot(CutPlane.Normal, math.cross(meshPos2 - meshPos, meshPos3 - meshPos)) > 0f)
										{
											value12.Reverse();
										}
										outputTriangles[num15++] = value12;
										num17++;
									}
								}
								finally
								{
									if (V.IsCreated)
									{
										V.Dispose();
									}
									if (triangles.IsCreated)
									{
										triangles.Dispose();
									}
								}
							}
						}
						OutputCounts[num16 + 1] = num17;
					}
					OutputCounts[0] = num13;
				}
				finally
				{
					if (verts.IsCreated)
					{
						verts.Dispose();
					}
					if (edges.IsCreated)
					{
						edges.Dispose();
					}
					if (faces.IsCreated)
					{
						for (int num24 = 0; num24 < faces.Length; num24++)
						{
							UnsafeList<int> edges3 = faces[num24].Edges;
							if (edges3.IsCreated)
							{
								edges3.Dispose();
							}
						}
						faces.Dispose();
					}
					if (unsafeList.IsCreated)
					{
						for (int num25 = 0; num25 < unsafeList.Length; num25++)
						{
							unsafeList.Ptr[num25].Dispose();
						}
						unsafeList.Dispose();
					}
				}
				if (Result[0] != SliceResult.PlaneFillError)
				{
					Result[0] = SliceResult.Success;
				}
			}

			private unsafe static int FindEdgeWithVert1(PlanePoint target, ref UnsafeList<PlaneEdge> edges, ref UnsafeList<MyVert> verts)
			{
				float num = 2.5000003E-07f;
				int result = -1;
				for (int i = 0; i < edges.Length; i++)
				{
					PlaneEdge* num2 = edges.Ptr + i;
					float num3 = math.distancesq(num2->P1.PlanePos, target.PlanePos);
					if (!num2->Found && num3 <= num)
					{
						result = i;
						num = num3;
					}
				}
				return result;
			}

			private static int IndexOf(int value, UnsafeList<int> list)
			{
				for (int i = 0; i < list.Length; i++)
				{
					if (list[i] == value)
					{
						return i;
					}
				}
				return -1;
			}

			private static int Remove(ref UnsafeList<int> list, int value)
			{
				for (int i = 0; i < list.Length; i++)
				{
					if (list[i] == value)
					{
						list.RemoveAt(i);
						return i;
					}
				}
				return -1;
			}

			private static void RemoveSwapBack(ref UnsafeList<int> list, int value)
			{
				for (int i = 0; i < list.Length; i++)
				{
					if (list[i] == value)
					{
						list.RemoveAtSwapBack(i);
						break;
					}
				}
			}

			private int AddOrGetEdge(int vert1, int vert2, int face, ushort submesh, ref UnsafeList<MyEdge> edges)
			{
				for (int i = 0; i < edges.Length; i++)
				{
					if (edges[i].Submesh == submesh && ((edges[i].Vertex1 == vert1 && edges[i].Vertex2 == vert2) || (edges[i].Vertex1 == vert2 && edges[i].Vertex2 == vert1)))
					{
						MyEdge value = edges[i];
						value.AddFace(face);
						edges[i] = value;
						return i;
					}
				}
				MyEdge value2 = new MyEdge
				{
					Face1 = face,
					Face2 = -1,
					Vertex1 = vert1,
					Vertex2 = vert2,
					Visibile = true,
					Submesh = submesh
				};
				int length = edges.Length;
				edges.Add(in value2);
				return length;
			}

			private unsafe void CullEdge(int i, ref UnsafeList<MyFace> faces, ref UnsafeList<MyEdge> edges)
			{
				MyEdge myEdge = edges[i];
				MyFace* ptr = faces.Ptr;
				if (myEdge.Face1 != -1)
				{
					int num = Remove(ref ptr[myEdge.Face1].Edges, i);
					UnsafeList<int> edges2 = faces[myEdge.Face1].Edges;
					if (edges2.Length == 0)
					{
						ptr[myEdge.Face1].Visible = false;
					}
					else if (edges2.Length == 2 && num == 1)
					{
						int value = edges2[0];
						edges2[0] = edges2[1];
						edges2[1] = value;
					}
				}
				if (myEdge.Face2 != -1)
				{
					int num2 = Remove(ref ptr[myEdge.Face2].Edges, i);
					UnsafeList<int> edges3 = faces[myEdge.Face2].Edges;
					if (edges3.Length == 0)
					{
						ptr[myEdge.Face2].Visible = false;
					}
					else if (edges3.Length == 2 && num2 == 1)
					{
						int value2 = edges3[0];
						edges3[0] = edges3[1];
						edges3[1] = value2;
					}
				}
			}

			private unsafe bool GetOpenPolyline(MyFace face, out int start, out int final, out int intervening, ref UnsafeList<MyVert> verts, ref UnsafeList<MyEdge> edges)
			{
				MyVert* ptr = verts.Ptr;
				for (int i = 0; i < face.Edges.Length; i++)
				{
					MyEdge myEdge = edges[face.Edges[i]];
					ptr[myEdge.Vertex1].Occurs++;
					ptr[myEdge.Vertex2].Occurs++;
				}
				start = -1;
				final = -1;
				int num = -1;
				int num2 = -1;
				for (int j = 0; j < face.Edges.Length; j++)
				{
					MyEdge myEdge2 = edges[face.Edges[j]];
					if (verts[myEdge2.Vertex1].Occurs == 1)
					{
						if (start == -1)
						{
							start = myEdge2.Vertex1;
							num2 = j;
						}
						else if (final == -1)
						{
							final = myEdge2.Vertex1;
							num = j;
						}
					}
					if (verts[myEdge2.Vertex2].Occurs == 1)
					{
						if (start == -1)
						{
							start = myEdge2.Vertex2;
							num2 = j;
						}
						else if (final == -1)
						{
							final = myEdge2.Vertex2;
							num = j;
						}
					}
				}
				intervening = num - num2;
				return start != -1;
			}

			private int GetSharedVertex(MyEdge e0, MyEdge e1)
			{
				if (e0.Vertex1 == e1.Vertex1 || e0.Vertex1 == e1.Vertex2)
				{
					return e0.Vertex1;
				}
				if (e0.Vertex2 == e1.Vertex1 || e0.Vertex2 == e1.Vertex2)
				{
					return e0.Vertex2;
				}
				return -1;
			}

			private unsafe float2* GetUV0(Vertex* vertex)
			{
				return (float2*)((byte*)vertex + Uv0Offset);
			}

			private unsafe float3* GetUV1(Vertex* vertex)
			{
				return (float3*)((byte*)vertex + Uv1Offset);
			}

			private unsafe Vertex* GetVertex(int n, ref NativeArray<int> array)
			{
				return (Vertex*)array.Slice(n * VertexSize >> 2, VertexSize >> 2).GetUnsafePtr();
			}

			private float3 PlaneToPoint(float2 planePoint)
			{
				return CutPlane.PlaneX * planePoint.x + CutPlane.PlaneY * planePoint.y + CutPlane.Point;
			}

			private float2 PointToPlane(float3 point)
			{
				point -= CutPlane.Point;
				return math.float2(math.dot(point, CutPlane.PlaneX), math.dot(point, CutPlane.PlaneY));
			}

			private static byte InsideTriangle(float2 a, float2 b, float2 c, float2 p)
			{
				if (!(math.determinant(math.float2x2(c - b, p - b)) > 0f) || !(math.determinant(math.float2x2(b - a, p - a)) > 0f) || !(math.determinant(math.float2x2(a - c, p - c)) > 0f))
				{
					return 0;
				}
				return 1;
			}

			private static byte Snip(int u, int v, int w, int n, ref UnsafeList<PlanePoint> points, ref NativeArray<int> V)
			{
				float2 planePos = points[V[u]].PlanePos;
				float2 planePos2 = points[V[v]].PlanePos;
				float2 planePos3 = points[V[w]].PlanePos;
				if (1.1920929E-07f > (planePos2.x - planePos.x) * (planePos3.y - planePos.y) - (planePos2.y - planePos.y) * (planePos3.x - planePos.x))
				{
					return 0;
				}
				for (int i = 0; i < n; i++)
				{
					if (i != u && i != v && i != w)
					{
						float2 planePos4 = points[V[i]].PlanePos;
						if (InsideTriangle(planePos, planePos2, planePos3, planePos4) != 0)
						{
							return 0;
						}
					}
				}
				return 1;
			}

			private static string DebugPoints(UnsafeList<PlanePoint> points)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < points.Length; i++)
				{
					PlanePoint planePoint = points[i];
					stringBuilder.AppendLine($"{planePoint.PlanePos.x}, {planePoint.PlanePos.y}");
				}
				return stringBuilder.ToString();
			}

			private static int Triangulate(int indexOffset, float area, byte reversed, ref UnsafeList<PlanePoint> points, ref NativeArray<Triangle> triangles, ref NativeArray<int> V)
			{
				int length = points.Length;
				int num = 0;
				if (area > 0f)
				{
					for (int i = 0; i < length; i++)
					{
						V[i] = i;
					}
				}
				else
				{
					for (int j = 0; j < length; j++)
					{
						V[j] = length - 1 - j;
					}
				}
				int num2 = length;
				int num3 = 2 * num2;
				byte b = 1;
				int num4 = num2 - 1;
				while (num2 > 2)
				{
					if (num3-- <= 0)
					{
						b = 0;
						break;
					}
					int num5 = num4;
					if (num2 <= num5)
					{
						num5 = 0;
					}
					num4 = num5 + 1;
					if (num2 <= num4)
					{
						num4 = 0;
					}
					int num6 = num4 + 1;
					if (num2 <= num6)
					{
						num6 = 0;
					}
					if (Snip(num5, num4, num6, num2, ref points, ref V) != 0)
					{
						if (reversed == 0)
						{
							triangles[num] = new Triangle
							{
								A = (ushort)(V[num5] + indexOffset),
								B = (ushort)(V[num4] + indexOffset),
								C = (ushort)(V[num6] + indexOffset)
							};
						}
						else
						{
							triangles[num] = new Triangle
							{
								C = (ushort)(V[num5] + indexOffset),
								B = (ushort)(V[num4] + indexOffset),
								A = (ushort)(V[num6] + indexOffset)
							};
						}
						num++;
						int num7 = num4;
						for (int k = num4 + 1; k < num2; k++)
						{
							V[num7] = V[k];
							num7++;
						}
						num2--;
						num3 = 2 * num2;
					}
				}
				if (b == 1)
				{
					for (int l = 0; l < triangles.Length; l++)
					{
						Triangle triangle = triangles[l];
						triangles[l] = new Triangle
						{
							A = triangle.C,
							B = triangle.B,
							C = triangle.A
						};
					}
				}
				return num;
			}
		}

		private struct Plane
		{
			public float3 Normal;

			public float3 PlaneX;

			public float3 PlaneY;

			public float3 Point;
		}

		private struct Triangle
		{
			public ushort A;

			public ushort B;

			public ushort C;

			public void Reverse()
			{
				ushort a = A;
				A = C;
				C = a;
			}
		}

		public const Allocator DefaultAllocator = Allocator.Temp;

		public static bool DidApply(SliceResult result)
		{
			switch (result)
			{
			case SliceResult.Success:
			case SliceResult.PlaneFillError:
				return true;
			default:
				return false;
			}
		}

		public static bool IsCritical(SliceResult result)
		{
			switch (result)
			{
			case SliceResult.Success:
			case SliceResult.PlaneFillError:
			case SliceResult.AllShown:
			case SliceResult.AllHidden:
				return false;
			default:
				return true;
			}
		}

		public static SliceResult Slice(Mesh mesh, Vector3 position, Vector3 normal, int planeFaceSubmesh = 0, Vector2? planeFaceUv0 = null, Vector3? planeFaceUv1 = null, Mesh applyTo = null)
		{
			if (applyTo == null)
			{
				applyTo = mesh;
			}
			try
			{
				int uv;
				int uv2;
				int num = CheckMeshFormat(mesh, out uv, out uv2);
				if (num == 0)
				{
					return SliceResult.MeshFormatError;
				}
				if (!planeFaceUv0.HasValue)
				{
					uv = -1;
				}
				if (!planeFaceUv1.HasValue)
				{
					uv2 = -1;
				}
				Vector3 tangent = default(Vector3);
				Vector3 binormal = default(Vector3);
				Vector3.OrthoNormalize(ref normal, ref tangent, ref binormal);
				bool flag = Vector3.Dot(Vector3.Cross(tangent, binormal), normal) < 0f;
				Mesh.MeshDataArray writableMeshData = GetWritableMeshData(mesh);
				NativeArray<Triangle> indexData = writableMeshData[0].GetIndexData<Triangle>();
				using NativeArray<ushort> nativeArray = new NativeArray<ushort>(indexData.Length, Allocator.TempJob);
				new GetSubmeshIndices
				{
					Mesh = writableMeshData,
					Output = nativeArray
				}.Run();
				CutJob jobData = new CutJob
				{
					CutPlane = new Plane
					{
						Point = position,
						Normal = normal,
						PlaneX = tangent,
						PlaneY = binormal
					},
					VertexBuffer = writableMeshData[0].GetVertexData<int>(),
					IndexBuffer = indexData,
					InitialVertices = writableMeshData[0].vertexCount,
					SubmeshCount = writableMeshData[0].subMeshCount,
					SubmeshIndices = nativeArray,
					VertexSize = num,
					OutputTriangles = new NativeArray<Triangle>(writableMeshData[0].GetIndexData<Triangle>().Length * 2, Allocator.TempJob),
					OutputVertices = new NativeArray<int>(mesh.vertexCount * num >> 1, Allocator.TempJob),
					OutputCounts = new NativeArray<int>(1 + mesh.subMeshCount, Allocator.TempJob),
					ReversePlaneFaces = (byte)(flag ? 1 : 0),
					PlaneSubmesh = planeFaceSubmesh,
					PlaneFaceUv0 = planeFaceUv0.GetValueOrDefault(),
					PlaneFaceUv1 = planeFaceUv1.GetValueOrDefault(),
					Uv0Offset = uv,
					Uv1Offset = uv2,
					Result = new NativeArray<SliceResult>(1, Allocator.TempJob)
				};
				SliceResult sliceResult = SliceResult.GenericSliceError;
				try
				{
					jobData.Run();
					sliceResult = jobData.Result[0];
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					return SliceResult.GenericSliceError;
				}
				bool flag2 = false;
				try
				{
					if (jobData.OutputCounts[0] > 0 && DidApply(sliceResult))
					{
						writableMeshData[0].SetVertexBufferParams(jobData.OutputCounts[0], mesh.GetVertexAttributes());
						NativeArray<int> vertexData = writableMeshData[0].GetVertexData<int>();
						NativeArray<int>.Copy(jobData.OutputVertices, vertexData, vertexData.Length);
						int num2 = 0;
						for (int i = 0; i < writableMeshData[0].subMeshCount; i++)
						{
							num2 += 3 * jobData.OutputCounts[i + 1];
						}
						writableMeshData[0].SetIndexBufferParams(num2, IndexFormat.UInt16);
						int num3 = 0;
						for (int j = 0; j < writableMeshData[0].subMeshCount; j++)
						{
							SubMeshDescriptor desc = new SubMeshDescriptor
							{
								baseVertex = 0,
								vertexCount = jobData.OutputCounts[0],
								firstVertex = 0,
								bounds = mesh.bounds,
								indexCount = jobData.OutputCounts[1 + j] * 3,
								indexStart = num3 * 3,
								topology = MeshTopology.Triangles
							};
							writableMeshData[0].SetSubMesh(j, desc, MeshUpdateFlags.DontValidateIndices | MeshUpdateFlags.DontResetBoneBounds | MeshUpdateFlags.DontNotifyMeshUsers | MeshUpdateFlags.DontRecalculateBounds);
							num3 += jobData.OutputCounts[1 + j];
						}
						NativeArray<Triangle> indexData2 = writableMeshData[0].GetIndexData<Triangle>();
						NativeArray<Triangle>.Copy(jobData.OutputTriangles, indexData2, indexData2.Length);
						Mesh.ApplyAndDisposeWritableMeshData(writableMeshData, applyTo);
						flag2 = true;
					}
					else if (DidApply(sliceResult))
					{
						sliceResult = SliceResult.GenericSliceError;
					}
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					sliceResult = SliceResult.MeshApplyError;
				}
				finally
				{
					if (!flag2)
					{
						writableMeshData.Dispose();
						flag2 = true;
					}
				}
				if (jobData.OutputVertices.IsCreated)
				{
					jobData.OutputVertices.Dispose();
				}
				if (jobData.OutputTriangles.IsCreated)
				{
					jobData.OutputTriangles.Dispose();
				}
				if (jobData.OutputCounts.IsCreated)
				{
					jobData.OutputCounts.Dispose();
				}
				if (jobData.Result.IsCreated)
				{
					jobData.Result.Dispose();
				}
				if (IsCritical(sliceResult))
				{
					Debug.Log($"Mesh Fill Failed for fuselage part #{planeFaceUv1?.z}: {sliceResult}");
				}
				return sliceResult;
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return SliceResult.MeshApplyError;
			}
		}

		public unsafe static async UniTask<SliceResult> Slice(NativeArray<float3> vertices, NativeArray<int3> triangles, Vector3 position, Vector3 normal, bool async, NativeList<float3> outVertices, NativeList<int3> outTriangles, bool append = true, int partId = 0)
		{
			try
			{
				Vector3 tangent = default(Vector3);
				Vector3 binormal = default(Vector3);
				Vector3.OrthoNormalize(ref normal, ref tangent, ref binormal);
				bool flag = Vector3.Dot(Vector3.Cross(tangent, binormal), normal) < 0f;
				using NativeArray<Triangle> inputTris = new NativeArray<Triangle>(triangles.Length, Allocator.TempJob);
				IJobForExtensions.Run(new ConvertIndexBuffer
				{
					Input = triangles.Reinterpret<int>(12),
					Output = inputTris.Reinterpret<ushort>(6)
				}, inputTris.Length * 3);
				using NativeArray<ushort> submeshIds = new NativeArray<ushort>(inputTris.Length, Allocator.TempJob);
				using NativeArray<Vertex> inVerts = new NativeArray<Vertex>(vertices.Length, Allocator.TempJob);
				inVerts.Slice().SliceWithStride<float3>(0).CopyFrom(vertices);
				int num = sizeof(Vertex);
				CutJob job = new CutJob
				{
					CutPlane = new Plane
					{
						Point = position,
						Normal = normal,
						PlaneX = tangent,
						PlaneY = binormal
					},
					VertexBuffer = inVerts.Reinterpret<int>(num),
					IndexBuffer = inputTris,
					InitialVertices = vertices.Length,
					SubmeshCount = 1,
					SubmeshIndices = submeshIds,
					VertexSize = num,
					OutputTriangles = new NativeArray<Triangle>(triangles.Length * 4, Allocator.TempJob),
					OutputVertices = new NativeArray<int>(vertices.Length * num, Allocator.TempJob),
					OutputCounts = new NativeArray<int>(2, Allocator.TempJob),
					ReversePlaneFaces = (byte)(flag ? 1 : 0),
					PlaneSubmesh = 0,
					PlaneFaceUv0 = default(float2),
					PlaneFaceUv1 = default(float3),
					Uv0Offset = -1,
					Uv1Offset = -1,
					Result = new NativeArray<SliceResult>(1, Allocator.TempJob)
				};
				SliceResult sliceResult;
				try
				{
					if (async)
					{
						await job.Schedule().ToUniTask(PlayerLoopTiming.Update);
					}
					else
					{
						job.Run();
					}
					sliceResult = job.Result[0];
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					return SliceResult.GenericSliceError;
				}
				if (job.OutputCounts[0] > 0 && DidApply(sliceResult))
				{
					NativeSlice<float3> nativeSlice = job.OutputVertices.Reinterpret<float3x2>(4).Slice(0, job.OutputCounts[0]).SliceWithStride<float3>(0);
					if (append)
					{
						int length = outVertices.Length;
						outVertices.Length = length + nativeSlice.Length;
						nativeSlice.CopyTo(outVertices.AsArray().GetSubArray(length, nativeSlice.Length));
					}
					else
					{
						outVertices.Clear();
						outVertices.Length = nativeSlice.Length;
						nativeSlice.CopyTo(outVertices.AsArray());
						outTriangles.Clear();
					}
					new ConvertMeshOutSimple
					{
						OutputCounts = job.OutputCounts,
						Triangles = job.OutputTriangles,
						OutTriangles = outTriangles
					}.Run();
				}
				else if (DidApply(sliceResult))
				{
					sliceResult = SliceResult.GenericSliceError;
				}
				if (job.OutputVertices.IsCreated)
				{
					job.OutputVertices.Dispose();
				}
				if (job.OutputTriangles.IsCreated)
				{
					job.OutputTriangles.Dispose();
				}
				if (job.OutputCounts.IsCreated)
				{
					job.OutputCounts.Dispose();
				}
				if (job.Result.IsCreated)
				{
					job.Result.Dispose();
				}
				if (IsCritical(sliceResult))
				{
					Debug.Log($"Mesh Fill Failed for fuselage part #{partId}: {sliceResult}");
				}
				return sliceResult;
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				return SliceResult.MeshApplyError;
			}
		}

		private static int CheckMeshFormat(VertexAttributeDescriptor[] attrs, out int uv0, out int uv1)
		{
			uv0 = -1;
			uv1 = -1;
			if (attrs.Length >= 2 && attrs[0].attribute == VertexAttribute.Position && attrs[0].dimension == 3 && attrs[0].format == VertexAttributeFormat.Float32 && attrs[0].stream == 0 && attrs[1].attribute == VertexAttribute.Normal && attrs[1].dimension == 3 && attrs[1].format == VertexAttributeFormat.Float32 && attrs[1].stream == 0)
			{
				int num = 24;
				for (int i = 2; i < attrs.Length; i++)
				{
					int num2;
					switch (attrs[i].format)
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
						Debug.LogError($"Unknown VertexAttributeFormat: {attrs[i].format}");
						return 0;
					}
					if (attrs[i].stream == 0 && attrs[i].attribute == VertexAttribute.TexCoord0 && attrs[i].dimension == 2 && attrs[i].format == VertexAttributeFormat.Float32)
					{
						uv0 = num;
					}
					else if (attrs[i].stream == 0 && attrs[i].attribute == VertexAttribute.TexCoord1 && attrs[i].dimension == 3 && attrs[i].format == VertexAttributeFormat.Float32)
					{
						uv1 = num;
					}
					num += num2 * attrs[i].dimension;
				}
				return num;
			}
			Debug.LogError("Mesh format does not fit target");
			return 0;
		}

		private static int CheckMeshFormat(Mesh mesh, out int uv0, out int uv1)
		{
			uv0 = -1;
			uv1 = -1;
			if (mesh.indexFormat != IndexFormat.UInt16)
			{
				Debug.LogError($"Index format {mesh.indexFormat} not supported");
				return 0;
			}
			return CheckMeshFormat(mesh.GetVertexAttributes(), out uv0, out uv1);
		}

		private static void DebugExport(Mesh mesh)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo("C:\\Users\\nicky.SYSTEM64.000\\Jundroo\\Temp\\");
			string path = $"Aexport-{directoryInfo.GetFiles().Length}.obj";
			using StreamWriter streamWriter = new StreamWriter(Path.Combine(directoryInfo.FullName, path));
			streamWriter.WriteLine("#debug exported mesh");
			Vector3[] vertices = mesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector = vertices[i];
				streamWriter.WriteLine($"v {vector.x:G9} {vector.y:G9} {vector.z:G9}");
			}
			int[] triangles = mesh.triangles;
			for (int j = 0; j < triangles.Length; j += 3)
			{
				streamWriter.WriteLine($"f {triangles[j] + 1} {triangles[j + 1] + 1} {triangles[j + 2] + 1}");
			}
		}

		private static Mesh.MeshDataArray GetWritableMeshData(Mesh mesh)
		{
			using Mesh.MeshDataArray meshDataArray = Mesh.AcquireReadOnlyMeshData(mesh);
			Mesh.MeshData meshData = meshDataArray[0];
			Mesh.MeshDataArray result = Mesh.AllocateWritableMeshData(1);
			try
			{
				Mesh.MeshData meshData2 = result[0];
				meshData2.subMeshCount = meshData.subMeshCount;
				meshData2.SetVertexBufferParams(mesh.vertexCount, mesh.GetVertexAttributes());
				uint num = 0u;
				for (int i = 0; i < mesh.subMeshCount; i++)
				{
					num += mesh.GetIndexCount(i);
				}
				meshData2.SetIndexBufferParams((int)num, mesh.indexFormat);
				NativeArray<int> vertexData = meshData.GetVertexData<int>();
				NativeArray<int> vertexData2 = meshData2.GetVertexData<int>();
				NativeArray<int>.Copy(vertexData, vertexData2);
				NativeArray<byte> indexData = meshData.GetIndexData<byte>();
				NativeArray<byte> indexData2 = meshData2.GetIndexData<byte>();
				NativeArray<byte>.Copy(indexData, indexData2);
				for (int j = 0; j < meshData.subMeshCount; j++)
				{
					meshData2.SetSubMesh(j, meshData.GetSubMesh(j));
				}
				return result;
			}
			catch
			{
				result.Dispose();
				throw;
			}
		}
	}
}
