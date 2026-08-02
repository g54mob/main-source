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
		public MicroSplatPropData propData;

		public void OnDestroy()
		{
			if (blendMatInstance != null)
			{
				UnityEngine.Object.DestroyImmediate(blendMatInstance);
			}
		}

		protected long GetOverrideHash()
		{
			long num = 3L * (long)(((propData == null) ? 3 : propData.GetHashCode()) * 3) * (((perPixelNormal == null) ? 7 : perPixelNormal.GetNativeTexturePtr().ToInt64()) * 7) * (((keywordSO == null) ? 11 : keywordSO.GetHashCode()) * 11) * (((streamTexture == null) ? 41 : streamTexture.GetNativeTexturePtr().ToInt64()) * 41);
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
		}
	}
}
