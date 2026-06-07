using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteAlways]
	public class MicroSplatDecalReceiver : MonoBehaviour
	{
		public enum StaticCacheSize
		{
			k64 = 0x40,
			k128 = 0x80,
			k256 = 0x100,
			k512 = 0x200,
			k1024 = 0x400
		}

		private struct PixelBounds
		{
			public int xmin;

			public int xmax;

			public int ymin;

			public int ymax;
		}

		private MaterialPropertyBlock decalBlock;

		private Terrain terrain;

		private Renderer rend;

		private MicroSplatMeshTerrain meshTerrain;

		public bool generateCacheOnLoad;

		private bool needsStaticUpdate = true;

		private bool loadStaticFromCache;

		[HideInInspector]
		public List<MicroSplatDecal> dynamicDecals;

		[HideInInspector]
		public Texture2D dynamicCacheData;

		[HideInInspector]
		public Texture2D dynamicCullData;

		private int maxDynamicDecals;

		private List<MicroSplatDecal> staticDecals;

		[HideInInspector]
		public Texture2D cacheMask;

		[HideInInspector]
		public Color[] cacheMaskBuffer;

		[HideInInspector]
		public Texture2D staticCacheData;

		private int maxStaticDecals;

		public StaticCacheSize staticCacheSize = StaticCacheSize.k256;

		public MicroSplatObject msObj { get; private set; }

		public int dynamicCount
		{
			get
			{
				if (dynamicDecals != null)
				{
					return dynamicDecals.Count;
				}
				return 0;
			}
		}

		public int staticCount
		{
			get
			{
				if (staticDecals != null)
				{
					return staticDecals.Count;
				}
				return 0;
			}
		}

		private void InitSystem()
		{
			if (decalBlock != null)
			{
				return;
			}
			decalBlock = new MaterialPropertyBlock();
			msObj = GetComponent<MicroSplatObject>();
			if (msObj == null)
			{
				Debug.LogError("MicroSplatDecalReceiver must be on MicroSplat Object");
			}
			else
			{
				terrain = GetComponent<Terrain>();
				rend = GetComponent<Renderer>();
				meshTerrain = GetComponent<MicroSplatMeshTerrain>();
				if (msObj.keywordSO == null)
				{
					Debug.LogError("MicroSplatDecalReceiver cannot find keyword data on MicroSplatObject, please make sure this is assigned");
				}
			}
			InitStatic();
			InitDynamic();
		}

		public bool RegisterDecal(MicroSplatDecal d)
		{
			if (decalBlock == null)
			{
				InitSystem();
			}
			if (terrain != null)
			{
				if (d.dynamic)
				{
					RegisterDynamicDecal(d);
					return true;
				}
				RegisterStaticDecal(d);
				return false;
			}
			if (meshTerrain != null)
			{
				if (d.dynamic)
				{
					RegisterDynamicDecal(d);
					return true;
				}
				RegisterStaticDecal(d);
				return false;
			}
			RegisterDynamicDecal(d);
			return true;
		}

		public void UnregisterDecal(MicroSplatDecal d)
		{
			if (terrain != null)
			{
				if (d.dynamic)
				{
					UnregisterDynamicDecal(d);
				}
				else
				{
					UnregisterStaticDecal(d);
				}
			}
			else if (meshTerrain != null)
			{
				if (d.dynamic)
				{
					UnregisterDynamicDecal(d);
				}
				else
				{
					UnregisterDynamicDecal(d);
				}
			}
			else
			{
				UnregisterDynamicDecal(d);
			}
		}

		private void SetData(MicroSplatDecal d, int index, Texture2D tex)
		{
			if (!(d == null))
			{
				Matrix4x4 worldToLocalMatrix = d.transform.worldToLocalMatrix;
				tex.SetPixel(index, 0, new Color(worldToLocalMatrix.m00, worldToLocalMatrix.m01, worldToLocalMatrix.m02, worldToLocalMatrix.m03));
				tex.SetPixel(index, 1, new Color(worldToLocalMatrix.m10, worldToLocalMatrix.m11, worldToLocalMatrix.m12, worldToLocalMatrix.m13));
				tex.SetPixel(index, 2, new Color(worldToLocalMatrix.m20, worldToLocalMatrix.m21, worldToLocalMatrix.m22, worldToLocalMatrix.m23));
				tex.SetPixel(index, 3, new Color(worldToLocalMatrix.m30, worldToLocalMatrix.m31, worldToLocalMatrix.m32, worldToLocalMatrix.m33));
				d.GetShaderData(out var data, out var data2);
				tex.SetPixel(index, 4, data);
				tex.SetPixel(index, 5, data2);
				tex.SetPixel(index, 6, d.splatIndexes);
				tex.SetPixel(index, 7, d.tint);
			}
		}

		private void OnEnable()
		{
			InitSystem();
		}

		private void OnDisable()
		{
			decalBlock = null;
		}

		private void OnDestroy()
		{
			decalBlock = null;
			if ((bool)staticCacheData)
			{
				Object.DestroyImmediate(staticCacheData);
			}
			if (cacheMask != null)
			{
				Object.DestroyImmediate(cacheMask);
			}
			if ((bool)dynamicCacheData)
			{
				Object.DestroyImmediate(dynamicCacheData);
			}
			if ((bool)dynamicCullData)
			{
				Object.DestroyImmediate(dynamicCullData);
			}
		}

		private void Update()
		{
			UpdatePropertyBlocks();
			if (needsStaticUpdate)
			{
				needsStaticUpdate = false;
				UpdateStaticCache();
				if (!generateCacheOnLoad && loadStaticFromCache)
				{
					loadStaticFromCache = false;
					LoadFromCache();
				}
				else
				{
					RerenderCacheMap();
				}
			}
		}

		private void UpdatePropertyBlocks()
		{
			if (decalBlock == null)
			{
				return;
			}
			if (terrain != null)
			{
				terrain.GetSplatMaterialPropertyBlock(decalBlock);
			}
			else if (meshTerrain != null)
			{
				if (meshTerrain.meshTerrains.Length != 0 && meshTerrain.meshTerrains[0] != null)
				{
					meshTerrain.meshTerrains[0].GetPropertyBlock(decalBlock);
				}
			}
			else if (rend != null)
			{
				rend.GetPropertyBlock(decalBlock);
			}
			UpdateDynamicPropertyBlocks();
			UpdateStaticPropertyBlocks();
			if (terrain != null)
			{
				terrain.SetSplatMaterialPropertyBlock(decalBlock);
			}
			else if (meshTerrain != null)
			{
				for (int i = 0; i < meshTerrain.meshTerrains.Length; i++)
				{
					MeshRenderer meshRenderer = meshTerrain.meshTerrains[i];
					if (meshRenderer != null)
					{
						meshRenderer.SetPropertyBlock(decalBlock);
					}
				}
			}
			else if (rend != null)
			{
				rend.SetPropertyBlock(decalBlock);
			}
		}

		private void ClearDynamicCacheData()
		{
			if (staticCacheData != null)
			{
				Object.DestroyImmediate(dynamicCacheData);
			}
			if (dynamicCullData != null)
			{
				Object.DestroyImmediate(dynamicCullData);
			}
			dynamicCacheData = new Texture2D(maxDynamicDecals, 8, TextureFormat.RGBAFloat, mipChain: false, linear: true);
			dynamicCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			dynamicCullData = new Texture2D(maxDynamicDecals, 1, TextureFormat.RGBAFloat, mipChain: false, linear: true);
			dynamicCullData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			dynamicCacheData.hideFlags = HideFlags.HideAndDontSave;
			dynamicCullData.hideFlags = HideFlags.HideAndDontSave;
		}

		private void InitDynamic()
		{
			maxDynamicDecals = 8;
			if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX0"))
			{
				maxDynamicDecals = 1;
			}
			if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX16"))
			{
				maxDynamicDecals = 16;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX32"))
			{
				maxDynamicDecals = 32;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX64"))
			{
				maxDynamicDecals = 64;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX128"))
			{
				maxDynamicDecals = 128;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_MAX256"))
			{
				maxDynamicDecals = 256;
			}
			dynamicDecals = new List<MicroSplatDecal>(maxDynamicDecals);
			ClearDynamicCacheData();
		}

		private void RegisterDynamicDecal(MicroSplatDecal d)
		{
			if (staticDecals.Contains(d))
			{
				return;
			}
			dynamicDecals.Add(d);
			if (dynamicDecals.Count > 1 && d.sortOrder != dynamicDecals[dynamicDecals.Count - 2].sortOrder)
			{
				dynamicDecals.Sort((MicroSplatDecal x, MicroSplatDecal y) => x.sortOrder.CompareTo(y.sortOrder));
			}
		}

		private void UpdateDynamicPropertyBlocks()
		{
			int count = dynamicDecals.Count;
			if (count > maxDynamicDecals)
			{
				count = maxDynamicDecals;
			}
			for (int i = 0; i < count; i++)
			{
				float a = (dynamicDecals[i].transform.lossyScale - Vector3.zero).sqrMagnitude * 0.5f;
				Vector3 position = dynamicDecals[i].transform.position;
				dynamicCullData.SetPixel(i, 0, new Color(position.x, position.y, position.z, a));
				SetData(dynamicDecals[i], i, dynamicCacheData);
			}
			dynamicCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			dynamicCullData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			decalBlock.SetInt("_MSDecalCount", count);
			decalBlock.SetTexture("_DecalCullData", dynamicCullData);
			decalBlock.SetTexture("_DecalDynamicData", dynamicCacheData);
		}

		private void UnregisterDynamicDecal(MicroSplatDecal d)
		{
			if (dynamicDecals != null && dynamicDecals.Contains(d))
			{
				dynamicDecals.Remove(d);
			}
		}

		private void ClearStaticCacheData()
		{
			if (staticCacheData != null)
			{
				Object.DestroyImmediate(staticCacheData);
			}
			staticCacheData = new Texture2D(maxStaticDecals, 8, TextureFormat.RGBAFloat, mipChain: false, linear: true);
			staticCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			staticCacheData.hideFlags = HideFlags.HideAndDontSave;
		}

		private void ClearCacheMask()
		{
			if (cacheMask != null)
			{
				Object.DestroyImmediate(cacheMask);
			}
			int num = (int)staticCacheSize;
			if (cacheMaskBuffer == null || cacheMaskBuffer.Length != num * num)
			{
				ClearCacheMaskBuffer();
			}
			cacheMask = new Texture2D(num, num, TextureFormat.RGBAHalf, mipChain: false, linear: true);
			cacheMask.hideFlags = HideFlags.HideAndDontSave;
			cacheMask.filterMode = FilterMode.Point;
			cacheMask.wrapMode = TextureWrapMode.Clamp;
			cacheMask.SetPixels(cacheMaskBuffer);
			cacheMask.Apply(updateMipmaps: false, makeNoLongerReadable: false);
		}

		private void ClearCacheMaskBuffer()
		{
			int num = (int)staticCacheSize;
			cacheMaskBuffer = new Color[num * num];
			Color color = new Color(0f, 0f, 0f, 0f);
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					cacheMaskBuffer[j * num + i] = color;
				}
			}
		}

		private void InitStatic()
		{
			maxStaticDecals = 1;
			if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX64"))
			{
				maxStaticDecals = 64;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX128"))
			{
				maxStaticDecals = 128;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX256"))
			{
				maxStaticDecals = 256;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX512"))
			{
				maxStaticDecals = 512;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX1024"))
			{
				maxStaticDecals = 1024;
			}
			else if (msObj.keywordSO.IsKeywordEnabled("_DECAL_STATICMAX2048"))
			{
				maxStaticDecals = 2048;
			}
			staticDecals = new List<MicroSplatDecal>(maxStaticDecals);
			if (Application.IsPlaying(this) && cacheMaskBuffer != null && cacheMaskBuffer.Length == maxStaticDecals * maxStaticDecals)
			{
				loadStaticFromCache = true;
				return;
			}
			ClearCacheMask();
			ClearStaticCacheData();
			needsStaticUpdate = true;
		}

		private void RegisterStaticDecal(MicroSplatDecal d)
		{
			staticDecals.Add(d);
			needsStaticUpdate = true;
		}

		private void UnregisterStaticDecal(MicroSplatDecal d)
		{
			if (terrain != null)
			{
				if (staticDecals != null && staticDecals.Contains(d))
				{
					staticDecals.Remove(d);
					needsStaticUpdate = true;
				}
			}
			else if (meshTerrain != null && staticDecals != null && staticDecals.Contains(d))
			{
				staticDecals.Remove(d);
				needsStaticUpdate = true;
			}
		}

		private void UpdateStaticCache()
		{
			if (staticDecals != null)
			{
				int count = staticDecals.Count;
				if (count > maxStaticDecals)
				{
					count = maxStaticDecals;
				}
				for (int i = 0; i < count; i++)
				{
					SetData(staticDecals[i], i, staticCacheData);
				}
				staticCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
		}

		private void UpdateStaticPropertyBlocks()
		{
			decalBlock.SetTexture("_DecalControl", cacheMask);
			decalBlock.SetTexture("_DecalStaticData", staticCacheData);
		}

		private Vector2 WorldToTerrainPixel(Vector3 terrainPos, Vector3 terrainSize, Vector3 point, Texture2D splatControl)
		{
			point -= terrainPos;
			float x = point.x / terrainSize.x * (float)splatControl.width;
			float y = point.z / terrainSize.z * (float)splatControl.height;
			return new Vector2(x, y);
		}

		private Vector3 TerrainPixelToWorld(Vector3 terrainPos, Vector3 terrainSize, int x, int y, Texture2D splatControl)
		{
			Vector3 vector = new Vector3(x, 0f, y);
			vector.x *= terrainSize.x / (float)splatControl.width;
			vector.z *= terrainSize.z / (float)splatControl.height;
			return vector += terrainPos;
		}

		private Vector3 TerrainPixelToWorldWithHeight(Terrain t, Vector3 terrainPos, Vector3 terrainSize, int x, int y, Texture2D splatControl)
		{
			Vector3 vector = new Vector3(x, 0f, y);
			vector.x *= terrainSize.x / (float)splatControl.width;
			vector.y = t.terrainData.GetInterpolatedHeight(x, y);
			vector.z *= terrainSize.z / (float)splatControl.height;
			return vector += terrainPos;
		}

		private bool GetDecalPixelBounds(Vector3 terrainPos, Vector3 terrainSize, Matrix4x4 decalMtx, ref PixelBounds bounds)
		{
			float num = 0.5f;
			Bounds bounds2 = new Bounds(decalMtx.MultiplyPoint(new Vector3(0f - num, 0f - num, 0f - num)), Vector3.one);
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(num, num, num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(0f - num, num, num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(num, 0f - num, num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(num, num, 0f - num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(0f - num, 0f - num, num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(num, 0f - num, 0f - num)));
			bounds2.Encapsulate(decalMtx.MultiplyPoint(new Vector3(0f - num, num, 0f - num)));
			Vector3 min = bounds2.min;
			Vector3 max = bounds2.max;
			Vector2 vector = WorldToTerrainPixel(terrainPos, terrainSize, min, cacheMask);
			Vector2 vector2 = WorldToTerrainPixel(terrainPos, terrainSize, max, cacheMask);
			bounds.xmin = Mathf.FloorToInt(vector.x - 1f);
			bounds.ymin = Mathf.FloorToInt(vector.y - 1f);
			bounds.xmax = Mathf.FloorToInt(vector2.x + 1f);
			bounds.ymax = Mathf.FloorToInt(vector2.y + 1f);
			if (bounds.xmin < 0 && bounds.xmax < 0)
			{
				return false;
			}
			if (bounds.ymin < 0 && bounds.ymax < 0)
			{
				return false;
			}
			if (bounds.xmin >= cacheMask.width && bounds.xmax >= cacheMask.width)
			{
				return false;
			}
			if (bounds.ymin >= cacheMask.height && bounds.ymax >= cacheMask.height)
			{
				return false;
			}
			bounds.xmin = Mathf.Clamp(bounds.xmin, 0, cacheMask.width);
			bounds.xmax = Mathf.Clamp(bounds.xmax, 0, cacheMask.width);
			bounds.ymin = Mathf.Clamp(bounds.ymin, 0, cacheMask.height);
			bounds.ymax = Mathf.Clamp(bounds.ymax, 0, cacheMask.height);
			if (bounds.xmin == bounds.xmax)
			{
				if (bounds.xmax < cacheMask.width)
				{
					bounds.xmax++;
				}
				else
				{
					bounds.xmin--;
				}
			}
			if (bounds.ymin == bounds.ymax)
			{
				if (bounds.ymax < cacheMask.height)
				{
					bounds.ymax++;
				}
				else
				{
					bounds.ymin--;
				}
			}
			return true;
		}

		private bool PointInOABB(Vector3 pt, Matrix4x4 decalMtx)
		{
			Vector3 vector = decalMtx.MultiplyPoint(pt);
			if (vector.x < 1f && vector.x > -1f && vector.y < 1f && vector.y > -1f && vector.z < 1f && vector.z > -1f)
			{
				return true;
			}
			return false;
		}

		private void ClearDecalInCache(Vector3 terrainPos, Vector3 terrainSize, Matrix4x4 dmtx, int index, PixelBounds pb)
		{
			int width = cacheMask.width;
			for (int i = pb.xmin; i < pb.xmax; i++)
			{
				for (int j = pb.ymin; j < pb.ymax; j++)
				{
					int num = j * width + i;
					Color color = cacheMaskBuffer[num];
					if (Mathf.RoundToInt(color.r - 1f) == index)
					{
						color.r = color.g;
						color.g = color.b;
						color.b = color.a;
						color.a = 0f;
						cacheMaskBuffer[num] = color;
					}
					else if (Mathf.RoundToInt(color.g - 1f) == index)
					{
						color.g = color.b;
						color.b = color.a;
						color.a = 0f;
						cacheMaskBuffer[num] = color;
					}
					else if (Mathf.RoundToInt(color.b - 1f) == index)
					{
						color.b = color.a;
						color.a = 0f;
						cacheMaskBuffer[num] = color;
					}
					else if (Mathf.RoundToInt(color.a - 1f) == index)
					{
						color.a = 0f;
						cacheMaskBuffer[num] = color;
					}
				}
			}
		}

		private void ClearDecalInCache(Vector3 terrainPos, Vector3 terrainSize, MicroSplatDecal d, Matrix4x4 oldMtx, int index)
		{
			PixelBounds bounds = default(PixelBounds);
			if (GetDecalPixelBounds(terrainPos, terrainSize, oldMtx, ref bounds))
			{
				ClearDecalInCache(terrainPos, terrainSize, oldMtx, index, bounds);
			}
		}

		private void RenderDecalIntoCache(int index, Vector3 terrainPos, Vector3 terrainSize, MicroSplatDecal d, PixelBounds pb)
		{
			_ = d.transform.worldToLocalMatrix;
			int width = cacheMask.width;
			for (int i = pb.xmin; i < pb.xmax; i++)
			{
				for (int j = pb.ymin; j < pb.ymax; j++)
				{
					int num = j * width + i;
					Color color = cacheMaskBuffer[num];
					if (Mathf.RoundToInt(color.r - 1f) != index && Mathf.RoundToInt(color.g - 1f) != index && Mathf.RoundToInt(color.b - 1f) != index && Mathf.RoundToInt(color.a - 1f) != index)
					{
						if (color.r < 0.5f)
						{
							color.r = index + 1;
							color.g = 0f;
							color.b = 0f;
							color.a = 0f;
						}
						else if (color.g < 0.5f)
						{
							color.g = color.r;
							color.r = index + 1;
							color.b = 0f;
							color.a = 0f;
						}
						else if (color.b < 0.5f)
						{
							color.b = color.g;
							color.g = color.r;
							color.r = index + 1;
							color.a = 0f;
						}
						else
						{
							color.a = color.b;
							color.b = color.g;
							color.g = color.r;
							color.r = index + 1;
						}
						cacheMaskBuffer[num] = color;
					}
				}
			}
		}

		private void RenderDecalIntoCache(Vector3 terrainPos, Vector3 terrainSize, MicroSplatDecal d, int index)
		{
			if (d.isActiveAndEnabled)
			{
				PixelBounds bounds = default(PixelBounds);
				if (GetDecalPixelBounds(terrainPos, terrainSize, d.transform.localToWorldMatrix, ref bounds))
				{
					RenderDecalIntoCache(index, terrainPos, terrainSize, d, bounds);
				}
			}
		}

		public void UpdateDecalInCache(Vector3 terrainPos, Vector3 terrainSize, MicroSplatDecal d, Matrix4x4 oldMtx)
		{
			int index = staticDecals.IndexOf(d);
			ClearDecalInCache(terrainPos, terrainSize, d, oldMtx, index);
			RenderDecalIntoCache(terrainPos, terrainSize, d, index);
			cacheMask.SetPixels(cacheMaskBuffer);
			cacheMask.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			UpdateStaticPropertyBlocks();
			UpdateStaticCache();
		}

		public void RerenderCacheMap()
		{
			ClearCacheMaskBuffer();
			ClearCacheMask();
			SortStaticDecals();
			UpdateStaticCache();
			UpdatePropertyBlocks();
			if (terrain != null)
			{
				for (int i = 0; i < staticDecals.Count; i++)
				{
					RenderDecalIntoCache(terrain.transform.position, terrain.terrainData.size, staticDecals[i], i);
				}
			}
			else if (meshTerrain != null)
			{
				for (int j = 0; j < staticDecals.Count; j++)
				{
					RenderDecalIntoCache(meshTerrain.transform.position, meshTerrain.GetBounds().size, staticDecals[j], j);
				}
			}
			cacheMask.SetPixels(cacheMaskBuffer);
			cacheMask.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			staticCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
		}

		private void SortStaticDecals()
		{
			if (staticDecals != null)
			{
				staticDecals.Sort((MicroSplatDecal x, MicroSplatDecal y) => x.GetHashCode().CompareTo(y.GetHashCode()));
				staticDecals.Sort((MicroSplatDecal x, MicroSplatDecal y) => x.sortOrder.CompareTo(y.sortOrder));
			}
		}

		public void LoadFromCache()
		{
			ClearCacheMask();
			SortStaticDecals();
			UpdateStaticCache();
			UpdatePropertyBlocks();
			cacheMask.SetPixels(cacheMaskBuffer);
			cacheMask.Apply(updateMipmaps: false, makeNoLongerReadable: false);
			staticCacheData.Apply(updateMipmaps: false, makeNoLongerReadable: false);
		}
	}
}
