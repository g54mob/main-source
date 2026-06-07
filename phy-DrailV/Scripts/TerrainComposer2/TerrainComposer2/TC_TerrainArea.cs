using System;
using System.Collections.Generic;
using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_TerrainArea : MonoBehaviour
	{
		public RenderTexture[] rtSplatmaps;

		public RenderTexture rtColormap;

		public bool loaded;

		public ApplyChanges applyChanges;

		public Int2 totalHeightmapResolution;

		public Int2 heightTexResolution;

		public List<TCUnityTerrain> terrains = new List<TCUnityTerrain>();

		public TCUnityTerrain[,] terrainArray;

		public bool createTerrainTab;

		public bool active = true;

		public Color color = new Color(1.5f, 1.5f, 1.5f, 1f);

		public int index;

		public bool terrains_active = true;

		public bool terrains_scene_active = true;

		public bool terrains_foldout = true;

		public bool sizeTab;

		public bool resolutionsTab;

		public bool settingsTab;

		public bool splatTab;

		public bool treeTab;

		public bool grassTab;

		public bool resetTab;

		public Int2 tiles;

		public Int2 selectTiles;

		public bool tileLink = true;

		public bool useSameTerrainLayersForAllTerrains = true;

		public bool drawInstanced;

		public Rect area;

		public Vector3 terrainSize = new Vector3(2048f, 750f, 2048f);

		public Vector3 center = new Vector3(0f, 0f, 0f);

		public Rect menuRect;

		public bool display_short;

		public string terrainDataPath;

		public Transform parent;

		public string terrainName = "Terrain";

		public bool copy_settings = true;

		public int copy_terrain;

		public int terrainSelect;

		public bool settingsEditor = true;

		public static readonly string[] heightmapResolutionList = new string[8] { "4097", "2049", "1025", "513", "257", "129", "65", "33" };

		public static readonly string[] splatmapResolutionList = new string[8] { "2048", "1024", "512", "256", "128", "64", "32", "16" };

		public static readonly string[] detailmapResolutionList = new string[9] { "2048", "1024", "512", "256", "128", "64", "32", "16", "8" };

		public static readonly string[] detailResolutionPerPatchList = new string[5] { "8", "16", "32", "64", "128" };

		public static readonly string[] imageImportMaxSettings = new string[8] { "32", "64", "128", "256", "512", "1024", "2048", "4096" };

		private void OnEnable()
		{
			if (!loaded)
			{
				loaded = true;
				terrainDataPath = Application.dataPath;
			}
			SetNeighbors();
		}

		private void AssignMaterials()
		{
			Shader shader = Shader.Find("HDRP/TerrainLit");
			if (shader == null)
			{
				shader = Shader.Find("Universal Render Pipeline/Terrain/Lit");
			}
			if (shader == null)
			{
				shader = Shader.Find("Nature/Terrain/Diffuse");
			}
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].materialTemplate = new Material(shader);
				if ((bool)terrains[i].terrain)
				{
					terrains[i].terrain.materialTemplate = terrains[i].materialTemplate;
				}
			}
		}

		public bool IsRTPAddedToTerrains()
		{
			Type type = TC.FindRTP();
			if (type == null)
			{
				return false;
			}
			for (int i = 0; i < terrains.Count; i++)
			{
				Terrain terrain = terrains[i].terrain;
				if (!(terrain == null) && terrain.GetComponent(type) == null)
				{
					return false;
				}
			}
			return true;
		}

		public void AddRTPTOTerrains()
		{
			Type type = TC.FindRTP();
			if (type == null)
			{
				return;
			}
			for (int i = 0; i < terrains.Count; i++)
			{
				Terrain terrain = terrains[i].terrain;
				if (!(terrain == null) && terrain.GetComponent(type) == null)
				{
					terrain.gameObject.AddComponent(type);
				}
			}
		}

		public void AssignTerrainArray()
		{
			bool flag = false;
			if (terrainArray == null)
			{
				flag = true;
			}
			else if (terrainArray.Length != tiles.x * tiles.y)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			terrainArray = new TCUnityTerrain[tiles.x, tiles.y];
			int num = 0;
			for (int i = 0; i < tiles.y; i++)
			{
				for (int j = 0; j < tiles.x; j++)
				{
					terrainArray[j, i] = terrains[num++];
				}
			}
		}

		private void OnDestroy()
		{
			DisposeTextures();
		}

		public void DisposeTextures()
		{
			TC_Compute.DisposeRenderTextures(ref rtSplatmaps);
			TC_Compute.DisposeRenderTexture(ref rtColormap);
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].DisposeTextures();
			}
		}

		public void Clear()
		{
			terrains.Clear();
		}

		public void ResetTextureRTP(string texName)
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].AssignTextureRTP(texName, null);
			}
		}

		public void ClearToOne()
		{
			int count = terrains.Count;
			if (terrains[0].terrain != null)
			{
				UnityEngine.Object.DestroyImmediate(terrains[0].terrain.gameObject);
			}
			for (int i = 1; i < count; i++)
			{
				if (terrains[1].terrain != null)
				{
					UnityEngine.Object.DestroyImmediate(terrains[1].terrain.gameObject);
				}
				terrains.RemoveAt(1);
			}
		}

		public void CalcTotalResolutions()
		{
			if (terrains.Count != 0 && !(terrains[0].terrain == null) && !(terrains[0].terrain.terrainData == null))
			{
				int heightmapResolution = terrains[0].terrain.terrainData.heightmapResolution;
				totalHeightmapResolution = new Int2(tiles.x * heightmapResolution, tiles.y * heightmapResolution);
				heightTexResolution = new Int2(tiles.x * (heightmapResolution - 1), tiles.y * (heightmapResolution - 1));
			}
		}

		public void CalcTotalArea()
		{
			Vector2 vector = new Vector2(terrains[0].terrain.transform.localPosition.x, terrains[0].terrain.transform.localPosition.z);
			Vector2 vector2 = vector + new Vector2(terrains[0].terrain.terrainData.size.x, terrains[0].terrain.terrainData.size.z);
			for (int i = 1; i < terrains.Count; i++)
			{
				if (terrains[i].terrain.transform.localPosition.x < vector.x)
				{
					vector.x = terrains[i].terrain.transform.localPosition.x;
				}
				if (terrains[i].terrain.transform.localPosition.z < vector.y)
				{
					vector.y = terrains[i].terrain.transform.localPosition.z;
				}
				Vector2 vector3 = new Vector2(terrains[i].terrain.transform.localPosition.x + terrains[i].terrain.terrainData.size.x, terrains[i].terrain.transform.localPosition.z + terrains[i].terrain.terrainData.size.z);
				if (vector3.x > vector2.x)
				{
					vector2.x = vector3.x;
				}
				if (vector3.y > vector2.y)
				{
					vector2.y = vector3.y;
				}
			}
			area = default(Rect);
			area.xMin = vector.x;
			area.yMin = vector.y;
			area.xMax = vector2.x;
			area.yMax = vector2.y;
		}

		public void FitTerrainsPosition()
		{
			if (terrains.Count == 0)
			{
				return;
			}
			int num = 0;
			Vector3 size = terrains[0].terrain.terrainData.size;
			area.xMin = (0f - size.x) * ((float)tiles.x / 2f);
			area.yMin = (0f - size.z) * ((float)tiles.y / 2f);
			for (int i = 0; i < tiles.y; i++)
			{
				for (int j = 0; j < tiles.x; j++)
				{
					terrains[num].tasks = 0;
					if (terrains[num].terrain.terrainData.size != size)
					{
						terrains[num].terrain.terrainData.size = size;
					}
					terrains[num].terrain.transform.localPosition = new Vector3(area.xMin + size.x * (float)j, 0f, area.yMin + size.z * (float)i);
					if (++num > terrains.Count)
					{
						goto end_IL_014f;
					}
				}
				continue;
				end_IL_014f:
				break;
			}
			SetNeighbors();
		}

		public void SetNeighbors()
		{
		}

		public void ResetNeighbors()
		{
		}

		public Terrain GetTerrainTile(int tileX, int tileZ)
		{
			if (tileX < 0 || tileX > tiles.x - 1 || tileZ < 0 || tileZ > tiles.y - 1)
			{
				return null;
			}
			int num = tileZ * tiles.x + tileX;
			if (!terrains[num].CheckValidUnityTerrain())
			{
				return null;
			}
			return terrains[num].terrain;
		}

		public TCUnityTerrain GetTCUnityTerrainTile(int tileX, int tileZ)
		{
			if (tileX < 0 || tileX > tiles.x - 1 || tileZ < 0 || tileZ > tiles.y - 1)
			{
				return null;
			}
			int num = tileZ * tiles.x + tileX;
			return terrains[num];
		}

		public void SetTerrainsActive(bool invert)
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				if (!invert)
				{
					terrains[i].active = terrains_active;
				}
				else
				{
					terrains[i].active = !terrains[i].active;
				}
			}
		}

		public void GetTerrainsFromChildren()
		{
			Terrain[] componentsInChildren = GetComponentsInChildren<Terrain>(includeInactive: true);
			terrains.Clear();
			if (componentsInChildren.Length != 0)
			{
				terrainSize = componentsInChildren[0].terrainData.size;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				terrains.Add(new TCUnityTerrain());
				terrains[terrains.Count - 1].terrain = componentsInChildren[i];
			}
			tiles.x = (tiles.y = (int)Mathf.Sqrt(terrains.Count));
		}

		public Int2 IndexToTile(int index)
		{
			Int2 result = default(Int2);
			result.y = index / tiles.x;
			result.x = index - result.y * tiles.x;
			return result;
		}

		public int TileToIndex(Int2 tile)
		{
			return tile.y * tiles.x + tile.x;
		}

		public void CreateTerrains()
		{
			ClearToOne();
			terrains[0].size = terrainSize;
			int num = 0;
			index = terrains.Count - 1;
			Int2 tile = IndexToTile(terrainSelect);
			for (int i = 0; i < selectTiles.y; i++)
			{
				for (int j = 0; j < selectTiles.x; j++)
				{
					if (num != 0)
					{
						terrains.Add(new TCUnityTerrain());
						terrains[num] = CopyTerrain(terrains[0]);
					}
					terrains[num].tileX = j;
					terrains[num].tileZ = i;
					GameObject obj = new GameObject();
					obj.transform.parent = base.transform;
					Terrain terrain = (Terrain)obj.AddComponent(typeof(Terrain));
					TerrainCollider obj2 = (TerrainCollider)obj.AddComponent(typeof(TerrainCollider));
					terrain.allowAutoConnect = true;
					terrain.name = string.Concat(str1: "_x" + j + "_y" + i, str0: terrainName);
					TerrainData terrainData = (terrain.terrainData = new TerrainData
					{
						size = terrains[0].size
					});
					obj2.terrainData = terrainData;
					terrains[num].terrain = terrain;
					terrains[num].ApplyAllSettings(terrains[0], settingsEditor);
					terrains[num].terrainSettingsScript = terrain.gameObject.AddComponent<TC_TerrainSettings>();
					terrains[num].ApplySplatTextures(this);
					terrains[num].ApplyTrees();
					terrains[num].ApplyGrass();
					terrains[num].GetSettings(settingsEditor);
					num++;
				}
			}
			AssignMaterials();
			if (terrains[0].terrain != null)
			{
				TC_Settings.instance.masterTerrain = terrains[0].terrain;
			}
			tiles = selectTiles;
			FitTerrainsPosition();
			CalcTotalResolutions();
			terrainSelect = TileToIndex(tile);
			if (terrainSelect > tiles.x * tiles.y)
			{
				terrainSelect = 0;
			}
		}

		public TCUnityTerrain CopyTerrain(TCUnityTerrain tcTerrain)
		{
			GameObject obj = new GameObject();
			obj.AddComponent<SaveTemplate>().tcTerrain = tcTerrain;
			GameObject gameObject = UnityEngine.Object.Instantiate(obj);
			UnityEngine.Object.DestroyImmediate(obj);
			tcTerrain = gameObject.GetComponent<SaveTemplate>().tcTerrain;
			tcTerrain.rtHeight = null;
			tcTerrain.texHeight = null;
			tcTerrain.texColormap = null;
			UnityEngine.Object.DestroyImmediate(gameObject);
			return tcTerrain;
		}

		public void GetAll()
		{
			if (terrains == null)
			{
				terrains = new List<TCUnityTerrain>();
			}
			if (terrains.Count == 0)
			{
				terrains.Add(new TCUnityTerrain());
			}
			if (terrainSelect >= terrains.Count)
			{
				terrainSelect = 0;
			}
			GetSize();
			GetSettings();
			GetSplatTextures();
			GetTrees();
			GetGrass();
			GetResolutions();
		}

		public void GetResolutions()
		{
			terrains[terrainSelect].GetResolutions();
			CalcTotalResolutions();
		}

		public void GetSize()
		{
			if (terrains[terrainSelect].CheckValidUnityTerrain())
			{
				terrains[terrainSelect].size = terrains[terrainSelect].terrain.terrainData.size;
			}
		}

		public void GetSettings()
		{
			terrains[terrainSelect].GetSettings(settingsEditor);
		}

		public void ApplySize()
		{
			if (applyChanges == ApplyChanges.Terrain)
			{
				ApplySizeTerrain();
			}
			else if (applyChanges == ApplyChanges.TerrainArea)
			{
				ApplySizeTerrainArea();
			}
		}

		public void ApplySizeTerrain()
		{
			if (terrains[terrainSelect].CheckValidUnityTerrain())
			{
				terrains[terrainSelect].terrain.terrainData.size = terrainSize;
				FitTerrainsPosition();
			}
		}

		public void ApplySizeTerrainArea()
		{
			if (terrains[terrainSelect].CheckValidUnityTerrain() && terrains[0].CheckValidUnityTerrain())
			{
				terrains[0].terrain.terrainData.size = terrainSize;
				FitTerrainsPosition();
			}
		}

		public void ApplyResolution()
		{
			ApplyResolutionTerrainArea(terrains[terrainSelect]);
		}

		public void ApplyResolutionTerrainArea(TCUnityTerrain sTerrain)
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ApplyResolutionTerrain(sTerrain);
			}
			CalcTotalResolutions();
			if (TC_Settings.instance.global.showResolutionWarnings)
			{
				if (sTerrain.heightmapResolution > 513)
				{
					TC.AddMessage("Heightmap resolution is higher than 513, keep in mind that Auto generate will be too slow to work in realtime.");
				}
				if (sTerrain.splatmapResolution > 1024)
				{
					TC.AddMessage("Splatmap resolution is higher than 1024, keep in mind that Auto generate will be too slow to work in realtime.");
				}
				if (sTerrain.detailResolution > 512)
				{
					TC.AddMessage("Grass resolution is higher than 513, keep in mind that Auto generate will be too slow to work in realtime.");
				}
			}
		}

		public void ApplySettings()
		{
			if (applyChanges == ApplyChanges.Terrain)
			{
				terrains[terrainSelect].ApplySettings(terrains[terrainSelect], settingsEditor);
			}
			else if (applyChanges == ApplyChanges.TerrainArea)
			{
				ApplySettingsTerrainArea();
			}
		}

		public void ApplySettingsTerrainArea()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ApplySettings(terrains[terrainSelect], settingsEditor);
			}
		}

		public void ApplySplatTextures(TCUnityTerrain sTerrain)
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ApplySplatTextures(this, sTerrain);
			}
		}

		public void GetSplatTextures()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].GetSplatTextures(this);
			}
		}

		public void ApplyTrees()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ApplyTrees(terrains[terrainSelect]);
			}
		}

		public void GetTrees()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].GetTrees();
			}
		}

		public void ApplyGrass()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ApplyGrass(terrains[terrainSelect]);
			}
		}

		public void GetGrass()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].GetGrass();
			}
		}

		public void ResetHeightmap()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ResetHeightmap();
			}
		}

		public void ResetSplatmap()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ResetSplatmap();
			}
		}

		public void ResetTrees()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ResetTrees();
			}
		}

		public void ResetGrass()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ResetGrass();
			}
		}

		public void ResetObjects()
		{
			for (int i = 0; i < terrains.Count; i++)
			{
				terrains[i].ResetObjects();
			}
		}
	}
}
