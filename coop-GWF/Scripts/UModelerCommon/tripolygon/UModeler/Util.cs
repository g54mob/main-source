using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class Util
	{
		public enum EClippingVertexType
		{
			FromBelowToAbove = 0,
			Above = 1,
			FromAboveToBelow = 2,
			Below = 3,
			Border = 4
		}

		public struct ClippingVertex
		{
			public Vertex vtx;

			public EClippingVertexType type;

			public bool zeroDistAndNoCreated;

			public ClippingVertex(Vertex _vtx, EClippingVertexType _type, bool _zero_dist_no_created = false)
			{
				vtx = _vtx;
				type = _type;
				zeroDistAndNoCreated = _zero_dist_no_created;
			}
		}

		private static float defaultOutlineOffset_ = 0.0004f;

		public static bool IsNullPolygon(SimplePolygon polygon)
		{
			return polygon == null;
		}

		public static bool IsOpenPolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				IndexPair edge = polygon.GetEdge(i);
				if (polygon.FindPrevEdges(edge) == null || polygon.FindNextEdges(edge) == null)
				{
					return true;
				}
			}
			return false;
		}

		public static SimplePolygon FindPolygonInEdMesh(ulong polygonID, int shelf = -1, EditableMesh edMesh = null)
		{
			if (edMesh == null)
			{
				edMesh = UMContext.activeModeler.editableMesh;
			}
			using (new ShelfHolder(edMesh))
			{
				for (int i = 0; i < 2; i++)
				{
					if (shelf == -1 || shelf == i)
					{
						edMesh.shelf = i;
						SimplePolygon simplePolygon = edMesh.FindPolygon(polygonID);
						if (simplePolygon != null)
						{
							return simplePolygon;
						}
					}
				}
			}
			return null;
		}

		public static PlaneEx FindBestPlane(EditableMesh editableMesh, Vector3 p0, Vector3 p1, PlaneEx plane0, PlaneEx plane1, SimplePolygon polygon0, SimplePolygon polygon1)
		{
			if (plane0 != null && plane1 == null)
			{
				return plane0;
			}
			if (plane0 == null && plane1 != null)
			{
				return plane1;
			}
			if (plane0 == null && plane1 == null)
			{
				return null;
			}
			if (plane0.IsEquivalent(plane1))
			{
				return plane0;
			}
			if (Mathf.Abs(plane0.CalcDistanceToPoint(p0)) < 0.0001f && Mathf.Abs(plane0.CalcDistanceToPoint(p1)) < 0.0001f && polygon0 != null && polygon0.IsPosInside(p0, checkOnEdge: true) && polygon0.IsPosInside(p1, checkOnEdge: true))
			{
				return plane0;
			}
			if (Mathf.Abs(plane1.CalcDistanceToPoint(p0)) < 0.0001f && Mathf.Abs(plane1.CalcDistanceToPoint(p1)) < 0.0001f && polygon1 != null && polygon1.IsPosInside(p0, checkOnEdge: true) && polygon1.IsPosInside(p1, checkOnEdge: true))
			{
				return plane1;
			}
			return FindBestPlane(editableMesh, p0, p1);
		}

		public static PlaneEx FindBestPlane(EditableMesh editableMesh, Vector3 p0, Vector3 p1)
		{
			PlaneEx result = null;
			Vector3 pos = (p0 + p1) * 0.5f;
			Edge edge = new Edge(p0, p1);
			Edge edge2 = edge.Clone().Invert();
			for (int i = 0; i < editableMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editableMesh.GetPolygon(i);
				if (Mathf.Abs(polygon.plane.CalcDistanceToPoint(p0)) < 0.0001f && Mathf.Abs(polygon.plane.CalcDistanceToPoint(p1)) < 0.0001f)
				{
					if (polygon.ContainsEdge(edge) || polygon.ContainsEdge(edge2) || polygon.bsptree.IsInside(pos))
					{
						return polygon.plane;
					}
					result = polygon.plane;
				}
			}
			return result;
		}

		public static SimplePolygon FindBestPolygon(EditableMesh editableMesh, Vector3 p0, Vector3 p1)
		{
			for (int i = 0; i < editableMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editableMesh.GetPolygon(i);
				bool flag = false;
				bool flag2 = false;
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					Edge pureEdge = polygon.GetPureEdge(j);
					if (pureEdge.FindClosestPos(p0, out var closest_pos, out var between_edge) && between_edge && Vector3.Distance(closest_pos, p0) < 0.0001f)
					{
						flag = true;
					}
					if (pureEdge.FindClosestPos(p1, out var closest_pos2, out var between_edge2) && between_edge2 && Vector3.Distance(closest_pos2, p1) < 0.0001f)
					{
						flag2 = true;
					}
				}
				if (flag && flag2)
				{
					return polygon;
				}
			}
			return null;
		}

		public static List<Vertex> FromClippingVerticesToVertices(List<ClippingVertex> clippingVertices)
		{
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < clippingVertices.Count; i++)
			{
				list.Add(clippingVertices[i].vtx);
			}
			return list;
		}

		public static void ClipByPlane(List<Vertex> vertices, PlaneEx plane, out List<ClippingVertex> above, out List<ClippingVertex> below)
		{
			above = new List<ClippingVertex>();
			below = new List<ClippingVertex>();
			int[] array = new int[vertices.Count];
			for (int i = 0; i < vertices.Count; i++)
			{
				float num = plane.CalcDistanceToPoint(vertices[i].pos);
				if (num > 0.0001f)
				{
					array[i] = 1;
				}
				else if (num < -0.0001f)
				{
					array[i] = -1;
				}
				else
				{
					array[i] = 0;
				}
			}
			for (int j = 0; j < vertices.Count; j++)
			{
				int num2 = (j + 1) % vertices.Count;
				int num3 = (num2 + 1) % vertices.Count;
				int num4 = (j - 1 + vertices.Count) % vertices.Count;
				int num5 = (num4 - 1 + vertices.Count) % vertices.Count;
				if (array[j] == 1)
				{
					above.Add(new ClippingVertex(vertices[j], EClippingVertexType.Above));
				}
				else if (array[j] == -1)
				{
					below.Add(new ClippingVertex(vertices[j], EClippingVertexType.Below));
				}
				else if (array[num4] == 1)
				{
					if (array[num2] == -1 || array[num3] == -1)
					{
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromAboveToBelow, _zero_dist_no_created: true));
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromAboveToBelow, _zero_dist_no_created: true));
					}
					else
					{
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.Border, _zero_dist_no_created: true));
					}
				}
				else if (array[num4] == -1)
				{
					if (array[num2] == 1 || array[num3] == 1)
					{
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromBelowToAbove, _zero_dist_no_created: true));
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromBelowToAbove, _zero_dist_no_created: true));
					}
					else
					{
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.Border, _zero_dist_no_created: true));
					}
				}
				else if (array[num2] == 1)
				{
					if (array[num5] == -1)
					{
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromBelowToAbove, _zero_dist_no_created: true));
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromBelowToAbove, _zero_dist_no_created: true));
					}
					else
					{
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.Border, _zero_dist_no_created: true));
					}
				}
				else if (array[num2] == -1)
				{
					if (array[num5] == 1)
					{
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromAboveToBelow, _zero_dist_no_created: true));
						above.Add(new ClippingVertex(vertices[j], EClippingVertexType.FromAboveToBelow, _zero_dist_no_created: true));
					}
					else
					{
						below.Add(new ClippingVertex(vertices[j], EClippingVertexType.Border, _zero_dist_no_created: true));
					}
				}
				if (array[j] * array[num2] == -1)
				{
					float t = 0f;
					Vector3 vector = vertices[num2].pos - vertices[j].pos;
					Vector2 vector2 = vertices[num2].uv - vertices[j].uv;
					Color color = vertices[num2].color - vertices[j].color;
					plane.RayHit(vertices[j].pos, vector, out t);
					Vector3 pos = vertices[j].pos + vector * t;
					Vector2 uv = vertices[j].uv + vector2 * t;
					Color color2 = vertices[j].color + color * t;
					if (array[j] == -1)
					{
						above.Add(new ClippingVertex(new Vertex(pos, uv, color2), EClippingVertexType.FromBelowToAbove));
						below.Add(new ClippingVertex(new Vertex(pos, uv, color2), EClippingVertexType.FromBelowToAbove));
					}
					else
					{
						above.Add(new ClippingVertex(new Vertex(pos, uv, color2), EClippingVertexType.FromAboveToBelow));
						below.Add(new ClippingVertex(new Vertex(pos, uv, color2), EClippingVertexType.FromAboveToBelow));
					}
				}
			}
			if (above.Count == 0 || CountVertexOnPlane(above) == above.Count)
			{
				above = null;
			}
			if (below.Count == 0 || CountVertexOnPlane(below) == below.Count)
			{
				below = null;
			}
		}

		public static void ClipByPlane(Segment segment, PlaneEx plane, out EditableMesh above, out EditableMesh below, EPolygonFlag polygonFlags = (EPolygonFlag)0)
		{
			if (segment == null)
			{
				above = null;
				below = null;
				return;
			}
			above = new EditableMesh();
			below = new EditableMesh();
			List<ClippingVertex> above2 = null;
			List<ClippingVertex> below2 = null;
			ClipByPlane(segment.vertices, plane, out above2, out below2);
			PlaneEx planeEx = MathUtil.ComputePlane(segment.vertices);
			if (above2 == null || below2 == null)
			{
				if (above2 != null)
				{
					SimplePolygon simplePolygon = new SimplePolygon(FromClippingVerticesToVertices(above2), planeEx, open: false, polygonFlags);
					if (simplePolygon.IsValid() && !simplePolygon.IsOpen())
					{
						above.AddPolygon(simplePolygon);
					}
					else
					{
						above = null;
					}
					below = null;
				}
				if (below2 != null)
				{
					SimplePolygon simplePolygon2 = new SimplePolygon(FromClippingVerticesToVertices(below2), planeEx, open: false, polygonFlags);
					if (simplePolygon2.IsValid() && !simplePolygon2.IsOpen())
					{
						below.AddPolygon(simplePolygon2);
					}
					else
					{
						below = null;
					}
					above = null;
				}
				return;
			}
			List<ClippingVertex>[] array = new List<ClippingVertex>[2] { above2, below2 };
			EClippingVertexType[] array2 = new EClippingVertexType[2]
			{
				EClippingVertexType.FromBelowToAbove,
				EClippingVertexType.FromAboveToBelow
			};
			List<SimplePolygon>[] array3 = new List<SimplePolygon>[2]
			{
				new List<SimplePolygon>(),
				new List<SimplePolygon>()
			};
			EditableMesh[] array4 = new EditableMesh[2] { above, below };
			for (int i = 0; i < array3.Length; i++)
			{
				int num = -1;
				for (int j = 0; j < array[i].Count; j++)
				{
					int num2 = (j + 1) % array[i].Count;
					if (plane.IsOnPlane(array[i][j].vtx.pos) && array[i][j].type == array2[i])
					{
						num = ((!plane.IsOnPlane(array[i][num2].vtx.pos) || array[i][num2].type != array2[i]) ? j : num2);
						break;
					}
				}
				if (num == -1)
				{
					num = 0;
				}
				List<Vertex> list = null;
				List<SimplePolygon> list2 = array3[i];
				int num3 = 0;
				int num4 = num;
				while (num3 < array[i].Count)
				{
					int index = num4 % array[i].Count;
					list?.Add(array[i][index].vtx);
					if (plane.IsOnPlane(array[i][index].vtx.pos))
					{
						if (list == null)
						{
							list = new List<Vertex>();
							list.Add(array[i][index].vtx);
						}
						else
						{
							list2.Add(new SimplePolygon(list, null, open: false, polygonFlags));
							list = null;
						}
					}
					num3++;
					num4++;
				}
				for (int k = 0; k < list2.Count; k++)
				{
					if (list2[k].plane != null && !list2[k].IsOpen() && planeEx.IsTowardSameDirection(list2[k].plane))
					{
						list2[k].plane = planeEx;
						array4[i].AddPolygon(list2[k]);
					}
				}
				for (int l = 0; l < list2.Count; l++)
				{
					if (list2[l].plane != null && !list2[l].IsOpen() && !planeEx.IsTowardSameDirection(list2[l].plane))
					{
						list2[l].Flip();
						list2[l].plane = planeEx;
						array4[i].AddSubtractedPolygon(list2[l]);
					}
				}
			}
		}

		public static int CountVertexOnPlane(List<ClippingVertex> vertices)
		{
			int num = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				if (vertices[i].zeroDistAndNoCreated)
				{
					num++;
				}
			}
			return num;
		}

		public static int CountVertexAbove(List<Vertex> vertices, PlaneEx plane)
		{
			int num = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				if (plane.CalcDistanceToPoint(vertices[i].pos) > 0.0001f)
				{
					num++;
				}
			}
			return num;
		}

		public static int CountVertexBelow(List<Vertex> vertices, PlaneEx plane)
		{
			int num = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				if (plane.CalcDistanceToPoint(vertices[i].pos) < -0.0001f)
				{
					num++;
				}
			}
			return num;
		}

		public static int CountVertexOnPlane(List<Vertex> vertices, PlaneEx plane)
		{
			int num = 0;
			for (int i = 0; i < vertices.Count; i++)
			{
				float num2 = plane.CalcDistanceToPoint(vertices[i].pos);
				if (num2 > 0.0001f && num2 < -0.0001f)
				{
					num++;
				}
			}
			return num;
		}

		public static void MatchHolesToOutsides(EditableMesh holeEdMesh, EditableMesh outsideModel, PlaneEx clipPlane)
		{
			for (int i = 0; i < holeEdMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = holeEdMesh.GetPolygon(i);
				List<Vertex> vertexList = polygon.GetVertexList();
				SimplePolygon simplePolygon = FindPolygonHavingVertex(outsideModel, vertexList);
				if (simplePolygon != null)
				{
					if (CountVertexAbove(vertexList, clipPlane) != vertexList.Count && CountVertexBelow(vertexList, clipPlane) != vertexList.Count)
					{
						polygon.Flip();
						simplePolygon.Subtract(polygon);
					}
					else
					{
						simplePolygon.Attach(vertexList);
					}
				}
			}
		}

		public static List<Vertex> ToVertices(List<Vector3> positions)
		{
			List<Vertex> list = new List<Vertex>();
			for (int i = 0; i < positions.Count; i++)
			{
				list.Add(new Vertex(positions[i]));
			}
			return list;
		}

		public static KeyValuePair<TValue, TKey> InvertKeyValue<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
		{
			return new KeyValuePair<TValue, TKey>(pair.Value, pair.Key);
		}

		private static SimplePolygon FindPolygonHavingVertex(EditableMesh editableMesh, List<Vertex> vertices)
		{
			if (editableMesh == null)
			{
				return null;
			}
			for (int i = 0; i < editableMesh.GetPolygonCount(); i++)
			{
				SimplePolygon polygon = editableMesh.GetPolygon(i);
				if (polygon.AtLeastOneVertexIncluded(vertices))
				{
					return polygon;
				}
			}
			return null;
		}

		public static SimplePolygon FindPolygonHavingEdge(List<SimplePolygon> polygons, Edge edge)
		{
			for (int i = 0; i < polygons.Count; i++)
			{
				if (polygons[i].FindOverlappedEdge(edge) != null)
				{
					return polygons[i];
				}
			}
			return null;
		}

		public static Vector3 ConvertWorldToScreen(Camera camera, Vector3 worldPos)
		{
			return camera.WorldToScreenPoint(worldPos);
		}

		public static Vector3 ConvertScreenToWorld(Camera camera, Vector3 screenPos)
		{
			return camera.ScreenToWorldPoint(screenPos);
		}

		public static int CountTriangle(MeshFilter mf)
		{
			if (mf == null || mf.sharedMesh == null)
			{
				return 0;
			}
			return CountTriangle(mf.sharedMesh);
		}

		public static int CountTriangle(Mesh mesh)
		{
			if (mesh == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				num += mesh.GetIndices(i).Length;
			}
			return num / 3;
		}

		public static bool ContainsEdge(Edge edge, List<Edge> edges)
		{
			for (int i = 0; i < edges.Count; i++)
			{
				if (edges[i].IsEquivalent(edge))
				{
					return true;
				}
			}
			return false;
		}

		public static Vector3 GetScaledNormal(Vector3 normal)
		{
			return new Vector3(normal.x / UMContext.activeModeler.transform.lossyScale.x, normal.y / UMContext.activeModeler.transform.lossyScale.y, normal.z / UMContext.activeModeler.transform.lossyScale.z);
		}

		public static float GetAdaptedVertexSize(Vector3 cameraPos, Vector3 worldPos)
		{
			return GetAdaptedVertexSize(Vector3.Distance(cameraPos, worldPos));
		}

		public static float GetAdaptedVertexSize(Vector3 pos)
		{
			return GetAdaptedVertexSizeOnWorld(UMContext.activeModeler.worldTM.MultiplyPoint3x4(pos));
		}

		public static float GetAdaptedVertexSizeOnWorld(Vector3 worldPos)
		{
			if (UMContext.engine.currentCamera == null || UMContext.activeModeler == null)
			{
				return 0f;
			}
			return GetAdaptedVertexSize(UMContext.engine.currentCamera.transform.position, worldPos);
		}

		public static float GetAdaptedVertexSize(float distFromVtxToCamera)
		{
			return 12.5f * distFromVtxToCamera * (1f / GetScreenSize());
		}

		public static float GetScreenSize()
		{
			if (UMContext.engine.currentCamera == null)
			{
				return 1f;
			}
			return Vector2.Distance(UMContext.engine.currentCamera.pixelRect.min, UMContext.engine.currentCamera.pixelRect.max);
		}

		public static float DistanceToCamera(Vector3 pos)
		{
			return DistanceToCameraInWorld(UMContext.activeModeler.worldTM.MultiplyPoint3x4(pos));
		}

		public static float DistanceToCameraInWorld(Vector3 worldPos)
		{
			return Vector3.Distance(worldPos, UMContext.engine.currentCamera.transform.position);
		}

		public static float CameraFovPow()
		{
			if (UMContext.engine.currentCamera.orthographic)
			{
				return 10f;
			}
			return UMContext.engine.currentCamera.fieldOfView / 60f;
		}

		public static float CalculateOutlineOffset(Vector3 pos)
		{
			float num = DistanceToCamera(pos);
			return defaultOutlineOffset_ * num * CameraFovPow();
		}

		public static Vector3 CalculateOutlineVector3(Vector3 pos)
		{
			return (UMContext.engine.currentCamera.transform.position - pos).normalized;
		}

		public static float CalculateOutlineOffset(AABB aabb)
		{
			Vector3[] array = new Vector3[9]
			{
				aabb.GetCenter(),
				new Vector3(aabb.min.x, aabb.min.y, aabb.min.z),
				new Vector3(aabb.min.x, aabb.min.y, aabb.max.z),
				new Vector3(aabb.min.x, aabb.max.y, aabb.min.z),
				new Vector3(aabb.min.x, aabb.max.y, aabb.max.z),
				new Vector3(aabb.max.x, aabb.min.y, aabb.min.z),
				new Vector3(aabb.max.x, aabb.min.y, aabb.max.z),
				new Vector3(aabb.max.x, aabb.max.y, aabb.min.z),
				new Vector3(aabb.max.x, aabb.max.y, aabb.max.z)
			};
			float num = 3E+10f;
			for (int i = 0; i < array.Length; i++)
			{
				float num2 = DistanceToCamera(array[i]);
				if (num2 < num)
				{
					num = num2;
				}
			}
			return defaultOutlineOffset_ * num * CameraFovPow();
		}

		public static Texture2D EmptyIcon(int iconSize)
		{
			Texture2D texture2D = new Texture2D(iconSize, iconSize, TextureFormat.ARGB32, mipChain: false);
			Color32[] array = new Color32[iconSize * iconSize];
			for (int i = 0; i < iconSize * iconSize; i++)
			{
				array[i] = new Color32(0, 0, 0, 50);
			}
			texture2D.SetPixels32(array);
			texture2D.Apply();
			return texture2D;
		}

		public static string ToDisplayName(string name)
		{
			string text = name.Replace("UV_", "");
			text = text.Replace("HSL_", "");
			for (int i = 1; i < text.Length; i++)
			{
				if (text[i] >= 'A' && text[i] <= 'Z')
				{
					text = text.Insert(i++, " ");
				}
			}
			return text;
		}

		public static Texture2D ConvertToGrayScale(Texture2D original)
		{
			Color[] pixels = original.GetPixels();
			Texture2D texture2D = new Texture2D(original.width, original.height, TextureFormat.ARGB32, mipChain: false);
			for (int i = 0; i < original.height; i++)
			{
				for (int j = 0; j < original.width; j++)
				{
					int num = i * original.width + j;
					float grayscale = pixels[num].grayscale;
					Color color = new Color(grayscale, grayscale, grayscale, pixels[num].a);
					texture2D.SetPixel(j, i, color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}
	}
}
