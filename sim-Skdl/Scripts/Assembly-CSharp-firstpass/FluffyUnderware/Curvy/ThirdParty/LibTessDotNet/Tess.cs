using System;
using System.Collections.Generic;
using ToolBuddy.Pooling.Collections;

namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	public class Tess
	{
		internal class ActiveRegion
		{
			internal MeshUtils.Edge _eUp;

			internal Dict<ActiveRegion>.Node _nodeUp;

			internal int _windingNumber;

			internal bool _inside;

			internal bool _sentinel;

			internal bool _dirty;

			internal bool _fixUpperEdge;
		}

		private LTMesh _mesh;

		private Vec3 _normal;

		private Vec3 _sUnit;

		private Vec3 _tUnit;

		private float _bminX;

		private float _bminY;

		private float _bmaxX;

		private float _bmaxY;

		private WindingRule _windingRule;

		private Dict<ActiveRegion> _dict;

		private PriorityQueue<MeshUtils.Vertex> _pq;

		private MeshUtils.Vertex _event;

		private CombineCallback _combineCallback;

		private ContourVertex[] _vertices;

		private int _vertexCount;

		private SubArray<int>? elementsList;

		private int _elementCount;

		public float SUnitX;

		public float SUnitY;

		public float SentinelCoord;

		public bool NoEmptyPolygons;

		public bool UsePooling;

		public Vec3 Normal
		{
			get
			{
				return default(Vec3);
			}
			set
			{
			}
		}

		public ContourVertex[] Vertices => null;

		public int VertexCount => 0;

		[Obsolete("Use ElementsArray instead")]
		public int[] Elements => null;

		[Obsolete("Use ElementsArray instead")]
		public IList<int> ElementsList => null;

		public SubArray<int>? ElementsArray => null;

		public int ElementCount => 0;

		private ActiveRegion RegionBelow(ActiveRegion reg)
		{
			return null;
		}

		private ActiveRegion RegionAbove(ActiveRegion reg)
		{
			return null;
		}

		private bool EdgeLeq(ActiveRegion reg1, ActiveRegion reg2)
		{
			return false;
		}

		private void DeleteRegion(ActiveRegion reg)
		{
		}

		private void FixUpperEdge(ActiveRegion reg, MeshUtils.Edge newEdge)
		{
		}

		private ActiveRegion TopLeftRegion(ActiveRegion reg)
		{
			return null;
		}

		private ActiveRegion TopRightRegion(ActiveRegion reg)
		{
			return null;
		}

		private ActiveRegion AddRegionBelow(ActiveRegion regAbove, MeshUtils.Edge eNewUp)
		{
			return null;
		}

		private void ComputeWinding(ActiveRegion reg)
		{
		}

		private void FinishRegion(ActiveRegion reg)
		{
		}

		private MeshUtils.Edge FinishLeftRegions(ActiveRegion regFirst, ActiveRegion regLast)
		{
			return null;
		}

		private void AddRightEdges(ActiveRegion regUp, MeshUtils.Edge eFirst, MeshUtils.Edge eLast, MeshUtils.Edge eTopLeft, bool cleanUp)
		{
		}

		private void SpliceMergeVertices(MeshUtils.Edge e1, MeshUtils.Edge e2)
		{
		}

		private void VertexWeights(MeshUtils.Vertex isect, MeshUtils.Vertex org, MeshUtils.Vertex dst, out float w0, out float w1)
		{
			w0 = default(float);
			w1 = default(float);
		}

		private void GetIntersectData(MeshUtils.Vertex isect, MeshUtils.Vertex orgUp, MeshUtils.Vertex dstUp, MeshUtils.Vertex orgLo, MeshUtils.Vertex dstLo)
		{
		}

		private bool CheckForRightSplice(ActiveRegion regUp)
		{
			return false;
		}

		private bool CheckForLeftSplice(ActiveRegion regUp)
		{
			return false;
		}

		private bool CheckForIntersect(ActiveRegion regUp)
		{
			return false;
		}

		private void WalkDirtyRegions(ActiveRegion regUp)
		{
		}

		private void ConnectRightVertex(ActiveRegion regUp, MeshUtils.Edge eBottomLeft)
		{
		}

		private void ConnectLeftDegenerate(ActiveRegion regUp, MeshUtils.Vertex vEvent)
		{
		}

		private void ConnectLeftVertex(MeshUtils.Vertex vEvent)
		{
		}

		private void SweepEvent(MeshUtils.Vertex vEvent)
		{
		}

		private void AddSentinel(float smin, float smax, float t)
		{
		}

		private void InitEdgeDict()
		{
		}

		private void DoneEdgeDict()
		{
		}

		private void RemoveDegenerateEdges()
		{
		}

		private void InitPriorityQ()
		{
		}

		private void DonePriorityQ()
		{
		}

		private void RemoveDegenerateFaces()
		{
		}

		protected void ComputeInterior()
		{
		}

		private void ComputeNormal(ref Vec3 norm)
		{
		}

		private void CheckOrientation()
		{
		}

		private void ProjectPolygon()
		{
		}

		private void TessellateMonoRegion(MeshUtils.Face face)
		{
		}

		private void TessellateInterior()
		{
		}

		private void DiscardExterior()
		{
		}

		private void SetWindingNumber(int value, bool keepOnlyBoundary)
		{
		}

		private int GetNeighbourFace(MeshUtils.Edge edge)
		{
			return 0;
		}

		private void OutputPolymesh(ElementType elementType, int polySize)
		{
		}

		private void OutputContours()
		{
		}

		private float SignedArea(ContourVertex[] vertices)
		{
			return 0f;
		}

		public void AddContour(ContourVertex[] vertices)
		{
		}

		public void AddContour(ContourVertex[] vertices, ContourOrientation forceOrientation)
		{
		}

		public void Tessellate(WindingRule windingRule, ElementType elementType, int polySize)
		{
		}

		public void Tessellate(WindingRule windingRule, ElementType elementType, int polySize, CombineCallback combineCallback)
		{
		}
	}
}
