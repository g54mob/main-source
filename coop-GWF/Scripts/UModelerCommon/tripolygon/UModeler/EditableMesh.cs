using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace tripolygon.UModeler
{
	[Serializable]
	public class EditableMesh
	{
		[SerializeField]
		private int editMeshVersion;

		public const int TextMeshVersion = 1;

		public const int ByteStreamMeshVersion = 2;

		public static int DefaultMeshVersion = 1;

		[SerializeField]
		[FormerlySerializedAs("main_polygons_")]
		private List<SimplePolygon> mainPolygons_ = new List<SimplePolygon>();

		[SerializeField]
		private byte[] mainPolygonsStream;

		private List<SimplePolygon> mainPolygonsStreamList_ = new List<SimplePolygon>();

		[SerializeField]
		[FormerlySerializedAs("sub_polygons_")]
		private List<SimplePolygon> subPolygons_ = new List<SimplePolygon>();

		[SerializeField]
		[FormerlySerializedAs("smoothing_groups")]
		[FormerlySerializedAs("smoothingGroups")]
		private SmoothingGroupManager smoothingGroups_ = new SmoothingGroupManager();

		[SerializeField]
		[FormerlySerializedAs("edgeSharpnesses")]
		private EdgeSharpnessManager edgeSharpnesses_ = new EdgeSharpnessManager();

		[SerializeField]
		[FormerlySerializedAs("mirror_mode")]
		[FormerlySerializedAs("mirrorMode")]
		private MirrorMode mirrorMode_ = new MirrorMode();

		[SerializeField]
		[FormerlySerializedAs("uvIslandManager")]
		private UVIslandManager uvIslandManager_ = new UVIslandManager();

		[SerializeField]
		[FormerlySerializedAs("polygonGroupManager")]
		private PolygonGroupManager polygonGroupManager_ = new PolygonGroupManager();

		private EditableMeshCache editableMeshCache_;

		public ulong activePolygonGroupId;

		private bool isBuilt;

		private List<SimplePolygon>[] polygons_ = new List<SimplePolygon>[2];

		private AABB aabb_;

		private BSPTree3D bsptree3d_;

		private Dictionary<SimplePolygon, List<SimplePolygon>> adjacentPolygons_;

		private int shelf_;

		public SmoothingGroupManager smoothingGroups => smoothingGroups_;

		public EdgeSharpnessManager edgeSharpnesses => edgeSharpnesses_;

		public MirrorMode mirrorMode => mirrorMode_;

		public UVIslandManager uvIslandManager => uvIslandManager_;

		public PolygonGroupManager polygonGroupManager => polygonGroupManager_;

		public int EditMeshVersion => editMeshVersion;

		public EditableMeshCache editableMeshCache
		{
			get
			{
				if (editableMeshCache_ == null)
				{
					editableMeshCache_ = new EditableMeshCache();
					editableMeshCache_.SetEditableMesh(this);
					editableMeshCache_.Clear();
				}
				return editableMeshCache_;
			}
		}

		public bool IsBuilt
		{
			get
			{
				return isBuilt;
			}
			set
			{
				isBuilt = value;
			}
		}

		public int shelf
		{
			get
			{
				return shelf_;
			}
			set
			{
				shelf_ = value;
			}
		}

		public AABB aabb
		{
			get
			{
				if (aabb_ == null)
				{
					aabb_ = new AABB();
					aabb_.Reset();
					for (int i = 0; i < 2; i++)
					{
						for (int j = 0; j < polygons_[i].Count; j++)
						{
							if (polygons_[i][j].IsValid())
							{
								aabb_.Add(polygons_[i][j].aabb);
							}
						}
					}
				}
				return aabb_;
			}
		}

		public BSPTree3D bsptree3d
		{
			get
			{
				if (bsptree3d_ == null)
				{
					bsptree3d_ = new BSPTree3D();
					bsptree3d_.Build(this);
				}
				return bsptree3d_;
			}
		}

		public Dictionary<SimplePolygon, List<SimplePolygon>> adjacentPolygons
		{
			get
			{
				if (adjacentPolygons_ == null)
				{
					adjacentPolygons_ = new Dictionary<SimplePolygon, List<SimplePolygon>>();
					Dictionary<Edge, List<SimplePolygon>> dictionary = new Dictionary<Edge, List<SimplePolygon>>();
					for (int i = 0; i < 2; i++)
					{
						int polygonCount = GetPolygonCount(i);
						for (int j = 0; j < polygonCount; j++)
						{
							SimplePolygon polygon = GetPolygon(i, j);
							List<SimplePolygon> list;
							adjacentPolygons_.Add(polygon, list = new List<SimplePolygon>());
							for (int k = 0; k < polygon.GetEdgeCount(); k++)
							{
								Edge pureEdge = polygon.GetPureEdge(k);
								List<SimplePolygon> list2 = null;
								foreach (KeyValuePair<Edge, List<SimplePolygon>> item in dictionary)
								{
									Edge edge = item.Key.Clone().Invert();
									if (item.Key.IsEquivalent(pureEdge) || edge.IsEquivalent(pureEdge))
									{
										list2 = item.Value;
										break;
									}
								}
								if (list2 != null)
								{
									for (int l = 0; l < list2.Count; l++)
									{
										adjacentPolygons_[list2[l]].Add(polygon);
									}
									list.AddRange(list2);
									list2.Add(polygon);
								}
								else
								{
									list2 = new List<SimplePolygon>();
									list2.Add(polygon);
									dictionary.Add(pureEdge, list2);
								}
							}
						}
					}
				}
				return adjacentPolygons_;
			}
		}

		public int GetPolygonCount(int inShelf = -1)
		{
			if (inShelf == -1)
			{
				return polygons_[shelf].Count;
			}
			return polygons_[inShelf].Count;
		}

		public void RefreshVertexManager()
		{
			editableMeshCache.Clear();
		}

		public void CheckInstanceID(List<ulong> instanceIDs)
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < polygons_[i].Count; j++)
				{
					if (instanceIDs.IndexOf(polygons_[i][j].instanceID) != -1)
					{
						polygons_[i][j].RegenarateInstanceID();
					}
					instanceIDs.Add(polygons_[i][j].instanceID);
				}
			}
			if (smoothingGroups != null)
			{
				smoothingGroups.CheckInstanceID(instanceIDs);
			}
			if (uvIslandManager != null)
			{
				uvIslandManager.CheckInstanceID(instanceIDs);
			}
		}

		public ulong CollectLatestID()
		{
			ulong num = 0uL;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < polygons_[i].Count; j++)
				{
					if (polygons_[i][j].instanceID > num)
					{
						num = polygons_[i][j].instanceID;
					}
				}
			}
			if (smoothingGroups != null)
			{
				ulong num2 = smoothingGroups.CollectLatestID();
				if (num2 > num)
				{
					num = num2;
				}
			}
			if (uvIslandManager != null)
			{
				ulong num3 = uvIslandManager.CollectLatestID();
				if (num3 > num)
				{
					num = num3;
				}
			}
			return num;
		}

		public Vector3 GetCenter()
		{
			return (aabb.min + aabb.max) * 0.5f;
		}

		public List<SimplePolygon> GetConvexHulls()
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.convexhulls.Count > 0)
				{
					list.AddRange(polygon.convexhulls);
				}
			}
			return list;
		}

		public EditableMesh()
		{
			InitCommon();
		}

		public EditableMesh(List<SimplePolygon> polygons, bool clone = true)
		{
			InitCommon();
			for (int i = 0; i < polygons.Count; i++)
			{
				AddPurePolygon(clone ? polygons[i].Clone() : polygons[i]);
			}
		}

		public void BeforeSerialize()
		{
		}

		public void AfterDeserialize()
		{
			if (mainPolygonsStream != null && mainPolygonsStream.Length != 0)
			{
				MemoryStream memoryStream = new MemoryStream(mainPolygonsStream);
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				binaryReader.ReadInt32();
				int num = binaryReader.ReadInt32();
				mainPolygonsStreamList_.Clear();
				mainPolygonsStreamList_.Capacity = num;
				for (int i = 0; i < num; i++)
				{
					mainPolygonsStreamList_.Add(new SimplePolygon(binaryReader));
				}
				mainPolygons_ = mainPolygonsStreamList_;
				binaryReader.Close();
				memoryStream.Close();
				mainPolygonsStream = null;
				editMeshVersion = 1;
			}
			polygons_[0] = mainPolygons_;
			MovePolygonsBetweenShelves(1, 0);
			uvIslandManager.AfterDeserialize(editMeshVersion);
			smoothingGroups.AfterDeserialize(editMeshVersion);
			editableMeshCache.Clear();
		}

		public int IsMeshVersion()
		{
			return editMeshVersion;
		}

		public bool IsCorruptMesh()
		{
			foreach (SimplePolygon item in polygons_[0])
			{
				if (item.IsCorruptPolygon())
				{
					return true;
				}
			}
			return false;
		}

		public bool Repair()
		{
			bool flag = false;
			foreach (SimplePolygon item in polygons_[0])
			{
				flag |= item.Repair();
			}
			return flag;
		}

		public void ConvertStream()
		{
		}

		private void InitCommon()
		{
			editMeshVersion = 1;
			polygons_[0] = mainPolygons_;
			uvIslandManager.InitCommon(editMeshVersion);
			smoothingGroups.InitCommon(editMeshVersion);
			polygons_[1] = subPolygons_;
		}

		private void CloneSubResources(EditableMesh clone, Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			clone.smoothingGroups_ = smoothingGroups.Clone(originalToClone);
			clone.uvIslandManager_ = uvIslandManager.Clone(originalToClone);
			clone.polygonGroupManager_ = polygonGroupManager.Clone();
			clone.mirrorMode_ = mirrorMode.Clone();
		}

		public EditableMesh Clone()
		{
			EditableMesh editableMesh = new EditableMesh();
			Dictionary<SimplePolygon, SimplePolygon> dictionary = new Dictionary<SimplePolygon, SimplePolygon>();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < polygons_[i].Count; j++)
				{
					SimplePolygon simplePolygon = polygons_[i][j].Clone();
					editableMesh.AddPurePolygon(simplePolygon);
					dictionary.Add(polygons_[i][j], simplePolygon);
				}
			}
			CloneSubResources(editableMesh, dictionary);
			return editableMesh;
		}

		public void MovePolygonsBetweenShelves(int srcShelf, int destShelf)
		{
			if (srcShelf == destShelf)
			{
				return;
			}
			using (new ShelfHolder(this))
			{
				shelf = destShelf;
				foreach (SimplePolygon item in polygons_[srcShelf])
				{
					if (item != null)
					{
						editableMeshCache.MovePolygonShelf(item, srcShelf, destShelf);
						AddPurePolygon(item);
					}
				}
			}
			polygons_[srcShelf].Clear();
			InvalidateCache();
		}

		public void MovePolygonBetweenShelves(SimplePolygon polygon, int srcShelf, int destShelf)
		{
			if (srcShelf != destShelf && polygons_[srcShelf].Contains(polygon))
			{
				UMContext.activeModeler.editableMesh.editableMeshCache.MovePolygonShelf(polygon, srcShelf, destShelf);
				polygons_[srcShelf].Remove(polygon);
				AddPurePolygon(destShelf, polygon);
			}
		}

		public SimplePolygon FindPolygon(Ray ray, out float t, bool excludeBackface = false)
		{
			float num = 3E+10f;
			SimplePolygon result = null;
			t = 3E+10f;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (!polygon.IsOpen() && polygon.Raycast(ray, out t, excludeBackface) && t < num && t > 0f)
				{
					num = t;
					result = polygon;
				}
			}
			Matrix4x4 worldToLocalTM = UMContext.activeModeler.worldToLocalTM;
			for (int j = 0; j < GetPolygonCount(); j++)
			{
				SimplePolygon polygon2 = GetPolygon(j);
				if (!polygon2.IsOpen())
				{
					continue;
				}
				float handleSize = MathUtil.GetHandleSize(polygon2.GetCenter(), worldToLocalTM, 5f);
				for (int k = 0; k < polygon2.GetEdgeCount(); k++)
				{
					if (polygon2.GetPureEdge(k).Raycast(ray, out t, handleSize) && t < num && t > 0f)
					{
						num = t;
						result = polygon2;
					}
				}
			}
			t = num;
			return result;
		}

		public SimplePolygon FindPolygon(PlaneEx plane, Ray ray, out float t)
		{
			int polygonCount = GetPolygonCount();
			float num = 3E+10f;
			SimplePolygon result = null;
			t = 3E+10f;
			for (int i = 0; i < polygonCount; i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.plane.IsEquivalent(plane) && polygon.Raycast(ray, out t) && t < num && t > 0f)
				{
					num = t;
					result = polygon;
				}
			}
			t = num;
			return result;
		}

		public List<SimplePolygon> FindPolygons(PlaneEx plane)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.plane.IsEquivalent(plane))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public ClosestEdge FindClosestEdge(Ray ray, bool excludeHoles = false, bool excludeBackface = true)
		{
			ClosestEdge closestEdge = new ClosestEdge();
			float t = 0f;
			closestEdge.polygon = FindPolygon(ray, out t, excludeBackface);
			if (closestEdge.polygon != null)
			{
				SimplePolygon outsideLoopPolygon = closestEdge.polygon.segments.GetOutsideLoopPolygon();
				SimplePolygon obj = ((!excludeHoles) ? closestEdge.polygon : outsideLoopPolygon);
				Vector3 pos = ray.origin + ray.direction * t;
				if (!obj.FindClosestEdge(pos, out closestEdge.edge, out closestEdge.posOnEdge))
				{
					return null;
				}
				closestEdge.belongIntoHole = true;
				if (!excludeHoles)
				{
					for (int i = 0; i < outsideLoopPolygon.GetEdgeCount(); i++)
					{
						if (outsideLoopPolygon.GetPureEdge(i).IsEquivalent(closestEdge.edge))
						{
							closestEdge.belongIntoHole = false;
							break;
						}
					}
				}
			}
			else
			{
				closestEdge = null;
				float num = 3E+10f;
				for (int j = 0; j < GetPolygonCount(); j++)
				{
					SimplePolygon polygon = GetPolygon(j);
					for (int k = 0; k < polygon.GetEdgeCount(); k++)
					{
						Edge pureEdge = polygon.GetPureEdge(k);
						if (pureEdge.Raycast(ray, out t) && t < num)
						{
							if (closestEdge == null)
							{
								closestEdge = new ClosestEdge();
							}
							closestEdge.polygon = polygon;
							closestEdge.edge = pureEdge;
							float t2 = 0f;
							if (closestEdge.polygon.plane.Raycast(ray, out t2))
							{
								closestEdge.posOnEdge = ray.origin + ray.direction * t2;
								num = t2;
							}
							else
							{
								closestEdge.posOnEdge = ray.origin + ray.direction * t;
								num = t;
							}
						}
					}
				}
			}
			return closestEdge;
		}

		public List<SimplePolygon> FindIntersectedPolygons(AABB aabb)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.aabb.IsIntersectBox(aabb))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindNeighborPerpendicularPolygons(SimplePolygon polygon)
		{
			List<SimplePolygon> list = null;
			AABB aABB = polygon.aabb.Clone();
			aABB.Expand(new Vector3(1f, 1f, 1f) * 0.001f);
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				Vector3 pos = polygon.GetVertex(i).pos;
				aABB.Add(pos + polygon.plane.normal * 10000f);
				aABB.Add(pos - polygon.plane.normal * 10000f);
			}
			for (int j = 0; j < GetPolygonCount(); j++)
			{
				SimplePolygon polygon2 = GetPolygon(j);
				if (polygon2.IsOpen() || polygon2 == polygon || polygon2.plane.IsEquivalent(polygon.plane) || Mathf.Abs(Vector3.Dot(polygon2.plane.normal, polygon.plane.normal)) > 0.0001f)
				{
					continue;
				}
				for (int k = 0; k < polygon2.GetVertexCount(); k++)
				{
					if (Mathf.Abs(polygon.plane.CalcDistanceToPoint(polygon2.GetVertex(k).pos)) < 0.0001f)
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(polygon2);
						break;
					}
				}
			}
			return list;
		}

		public int FindPolygonIndex(SimplePolygon polygon)
		{
			for (int i = 0; i < polygons_[shelf].Count; i++)
			{
				if (polygons_[shelf][i] == polygon)
				{
					return i;
				}
			}
			return -1;
		}

		public bool FindIntersectionsByEdge(Edge edge, out List<KeyValuePair<SimplePolygon, Vector3>> outIntersections)
		{
			outIntersections = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				if (GetPolygon(i).FindIntersectionsByEdge(edge, out var outIntersections2))
				{
					if (outIntersections == null)
					{
						outIntersections = new List<KeyValuePair<SimplePolygon, Vector3>>();
					}
					outIntersections.AddRange(outIntersections2);
				}
			}
			return outIntersections != null;
		}

		public SimplePolygon FindClosestOppositePolygon(SimplePolygon inputPolygon, EOppositeDirection oppositeDirection, bool is_polygon_scaled, out float closest_distance)
		{
			closest_distance = 3E+10f;
			PlaneEx plane = inputPolygon.plane;
			PlaneEx plane2 = plane.Clone().Flip();
			SimplePolygon simplePolygon = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.IsOpen() || polygon.IsEmpty() || polygon.IsNonplanarQuad() || polygon.plane.IsEquivalent(plane) || polygon.plane.IsEquivalent(plane2))
				{
					continue;
				}
				SimplePolygon simplePolygon2 = polygon.Clone();
				simplePolygon2.Project2Plane(plane);
				if (is_polygon_scaled && simplePolygon2.Scale(0.001f) == null)
				{
					continue;
				}
				simplePolygon2.Intersect(inputPolygon);
				if (simplePolygon2.IsEmpty() || simplePolygon2.IsOpen())
				{
					continue;
				}
				simplePolygon2.Project2Plane(polygon.plane, plane.normal);
				Vector3 pos = simplePolygon2.GetVertex(0).pos;
				float t = 0f;
				if (!plane.RayHit(pos, polygon.plane.normal, out t))
				{
					continue;
				}
				if (is_polygon_scaled)
				{
					if (Vector3.Dot(polygon.plane.normal, plane.normal) < 0.9999f)
					{
						continue;
					}
					switch (oppositeDirection)
					{
					case EOppositeDirection.Backward:
						if (t < 0f)
						{
							continue;
						}
						break;
					case EOppositeDirection.Forward:
						if (t > 0f)
						{
							continue;
						}
						break;
					}
				}
				else
				{
					if (plane.IsTowardSameDirection(polygon.plane))
					{
						continue;
					}
					List<Vertex> vertexList = polygon.GetVertexList();
					int num = Util.CountVertexBelow(vertexList, plane);
					int num2 = Util.CountVertexAbove(vertexList, plane);
					switch (oppositeDirection)
					{
					case EOppositeDirection.Backward:
						if ((num == 0 && Comparer.IsEquivalent(t, 0f)) || t > 0f)
						{
							continue;
						}
						break;
					case EOppositeDirection.Forward:
						if ((num2 == 0 && Comparer.IsEquivalent(t, 0f)) || t < 0f)
						{
							continue;
						}
						break;
					}
				}
				if (plane.FindClosestDistance(simplePolygon2, plane.normal, out t) == null)
				{
					continue;
				}
				if (Comparer.IsEquivalent(t, closest_distance))
				{
					float f = Vector3.Dot(inputPolygon.plane.normal, polygon.plane.normal);
					float f2 = Vector3.Dot(inputPolygon.plane.normal, simplePolygon.plane.normal);
					if (Mathf.Abs(f) > Mathf.Abs(f2))
					{
						simplePolygon = polygon;
						closest_distance = t;
					}
				}
				else if (t < closest_distance)
				{
					closest_distance = t;
					simplePolygon = polygon;
				}
			}
			return simplePolygon;
		}

		public SimplePolygon FindPolygon(ulong id)
		{
			SimplePolygon simplePolygon = editableMeshCache.FindPolygon(id);
			if (simplePolygon != null)
			{
				return simplePolygon;
			}
			return null;
		}

		public SimplePolygon FindEquivalentPolygon(SimplePolygon polygon)
		{
			if (Contains(polygon))
			{
				return polygon;
			}
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon2 = GetPolygon(i);
				if (polygon2.IsEquivalent(polygon))
				{
					return polygon2;
				}
			}
			return null;
		}

		public List<SimplePolygon> FindPolygonsHavingEdge(Edge edge)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsEdge(edge))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<IndexPair> FindEdgeIndexPairs(Edge edge)
		{
			List<IndexPair> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				IndexPair indexPair = GetPolygon(i).FindEdgeIndexPair(edge);
				if (indexPair != null)
				{
					if (list == null)
					{
						list = new List<IndexPair>();
					}
					list.Add(indexPair);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsIncludeVertex(int inShelf, Vector3 pos)
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			foreach (SimplePolygon item in polygons_[inShelf])
			{
				if (item.FindVertexIndex(pos) != -1)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonHavingEdge(Edge edge)
		{
			List<SimplePolygon> list = null;
			Edge edge2 = edge.Clone().Invert();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsEdge(edge) || polygon.ContainsEdge(edge2))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsSharingEdge(Edge edge)
		{
			List<SimplePolygon> list = null;
			Edge edge2 = edge.Clone().Invert();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsEdge(edge) || polygon.ContainsEdge(edge2) || polygon.FindOverlappedEdge(edge) != null || polygon.FindOverlappedEdge(edge2) != null)
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsCoverdEdge(Edge edge)
		{
			List<SimplePolygon> list = null;
			Edge edge2 = edge.Clone().Invert();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.IsEdgeCovered(edge) || polygon.IsEdgeCovered(edge2))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsSharingUVEdge(Edge edge)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsUVEdge(edge))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsSharingEdgeInAllShelf(Edge edge)
		{
			List<SimplePolygon> list = null;
			Edge edge2 = edge.Clone().Invert();
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < GetPolygonCount(i); j++)
				{
					SimplePolygon polygon = GetPolygon(i, j);
					if (polygon.ContainsEdge(edge) || polygon.ContainsEdge(edge2) || polygon.FindOverlappedEdge(edge) != null || polygon.FindOverlappedEdge(edge2) != null)
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(polygon);
					}
				}
			}
			return list;
		}

		public List<SimplePolygon> FindPolygonsHavingPos(Vector3 pos)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (polygon.ContainsPosition(pos))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon);
				}
			}
			return list;
		}

		public List<SimplePolygon> FindAdjacentPolygons(SimplePolygon polygon)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge edge = polygon.GetPureEdge(i).Invert();
				List<SimplePolygon> list2 = FindPolygonsSharingEdge(edge);
				int num = 0;
				while (list2 != null && num < list2.Count)
				{
					if ((list == null || !list.Contains(list2[num])) && !polygon.IsEquivalent(list2[num]))
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(list2[num]);
					}
					num++;
				}
			}
			return list;
		}

		public List<SimplePolygon> FindAdjacentCompletlyPolygons(SimplePolygon polygon)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge edge = polygon.GetPureEdge(i).Invert();
				List<SimplePolygon> list2 = FindPolygonHavingEdge(edge);
				int num = 0;
				while (list2 != null && num < list2.Count)
				{
					if ((list == null || !list.Contains(list2[num])) && !polygon.IsEquivalent(list2[num]))
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(list2[num]);
					}
					num++;
				}
			}
			return list;
		}

		public List<SimplePolygon> FindUVAdjacentPolygons(SimplePolygon polygon)
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge edge = polygon.GetPureEdge(i).Invert();
				List<SimplePolygon> list2 = FindPolygonsSharingUVEdge(edge);
				int num = 0;
				while (list2 != null && num < list2.Count)
				{
					if (!list.Contains(list2[num]) && !polygon.IsEquivalent(list2[num]))
					{
						list.Add(list2[num]);
					}
					num++;
				}
			}
			return list;
		}

		public List<SimplePolygon> FindAdjacentPolygonsExcludeEdges(SimplePolygon polygon, List<Edge> excludeEdges)
		{
			List<SimplePolygon> list = null;
			EdgeEqualityComparer comparer = new EdgeEqualityComparer();
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge edge = polygon.GetPureEdge(i).Invert();
				if (excludeEdges != null && excludeEdges.Contains(edge, comparer))
				{
					continue;
				}
				List<SimplePolygon> list2 = FindPolygonsSharingEdge(edge);
				int num = 0;
				while (list2 != null && num < list2.Count)
				{
					if ((list == null || !list.Contains(list2[num])) && !polygon.IsEquivalent(list2[num]))
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(list2[num]);
					}
					num++;
				}
			}
			return list;
		}

		public List<SimplePolygon> FindAdjacentPolygonsInAllShelf(SimplePolygon polygon)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge edge = polygon.GetPureEdge(i).Invert();
				List<SimplePolygon> list2 = FindPolygonsSharingEdgeInAllShelf(edge);
				int num = 0;
				while (list2 != null && num < list2.Count)
				{
					if ((list == null || !list.Contains(list2[num])) && !polygon.IsEquivalent(list2[num]))
					{
						if (list == null)
						{
							list = new List<SimplePolygon>();
						}
						list.Add(list2[num]);
					}
					num++;
				}
			}
			return list;
		}

		public List<Edge> FindOverlappedEdges(Edge edge)
		{
			List<Edge> list = null;
			List<SimplePolygon> list2 = FindPolygonsSharingEdge(edge);
			if (list2 == null)
			{
				return null;
			}
			for (int i = 0; i < list2.Count; i++)
			{
				List<Edge> list3 = list2[i].FindOverlappedEdge(edge);
				if (list3 != null)
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.AddRange(list3);
				}
			}
			return list;
		}

		public bool Contains(SimplePolygon polygon)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				if (GetPolygon(i) == polygon)
				{
					return true;
				}
			}
			return false;
		}

		public IndexPair FindEdgeIndexPair(Edge edge)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				IndexPair indexPair = GetPolygon(i).FindEdgeIndexPair(edge);
				if (indexPair != null)
				{
					return indexPair;
				}
			}
			return null;
		}

		public void AddPurePolygon(SimplePolygon polygon, bool bForceUpdateVM = false)
		{
			AddPurePolygon(shelf, polygon, bForceUpdateVM);
		}

		private void AddPurePolygon(int inShelf, SimplePolygon polygon, bool bForceUpdateVM = false)
		{
			polygon.groupID = activePolygonGroupId;
			polygons_[inShelf].Add(polygon);
			editableMeshCache.AddPolygon(polygon, inShelf);
			if ((bForceUpdateVM || (UMContext.activeModeler != null && this == UMContext.activeModeler.editableMesh)) && !editableMeshCache.UpdatePartially(polygon))
			{
				editableMeshCache.Clear();
			}
		}

		public void AddPolygon(SimplePolygon polygon)
		{
			if (polygon != null && polygon.IsValid())
			{
				if (polygon.IsOpen())
				{
					AddSegments(polygon);
				}
				else
				{
					AddIsolatedUnits(polygon);
				}
			}
		}

		private void AddSegments(SimplePolygon polygon)
		{
			if (!polygon.IsOpen())
			{
				return;
			}
			SegmentPolygons segments = polygon.segments;
			polygon.groupID = activePolygonGroupId;
			if (segments.GetLoopCount() == 1)
			{
				AddPurePolygon(shelf, polygon);
				return;
			}
			for (int i = 0; i < segments.GetLoopCount(); i++)
			{
				Segment loop = segments.GetLoop(i);
				SimplePolygon simplePolygon = new SimplePolygon(loop.vertices, polygon.plane, loop.open);
				simplePolygon.groupID = polygon.groupID;
				AddPurePolygon(shelf, simplePolygon);
			}
		}

		private bool CheckSegmentExist(SimplePolygon polygon)
		{
			if (polygon.IsOpen())
			{
				SegmentPolygons segments = polygon.segments;
				for (int i = 0; i < segments.GetLoopCount(); i++)
				{
					if (CheckSegmentExist(segments.GetLoop(i)))
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		private bool CheckSegmentExist(Segment segment)
		{
			for (int i = 0; i < segment.vertices.Count - 1; i++)
			{
				Edge edge = new Edge(segment.vertices[i].pos, segment.vertices[i + 1].pos);
				if (FindPolygonsSharingEdge(edge) != null)
				{
					return true;
				}
			}
			return false;
		}

		private void AddUnwrappedPolygon(SimplePolygon polygon)
		{
			polygon.groupID = activePolygonGroupId;
			if (shelf == 0)
			{
				if (polygon.IsUnwrapped())
				{
					uvIslandManager.AddPolygonToNewIsland(polygon);
				}
				else
				{
					uvIslandManager.RemovePolygon(polygon);
				}
			}
			AddPurePolygon(shelf, polygon);
		}

		private List<SimplePolygon> AddIsolatedUnits(SimplePolygon polygon)
		{
			if (polygon == null || !polygon.IsValid())
			{
				return null;
			}
			polygon.groupID = activePolygonGroupId;
			if (polygon.segments.GetLoopCount() == 1)
			{
				AddUnwrappedPolygon(polygon);
				return new List<SimplePolygon> { polygon };
			}
			List<SimplePolygon> isolatedUnits = polygon.GetIsolatedUnits();
			if (isolatedUnits != null)
			{
				if (isolatedUnits.Count == 1)
				{
					AddUnwrappedPolygon(polygon);
				}
				else
				{
					for (int i = 0; i < isolatedUnits.Count; i++)
					{
						AddUnwrappedPolygon(isolatedUnits[i]);
					}
				}
			}
			else if (!polygon.IsEmpty())
			{
				AddUnwrappedPolygon(polygon);
			}
			isolatedUnits.RemoveAll((SimplePolygon item) => item == null);
			return isolatedUnits;
		}

		public void Join(EditableMesh editableMesh)
		{
			for (int i = 0; i < editableMesh.GetPolygonCount(); i++)
			{
				AddPolygon(editableMesh.GetPolygon(i));
			}
		}

		public void ReplaceWith(EditableMesh editableMesh)
		{
			if (this == UMContext.activeModeler.editableMesh)
			{
				editableMeshCache.Clear();
			}
			Dictionary<SimplePolygon, SimplePolygon> dictionary = new Dictionary<SimplePolygon, SimplePolygon>();
			using (new ShelfHolder(editableMesh))
			{
				for (int i = 0; i < 2; i++)
				{
					editableMesh.shelf = i;
					polygons_[i].Clear();
					for (int j = 0; j < editableMesh.GetPolygonCount(); j++)
					{
						SimplePolygon simplePolygon = editableMesh.GetPolygon(j).Clone();
						AddPurePolygon(simplePolygon);
						dictionary.Add(editableMesh.GetPolygon(j), simplePolygon);
					}
				}
			}
			editableMesh.CloneSubResources(this, dictionary);
			InvalidateCache();
		}

		public void ReplaceWith(Mesh mesh, bool makeAutoSmoothingGroup)
		{
			Clear();
			if (mesh.subMeshCount == 1)
			{
				AssignMesh(mesh, mesh.GetIndices(0), 0, makeAutoSmoothingGroup);
				return;
			}
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				AssignMesh(mesh, mesh.GetIndices(i), i, makeAutoSmoothingGroup);
			}
		}

		private void SortPolygonByIndex(Dictionary<int, List<SimplePolygon>> autoSmoothingGroup, int vertexIndex, SimplePolygon polygon)
		{
			if (!autoSmoothingGroup.ContainsKey(vertexIndex))
			{
				autoSmoothingGroup.Add(vertexIndex, new List<SimplePolygon>());
			}
			autoSmoothingGroup[vertexIndex].Add(polygon);
		}

		private void AssignMesh(Mesh mesh, int[] indices, int subMeshID, bool makeAutoSmoothingGroup)
		{
			Vector2[] uv = mesh.uv;
			Color[] colors = mesh.colors;
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			bool flag = uv != null && uv.Length != 0;
			bool flag2 = colors != null && colors.Length != 0;
			Dictionary<int, List<SimplePolygon>> dictionary = null;
			MeshTopology topology = mesh.GetTopology(subMeshID);
			if (makeAutoSmoothingGroup)
			{
				dictionary = new Dictionary<int, List<SimplePolygon>>();
			}
			switch (topology)
			{
			case MeshTopology.Triangles:
			{
				for (int j = 0; j < indices.Length; j += 3)
				{
					int num5 = indices[j];
					int num6 = indices[j + 1];
					int num7 = indices[j + 2];
					SimplePolygon simplePolygon2 = new SimplePolygon(vertices[num5], vertices[num6], vertices[num7], flag ? uv[num5] : Vector2.zero, flag ? uv[num6] : Vector2.zero, flag ? uv[num7] : Vector2.zero, flag2 ? colors[num5] : Color.white, flag2 ? colors[num6] : Color.white, flag2 ? colors[num7] : Color.white, null, EPolygonFlag.UVUnwrapped);
					if (simplePolygon2.GetVertexCount() == 0)
					{
						Debug.Log("UModelerize : The polygon was excluded due to its small size.");
						continue;
					}
					simplePolygon2.matID = subMeshID;
					simplePolygon2.groupID = activePolygonGroupId;
					if (makeAutoSmoothingGroup)
					{
						SortPolygonByIndex(dictionary, num5, simplePolygon2);
						SortPolygonByIndex(dictionary, num6, simplePolygon2);
						SortPolygonByIndex(dictionary, num7, simplePolygon2);
					}
					AddPurePolygon(shelf, simplePolygon2);
				}
				break;
			}
			case MeshTopology.Quads:
			{
				for (int i = 0; i < indices.Length; i += 4)
				{
					int num = indices[i];
					int num2 = indices[i + 1];
					int num3 = indices[i + 2];
					int num4 = indices[i + 3];
					SimplePolygon simplePolygon = new SimplePolygon(new List<Vertex>
					{
						new Vertex(vertices[num], flag ? uv[num] : Vector2.zero, flag2 ? colors[num] : Color.white),
						new Vertex(vertices[num2], flag ? uv[num2] : Vector2.zero, flag2 ? colors[num2] : Color.white),
						new Vertex(vertices[num3], flag ? uv[num3] : Vector2.zero, flag2 ? colors[num3] : Color.white),
						new Vertex(vertices[num4], flag ? uv[num4] : Vector2.zero, flag2 ? colors[num4] : Color.white)
					}, null, open: false, EPolygonFlag.UVUnwrapped);
					if (simplePolygon.GetVertexCount() == 0)
					{
						Debug.Log("UModelerize : The polygon was excluded due to its small size.");
						continue;
					}
					simplePolygon.matID = subMeshID;
					simplePolygon.groupID = activePolygonGroupId;
					if (makeAutoSmoothingGroup)
					{
						SortPolygonByIndex(dictionary, num, simplePolygon);
						SortPolygonByIndex(dictionary, num2, simplePolygon);
						SortPolygonByIndex(dictionary, num3, simplePolygon);
						SortPolygonByIndex(dictionary, num4, simplePolygon);
					}
					AddPurePolygon(shelf, simplePolygon);
				}
				break;
			}
			}
			if (!makeAutoSmoothingGroup)
			{
				return;
			}
			int num8 = 200;
			float num9 = (float)num8 / 2f;
			Dictionary<int, List<int>> dictionary2 = new Dictionary<int, List<int>>();
			for (int k = 0; k < num8; k++)
			{
				dictionary2.Add(k, new List<int>());
			}
			foreach (KeyValuePair<int, List<SimplePolygon>> item in dictionary)
			{
				int key = Mathf.Min((int)((Vector3.Dot(Vector3.up, normals[item.Key]) + 1f) * num9), num8 - 1);
				dictionary2[key].Add(item.Key);
			}
			foreach (KeyValuePair<int, List<SimplePolygon>> item2 in dictionary)
			{
				if (item2.Value.Count == 0)
				{
					continue;
				}
				int key2 = item2.Key;
				int key3 = Mathf.Min((int)((Vector3.Dot(Vector3.up, normals[key2]) + 1f) * num9), num8 - 1);
				foreach (int item3 in dictionary2[key3])
				{
					List<SimplePolygon> list = dictionary[item3];
					if (item3 != key2 && list.Count != 0 && Comparer.IsEquivalent(vertices[item3], vertices[key2]) && Comparer.IsEquivalent(normals[item3], normals[key2]))
					{
						item2.Value.AddRange(list);
						list.Clear();
					}
				}
			}
			Dictionary<SimplePolygon, List<SimplePolygon>> dictionary3 = new Dictionary<SimplePolygon, List<SimplePolygon>>();
			foreach (KeyValuePair<int, List<SimplePolygon>> item4 in dictionary)
			{
				List<SimplePolygon> value = item4.Value;
				if (value.Count == 0)
				{
					continue;
				}
				foreach (SimplePolygon item5 in value)
				{
					if (!dictionary3.ContainsKey(item5))
					{
						dictionary3.Add(item5, new List<SimplePolygon>());
					}
					dictionary3[item5].AddRange(value);
				}
			}
			smoothingGroups.Invalidate();
			int num10 = 1;
			for (int l = 0; l < 100000; l++)
			{
				if (dictionary3.Count <= 0)
				{
					break;
				}
				Queue<SimplePolygon> queue = new Queue<SimplePolygon>();
				List<SimplePolygon> list2 = new List<SimplePolygon>();
				queue.Enqueue(dictionary3.First().Key);
				list2.Add(dictionary3.First().Key);
				for (int m = 0; m < 100000; m++)
				{
					if (queue.Count <= 0)
					{
						break;
					}
					SimplePolygon key4 = queue.Dequeue();
					if (!dictionary3.ContainsKey(key4))
					{
						continue;
					}
					List<SimplePolygon> list3 = dictionary3[key4];
					dictionary3.Remove(key4);
					foreach (SimplePolygon item6 in list3)
					{
						if (dictionary3.ContainsKey(item6))
						{
							queue.Enqueue(item6);
						}
						if (!list2.Contains(item6))
						{
							list2.Add(item6);
						}
					}
				}
				if (list2.Count <= 1)
				{
					continue;
				}
				SmoothingGroup smoothingGroup = smoothingGroups.AddSmoothingGroup($"Auto_{num10}");
				num10++;
				foreach (SimplePolygon item7 in list2)
				{
					smoothingGroup.AddPolygon(item7);
				}
			}
		}

		public void AddUnitedPolygon(SimplePolygon polygon)
		{
			if (!polygon.IsValid())
			{
				return;
			}
			if (IsEmpty())
			{
				AddPolygon(polygon);
				return;
			}
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon2 = GetPolygon(i);
				if (polygon2.IsIntersected(polygon))
				{
					list.Add(polygon2);
				}
			}
			SimplePolygon simplePolygon = polygon.Clone();
			for (int j = 0; j < list.Count; j++)
			{
				simplePolygon.Unite(list[j]);
				RemovePolygon(list[j]);
			}
			AddPolygon(simplePolygon);
		}

		public List<SimplePolygon> AddSubtractedPolygon(SimplePolygon polygon)
		{
			if (!polygon.IsValid())
			{
				return null;
			}
			InvalidateCache();
			List<SimplePolygon> list = FindCandidates(polygon);
			SimplePolygon bPolygon = polygon.Clone();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					RemovePolygon(list[i]);
					list[i].Subtract(bPolygon);
					AddIsolatedUnits(list[i]);
				}
			}
			return list;
		}

		public List<SimplePolygon> AddSplitPolygon(SimplePolygon polygon)
		{
			if (!polygon.IsValid())
			{
				return null;
			}
			InvalidateCache();
			if (polygon.IsOpen())
			{
				return SplitByOpenPolygon(polygon);
			}
			List<SimplePolygon> list = FindCandidates(polygon, 0.002f);
			SimplePolygon simplePolygon = polygon.Clone();
			List<SimplePolygon> list2 = new List<SimplePolygon>();
			if (list == null)
			{
				list2.Add(simplePolygon);
				AddPolygon(simplePolygon);
				return list2;
			}
			for (int i = 0; i < list.Count; i++)
			{
				SimplePolygon simplePolygon2 = list[i].Clone();
				list2.Add(simplePolygon2.Intersect(polygon));
				SimplePolygon simplePolygon3 = list[i].Clone();
				if (!simplePolygon2.IsEmpty() && !simplePolygon2.IsOpen())
				{
					simplePolygon3.Subtract(polygon);
					simplePolygon.Subtract(simplePolygon2);
					list2.AddRange(AddIsolatedUnits(simplePolygon2));
				}
				if (!simplePolygon3.IsEmpty())
				{
					if (!simplePolygon3.IsOpen())
					{
						list2.AddRange(AddIsolatedUnits(simplePolygon3));
					}
					else
					{
						list2.AddRange(AddIsolatedUnits(list[i].Clone()));
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				RemovePolygon(list[j]);
			}
			if (!simplePolygon.IsEmpty())
			{
				list2.Add(simplePolygon);
				List<SimplePolygon> collection = AddIsolatedUnits(simplePolygon);
				list2.AddRange(collection);
			}
			return list2;
		}

		public void AddExclusiveORPolygon(SimplePolygon polygon, bool input_flipped = false, bool unlockAutoHotspot = false)
		{
			if (!polygon.IsValid())
			{
				return;
			}
			InvalidateCache();
			AABB aABB = polygon.aabb;
			List<SimplePolygon> list = new List<SimplePolygon>();
			List<SimplePolygon> list2 = new List<SimplePolygon>();
			List<SimplePolygon> list3 = new List<SimplePolygon>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon2 = GetPolygon(i);
				if (polygon2 == null || polygon2.IsNonplanarQuad() || polygon2.IsOpen() || !aABB.IsIntersectBox(polygon2.aabb) || !polygon.plane.IsEquivalent(polygon2.plane))
				{
					continue;
				}
				switch (SimplePolygon.IntersectionTest(polygon, polygon2))
				{
				case EIntersection.Intersection:
				{
					list.Add(polygon2);
					SimplePolygon simplePolygon = polygon2.Clone();
					if (unlockAutoHotspot)
					{
						simplePolygon.LockAutoHotspot(locked: false);
					}
					list2.Add(simplePolygon);
					break;
				}
				case EIntersection.Adjacency:
					list3.Add(polygon2);
					break;
				}
			}
			if (list.Count == 0)
			{
				if (list3.Count > 0)
				{
					list3[0].Unite(polygon);
					for (int j = 1; j < list3.Count; j++)
					{
						list3[0].Unite(list3[j]);
						RemovePolygon(list3[j]);
					}
				}
				else
				{
					SimplePolygon simplePolygon2 = polygon.Clone();
					if (unlockAutoHotspot)
					{
						simplePolygon2.LockAutoHotspot(locked: false);
					}
					AddPolygon(input_flipped ? simplePolygon2.Flip() : simplePolygon2);
				}
				return;
			}
			if (list.Count == 1 && polygon.Included(list[0]))
			{
				SimplePolygon simplePolygon3 = polygon.Clone();
				if (unlockAutoHotspot)
				{
					simplePolygon3.LockAutoHotspot(locked: false);
				}
				simplePolygon3.Subtract(list[0]);
				RemovePolygon(list[0]);
				if (!simplePolygon3.IsEmpty())
				{
					AddIsolatedUnits(input_flipped ? simplePolygon3.Flip() : simplePolygon3);
				}
				return;
			}
			for (int k = 0; k < list.Count; k++)
			{
				SimplePolygon simplePolygon4 = polygon.Clone();
				if (unlockAutoHotspot)
				{
					simplePolygon4.LockAutoHotspot(locked: false);
				}
				for (int l = 0; l < list.Count; l++)
				{
					if (k != l)
					{
						simplePolygon4.Subtract(list2[l]);
					}
				}
				if (!simplePolygon4.IsEmpty() && !simplePolygon4.IsOpen())
				{
					list[k].LockAutoHotspot(locked: false);
					list[k].Subtract(simplePolygon4);
					RemovePolygon(list[k]);
					if (!list[k].IsEmpty())
					{
						AddIsolatedUnits(list[k]);
					}
					simplePolygon4.Subtract(list2[k]);
					if (!simplePolygon4.IsEmpty())
					{
						AddIsolatedUnits(simplePolygon4.Flip());
					}
				}
			}
		}

		private List<SimplePolygon> SplitByOpenPolygon(SimplePolygon open_polygon)
		{
			if (!open_polygon.IsOpen())
			{
				return null;
			}
			InvalidateCache();
			List<SimplePolygon> list = new List<SimplePolygon>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				if (!polygon.IsOpen() && SimplePolygon.IntersectionTest(polygon, open_polygon) == EIntersection.Intersection)
				{
					list.Add(polygon);
				}
			}
			if (list.Count == 0)
			{
				AddPolygon(open_polygon);
				return new List<SimplePolygon> { open_polygon };
			}
			List<SimplePolygon> list2 = new List<SimplePolygon>();
			for (int j = 0; j < list.Count; j++)
			{
				SimplePolygon simplePolygon = list[j].Clone();
				SimplePolygon simplePolygon2 = open_polygon.Clone();
				simplePolygon2.ClipOutside(simplePolygon);
				List<SimplePolygon> list3 = new List<SimplePolygon>();
				for (int k = 0; k < simplePolygon2.segments.GetLoopCount(); k++)
				{
					Segment loop = simplePolygon2.segments.GetLoop(k);
					if (loop.open)
					{
						list3.Add(new SimplePolygon(loop.vertices, open_polygon.plane, open: true));
					}
				}
				List<SimplePolygon> polygonsCutByOpenPolyon = simplePolygon.GetPolygonsCutByOpenPolyon(list3);
				if (polygonsCutByOpenPolyon != null)
				{
					RemovePolygon(list[j]);
					for (int l = 0; l < polygonsCutByOpenPolyon.Count; l++)
					{
						if (!polygonsCutByOpenPolyon[l].IsUnwrapped() || open_polygon.GetEdgeCount() > 1)
						{
							polygonsCutByOpenPolyon[l].ResetUVs();
						}
						list2.AddRange(AddSplitPolygon(polygonsCutByOpenPolyon[l]));
					}
				}
				else
				{
					list2.AddRange(list3);
					for (int m = 0; m < list3.Count; m++)
					{
						AddPolygon(list3[m]);
					}
				}
			}
			return list2;
		}

		public SimplePolygon GetPolygon(int idx)
		{
			return polygons_[shelf][idx];
		}

		public SimplePolygon GetPolygon(int inShelf, int idx)
		{
			return polygons_[inShelf][idx];
		}

		public List<SimplePolygon> GetAllPolygons()
		{
			return new List<SimplePolygon>(polygons_[shelf]);
		}

		public void SetPolygon(int idx, SimplePolygon polygon)
		{
			InvalidateCache();
			polygons_[shelf][idx] = polygon;
			editableMeshCache.AddPolygon(polygon);
			if (UMContext.activeModeler.editableMesh == this && shelf != 1 && !editableMeshCache.UpdatePartially(polygon))
			{
				editableMeshCache.Clear();
			}
		}

		public void RemovePolygon(SimplePolygon polygon)
		{
			if (polygon != null)
			{
				InvalidateCache();
				editableMeshCache.RemovePolygon(polygon);
				polygons_[shelf].Remove(polygon);
				if (UMContext.activeModeler.editableMesh == this)
				{
					_ = shelf;
					_ = 1;
				}
			}
		}

		public bool RemoveEdge(Edge edge)
		{
			List<SimplePolygon> list = FindPolygonsCoverdEdge(edge);
			if (list == null)
			{
				return false;
			}
			PlaneEx plane = Util.FindBestPlane(this, edge.p0, edge.p1);
			InvalidateCache();
			if (list.Count == 1)
			{
				if (!list[0].IsOpen())
				{
					List<Edge> linkEdges = list[0].GetLinkEdges();
					if (linkEdges != null)
					{
						SimplePolygon simplePolygon = new SimplePolygon();
						simplePolygon.plane = plane;
						Edge rhs = edge.Clone().Invert();
						for (int i = 0; i < linkEdges.Count; i++)
						{
							if (!linkEdges[i].IsEquivalent(edge) && !linkEdges[i].IsEquivalent(rhs))
							{
								simplePolygon.AddEdge(linkEdges[i]);
							}
						}
						if (simplePolygon.GetEdgeCount() < linkEdges.Count)
						{
							list[0].RemoveLinkEdges();
							AddPolygon(simplePolygon);
						}
					}
					else
					{
						list[0].RemoveEdge(edge);
						RemovePolygon(list[0]);
						if (!CheckSegmentExist(list[0]))
						{
							AddPolygon(list[0]);
						}
					}
					return true;
				}
				RemovePolygon(list[0]);
				if (list[0].GetEdgeCount() > 1)
				{
					AddPolygon(list[0]);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].IsOpen())
				{
					list[j].RemoveEdge(edge);
					RemovePolygon(list[j]);
					if (!list[j].IsEmpty())
					{
						AddPolygon(list[j]);
					}
				}
			}
			if (list.Count == 2 && !list[0].IsOpen() && !list[1].IsOpen())
			{
				if (list[0].plane.IsEquivalent(list[1].plane))
				{
					SegmentPolygons[] array = new SegmentPolygons[2]
					{
						list[0].segments,
						list[1].segments
					};
					SimplePolygon[] array2 = new SimplePolygon[2]
					{
						array[0].GetOutsideLoopPolygon(),
						array[1].GetOutsideLoopPolygon()
					};
					List<SimplePolygon>[] array3 = new List<SimplePolygon>[2]
					{
						array[0].GetHolePolygons(),
						array[1].GetHolePolygons()
					};
					bool[] array4 = new bool[2]
					{
						array2[0].FindOverlappedEdge(edge) != null,
						array2[1].FindOverlappedEdge(edge) != null
					};
					SimplePolygon[] array5 = new SimplePolygon[2]
					{
						(array3[0] == null) ? null : Util.FindPolygonHavingEdge(array3[0], edge),
						(array3[1] == null) ? null : Util.FindPolygonHavingEdge(array3[1], edge)
					};
					if (array4[0] && array4[1])
					{
						RemovePolygon(list[0]);
						RemovePolygon(list[1]);
						array2[0].RemoveEdge(edge);
						array2[1].RemoveEdge(edge);
						HandleOverlappedEdges(array2[0], array2[1], plane);
						array2[0].Attach(array2[1]);
						if (!array2[0].plane.IsTowardSameDirection(plane))
						{
							array2[0].Flip();
						}
						for (int k = 0; k < 2; k++)
						{
							if (array3[k] != null)
							{
								for (int l = 0; l < array3[k].Count; l++)
								{
									array2[0].Attach(array3[k][l].Flip().segments.GetOutsideLoop().vertices);
								}
							}
						}
						array2[0].AssignMatUVInfo(list[0]);
						AddPolygon(array2[0]);
					}
					else if ((array4[0] && array5[1] != null) || (array4[1] && array5[0] != null))
					{
						RemovePolygon(list[0]);
						RemovePolygon(list[1]);
						SimplePolygon simplePolygon2 = ((array5[0] != null) ? array5[0] : array5[1]);
						int num = ((array5[0] != null) ? 1 : 0);
						simplePolygon2.RemoveEdge(edge);
						array2[num].RemoveEdge(edge);
						List<Edge> list2 = array2[num].FindOverlappedEdges(simplePolygon2);
						if (list2 == null || list2.Count < simplePolygon2.GetEdgeCount())
						{
							SimplePolygon simplePolygon3 = new SimplePolygon();
							PlaneEx plane2 = (simplePolygon3.plane = list[0].plane);
							int num2 = 0;
							while (list2 != null && num2 < list2.Count)
							{
								simplePolygon2.RemoveEdge(list2[num2]);
								array2[num].RemoveEdge(list2[num2]);
								simplePolygon3.AddEdge(list2[num2]);
								num2++;
							}
							AddPolygon(simplePolygon3);
							for (int m = 0; m < simplePolygon2.segments.GetLoopCount(); m++)
							{
								Segment loop = simplePolygon2.segments.GetLoop(m);
								SimplePolygon simplePolygon4 = new SimplePolygon(loop.vertices, plane2, open: true);
								for (int n = 0; n < array2[num].segments.GetLoopCount(); n++)
								{
									Segment loop2 = array2[num].segments.GetLoop(n);
									if ((Comparer.IsEquivalent(loop.vertices[0].pos, loop2.vertices[0].pos) && Comparer.IsEquivalent(loop.vertices[loop.vertices.Count - 1].pos, loop2.vertices[loop2.vertices.Count - 1].pos)) || (Comparer.IsEquivalent(loop.vertices[0].pos, loop2.vertices[loop2.vertices.Count - 1].pos) && Comparer.IsEquivalent(loop.vertices[loop.vertices.Count - 1].pos, loop2.vertices[0].pos)))
									{
										simplePolygon4.Attach(new SimplePolygon(loop2.vertices, plane2, open: true));
										break;
									}
								}
								array2[1 - num].Attach(simplePolygon4.Flip());
							}
							for (int num3 = 0; num3 < array3[1 - num].Count; num3++)
							{
								SimplePolygon simplePolygon5 = array3[1 - num][num3];
								if (simplePolygon5.FindOverlappedEdges(simplePolygon2) == null)
								{
									array2[1 - num].Attach(simplePolygon5.Flip());
								}
							}
							array2[1 - num].AssignMatUVInfo(list[0]);
							AddPolygon(array2[1 - num]);
						}
						else
						{
							list[0].Unite(list[1]);
							SimplePolygon simplePolygon6 = new SimplePolygon();
							simplePolygon6.plane = plane;
							for (int num4 = 0; num4 < list2.Count; num4++)
							{
								simplePolygon6.AddEdge(list2[num4]);
							}
							AddPolygon(simplePolygon6);
							AddPolygon(list[0]);
						}
					}
				}
				else
				{
					RemovePolygon(list[0]);
					RemovePolygon(list[1]);
				}
			}
			return true;
		}

		public void RemoveVertex(Vertex vertex)
		{
			VertexInfo vertexInfo = editableMeshCache.FindVertexByPos(vertex.pos);
			if (vertexInfo == null)
			{
				return;
			}
			for (int i = 0; i < vertexInfo.tokens.Count; i++)
			{
				SimplePolygon polygon = vertexInfo.tokens[i].polygon;
				if (!polygon.RemoveVertex(vertex.pos))
				{
					RemovePolygon(polygon);
				}
			}
		}

		public void RemoveVertices(List<Vector3> poses)
		{
			List<SimplePolygon> list = new List<SimplePolygon>();
			foreach (KeyValuePair<Vector3, VertexInfo> item in from a in poses.ToDictionary((Vector3 a) => a, (Vector3 a) => editableMeshCache.FindVertexByPos(a))
				where a.Value != null
				select a)
			{
				VertexInfo value = item.Value;
				for (int num = 0; num < value.tokens.Count; num++)
				{
					SimplePolygon polygon = value.tokens[num].polygon;
					if (polygon != null && !polygon.RemoveVertex(item.Key))
					{
						list.Add(polygon);
					}
				}
			}
			foreach (SimplePolygon item2 in list.Distinct())
			{
				RemovePolygon(item2);
			}
		}

		public void DisableMirrorMode()
		{
			if (shelf != 0)
			{
				return;
			}
			foreach (SimplePolygon item in polygons_[shelf])
			{
				if (item.IsMirrored())
				{
					item.EnableMirrored(mirrored: false);
					if (item.IsUnwrapped())
					{
						uvIslandManager.AddPolygon(item);
					}
				}
			}
		}

		private void HandleOverlappedEdges(SimplePolygon polygon0, SimplePolygon polygon1, PlaneEx plane)
		{
			List<Edge> list = polygon0.FindOverlappedEdges(polygon1);
			SimplePolygon simplePolygon = new SimplePolygon();
			int num = 0;
			while (list != null && num < list.Count)
			{
				polygon0.RemoveEdge(list[num]);
				polygon1.RemoveEdge(list[num]);
				simplePolygon.AddEdge(list[num]);
				num++;
			}
			if (!simplePolygon.IsEmpty())
			{
				simplePolygon.plane = plane;
				AddPolygon(simplePolygon);
			}
		}

		public void Transform(Matrix4x4 tm)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				GetPolygon(i).Transform(tm);
			}
		}

		public void Clear(int inShelf = -1)
		{
			InvalidateCache();
			if (inShelf == -1)
			{
				inShelf = shelf;
			}
			for (int i = 0; i < polygons_[inShelf].Count; i++)
			{
				if (polygons_[inShelf][i] != null)
				{
					smoothingGroups.RemovePolygon(polygons_[inShelf][i]);
					polygonGroupManager.RemovePolygon(polygons_[inShelf][i]);
					uvIslandManager.RemovePolygon(polygons_[inShelf][i]);
				}
			}
			uvIslandManager.RemoveAllEmpty();
			editableMeshCache.ClearShelf(inShelf);
			editableMeshCache.Clear();
			polygons_[inShelf].Clear();
		}

		public bool IsEmpty(int input_shelf = -1)
		{
			if (input_shelf == -1)
			{
				return polygons_[shelf].Count == 0;
			}
			return polygons_[input_shelf].Count == 0;
		}

		public List<SimplePolygon> FindCandidates(SimplePolygon polygon, float epsilon = 0.0001f)
		{
			List<SimplePolygon> list = null;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon2 = GetPolygon(i);
				if (polygon != polygon2 && !polygon2.IsOpen() && polygon2.IsIntersected(polygon))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					list.Add(polygon2);
				}
			}
			return list;
		}

		public void InvalidateCache()
		{
			bsptree3d_ = null;
			aabb_ = null;
			adjacentPolygons_ = null;
			smoothingGroups.Invalidate();
			uvIslandManager.Invalidate();
			using (new ShelfHolder(this))
			{
				for (int i = 0; i < 2; i++)
				{
					shelf = i;
					for (int j = 0; j < GetPolygonCount(); j++)
					{
						GetPolygon(j).InvalidateCacheData();
					}
				}
			}
		}

		public void InvalidateVertexManager()
		{
			editableMeshCache.Clear();
		}

		public void ClipByPlane(PlaneEx plane, out EditableMesh above, out EditableMesh below, out List<Edge> above_facet_edges)
		{
			above = new EditableMesh();
			below = new EditableMesh();
			above_facet_edges = new List<Edge>();
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				SimplePolygon polygon = GetPolygon(i);
				List<Edge> list = new List<Edge>();
				polygon.ClipByPlane(plane, out var abovePolygons, out var belowPolygons, list);
				if (abovePolygons != null)
				{
					above.Join(abovePolygons);
				}
				if (belowPolygons != null)
				{
					below.Join(belowPolygons);
				}
				if (list != null)
				{
					above_facet_edges.AddRange(list);
				}
			}
			if (above_facet_edges.Count == 0)
			{
				above_facet_edges = null;
			}
			if (above.IsEmpty())
			{
				above = null;
			}
			if (below.IsEmpty())
			{
				below = null;
			}
		}

		public void BooleanUnion(EditableMesh editableMesh)
		{
			EditableMesh editableMesh2 = new EditableMesh();
			if (IsEmpty())
			{
				for (int i = 0; i < editableMesh.GetPolygonCount(); i++)
				{
					editableMesh2.AddPolygon(editableMesh.GetPolygon(i).Clone());
				}
			}
			else
			{
				Clip(editableMesh.bsptree3d, EClipObjective.Union0, editableMesh2);
				editableMesh.Clip(bsptree3d, EClipObjective.Union1, editableMesh2);
			}
			Clear();
			for (int j = 0; j < editableMesh2.GetPolygonCount(); j++)
			{
				AddUnitedPolygon(editableMesh2.GetPolygon(j));
			}
		}

		public void BooleanSubtract(EditableMesh editableMesh)
		{
			if (!IsEmpty())
			{
				EditableMesh editableMesh2 = new EditableMesh();
				Clip(editableMesh.bsptree3d, EClipObjective.Subtract0, editableMesh2);
				editableMesh.Clip(bsptree3d, EClipObjective.Subtract1, editableMesh2);
				Clear();
				for (int i = 0; i < editableMesh2.GetPolygonCount(); i++)
				{
					AddUnitedPolygon(editableMesh2.GetPolygon(i));
				}
			}
		}

		public void BooleanIntersection(EditableMesh editableMesh)
		{
			if (!IsEmpty())
			{
				EditableMesh editableMesh2 = new EditableMesh();
				Clip(editableMesh.bsptree3d, EClipObjective.Intersection0, editableMesh2);
				editableMesh.Clip(bsptree3d, EClipObjective.Intersection1, editableMesh2);
				Clear();
				for (int i = 0; i < editableMesh2.GetPolygonCount(); i++)
				{
					AddUnitedPolygon(editableMesh2.GetPolygon(i));
				}
			}
		}

		private void Clip(BSPTree3D bsptree, EClipObjective objective, EditableMesh out_edmesh)
		{
			List<SimplePolygon> convexHulls = GetConvexHulls();
			for (int i = 0; i < convexHulls.Count; i++)
			{
				Partitions3D partitions = bsptree.GetPartitions(convexHulls[i]);
				switch (objective)
				{
				case EClipObjective.Union0:
				case EClipObjective.Union1:
					out_edmesh.Join(partitions.positives);
					if (objective == EClipObjective.Union0)
					{
						out_edmesh.Join(partitions.coPositive);
					}
					break;
				case EClipObjective.Subtract0:
					out_edmesh.Join(partitions.positives);
					out_edmesh.Join(partitions.coNegative);
					break;
				case EClipObjective.Subtract1:
				{
					for (int j = 0; j < partitions.negatives.GetPolygonCount(); j++)
					{
						partitions.negatives.GetPolygon(j).Flip();
					}
					out_edmesh.Join(partitions.negatives);
					break;
				}
				case EClipObjective.Intersection0:
				case EClipObjective.Intersection1:
					out_edmesh.Join(partitions.negatives);
					if (objective == EClipObjective.Intersection0)
					{
						out_edmesh.Join(partitions.coPositive);
					}
					break;
				case EClipObjective.ClipOutside:
					out_edmesh.Join(partitions.negatives);
					break;
				case EClipObjective.ClipInside:
					out_edmesh.Join(partitions.positives);
					break;
				}
			}
		}

		public void SetColor(Color color)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				GetPolygon(i).color = color;
			}
		}

		public void SetMatId(int id)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				GetPolygon(i).matID = id;
			}
		}

		public void SetUVParams(UVParameter uv_param)
		{
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				GetPolygon(i).uvParams = uv_param;
			}
		}
	}
}
