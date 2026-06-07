using System;
using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class MicroSplatTerrain : MicroSplatObject
	{
		public delegate void MaterialSyncAll();

		public delegate void MaterialSync(Material m);

		private static List<MicroSplatTerrain> sInstances = new List<MicroSplatTerrain>();

		public Terrain terrain;

		public Shader baseMapShader;

		[HideInInspector]
		public Texture2D customControl0;

		[HideInInspector]
		public Texture2D customControl1;

		[HideInInspector]
		public Texture2D customControl2;

		[HideInInspector]
		public Texture2D customControl3;

		[HideInInspector]
		public Texture2D customControl4;

		[HideInInspector]
		public Texture2D customControl5;

		[HideInInspector]
		public Texture2D customControl6;

		[HideInInspector]
		public Texture2D customControl7;

		[NonSerialized]
		public bool useCustomTexturesWithoutKeyword;

		public Vector3 patchBoundsMultiplier = Vector3.one;

		[HideInInspector]
		public bool reenabled;

		public static event MaterialSyncAll OnMaterialSyncAll;

		public event MaterialSync OnMaterialSync;

		private void Awake()
		{
			terrain = GetComponent<Terrain>();
		}

		private void OnEnable()
		{
			terrain = GetComponent<Terrain>();
			sInstances.Add(this);
			if (reenabled)
			{
				Sync();
			}
		}

		private void Start()
		{
			Sync();
		}

		private void OnDisable()
		{
			sInstances.Remove(this);
			Cleanup();
			reenabled = true;
		}

		private void Cleanup()
		{
			if (matInstance != null && matInstance != templateMaterial)
			{
				UnityEngine.Object.DestroyImmediate(matInstance);
				terrain.materialTemplate = null;
			}
		}

		public override TerrainDescriptor GetTerrainDescriptor()
		{
			TerrainDescriptor result = new TerrainDescriptor
			{
				heightMap = terrain.terrainData.heightmapTexture,
				normalMap = terrain.normalmapTexture
			};
			if (perPixelNormal != null)
			{
				result.normalMap = perPixelNormal;
			}
			result.heightMapScale = terrain.terrainData.heightmapScale;
			return result;
		}

		public void Sync()
		{
			if (templateMaterial == null)
			{
				return;
			}
			ApplySharedData(templateMaterial);
			Material material = null;
			if (terrain.materialTemplate == matInstance && matInstance != null)
			{
				terrain.materialTemplate.CopyPropertiesFromMaterial(templateMaterial);
				material = terrain.materialTemplate;
			}
			else
			{
				material = new Material(templateMaterial);
			}
			material.hideFlags = HideFlags.HideAndDontSave;
			terrain.materialTemplate = material;
			matInstance = material;
			ApplyMaps(material);
			if (terrain.drawInstanced)
			{
				material.SetTexture("_PerPixelNormal", terrain.normalmapTexture);
			}
			if (keywordSO.IsKeywordEnabled("_CUSTOMSPLATTEXTURES"))
			{
				material.SetTexture("_CustomControl0", (customControl0 != null) ? customControl0 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl1", (customControl1 != null) ? customControl1 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl2", (customControl2 != null) ? customControl2 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl3", (customControl3 != null) ? customControl3 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl4", (customControl4 != null) ? customControl4 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl5", (customControl5 != null) ? customControl5 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl6", (customControl6 != null) ? customControl6 : Texture2D.blackTexture);
				material.SetTexture("_CustomControl7", (customControl7 != null) ? customControl7 : Texture2D.blackTexture);
			}
			else if (useCustomTexturesWithoutKeyword)
			{
				material.SetTexture("_Control0", (customControl0 != null) ? customControl0 : Texture2D.blackTexture);
				material.SetTexture("_Control1", (customControl1 != null) ? customControl1 : Texture2D.blackTexture);
				material.SetTexture("_Control2", (customControl2 != null) ? customControl2 : Texture2D.blackTexture);
				material.SetTexture("_Control3", (customControl3 != null) ? customControl3 : Texture2D.blackTexture);
				material.SetTexture("_Control4", (customControl4 != null) ? customControl4 : Texture2D.blackTexture);
				material.SetTexture("_Control5", (customControl5 != null) ? customControl5 : Texture2D.blackTexture);
				material.SetTexture("_Control6", (customControl6 != null) ? customControl6 : Texture2D.blackTexture);
				material.SetTexture("_Control7", (customControl7 != null) ? customControl7 : Texture2D.blackTexture);
			}
			else
			{
				if (terrain == null || terrain.terrainData == null)
				{
					Debug.LogError("Terrain or terrain data is null, cannot sync");
					return;
				}
				Texture2D[] alphamapTextures = terrain.terrainData.alphamapTextures;
				if (alphamapTextures == null || alphamapTextures.Length == 0 || alphamapTextures[0] == null)
				{
					Debug.LogError("Terrain doesn't have splat map textures!");
				}
				ApplyControlTextures(alphamapTextures, material);
			}
			ApplyBlendMap();
			if (this.OnMaterialSync != null)
			{
				this.OnMaterialSync(material);
			}
		}

		public override Bounds GetBounds()
		{
			return terrain.terrainData.bounds;
		}

		public new static void SyncAll()
		{
			for (int i = 0; i < sInstances.Count; i++)
			{
				sInstances[i].Sync();
			}
			if (MicroSplatTerrain.OnMaterialSyncAll != null)
			{
				MicroSplatTerrain.OnMaterialSyncAll();
			}
		}
	}
}
