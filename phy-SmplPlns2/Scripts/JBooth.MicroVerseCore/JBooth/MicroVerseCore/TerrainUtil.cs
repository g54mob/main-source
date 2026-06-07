using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class TerrainUtil
	{
		public static Mesh GenerateMesh(int segments, Vector3 tsize)
		{
			float x = tsize.x;
			Mesh mesh = new Mesh
			{
				name = "TerrainProxy",
				hideFlags = HideFlags.DontSave
			};
			int num = segments + 1;
			int num2 = segments + 1;
			int num3 = segments * segments * 6;
			int num4 = num * num2;
			Vector3[] array = new Vector3[num4];
			Vector2[] array2 = new Vector2[num4];
			int[] array3 = new int[num3];
			int num5 = 0;
			float num6 = 1f / (float)segments;
			float num7 = 1f / (float)segments;
			float num8 = x / (float)segments;
			float num9 = x / (float)segments;
			for (float num10 = 0f; num10 < (float)num2; num10 += 1f)
			{
				for (float num11 = 0f; num11 < (float)num; num11 += 1f)
				{
					array[num5] = new Vector3(num11 * num8, 0f, num10 * num9);
					array2[num5++] = new Vector2(num11 * num6, num10 * num7);
				}
			}
			num5 = 0;
			for (int i = 0; i < segments; i++)
			{
				for (int j = 0; j < segments; j++)
				{
					array3[num5] = i * num + j;
					array3[num5 + 1] = (i + 1) * num + j;
					array3[num5 + 2] = i * num + j + 1;
					array3[num5 + 3] = (i + 1) * num + j;
					array3[num5 + 4] = (i + 1) * num + j + 1;
					array3[num5 + 5] = i * num + j + 1;
					num5 += 6;
				}
			}
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.triangles = array3;
			mesh.RecalculateNormals();
			mesh.bounds = new Bounds(new Vector3(tsize.x * 0.5f, tsize.y * 0.5f, tsize.z * 0.5f), tsize);
			mesh.RecalculateTangents();
			return mesh;
		}

		public static Bounds ComputeTerrainBounds(Terrain terrain)
		{
			if (terrain == null || terrain.terrainData == null)
			{
				return default(Bounds);
			}
			Bounds bounds = terrain.terrainData.bounds;
			Vector3 size = bounds.size;
			bounds.center = terrain.transform.position;
			bounds.center += new Vector3(size.x * 0.5f, 0f, size.z * 0.5f);
			return bounds;
		}

		public static Bounds ComputeTerrainBounds(Terrain[] terrains)
		{
			Bounds result = new Bounds(Vector3.zero, Vector3.zero);
			for (int i = 0; i < terrains.Length; i++)
			{
				Bounds bounds = ComputeTerrainBounds(terrains[i]);
				if (i == 0)
				{
					result = bounds;
				}
				else
				{
					result.Encapsulate(bounds);
				}
			}
			return result;
		}

		public static Bounds AdjustForRotation(Bounds b, Quaternion rot)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(b.center, rot, Vector3.one);
			b.Encapsulate(matrix4x.MultiplyPoint(b.size / 2f));
			b.Encapsulate(matrix4x.MultiplyPoint(-b.size / 2f));
			return b;
		}

		public static Bounds GetBounds(Transform transform)
		{
			Vector3 lossyScale = transform.lossyScale;
			float num = Mathf.Max(lossyScale.x, lossyScale.z);
			Bounds result = AdjustForRotation(new Bounds(transform.position, new Vector3(num, num, num)), transform.rotation);
			result.max = new Vector3(result.max.x, 99999f, result.max.z);
			result.min = new Vector3(result.min.x, -99999f, result.min.z);
			return result;
		}

		public static Vector3 ComputeTerrainSize(Terrain terrain)
		{
			Vector3 heightmapScale = terrain.terrainData.heightmapScale;
			int heightmapResolution = terrain.terrainData.heightmapResolution;
			return new Vector3(heightmapScale.x * (float)heightmapResolution, heightmapScale.y * 2f, heightmapScale.z * (float)heightmapResolution);
		}

		public static Matrix4x4 ComputeStampMatrix(Terrain terrain, Transform transform, bool heightStamp = false, int sizeXOffset = 0, int sizeZOffset = 0)
		{
			Vector3 size = terrain.terrainData.size;
			Vector2 vector = new Vector2(size.x, size.z);
			if (heightStamp)
			{
				Vector3 heightmapScale = terrain.terrainData.heightmapScale;
				int heightmapResolution = terrain.terrainData.heightmapResolution;
				vector = new Vector2(heightmapScale.x * (float)heightmapResolution, heightmapScale.z * (float)heightmapResolution);
			}
			Vector3 vector2 = terrain.transform.worldToLocalMatrix.MultiplyPoint3x4(transform.position);
			Vector3 lossyScale = transform.lossyScale;
			Vector2 vector3 = new Vector2(lossyScale.x + (float)sizeXOffset, lossyScale.z + (float)sizeZOffset);
			Vector2 vector4 = new Vector2(vector2.x, vector2.z) / vector;
			float y = transform.rotation.eulerAngles.y;
			Matrix4x4 matrix4x = Matrix4x4.Translate(-vector4);
			matrix4x = Matrix4x4.Rotate(Quaternion.AngleAxis(y, Vector3.forward)) * matrix4x;
			matrix4x = Matrix4x4.Scale(new Vector2(size.x, size.z) / vector3) * matrix4x;
			return Matrix4x4.Translate(new Vector3(0.5f, 0.5f, 0f)) * matrix4x;
		}

		public static int FindTextureChannelIndex(Terrain terrain, TerrainLayer layer)
		{
			TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
			for (int i = 0; i < terrainLayers.Length; i++)
			{
				if ((object)terrainLayers[i] == layer)
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindTreeIndex(Terrain terrain, GameObject prefab)
		{
			TreePrototype[] treePrototypes = terrain.terrainData.treePrototypes;
			for (int i = 0; i < treePrototypes.Length; i++)
			{
				if ((object)treePrototypes[i].prefab == prefab)
				{
					return i;
				}
			}
			return -1;
		}

		public static void EnsureTexturesAreOnTerrain(Terrain terrain, List<TerrainLayer> prototypes)
		{
			TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
			List<TerrainLayer> list = new List<TerrainLayer>(terrainLayers);
			bool flag = false;
			int num = -1;
			foreach (TerrainLayer item in prototypes.Distinct())
			{
				for (int i = 0; i < terrainLayers.Length; i++)
				{
					TerrainLayer terrainLayer = terrainLayers[i];
					if ((object)item == terrainLayer)
					{
						num = i;
					}
				}
				if (num < 0)
				{
					list.Add(item);
					flag = true;
				}
			}
			if (flag)
			{
				terrain.terrainData.terrainLayers = list.ToArray();
			}
		}
	}
}
