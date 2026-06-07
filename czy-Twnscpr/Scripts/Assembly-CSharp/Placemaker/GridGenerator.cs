using System;
using System.Collections.Generic;
using Placemaker.Quads;
using Placemaker.Quads.GridGeneration;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker
{
	public class GridGenerator : MonoBehaviour
	{
		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		public Transform bitContainer;

		[SerializeField]
		private CustomGridLibrary customGridLibrary;

		[SerializeField]
		private List<GridBit> bits;

		private Dictionary<int2, GridBit> bitDict;

		[SerializeField]
		public List<HexPatch> patches;

		public Dictionary<int2, HexPatch> patchDict;

		[SerializeField]
		private List<HexCluster> clusters;

		private Dictionary<int2, HexCluster> clusterDict;

		[SerializeField]
		private ushort bitProcessIndex;

		[SerializeField]
		private List<float2> deltas;

		[SerializeField]
		public bool focusUpdated;

		private const float bitRadius = 10.510949f;

		private const int bitExtent = 84;

		private static readonly float diagonal;

		private const int relaxIterations = 255;

		private const int bitMeshVertCount = 300;

		private int2 hexOrigo;

		public static float2 HexToPlane(float3 hexPos)
		{
			return default(float2);
		}

		public static float2 HexToPlane(float2 hexPos)
		{
			return default(float2);
		}

		public static float2 HexToPlane(int2 hexPos)
		{
			return default(float2);
		}

		public static float2 HexToPlane(int3 hexPos)
		{
			return default(float2);
		}

		public static float3 PlaneToHex(float2 planePos)
		{
			return default(float3);
		}

		private int3 HexToPatchHex(float3 hexPos)
		{
			return default(int3);
		}

		public int2 HexToPatchHex(int2 hexPos)
		{
			return default(int2);
		}

		public float GetVertCost(float2 hexPos)
		{
			return 0f;
		}

		public void PopulateBorderMesh(Vert vert, Mesh mesh)
		{
		}

		private int3 GetClosestClusterPos(int3 hexPos)
		{
			return default(int3);
		}

		public void HexToPatchHexes(int3 hexPos, out int3x3 patchPositions, out byte mask)
		{
			patchPositions = default(int3x3);
			mask = default(byte);
		}

		public int3 HexToGridCentroid(int3 hexPos)
		{
			return default(int3);
		}

		private bool IsNewGrid(int3 hexPos)
		{
			return false;
		}

		private int GetSubdivisions(int2 hexPos)
		{
			return 0;
		}

		private bool IsBorder(int2 hexPos)
		{
			return false;
		}

		private void OnEnable()
		{
		}

		public int2 GetPatchOffset(int2 clusterPos)
		{
			return default(int2);
		}

		public static int2 GetClusterOffset()
		{
			return default(int2);
		}

		private GridBit MotivateBit(int2 bitPos)
		{
			return null;
		}

		private void UnmotivateBit(GridBit bit)
		{
		}

		private void UnmotivateBitChildren(GridBit bit)
		{
		}

		private HexCluster MotivateCluster(int2 clusterPos, int2 sourcePos)
		{
			return null;
		}

		private void UnmotivateCluster(HexCluster cluster, int2 sourcePos)
		{
		}

		private void UnmotivateClusterChildren(HexCluster cluster)
		{
		}

		private HexPatch MotivatePatch(int2 patchPos, int2 sourcePos)
		{
			return null;
		}

		private void UnmotivatePatch(int2 patchPos, int2 sourcePos)
		{
		}

		private void IteratePatch(HexPatch patch)
		{
		}

		private void IterateCluster(HexCluster cluster, Func<bool> keepGoing)
		{
		}

		public void SceneProcessIteration()
		{
		}

		public void IterateBit(GridBit bit, Func<bool> keepGoing)
		{
		}

		public bool IterateFocus()
		{
			return false;
		}

		public bool IterateGenerateCenter()
		{
			return false;
		}

		private void Measure()
		{
		}

		public bool IterateBits(Func<bool> keepGoing)
		{
			return false;
		}

		public void SetQuadMesh(List<BitMeshQuadChange> changes)
		{
		}

		public Quad GetQuad(int2 hexWithinPatch, int2 corner0, int2 corner1)
		{
			return default(Quad);
		}

		public Quad GetAdjecentQuad(Quad quad)
		{
			return default(Quad);
		}

		public bool AppendQuadList(List<Quad> nodes, Vector2 planeCameraDir, ref int hoverIndex, int steps)
		{
			return false;
		}

		public Quad GetQuad(float2 planePos)
		{
			return default(Quad);
		}

		public Vert GetClostestVertPosition(float2 planePos)
		{
			return default(Vert);
		}

		public Vert GetVertOrIterate(int2 hexPos, Func<bool> keepGoing = null)
		{
			return default(Vert);
		}

		public static int2 GetStartingHex(int onionIndex)
		{
			return default(int2);
		}

		private void OnDrawGizmos()
		{
		}
	}
}
