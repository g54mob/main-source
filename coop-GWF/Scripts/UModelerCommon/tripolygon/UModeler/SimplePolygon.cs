using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace tripolygon.UModeler
{
	[Serializable]
	public class SimplePolygon
	{
		private enum EPolygonPrivateFlag
		{
			Open = 1,
			Convexhull = 2,
			HasHoles = 4,
			NonplanarQuad = 8
		}

		[SerializeField]
		private List<Vertex> vertices_ = new List<Vertex>();

		[SerializeField]
		private List<IndexPair> edges_ = new List<IndexPair>();

		[SerializeField]
		[FormerlySerializedAs("uv_params_")]
		private UVParameter uvParams_ = new UVParameter();

		[SerializeField]
		private PlaneEx plane_;

		[SerializeField]
		[FormerlySerializedAs("mat_id_")]
		private int matID_;

		[SerializeField]
		private EPolygonFlag flags_;

		[SerializeField]
		private ulong instanceID_ = ((UMContext.activeModeler != null) ? UModeler.GenerateID() : 0);

		public ulong groupID;

		private CachedMesh renderableMesh_;

		private AABB aabb_ = new AABB();

		private AABB worldAABB_ = new AABB();

		private AABB uvAABB_ = new AABB();

		private BSPTree2D bsptree_ = new BSPTree2D();

		private SegmentPolygons segments_ = new SegmentPolygons();

		private int privateFlags_;

		private SmallestVertexX smallestX_ = new SmallestVertexX();

		private EPolygonCacheRefreshFlag refreshFlag = EPolygonCacheRefreshFlag.All;

		[NonSerialized]
		private List<SimplePolygon> convexhulls_;

		private bool allowOptimization_ = true;

		public static UVParameter DefaultUVParameter = new UVParameter();

		public static bool flattenEdgesEnable = true;

		public EPolygonFlag flags => flags_;

		public ulong instanceID => instanceID_;

		public bool allowOptimization
		{
			get
			{
				return allowOptimization_;
			}
			set
			{
				allowOptimization_ = value;
			}
		}

		public UVParameter uvParams
		{
			get
			{
				return uvParams_;
			}
			set
			{
				if (value != null)
				{
					uvParams_.Reset(value);
				}
				InvalidateRenderableMesh();
			}
		}

		public PlaneEx plane
		{
			get
			{
				if (plane_ == null)
				{
					plane_ = new PlaneEx();
				}
				return plane_;
			}
			set
			{
				if (value == null)
				{
					plane_ = new PlaneEx();
				}
				else
				{
					plane_ = value.Clone();
				}
			}
		}

		public Color color
		{
			get
			{
				if (vertices_.Count > 0)
				{
					Color color = new Color(0f, 0f, 0f, 0f);
					for (int i = 0; i < vertices_.Count; i++)
					{
						color += vertices_[i].color;
					}
					return color / vertices_.Count;
				}
				return Color.black;
			}
			set
			{
				for (int i = 0; i < vertices_.Count; i++)
				{
					vertices_[i].color = value;
				}
				InvalidateRenderableMesh();
			}
		}

		public int matID
		{
			get
			{
				return matID_;
			}
			set
			{
				matID_ = value;
				InvalidateRenderableMesh();
			}
		}

		public AABB aabb
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.AABB))
				{
					aabb_.Reset();
					for (int i = 0; i < vertices_.Count; i++)
					{
						aabb_.Add(vertices_[i].pos);
					}
				}
				return aabb_;
			}
		}

		public AABB worldAABB
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.WorldAABB))
				{
					worldAABB_.Reset();
					for (int i = 0; i < vertices_.Count; i++)
					{
						worldAABB_.Add(UMContext.activeModeler.worldTM.MultiplyPoint3x4(vertices_[i].pos));
					}
				}
				return worldAABB_;
			}
		}

		public AABB uvAABB
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.UVAABB))
				{
					uvAABB_.Reset();
					for (int i = 0; i < vertices_.Count; i++)
					{
						uvAABB_.Add(vertices_[i].uv);
					}
				}
				return uvAABB_;
			}
		}

		public CachedMesh renderableMesh
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.RenderableMesh))
				{
					if (renderableMesh_ != null)
					{
						renderableMesh_.Clear();
					}
					renderableMesh_ = Triangulator.Triangulate(this, renderableMesh_);
				}
				return renderableMesh_;
			}
		}

		public BSPTree2D bsptree
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.BSPTree))
				{
					bsptree_.Build(this);
				}
				return bsptree_;
			}
		}

		public SegmentPolygons segments
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.Segments))
				{
					segments_.SetSegmentPolygons(this);
				}
				return segments_;
			}
		}

		public List<SimplePolygon> convexhulls
		{
			get
			{
				if (convexhulls_ == null)
				{
					convexhulls_ = new List<SimplePolygon>();
					InvalidateConvexHulls();
				}
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.ConvexHull))
				{
					Triangulator.BreakDownToConvexhulls(this, convexhulls_);
				}
				return convexhulls_;
			}
		}

		public SmallestVertexX smallestVertexX
		{
			get
			{
				if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.SmallestX))
				{
					smallestX_.index = -1;
					smallestX_.x = 3E+10f;
					for (int i = 0; i < GetVertexCount(); i++)
					{
						Vector2 vector = plane.ToPlaneCoord(GetVertex(i).pos);
						if (vector.x < smallestX_.x)
						{
							smallestX_.x = vector.x;
							smallestX_.index = i;
						}
					}
				}
				return smallestX_;
			}
		}

		public List<Vertex> GetVertexList()
		{
			return vertices_;
		}

		public int GetVertexCount()
		{
			return vertices_.Count;
		}

		public List<IndexPair> GetEdgeList()
		{
			return edges_;
		}

		public int GetEdgeCount()
		{
			return edges_.Count;
		}

		public Vertex GetVertex(int idx)
		{
			return vertices_[idx];
		}

		public IndexPair GetEdge(int idx)
		{
			return edges_[idx];
		}

		private void SetInvalidateFlag(EPolygonCacheRefreshFlag flag)
		{
			refreshFlag |= flag;
		}

		public bool RefreshCheck(EPolygonCacheRefreshFlag flag)
		{
			return (refreshFlag & flag) != 0;
		}

		private bool RefreshCheckAndReset(EPolygonCacheRefreshFlag flag)
		{
			bool result = (refreshFlag & flag) != 0;
			refreshFlag &= ~flag;
			return result;
		}

		public SimplePolygon()
		{
			Init();
		}

		public SimplePolygon(List<Vertex> vertices, PlaneEx _plane = null, bool open = false, EPolygonFlag flags = (EPolygonFlag)0)
		{
			Init();
			Set(vertices, _plane, open, flags);
		}

		public SimplePolygon(List<Vector3> positions, PlaneEx _plane = null, bool open = false, EPolygonFlag flags = (EPolygonFlag)0)
		{
			Init();
			Set(positions, _plane, open, flags);
		}

		public SimplePolygon(List<Vertex> vertices, List<IndexPair> edges, PlaneEx _plane = null, EPolygonFlag flags = (EPolygonFlag)0)
		{
			Debug.LogWarning("Waring. this fuction no check Instance ID");
			Init();
			Set(vertices, edges, _plane, flags);
		}

		public SimplePolygon(Vector3 pos0, Vector3 pos1, Vector3 pos2, Vector2 uv0, Vector2 uv1, Vector2 uv2, Color color0, Color color1, Color color2, PlaneEx _plane = null, EPolygonFlag flags = (EPolygonFlag)0)
		{
			Init();
			Set(new List<Vertex>
			{
				new Vertex(pos0, uv0, color0),
				new Vertex(pos1, uv1, color1),
				new Vertex(pos2, uv2, color2)
			}, _plane, open: false, flags);
		}

		public SimplePolygon(BinaryReader binaryReader)
		{
			Read(binaryReader);
		}

		public void Set(List<Vertex> vertices, PlaneEx _plane = null, bool open = false, EPolygonFlag flags = (EPolygonFlag)0)
		{
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < vertices.Count; i++)
			{
				if (!open || i != vertices.Count - 1)
				{
					list.Add(new IndexPair(i, (i + 1) % vertices.Count));
				}
			}
			Elemental_CopyVertices(vertices);
			Elemental_SetEdges(list);
			plane_ = ((_plane == null) ? ResetPlane() : _plane.Clone());
			flags_ = flags;
			if ((flags & EPolygonFlag.UVUnwrapped) == 0)
			{
				ResetUVs();
			}
			Optimize();
		}

		public void Set(List<Vector3> positions, PlaneEx _plane = null, bool open = false, EPolygonFlag flags = (EPolygonFlag)0)
		{
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			for (int i = 0; i < positions.Count; i++)
			{
				list.Add(new Vertex(positions[i]));
				if (!open || i != positions.Count - 1)
				{
					list2.Add(new IndexPair(i, (i + 1) % positions.Count));
				}
			}
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			plane_ = ((_plane == null) ? ResetPlane() : _plane.Clone());
			flags_ = flags;
			if ((flags & EPolygonFlag.UVUnwrapped) == 0)
			{
				ResetUVs();
			}
			Optimize();
		}

		public void Set(List<Vertex> vertices, List<IndexPair> edges, PlaneEx _plane = null, EPolygonFlag flags = (EPolygonFlag)0)
		{
			Elemental_CopyVertices(vertices);
			Elemental_CopyEdges(edges);
			plane_ = ((_plane == null) ? ResetPlane() : _plane.Clone());
			if ((flags & EPolygonFlag.UVUnwrapped) == 0)
			{
				ResetUVs();
			}
			flags_ = flags;
			Optimize();
		}

		private void Read(BinaryReader binaryReader)
		{
			int num = binaryReader.ReadInt32();
			vertices_.Clear();
			vertices_.Capacity = num;
			Vector3 pos = default(Vector3);
			Vector2 uv = default(Vector2);
			Color color = default(Color);
			for (int i = 0; i < num; i++)
			{
				pos.x = binaryReader.ReadSingle();
				pos.y = binaryReader.ReadSingle();
				pos.z = binaryReader.ReadSingle();
				uv.x = binaryReader.ReadSingle();
				uv.y = binaryReader.ReadSingle();
				color.r = binaryReader.ReadSingle();
				color.g = binaryReader.ReadSingle();
				color.b = binaryReader.ReadSingle();
				color.a = binaryReader.ReadSingle();
				vertices_.Add(new Vertex(pos, uv, color));
			}
			int num2 = binaryReader.ReadInt32();
			edges_.Clear();
			edges_.Capacity = num2;
			for (int j = 0; j < num2; j++)
			{
				edges_.Add(new IndexPair(binaryReader.ReadInt32(), binaryReader.ReadInt32()));
			}
			uvParams_.shift.x = binaryReader.ReadSingle();
			uvParams_.shift.y = binaryReader.ReadSingle();
			uvParams_.scale.x = binaryReader.ReadSingle();
			uvParams_.scale.y = binaryReader.ReadSingle();
			uvParams_.rotation = binaryReader.ReadSingle();
			if (binaryReader.ReadBoolean())
			{
				Vector3 in_normal = default(Vector3);
				in_normal.x = binaryReader.ReadSingle();
				in_normal.y = binaryReader.ReadSingle();
				in_normal.z = binaryReader.ReadSingle();
				float d = binaryReader.ReadSingle();
				plane_ = new PlaneEx(in_normal, d);
			}
			else
			{
				plane_ = null;
			}
			matID_ = binaryReader.ReadInt32();
			flags_ = (EPolygonFlag)binaryReader.ReadInt32();
			instanceID_ = binaryReader.ReadUInt64();
		}

		public void Write(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(vertices_.Count);
			for (int i = 0; i < vertices_.Count; i++)
			{
				Vertex vertex = vertices_[i];
				binaryWriter.Write(vertex.pos.x);
				binaryWriter.Write(vertex.pos.y);
				binaryWriter.Write(vertex.pos.z);
				binaryWriter.Write(vertex.uv.x);
				binaryWriter.Write(vertex.uv.y);
				binaryWriter.Write(vertex.color.r);
				binaryWriter.Write(vertex.color.g);
				binaryWriter.Write(vertex.color.b);
				binaryWriter.Write(vertex.color.a);
			}
			binaryWriter.Write(edges_.Count);
			for (int j = 0; j < edges_.Count; j++)
			{
				binaryWriter.Write(edges_[j].i0);
				binaryWriter.Write(edges_[j].i1);
			}
			binaryWriter.Write(uvParams_.shift.x);
			binaryWriter.Write(uvParams_.shift.y);
			binaryWriter.Write(uvParams_.scale.x);
			binaryWriter.Write(uvParams_.scale.y);
			binaryWriter.Write(uvParams_.rotation);
			if (plane_ != null)
			{
				binaryWriter.Write(value: true);
				binaryWriter.Write(plane_.normal.x);
				binaryWriter.Write(plane_.normal.y);
				binaryWriter.Write(plane_.normal.z);
				binaryWriter.Write(plane_.distance);
			}
			else
			{
				binaryWriter.Write(value: false);
			}
			binaryWriter.Write(matID_);
			binaryWriter.Write((int)flags_);
			binaryWriter.Write(instanceID_);
		}

		private void Init()
		{
			uvParams_.Reset(DefaultUVParameter);
		}

		public void SetPos(int vtxIndex, Vector3 pos)
		{
			Vertex vertex = vertices_[vtxIndex];
			if (vertex.pos.x != pos.x || vertex.pos.y != pos.y || vertex.pos.z != pos.z)
			{
				Elemental_SetPos(vtxIndex, pos);
			}
		}

		public void SetUV(int vtxIndex, Vector2 uv)
		{
			Vertex vertex = vertices_[vtxIndex];
			if (vertex.uv.x != uv.x || vertex.uv.y != uv.y)
			{
				Elemental_SetUV(vtxIndex, uv);
			}
		}

		public void SetColor(int vtxIdx, Color color)
		{
			if (!(vertices_[vtxIdx].color == color))
			{
				Elemental_SetColor(vtxIdx, color);
			}
		}

		public void ValidateInstanceID()
		{
			if (instanceID_ == 0L)
			{
				instanceID_ = UModeler.GenerateID();
			}
		}

		public void RegenarateInstanceID()
		{
			instanceID_ = UModeler.GenerateID();
		}

		private void Clear()
		{
			vertices_.Clear();
			edges_.Clear();
			InvalidateCacheData();
		}

		public SimplePolygon Clone()
		{
			SimplePolygon simplePolygon = new SimplePolygon();
			simplePolygon.Elemental_CopyVertices(vertices_);
			simplePolygon.Elemental_CopyEdges(edges_);
			simplePolygon.plane = plane_;
			simplePolygon.uvParams = uvParams;
			simplePolygon.matID = matID;
			simplePolygon.flags_ = flags_;
			simplePolygon.groupID = groupID;
			return simplePolygon;
		}

		public void CloneTo(SimplePolygon clone)
		{
			clone.Clear();
			clone.Elemental_CopyVertices(vertices_);
			clone.Elemental_CopyEdges(edges_);
			clone.plane = plane_;
			clone.uvParams = uvParams;
			clone.matID = matID;
			clone.flags_ = flags_;
			clone.groupID = groupID;
		}

		public SimplePolygon Mirror(PlaneEx mirror_plane)
		{
			for (int i = 0; i < vertices_.Count; i++)
			{
				float t = 0f;
				mirror_plane.RayHit(vertices_[i].pos, mirror_plane.normal, out t);
				vertices_[i].pos += mirror_plane.normal * (2f * t);
			}
			flags_ |= EPolygonFlag.Mirrored;
			ReverseAllEdges();
			plane = GetComputedPlane();
			if (!IsUnwrapped())
			{
				ResetUVs();
			}
			return this;
		}

		public PlaneEx GetComputedPlane()
		{
			if (IsNonplanarQuad())
			{
				PlaneEx planeEx = null;
				Segment outsideLoop = segments.GetOutsideLoop();
				for (int i = 0; i < outsideLoop.vertices.Count; i++)
				{
					if (Mathf.Abs(plane.CalcDistanceToPoint(outsideLoop.vertices[i].pos)) > 0.0001f)
					{
						Vector3 vector = MathUtil.Cross(outsideLoop.vertices[(i - 1 + outsideLoop.vertices.Count) % outsideLoop.vertices.Count].pos, outsideLoop.vertices[i].pos, outsideLoop.vertices[(i + 1) % outsideLoop.vertices.Count].pos);
						Vector3 vector2 = MathUtil.Cross(outsideLoop.vertices[(i + 1) % outsideLoop.vertices.Count].pos, outsideLoop.vertices[(i + 2) % outsideLoop.vertices.Count].pos, outsideLoop.vertices[(i + 3) % outsideLoop.vertices.Count].pos);
						planeEx = new PlaneEx((vector + vector2).normalized, outsideLoop.vertices[i].pos);
						break;
					}
				}
				if (planeEx != null)
				{
					return planeEx;
				}
			}
			return ResetPlane();
		}

		public bool IsEmpty()
		{
			if (vertices_.Count != 0)
			{
				return edges_.Count == 0;
			}
			return true;
		}

		public bool IsValid(bool strict_check = false)
		{
			if (IsEmpty() || plane == null || GetVertexCount() == 1)
			{
				return false;
			}
			if (strict_check)
			{
				SimplePolygon outsideLoopPolygon = segments.GetOutsideLoopPolygon();
				if (outsideLoopPolygon == null)
				{
					return false;
				}
				for (int i = 0; i < outsideLoopPolygon.GetEdgeCount(); i++)
				{
					Edge pureEdge = GetPureEdge(i);
					if (pureEdge.IsPoint())
					{
						return false;
					}
					Edge2D edge2D = new Edge2D(plane.ToPlaneCoord(pureEdge.p0), plane.ToPlaneCoord(pureEdge.p1));
					for (int j = 0; j < outsideLoopPolygon.GetEdgeCount(); j++)
					{
						if (i == j)
						{
							continue;
						}
						Edge pureEdge2 = GetPureEdge(j);
						if (!Comparer.IsEquivalent(pureEdge.p0, pureEdge2.p1) && !Comparer.IsEquivalent(pureEdge.p1, pureEdge2.p0))
						{
							Edge2D edge = new Edge2D(plane.ToPlaneCoord(pureEdge2.p0), plane.ToPlaneCoord(pureEdge2.p1));
							if (edge2D.FindIntersection(edge, out var _))
							{
								return false;
							}
						}
					}
				}
				for (int k = 0; k < segments.GetHoleCount(); k++)
				{
					SimplePolygon holePolygon = segments.GetHolePolygon(k);
					if (!outsideLoopPolygon.AllEdgesIncluded(holePolygon) || !holePolygon.IsValid(strict_check: true))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsCorruptPolygon()
		{
			int count = vertices_.Count;
			for (int i = 0; i < edges_.Count; i++)
			{
				if (count <= edges_[i].i0 || edges_[i].i0 < 0)
				{
					return true;
				}
				if (count <= edges_[i].i1 || edges_[i].i1 < 0)
				{
					return true;
				}
			}
			return false;
		}

		public bool Repair()
		{
			int count = vertices_.Count;
			bool result = false;
			for (int i = 0; i < edges_.Count; i++)
			{
				if (count <= edges_[i].i0 || edges_[i].i0 < 0)
				{
					edges_[i].i0 = 0;
					result = true;
				}
				if (count <= edges_[i].i1 || edges_[i].i1 < 0)
				{
					edges_[i].i1 = 0;
					result = true;
				}
			}
			return result;
		}

		public bool IsOpen()
		{
			if (!CheckPrivateFlags(EPolygonPrivateFlag.Open) && vertices_.Count >= 3)
			{
				return edges_.Count < 3;
			}
			return true;
		}

		public bool IsConvexhull()
		{
			return CheckPrivateFlags(EPolygonPrivateFlag.Convexhull);
		}

		public bool IsTriangle()
		{
			if (vertices_.Count == 3 && edges_.Count == 3)
			{
				return !IsOpen();
			}
			return false;
		}

		public bool IsQuad()
		{
			if (vertices_.Count == 4 && edges_.Count == 4)
			{
				return !IsOpen();
			}
			return false;
		}

		public bool IsNonplanarQuad()
		{
			return CheckPrivateFlags(EPolygonPrivateFlag.NonplanarQuad);
		}

		public bool IsAdjacent(SimplePolygon polygon)
		{
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge pureEdge = polygon.GetPureEdge(i);
				if (ContainsEdge(pureEdge.Invert()))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsUVAdjacent(SimplePolygon polygon)
		{
			if (!aabb.IsIntersectBox2D(polygon.aabb))
			{
				return false;
			}
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Vector2 uv = polygon.vertices_[polygon.edges_[i].i0].uv;
				Vector2 uv2 = polygon.vertices_[polygon.edges_[i].i1].uv;
				for (int j = 0; j < GetEdgeCount(); j++)
				{
					Vector2 uv3 = vertices_[edges_[j].i0].uv;
					Vector2 uv4 = vertices_[edges_[j].i1].uv;
					if ((Comparer.IsEquivalent(uv, uv3) && Comparer.IsEquivalent(uv2, uv4)) || (Comparer.IsEquivalent(uv2, uv3) && Comparer.IsEquivalent(uv, uv4)))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsHoleEdge(Edge edge)
		{
			for (int i = 0; i < segments.GetHoleCount(); i++)
			{
				Segment hole = segments.GetHole(i);
				for (int j = 0; j < hole.vertices.Count; j++)
				{
					Edge rhs = new Edge(hole.vertices[j].pos, hole.vertices[(j + 1) % hole.vertices.Count].pos);
					if (edge.IsEquivalent(rhs))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool IsUVPassed(Vector2 rayOrigin)
		{
			return renderableMesh.IsUVPassed(rayOrigin);
		}

		public bool IsUVOverlapped(Vector2 p0, Vector2 p1)
		{
			for (int i = 0; i < vertices_.Count; i++)
			{
				Vector2 uv = vertices_[i].uv;
				if (uv.x > p0.x && uv.x < p1.x && uv.y > p0.y && uv.y < p1.y)
				{
					return true;
				}
			}
			Vector2[] array = new Vector2[4]
			{
				p0,
				new Vector2(p0.x, p1.y),
				p1,
				new Vector3(p1.x, p0.y)
			};
			int num = 0;
			while (renderableMesh != null && num < renderableMesh.indices.Count)
			{
				int index = renderableMesh.indices[num];
				int index2 = renderableMesh.indices[num + 1];
				int index3 = renderableMesh.indices[num + 2];
				Vector2 uv2 = renderableMesh.vertices[index].uv;
				Vector2 uv3 = renderableMesh.vertices[index2].uv;
				Vector2 uv4 = renderableMesh.vertices[index3].uv;
				for (int j = 0; j < array.Length; j++)
				{
					if (MathUtil.PointInTriangle(array[j], uv2, uv3, uv4))
					{
						return true;
					}
				}
				num += 3;
			}
			for (int k = 0; k < edges_.Count; k++)
			{
				Vector3 vector = vertices_[edges_[k].i0].uv;
				Vector3 vector2 = vertices_[edges_[k].i1].uv;
				vector.z = 1f;
				vector2.z = -1f;
				float dist = 0f;
				if (MathUtil.Raycast(new Ray(vector, vector2 - vector), array[0], array[1], array[2], out dist) || MathUtil.Raycast(new Ray(vector, vector2 - vector), array[0], array[2], array[3], out dist))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasHoles()
		{
			return CheckPrivateFlags(EPolygonPrivateFlag.HasHoles);
		}

		public bool Raycast(Ray ray, out float t, bool excludeBackface = false)
		{
			if (IsOpen())
			{
				if (!plane.Raycast(ray, out t, excludeBackface))
				{
					return false;
				}
				for (int i = 0; i < GetEdgeCount(); i++)
				{
					Edge pureEdge = GetPureEdge(i);
					bool between_edge = false;
					Vector3 vector = ray.origin + ray.direction * t;
					if (pureEdge.FindClosestPos(vector, out var closest_pos, out between_edge) && MathUtil.DistanceOnScreen(vector, closest_pos) < 7f)
					{
						return true;
					}
				}
				return false;
			}
			t = 0f;
			if (renderableMesh == null)
			{
				return false;
			}
			return renderableMesh.Raycast(ray, out t, excludeBackface);
		}

		public bool FindClosestEdge(Vector3 pos, out Edge outClosestEdge, out Vector3 outPosOnEdge)
		{
			outClosestEdge = null;
			outPosOnEdge = Vector3.zero;
			float num = 3E+10f;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (pureEdge.FindClosestPos(pos, out var closest_pos, out var _))
				{
					float num2 = Vector3.Distance(closest_pos, pos);
					if (num2 < num)
					{
						num = num2;
						outClosestEdge = pureEdge;
						outPosOnEdge = closest_pos;
					}
				}
			}
			return num < 3E+10f;
		}

		public Vector2 FindInterpolatedUV(Vector3 pos)
		{
			SimplePolygon outsideLoopPolygon = segments.GetOutsideLoopPolygon();
			if (outsideLoopPolygon.renderableMesh != null && outsideLoopPolygon.renderableMesh.FindFacePassedByRay(new Ray(pos, plane.normal), out var v, out var v2, out var v3))
			{
				Vector3 lhs = pos - v.pos;
				Vector3 vector = v2.pos - v.pos;
				Vector3 vector2 = v3.pos - v.pos;
				float num = Vector3.Dot(vector, vector);
				float num2 = Vector3.Dot(vector2, vector2);
				float num3 = Vector3.Dot(vector, vector2);
				float num4 = Vector3.Dot(lhs, vector);
				float num5 = Vector3.Dot(lhs, vector2);
				float num6 = num * num2 - num3 * num3;
				float num7 = (num2 * num4 - num3 * num5) / num6;
				float num8 = ((0f - num3) * num4 + num * num5) / num6;
				return (1f - num7 - num8) * v.uv + num7 * v2.uv + num8 * v3.uv;
			}
			if (FindClosestEdge(pos, out var outClosestEdge, out var outPosOnEdge))
			{
				float num9 = Vector3.Distance(outPosOnEdge, outClosestEdge.p0) / Vector3.Distance(outClosestEdge.p1, outClosestEdge.p0);
				return outClosestEdge.uv0 + num9 * (outClosestEdge.uv1 - outClosestEdge.uv0);
			}
			return Vector2.zero;
		}

		public bool FindClosestUV(Vector2 pos, out int out_uv_idx)
		{
			out_uv_idx = -1;
			float num = 3E+10f;
			for (int i = 0; i < GetVertexCount(); i++)
			{
				Vector2 uv = GetVertex(i).uv;
				float num2 = Vector2.Distance(pos, uv);
				if (num2 < num)
				{
					num = num2;
					out_uv_idx = i;
				}
			}
			return num < 3E+10f;
		}

		public bool FindClosestUVEdge(Vector2 pos, out IndexPair outClosestEdgeIndexPair, out Vector2 outUVOnClosestEdge)
		{
			outClosestEdgeIndexPair = IndexPair.invalide_pair;
			outUVOnClosestEdge = Vector2.zero;
			float num = 3E+10f;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				IndexPair edge = GetEdge(i);
				if (new Edge(vertices_[edge.i0].uv, vertices_[edge.i1].uv).FindClosestPos(pos, out var closest_pos, out var _))
				{
					float num2 = Vector3.Distance(closest_pos, pos);
					if (num2 < num)
					{
						num = num2;
						outClosestEdgeIndexPair = edge;
						outUVOnClosestEdge = closest_pos;
					}
				}
			}
			return num < 3E+10f;
		}

		public SimplePolygon Flip()
		{
			ReverseAllEdges();
			if (plane_ != null)
			{
				plane_.Flip();
			}
			InvalidateCacheData();
			return this;
		}

		public Vector3 GetCenter()
		{
			if (IsOpen() && segments.GetLoopCount() >= 1)
			{
				List<Vertex> vertices = segments.GetLoop(0).vertices;
				if (vertices.Count % 2 == 1)
				{
					return vertices[vertices.Count / 2].pos;
				}
				return (vertices[vertices.Count / 2 - 1].pos + vertices[vertices.Count / 2].pos) * 0.5f;
			}
			return aabb.GetCenter();
		}

		private void ReverseAllEdges()
		{
			List<IndexPair> list = new List<IndexPair>();
			for (int num = edges_.Count - 1; num >= 0; num--)
			{
				edges_[num].Swap();
				list.Add(edges_[num]);
			}
			Elemental_SetEdges(list);
		}

		public void Project2Plane(PlaneEx inputPlane)
		{
			Project2Plane(inputPlane, inputPlane.normal);
		}

		public void Project2Plane(PlaneEx inputPlane, Vector3 direction)
		{
			if (IsNonplanarQuad() || (plane.normal.x == inputPlane.normal.x && plane.normal.y == inputPlane.normal.y && plane.normal.z == inputPlane.normal.z && plane.distance == inputPlane.distance))
			{
				return;
			}
			for (int i = 0; i < GetVertexCount(); i++)
			{
				Vertex vertex = GetVertex(i);
				float t = 0f;
				if (inputPlane.RayHit(vertex.pos, direction, out t))
				{
					vertex.pos += direction * t;
				}
			}
			bool num = Vector3.Dot(plane.normal, inputPlane.normal) > -0.0001f;
			plane = inputPlane.Clone();
			if (!num)
			{
				ReverseAllEdges();
			}
			InvalidateCacheData();
		}

		public SimplePolygon Scale(float scale, bool[] scaleEdgeFlags = null)
		{
			if (Mathf.Abs(scale) < 0.0001f)
			{
				return this;
			}
			Dictionary<IndexPair, Edge2D> dictionary = new Dictionary<IndexPair, Edge2D>();
			Dictionary<IndexPair, Line2D> dictionary2 = new Dictionary<IndexPair, Line2D>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				Edge2D edge2D = new Edge2D(plane.ToPlaneCoord(pureEdge.p0), plane.ToPlaneCoord(pureEdge.p1));
				dictionary.Add(GetEdge(i), edge2D);
				Line2D line2D = new Line2D(edge2D);
				if (scaleEdgeFlags == null || scaleEdgeFlags[i])
				{
					line2D.distance -= scale;
				}
				dictionary2.Add(GetEdge(i), line2D);
			}
			List<Edge> list = new List<Edge>();
			for (int j = 0; j < GetEdgeCount(); j++)
			{
				FindNeighborEdges(edges_[j], out var outPrevEdge, out var outNextEdge);
				if (outPrevEdge == null || outNextEdge == null)
				{
					continue;
				}
				IndexPair edge = GetEdge(j);
				if (!dictionary2[edge].Intersect(dictionary2[outPrevEdge], out var intersection))
				{
					HitResult hitResult = dictionary2[edge].RayHit(dictionary[edge].p0, dictionary2[edge].normal);
					if (hitResult == null)
					{
						return this;
					}
					intersection = hitResult.pos;
				}
				if (!dictionary2[edge].Intersect(dictionary2[outNextEdge], out var intersection2))
				{
					HitResult hitResult2 = dictionary2[edge].RayHit(dictionary[edge].p1, dictionary2[edge].normal);
					if (hitResult2 == null)
					{
						return this;
					}
					intersection2 = hitResult2.pos;
				}
				Edge edge2 = new Edge(plane.FromPlaneCoord(intersection), plane.FromPlaneCoord(intersection2));
				if (Vector3.Dot(GetPureEdge(j).GetDir(), edge2.GetDir()) <= 0.0001f)
				{
					return null;
				}
				list.Add(edge2);
			}
			Clear();
			for (int k = 0; k < list.Count; k++)
			{
				AddEdge(list[k]);
			}
			Optimize();
			return this;
		}

		public Edge GetPureEdge(int idx)
		{
			IndexPair edge = GetEdge(idx);
			return new ExtendedEdge(GetVertex(edge.i0), GetVertex(edge.i1));
		}

		public Edge2D GetPureEdge2D(int idx)
		{
			IndexPair edge = GetEdge(idx);
			return new Edge2D(plane.ToPlaneCoord(GetVertex(edge.i0).pos), plane.ToPlaneCoord(GetVertex(edge.i1).pos));
		}

		public List<IndexPair> FindEdgesWithVertexIndex(int idx)
		{
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				IndexPair edge = GetEdge(i);
				if (edge.i1 == idx)
				{
					list.Insert(0, edge);
				}
				else if (edge.i0 == idx)
				{
					list.Add(edge);
				}
			}
			return list;
		}

		public List<Edge> FindEdgesConnectedToPos(Vector3 pos)
		{
			List<Edge> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (Comparer.IsEquivalent(pureEdge.p0, pos) || Comparer.IsEquivalent(pureEdge.p1, pos))
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(pureEdge);
				}
			}
			return list;
		}

		public List<Edge> FindEdgesConnectedToEdge(Edge edge)
		{
			List<Edge> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (Comparer.IsEquivalent(pureEdge.p0, edge.p1) || Comparer.IsEquivalent(pureEdge.p1, edge.p0))
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(pureEdge);
				}
			}
			return list;
		}

		public EIntersection IntersectionTest(SimplePolygon polygon)
		{
			if (this == polygon)
			{
				return EIntersection.Intersection;
			}
			if (polygon == null || bsptree == null || IsOpen() || !plane.IsEquivalent(polygon.plane))
			{
				return EIntersection.None;
			}
			if (IsEquivalent(polygon))
			{
				return EIntersection.Intersection;
			}
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				if (bsptree.IsInside(polygon.GetVertex(i).pos))
				{
					return EIntersection.Intersection;
				}
			}
			bool flag = false;
			for (int j = 0; j < polygon.GetEdgeCount(); j++)
			{
				Edge pureEdge = polygon.GetPureEdge(j);
				switch (bsptree.HasIntersection(pureEdge))
				{
				case EIntersection.Intersection:
					return EIntersection.Intersection;
				case EIntersection.Adjacency:
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return EIntersection.None;
			}
			return EIntersection.Adjacency;
		}

		public static EIntersection IntersectionTest(SimplePolygon polygon0, SimplePolygon polygon1)
		{
			if (polygon0 == null || polygon1 == null || !polygon0.plane.IsEquivalent(polygon1.plane) || !polygon0.aabb.IsIntersectBox(polygon1.aabb.Clone().Expand(Vector3.one * 0.001f)))
			{
				return EIntersection.None;
			}
			EIntersection eIntersection = polygon0.IntersectionTest(polygon1);
			EIntersection eIntersection2 = polygon1.IntersectionTest(polygon0);
			if (eIntersection == EIntersection.Intersection || eIntersection2 == EIntersection.Intersection)
			{
				return EIntersection.Intersection;
			}
			if (eIntersection == EIntersection.Adjacency || eIntersection2 == EIntersection.Adjacency)
			{
				return EIntersection.Adjacency;
			}
			return EIntersection.None;
		}

		public bool FindIntersectionsByEdge(Edge edge, out List<KeyValuePair<SimplePolygon, Vector3>> outIntersections)
		{
			outIntersections = null;
			Edge2D edge2D = new Edge2D(plane.ToPlaneCoord(edge.p0), plane.ToPlaneCoord(edge.p1));
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				Edge2D edge2 = new Edge2D(plane.ToPlaneCoord(pureEdge.p0), plane.ToPlaneCoord(pureEdge.p1));
				if (edge2D.FindIntersection(edge2, out var out_intersection))
				{
					if (outIntersections != null)
					{
						outIntersections = new List<KeyValuePair<SimplePolygon, Vector3>>();
					}
					outIntersections.Add(new KeyValuePair<SimplePolygon, Vector3>(this, plane.FromPlaneCoord(out_intersection)));
				}
			}
			return outIntersections != null;
		}

		public bool HasCrossedEdges(SimplePolygon polygon)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					Edge pureEdge2 = polygon.GetPureEdge(j);
					if (Comparer.IsEquivalent(pureEdge.p0, pureEdge2.p1) && Comparer.IsEquivalent(pureEdge.p1, pureEdge2.p0))
					{
						return true;
					}
				}
			}
			return false;
		}

		public List<Edge> FindOverlappedEdges(SimplePolygon polygon)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				List<Edge> list2 = polygon.FindOverlappedEdge(pureEdge);
				if (list2 != null)
				{
					list.AddRange(list2);
				}
			}
			if (list.Count != 0)
			{
				return list;
			}
			return null;
		}

		public List<Edge> FindOverlappedEdge(Edge edge)
		{
			float f = plane.CalcDistanceToPoint(edge.p0);
			float f2 = plane.CalcDistanceToPoint(edge.p1);
			if (!IsOpen() && !IsNonplanarQuad() && (Mathf.Abs(f) >= 0.0001f || Mathf.Abs(f2) >= 0.0001f))
			{
				return null;
			}
			Edge edge2 = edge.Clone().Invert();
			Line2D line2D = new Line2D(new Edge2D(plane.ToPlaneCoord(edge.p0), plane.ToPlaneCoord(edge.p1)));
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				Edge2D edge2D = new Edge2D(plane.ToPlaneCoord(pureEdge.p0), plane.ToPlaneCoord(pureEdge.p1));
				float f3 = line2D.Distance(edge2D.p0);
				float f4 = line2D.Distance(edge2D.p1);
				if (Mathf.Abs(f3) >= 0.0001f || Mathf.Abs(f4) >= 0.0001f)
				{
					continue;
				}
				Edge edge3 = edge.FindInterectedEdge(pureEdge);
				if (edge3 != null && !edge3.IsPoint())
				{
					list.Add(edge3);
					continue;
				}
				edge3 = edge2.FindInterectedEdge(pureEdge);
				if (edge3 != null && !edge3.IsPoint())
				{
					list.Add(edge3);
				}
			}
			if (list.Count != 0)
			{
				return list;
			}
			return null;
		}

		public Edge FindInvertedIdenticalEdge(Edge edge)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (Comparer.IsEquivalent(pureEdge.p0, edge.p1) && Comparer.IsEquivalent(pureEdge.p1, edge.p0))
				{
					return pureEdge;
				}
			}
			return null;
		}

		public bool IsEquivalent(SimplePolygon polygon)
		{
			if (polygon == null)
			{
				return false;
			}
			if (this == polygon)
			{
				return true;
			}
			if (!plane.IsEquivalent(polygon.plane))
			{
				return false;
			}
			if (GetVertexCount() != polygon.GetVertexCount() || GetEdgeCount() != polygon.GetEdgeCount())
			{
				return false;
			}
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge pureEdge = polygon.GetPureEdge(i);
				if (!ContainsEdge(pureEdge))
				{
					return false;
				}
			}
			return true;
		}

		public void RemoveEdge(Edge edge)
		{
			float f = plane.CalcDistanceToPoint(edge.p0);
			float f2 = plane.CalcDistanceToPoint(edge.p1);
			Edge edge2 = edge.Clone().Invert();
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (!edge.IsEquivalent(pureEdge) && !edge2.IsEquivalent(pureEdge))
				{
					list.Add(edges_[i]);
				}
			}
			if (list.Count < GetEdgeCount())
			{
				Elemental_SetEdges(list);
				Optimize();
			}
			else
			{
				if (!IsOpen() && !IsNonplanarQuad() && (Mathf.Abs(f) >= 0.0001f || Mathf.Abs(f2) >= 0.0001f))
				{
					return;
				}
				Edge2D edge3 = new Edge2D(plane.ToPlaneCoord(edge.p0), plane.ToPlaneCoord(edge.p1));
				Line2D line2D = new Line2D(edge3);
				for (int j = 0; j < GetEdgeCount(); j++)
				{
					Edge pureEdge2 = GetPureEdge(j);
					Line2D line2D2 = new Line2D(new Edge2D(plane.ToPlaneCoord(pureEdge2.p0), plane.ToPlaneCoord(pureEdge2.p1)));
					if (Mathf.Abs(line2D2.Distance(edge3.p0)) > 0.0001f || Mathf.Abs(line2D2.Distance(edge3.p1)) > 0.0001f || pureEdge2.FindInterectedEdge(edge) == null)
					{
						continue;
					}
					Elemental_RemoveEdgeAt(j);
					List<Edge> list2 = pureEdge2.SubtractEdge(edge);
					if (list2 == null)
					{
						break;
					}
					bool flag = Vector3.Dot(line2D.normal, line2D2.normal) > 0.0001f;
					for (int k = 0; k < list2.Count; k++)
					{
						if (flag)
						{
							AddEdge(list2[k]);
						}
						else
						{
							AddEdge(list2[k].Invert());
						}
					}
					break;
				}
				ResetUVs();
				Optimize();
			}
		}

		public void RemoveHoles()
		{
			List<Vertex> vertices = segments.GetOutsideLoop().vertices;
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < vertices.Count; i++)
			{
				list.Add(new IndexPair(i, (i + 1) % vertices.Count));
			}
			Elemental_SetVertices(vertices);
			Elemental_SetEdges(list);
		}

		public bool RemoveEdgeIfEdgeIsLink(Edge edge)
		{
			HashSet<int> hashSet = FindLinkEdges();
			if (hashSet.Count == 0)
			{
				return false;
			}
			foreach (int item in hashSet)
			{
				if (GetPureEdge(item).IsEquivalent(edge))
				{
					allowOptimization = false;
					RemoveEdge(edge);
					RemoveEdge(edge.Clone().Invert());
					allowOptimization = true;
					Optimize();
					return true;
				}
			}
			return false;
		}

		public bool RemoveVertex(Vector3 removeVertexPos)
		{
			List<IndexPair> list = null;
			int num = -1;
			Vertex vertex = null;
			Vertex vertex2 = null;
			List<Edge> list2 = new List<Edge>();
			for (int i = 0; i < vertices_.Count; i++)
			{
				if (Comparer.IsEquivalent(vertices_[i].pos, removeVertexPos))
				{
					num = i;
					list = FindEdgesWithVertexIndex(i);
					break;
				}
			}
			if (num == -1 || list == null)
			{
				Debug.LogWarning("Cannot find vertex");
				return true;
			}
			foreach (IndexPair item in list)
			{
				if (item.i0 == num)
				{
					vertex2 = GetVertex(item.i1);
				}
				else if (item.i1 == num)
				{
					vertex = GetVertex(item.i0);
				}
				list2.Add(new ExtendedEdge(GetVertex(item.i0), GetVertex(item.i1)));
			}
			if (vertex == vertex2 && vertex != null)
			{
				return false;
			}
			if (!IsOpen() && edges_.Count - list2.Count <= 1)
			{
				return false;
			}
			if (edges_.Count - list2.Count <= 0)
			{
				return false;
			}
			foreach (Edge item2 in list2)
			{
				RemoveEdge(item2);
			}
			if (vertex != null && vertex2 != null)
			{
				AddEdge(vertex, vertex2);
			}
			Optimize();
			return true;
		}

		public List<Edge> GetLinkEdges()
		{
			List<Edge> list = null;
			foreach (int item in FindLinkEdges())
			{
				if (list == null)
				{
					list = new List<Edge>();
				}
				list.Add(GetPureEdge(item));
			}
			return list;
		}

		private HashSet<int> FindLinkEdges()
		{
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (hashSet.Contains(i))
				{
					continue;
				}
				IndexPair edge = GetEdge(i);
				for (int j = i + 1; j < GetEdgeCount(); j++)
				{
					if (!hashSet.Contains(j))
					{
						IndexPair edge2 = GetEdge(j);
						if (edge.i0 == edge2.i1 && edge.i1 == edge2.i0)
						{
							hashSet.Add(i);
							hashSet.Add(j);
							break;
						}
					}
				}
			}
			return hashSet;
		}

		public void RemoveLinkEdges()
		{
			HashSet<int> hashSet = FindLinkEdges();
			if (hashSet.Count == 0)
			{
				return;
			}
			List<IndexPair> list = new List<IndexPair>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (!hashSet.Contains(i))
				{
					list.Add(GetEdge(i));
				}
			}
			Elemental_SetEdges(list);
			Optimize();
		}

		public SimplePolygon Unite(SimplePolygon BPolygon)
		{
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			if (IsEmpty())
			{
				for (int i = 0; i < BPolygon.GetVertexCount(); i++)
				{
					list.Add(BPolygon.GetVertex(i).Clone());
				}
				for (int j = 0; j < BPolygon.GetEdgeCount(); j++)
				{
					list2.Add(BPolygon.GetEdge(j).Clone());
				}
			}
			else
			{
				Clip(BPolygon.bsptree, EClipObjective.Union0, list, list2);
				BPolygon.Clip(bsptree, EClipObjective.Union1, list, list2);
			}
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			if (!IsUnwrapped() || !BPolygon.IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
			return this;
		}

		public SimplePolygon Subtract(SimplePolygon BPolygon)
		{
			if (IsEmpty() || BPolygon.IsEmpty())
			{
				return this;
			}
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			Clip(BPolygon.bsptree, EClipObjective.Subtract0, list, list2);
			BPolygon.Clip(bsptree, EClipObjective.Subtract1, list, list2);
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			if (!IsUnwrapped() || !BPolygon.IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
			return this;
		}

		public SimplePolygon Intersect(SimplePolygon BPolygon)
		{
			if (IsEmpty())
			{
				return this;
			}
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			if (!BPolygon.IsOpen())
			{
				Clip(BPolygon.bsptree, EClipObjective.Intersection0, list, list2);
			}
			if (!IsOpen())
			{
				BPolygon.Clip(bsptree, EClipObjective.Intersection1, list, list2);
			}
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			if (!IsUnwrapped() || !BPolygon.IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
			return this;
		}

		public SimplePolygon ClipOutside(SimplePolygon BPolygon)
		{
			if (IsEmpty())
			{
				return this;
			}
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			Clip(BPolygon.bsptree, EClipObjective.ClipOutside, list, list2);
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			if (!IsUnwrapped() || !BPolygon.IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
			return this;
		}

		public SimplePolygon ClipInside(SimplePolygon BPolygon)
		{
			if (IsEmpty())
			{
				return this;
			}
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			Clip(BPolygon.bsptree, EClipObjective.ClipInside, list, list2);
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
			if (!IsUnwrapped() || !BPolygon.IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
			return this;
		}

		private void Clip(BSPTree2D clipper, EClipObjective objective, List<Vertex> outVertices, List<IndexPair> outEdges)
		{
			List<Edge> list = new List<Edge>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				Partitions partitions = clipper.GetPartitions(pureEdge);
				switch (objective)
				{
				case EClipObjective.Union0:
				case EClipObjective.Union1:
					list.AddRange(partitions.positives);
					if (objective == EClipObjective.Union0)
					{
						list.AddRange(partitions.coPositive);
					}
					break;
				case EClipObjective.Subtract0:
					list.AddRange(partitions.positives);
					list.AddRange(partitions.coNegative);
					break;
				case EClipObjective.Subtract1:
				{
					for (int j = 0; j < partitions.negatives.Count; j++)
					{
						partitions.negatives[j].Invert();
					}
					list.AddRange(partitions.negatives);
					break;
				}
				case EClipObjective.Intersection0:
				case EClipObjective.Intersection1:
					list.AddRange(partitions.negatives);
					if (objective == EClipObjective.Intersection0)
					{
						list.AddRange(partitions.coPositive);
					}
					break;
				case EClipObjective.ClipOutside:
					list.AddRange(partitions.negatives);
					break;
				case EClipObjective.ClipInside:
					list.AddRange(partitions.positives);
					break;
				}
			}
			foreach (Edge item in list)
			{
				IndexPair indexPair = new IndexPair(AddVertex(outVertices, new Vertex(item.p0, item.uv0)), AddVertex(outVertices, new Vertex(item.p1, item.uv1)));
				if (!indexPair.IsPoint() && !ContainsEdges(outEdges, indexPair))
				{
					outEdges.Add(indexPair);
				}
			}
		}

		public void ClipByPlane(PlaneEx clipPlane, out EditableMesh abovePolygons, out EditableMesh belowPolygons, List<Edge> outAboveFacetEdges = null)
		{
			abovePolygons = new EditableMesh();
			belowPolygons = new EditableMesh();
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < GetVertexCount(); i++)
			{
				float num3 = clipPlane.CalcDistanceToPoint(GetVertex(i).pos);
				if (num3 > 0.0001f)
				{
					num++;
				}
				else if (num3 < -0.0001f)
				{
					num2++;
				}
			}
			if (num == 0 || num2 == 0)
			{
				if (num > 0)
				{
					belowPolygons = null;
					abovePolygons.AddPurePolygon(this);
				}
				else if (num2 > 0)
				{
					abovePolygons = null;
					belowPolygons.AddPurePolygon(this);
				}
				return;
			}
			Util.ClipByPlane(segments.GetOutsideLoop(), clipPlane, out var above, out var below, flags_);
			if (above != null)
			{
				above.SetMatId(matID);
				above.SetUVParams(uvParams);
				abovePolygons.Join(above);
			}
			if (below != null)
			{
				below.SetMatId(matID);
				below.SetUVParams(uvParams);
				belowPolygons.Join(below);
			}
			for (int j = 0; j < segments.GetHoleCount(); j++)
			{
				Util.ClipByPlane(segments.GetHole(j), clipPlane, out var above2, out var below2, flags_);
				if (below2 != null)
				{
					Util.MatchHolesToOutsides(below2, below, clipPlane);
				}
				if (above2 != null)
				{
					Util.MatchHolesToOutsides(above2, above, clipPlane);
				}
			}
			if (outAboveFacetEdges != null && !abovePolygons.IsEmpty())
			{
				for (int k = 0; k < abovePolygons.GetPolygonCount(); k++)
				{
					SimplePolygon polygon = abovePolygons.GetPolygon(k);
					for (int l = 0; l < polygon.GetEdgeCount(); l++)
					{
						Edge pureEdge = polygon.GetPureEdge(l);
						if (Mathf.Abs(clipPlane.CalcDistanceToPoint(pureEdge.p0)) < 0.0001f && Mathf.Abs(clipPlane.CalcDistanceToPoint(pureEdge.p1)) < 0.0001f)
						{
							outAboveFacetEdges.Add(pureEdge);
						}
					}
				}
			}
			if (IsUnwrapped())
			{
				for (int m = 0; m < abovePolygons.GetPolygonCount(); m++)
				{
					abovePolygons.GetPolygon(m).EnableUnwrapped(unwrapped: true);
				}
				for (int n = 0; n < belowPolygons.GetPolygonCount(); n++)
				{
					belowPolygons.GetPolygon(n).EnableUnwrapped(unwrapped: true);
				}
			}
			if (abovePolygons.IsEmpty())
			{
				abovePolygons = null;
			}
			if (belowPolygons.IsEmpty())
			{
				belowPolygons = null;
			}
		}

		public bool ContainsEdge(Edge edge)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (GetPureEdge(i).IsEquivalent(edge))
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsUVEdge(Edge edge)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if ((Comparer.IsEquivalent(pureEdge.uv0, edge.uv0) && Comparer.IsEquivalent(pureEdge.uv1, edge.uv1)) || (Comparer.IsEquivalent(pureEdge.uv0, edge.uv1) && Comparer.IsEquivalent(pureEdge.uv1, edge.uv0)))
				{
					return true;
				}
			}
			return false;
		}

		public void AssignMatUVInfo(SimplePolygon polygon)
		{
			if (polygon != null)
			{
				uvParams = polygon.uvParams;
				matID = polygon.matID;
				GenerateUVs();
			}
		}

		public void AssignInterpolatedUVs(SimplePolygon polygon)
		{
			if (polygon != null && polygon.IsUnwrapped())
			{
				EnableUnwrapped(unwrapped: true);
				for (int i = 0; i < vertices_.Count; i++)
				{
					vertices_[i].uv = polygon.FindInterpolatedUV(vertices_[i].pos);
				}
			}
		}

		public bool IsEdgeIncluded(Edge edge)
		{
			if (ContainsEdge(edge))
			{
				return true;
			}
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (GetPureEdge(i).FindInterectedEdge(edge) != null)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsEdgeCovered(Edge edge)
		{
			if (ContainsEdge(edge))
			{
				return true;
			}
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (pureEdge.FindClosestPos(edge.p0, out var closest_pos, out var between_edge) && pureEdge.FindClosestPos(edge.p1, out var closest_pos2, out var between_edge2) && between_edge && between_edge2 && Comparer.IsEquivalent(closest_pos, edge.p0) && Comparer.IsEquivalent(closest_pos2, edge.p1))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPlaneEquivalent(SimplePolygon polygon)
		{
			if (polygon != null && !polygon.IsOpen() && polygon.plane != null && plane != null)
			{
				return plane.IsEquivalent(polygon.plane);
			}
			return false;
		}

		public bool ContainsPosition(Vector3 pos)
		{
			for (int i = 0; i < GetVertexCount(); i++)
			{
				if (Comparer.IsEquivalent(GetVertex(i).pos, pos))
				{
					return true;
				}
			}
			return false;
		}

		private int AddVertex(List<Vertex> vertices, Vertex v)
		{
			for (int i = 0; i < vertices.Count; i++)
			{
				if (Comparer.IsEquivalent(vertices[i].pos, v.pos))
				{
					return i;
				}
			}
			int count = vertices.Count;
			vertices.Add(v);
			return count;
		}

		public int InsertEdge(Edge e)
		{
			IndexPair indexPair = new IndexPair(-1, -1);
			for (int i = 0; i < 2; i++)
			{
				int vertexIndex = -1;
				List<IndexPair> edgeIndices = null;
				InsertPosition(e[i], out vertexIndex, out edgeIndices, 0.0009999999f);
				vertices_[vertexIndex].uv = e.GetUV(i);
				indexPair.SetIndex(i, vertexIndex);
			}
			if (indexPair.i0 == -1 || indexPair.i1 == -1)
			{
				return -1;
			}
			int count = edges_.Count;
			Elemental_AddEdgeIndexPair(indexPair);
			return count;
		}

		public int AddEdge(Edge e)
		{
			IndexPair indexPair = new IndexPair(-1, -1);
			for (int i = 0; i < 2; i++)
			{
				int num = FindVertexIndex(e[i]);
				if (num == -1)
				{
					num = vertices_.Count;
					vertices_.Add(new Vertex(e[i], e.GetUV(i)));
				}
				indexPair.SetIndex(i, num);
			}
			if (indexPair.i0 == -1 || indexPair.i1 == -1)
			{
				return -1;
			}
			int count = edges_.Count;
			Elemental_AddEdgeIndexPair(indexPair);
			return count;
		}

		public int AddEdge(Vertex v0, Vertex v1)
		{
			Vertex[] array = new Vertex[2] { v0, v1 };
			IndexPair indexPair = new IndexPair(-1, -1);
			for (int i = 0; i < 2; i++)
			{
				int num = FindVertexIndex(array[i].pos);
				if (num == -1)
				{
					num = vertices_.Count;
					vertices_.Add(new Vertex(array[i].pos, array[i].uv));
				}
				indexPair.SetIndex(i, num);
			}
			if (indexPair.i0 == -1 || indexPair.i1 == -1)
			{
				return -1;
			}
			int count = edges_.Count;
			edges_.Add(indexPair);
			InvalidateCacheData();
			return count;
		}

		public void Attach(SimplePolygon polygon)
		{
			if (IsOpen() && polygon.IsOpen())
			{
				List<Vertex> vertices = segments.GetLoop(0).vertices;
				if (Comparer.IsEquivalent(v1: polygon.segments.GetLoop(0).vertices[0].pos, v0: vertices[0].pos))
				{
					polygon = polygon.Clone().Flip();
				}
			}
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				InsertEdge(polygon.GetPureEdge(i));
			}
			PlaneEx computedPlane = GetComputedPlane();
			if (computedPlane != null && !plane.IsTowardSameDirection(computedPlane))
			{
				plane.Flip();
			}
			if (!IsUnwrapped())
			{
				ResetUVs();
			}
			Optimize();
		}

		public void Attach(List<Vertex> polygon)
		{
			for (int i = 0; i < polygon.Count; i++)
			{
				AddEdge(new ExtendedEdge(polygon[i], polygon[(i + 1) % polygon.Count]));
			}
			ResetUVs();
			Optimize();
		}

		public int FindVertexIndex(Vector3 pos)
		{
			for (int i = 0; i < vertices_.Count; i++)
			{
				if (Comparer.IsEquivalent(vertices_[i].pos, pos))
				{
					return i;
				}
			}
			return -1;
		}

		public int FindVertexIndex(Vertex vertex)
		{
			for (int i = 0; i < vertices_.Count; i++)
			{
				if (vertices_[i] == vertex)
				{
					return i;
				}
			}
			return -1;
		}

		private bool ContainsEdges(List<IndexPair> edges, IndexPair input_e)
		{
			foreach (IndexPair edge in edges)
			{
				if ((edge.i0 == input_e.i0 && edge.i1 == input_e.i1) || (edge.i0 == input_e.i1 && edge.i1 == input_e.i0))
				{
					return true;
				}
			}
			return false;
		}

		public void OutputData()
		{
			Debug.Log("SimplePolygon Elements");
			for (int i = 0; i < vertices_.Count; i++)
			{
				if (plane_ != null)
				{
					Debug.Log(plane_.ToPlaneCoord(vertices_[i].pos).ToString());
				}
				else
				{
					Debug.Log(vertices_[i].pos.ToString());
				}
			}
		}

		public bool RayHit(Vector3 origin, Vector3 dir, out float t)
		{
			if (renderableMesh != null)
			{
				return renderableMesh.RayHit(origin, dir, out t);
			}
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (GetPureEdge(i).RayHit(origin, dir, out t))
				{
					return true;
				}
			}
			t = 0f;
			return false;
		}

		public bool IsIntersected(SimplePolygon polygon, float epsilon = 0.002f)
		{
			if (!plane.IsEquivalent(polygon.plane, epsilon))
			{
				return false;
			}
			Partitions partitions = new Partitions();
			partitions.Join(bsptree.GetPartitions(polygon));
			partitions.Join(polygon.bsptree.GetPartitions(this));
			if (partitions.negatives.Count <= 0 && partitions.coNegative.Count <= 0)
			{
				return partitions.coPositive.Count > 0;
			}
			return true;
		}

		public bool IsPosInside(Vector3 pos, bool checkOnEdge = false)
		{
			if (bsptree == null)
			{
				return false;
			}
			if (bsptree.IsInside(pos) || (checkOnEdge && CheckIfPosIsOnEdge(pos)))
			{
				return true;
			}
			return false;
		}

		public bool CheckIfPosIsOnEdge(Vector3 pos)
		{
			Vector2 vector = plane.ToPlaneCoord(pos);
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (GetPureEdge2D(i).Contains(vector))
				{
					return true;
				}
			}
			for (int j = 0; j < GetVertexCount(); j++)
			{
				if (Comparer.IsEquivalent(plane.ToPlaneCoord(GetVertex(j).pos), vector))
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsOnePosAtLeast(SimplePolygon polygon, Vector3 projectionDir, bool checkOnEdge = false)
		{
			for (int i = 0; i < polygon.GetVertexCount(); i++)
			{
				Vertex vertex = polygon.GetVertex(i);
				float t = 0f;
				plane.RayHit(vertex.pos, projectionDir, out t);
				Vector3 pos = vertex.pos + projectionDir * t;
				if (IsPosInside(pos, checkOnEdge))
				{
					return true;
				}
			}
			return false;
		}

		public bool HasDuplicatedVertices()
		{
			for (int i = 0; i < vertices_.Count; i++)
			{
				for (int j = i + 1; j < vertices_.Count; j++)
				{
					if (Comparer.IsEquivalent(vertices_[i].pos, vertices_[j].pos))
					{
						return true;
					}
				}
			}
			return false;
		}

		public List<SimplePolygon> GetIsolatedUnits()
		{
			if (IsOpen() || IsEmpty())
			{
				return null;
			}
			List<SimplePolygon> list = null;
			List<SimplePolygon> list2 = null;
			for (int i = 0; i < segments.GetLoopCount(); i++)
			{
				List<Vertex> vertices = segments.GetLoop(i).vertices;
				if (MathUtil.IsCCW(vertices, plane))
				{
					if (list == null)
					{
						list = new List<SimplePolygon>();
					}
					SimplePolygon simplePolygon = new SimplePolygon();
					simplePolygon.flags_ = flags_;
					for (int j = 0; j < vertices.Count; j++)
					{
						simplePolygon.AddEdge(vertices[j], vertices[(j + 1) % vertices.Count]);
					}
					simplePolygon.plane = plane;
					simplePolygon.groupID = groupID;
					simplePolygon.matID = matID;
					list.Add(simplePolygon);
				}
				else
				{
					if (list2 == null)
					{
						list2 = new List<SimplePolygon>();
					}
					SimplePolygon simplePolygon2 = new SimplePolygon();
					simplePolygon2.flags_ = flags_;
					for (int k = 0; k < vertices.Count; k++)
					{
						simplePolygon2.AddEdge(vertices[k], vertices[(k + 1) % vertices.Count]);
					}
					simplePolygon2.plane = plane;
					simplePolygon2.groupID = groupID;
					simplePolygon2.matID = matID;
					list2.Add(simplePolygon2);
				}
			}
			if (list2 != null && list != null)
			{
				for (int l = 0; l < list.Count; l++)
				{
					SimplePolygon simplePolygon3 = list[l];
					for (int m = 0; m < list2.Count; m++)
					{
						if (simplePolygon3.AllEdgesIncluded(list2[m]))
						{
							simplePolygon3.Attach(list2[m]);
						}
					}
				}
			}
			return list;
		}

		public List<IndexPair> FindNextEdges(IndexPair e)
		{
			List<IndexPair> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (e.i1 == edges_[i].i0 && e.i0 != edges_[i].i1)
				{
					if (list == null)
					{
						list = new List<IndexPair>();
					}
					list.Add(edges_[i]);
				}
			}
			return list;
		}

		public List<IndexPair> FindPrevEdges(IndexPair e)
		{
			List<IndexPair> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (e.i0 == edges_[i].i1 && e.i1 != edges_[i].i0)
				{
					if (list == null)
					{
						list = new List<IndexPair>();
					}
					list.Add(edges_[i]);
				}
			}
			return list;
		}

		private void SearchLinkedColinearEdges(IndexPair edgeIdxPair, EDirection direction, List<IndexPair> outLinkedEdges)
		{
			int num = 0;
			Edge edge = new Edge(vertices_[edgeIdxPair.i0].pos, vertices_[edgeIdxPair.i1].pos);
			Vector3 vector = edge.p1 - edge.p0;
			IndexPair outPrevEdge = null;
			IndexPair outNextEdge = null;
			while (num++ < GetEdgeCount() && FindNeighborEdges(edgeIdxPair, out outPrevEdge, out outNextEdge))
			{
				IndexPair indexPair = ((direction == EDirection.Left) ? outPrevEdge : outNextEdge);
				if (indexPair != null)
				{
					Edge edge2 = new Edge(vertices_[indexPair.i0].pos, vertices_[indexPair.i1].pos);
					Vector3 vector2 = edge2.p1 - edge2.p0;
					if (!(Vector3.Dot(vector.normalized, vector2.normalized) < 0.9999f))
					{
						edgeIdxPair = indexPair;
						outLinkedEdges.Add(edgeIdxPair);
						continue;
					}
					break;
				}
				break;
			}
		}

		public bool FindNeighborEdges(IndexPair edge, out IndexPair outPrevEdge, out IndexPair outNextEdge)
		{
			outPrevEdge = null;
			outNextEdge = null;
			List<IndexPair> list = FindPrevEdges(edge);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (edge.i0 == list[i].i1 && edge.i1 == list[i].i0)
					{
						list.RemoveAt(i);
						break;
					}
				}
				if (list.Count == 1)
				{
					outPrevEdge = list[0];
				}
				else if (list.Count > 1)
				{
					ChoosePrevEdge(edge, list, out outPrevEdge);
				}
			}
			List<IndexPair> list2 = FindNextEdges(edge);
			if (list2 != null)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					if (edge.i0 == list2[j].i1 && edge.i1 == list2[j].i0)
					{
						list2.RemoveAt(j);
						break;
					}
				}
				if (list2.Count == 1)
				{
					outNextEdge = list2[0];
				}
				else if (list2.Count > 1)
				{
					ChooseNextEdge(edge, list2, out outNextEdge);
				}
			}
			if (outPrevEdge == null)
			{
				return outNextEdge != null;
			}
			return true;
		}

		private IndexPair FindExtremeLeftEdge()
		{
			if (!IsOpen())
			{
				return edges_[0];
			}
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				IndexPair edge = GetEdge(i);
				bool flag = false;
				for (int j = 0; j < GetEdgeCount(); j++)
				{
					if (i != j)
					{
						IndexPair edge2 = GetEdge(j);
						if (edge.i0 == edge2.i1)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					return edge;
				}
			}
			return edges_[0];
		}

		private void ChoosePrevEdge(IndexPair edge, List<IndexPair> candidateEdges, out IndexPair outPrevEdge)
		{
			float num = -1.5f;
			float num2 = 1.5f;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < candidateEdges.Count; i++)
			{
				if (candidateEdges[i].i0 == edge.i1)
				{
					continue;
				}
				float num5 = MathUtil.Cosine(vertices_[edge.i1].pos, vertices_[candidateEdges[i].i1].pos, vertices_[candidateEdges[i].i0].pos);
				if (!IsCCW(vertices_[edge.i1], vertices_[candidateEdges[i].i1], vertices_[candidateEdges[i].i0]))
				{
					if (num5 > num)
					{
						num3 = i;
						num = num5;
					}
				}
				else if (num5 < num2)
				{
					num4 = i;
					num2 = num5;
				}
			}
			if (num3 != -1)
			{
				outPrevEdge = candidateEdges[num3];
			}
			else if (num4 != -1)
			{
				outPrevEdge = candidateEdges[num4];
			}
			else
			{
				outPrevEdge = null;
			}
		}

		public void ChooseNextEdge(IndexPair edge, List<IndexPair> candidateEdges, out IndexPair outNextEdge)
		{
			float num = -1.5f;
			float num2 = 1.5f;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < candidateEdges.Count; i++)
			{
				if (candidateEdges[i].i1 == edge.i0)
				{
					continue;
				}
				float num5 = MathUtil.Cosine(vertices_[edge.i0].pos, vertices_[candidateEdges[i].i0].pos, vertices_[candidateEdges[i].i1].pos);
				if (IsCCW(vertices_[edge.i0], vertices_[candidateEdges[i].i0], vertices_[candidateEdges[i].i1]))
				{
					if (num5 > num)
					{
						num3 = i;
						num = num5;
					}
				}
				else if (num5 < num2)
				{
					num4 = i;
					num2 = num5;
				}
			}
			if (num3 != -1)
			{
				outNextEdge = candidateEdges[num3];
			}
			else if (num4 != -1)
			{
				outNextEdge = candidateEdges[num4];
			}
			else
			{
				outNextEdge = null;
			}
		}

		public void SortEdges()
		{
			IndexPair indexPair = FindExtremeLeftEdge();
			IndexPair indexPair2 = indexPair;
			List<Vertex> list = new List<Vertex>();
			List<IndexPair> list2 = new List<IndexPair>();
			IndexPair outNextEdge = indexPair;
			do
			{
				indexPair = outNextEdge;
				list.Add(GetVertex(indexPair.i0));
				FindNeighborEdges(indexPair, out var _, out outNextEdge);
			}
			while (outNextEdge != indexPair2 && outNextEdge != null);
			if (outNextEdge == null)
			{
				list.Add(GetVertex(indexPair.i1));
			}
			for (int i = 0; i < list.Count && (outNextEdge != null || i != list.Count - 1); i++)
			{
				int idx = (i + 1) % list.Count;
				list2.Add(new IndexPair(i, idx));
			}
			Elemental_SetVertices(list);
			Elemental_SetEdges(list2);
		}

		public void Transform(Matrix4x4 tm)
		{
			for (int i = 0; i < GetVertexCount(); i++)
			{
				Vertex vertex = GetVertex(i);
				vertex.pos = tm.MultiplyPoint(vertex.pos);
			}
			InvalidateCacheData();
			PlaneEx computedPlane = GetComputedPlane();
			if (computedPlane != null)
			{
				plane = computedPlane;
			}
		}

		public bool IsPosIncluded(Vector3 pos)
		{
			if (IsOpen())
			{
				return false;
			}
			return bsptree.IsInside(pos);
		}

		public bool AllVerticesIncluded(List<Vertex> vertices)
		{
			if (IsOpen())
			{
				return false;
			}
			for (int i = 0; i < vertices.Count; i++)
			{
				if (!bsptree.IsInside(vertices[i].pos))
				{
					return false;
				}
			}
			return true;
		}

		public bool AtLeastOneVertexIncluded(List<Vertex> vertices)
		{
			if (IsOpen())
			{
				return false;
			}
			for (int i = 0; i < vertices.Count; i++)
			{
				if (bsptree.IsInside(vertices[i].pos))
				{
					return true;
				}
			}
			return false;
		}

		public bool AllEdgesIncluded(SimplePolygon polygon)
		{
			if (IsOpen())
			{
				return false;
			}
			for (int i = 0; i < polygon.GetEdgeCount(); i++)
			{
				Edge pureEdge = polygon.GetPureEdge(i);
				if (!bsptree.IsInside(pureEdge))
				{
					return false;
				}
			}
			return true;
		}

		public bool Included(SimplePolygon polygon)
		{
			if (IsOpen())
			{
				return false;
			}
			return polygon.Clone().Subtract(this).IsEmpty();
		}

		public void ReplaceWith(SimplePolygon polygon)
		{
			Elemental_CopyVertices(polygon.vertices_);
			Elemental_CopyEdges(polygon.edges_);
			if (polygon.plane_ != null)
			{
				plane_ = polygon.plane_.Clone();
			}
			else
			{
				plane_ = null;
			}
			uvParams = polygon.uvParams.Clone();
		}

		public SimplePolygon ProjectTo(PlaneEx toPlane)
		{
			for (int i = 0; i < GetVertexCount(); i++)
			{
				Vertex vertex = GetVertex(i);
				float t = 0f;
				if (toPlane.RayHit(vertex.pos, toPlane.normal, out t))
				{
					vertex.pos += toPlane.normal * t;
				}
			}
			PlaneEx computedPlane = GetComputedPlane();
			if (computedPlane != null && !computedPlane.IsTowardSameDirection(toPlane))
			{
				for (int j = 0; j < edges_.Count; j++)
				{
					edges_[j].Swap();
				}
			}
			plane = toPlane;
			return this;
		}

		public IndexPair FindEdgeIndexPair(Edge edge)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (edge.IsEquivalent(GetPureEdge(i)))
				{
					return edges_[i];
				}
			}
			return null;
		}

		public int FindEdgeIndex(Edge edge)
		{
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				if (edge.IsEquivalent(GetPureEdge(i)))
				{
					return i;
				}
			}
			return -1;
		}

		public IndexPair FindEdgeCrossingPos(Vector3 pos)
		{
			Vector2 pos2 = plane.ToPlaneCoord(pos);
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (new Edge2D(plane.ToPlaneCoord(pureEdge.p0), plane.ToPlaneCoord(pureEdge.p1)).IsInside(pos2))
				{
					return GetEdge(i);
				}
			}
			return null;
		}

		public List<Edge> FindEdgesSharingPos(Vector3 pos)
		{
			List<Edge> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (Comparer.IsEquivalent(pureEdge.p0, pos) || Comparer.IsEquivalent(pureEdge.p1, pos))
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(pureEdge);
				}
			}
			return list;
		}

		public List<Edge> FindDirectionEdgesSharingPos(Vector3 pos, bool isP0)
		{
			List<Edge> list = null;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				if (Comparer.IsEquivalent(isP0 ? pureEdge.p0 : pureEdge.p1, pos))
				{
					if (list == null)
					{
						list = new List<Edge>();
					}
					list.Add(pureEdge);
				}
			}
			return list;
		}

		public List<Edge> FindSharedEdges(SimplePolygon polygon)
		{
			List<Edge> list = null;
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				Edge pureEdge = GetPureEdge(i);
				for (int j = 0; j < polygon.GetEdgeCount(); j++)
				{
					if (hashSet.Contains(j))
					{
						continue;
					}
					Edge pureEdge2 = polygon.GetPureEdge(j);
					if (pureEdge.IsEquivalent(pureEdge2.Invert()))
					{
						if (list == null)
						{
							list = new List<Edge>();
						}
						list.Add(pureEdge2);
						hashSet.Add(j);
						break;
					}
				}
			}
			return list;
		}

		public void Translate(Vector3 offset)
		{
			for (int i = 0; i < GetVertexCount(); i++)
			{
				Elemental_SetPos(i, GetVertex(i).pos + offset);
			}
		}

		public void Optimize()
		{
			if (allowOptimization)
			{
				if (flattenEdgesEnable)
				{
					FlattenEdges();
				}
				RemoveAllInvalidEdges();
				RemoveDuplicatedVertices();
				RemoveUnusedVertices();
				PlaneEx planeEx = ResetPlane();
				if (planeEx != null)
				{
					plane_ = planeEx;
				}
			}
		}

		private bool RemoveAllInvalidEdges()
		{
			int num = edges_.RemoveAll(IsEdgeInvalid);
			InvalidateCacheData();
			return 0 < num;
		}

		private bool IsEdgeInvalid(IndexPair edgeIdx)
		{
			return new Edge(vertices_[edgeIdx.i0].pos, vertices_[edgeIdx.i1].pos).IsPoint();
		}

		private bool FlattenEdges()
		{
			HashSet<int> hashSet = new HashSet<int>();
			HashSet<int> hashSet2 = new HashSet<int>();
			List<IndexPair> list = new List<IndexPair>();
			bool flag = false;
			for (int i = 0; i < GetEdgeCount(); i++)
			{
				IndexPair edge = GetEdge(i);
				if (hashSet.Contains(edge.i0) && hashSet2.Contains(edge.i1))
				{
					continue;
				}
				List<IndexPair> list2 = new List<IndexPair>();
				List<IndexPair> list3 = new List<IndexPair>();
				SearchLinkedColinearEdges(edge, EDirection.Left, list2);
				SearchLinkedColinearEdges(edge, EDirection.Right, list3);
				int i2 = edge.i0;
				int i3 = edge.i1;
				hashSet.Add(edge.i0);
				hashSet2.Add(edge.i1);
				if (list2.Count > 0)
				{
					for (int j = 0; j < list2.Count && !hashSet.Contains(list2[j].i0); j++)
					{
						hashSet2.Add(i2);
						hashSet.Add(list2[j].i0);
						i2 = list2[j].i0;
					}
				}
				if (list3.Count > 0)
				{
					for (int k = 0; k < list3.Count && !hashSet2.Contains(list3[k].i1); k++)
					{
						hashSet.Add(i3);
						hashSet2.Add(list3[k].i1);
						i3 = list3[k].i1;
					}
				}
				if (i2 != edge.i0 || i3 != edge.i1)
				{
					flag = true;
				}
				list.Add(new IndexPair(i2, i3));
			}
			if (flag)
			{
				Elemental_SetEdges(list);
			}
			return flag;
		}

		private void RemoveUnusedVertices()
		{
			List<Vertex> list = new List<Vertex>();
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int i = 0; i < edges_.Count; i++)
			{
				for (int j = 0; j < 2; j++)
				{
					int num = ((j == 0) ? edges_[i].i0 : edges_[i].i1);
					int value;
					if (vertices_.Count <= num || num < 0)
					{
						Debug.LogError($"Wrong edge index. {num}");
						value = ((list.Count > 0) ? (list.Count - 1) : 0);
					}
					else if (!dictionary.TryGetValue(num, out value))
					{
						dictionary.Add(num, value = list.Count);
						list.Add(vertices_[num]);
					}
					if (j == 0)
					{
						edges_[i].i0 = value;
					}
					else
					{
						edges_[i].i1 = value;
					}
				}
			}
			Elemental_SetVertices(list);
		}

		private bool RemoveDuplicatedVertices()
		{
			bool result = false;
			for (int i = 0; i < edges_.Count; i++)
			{
				Vector3 pos = vertices_[edges_[i].i0].pos;
				Vector3 pos2 = vertices_[edges_[i].i1].pos;
				int num = FindVertexIndex(pos);
				int num2 = FindVertexIndex(pos2);
				if (num != edges_[i].i0 || num2 != edges_[i].i1)
				{
					result = true;
				}
				edges_[i].i0 = num;
				edges_[i].i1 = num2;
			}
			return result;
		}

		private bool InsertPosition(Vector3 pos, out int vertexIndex, out List<IndexPair> edgeIndices, float kEpsilon)
		{
			vertexIndex = -1;
			edgeIndices = null;
			for (int i = 0; i < vertices_.Count; i++)
			{
				if (Comparer.IsEquivalent(vertices_[i].pos, pos))
				{
					vertexIndex = i;
					edgeIndices = FindEdgesWithVertexIndex(i);
					if (edgeIndices != null && edgeIndices.Count == 2)
					{
						edgeIndices.RemoveAt(0);
					}
					return true;
				}
			}
			int count = vertices_.Count;
			Vertex vertex = new Vertex(pos);
			vertices_.Add(vertex);
			float num = 3E+10f;
			int num2 = -1;
			for (int j = 0; j < edges_.Count; j++)
			{
				Edge pureEdge = GetPureEdge(j);
				float distance = 0f;
				if (pureEdge.CalculateSquaredDistance(pos, out distance) == EDistanceToEdgeDesc.Middle)
				{
					distance = Mathf.Abs(distance);
					if (distance < num)
					{
						num = distance;
						num2 = j;
					}
				}
			}
			if (num2 != -1 && num < kEpsilon)
			{
				if (edgeIndices == null)
				{
					edgeIndices = new List<IndexPair>();
				}
				if (IsUnwrapped())
				{
					Vertex vertex2 = vertices_[edges_[num2].i0];
					Vertex vertex3 = vertices_[edges_[num2].i1];
					float num3 = Vector3.Distance(vertex.pos, vertex2.pos) / Vector3.Distance(vertex2.pos, vertex3.pos);
					vertex.uv = vertex2.uv + (vertex3.uv - vertex2.uv) * num3;
				}
				IndexPair item = new IndexPair(count, edges_[num2].i1);
				edges_.Add(item);
				edges_[num2].i1 = count;
				edgeIndices.Add(item);
			}
			vertexIndex = count;
			return true;
		}

		private SimplePolygon ConvertSerialVerticesToPolygon(List<Vertex> vertices)
		{
			SimplePolygon simplePolygon = new SimplePolygon(vertices, null, open: false, flags_);
			if (simplePolygon.plane != null)
			{
				if (simplePolygon.plane.IsTowardSameDirection(plane))
				{
					for (int i = 0; i < segments.GetHoleCount(); i++)
					{
						Segment hole = segments.GetHole(i);
						if (simplePolygon.AllVerticesIncluded(hole.vertices))
						{
							simplePolygon.Attach(hole.vertices);
						}
					}
				}
				else
				{
					simplePolygon = segments.GetOutsideLoopPolygon();
					simplePolygon.Attach(vertices);
					for (int j = 0; j < segments.GetHoleCount(); j++)
					{
						Segment hole2 = segments.GetHole(j);
						if (simplePolygon.AllVerticesIncluded(hole2.vertices))
						{
							simplePolygon.Attach(hole2.vertices);
						}
					}
				}
				simplePolygon.plane = plane;
			}
			simplePolygon.Optimize();
			return simplePolygon;
		}

		public List<SimplePolygon> GetPolygonsCutByOpenPolyon(List<SimplePolygon> openPolygons)
		{
			SimplePolygon simplePolygon = Clone();
			List<int[]> list = new List<int[]>();
			List<IndexPair[]> list2 = new List<IndexPair[]>();
			List<List<IndexPair>[]> list3 = new List<List<IndexPair>[]>();
			List<SimplePolygon> list4 = new List<SimplePolygon>();
			for (int i = 0; i < openPolygons.Count; i++)
			{
				list.Add(new int[2] { -1, -1 });
				list2.Add(new IndexPair[2]);
				list3.Add(new List<IndexPair>[2]);
				SimplePolygon simplePolygon2 = openPolygons[i];
				if (simplePolygon2.IsOpen())
				{
					simplePolygon2 = simplePolygon2.Clone().Intersect(this);
					if (!simplePolygon2.IsEmpty())
					{
						simplePolygon2.SortEdges();
						list4.Add(simplePolygon2);
						Vector3 p = simplePolygon2.GetPureEdge(0).p0;
						Vector3 p2 = simplePolygon2.GetPureEdge(simplePolygon2.GetEdgeCount() - 1).p1;
						simplePolygon.InsertPosition(p, out list[i][0], out list3[i][0], 0.0019999999f);
						simplePolygon.InsertPosition(p2, out list[i][1], out list3[i][1], 0.0019999999f);
					}
				}
			}
			List<SimplePolygon> list5 = new List<SimplePolygon>();
			for (int j = 0; j < list4.Count; j++)
			{
				SimplePolygon simplePolygon3 = list4[j];
				SimplePolygon simplePolygon4 = simplePolygon;
				for (int k = 0; k < 2; k++)
				{
					if (list3[j][k] != null)
					{
						if (list3[j][k].Count > 1)
						{
							simplePolygon4.ChooseNextEdge(new IndexPair(list[j][1 - k], list[j][k]), list3[j][k], out list2[j][k]);
						}
						else if (list3[j][k].Count == 1)
						{
							list2[j][k] = list3[j][k][0];
						}
					}
				}
				if (list2[j][0] == null || list2[j][1] == null)
				{
					continue;
				}
				List<Vertex> vertices = new List<Vertex>();
				switch (simplePolygon4.TrackSerialVertices(list2[j][0], list2[j][1], out vertices))
				{
				case ETrackingResult.EndAtLastEdge:
				{
					for (int num = simplePolygon3.GetVertexCount() - 2; num >= 1; num--)
					{
						vertices.Add(simplePolygon3.GetVertex(num).Clone());
					}
					SimplePolygon simplePolygon5 = ConvertSerialVerticesToPolygon(vertices);
					simplePolygon5.AssignMatUVInfo(this);
					list5.Add(simplePolygon5);
					simplePolygon4.TrackSerialVertices(list2[j][1], list2[j][0], out vertices);
					for (int m = 1; m < simplePolygon3.GetVertexCount() - 1; m++)
					{
						vertices.Add(simplePolygon3.GetVertex(m).Clone());
					}
					simplePolygon5 = ConvertSerialVerticesToPolygon(vertices);
					simplePolygon5.AssignMatUVInfo(this);
					list5.Add(simplePolygon5);
					break;
				}
				case ETrackingResult.EndAtFirstEdge:
				{
					for (int l = 0; l < simplePolygon3.GetVertexCount() - 1; l++)
					{
						Vertex vertex = simplePolygon3.GetVertex(l);
						Vertex vertex2 = simplePolygon3.GetVertex(l + 1);
						simplePolygon4.AddEdge(new ExtendedEdge(vertex, vertex2));
						simplePolygon4.AddEdge(new ExtendedEdge(vertex2, vertex));
					}
					simplePolygon4.AssignMatUVInfo(this);
					list5.Add(simplePolygon4);
					break;
				}
				}
			}
			if (list5.Count != 0)
			{
				return list5;
			}
			return null;
		}

		private ETrackingResult TrackSerialVertices(IndexPair firstEdge, IndexPair lastEdge, out List<Vertex> vertices)
		{
			vertices = new List<Vertex>();
			vertices.Add(GetVertex(firstEdge.i0));
			int num = 0;
			IndexPair indexPair = firstEdge;
			IndexPair outPrevEdge = null;
			IndexPair outNextEdge = null;
			while (FindNeighborEdges(indexPair, out outPrevEdge, out outNextEdge) && outNextEdge != null)
			{
				indexPair = outNextEdge;
				vertices.Add(GetVertex(indexPair.i0).Clone());
				if (indexPair.IsEquivalent(firstEdge))
				{
					return ETrackingResult.EndAtFirstEdge;
				}
				if (indexPair.IsEquivalent(lastEdge))
				{
					return ETrackingResult.EndAtLastEdge;
				}
				if (++num > edges_.Count)
				{
					break;
				}
			}
			return ETrackingResult.Fail;
		}

		private void Elemental_SetVertices(List<Vertex> vertices)
		{
			if (vertices_ != vertices)
			{
				vertices_ = vertices;
				InvalidateCacheData();
			}
		}

		private void Elemental_SetPos(int vtxIndex, Vector3 pos)
		{
			if (!Comparer.IsEquivalent(vertices_[vtxIndex].pos, pos))
			{
				vertices_[vtxIndex].pos = pos;
				InvalidateCacheData();
			}
		}

		private void Elemental_SetUV(int vtxIndex, Vector2 uv)
		{
			if (!Comparer.IsEquivalent(vertices_[vtxIndex].uv, uv))
			{
				vertices_[vtxIndex].uv = uv;
				InvalidateCacheData();
			}
		}

		private void Elemental_SetColor(int vtxIndex, Color color)
		{
			if (vertices_[vtxIndex].color != color)
			{
				vertices_[vtxIndex].color = color;
				InvalidateCacheData();
			}
		}

		private void Elemental_SetEdges(List<IndexPair> edges)
		{
			if (edges_ != edges)
			{
				edges_ = edges;
				InvalidateCacheData();
			}
		}

		private void Elemental_CopyVertices(List<Vertex> vertices)
		{
			vertices_.Clear();
			for (int i = 0; i < vertices.Count; i++)
			{
				vertices_.Add(new Vertex(vertices[i]));
			}
			InvalidateCacheData();
		}

		private void Elemental_CopyEdges(List<IndexPair> edges)
		{
			edges_.Clear();
			for (int i = 0; i < edges.Count; i++)
			{
				edges_.Add(edges[i].Clone());
			}
			InvalidateCacheData();
		}

		private void Elemental_RemoveEdgeAt(int index)
		{
			edges_.RemoveAt(index);
			InvalidateCacheData();
		}

		private void Elemental_AddEdgeIndexPair(IndexPair pair)
		{
			edges_.Add(pair);
			InvalidateCacheData();
		}

		public void InvalidateCacheData()
		{
			InvalidateRenderableMesh();
			InvalidateAABB();
			InvalidateWorldAABB();
			InvalidateUVAABB();
			InvalidateBSPTree();
			InvalidateSegments();
			InvalidatePrivateFlags();
			InvalidateConvexHulls();
			InvalidateSmallestX();
			if (plane_ != null)
			{
				plane_.Invalidate();
			}
		}

		private bool IsCCW(Vertex v0, Vertex v1, Vertex v2)
		{
			Vector3 vector = plane.ToPlaneCoord(v0.pos);
			Vector3 vector2 = plane.ToPlaneCoord(v1.pos);
			Vector3 vector3 = plane.ToPlaneCoord(v2.pos);
			Vector3 lhs = Vector3.Normalize(vector - vector2);
			Vector3 rhs = Vector3.Normalize(vector3 - vector2);
			return Vector3.Cross(lhs, rhs).z < 0f;
		}

		private bool CheckPrivateFlags(EPolygonPrivateFlag flags)
		{
			if (RefreshCheckAndReset(EPolygonCacheRefreshFlag.PrivateFlags))
			{
				privateFlags_ = 0;
				if (segments.open)
				{
					privateFlags_ |= 1;
				}
				else if (segments.GetLoopCount() > 1)
				{
					privateFlags_ |= 4;
				}
				if (CheckConvexhull())
				{
					privateFlags_ |= 2;
				}
				if (vertices_.Count == 4 && edges_.Count == 4 && (privateFlags_ & 1) == 0)
				{
					for (int i = 0; i < vertices_.Count; i++)
					{
						if (plane != null && !Comparer.IsEquivalent(plane.CalcDistanceToPoint(vertices_[i].pos), 0f))
						{
							privateFlags_ |= 8;
							break;
						}
					}
				}
			}
			return ((uint)flags & (uint)privateFlags_) != 0;
		}

		private bool CheckConvexhull()
		{
			if (!IsOpen() && vertices_.Count == 3)
			{
				return true;
			}
			if (segments.GetHoleCount() > 0 || segments.GetOutsideLoop() == null)
			{
				return false;
			}
			return MathUtil.IsConvexhull(segments.GetOutsideLoop().vertices, plane);
		}

		public void ResetUVs(bool isResetDefaultParameter = false)
		{
			flags_ &= (EPolygonFlag)(-2);
			if (isResetDefaultParameter)
			{
				uvParams.Reset(DefaultUVParameter);
			}
			GenerateUVs();
		}

		public void GenerateUVs()
		{
			if (plane != null && !IsUnwrapped())
			{
				for (int i = 0; i < vertices_.Count; i++)
				{
					vertices_[i].uv = UVUtil.CalcTexCoords(vertices_[i].pos, plane.normal);
					vertices_[i].uv = UVUtil.TransformUV(vertices_[i].uv, uvParams, Vector2.one * 0.5f);
				}
				InvalidateRenderableMesh();
			}
		}

		private PlaneEx ResetPlane()
		{
			if (Util.IsOpenPolygon(this))
			{
				return plane_;
			}
			SimplePolygon simplePolygon = Clone();
			simplePolygon.RemoveLinkEdges();
			return MathUtil.ComputePlane(simplePolygon.vertices_, simplePolygon.edges_);
		}

		public List<Vertex> FindVerticesOnEdge(Edge e)
		{
			List<Vertex> list = null;
			foreach (Vertex item in vertices_)
			{
				if (e.CalculateSquaredDistance(item.pos, out var distance) == EDistanceToEdgeDesc.Middle && distance < 0.0001f)
				{
					if (list == null)
					{
						list = new List<Vertex>();
					}
					list.Add(item);
				}
			}
			return list;
		}

		public void EnableUnwrapped(bool unwrapped)
		{
			if (unwrapped)
			{
				flags_ |= EPolygonFlag.UVUnwrapped;
			}
			else
			{
				ResetUVs();
			}
		}

		public bool IsUnwrapped()
		{
			return (flags_ & EPolygonFlag.UVUnwrapped) != 0;
		}

		public void EnableMirrored(bool mirrored)
		{
			if (mirrored)
			{
				flags_ |= EPolygonFlag.Mirrored;
			}
			else
			{
				flags_ &= (EPolygonFlag)(-5);
			}
		}

		public bool IsMirrored()
		{
			return (flags_ & EPolygonFlag.Mirrored) != 0;
		}

		public void EnableSelection(bool selected)
		{
			if (selected)
			{
				flags_ |= EPolygonFlag.Selected;
			}
			else
			{
				flags_ &= (EPolygonFlag)(-3);
			}
		}

		public bool IsSelected()
		{
			return (flags_ & EPolygonFlag.Selected) != 0;
		}

		public void LockAutoHotspot(bool locked)
		{
			if (locked)
			{
				flags_ |= EPolygonFlag.LockAutoHotspot;
			}
			else
			{
				flags_ &= (EPolygonFlag)(-9);
			}
		}

		public bool IsLockAutoHotspot()
		{
			return (flags_ & EPolygonFlag.LockAutoHotspot) != 0;
		}

		private void InvalidateRenderableMesh()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.RenderableMesh);
		}

		private void InvalidateAABB()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.AABB);
		}

		private void InvalidateWorldAABB()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.WorldAABB);
		}

		private void InvalidateUVAABB()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.UVAABB);
		}

		private void InvalidateBSPTree()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.BSPTree);
		}

		private void InvalidateSegments()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.Segments);
		}

		private void InvalidatePrivateFlags()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.PrivateFlags);
		}

		private void InvalidateConvexHulls()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.ConvexHull);
		}

		private void InvalidateSmallestX()
		{
			SetInvalidateFlag(EPolygonCacheRefreshFlag.SmallestX);
		}
	}
}
