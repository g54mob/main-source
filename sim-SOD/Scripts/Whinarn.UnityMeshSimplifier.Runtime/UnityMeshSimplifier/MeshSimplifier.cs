using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityMeshSimplifier
{
	public sealed class MeshSimplifier
	{
		private const int TriangleEdgeCount = 3;

		private const int TriangleVertexCount = 3;

		private const int EdgeVertexCount = 2;

		private const double DoubleEpsilon = 0.001;

		private static readonly int UVChannelCount;

		private bool verbose;

		private int subMeshCount;

		private int[] subMeshOffsets;

		private ResizableArray<Triangle> triangles;

		private ResizableArray<Vertex> vertices;

		private ResizableArray<Ref> vtx2tris;

		private ResizableArray<Edge> vtx2edges;

		private List<Edge> edgesL;

		private ResizableArray<Edge> edgesRA;

		private const double PenaltyWeightBorder = 20.0;

		private const double PenaltyWeightUVSeamOrFoldover = 10.0;

		private const double DegeneratedTriangleCriteria = 0.9999999999;

		private const double FlippedTriangleCriteria = 0.0;

		private const double RecycleRejectedEdgesThreshold = 0.0025;

		private ResizableArray<Vector3> vertNormals;

		private ResizableArray<Vector4> vertTangents;

		private UVChannels<Vector2> vertUV2D;

		private UVChannels<Vector3> vertUV3D;

		private UVChannels<Vector4> vertUV4D;

		private ResizableArray<Color> vertColors;

		private ResizableArray<BoneWeight> vertBoneWeights;

		private ResizableArray<BlendShapeContainer> blendShapes;

		private Matrix4x4[] bindposes;

		private readonly double[] errArr;

		private readonly int[] attributeIndexArr;

		private readonly HashSet<Triangle> triangleHashSet1;

		private readonly HashSet<Triangle> triangleHashSet2;

		public bool isSkinned;

		public BoneWeight[] boneWeightsOriginal;

		public Matrix4x4[] bindPosesOriginal;

		public Transform[] bonesOriginal;

		public Mesh meshToSimplify;

		public ToleranceSphere[] toleranceSpheres;

		private Dictionary<int, Matrix4x4> transformations;

		private HashSet<object> trianglesInToleranceSpheres;

		private bool isPreservationActive;

		private int once;

		private double vertexLinkDistanceSqr;

		private bool preserveBorderEdges;

		private bool preserveUVSeamEdges;

		private bool preserveUVFoldoverEdges;

		private bool enableSmartLink;

		private bool recalculateNormals;

		private int maxIterationCount;

		private double aggressiveness;

		private bool regardCurvature;

		private bool useSortedEdgeMethod;

		private ToleranceSphere[] spheresToSubtract;

		[Obsolete("Use the 'MeshSimplifier.PreserveBorderEdges' property instead.", false)]
		public bool PreserveBorders
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PreserveBorderEdges
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use the 'MeshSimplifier.PreserveUVSeamEdges' property instead.", false)]
		public bool PreserveSeams
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PreserveUVSeamEdges
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Obsolete("Use the 'MeshSimplifier.PreserveUVFoldoverEdges' property instead.", false)]
		public bool PreserveFoldovers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool PreserveUVFoldoverEdges
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool EnableSmartLink
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RecalculateNormals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int MaxIterationCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public double Aggressiveness
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public bool RegardCurvature
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseSortedEdgeMethod
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Verbose
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public double VertexLinkDistance
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public double VertexLinkDistanceSqr
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		public Vector3[] Vertices
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int SubMeshCount => 0;

		public int BlendShapeCount => 0;

		public Vector3[] Normals
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector4[] Tangents
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV1
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV2
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV3
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV4
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV5
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV6
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV7
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector2[] UV8
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Color[] Colors
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BoneWeight[] BoneWeights
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MeshSimplifier()
		{
		}

		public MeshSimplifier(Mesh mesh)
		{
		}

		private void InitializeVertexAttribute<T>(T[] attributeValues, ref ResizableArray<T> attributeArray, string attributeName)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static double VertexError(SymmetricMatrix q, double x, double y, double z)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private double CurvatureError(ref Vertex vert0, ref Vertex vert1)
		{
			return 0.0;
		}

		private double CalculateError(ref Vertex vert0, ref Vertex vert1, out Vector3d result)
		{
			result = default(Vector3d);
			return 0.0;
		}

		private static void CalculateBarycentricCoords(ref Vector3d point, ref Vector3d a, ref Vector3d b, ref Vector3d c, out Vector3 result)
		{
			result = default(Vector3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static Vector4 NormalizeTangent(Vector4 tangent)
		{
			return default(Vector4);
		}

		private bool Flipped(ref Vector3d p, int i0, int i1, ref Vertex v0, bool[] deleted)
		{
			return false;
		}

		private void UpdateTriangles(int i0, int ia0, ref Vertex v, ResizableArray<bool> deleted, ref int deletedTriangles)
		{
		}

		private void InterpolateVertexAttributes(int dst, int i0, int i1, int i2, ref Vector3 barycentricCoord)
		{
		}

		private bool AreUVsTheSame(int channel, int indexA, int indexB)
		{
			return false;
		}

		private void RemoveVertexPass(int startTrisCount, int targetTrisCount, double threshold, ResizableArray<bool> deleted0, ResizableArray<bool> deleted1, ref int deletedTris, bool isPreservationActive = false)
		{
		}

		private void UpdateMesh(int iteration)
		{
		}

		private void UpdateReferences()
		{
		}

		private void CompactMesh()
		{
		}

		private void CalculateSubMeshOffsets()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void GetTrianglesContainingVertex(ref Vertex vert, HashSet<Triangle> tris)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void GetTrianglesContainingBothVertices(ref Vertex vert0, ref Vertex vert1, HashSet<Triangle> tris)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void CalculateEdgeError(Edge edge)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool ValidateContractionThenUpdateTrisNormals(Edge edge, ref int survivedIndex, ref int deletedIndex, ref List<Triangle> trisTouchingSurvivedVertexOnly, ref List<Triangle> trisTouchingDeletedVertexOnly, ref List<Triangle> trisTouchingBothVertices)
		{
			return false;
		}

		private void CalculateEdgePenaltyMatrix(Triangle t, Edge e)
		{
		}

		private void DistributeEdgePenaltyMatrix(Edge e, Vertex v)
		{
		}

		private void DistributeEdgePenaltyMatrix(Edge e)
		{
		}

		private void InitEdges(out int degeneratedTriangles)
		{
			degeneratedTriangles = default(int);
		}

		private void RemoveEdgePass(int trisToDelete, ref int deletedTris)
		{
		}

		private void SimplifyMeshByEdge(float quality)
		{
		}

		public int[][] GetAllSubMeshTriangles()
		{
			return null;
		}

		public int[] GetSubMeshTriangles(int subMeshIndex)
		{
			return null;
		}

		public void ClearSubMeshes()
		{
		}

		public void AddSubMeshTriangles(int[] triangles)
		{
		}

		public void AddSubMeshTriangles(int[][] triangles)
		{
		}

		public Vector2[] GetUVs2D(int channel)
		{
			return null;
		}

		public Vector3[] GetUVs3D(int channel)
		{
			return null;
		}

		public Vector4[] GetUVs4D(int channel)
		{
			return null;
		}

		public void GetUVs(int channel, List<Vector2> uvs)
		{
		}

		public void GetUVs(int channel, List<Vector3> uvs)
		{
		}

		public void GetUVs(int channel, List<Vector4> uvs)
		{
		}

		public void SetUVs(int channel, Vector2[] uvs)
		{
		}

		public void SetUVs(int channel, Vector3[] uvs)
		{
		}

		public void SetUVs(int channel, Vector4[] uvs)
		{
		}

		public void SetUVs(int channel, List<Vector2> uvs)
		{
		}

		public void SetUVs(int channel, List<Vector3> uvs)
		{
		}

		public void SetUVs(int channel, List<Vector4> uvs)
		{
		}

		public void SetUVsAuto(int channel, List<Vector4> uvs)
		{
		}

		public BlendShape[] GetAllBlendShapes()
		{
			return null;
		}

		public BlendShape GetBlendShape(int blendShapeIndex)
		{
			return default(BlendShape);
		}

		public void ClearBlendShapes()
		{
		}

		public void AddBlendShape(BlendShape blendShape)
		{
		}

		public void AddBlendShapes(BlendShape[] blendShapes)
		{
		}

		public void Initialize(Mesh mesh, bool isPreservationActive = false)
		{
		}

		public void SimplifyMesh(float quality)
		{
		}

		public void SimplifyMeshLossless()
		{
		}

		public Mesh ToMesh()
		{
			return null;
		}

		private bool TriangleLiesInSphere(Triangle triangle)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool VertexLiesInSphere(ToleranceSphere sphere, Triangle containingTri, Vertex vertex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsTriangleInAnyToleranceSphere(Triangle triangle)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private HashSet<Triangle> GetTrianglesContainingVertex(ref Vertex toCheck)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private HashSet<Triangle> GetTrianglesContainingBothVertices(ref Vertex vertex1, ref Vertex vertex2)
		{
			return null;
		}

		private bool TriangleContainsVertex(Triangle triangle, Vertex vertex)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Vector3? GetVertexWorldPosition(Vector3 vertexLocalPosition, BoneWeight bw, BoneWeight[] boneWeights, Matrix4x4[] aBindPoses, Transform[] aBones, Matrix4x4[] transformMatrices)
		{
			return null;
		}
	}
}
