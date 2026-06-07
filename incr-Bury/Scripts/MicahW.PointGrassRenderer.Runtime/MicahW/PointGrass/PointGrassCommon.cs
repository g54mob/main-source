using System;
using System.Linq;
using UnityEngine;

namespace MicahW.PointGrass
{
	public static class PointGrassCommon
	{
		public enum BladeType
		{
			Flat = 0,
			Cylindrical = 1,
			Mesh = 2
		}

		[Serializable]
		public struct MeshPoint
		{
			public Vector3 position;

			public Vector3 normal;

			public Color color;

			public Vector4 extraData;

			public const int stride = 56;

			public MeshPoint(Vector3 position, Vector3 normal, Color color, Vector4 extraData)
			{
				this.position = position;
				this.normal = normal;
				this.color = color;
				this.extraData = extraData;
			}
		}

		[Serializable]
		public struct ObjectData
		{
			public Vector3 position;

			public float radius;

			public float strength;

			public const int stride = 20;

			public ObjectData(Vector3 position, float radius, float strength)
			{
				this.position = position;
				this.radius = radius;
				this.strength = strength;
			}
		}

		public class MeshData
		{
			public Vector3[] verts;

			public Vector3[] normals;

			public Vector2[] UVs;

			public Color[] colours;

			public int[] tris;

			public Vector2[] attributes;

			public Bounds bounds;

			public static readonly MeshData Empty = new MeshData(null, null, null, null, null);

			public bool HasColours
			{
				get
				{
					if (colours != null)
					{
						return colours.Length != 0;
					}
					return false;
				}
			}

			public bool HasAttributes
			{
				get
				{
					if (attributes != null)
					{
						return attributes.Length != 0;
					}
					return false;
				}
			}

			public MeshData(Vector3[] verts, Vector3[] normals, Vector2[] UVs, Color[] colours, int[] tris, Vector2[] attributes)
			{
				this.verts = verts;
				this.normals = normals;
				this.UVs = UVs;
				this.colours = colours;
				this.tris = tris;
				this.attributes = attributes;
				bounds = default(Bounds);
				RecalculateBounds();
			}

			public MeshData(Vector3[] verts, Vector3[] normals, Vector2[] UVs, int[] tris, Vector2[] attributes)
			{
				this.verts = verts;
				this.normals = normals;
				this.UVs = UVs;
				this.tris = tris;
				this.attributes = attributes;
				colours = null;
				bounds = default(Bounds);
				RecalculateBounds();
			}

			public MeshData(Vector3[] verts, Vector3[] normals, Vector2[] UVs, int[] tris)
			{
				this.verts = verts;
				this.normals = normals;
				this.UVs = UVs;
				this.tris = tris;
				colours = null;
				attributes = null;
				bounds = default(Bounds);
				RecalculateBounds();
			}

			public void RecalculateBounds()
			{
				if (verts != null && verts.Length >= 2)
				{
					bounds = new Bounds(verts[0], Vector3.zero);
					for (int i = 1; i < verts.Length; i++)
					{
						bounds.Encapsulate(verts[i]);
					}
				}
			}

			public void RecalculateNormals()
			{
				Array.Clear(normals, 0, normals.Length);
				for (int i = 0; i < tris.Length; i += 3)
				{
					Vector3 lhs = verts[tris[i + 1]] - verts[tris[i]];
					Vector3 rhs = verts[tris[i + 2]] - verts[tris[i]];
					Vector3 vector = Vector3.Normalize(Vector3.Cross(lhs, rhs));
					for (int j = 0; j < 3; j++)
					{
						normals[tris[i + j]] += vector;
					}
				}
				for (int k = 0; k < normals.Length; k++)
				{
					normals[k].Normalize();
				}
			}

			public void ApplyDensityCutoff(float cutoff)
			{
				if (cutoff <= 0f)
				{
					return;
				}
				if (cutoff >= 1f)
				{
					Debug.LogError("Point Grass Common - An attempt was made to apply a density cutoff greater than or equal to 1f. This would have caused an error, so no cutoff was applied");
					return;
				}
				float num = 1f - cutoff;
				for (int i = 0; i < attributes.Length; i++)
				{
					attributes[i].x = Mathf.Clamp01(attributes[i].x - cutoff) / num;
				}
			}

			public void ApplyLengthMapping(Vector2 mapping)
			{
				mapping.x = Mathf.Clamp01(mapping.x);
				mapping.y = ((mapping.y < mapping.x) ? mapping.x : Mathf.Clamp01(mapping.y));
				for (int i = 0; i < attributes.Length; i++)
				{
					attributes[i].y = Mathf.Lerp(mapping.x, mapping.y, attributes[i].y);
				}
			}
		}

