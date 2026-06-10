using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Map
{
	public class GrassChunk
	{
		private const float MaxZCullDistance = 100f;

		private const float MaxZCullDistanceSqr = 10000f;

		private int sizeX;

		private int sizeY;

		private int sizeZ;

		private int x;

		private int y;

		private int z;

		private Vector3 worldPosition;

		private bool isChunkVisible;

		private Bounds boundsWorldSpace;

		private readonly List<Matrix4x4> grassMatrices = new List<Matrix4x4>();

		private readonly List<int> grassIndices = new List<int>();

		private readonly HashSet<int> grassIndicesSet = new HashSet<int>();

		public static float WorldLayerLevel;

		public static Plane[] CurrentCameraFrustumPlanes = new Plane[6];

		public static Vector3 CurrentCameraWorldPosition;

		public static Material Material;

		public static Mesh Mesh;

		public static RenderParams RenderParams;

		private string name;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			Material = null;
			Mesh = null;
			RenderParams = default(RenderParams);
			WorldLayerLevel = 0f;
			CurrentCameraFrustumPlanes = new Plane[6];
			CurrentCameraWorldPosition = Vector3.zero;
		}

		public void Setup(int x, int y, int z, int sizeX, int sizeY, int sizeZ)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.sizeX = sizeX;
			this.sizeY = sizeY;
			this.sizeZ = sizeZ;
			worldPosition = GridUtils.GetWorldPosition(x, y, z);
			Vector3 vector = new Vector3(sizeX, (float)sizeY * 3f, sizeZ);
			boundsWorldSpace = new Bounds(worldPosition - Vector3.one * 0.5f + vector / 2f, vector);
			name = $"Grass Chunk ({x / sizeX}, {y / sizeY}, {z / sizeZ})";
		}

		public void AddNode(int index)
		{
			if (grassIndicesSet.Add(index))
			{
				grassIndices.Add(index);
				Matrix4x4 item = Matrix4x4.TRS(GridUtils.GetWorldPosition(GridDataIndexTools.FastTo3DIndex(index)), Quaternion.identity, new Vector3(1f, 1f, 1f));
				grassMatrices.Add(item);
			}
		}

		public void RemoveNode(int index)
		{
			if (grassIndicesSet.Remove(index))
			{
				int num = grassIndices.IndexOf(index);
				if (num != -1)
				{
					grassIndices.RemoveAt(num);
					grassMatrices.RemoveAt(num);
				}
			}
		}

		public void RenderChunk()
		{
			if (grassMatrices.Count != 0)
			{
				isChunkVisible = IsVisible();
				if (isChunkVisible)
				{
					Graphics.RenderMeshInstanced(in RenderParams, Mesh, 0, grassMatrices, grassMatrices.Count);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsVisible()
		{
			if (WorldLayerLevel + 0.5f < (float)y)
			{
				return false;
			}
			if (!ZDistanceCheck(CurrentCameraWorldPosition, boundsWorldSpace.center))
			{
				return false;
			}
			return GeometryUtility.TestPlanesAABB(CurrentCameraFrustumPlanes, boundsWorldSpace);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool ZDistanceCheck(Vector3 cameraPos, Vector3 boundsCenter)
		{
			float num = cameraPos.x - boundsCenter.x;
			float num2 = cameraPos.y - boundsCenter.y;
			float num3 = cameraPos.z - boundsCenter.z;
			return num * num + num2 * num2 + num3 * num3 < 10000f;
		}
	}
}
