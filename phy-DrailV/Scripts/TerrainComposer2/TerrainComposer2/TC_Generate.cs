using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace TerrainComposer2
{
	[ExecuteInEditMode]
	public class TC_Generate : MonoBehaviour
	{
		private struct ItemMap
		{
			public int index;

			public float density;

			public float maskValue;

			public Vector3 pos;
		}

		[Serializable]
		public class GenerateStackEntry
		{
			public List<GenerateStack> stack = new List<GenerateStack>();

			public int frame;

			public GenerateStackEntry(int frame)
			{
				this.frame = frame;
			}
		}

		[Serializable]
		public class GenerateStack
		{
			public TCUnityTerrain tcTerrain;

			public int outputId;

			public bool assignTerrainHeightmap;

			public Rect generateRect;

			public GenerateStack(int outputId, TCUnityTerrain tcTerrain, bool assignTerrainHeightmap)
			{
				this.tcTerrain = tcTerrain;
				this.outputId = outputId;
				this.assignTerrainHeightmap = assignTerrainHeightmap;
			}

			public GenerateStack(int outputId, TCUnityTerrain tcTerrain, bool assignTerrainHeightmap, Rect generateRect)
			{
				this.tcTerrain = tcTerrain;
				this.outputId = outputId;
				this.assignTerrainHeightmap = assignTerrainHeightmap;
				this.generateRect = generateRect;
			}
		}

		public static TC_Generate instance;

		public float globalScale = 1f;

		public TC_Area2D area2D;

		public bool assignTerrainHeightmap;

		public bool hideHierarchy;

		public bool generate;

		public bool generateSplat;

		public bool generateSplatSingle;

		public bool generateTree;

		public bool generateObject;

		public bool generateGrass;

		public bool generateColor;

		public bool resetTrees;

		public bool generateSingle;

		public int threadActive;

		public bool isMesh;

		public bool resetObjects;

		public bool autoGenerate;

		public bool scanHeight;

		public bool cmdGenerate;

		public Rect autoGenerateRect = new Rect(0f, 0f, 1f, 1f);

		public bool generateNextFrame;

		public int generateDone;

		public int generateDoneOld;

		public bool isGeneratingHeight;

		public int jobs;

		public bool autoGenerateOld;

		private float[] heightsReadback;

		private float[,] heights;

		private int[,] grass;

		private List<TreeInstance> trees;

		private int restoreAutoGenerateFrame;

		private bool restoreAutoGenerate;

		public List<GenerateStackEntry> stackEntry = new List<GenerateStackEntry>();

		public Transform objectParent;

		[NonSerialized]
		private TC_Terrain firstTreeTerrain;

		[NonSerialized]
		private TC_Terrain firstObjectTerrain;

		private int frame;

		private bool updateCamCapture;

		private bool disableHeightOuput;

		private void Awake()
		{
			autoGenerateOld = autoGenerate;
			autoGenerate = false;
			restoreAutoGenerate = true;
		}

		private void OnEnable()
		{
			instance = this;
			isGeneratingHeight = false;
		}

		private void OnDisable()
		{
			autoGenerateOld = autoGenerate;
			autoGenerate = false;
		}

		private void OnDestroy()
		{
			instance = null;
		}

		public void Update()
		{
			MyUpdate();
		}

		public void MyUpdate()
		{
			TC_Settings tC_Settings = TC_Settings.instance;
			if (tC_Settings != null && tC_Settings.version == 0f)
			{
				tC_Settings.version = TC.GetVersionNumber();
				TC.RefreshOutputReferences(7);
				TC.AddMessage("TerrainComposer2 is updated to " + TC.GetVersionNumber());
			}
			area2D = TC_Area2D.current;
			if (area2D == null || area2D.terrainLayer == null)
			{
				return;
			}
			if (area2D.terrainLayer.layerGroups[0] == null)
			{
				TC.RefreshOutputReferences(6);
			}
			RefreshOutputReferences(TC.GetRefreshOutputReferences(), TC.refreshPreviewImages);
			if (cmdGenerate)
			{
				cmdGenerate = false;
				if (autoGenerate)
				{
					TC_Reporter.Log("Generate from auto", 2);
					Generate(instantGenerate: false, autoGenerateRect);
				}
				else
				{
					TC.autoGenerateCallTimeStart = Time.realtimeSinceStartup;
				}
				autoGenerateRect = new Rect(0f, 0f, 1f, 1f);
			}
			if (restoreAutoGenerate)
			{
				if (restoreAutoGenerateFrame > 1)
				{
					restoreAutoGenerate = false;
					restoreAutoGenerateFrame = 0;
					autoGenerate = autoGenerateOld;
				}
				restoreAutoGenerateFrame++;
			}
			generate = false;
			RunGenerateStack();
			frame++;
		}

		public void RefreshOutputReferences(int outputId, bool refreshPreviewImages)
		{
			if (outputId >= 0)
			{
				TC.refreshPreviewImages = refreshPreviewImages;
				if (outputId >= 6)
				{
					area2D.terrainLayer.GetItems(refresh: false, rebuildGlobalLists: true, outputId == 7);
				}
				else
				{
					area2D.terrainLayer.GetItem(outputId, rebuildGlobalLists: true, resetTextures: false);
				}
				TC.RefreshOutputReferences(-1);
				TC.refreshPreviewImages = false;
				TC.repaintNodeWindow = true;
			}
		}

		public void RunGenerateStack()
		{
			if (stackEntry.Count > 0 && stackEntry[0].stack.Count == 0)
			{
				stackEntry.RemoveAt(0);
			}
			if (stackEntry.Count > 0 && !generate)
			{
				List<GenerateStack> stack = stackEntry[0].stack;
				GenerateStack generateStack = stack[0];
				int outputId = generateStack.outputId;
				TCUnityTerrain tcTerrain = generateStack.tcTerrain;
				assignTerrainHeightmap = generateStack.assignTerrainHeightmap;
				stack.RemoveAt(0);
				GenerateTerrain(tcTerrain, outputId);
				Compute(tcTerrain, outputId, generateStack.generateRect);
			}
			if (stackEntry.Count == 0 && disableHeightOuput)
			{
				disableHeightOuput = false;
				area2D.terrainLayer.layerGroups[0].visible = false;
			}
		}

		public void Compute(TCUnityTerrain tcTerrain, int outputId, Rect generateRect)
		{
			switch (outputId)
			{
			case 0:
				ComputeHeight(generateRect);
				break;
			case 1:
				ComputeSplat(generateRect);
				break;
			case 2:
				ComputeColor();
				break;
			case 3:
				ComputeTree();
				break;
			case 4:
				ComputeGrass();
				break;
			case 5:
				ComputeObject();
				break;
			}
			tcTerrain.generateStatus &= (byte)(255 - Mathw.bit8[outputId]);
			if (tcTerrain.generateStatus == 0)
			{
				if (tcTerrain.tasks > 0)
				{
					tcTerrain.tasks--;
				}
				if (!tcTerrain.terrain.gameObject.activeSelf)
				{
					tcTerrain.terrain.gameObject.SetActive(value: true);
				}
			}
			TC_Compute.instance.camCapture.DisposeRTCapture();
		}

		public bool CheckForTerrain(bool selectTerrainArea = true)
		{
			if (area2D.terrainAreas == null)
			{
				area2D.terrainAreas = new TC_TerrainArea[1];
			}
			else if (area2D.terrainAreas.Length == 0)
			{
				area2D.terrainAreas = new TC_TerrainArea[1];
			}
			if (area2D.terrainAreas[0] == null)
			{
				GameObject gameObject = GameObject.Find("Terrain Area");
				if (!(gameObject != null))
				{
					TC.AddMessage("No Terrain Area is created.");
					return false;
				}
				TC_TerrainArea component = gameObject.GetComponent<TC_TerrainArea>();
				if (!(component != null))
				{
					TC.AddMessage("The Terrain Area GameObject is missing the 'TC_TerrainArea' script.");
					return false;
				}
				area2D.terrainAreas[0] = component;
			}
			bool flag = true;
			if (area2D.terrainAreas[0].terrains.Count == 0)
			{
				area2D.terrainAreas[0].terrains.Add(new TCUnityTerrain());
				flag = false;
			}
			for (int i = 0; i < area2D.terrainAreas[0].terrains.Count; i++)
			{
				if (!area2D.terrainAreas[0].terrains[i].CheckValidUnityTerrain())
				{
					if (selectTerrainArea)
					{
						TC.AddMessage("Terrain missing on X" + area2D.terrainAreas[0].terrains[i].tileX + "_Y" + area2D.terrainAreas[0].terrains[i].tileZ + "\n\nTC2 has automatically selected the Terrain Area GameObject.");
					}
					flag = false;
				}
			}
			if (!flag)
			{
				TC.AddMessage("Please create a terrain first.");
				return false;
			}
			return flag;
		}

		public void Generate(bool instantGenerate, int outputId = 6)
		{
			Generate(instantGenerate, new Rect(0f, 0f, 1f, 1f), outputId);
		}

		public void Generate(bool instantGenerate, Rect generateRect, int outputId = 6)
		{
			if (!CheckForTerrain())
			{
				return;
			}
			area2D = TC_Area2D.current;
			if (area2D == null || area2D.terrainLayer == null)
			{
				return;
			}
			if (area2D.terrainLayer.layerGroups[0] == null)
			{
				area2D.terrainLayer.GetItems(refresh: true);
			}
			if (TC_Settings.instance == null)
			{
				TC.AddMessage("Settings GameObject not found.");
				return;
			}
			generateRect = Mathw.ClampRect(generateRect, new Rect(0f, 0f, 1f, 1f));
			if (area2D.terrainAreas[0].terrains[0].texHeight == null)
			{
				_ = area2D.terrainLayer.layerGroups[0].visible;
			}
			isMesh = false;
			bool flag = true;
			TC_TerrainArea tC_TerrainArea = area2D.terrainAreas[0];
			for (int i = 0; i < tC_TerrainArea.terrains.Count; i++)
			{
				TCUnityTerrain tCUnityTerrain = tC_TerrainArea.terrains[i];
				if (tCUnityTerrain.texHeight == null || (scanHeight && !area2D.terrainLayer.layerGroups[0].active))
				{
					area2D.SetCurrentArea(tCUnityTerrain);
					RenderTexture rtHeight = tCUnityTerrain.rtHeight;
					TC_Compute.instance.RunTerrainTexFromTerrainData(tCUnityTerrain.terrain.terrainData, ref rtHeight);
					RenderTextureHeightToTexHeight(rtHeight, tCUnityTerrain, tCUnityTerrain.terrain);
				}
				Vector2 position = new Vector2((float)tCUnityTerrain.tileX / (float)tC_TerrainArea.tiles.x, (float)tCUnityTerrain.tileZ / (float)tC_TerrainArea.tiles.y);
				Rect testRect = new Rect(size: new Vector2(1f / (float)tC_TerrainArea.tiles.x, 1f / (float)tC_TerrainArea.tiles.y), position: position);
				if (!tCUnityTerrain.active || !Mathw.OverlapRect(generateRect, testRect, out var overlapRect))
				{
					continue;
				}
				Rect baseRect = new Rect((overlapRect.x - position.x) * (float)tC_TerrainArea.tiles.x, (overlapRect.y - position.y) * (float)tC_TerrainArea.tiles.y, overlapRect.width * (float)tC_TerrainArea.tiles.x, overlapRect.height * (float)tC_TerrainArea.tiles.y);
				baseRect = Mathw.ClampRect(baseRect, new Rect(0f, 0f, 1f, 1f));
				if (flag)
				{
					if (area2D.terrainLayer.layerGroups[3].active && (outputId == 6 || outputId == 3))
					{
						firstTreeTerrain = tCUnityTerrain;
					}
					if (area2D.terrainLayer.layerGroups[5].active && (outputId == 6 || outputId == 5))
					{
						firstObjectTerrain = tCUnityTerrain;
					}
					flag = false;
				}
				TC_Compute.instance.camCapture.collisionMask = 0;
				switch (outputId)
				{
				case 6:
					Generate(tCUnityTerrain, instantGenerate, baseRect);
					break;
				case 0:
					GenerateHeight(tCUnityTerrain, instantGenerate, baseRect, disableTerrain: false);
					break;
				default:
					GenerateOutput(tCUnityTerrain, outputId, instantGenerate, baseRect);
					break;
				}
			}
		}

		public void GenerateMesh()
		{
			isMesh = true;
		}

		public void Generate(TCUnityTerrain tcTerrain, bool instantGenerate, int outputId = 6)
		{
			Generate(tcTerrain, instantGenerate, new Rect(0f, 0f, 1f, 1f));
		}

		public void Generate(TCUnityTerrain tcTerrain, bool instantGenerate, Rect generateRect)
		{
			if (area2D.terrainLayer.layerGroups[0].active || area2D.terrainLayer.layerGroups[5].active)
			{
				GenerateHeight(tcTerrain, instantGenerate, generateRect, disableTerrain: false);
			}
			for (int i = 1; i <= 4; i++)
			{
				if (area2D.terrainLayer.layerGroups[i].active)
				{
					GenerateOutput(tcTerrain, i, instantGenerate, generateRect);
				}
			}
		}

		public void GenerateOutput(TCUnityTerrain tcTerrain, int outputId, bool instantGenerate, Rect generateRect)
		{
			if (!(area2D.terrainLayer.layerGroups[outputId] != null))
			{
				return;
			}
			tcTerrain.generateStatus |= Mathw.bit8[outputId];
			if (generate && !instantGenerate)
			{
				bool flag = true;
				if (stackEntry.Count == 0)
				{
					stackEntry.Add(new GenerateStackEntry(frame));
				}
				else if (stackEntry[0].frame != frame && stackEntry.Count == 1)
				{
					stackEntry.Add(new GenerateStackEntry(frame));
				}
				if (stackEntry.Count == 2)
				{
					List<GenerateStack> stack = stackEntry[1].stack;
					for (int i = 0; i < stack.Count; i++)
					{
						GenerateStack generateStack = stack[i];
						if (generateStack.tcTerrain == tcTerrain && generateStack.outputId == outputId && generateStack.assignTerrainHeightmap == assignTerrainHeightmap)
						{
							Mathw.EncapsulteRect(ref generateStack.generateRect, generateRect);
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					stackEntry[stackEntry.Count - 1].stack.Add(new GenerateStack(outputId, tcTerrain, assignTerrainHeightmap, generateRect));
				}
			}
			else
			{
				tcTerrain.tasks++;
				GenerateTerrain(tcTerrain, outputId);
				Compute(tcTerrain, outputId, generateRect);
			}
		}

		public void GenerateHeight(TCUnityTerrain tcTerrain, bool instantGenerate, Rect generateRect, bool disableTerrain)
		{
			TC_Compute.instance.camCapture.collisionMask = 0;
			assignTerrainHeightmap = true;
			if (area2D.terrainLayer.layerGroups[0].active && area2D.terrainLayer.layerGroups[5].active && area2D.terrainLayer.layerGroups[0].ContainsCollisionNode())
			{
				assignTerrainHeightmap = false;
			}
			if (area2D.terrainLayer.layerGroups[0].active)
			{
				GenerateOutput(tcTerrain, 0, instantGenerate, generateRect);
			}
			if (area2D.terrainLayer.layerGroups[5].active)
			{
				GenerateOutput(tcTerrain, 5, instantGenerate, generateRect);
			}
			if (!assignTerrainHeightmap)
			{
				assignTerrainHeightmap = true;
				GenerateOutput(tcTerrain, 0, instantGenerate, generateRect);
			}
			if (area2D.terrainLayer.layerGroups[5].active)
			{
				GenerateOutput(tcTerrain, 5, instantGenerate, generateRect);
			}
		}

		public bool GenerateStart()
		{
			TC_Area2D.current = area2D;
			if (area2D.terrainAreas[0] == null)
			{
				return false;
			}
			if (area2D.previewArea != null)
			{
				if (area2D.previewArea.manual)
				{
					area2D.SetManualTotalArea();
				}
				else if (!area2D.CalcTotalArea())
				{
					return false;
				}
			}
			else if (!area2D.CalcTotalArea())
			{
				return false;
			}
			area2D.terrainsDone = 0f;
			area2D.terrainsToDo = 0f;
			generate = true;
			for (int i = 0; i < area2D.terrainAreas.Length; i++)
			{
				area2D.terrainsToDo += area2D.terrainAreas[i].terrains.Count;
			}
			return true;
		}

		public void GenerateStop()
		{
			generateDone++;
		}

		public void ComputeTerrainAreas()
		{
			if (!GenerateStart())
			{
				return;
			}
			for (int i = 0; i < area2D.terrainAreas.Length; i++)
			{
				area2D.currentTerrainArea = area2D.terrainAreas[i];
				for (int j = 0; j < area2D.currentTerrainArea.terrains.Count; j++)
				{
				}
			}
			GenerateStop();
		}

		public void ComputeMeshTerrainAreas()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (!GenerateStart())
			{
				return;
			}
			for (int i = 0; i < area2D.meshTerrainAreas.Length; i++)
			{
				area2D.currentMeshTerrainArea = area2D.meshTerrainAreas[i];
				for (int j = 0; j < area2D.currentMeshTerrainArea.terrains.Count; j++)
				{
					area2D.currentMeshTerrainArea.terrains[j].SetNodesActive(active: true);
					if (ComputeMeshTerrain(0, area2D.currentMeshTerrainArea.terrains[j], doGenerateStart: false))
					{
						area2D.terrainsDone += 1f;
					}
					area2D.currentMeshTerrainArea.terrains[j].SetNodesActive(active: false);
				}
			}
			GenerateStop();
			float num = 1f / (Time.realtimeSinceStartup - realtimeSinceStartup);
			Debug.Log("Mesh Frames " + num);
		}

		public bool GenerateTerrain(TCUnityTerrain tcTerrain, int outputId, bool doGenerateStart = true)
		{
			if (tcTerrain == null)
			{
				return false;
			}
			if (doGenerateStart && !GenerateStart())
			{
				return false;
			}
			if (tcTerrain.updateTerrainPos)
			{
				tcTerrain.updateTerrainPos = false;
				tcTerrain.terrain.gameObject.SetActive(value: false);
				if (tcTerrain.terrain.terrainData.treeInstanceCount > 0)
				{
					tcTerrain.terrain.terrainData.treeInstances = new TreeInstance[0];
				}
				tcTerrain.terrain.transform.position = tcTerrain.newPos;
			}
			area2D.SetCurrentArea(tcTerrain, outputId);
			return true;
		}

		public void ReportArea()
		{
			Debug.Log("Resolution X " + area2D.resolution.x + " Y " + area2D.resolution.y);
			Debug.Log("IntResolution " + area2D.intResolution.ToString());
			Debug.Log("ResToTerrain X " + area2D.resolutionPM.x + " Y " + area2D.resolutionPM.y);
			Debug.Log("Bounds " + area2D.bounds);
			Debug.Log("StartPos X " + area2D.startPos.x + " Y " + area2D.startPos.y);
			Debug.Log("TerrainSize X " + area2D.terrainSize.x + " Y " + area2D.terrainSize.y);
			Debug.Log("Preview Resolution " + area2D.previewResolution);
			Debug.Log("ResToPreview X " + area2D.resToPreview.x + " Y " + area2D.resToPreview.y);
			Debug.Log("-------------------------------------------------------");
		}

		public bool ComputeMeshTerrain(int outputId, MeshTerrain tcMeshTerrain, bool doGenerateStart = true)
		{
			if (doGenerateStart && !GenerateStart())
			{
				return false;
			}
			area2D.currentMeshTerrain = tcMeshTerrain;
			Int2 @int = default(Int2);
			Int2 int2 = default(Int2);
			switch (outputId)
			{
			case 0:
				@int.x = (@int.y = area2D.terrainLayer.meshResolution + 2);
				int2 = new Int2(@int.x - 2, @int.y - 2);
				break;
			case 1:
				@int.x = (@int.y = area2D.terrainLayer.meshResolution);
				int2 = @int;
				break;
			case 2:
				@int.x = (@int.y = area2D.terrainLayer.meshResolution);
				int2 = @int;
				break;
			}
			area2D.resolution = new Vector2(@int.x, @int.y);
			area2D.intResolution = @int;
			TC_Reporter.Log("Resolution" + @int.ToString());
			MeshTerrain currentMeshTerrain = area2D.currentMeshTerrain;
			Vector2 vector = new Vector2(currentMeshTerrain.t.lossyScale.x * 10f, currentMeshTerrain.t.lossyScale.z * 10f);
			area2D.resolutionPM = new Vector2(vector.x / (float)int2.x, vector.y / (float)int2.y);
			area2D.area = new Rect(currentMeshTerrain.t.position.x - vector.x / 2f, currentMeshTerrain.t.position.z - vector.y / 2f, @int.x, @int.y);
			area2D.terrainSize = new Vector3(vector.x, 4800f, vector.y);
			area2D.bounds = new Bounds(new Vector3(currentMeshTerrain.t.position.x, 0f, currentMeshTerrain.t.position.z), area2D.terrainSize);
			area2D.startPos = new Vector3(area2D.area.xMin, currentMeshTerrain.t.position.y, area2D.area.yMin);
			return true;
		}

		public void ExportHeightmap(string path)
		{
			byte[] array = null;
			int num = 0;
			int resExpandBorder = TC_Area2D.current.resExpandBorder;
			for (int i = 0; i < area2D.terrainAreas[0].tiles.y; i++)
			{
				for (int j = 0; j < area2D.terrainAreas[0].tiles.x; j++)
				{
					TCUnityTerrain tCUnityTerrain = area2D.terrainAreas[0].terrains[num];
					Texture2D texHeight = tCUnityTerrain.texHeight;
					if (texHeight == null)
					{
						continue;
					}
					FileStream fileStream = new FileStream(path + "/" + TC_Settings.instance.heightmapFilename + "_x" + j + "_y" + i + ".raw", FileMode.Create);
					Color32[] pixels = tCUnityTerrain.texHeight.GetPixels32();
					Int2 @int = new Int2(texHeight.width - resExpandBorder * 2, texHeight.height - resExpandBorder * 2);
					int num2 = @int.x * @int.y;
					if (array == null)
					{
						array = new byte[num2 * 2];
					}
					else if (array.Length != num2 * 2)
					{
						array = new byte[num2 * 2];
					}
					for (int k = 0; k < @int.y; k++)
					{
						for (int l = 0; l < @int.x; l++)
						{
							int num3 = (k * @int.x + l) * 2;
							int num4 = (texHeight.height - k - 1 - resExpandBorder) * texHeight.width + l + resExpandBorder;
							array[num3] = pixels[num4].g;
							array[num3 + 1] = pixels[num4].r;
						}
					}
					fileStream.Write(array, 0, array.Length);
					fileStream.Close();
					num++;
				}
			}
		}

		public void ExportHeightmapCombined(string path)
		{
			TC_Settings tC_Settings = TC_Settings.instance;
			byte[] array = null;
			int num = 0;
			FileStream fileStream = new FileStream(path + "/" + TC_Settings.instance.heightmapFilename + ".raw", FileMode.Create);
			Int2 @int = ((tC_Settings.importSource != TC_Settings.ImportSource.TC2_TerrainArea) ? tC_Settings.importTiles : area2D.terrainAreas[0].tiles);
			for (int i = 0; i < @int.y; i++)
			{
				for (int j = 0; j < @int.x; j++)
				{
					TerrainData terrainData = ((tC_Settings.importSource != TC_Settings.ImportSource.TC2_TerrainArea) ? tC_Settings.importTerrains[num] : area2D.terrainAreas[0].terrains[num].terrain.terrainData);
					if (terrainData == null)
					{
						TC.AddMessage("TerrainData X" + j + "_Y" + i + " is null");
						num++;
						continue;
					}
					int heightmapResolution = terrainData.heightmapResolution;
					float[,] array2 = terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
					if (array == null)
					{
						array = new byte[heightmapResolution * 2];
					}
					else if (array.Length != heightmapResolution * 2)
					{
						array = new byte[heightmapResolution * 2];
					}
					fileStream.Seek(j * heightmapResolution * 2 + (@int.y - i - 1) * heightmapResolution * (heightmapResolution * 2 * @int.x), SeekOrigin.Begin);
					for (int k = 0; k < heightmapResolution; k++)
					{
						int num2 = 0;
						for (int l = 0; l < heightmapResolution; l++)
						{
							int num3 = (int)(array2[heightmapResolution - k - 1, l] * 65536f);
							byte b = (byte)(num3 >> 8);
							array[num2++] = (byte)(num3 - (b << 8));
							array[num2++] = b;
						}
						fileStream.Write(array, 0, array.Length);
						fileStream.Seek(heightmapResolution * 2 * (@int.x - 1), SeekOrigin.Current);
					}
					num++;
				}
			}
			fileStream.Close();
		}

		public void CreateLayerFromExportedHeightmap(string path)
		{
		}

		public void ExportNormalmap(string path, bool assignRTP)
		{
			Color32[] array = null;
			int num = 0;
			int resExpandBorder = TC_Area2D.current.resExpandBorder;
			float normalmapStrength = TC_Settings.instance.normalmapStrength;
			for (int i = 0; i < area2D.terrainAreas[0].tiles.y; i++)
			{
				for (int j = 0; j < area2D.terrainAreas[0].tiles.x; j++)
				{
					TCUnityTerrain tCUnityTerrain = area2D.terrainAreas[0].terrains[num];
					Texture2D texHeight = tCUnityTerrain.texHeight;
					if (texHeight == null)
					{
						continue;
					}
					Color32[] pixels = tCUnityTerrain.texHeight.GetPixels32();
					Int2 @int = new Int2(texHeight.width - resExpandBorder * 2, texHeight.height - resExpandBorder * 2);
					int num2 = @int.x * @int.y;
					TC_Compute.InitTexture(ref tCUnityTerrain.texNormalmap, TC_Settings.instance.normalmapFilename, @int.x, mipmap: true, TextureFormat.RGB24);
					if (array == null)
					{
						array = new Color32[num2];
					}
					else if (array.Length != num2)
					{
						array = new Color32[num2];
					}
					for (int k = 0; k < @int.y; k++)
					{
						for (int l = 0; l < @int.x; l++)
						{
							int num3 = k * @int.x + l;
							int num4 = (k + resExpandBorder) * texHeight.width + l + resExpandBorder;
							float num5 = ((float)(int)pixels[num4].b / 255f * 2f - 1f) * normalmapStrength;
							float num6 = ((float)(int)pixels[num4].a / 255f * 2f - 1f) * normalmapStrength;
							float num7 = Mathf.Sqrt(1f - num5 * num5 - num6 * num6);
							array[num3].r = pixels[num4].b;
							array[num3].g = pixels[num4].a;
							array[num3].b = (byte)(num7 * 255f);
						}
					}
					tCUnityTerrain.texNormalmap.SetPixels32(array);
					tCUnityTerrain.texNormalmap.Apply();
					num++;
				}
			}
		}

		public void ExportColormap(string path, bool assignRTP)
		{
		}

		public string ExportImage(string filePath, Texture2D tex)
		{
			byte[] bytes;
			string text;
			if (TC_Settings.instance.imageExportFormat == TC_Settings.ImageExportFormat.PNG)
			{
				bytes = tex.EncodeToPNG();
				text = "png";
			}
			else
			{
				bytes = tex.EncodeToJPG();
				text = "jpg";
			}
			filePath = filePath + "." + text;
			File.WriteAllBytes(filePath, bytes);
			return filePath;
		}

		public void ExportSplatmap(string path)
		{
			int num = 0;
			for (int i = 0; i < area2D.terrainAreas[0].tiles.y; i++)
			{
				for (int j = 0; j < area2D.terrainAreas[0].tiles.x; j++)
				{
					Terrain terrain = area2D.terrainAreas[0].terrains[num].terrain;
					if (terrain == null || terrain.terrainData == null)
					{
						continue;
					}
					Texture2D[] alphamapTextures = terrain.terrainData.alphamapTextures;
					for (int k = 0; k < alphamapTextures.Length; k++)
					{
						if (!(alphamapTextures[k] == null))
						{
							ExportImage(path + "/" + TC_Settings.instance.splatmapFilename + k + "_x" + j + "_y" + i, alphamapTextures[k]);
						}
					}
					num++;
				}
			}
		}

		private void RenderTextureHeightToTexHeight(RenderTexture rtHeight, TC_Terrain tcTerrain, Terrain terrain)
		{
			TC_Compute.InitTexture(ref tcTerrain.texHeight, "HeightTexture " + terrain.name, rtHeight.width, mipmap: true);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = rtHeight;
			tcTerrain.texHeight.ReadPixels(new Rect(0f, 0f, rtHeight.width, rtHeight.height), 0, 0);
			tcTerrain.texHeight.Apply();
			RenderTexture.active = active;
		}

		public void ComputeHeight(Rect generateRect)
		{
			TC_LayerGroup tC_LayerGroup = area2D.terrainLayer.layerGroups[0];
			if (tC_LayerGroup == null || !tC_LayerGroup.active)
			{
				return;
			}
			if (!assignTerrainHeightmap)
			{
				area2D.currentTCUnityTerrain.ResetObjects();
				area2D.terrainLayer.ResetObjects();
			}
			TC_Compute tC_Compute = TC_Compute.instance;
			int x = area2D.intResolution.x;
			ComputeBuffer totalBuffer = null;
			tC_LayerGroup.ComputeSingle(ref totalBuffer, 0f, first: true);
			if (totalBuffer == null)
			{
				TC_Reporter.Log("final buffer is null");
			}
			else
			{
				if (isMesh)
				{
					return;
				}
				tC_Compute.RunTerrainTex(totalBuffer, ref area2D.currentTCTerrain.rtHeight, x);
				RenderTexture rtHeight = area2D.currentTCTerrain.rtHeight;
				RenderTextureHeightToTexHeight(rtHeight, area2D.currentTCTerrain, area2D.currentTerrain);
				int resExpandBorder = area2D.resExpandBorder;
				int num = x - resExpandBorder * 2;
				generateRect = Mathw.ClampRect(generateRect, new Rect(0f, 0f, 1f, 1f));
				Rect rect = new Rect(Mathf.Floor((float)num * generateRect.x), Mathf.Floor((float)num * generateRect.y), Mathf.Ceil((float)num * generateRect.width), Mathf.Ceil((float)num * generateRect.height));
				TC.InitArray(ref heights, (int)rect.height, (int)rect.width);
				TC.InitArray(ref heightsReadback, x * x);
				totalBuffer.GetData(heightsReadback);
				tC_Compute.DisposeBuffer(ref totalBuffer);
				int num2 = (int)rect.height;
				int num3 = (int)rect.width;
				int num4 = (int)rect.x;
				int num5 = (int)rect.y;
				for (int i = 0; i < num2; i++)
				{
					for (int j = 0; j < num3; j++)
					{
						heights[i, j] = heightsReadback[j + resExpandBorder + num4 + (i + resExpandBorder + num5) * x];
					}
				}
				if (area2D.currentTCUnityTerrain.tileX == 0 && area2D.currentTCUnityTerrain.tileZ == 0)
				{
					area2D.currentTerrainArea.ResetNeighbors();
				}
				area2D.currentTerrain.terrainData.SetHeights(num4, num5, heights);
				if (area2D.currentTCUnityTerrain.tileX == area2D.currentTerrainArea.tiles.x - 1 && area2D.currentTCUnityTerrain.tileZ == area2D.currentTerrainArea.tiles.y - 1)
				{
					area2D.currentTerrainArea.SetNeighbors();
				}
			}
		}

		public void ComputeColor()
		{
			if (area2D.terrainLayer.layerGroups[2] == null)
			{
				return;
			}
			TC_Compute tC_Compute = TC_Compute.instance;
			tC_Compute.SetPreviewColors(tC_Compute.colors);
			ComputeBuffer maskBuffer = null;
			TC_Compute.InitRenderTextures(ref tC_Compute.rtsColor, "rtsColor", 1);
			TC_Compute.InitRenderTexture(ref tC_Compute.rtResult, "rtResult");
			area2D.terrainLayer.layerGroups[2].ComputeMulti(ref tC_Compute.rtsColor, ref maskBuffer, 0f);
			area2D.currentTerrainArea.rtColormap = tC_Compute.rtsColor[0];
			if (maskBuffer != null)
			{
				tC_Compute.DisposeBuffer(ref maskBuffer);
			}
			if (!isMesh)
			{
				RenderTexture active = RenderTexture.active;
				TC_Compute.InitTexture(ref area2D.currentTCUnityTerrain.texColormap, "texColormap", -1, mipmap: true, TextureFormat.RGB24, clamp: true, linear: false);
				Texture2D texColormap = area2D.currentTCUnityTerrain.texColormap;
				RenderTexture.active = area2D.currentTerrainArea.rtColormap;
				texColormap.ReadPixels(new Rect(0f, 0f, texColormap.width, texColormap.height), 0, 0);
				texColormap.Apply();
				if (TC_Settings.instance.isRTPDetected && TC_Settings.instance.autoColormapRTP)
				{
					area2D.currentTCUnityTerrain.AssignTextureRTP("ColorGlobal", area2D.currentTCUnityTerrain.texColormap);
				}
				RenderTexture.active = active;
			}
			else
			{
				area2D.currentMeshTerrain.rtpMat.SetTexture("_ColorMapGlobal", area2D.currentTerrainArea.rtColormap);
			}
		}

		public void ComputeSplat(Rect generateRect)
		{
			if (area2D.terrainLayer.layerGroups[1] == null)
			{
				return;
			}
			int splatLength = area2D.splatLength;
			int splatmapLength = area2D.splatmapLength;
			if (splatLength == 0)
			{
				TC.AddMessage("No splat textures assigned to terrain '" + area2D.currentTerrain.name + "'");
				TC.AddMessage("Splat textures can be assigned on the Terrain Area GameObject -> Splat tab.", 2f);
				return;
			}
			if (splatLength > 16)
			{
				TC.AddMessage("TC2 supports generating maximum " + 16 + " splat textures. There are " + splatLength + " on " + area2D.currentTerrain.name + " assigned.", 0f, 4f);
				return;
			}
			TC_Compute tC_Compute = TC_Compute.instance;
			ComputeBuffer maskBuffer = null;
			tC_Compute.SetPreviewColors(tC_Compute.splatColors);
			if (!isMesh)
			{
				TC_Compute.InitRenderTextures(ref area2D.currentTerrainArea.rtSplatmaps, "splatmapRTextures", splatmapLength);
			}
			TC_Compute.InitRenderTextures(ref tC_Compute.rtsResult, "resultRTextures", splatmapLength);
			RenderTexture[] renderTextures = area2D.currentTerrainArea.rtSplatmaps;
			area2D.terrainLayer.layerGroups[1].ComputeMulti(ref renderTextures, ref maskBuffer, 0f);
			if (maskBuffer != null)
			{
				tC_Compute.DisposeBuffer(ref maskBuffer);
			}
			if (!isMesh)
			{
				Texture2D[] alphamapTextures = area2D.currentTerrain.terrainData.alphamapTextures;
				generateRect = Mathw.ClampRect(generateRect, new Rect(0f, 0f, 1f, 1f));
				Int2 samplePos;
				Rect source = Mathw.UniformRectToResolution(generateRect, new Int2(renderTextures[0].width, renderTextures[0].height), new Int2(alphamapTextures[0].width, alphamapTextures[0].height), out samplePos);
				source.y = (float)renderTextures[0].width - source.y - source.height;
				RenderTexture active = RenderTexture.active;
				for (int i = 0; i < renderTextures.Length; i++)
				{
					RenderTexture.active = renderTextures[i];
					alphamapTextures[i].ReadPixels(source, samplePos.x, samplePos.y);
					alphamapTextures[i].Apply();
				}
				RenderTexture.active = active;
			}
			else
			{
				area2D.currentMeshTerrain.rtpMat.SetTexture("_Control1", renderTextures[0]);
				area2D.currentMeshTerrain.rtpMat.SetTexture("_Control2", renderTextures[1]);
				area2D.currentMeshTerrain.rtpMat.SetTexture("_Control3", renderTextures[1]);
			}
		}

		public void ComputeGrass()
		{
			if (area2D.terrainLayer.layerGroups[4] == null)
			{
				return;
			}
			int num = area2D.currentTerrain.terrainData.detailPrototypes.Length;
			if (num == 0)
			{
				TC.AddMessage("No grass assigned to terrain '" + area2D.currentTerrain.name + "'");
				TC.AddMessage("Grass can be assigned on the Terrain Area GameObject -> Grass tab.", 2f);
				return;
			}
			if (num > 16)
			{
				TC.AddMessage("TC2 supports generating maximum " + 16 + " grass textures. There are " + num + " on " + area2D.currentTerrain.name + " assigned.", 0f, 4f);
				return;
			}
			int x = area2D.intResolution.x;
			TC_Compute tC_Compute = TC_Compute.instance;
			tC_Compute.SetPreviewColors(tC_Compute.splatColors);
			ComputeBuffer maskBuffer = null;
			int length = Mathf.CeilToInt((float)num / 4f);
			TC_Compute.InitRenderTextures(ref tC_Compute.rtsSplatmap, "rtsSplatmap", length);
			TC_Compute.InitRenderTextures(ref tC_Compute.rtsResult, "rtsResult", length);
			RenderTexture[] renderTextures = tC_Compute.rtsSplatmap;
			area2D.terrainLayer.layerGroups[4].ComputeMulti(ref renderTextures, ref maskBuffer, 0f);
			tC_Compute.DisposeBuffer(ref maskBuffer);
			TC_Compute.InitTextures(ref tC_Compute.texGrassmaps, "grassTextures", length);
			tC_Compute.InitBytesArray(length);
			TC_Compute.BytesArray[] bytesArray = tC_Compute.bytesArray;
			RenderTexture active = RenderTexture.active;
			for (int i = 0; i < renderTextures.Length; i++)
			{
				RenderTexture.active = renderTextures[i];
				tC_Compute.texGrassmaps[i].ReadPixels(new Rect(0f, 0f, renderTextures[i].width, renderTextures[i].height), 0, 0);
				bytesArray[i].bytes = tC_Compute.texGrassmaps[i].GetRawTextureData();
			}
			RenderTexture.active = active;
			TC.InitArray(ref grass, x, x);
			for (int j = 0; j < num; j++)
			{
				int num2 = j / 4;
				int num3 = (1 + (j - num2 * 4)) % 4;
				for (int k = 0; k < x; k++)
				{
					for (int l = 0; l < x; l++)
					{
						int num4 = k * x * 4 + l * 4 + num3;
						grass[k, l] = (int)((float)(int)bytesArray[num2].bytes[num4] / 255f * 16f);
					}
				}
				area2D.currentTerrain.terrainData.SetDetailLayer(0, 0, j, grass);
			}
		}

		public void ComputeTree()
		{
			if (area2D.terrainLayer.layerGroups[3] == null)
			{
				return;
			}
			if (area2D.currentTerrain.terrainData.treePrototypes.Length == 0)
			{
				TC.AddMessage("No trees assigned to terrain '" + area2D.currentTerrain.name + "'");
				TC.AddMessage("Trees can be assigned on the Terrain Area GameObject -> Trees tab.", 2f);
				return;
			}
			if (firstTreeTerrain == area2D.currentTCTerrain)
			{
				area2D.terrainLayer.ResetPlaced();
				firstTreeTerrain = null;
			}
			int x = area2D.intResolution.x;
			TC_Compute tC_Compute = TC_Compute.instance;
			tC_Compute.SetPreviewColors(tC_Compute.splatColors);
			ComputeBuffer totalBuffer = null;
			area2D.terrainLayer.layerGroups[3].ComputeSingle(ref totalBuffer, 0f, first: true);
			ItemMap[] array = new ItemMap[x * x];
			totalBuffer.GetData(array);
			tC_Compute.DisposeBuffer(ref totalBuffer);
			if (trees == null)
			{
				trees = new List<TreeInstance>();
			}
			Vector3 size = area2D.currentTerrain.terrainData.size;
			Vector3 position = area2D.currentTerrain.transform.position;
			Vector3 outputOffsetV = area2D.outputOffsetV3;
			List<TC_SelectItem> treeSelectItems = TC_Area2D.current.terrainLayer.treeSelectItems;
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < x; j++)
				{
					int num = i * x + j;
					if (array[num].density * array[num].maskValue == 0f)
					{
						continue;
					}
					Vector3 vector = new Vector3((float)j / (float)x, 0f, (float)i / (float)x);
					Vector3 vector2 = vector + array[num].pos;
					if (!(vector2.x < 0f) && !(vector2.x > 1f) && !(vector2.z < 0f) && !(vector2.z > 1f))
					{
						int index = array[num].index;
						if (index > treeSelectItems.Count - 1)
						{
							TC.AddMessage("Tree index is out of bounds, index = " + index + ". Try the 'Refresh' button.");
							return;
						}
						TC_SelectItem tC_SelectItem = treeSelectItems[index];
						int selectIndex = tC_SelectItem.selectIndex;
						TC_SelectItem.Tree tree = tC_SelectItem.tree;
						Vector2 vector3 = new Vector2(vector.x * size.x, vector.z * size.z) + new Vector2(position.x - outputOffsetV.x, position.z - outputOffsetV.z);
						vector3 = Mathw.SnapVector2(vector3 + new Vector2(area2D.resolutionPM.x / 4f, area2D.resolutionPM.x / 4f), area2D.resolutionPM.x / 2f);
						TreeInstance item = new TreeInstance
						{
							color = Color.white,
							lightmapColor = Color.white,
							position = vector + array[num].pos,
							prototypeIndex = selectIndex,
							rotation = RandomPos(vector3 + new Vector2(225.5f, 350.5f)) * 360f
						};
						Vector2 vector4 = new Vector2(tree.scaleRange.x * tC_SelectItem.parentItem.scaleMinMaxMulti.x, tree.scaleRange.y * tC_SelectItem.parentItem.scaleMinMaxMulti.y);
						float num2 = vector4.y - vector4.x;
						if (num2 == 0f)
						{
							num2 = 0.001f;
						}
						item.heightScale = tree.scaleCurve.Evaluate(RandomPos(vector3)) * num2 + vector4.x;
						float num3 = tree.scaleMulti * tC_SelectItem.parentItem.scaleMulti;
						item.heightScale *= num3;
						if (tC_SelectItem.parentItem.linkScaleToMask)
						{
							item.heightScale *= Mathf.Lerp(1f, array[num].maskValue, tC_SelectItem.parentItem.linkScaleToMaskAmount);
						}
						if (item.heightScale < vector4.x * num3)
						{
							item.heightScale = vector4.x * num3;
						}
						item.widthScale = item.heightScale * (RandomPos(vector3 + new Vector2(997.5f, 500.5f)) * tree.nonUniformScale * 2f + (1f - tree.nonUniformScale));
						trees.Add(item);
						tC_SelectItem.placed++;
					}
				}
			}
			area2D.currentTerrain.terrainData.treeInstances = trees.ToArray();
			float[,] array2 = area2D.currentTerrain.terrainData.GetHeights(0, 0, 1, 1);
			area2D.currentTerrain.terrainData.SetHeights(0, 0, array2);
			trees.Clear();
			area2D.terrainLayer.CalcTreePlaced();
		}

		public void ComputeObject()
		{
			if (objectParent != null)
			{
				UnityEngine.Object.DestroyImmediate(objectParent);
			}
			if (area2D.terrainLayer.layerGroups[5] == null)
			{
				return;
			}
			if (area2D.terrainLayer.objectSelectItems.Count == 0)
			{
				TC.AddMessage("No objects nodes are active.");
				return;
			}
			if (firstObjectTerrain == area2D.currentTCTerrain)
			{
				area2D.terrainLayer.ResetPlaced();
				firstObjectTerrain = null;
			}
			int x = area2D.intResolution.x;
			Transform parent = CheckObjectsParent(area2D.currentTCUnityTerrain);
			if (assignTerrainHeightmap)
			{
				area2D.currentTCUnityTerrain.ResetObjects();
				area2D.terrainLayer.ResetObjects();
			}
			TC_Compute tC_Compute = TC_Compute.instance;
			tC_Compute.SetPreviewColors(tC_Compute.splatColors);
			ComputeBuffer totalBuffer = null;
			area2D.terrainLayer.layerGroups[5].ComputeSingle(ref totalBuffer, 0f, first: true);
			ItemMap[] array = new ItemMap[x * x];
			totalBuffer.GetData(array);
			tC_Compute.DisposeBuffer(ref totalBuffer);
			Vector3 size = area2D.currentTerrain.terrainData.size;
			Vector3 position = area2D.currentTerrain.transform.position;
			Vector3 outputOffsetV = area2D.outputOffsetV3;
			List<TC_SelectItem> objectSelectItems = TC_Area2D.current.terrainLayer.objectSelectItems;
			Vector3 euler = default(Vector3);
			Vector3 b = default(Vector3);
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < x; j++)
				{
					int num = i * x + j;
					if (array[num].density * array[num].maskValue == 0f)
					{
						continue;
					}
					Vector3 vector = new Vector3((float)j / (float)x, 0f, (float)i / (float)x);
					Vector3 vector2 = vector + array[num].pos;
					if (vector2.x < 0f || vector2.x > 1f || vector2.z < 0f || vector2.z > 1f)
					{
						continue;
					}
					int index = array[num].index;
					if (index > objectSelectItems.Count - 1)
					{
						TC.AddMessage("Object index is out of bounds, index = " + index + ". Try the 'Refresh' button.");
						return;
					}
					TC_SelectItem tC_SelectItem = objectSelectItems[index];
					TC_SelectItem.SpawnObject spawnObject = tC_SelectItem.spawnObject;
					vector = new Vector3(vector.x * size.x, vector.y, vector.z * size.z) + position;
					Vector3 vector3 = Mathw.SnapVector3(vector + new Vector3(area2D.resolutionPM.x / 4f, 0f, area2D.resolutionPM.x / 4f), area2D.resolutionPM.x / 2f) - outputOffsetV;
					vector += new Vector3(array[num].pos.x * size.x, 0f, array[num].pos.z * size.z);
					if (spawnObject.includeTerrainHeight)
					{
						vector.y = area2D.currentTerrain.SampleHeight(vector);
					}
					else
					{
						vector.y = 0f;
					}
					vector.y += TC_Settings.instance.generateOffset.y;
					UnityEngine.Random.InitState((int)vector3.x + (int)vector3.z * x);
					if (spawnObject.includeTerrainAngle)
					{
						Vector3 interpolatedNormal = area2D.currentTerrain.terrainData.GetInterpolatedNormal(vector2.x, vector2.z);
						euler.x = interpolatedNormal.z * 90f;
						euler.y = 0f;
						euler.z = interpolatedNormal.x * -90f;
					}
					else
					{
						euler = Vector3.zero;
					}
					if (spawnObject.lookAtTarget != null)
					{
						euler = Quaternion.LookRotation(spawnObject.lookAtTarget.position - vector).eulerAngles;
						if (!spawnObject.lookAtX)
						{
							euler.x = (euler.z = 0f);
						}
					}
					UnityEngine.Random.InitState((int)vector3.x + (int)vector3.z * x);
					float num2 = spawnObject.scaleMulti * tC_SelectItem.parentItem.scaleMulti;
					if (!spawnObject.customScaleRange)
					{
						Vector2 vector4 = new Vector2(spawnObject.scaleRange.x * tC_SelectItem.parentItem.scaleMinMaxMulti.x, spawnObject.scaleRange.y * tC_SelectItem.parentItem.scaleMinMaxMulti.y);
						float num3 = vector4.y - vector4.x;
						if (num3 == 0f)
						{
							num3 = 0.001f;
						}
						b.x = spawnObject.scaleCurve.Evaluate(UnityEngine.Random.value) * num3 + vector4.x;
						b.x *= num2;
						if (tC_SelectItem.parentItem.linkScaleToMask)
						{
							b.x *= Mathf.Lerp(1f, array[num].maskValue, tC_SelectItem.parentItem.linkScaleToMaskAmount);
						}
						if (b.x < vector4.x * num2)
						{
							b.x = vector4.x * num2;
						}
						b.y = b.x * UnityEngine.Random.Range(1f - spawnObject.nonUniformScale, 1f + spawnObject.nonUniformScale);
						b.z = b.x * UnityEngine.Random.Range(1f - spawnObject.nonUniformScale, 1f + spawnObject.nonUniformScale);
					}
					else
					{
						Vector2 vector5 = new Vector2(spawnObject.scaleRangeX.x * tC_SelectItem.parentItem.scaleMinMaxMulti.x, spawnObject.scaleRangeX.y * tC_SelectItem.parentItem.scaleMinMaxMulti.y);
						Vector2 vector6 = new Vector2(spawnObject.scaleRangeY.x * tC_SelectItem.parentItem.scaleMinMaxMulti.x, spawnObject.scaleRangeY.y * tC_SelectItem.parentItem.scaleMinMaxMulti.y);
						Vector2 vector7 = new Vector2(spawnObject.scaleRangeZ.x * tC_SelectItem.parentItem.scaleMinMaxMulti.x, spawnObject.scaleRangeZ.y * tC_SelectItem.parentItem.scaleMinMaxMulti.y);
						float num4 = vector5.y - vector5.x;
						if (num4 == 0f)
						{
							num4 = 0.001f;
						}
						float num5 = vector6.y - vector6.x;
						if (num5 == 0f)
						{
							num5 = 0.001f;
						}
						float num6 = vector7.y - vector7.x;
						if (num6 == 0f)
						{
							num6 = 0.001f;
						}
						b.x = spawnObject.scaleCurve.Evaluate(UnityEngine.Random.value) * num4 + vector5.x;
						b.y = spawnObject.scaleCurve.Evaluate(UnityEngine.Random.value) * num5 + vector6.x;
						b.z = spawnObject.scaleCurve.Evaluate(UnityEngine.Random.value) * num6 + vector7.x;
						b *= num2;
						if (tC_SelectItem.parentItem.linkScaleToMask)
						{
							b *= Mathf.Lerp(1f, array[num].maskValue, tC_SelectItem.parentItem.linkScaleToMaskAmount);
						}
						if (b.x < vector5.x * num2)
						{
							b.x = vector5.x * num2;
						}
						if (b.y < vector6.x * num2)
						{
							b.y = vector6.x * num2;
						}
						if (b.z < vector7.x * num2)
						{
							b.z = vector7.x * num2;
						}
					}
					vector.y += spawnObject.heightOffset;
					if (spawnObject.includeScale)
					{
						vector.y += UnityEngine.Random.Range(spawnObject.heightRange.x, spawnObject.heightRange.y) * b.y;
					}
					else
					{
						vector.y += UnityEngine.Random.Range(spawnObject.heightRange.x, spawnObject.heightRange.y);
					}
					GameObject obj = UnityEngine.Object.Instantiate(spawnObject.go, vector, Quaternion.Euler(euler));
					Transform transform = obj.transform;
					transform.Rotate(new Vector3(UnityEngine.Random.Range(spawnObject.rotRangeX.x, spawnObject.rotRangeX.y), UnityEngine.Random.Range(spawnObject.rotRangeY.x, spawnObject.rotRangeY.y), UnityEngine.Random.Range(spawnObject.rotRangeZ.x, spawnObject.rotRangeZ.y)), Space.Self);
					if (spawnObject.isSnapRot)
					{
						if (spawnObject.isSnapRotX)
						{
							euler.x = (float)(int)(euler.x / spawnObject.snapRotX) * spawnObject.snapRotX;
						}
						if (spawnObject.isSnapRotY)
						{
							euler.y = (float)(int)(euler.y / spawnObject.snapRotY) * spawnObject.snapRotY;
						}
						if (spawnObject.isSnapRotZ)
						{
							euler.z = (float)(int)(euler.z / spawnObject.snapRotZ) * spawnObject.snapRotZ;
						}
					}
					obj.name = spawnObject.go.name;
					if (spawnObject.parentMode == TC_SelectItem.SpawnObject.ParentMode.Terrain)
					{
						transform.parent = parent;
					}
					else if (spawnObject.parentMode == TC_SelectItem.SpawnObject.ParentMode.Existing)
					{
						transform.parent = spawnObject.parentT;
					}
					else if (spawnObject.parentMode == TC_SelectItem.SpawnObject.ParentMode.Create)
					{
						if (spawnObject.newParentT == null)
						{
							GameObject gameObject = new GameObject(spawnObject.parentName);
							if (spawnObject.parentToTerrain)
							{
								gameObject.transform.parent = parent;
							}
							spawnObject.newParentT = gameObject.transform;
						}
						transform.parent = spawnObject.newParentT;
					}
					transform.localScale = Vector3.Scale(spawnObject.go.transform.localScale, b);
					tC_SelectItem.placed++;
				}
			}
			area2D.terrainLayer.CalcObjectPlaced();
		}

		public float RandomPos(Vector2 pos)
		{
			return Mathw.Frac(Mathf.Sin(Vector2.Dot(pos, new Vector2(12.9898f, 78.233f))) * 43758.547f);
		}

		public Transform CheckObjectsParent(TCUnityTerrain tcUnityTerrain)
		{
			if (tcUnityTerrain.objectsParent == null)
			{
				tcUnityTerrain.objectsParent = new GameObject("TerrainComposer Objects").transform;
				tcUnityTerrain.objectsParent.parent = tcUnityTerrain.terrain.transform;
			}
			return tcUnityTerrain.objectsParent;
		}
	}
}
