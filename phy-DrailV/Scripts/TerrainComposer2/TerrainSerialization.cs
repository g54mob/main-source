using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class TerrainSerialization : MonoBehaviour
{
	public bool serialize;

	public bool deserialize;

	public Terrain[] terrains;

	private void Update()
	{
		if (serialize)
		{
			serialize = false;
			SaveTerrains(Application.dataPath + "/MyTerrain.dat", terrains);
		}
		if (deserialize)
		{
			deserialize = false;
			LoadTerrain(Application.dataPath + "/MyTerrain.dat");
		}
	}

	public void SaveTerrains(string path, Terrain[] terrains)
	{
		List<byte> list = new List<byte>();
		R_SerializationHelper.SerializeInt(list, terrains.Length);
		for (int i = 0; i < terrains.Length; i++)
		{
			SerializeTerrain(list, terrains[i]);
		}
		if (list.Count > 0)
		{
			FileStream fileStream = new FileStream(path, FileMode.Create);
			fileStream.Write(list.ToArray(), 0, list.Count);
			fileStream.Close();
		}
	}

	public void SaveTerrain(string path, Terrain terrain)
	{
		List<byte> list = new List<byte>();
		R_SerializationHelper.SerializeInt(list, 1);
		SerializeTerrain(list, terrain);
		if (list.Count > 0)
		{
			FileStream fileStream = new FileStream(path, FileMode.Create);
			fileStream.Write(list.ToArray(), 0, list.Count);
			fileStream.Close();
		}
	}

	public Terrain[] LoadTerrain(string path)
	{
		FileStream fileStream = new FileStream(path, FileMode.Open);
		if (fileStream == null)
		{
			Debug.Log(path + " not found.");
			return null;
		}
		byte[] array = new byte[fileStream.Length];
		fileStream.Read(array, 0, array.Length);
		int index = 0;
		int num = R_SerializationHelper.DeserializeInt(array, ref index);
		Terrain[] array2 = new Terrain[num];
		for (int i = 0; i < num; i++)
		{
			array2[i] = DeserializeTerrain(array, ref index);
		}
		return array2;
	}

	public void SerializeTerrain(List<byte> bytes, Terrain terrain)
	{
		if (!(terrain == null) && !(terrain.terrainData == null))
		{
			R_SerializationHelper.SerializeString(bytes, terrain.name);
			R_SerializationHelper.SerializeVector3(bytes, terrain.transform.position);
			R_SerializationHelper.SerializeFloat(bytes, terrain.basemapDistance);
			R_SerializationHelper.SerializeInt(bytes, (int)terrain.shadowCastingMode);
			R_SerializationHelper.SerializeBool(bytes, terrain.collectDetailPatches);
			R_SerializationHelper.SerializeFloat(bytes, terrain.detailObjectDensity);
			R_SerializationHelper.SerializeFloat(bytes, terrain.detailObjectDistance);
			R_SerializationHelper.SerializeBool(bytes, terrain.drawHeightmap);
			R_SerializationHelper.SerializeBool(bytes, terrain.drawTreesAndFoliage);
			R_SerializationHelper.SerializeInt(bytes, terrain.heightmapMaximumLOD);
			R_SerializationHelper.SerializeFloat(bytes, terrain.heightmapPixelError);
			R_SerializationHelper.SerializeInt(bytes, terrain.lightmapIndex);
			R_SerializationHelper.SerializeVector4(bytes, terrain.lightmapScaleOffset);
			if (terrain.materialTemplate != null)
			{
				bytes.Add(1);
				R_SerializationHelper.SerializeString(bytes, terrain.materialTemplate.name);
			}
			else
			{
				bytes.Add(0);
			}
			R_SerializationHelper.SerializeInt(bytes, terrain.realtimeLightmapIndex);
			R_SerializationHelper.SerializeVector4(bytes, terrain.realtimeLightmapScaleOffset);
			R_SerializationHelper.SerializeInt(bytes, (int)terrain.reflectionProbeUsage);
			R_SerializationHelper.SerializeFloat(bytes, terrain.treeBillboardDistance);
			R_SerializationHelper.SerializeFloat(bytes, terrain.treeCrossFadeLength);
			R_SerializationHelper.SerializeFloat(bytes, terrain.treeDistance);
			R_SerializationHelper.SerializeInt(bytes, terrain.treeMaximumFullLODCount);
			SerializeTerrainData(bytes, terrain.terrainData);
		}
	}

	public Terrain DeserializeTerrain(byte[] bytes, ref int index)
	{
		GameObject obj = Terrain.CreateTerrainGameObject(null);
		Terrain component = obj.GetComponent<Terrain>();
		TerrainCollider component2 = obj.GetComponent<TerrainCollider>();
		component.name = R_SerializationHelper.DeserializeString(bytes, ref index);
		component.transform.position = R_SerializationHelper.DeserializeVector3(bytes, ref index);
		component.basemapDistance = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.shadowCastingMode = (ShadowCastingMode)R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.collectDetailPatches = R_SerializationHelper.DeserializeBool(bytes, ref index);
		component.detailObjectDensity = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.detailObjectDistance = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.drawHeightmap = R_SerializationHelper.DeserializeBool(bytes, ref index);
		component.drawTreesAndFoliage = R_SerializationHelper.DeserializeBool(bytes, ref index);
		component.heightmapMaximumLOD = R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.heightmapPixelError = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.lightmapIndex = R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.lightmapScaleOffset = R_SerializationHelper.DeserializeVector4(bytes, ref index);
		if (bytes[index++] == 1)
		{
			R_SerializationHelper.DeserializeString(bytes, ref index);
		}
		component.realtimeLightmapIndex = R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.realtimeLightmapScaleOffset = R_SerializationHelper.DeserializeVector4(bytes, ref index);
		component.reflectionProbeUsage = (ReflectionProbeUsage)R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.treeBillboardDistance = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.treeCrossFadeLength = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.treeDistance = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		component.treeMaximumFullLODCount = R_SerializationHelper.DeserializeInt(bytes, ref index);
		component.terrainData = DeserializeTerrainData(bytes, ref index);
		component2.terrainData = component.terrainData;
		return component;
	}

	public void SerializeTerrainData(List<byte> bytes, TerrainData terrainData)
	{
		R_SerializationHelper.SerializeString(bytes, terrainData.name);
		int heightmapResolution = terrainData.heightmapResolution;
		int detailResolution = terrainData.detailResolution;
		R_SerializationHelper.SerializeInt(bytes, heightmapResolution);
		R_SerializationHelper.SerializeInt(bytes, terrainData.baseMapResolution);
		R_SerializationHelper.SerializeInt(bytes, terrainData.alphamapResolution);
		R_SerializationHelper.SerializeInt(bytes, detailResolution);
		R_SerializationHelper.SerializeVector3(bytes, terrainData.size);
		R_SerializationHelper.SerializeFloat(bytes, terrainData.wavingGrassAmount);
		R_SerializationHelper.SerializeFloat(bytes, terrainData.wavingGrassSpeed);
		R_SerializationHelper.SerializeFloat(bytes, terrainData.wavingGrassStrength);
		R_SerializationHelper.SerializeColor(bytes, terrainData.wavingGrassTint);
		TerrainLayer[] terrainLayers = terrainData.terrainLayers;
		R_SerializationHelper.SerializeInt(bytes, terrainLayers.Length);
		foreach (TerrainLayer terrainLayer in terrainLayers)
		{
			R_SerializationHelper.SerializeFloat(bytes, terrainLayer.metallic);
			if (terrainLayer.normalMapTexture != null)
			{
				bytes.Add(1);
				R_SerializationHelper.SerializeString(bytes, terrainLayer.normalMapTexture.name);
				R_SerializationHelper.SerializeFloat(bytes, terrainLayer.normalScale);
			}
			else
			{
				bytes.Add(0);
			}
			R_SerializationHelper.SerializeFloat(bytes, terrainLayer.smoothness);
			R_SerializationHelper.SerializeString(bytes, terrainLayer.diffuseTexture.name);
			R_SerializationHelper.SerializeVector2(bytes, terrainLayer.tileOffset);
			R_SerializationHelper.SerializeVector2(bytes, terrainLayer.tileSize);
		}
		TreePrototype[] treePrototypes = terrainData.treePrototypes;
		R_SerializationHelper.SerializeInt(bytes, treePrototypes.Length);
		foreach (TreePrototype treePrototype in treePrototypes)
		{
			R_SerializationHelper.SerializeFloat(bytes, treePrototype.bendFactor);
			R_SerializationHelper.SerializeString(bytes, treePrototype.prefab.name);
		}
		DetailPrototype[] detailPrototypes = terrainData.detailPrototypes;
		int num = detailPrototypes.Length;
		R_SerializationHelper.SerializeInt(bytes, detailPrototypes.Length);
		foreach (DetailPrototype detailPrototype in detailPrototypes)
		{
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.bendFactor);
			R_SerializationHelper.SerializeColor(bytes, detailPrototype.dryColor);
			R_SerializationHelper.SerializeColor(bytes, detailPrototype.healthyColor);
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.maxHeight);
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.maxWidth);
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.minHeight);
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.minWidth);
			R_SerializationHelper.SerializeFloat(bytes, detailPrototype.noiseSpread);
			if (detailPrototype.prototype != null)
			{
				bytes.Add(1);
				R_SerializationHelper.SerializeString(bytes, detailPrototype.prototype.name);
			}
			else
			{
				bytes.Add(0);
			}
			if (detailPrototype.prototypeTexture != null)
			{
				bytes.Add(1);
				R_SerializationHelper.SerializeString(bytes, detailPrototype.prototypeTexture.name);
			}
			else
			{
				bytes.Add(0);
			}
			R_SerializationHelper.SerializeInt(bytes, (int)detailPrototype.renderMode);
		}
		float[,] heights = terrainData.GetHeights(0, 0, heightmapResolution, heightmapResolution);
		R_SerializationHelper.Serialize2DFloatArray(bytes, heights);
		R_SerializationHelper.SerializeInt(bytes, terrainData.alphamapTextures.Length);
		for (int l = 0; l < terrainData.alphamapTextures.Length; l++)
		{
			byte[] array = terrainData.alphamapTextures[l].EncodeToPNG();
			R_SerializationHelper.SerializeInt(bytes, array.Length);
			bytes.AddRange(array);
		}
		TreeInstance[] treeInstances = terrainData.treeInstances;
		R_SerializationHelper.SerializeInt(bytes, treeInstances.Length);
		for (int m = 0; m < treeInstances.Length; m++)
		{
			TreeInstance treeInstance = treeInstances[m];
			R_SerializationHelper.SerializeColor(bytes, treeInstance.color);
			R_SerializationHelper.SerializeFloat(bytes, treeInstance.heightScale);
			R_SerializationHelper.SerializeColor(bytes, treeInstance.lightmapColor);
			R_SerializationHelper.SerializeVector3(bytes, treeInstance.position);
			R_SerializationHelper.SerializeInt(bytes, treeInstance.prototypeIndex);
			R_SerializationHelper.SerializeFloat(bytes, treeInstance.rotation);
			R_SerializationHelper.SerializeFloat(bytes, treeInstance.widthScale);
		}
		for (int n = 0; n < num; n++)
		{
			int[,] detailLayer = terrainData.GetDetailLayer(0, 0, detailResolution, detailResolution, n);
			R_SerializationHelper.Serialize2DIntArrayToBytes(bytes, detailLayer);
		}
	}

	public TerrainData DeserializeTerrainData(byte[] bytes, ref int index)
	{
		TerrainData terrainData = new TerrainData();
		terrainData.name = R_SerializationHelper.DeserializeString(bytes, ref index);
		int heightmapResolution = R_SerializationHelper.DeserializeInt(bytes, ref index);
		terrainData.heightmapResolution = heightmapResolution;
		terrainData.baseMapResolution = R_SerializationHelper.DeserializeInt(bytes, ref index);
		terrainData.alphamapResolution = R_SerializationHelper.DeserializeInt(bytes, ref index);
		int detailResolution = R_SerializationHelper.DeserializeInt(bytes, ref index);
		terrainData.SetDetailResolution(detailResolution, 16);
		terrainData.size = R_SerializationHelper.DeserializeVector3(bytes, ref index);
		terrainData.wavingGrassAmount = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		terrainData.wavingGrassSpeed = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		terrainData.wavingGrassStrength = R_SerializationHelper.DeserializeFloat(bytes, ref index);
		terrainData.wavingGrassTint = R_SerializationHelper.DeserializeColor(bytes, ref index);
		int num = R_SerializationHelper.DeserializeInt(bytes, ref index);
		TerrainLayer[] array = new TerrainLayer[num];
		for (int i = 0; i < num; i++)
		{
			TerrainLayer terrainLayer = new TerrainLayer();
			terrainLayer.metallic = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			if (bytes[index++] == 1)
			{
				string path = R_SerializationHelper.DeserializeString(bytes, ref index);
				terrainLayer.normalMapTexture = (Texture2D)Resources.Load(path);
				terrainLayer.normalScale = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			}
			terrainLayer.smoothness = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			string path2 = R_SerializationHelper.DeserializeString(bytes, ref index);
			terrainLayer.diffuseTexture = (Texture2D)Resources.Load(path2);
			terrainLayer.tileOffset = R_SerializationHelper.DeserializeVector2(bytes, ref index);
			terrainLayer.tileSize = R_SerializationHelper.DeserializeVector2(bytes, ref index);
			array[i] = terrainLayer;
		}
		terrainData.terrainLayers = array;
		int num2 = R_SerializationHelper.DeserializeInt(bytes, ref index);
		TreePrototype[] array2 = new TreePrototype[num2];
		for (int j = 0; j < num2; j++)
		{
			TreePrototype treePrototype = new TreePrototype();
			treePrototype.bendFactor = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			string path3 = R_SerializationHelper.DeserializeString(bytes, ref index);
			treePrototype.prefab = (GameObject)Resources.Load(path3);
			array2[j] = treePrototype;
		}
		terrainData.treePrototypes = array2;
		int num3 = R_SerializationHelper.DeserializeInt(bytes, ref index);
		DetailPrototype[] array3 = new DetailPrototype[num3];
		for (int k = 0; k < num3; k++)
		{
			DetailPrototype detailPrototype = new DetailPrototype();
			detailPrototype.bendFactor = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			detailPrototype.dryColor = R_SerializationHelper.DeserializeColor(bytes, ref index);
			detailPrototype.healthyColor = R_SerializationHelper.DeserializeColor(bytes, ref index);
			detailPrototype.maxHeight = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			detailPrototype.maxWidth = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			detailPrototype.minHeight = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			detailPrototype.minWidth = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			detailPrototype.noiseSpread = R_SerializationHelper.DeserializeFloat(bytes, ref index);
			if (bytes[index++] == 1)
			{
				R_SerializationHelper.DeserializeString(bytes, ref index);
			}
			if (bytes[index++] == 1)
			{
				string path4 = R_SerializationHelper.DeserializeString(bytes, ref index);
				detailPrototype.prototypeTexture = (Texture2D)Resources.Load(path4);
			}
			detailPrototype.renderMode = (DetailRenderMode)R_SerializationHelper.DeserializeInt(bytes, ref index);
			array3[k] = detailPrototype;
		}
		terrainData.detailPrototypes = array3;
		float[,] heights = R_SerializationHelper.Deserialize2DFloatArray(bytes, ref index);
		terrainData.SetHeights(0, 0, heights);
		int num4 = R_SerializationHelper.DeserializeInt(bytes, ref index);
		Texture2D[] alphamapTextures = terrainData.alphamapTextures;
		for (int l = 0; l < num4; l++)
		{
			int num5 = R_SerializationHelper.DeserializeInt(bytes, ref index);
			byte[] array4 = new byte[num5];
			Array.Copy(bytes, index, array4, 0, num5);
			index += num5;
			alphamapTextures[l].LoadImage(array4);
			alphamapTextures[l].Apply();
		}
		TreeInstance[] array5 = new TreeInstance[R_SerializationHelper.DeserializeInt(bytes, ref index)];
		for (int m = 0; m < array5.Length; m++)
		{
			array5[m] = new TreeInstance
			{
				color = R_SerializationHelper.DeserializeColor(bytes, ref index),
				heightScale = R_SerializationHelper.DeserializeFloat(bytes, ref index),
				lightmapColor = R_SerializationHelper.DeserializeColor(bytes, ref index),
				position = R_SerializationHelper.DeserializeVector3(bytes, ref index),
				prototypeIndex = R_SerializationHelper.DeserializeInt(bytes, ref index),
				rotation = R_SerializationHelper.DeserializeFloat(bytes, ref index),
				widthScale = R_SerializationHelper.DeserializeFloat(bytes, ref index)
			};
		}
		terrainData.treeInstances = array5;
		for (int n = 0; n < num3; n++)
		{
			int[,] details = R_SerializationHelper.Deserialize2DByteArrayToInt(bytes, ref index);
			terrainData.SetDetailLayer(0, 0, n, details);
		}
		return terrainData;
	}
}