		public enum DistributionSource
		{
			Mesh = 0,
			MeshFilter = 1,
			TerrainData = 2,
			SceneFilters = 3
		}

		public enum ProjectionType
		{
			None = 0,
			ProjectMesh = 1
		}

		public static Mesh grassMeshFlat;

		public static Mesh grassMeshCyl;

		public static int ID_PointBuff;

		public static int ID_ObjBuff;

		public static int ID_ObjCount;

		public static int ID_MatrixL2W;

		public static int ID_MatrixW2L;

		private static int heightmapSize;

		private static int alphamapWidth;

		private static int alphamapHeight;

		private static int numLayers;

		private static Vector3 terrainSize;

		private static float[,,] alphamaps;

		private static bool[] grassLayerMask;

		private static Texture2D[] layerTextures;

		private static Vector2[] layerOffsets;

		private static Vector2[] layerSizes;

		public static bool BladeMeshesGenerated
		{
			get
			{
				if (grassMeshFlat != null)
				{
					return grassMeshCyl != null;
				}
				return false;
			}
		}

		public static bool PropertyIDsInitialized { get; private set; }

		public static void FindPropertyIDs()
		{
			if (!PropertyIDsInitialized)
			{
				ID_PointBuff = Shader.PropertyToID("_MeshPoints");
				ID_ObjBuff = Shader.PropertyToID("_DisplacementObjects");
				ID_ObjCount = Shader.PropertyToID("_DisplacementCount");
				ID_MatrixL2W = Shader.PropertyToID("_ObjMatrix_L2W");
				ID_MatrixW2L = Shader.PropertyToID("_ObjMatrix_W2L");
				PropertyIDsInitialized = true;
			}
		}

		public static void UpdateMaterialPropertyBlock(ref MaterialPropertyBlock block, Transform trans)
		{
			if (block != null && !(trans == null))
			{
				block.SetMatrix(ID_MatrixL2W, trans.localToWorldMatrix);
				block.SetMatrix(ID_MatrixW2L, trans.worldToLocalMatrix);
				if (PointGrassDisplacementManager.instance != null)
				{
					PointGrassDisplacementManager.instance.UpdatePropertyBlock(ref block);
				}
			}
		}

		public static void GenerateGrassMeshes()
		{
			grassMeshFlat = GenerateGrassMesh_Flat();
			grassMeshCyl = GenerateGrassMesh_Cylinder();
		}

		private static Mesh GenerateGrassMesh_Flat(int divisions = 3)
		{
			divisions = Mathf.Max(divisions, 0);
			int num = divisions * 2 + 3;
			int num2 = divisions * 2 + 1;
			Vector3[] array = new Vector3[num];
			Vector2[] array2 = new Vector2[num];
			Color[] array3 = new Color[num];
			float num3 = (float)divisions + 1f;
			for (int i = 0; i < num; i++)
			{
				float num4 = (float)(i >> 1) / num3;
				float num5 = Mathf.Cos(num4 * MathF.PI * 0.5f);
				if (i % 2 == 1)
				{
					num5 = 0f - num5;
				}
				Vector3 vector = new Vector3(num5, num4, 0f);
				Vector2 vector2 = new Vector2(num5 * 0.5f + 0.5f, num4);
				array[i] = vector;
				array2[i] = vector2;
				array3[i] = new Color(1f, 1f, 1f, vector2.y);
			}
			int[] array4 = new int[num2 * 3];
			int num6 = 0;
			for (int j = 0; j < divisions; j++)
			{
				int num7 = j * 6;
				array4[num7] = num6;
				array4[num7 + 1] = num6 + 1;
				array4[num7 + 2] = num6 + 3;
				array4[num7 + 3] = num6;
				array4[num7 + 4] = num6 + 3;
				array4[num7 + 5] = num6 + 2;
				num6 += 2;
			}
			int num8 = divisions * 6;
			array4[num8] = num6;
			array4[num8 + 1] = num6 + 1;
			array4[num8 + 2] = num6 + 2;
			Mesh mesh = new Mesh();
			mesh.name = "Generated Grass Blade";
			mesh.vertices = array;
			mesh.triangles = array4;
			mesh.colors = array3;
			mesh.SetUVs(0, array2);
			mesh.RecalculateNormals();
			return mesh;
		}

