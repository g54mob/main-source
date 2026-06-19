using System.Collections.Generic;
using PugTilemap.Quads;
using UnityEngine;
using UnityEngine.Rendering;

namespace PugTilemap
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteAlways]
	public class PugMapLayerMesh : MonoBehaviour
	{
		private const int spriteQueueIndex = 2000;

		private const string sortingLayerName = "Back";

		private Vector3Int forwardVector = new Vector3Int(0, 0, 1);

		private Vector3Int backVector = new Vector3Int(0, 0, -1);

		private Vector3Int leftVector = new Vector3Int(-1, 0, 0);

		private Vector3Int rightVector = new Vector3Int(1, 0, 0);

		public Texture texture;

		public Mesh mesh;

		public MeshRenderer meshRenderer;

		public int triangleCount;

		private List<Vector3> vertices = new List<Vector3>();

		private List<Vector3> normals = new List<Vector3>();

		private List<int> triangles = new List<int>();

		private List<Vector2> uv = new List<Vector2>();

		private List<Color32> colors32 = new List<Color32>();

		private Dictionary<Vector3Int, Vector2Int> meshPartStartIndices = new Dictionary<Vector3Int, Vector2Int>();

		private static readonly int EmissiveTex = Shader.PropertyToID("_EmissiveTex");

		private static readonly int EffectMaskTex = Shader.PropertyToID("_EffectMaskTex");

		private static readonly int BumpMap = Shader.PropertyToID("_BumpMap");

		public void Init(Texture2D _texture, Texture2D _emissiveTexture, Texture2D _effectMaskTexture, Texture2D _normalsTexture, Material _material, QuadGenerator layerDef)
		{
			texture = _texture;
			if (mesh == null)
			{
				mesh = new Mesh();
			}
			MeshFilter component = GetComponent<MeshFilter>();
			meshRenderer = GetComponent<MeshRenderer>();
			component.mesh = mesh;
			meshRenderer.sortingLayerID = layerDef.sortingLayer;
			meshRenderer.lightProbeUsage = LightProbeUsage.Off;
			meshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Simple;
			meshRenderer.shadowCastingMode = ShadowCastingMode.On;
			meshRenderer.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;
			meshRenderer.shadowCastingMode = layerDef.shadowCastingMode;
			meshRenderer.receiveShadows = layerDef.receiveShadows;
			meshRenderer.sharedMaterial = new Material(_material);
			meshRenderer.sharedMaterial.mainTexture = texture;
			if (_emissiveTexture == null && layerDef.emissiveTexture != null)
			{
				meshRenderer.sharedMaterial.SetTexture(EmissiveTex, layerDef.emissiveTexture);
			}
			if (_emissiveTexture != null)
			{
				meshRenderer.sharedMaterial.SetTexture(EmissiveTex, _emissiveTexture);
			}
			if (_effectMaskTexture != null)
			{
				meshRenderer.sharedMaterial.SetTexture(EffectMaskTex, _effectMaskTexture);
			}
			if (_normalsTexture != null)
			{
				meshRenderer.sharedMaterial.SetTexture(BumpMap, _normalsTexture);
			}
		}

		private static void RecycleList<T>(List<T> list, int newCapacity)
		{
			list.Clear();
			if (list.Capacity < newCapacity)
			{
				list.Capacity = newCapacity;
			}
		}

		public void BuildMesh(QuadCache ld, BoundsInt bounds, QuadGenerator def, PugMultiMap multiMap, PugMap map, TileType tileType)
		{
			Color32 item = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 0);
			int x = bounds.size.x;
			int z = bounds.size.z;
			int num = x * z;
			int num2 = 2 * num;
			int newCapacity = 4 * num;
			RecycleList(vertices, newCapacity);
			RecycleList(normals, newCapacity);
			RecycleList(triangles, 3 * num2);
			RecycleList(uv, newCapacity);
			RecycleList(colors32, newCapacity);
			int num3 = 0;
			foreach (KeyValuePair<Vector3Int, Quad> quad in ld.quads)
			{
				Quad value = quad.Value;
				if (!value.hasSprite)
				{
					continue;
				}
				foreach (QuadGenerator.TileFace tileFace in def.tileFaces)
				{
					float num4 = def.offset.x + ((float)value.pos.x - 0.5f) + ((tileFace == QuadGenerator.TileFace.LEFT) ? (0f - def.padding) : 0f);
					float num5 = def.offset.z + ((float)value.pos.z - 0.5f) + ((tileFace == QuadGenerator.TileFace.FRONT) ? (0f - def.padding) : 0f);
					float x2 = num4 + 1f + ((tileFace == QuadGenerator.TileFace.RIGHT) ? def.padding : 0f);
					float num6 = num5 + 1f + ((tileFace == QuadGenerator.TileFace.BACK) ? def.padding : 0f);
					float num7 = def.offset.y + ((tileFace == QuadGenerator.TileFace.BOTTOM) ? (0f - def.padding) : 0f);
					float num8 = def.offset.y + 1f + def.heightStretch + ((tileFace == QuadGenerator.TileFace.TOP) ? def.padding : 0f);
					float z2 = (def.skewInTopVertices ? (num6 - Mathf.Clamp(0.4f * num7, 0f, 1f)) : 0f);
					float z3 = (def.skewInTopVertices ? (num6 - Mathf.Clamp(0.4f * num8, 0f, 1f)) : 0f);
					Vector3 item2 = Vector3.up;
					TileType type = ((def.overrideTileTypeForMeshAdjustments != TileType.__illegal__) ? def.overrideTileTypeForMeshAdjustments : tileType);
					Vector3 vector = map.ToWorldCoord(value.pos);
					switch (tileFace)
					{
					case QuadGenerator.TileFace.TOP:
						if (!def.skewInTopVertices || multiMap.IsTileTypeAt(vector + forwardVector, type))
						{
							vertices.Add(new Vector3(num4, num8, num5));
							vertices.Add(new Vector3(num4, num8, num6));
							vertices.Add(new Vector3(x2, num8, num6));
							vertices.Add(new Vector3(x2, num8, num5));
							break;
						}
						vertices.Add(new Vector3(num4, num8, num5));
						if (!multiMap.IsTileTypeAt(vector + forwardVector + leftVector, type))
						{
							vertices.Add(new Vector3(num4, num8, z3));
						}
						else
						{
							vertices.Add(new Vector3(num4, num8, num6));
						}
						if (!multiMap.IsTileTypeAt(vector + forwardVector + rightVector, type))
						{
							vertices.Add(new Vector3(x2, num8, z3));
						}
						else
						{
							vertices.Add(new Vector3(x2, num8, num6));
						}
						vertices.Add(new Vector3(x2, num8, num5));
						break;
					case QuadGenerator.TileFace.BOTTOM:
						vertices.Add(new Vector3(num4, num7, num5));
						vertices.Add(new Vector3(num4, num7, num6));
						vertices.Add(new Vector3(x2, num7, num6));
						vertices.Add(new Vector3(x2, num7, num5));
						break;
					case QuadGenerator.TileFace.FRONT:
						vertices.Add(new Vector3(num4, num7, num5));
						vertices.Add(new Vector3(num4, num8, num5));
						vertices.Add(new Vector3(x2, num8, num5));
						vertices.Add(new Vector3(x2, num7, num5));
						item2 = Vector3.back;
						break;
					case QuadGenerator.TileFace.BACK:
						if (multiMap.IsTileTypeAt(vector + forwardVector, type))
						{
							continue;
						}
						if (def.skewInTopVertices && !multiMap.IsTileTypeAt(vector + forwardVector + rightVector, type))
						{
							vertices.Add(new Vector3(x2, num7, z2));
							vertices.Add(new Vector3(x2, num8, z3));
						}
						else
						{
							vertices.Add(new Vector3(x2, num7, num6));
							vertices.Add(new Vector3(x2, num8, num6));
						}
						if (def.skewInTopVertices && !multiMap.IsTileTypeAt(vector + forwardVector + leftVector, type))
						{
							vertices.Add(new Vector3(num4, num8, z3));
							vertices.Add(new Vector3(num4, num7, z2));
						}
						else
						{
							vertices.Add(new Vector3(num4, num8, num6));
							vertices.Add(new Vector3(num4, num7, num6));
						}
						item2 = Vector3.forward;
						break;
					case QuadGenerator.TileFace.LEFT:
						if (multiMap.IsTileTypeAt(vector + Vector3Int.left, type))
						{
							continue;
						}
						if (!def.skewInTopVertices || multiMap.IsTileTypeAt(vector + forwardVector, type) || multiMap.IsTileTypeAt(vector + forwardVector + leftVector, type))
						{
							vertices.Add(new Vector3(num4, num7, num6));
							vertices.Add(new Vector3(num4, num8, num6));
						}
						else
						{
							vertices.Add(new Vector3(num4, num7, z2));
							vertices.Add(new Vector3(num4, num8, z3));
						}
						vertices.Add(new Vector3(num4, num8, num5));
						vertices.Add(new Vector3(num4, num7, num5));
						item2 = Vector3.left;
						break;
					case QuadGenerator.TileFace.RIGHT:
						if (multiMap.IsTileTypeAt(vector + Vector3Int.right, type))
						{
							continue;
						}
						vertices.Add(new Vector3(x2, num7, num5));
						vertices.Add(new Vector3(x2, num8, num5));
						if (!def.skewInTopVertices || multiMap.IsTileTypeAt(vector + forwardVector, type) || multiMap.IsTileTypeAt(vector + forwardVector + rightVector, type))
						{
							vertices.Add(new Vector3(x2, num8, num6));
							vertices.Add(new Vector3(x2, num7, num6));
						}
						else
						{
							vertices.Add(new Vector3(x2, num8, z3));
							vertices.Add(new Vector3(x2, num7, z2));
						}
						item2 = Vector3.right;
						break;
					}
					normals.Add(item2);
					normals.Add(item2);
					normals.Add(item2);
					normals.Add(item2);
					triangles.Add(num3);
					triangles.Add(num3 + 1);
					triangles.Add(num3 + 2);
					triangles.Add(num3);
					triangles.Add(num3 + 2);
					triangles.Add(num3 + 3);
					uv.Add(new Vector2(value.spriteUV.xMin, value.spriteUV.yMin));
					uv.Add(new Vector2(value.spriteUV.xMin, value.spriteUV.yMax));
					uv.Add(new Vector2(value.spriteUV.xMax, value.spriteUV.yMax));
					uv.Add(new Vector2(value.spriteUV.xMax, value.spriteUV.yMin));
					colors32.Add(item);
					colors32.Add(item);
					colors32.Add(item);
					colors32.Add(item);
					num3 += 4;
				}
			}
			mesh.Clear();
			mesh.SetVertices(vertices);
			mesh.SetNormals(normals);
			mesh.SetTriangles(triangles, 0);
			mesh.SetUVs(0, uv);
			mesh.SetColors(colors32);
			mesh.bounds = new Bounds(bounds.center, bounds.size + new Vector3Int(2, 2, 2));
			triangleCount = triangles.Count / 3;
		}
	}
}
