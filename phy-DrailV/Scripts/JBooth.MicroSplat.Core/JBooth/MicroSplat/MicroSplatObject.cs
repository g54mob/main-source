using System;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteAlways]
	public class MicroSplatObject : MonoBehaviour
	{
		public struct TerrainDescriptor
		{
			public Texture heightMap;

			public Texture normalMap;

			public Vector3 heightMapScale;
		}

		[HideInInspector]
		public Material templateMaterial;

		[NonSerialized]
		[HideInInspector]
		public Material matInstance;

		[HideInInspector]
		public Material blendMat;

		[HideInInspector]
		public Material blendMatInstance;

		[HideInInspector]
		public MicroSplatKeywords keywordSO;

		[HideInInspector]
		public Texture2D perPixelNormal;

		[HideInInspector]
		public Texture2D streamTexture;

		[HideInInspector]
		public Texture2D tintMapOverride;

		[HideInInspector]
		public Texture2D globalNormalOverride;

		[HideInInspector]
		public Texture2D globalSAOMOverride;

		[HideInInspector]
		public Texture2D globalEmisOverride;

		[HideInInspector]
		public Texture2D geoTextureOverride;

		[HideInInspector]
		public Texture2D vsGrassMap;

		[HideInInspector]
		public Texture2D vsShadowMap;

		[HideInInspector]
		public Texture2D clipMap;

		[HideInInspector]
		public MicroSplatPropData propData;

		protected long GetOverrideHash()
		{
			long num = 3L * (long)(((propData == null) ? 3 : propData.GetHashCode()) * 3) * (((perPixelNormal == null) ? 7 : perPixelNormal.GetNativeTexturePtr().ToInt64()) * 7) * (((keywordSO == null) ? 11 : keywordSO.GetHashCode()) * 11) * (((clipMap == null) ? 5 : clipMap.GetNativeTexturePtr().ToInt64()) * 5) * (((vsShadowMap == null) ? 31 : vsShadowMap.GetNativeTexturePtr().ToInt64()) * 31) * (((vsGrassMap == null) ? 37 : vsGrassMap.GetNativeTexturePtr().ToInt64()) * 37) * (((streamTexture == null) ? 41 : streamTexture.GetNativeTexturePtr().ToInt64()) * 41) * (((geoTextureOverride == null) ? 47 : geoTextureOverride.GetNativeTexturePtr().ToInt64()) * 47) * (((globalNormalOverride == null) ? 53 : globalNormalOverride.GetNativeTexturePtr().ToInt64()) * 53) * (((globalSAOMOverride == null) ? 59 : globalSAOMOverride.GetNativeTexturePtr().ToInt64()) * 59) * (((globalEmisOverride == null) ? 61 : globalEmisOverride.GetNativeTexturePtr().ToInt64()) * 61) * (((tintMapOverride == null) ? 71 : tintMapOverride.GetNativeTexturePtr().ToInt64()) * 71);
			if (num == 0L)
			{
				Debug.Log("Override hash returned 0, this should not happen");
			}
			return num;
		}

		protected void SetMap(Material m, string name, Texture tex)
		{
			if (m.HasProperty(name) && tex != null)
			{
				m.SetTexture(name, tex);
			}
		}

		protected void ApplySharedData(Material m)
		{
			if (propData != null)
			{
				m.SetTexture("_PerTexProps", propData.GetTexture());
			}
			if (m.HasProperty("_GeoCurve") && propData != null)
			{
				m.SetTexture("_GeoCurve", propData.GetGeoCurve());
			}
			if (m.HasProperty("_GeoSlopeTex") && propData != null)
			{
				m.SetTexture("_GeoSlopeTex", propData.GetGeoSlopeFilter());
			}
			if (m.HasProperty("_GlobalSlopeTex") && propData != null)
			{
				m.SetTexture("_GlobalSlopeTex", propData.GetGlobalSlopeFilter());
			}
		}

		protected void ApplyMaps(Material m)
		{
			SetMap(m, "_StreamControl", streamTexture);
			SetMap(m, "_PerPixelNormal", perPixelNormal);
			TerrainDescriptor terrainDescriptor = GetTerrainDescriptor();
			if (perPixelNormal == null && terrainDescriptor.normalMap != null)
			{
				SetMap(m, "_PerPixelNormal", terrainDescriptor.normalMap);
			}
			SetMap(m, "_AlphaHoleTexture", clipMap);
			SetMap(m, "_GeoTex", geoTextureOverride);
			SetMap(m, "_GlobalTintTex", tintMapOverride);
			SetMap(m, "_GlobalNormalTex", globalNormalOverride);
			SetMap(m, "_GlobalSAOMTex", globalSAOMOverride);
			SetMap(m, "_GlobalEmisTex", globalEmisOverride);
			SetMap(m, "_VSGrassMap", vsGrassMap);
			SetMap(m, "_VSShadowMap", vsShadowMap);
		}

		protected void ApplyControlTextures(Texture2D[] controls, Material m)
		{
			m.SetTexture("_Control0", (controls.Length != 0) ? controls[0] : Texture2D.blackTexture);
			m.SetTexture("_Control1", (controls.Length > 1) ? controls[1] : Texture2D.blackTexture);
			m.SetTexture("_Control2", (controls.Length > 2) ? controls[2] : Texture2D.blackTexture);
			m.SetTexture("_Control3", (controls.Length > 3) ? controls[3] : Texture2D.blackTexture);
			m.SetTexture("_Control4", (controls.Length > 4) ? controls[4] : Texture2D.blackTexture);
			m.SetTexture("_Control5", (controls.Length > 5) ? controls[5] : Texture2D.blackTexture);
			m.SetTexture("_Control6", (controls.Length > 6) ? controls[6] : Texture2D.blackTexture);
			m.SetTexture("_Control7", (controls.Length > 7) ? controls[7] : Texture2D.blackTexture);
		}

		protected void SyncBlendMat(Vector3 size)
		{
			if (blendMatInstance != null && matInstance != null)
			{
				blendMatInstance.CopyPropertiesFromMaterial(matInstance);
				Vector4 value = new Vector4
				{
					z = size.x,
					w = size.z,
					x = base.transform.position.x,
					y = base.transform.position.z
				};
				blendMatInstance.SetVector("_TerrainBounds", value);
				TerrainDescriptor terrainDescriptor = GetTerrainDescriptor();
				blendMatInstance.SetTexture("_TerrainHeightmapTexture", terrainDescriptor.heightMap);
				blendMatInstance.SetTexture("_TerrainNormalmapTexture", terrainDescriptor.normalMap);
				blendMatInstance.SetVector("_TerrainHeightmapScale", terrainDescriptor.heightMapScale);
				if (terrainDescriptor.normalMap != null)
				{
					blendMatInstance.SetTexture("_PerPixelNormal", terrainDescriptor.normalMap);
				}
			}
		}

		public virtual TerrainDescriptor GetTerrainDescriptor()
		{
			return default(TerrainDescriptor);
		}

		public virtual Bounds GetBounds()
		{
			return default(Bounds);
		}

		public Material GetBlendMatInstance()
		{
			if (blendMat != null)
			{
				if (blendMatInstance == null)
				{
					blendMatInstance = new Material(blendMat);
					SyncBlendMat(GetBounds().size);
				}
				if (blendMatInstance.shader != blendMat.shader)
				{
					blendMatInstance.shader = blendMat.shader;
					SyncBlendMat(GetBounds().size);
				}
			}
			return blendMatInstance;
		}

		public void ApplyBlendMap()
		{
			if (blendMat != null)
			{
				if (blendMatInstance == null)
				{
					blendMatInstance = new Material(blendMat);
				}
				SyncBlendMat(GetBounds().size);
			}
		}

		public void RevisionFromMat()
		{
		}

		public static void SyncAll()
		{
			MicroSplatTerrain.SyncAll();
			MicroSplatMeshTerrain.SyncAll();
		}
	}
}