		private static Mesh GenerateGrassMesh_Cylinder(int divisions = 3, int loops = 4)
		{
			int num = divisions * loops + 1;
			Vector3[] verts = new Vector3[num];
			Vector2[] uvs = new Vector2[num];
			Color[] cols = new Color[num];
			for (int i = 0; i < loops; i++)
			{
				float num2 = (float)i / (float)loops;
				float num3 = Mathf.Cos(num2 * MathF.PI * 0.5f);
				int num4 = i * divisions;
				for (int j = 0; j < divisions; j++)
				{
					float f = (float)j / (float)divisions * MathF.PI * 2f;
					Vector3 pos = new Vector3(Mathf.Sin(f) * num3, num2, Mathf.Cos(f) * num3);
					SetVert(num4 + j, pos);
				}
			}
			SetVert(num - 1, Vector3.up);
			int[] array = new int[(divisions * (loops - 1) * 2 + divisions) * 3];
			int num5 = 0;
			for (int k = 0; k < loops - 1; k++)
			{
				for (int l = 0; l < divisions; l++)
				{
					int num6 = k * divisions + l;
					int num7 = num6 + divisions;
					int num8 = k * divisions + (l + 1) % divisions;
					int num9 = num8 + divisions;
					array[num5] = num6;
					array[num5 + 1] = num7;
					array[num5 + 2] = num8;
					array[num5 + 3] = num8;
					array[num5 + 4] = num7;
					array[num5 + 5] = num9;
					num5 += 6;
				}
			}
			for (int m = 0; m < divisions; m++)
			{
				int num10 = divisions * (loops - 1) + m;
				int num11 = divisions * (loops - 1) + (m + 1) % divisions;
				int num12 = num - 1;
				array[num5] = num10;
				array[num5 + 1] = num12;
				array[num5 + 2] = num11;
				num5 += 3;
			}
			Mesh mesh = new Mesh();
			mesh.name = "Generated Cylindrical Grass Blade";
			mesh.vertices = verts;
			mesh.triangles = array;
			mesh.colors = cols;
			mesh.SetUVs(0, uvs);
			mesh.RecalculateNormals();
			return mesh;
			void SetVert(int index, Vector3 vector2)
			{
				Vector2 vector = new Vector2(vector2.x * 0.5f + 0.5f, vector2.y);
				verts[index] = vector2;
				uvs[index] = vector;
				cols[index] = new Color(1f, 1f, 1f, vector2.y);
			}
		}

		public static void ProjectBaseMesh(ref MeshData mesh, LayerMask mask, Transform transform)
		{
			for (int i = 0; i < mesh.verts.Length; i++)
			{
				Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
				Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
				Vector3 origin = localToWorldMatrix.MultiplyPoint(mesh.verts[i]);
				Vector3 vector = localToWorldMatrix.MultiplyVector(mesh.normals[i]);
				if (Physics.Raycast(origin, -vector, out var hitInfo, 10f, mask))
				{
					Vector3 vector2 = worldToLocalMatrix.MultiplyPoint(hitInfo.point);
					Vector3 vector3 = worldToLocalMatrix.MultiplyVector(hitInfo.normal);
					mesh.verts[i] = vector2;
					mesh.normals[i] = vector3;
				}
			}
			mesh.RecalculateBounds();
		}

		private static Texture2D CreateTextureCopy(Texture2D source, int width, int height)
		{
			width = Mathf.Max(width, 16);
			height = Mathf.Max(height, 16);
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
			RenderTexture active = RenderTexture.active;
			Graphics.Blit(source, temporary);
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGB24, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			return texture2D;
		}

		public static void CacheTerrainData(TerrainData terrain, TerrainLayer[] grassLayers)
		{
			heightmapSize = terrain.heightmapResolution;
			terrainSize = terrain.size;
			alphamapWidth = terrain.alphamapWidth;
			alphamapHeight = terrain.alphamapHeight;
			numLayers = terrain.alphamapLayers;
			alphamaps = terrain.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
			TerrainLayer[] terrainLayers = terrain.terrainLayers;
			grassLayerMask = new bool[numLayers];
			layerTextures = new Texture2D[numLayers];
			layerOffsets = new Vector2[numLayers];
			layerSizes = new Vector2[numLayers];
			for (int i = 0; i < numLayers; i++)
			{
				grassLayerMask[i] = grassLayers.Contains(terrainLayers[i]);
				layerTextures[i] = CreateTextureCopy(terrain.terrainLayers[i].diffuseTexture, 32, 32);
				layerOffsets[i] = terrain.terrainLayers[i].tileOffset;
				layerSizes[i] = terrain.terrainLayers[i].tileSize;
			}
		}

