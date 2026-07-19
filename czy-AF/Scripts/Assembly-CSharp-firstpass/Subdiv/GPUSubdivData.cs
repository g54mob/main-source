using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Subdiv
{
	public class GPUSubdivData : IDisposable
	{
		private ComputeBuffer vertBuffer;

		private ComputeBuffer edgeBuffer;

		private ComputeBuffer triBuffer;

		private ComputeBuffer subdivBuffer;

		private int[] triangles;

		private List<Edge_t> edges;

		public ComputeBuffer VertexBuffer => vertBuffer;

		public ComputeBuffer EdgeBuffer => edgeBuffer;

		public ComputeBuffer TriangleBuffer => triBuffer;

		public ComputeBuffer SubdivBuffer => subdivBuffer;

		public List<Edge_t> Edges => edges;

		public int[] Triangles => triangles;

		public GPUSubdivData()
		{
		}

		public GPUSubdivData(ComputeBuffer vbuf, ComputeBuffer ebuf, ComputeBuffer tbuf, int[] tri, List<Edge_t> e)
		{
			vertBuffer = vbuf;
			edgeBuffer = ebuf;
			triBuffer = tbuf;
			triangles = tri;
			edges = e;
			subdivBuffer = new ComputeBuffer(vertBuffer.count + edgeBuffer.count, Marshal.SizeOf(typeof(Vector3)));
		}

		public GPUSubdivData(Mesh source)
		{
			vertBuffer = new ComputeBuffer(source.vertexCount, Marshal.SizeOf(typeof(Vector3)));
			vertBuffer.SetData(source.vertices);
			triangles = source.triangles;
			triBuffer = new ComputeBuffer(triangles.Length / 3, Marshal.SizeOf(typeof(Triangle_t)));
			Triangle_t[] array = new Triangle_t[triBuffer.count];
			edges = new List<Edge_t>();
			int i = 0;
			for (int num = triangles.Length; i < num; i += 3)
			{
				int num2 = triangles[i];
				int num3 = triangles[i + 1];
				int num4 = triangles[i + 2];
				Edge_t item = new Edge_t
				{
					v0 = num2,
					v1 = num3
				};
				Edge_t item2 = new Edge_t
				{
					v0 = num3,
					v1 = num4
				};
				Edge_t item3 = new Edge_t
				{
					v0 = num4,
					v1 = num2
				};
				int e;
				if (edges.Contains(item))
				{
					e = edges.IndexOf(item);
				}
				else
				{
					edges.Add(item);
					e = edges.Count - 1;
				}
				int e2;
				if (edges.Contains(item2))
				{
					e2 = edges.IndexOf(item2);
				}
				else
				{
					edges.Add(item2);
					e2 = edges.Count - 1;
				}
				int e3;
				if (edges.Contains(item3))
				{
					e3 = edges.IndexOf(item3);
				}
				else
				{
					edges.Add(item3);
					e3 = edges.Count - 1;
				}
				array[i / 3] = new Triangle_t
				{
					v0 = num2,
					v1 = num3,
					v2 = num4,
					e0 = e,
					e1 = e2,
					e2 = e3
				};
			}
			edgeBuffer = new ComputeBuffer(edges.Count, Marshal.SizeOf(typeof(Edge_t)));
			edgeBuffer.SetData(edges.ToArray());
			triBuffer.SetData(array);
			subdivBuffer = new ComputeBuffer(vertBuffer.count + edgeBuffer.count, Marshal.SizeOf(typeof(Vector3)));
		}

		private Triangle_t AddTriangle(List<Edge_t> newEdges, int iv0, int iv1, int iv2)
		{
			Edge_t item = new Edge_t
			{
				v0 = iv0,
				v1 = iv1
			};
			Edge_t item2 = new Edge_t
			{
				v0 = iv1,
				v1 = iv2
			};
			Edge_t item3 = new Edge_t
			{
				v0 = iv2,
				v1 = iv0
			};
			int e;
			if (newEdges.Contains(item))
			{
				e = newEdges.IndexOf(item);
			}
			else
			{
				newEdges.Add(item);
				e = newEdges.Count - 1;
			}
			int e2;
			if (newEdges.Contains(item2))
			{
				e2 = newEdges.IndexOf(item2);
			}
			else
			{
				newEdges.Add(item2);
				e2 = newEdges.Count - 1;
			}
			int e3;
			if (newEdges.Contains(item3))
			{
				e3 = newEdges.IndexOf(item3);
			}
			else
			{
				newEdges.Add(item3);
				e3 = newEdges.Count - 1;
			}
			return new Triangle_t
			{
				v0 = iv0,
				v1 = iv1,
				v2 = iv2,
				e0 = e,
				e1 = e2,
				e2 = e3
			};
		}

		public GPUSubdivData Next()
		{
			int[] array = new int[triangles.Length * 4];
			Triangle_t[] array2 = new Triangle_t[triBuffer.count * 4];
			List<Edge_t> list = new List<Edge_t>();
			int count = VertexBuffer.count;
			int i = 0;
			for (int num = triangles.Length; i < num; i += 3)
			{
				int num2 = triangles[i];
				int num3 = triangles[i + 1];
				int num4 = triangles[i + 2];
				Edge_t item = new Edge_t
				{
					v0 = num2,
					v1 = num3
				};
				Edge_t item2 = new Edge_t
				{
					v0 = num3,
					v1 = num4
				};
				Edge_t item3 = new Edge_t
				{
					v0 = num4,
					v1 = num2
				};
				int num5 = edges.IndexOf(item) + count;
				int num6 = edges.IndexOf(item2) + count;
				int num7 = edges.IndexOf(item3) + count;
				int num8 = i * 4;
				int num9 = num8 + 1;
				int num10 = num9 + 1;
				int num11 = num8 + 3;
				int num12 = num11 + 1;
				int num13 = num12 + 1;
				int num14 = num11 + 3;
				int num15 = num14 + 1;
				int num16 = num15 + 1;
				int num17 = num14 + 3;
				int num18 = num17 + 1;
				int num19 = num18 + 1;
				array[num8] = num2;
				array[num9] = num5;
				array[num10] = num7;
				array[num11] = num5;
				array[num12] = num3;
				array[num13] = num6;
				array[num14] = num5;
				array[num15] = num6;
				array[num16] = num7;
				array[num17] = num7;
				array[num18] = num6;
				array[num19] = num4;
				int num20 = i / 3 * 4;
				array2[num20] = AddTriangle(list, array[num8], array[num9], array[num10]);
				array2[num20 + 1] = AddTriangle(list, array[num11], array[num12], array[num13]);
				array2[num20 + 2] = AddTriangle(list, array[num14], array[num15], array[num16]);
				array2[num20 + 3] = AddTriangle(list, array[num17], array[num18], array[num19]);
			}
			ComputeBuffer computeBuffer = new ComputeBuffer(list.Count, Marshal.SizeOf(typeof(Edge_t)));
			computeBuffer.SetData(list.ToArray());
			ComputeBuffer computeBuffer2 = new ComputeBuffer(array2.Length, Marshal.SizeOf(typeof(Triangle_t)));
			computeBuffer2.SetData(array2);
			GPUSubdivData result = new GPUSubdivData(subdivBuffer, computeBuffer, computeBuffer2, array, list);
			ReleaseBuffer(vertBuffer);
			vertBuffer = null;
			ReleaseBuffer(edgeBuffer);
			edgeBuffer = null;
			ReleaseBuffer(triBuffer);
			triBuffer = null;
			subdivBuffer = null;
			return result;
		}

		public Mesh Build(bool weld = false)
		{
			Mesh mesh = new Mesh();
			List<Edge_t> list = Edges;
			int[] array = Triangles;
			Vector3[] array2 = new Vector3[SubdivBuffer.count];
			SubdivBuffer.GetData(array2);
			int[] array3;
			if (weld)
			{
				mesh.vertices = array2;
				array3 = new int[array.Length * 4];
				int count = VertexBuffer.count;
				int i = 0;
				for (int num = array.Length; i < num; i += 3)
				{
					int num2 = array[i];
					int num3 = array[i + 1];
					int num4 = array[i + 2];
					Edge_t item = new Edge_t
					{
						v0 = num2,
						v1 = num3
					};
					Edge_t item2 = new Edge_t
					{
						v0 = num3,
						v1 = num4
					};
					Edge_t item3 = new Edge_t
					{
						v0 = num4,
						v1 = num2
					};
					int num5 = list.IndexOf(item) + count;
					int num6 = list.IndexOf(item2) + count;
					int num7 = list.IndexOf(item3) + count;
					int num8 = i * 4;
					int num9 = num8 + 3;
					int num10 = num9 + 3;
					int num11 = num10 + 3;
					array3[num8] = num2;
					array3[num8 + 1] = num5;
					array3[num8 + 2] = num7;
					array3[num9] = num5;
					array3[num9 + 1] = num3;
					array3[num9 + 2] = num6;
					array3[num10] = num5;
					array3[num10 + 1] = num6;
					array3[num10 + 2] = num7;
					array3[num11] = num7;
					array3[num11 + 1] = num6;
					array3[num11 + 2] = num4;
				}
			}
			else
			{
				array3 = new int[array.Length * 4];
				Vector3[] array4 = new Vector3[array3.Length];
				int count2 = VertexBuffer.count;
				int j = 0;
				for (int num12 = array.Length; j < num12; j += 3)
				{
					int num13 = array[j];
					int num14 = array[j + 1];
					int num15 = array[j + 2];
					Edge_t item4 = new Edge_t
					{
						v0 = num13,
						v1 = num14
					};
					Edge_t item5 = new Edge_t
					{
						v0 = num14,
						v1 = num15
					};
					Edge_t item6 = new Edge_t
					{
						v0 = num15,
						v1 = num13
					};
					int num16 = list.IndexOf(item4) + count2;
					int num17 = list.IndexOf(item5) + count2;
					int num18 = list.IndexOf(item6) + count2;
					int num19 = j * 4;
					int num20 = num19 + 3;
					int num21 = num20 + 3;
					int num22 = num21 + 3;
					array4[num19] = array2[num13];
					array4[num19 + 1] = array2[num16];
					array4[num19 + 2] = array2[num18];
					array4[num20] = array2[num16];
					array4[num20 + 1] = array2[num14];
					array4[num20 + 2] = array2[num17];
					array4[num21] = array2[num16];
					array4[num21 + 1] = array2[num17];
					array4[num21 + 2] = array2[num18];
					array4[num22] = array2[num18];
					array4[num22 + 1] = array2[num17];
					array4[num22 + 2] = array2[num15];
					array3[num19] = num19;
					array3[num19 + 1] = num19 + 1;
					array3[num19 + 2] = num19 + 2;
					array3[num20] = num20;
					array3[num20 + 1] = num20 + 1;
					array3[num20 + 2] = num20 + 2;
					array3[num21] = num21;
					array3[num21 + 1] = num21 + 1;
					array3[num21 + 2] = num21 + 2;
					array3[num22] = num22;
					array3[num22 + 1] = num22 + 1;
					array3[num22 + 2] = num22 + 2;
				}
				mesh.vertices = array4;
			}
			mesh.indexFormat = ((mesh.vertexCount >= 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			mesh.triangles = array3;
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
			return mesh;
		}

		public void Dispose()
		{
			ReleaseBuffer(vertBuffer);
			ReleaseBuffer(edgeBuffer);
			ReleaseBuffer(triBuffer);
			ReleaseBuffer(subdivBuffer);
		}

		private void ReleaseBuffer(ComputeBuffer buf)
		{
			buf?.Release();
		}
	}
}