		public static MeshData CreateMeshFromTerrainData(TerrainData terrain, float densityCutoff, int startX, int startY, int sizeX, int sizeY)
		{
			int num = sizeX * sizeY;
			Vector3[] array = new Vector3[num];
			Vector3[] normals = new Vector3[num];
			Vector2[] array2 = new Vector2[num];
			Color[] array3 = new Color[num];
			Vector2[] array4 = new Vector2[num];
			int[] array5 = new int[(sizeX - 1) * (sizeY - 1) * 2 * 3];
			float num2 = 1f - densityCutoff;
			Vector2 zero = Vector2.zero;
			for (int i = 0; i < sizeX; i++)
			{
				int num3 = i + startX;
				zero.x = Mathf.Clamp01((float)num3 / (float)(heightmapSize - 1));
				for (int j = 0; j < sizeY; j++)
				{
					int num4 = j + startY;
					zero.y = Mathf.Clamp01((float)num4 / (float)(heightmapSize - 1));
					int num5 = i + j * sizeX;
					Vector3 vector = new Vector3(zero.x, 0f, zero.y);
					vector.Scale(terrainSize);
					vector.y = terrain.GetHeight(num3, num4);
					float num6 = 0f;
					Color black = Color.black;
					int num7 = Mathf.FloorToInt(zero.x * (float)(alphamapWidth - 1));
					int num8 = Mathf.FloorToInt(zero.y * (float)(alphamapHeight - 1));
					for (int k = 0; k < numLayers; k++)
					{
						float num9 = alphamaps[num8, num7, k];
						if (grassLayerMask[k])
						{
							num6 += num9;
						}
						Vector2 vector2 = layerSizes[k];
						Vector2 vector3 = new Vector2(vector.x / vector2.x, vector.z / vector2.y) + layerOffsets[k];
						black += layerTextures[k].GetPixelBilinear(vector3.x, vector3.y) * num9;
					}
					num6 = ((!(num2 <= 0f)) ? Mathf.Clamp01((num6 - densityCutoff) / num2) : 0f);
					float x = num6;
					float y = num6;
					array[num5] = vector;
					array2[num5] = new Vector2(vector.x, vector.z);
					array4[num5] = new Vector2(x, y);
					array3[num5] = black;
				}
			}
			for (int l = 0; l < sizeX - 1; l++)
			{
				for (int m = 0; m < sizeY - 1; m++)
				{
					int num10 = l + m * sizeX;
					int num11 = (l + m * (sizeX - 1)) * 6;
					array5[num11] = num10;
					array5[num11 + 1] = num10 + sizeX;
					array5[num11 + 2] = num10 + 1;
					array5[num11 + 3] = num10 + sizeX;
					array5[num11 + 4] = num10 + sizeX + 1;
					array5[num11 + 5] = num10 + 1;
				}
			}
			MeshData meshData = new MeshData(array, normals, array2, array3, array5, array4);
			meshData.RecalculateNormals();
			return meshData;
		}

		public static MeshData CreateMeshFromFilters(Transform parent, MeshFilter[] filters)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < filters.Length; i++)
			{
				if (filters[i] != null && filters[i].sharedMesh != null)
				{
					num += filters[i].sharedMesh.vertexCount;
					num2 += filters[i].sharedMesh.triangles.Length;
				}
			}
			Vector3[] array = new Vector3[num];
			Vector3[] array2 = new Vector3[num];
			Vector2[] array3 = new Vector2[num];
			Vector2[] array4 = new Vector2[num];
			int[] array5 = new int[num2];
			int num3 = 0;
			int num4 = 0;
			for (int j = 0; j < filters.Length; j++)
			{
				if (!(filters[j] != null))
				{
					continue;
				}
				Mesh sharedMesh = filters[j].sharedMesh;
				if (!(sharedMesh != null))
				{
					continue;
				}
				int vertexCount = sharedMesh.vertexCount;
				int num5 = sharedMesh.triangles.Length;
				Transform transform = filters[j].transform;
				for (int k = 0; k < vertexCount; k++)
				{
					Vector3 vector = parent.InverseTransformPoint(transform.TransformPoint(sharedMesh.vertices[k]));
					Vector3 vector2 = parent.InverseTransformVector(transform.TransformDirection(sharedMesh.normals[k]));
					array[num3 + k] = vector;
					array2[num3 + k] = vector2;
				}
				if (sharedMesh.colors != null && sharedMesh.colors.Length == vertexCount)
				{
					for (int l = 0; l < vertexCount; l++)
					{
						array4[num3 + l] = new Vector2(sharedMesh.colors[j].r, sharedMesh.colors[j].g);
					}
				}
				else
				{
					for (int m = 0; m < vertexCount; m++)
					{
						array4[num3 + m] = Vector2.one;
					}
				}
				Array.Copy(sharedMesh.uv, 0, array3, num3, vertexCount);
				for (int n = 0; n < num5; n++)
				{
					array5[num4 + n] = sharedMesh.triangles[n] + num3;
				}
				num3 += vertexCount;
				num4 += num5;
			}
			MeshData meshData = new MeshData(array, array2, array3, array5, array4);
			meshData.RecalculateBounds();
			return meshData;
		}
	}
}
