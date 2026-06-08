using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class ResourceManager
{
	public enum MeshTypeEnum
	{
		Debris = 0,
		LargeObject = 1
	}

	private enum AssetTypeEnum
	{
		Unknown = 0,
		Resource = 1,
		Byte = 2
	}

	private class AssetItem
	{
		public int referenceCount { get; set; }

		public UnityEngine.Object referenceObject { get; set; }

		public AssetTypeEnum assetType { get; private set; }

		private AssetItem()
		{
		}

		public AssetItem(UnityEngine.Object obj, AssetTypeEnum assetType)
		{
			referenceCount = 1;
			referenceObject = obj;
			this.assetType = assetType;
		}
	}

	private static Dictionary<string, Material> DungeonMaterialDict;

	private static Dictionary<string, GameObject> ModelDict;

	private static GameObject[] PreInstatiatedSensorLinePrefabArray;

	private static int lastGivenSensorLineIndex = -1;

	private static Dictionary<string, AssetItem> assetDict;

	private static List<string> pathsToUnload;

	public static bool OneTimeBackgroundLoadPerformed { get; private set; }

	public static bool OneTimeGalaxyLoadPerformed { get; private set; }

	public static bool OneTimeDungeonLoadPerformed { get; private set; }

	public static GameObject ShipUpgradeObjectPrefab { get; private set; }

	public static GameObject ShipUpgradePermObjectPrefab { get; private set; }

	public static GameObject UpgradeSubSystem1SlotPrefab { get; private set; }

	public static GameObject UpgradeSubSystemPermSlotPrefab { get; private set; }

	public static GameObject BlankScreenPrefab { get; private set; }

	public static GameObject SelectionIconPrefab { get; private set; }

	public static GameObject ItemLabelPrefab { get; private set; }

	public static GameObject HintLabelPrefab { get; private set; }

	public static GameObject SensorLinePrefab { get; private set; }

	public static GameObject SensorRectanglePrefab { get; private set; }

	public static Material GenericTransparantDiffuseMaterial { get; private set; }

	public static Material GenericTransparantDiffuseCharacterMaterial { get; private set; }

	public static int CountDungeonMaterials
	{
		get
		{
			if (DungeonMaterialDict != null)
			{
				return DungeonMaterialDict.Count;
			}
			return 0;
		}
	}

	public static Texture2D SemiTransparantBackground50 { get; private set; }

	public static Texture2D SemiTransparantBackground70 { get; private set; }

	public static void OneTimeBackgroundLoad()
	{
		if (!OneTimeBackgroundLoadPerformed)
		{
			if (SemiTransparantBackground50 == null)
			{
				Texture2D texture = null;
				GenerateSemiTransparantBackgroundTexture(ref texture, 0.5f);
				SemiTransparantBackground50 = texture;
			}
			if (SemiTransparantBackground70 == null)
			{
				Texture2D texture2 = null;
				GenerateSemiTransparantBackgroundTexture(ref texture2, 0.7f);
				SemiTransparantBackground70 = texture2;
			}
			OneTimeBackgroundLoadPerformed = true;
		}
	}

	public static void OneTimeGalaxyResourceLoad()
	{
		OneTimeBackgroundLoad();
		if (SelectionIconPrefab == null)
		{
			SelectionIconPrefab = Resources.Load<GameObject>("Prefabs/GalaxySelectionIconPrefab");
			SelectionIconPrefab.SetActive(false);
		}
		OneTimeGalaxyLoadPerformed = true;
	}

	public static void UnloadGalaxyResources()
	{
		if (UnloadAsset("Prefabs/GalaxySelectionIconPrefab"))
		{
			SelectionIconPrefab = null;
		}
		OneTimeGalaxyLoadPerformed = false;
	}

	public static void OneTimeDungeonResourceLoad()
	{
		if (ShipUpgradeObjectPrefab == null)
		{
			ShipUpgradeObjectPrefab = LoadAsset<GameObject>("ShipUpgradeObjectPrefab");
			ShipUpgradeObjectPrefab.GetComponent<Renderer>().enabled = false;
		}
		if (ShipUpgradePermObjectPrefab == null)
		{
			ShipUpgradePermObjectPrefab = LoadAsset<GameObject>("ShipUpgradePermObjectPrefab");
			ShipUpgradePermObjectPrefab.GetComponent<Renderer>().enabled = false;
		}
		if (UpgradeSubSystem1SlotPrefab == null)
		{
			UpgradeSubSystem1SlotPrefab = LoadAsset<GameObject>("UpgradeSubSystem1SlotPrefab");
			UpgradeSubSystem1SlotPrefab.transform.FindChild("SingleSubSystemPrefab").gameObject.GetComponent<Renderer>().enabled = false;
		}
		if (UpgradeSubSystemPermSlotPrefab == null)
		{
			UpgradeSubSystemPermSlotPrefab = LoadAsset<GameObject>("UpgradeSubSystemPermSlotPrefab");
			UpgradeSubSystemPermSlotPrefab.transform.FindChild("SingleSubSystemPrefab").gameObject.GetComponent<Renderer>().enabled = false;
		}
		if (BlankScreenPrefab == null)
		{
			BlankScreenPrefab = LoadAsset<GameObject>("Prefabs/BlankScreenPrefab");
		}
		if (GenericTransparantDiffuseMaterial == null)
		{
			GenericTransparantDiffuseMaterial = LoadAsset<Material>("Materials/GenericTransparantMat");
		}
		if (GenericTransparantDiffuseCharacterMaterial == null)
		{
			GenericTransparantDiffuseCharacterMaterial = LoadAsset<Material>("Materials/CharacterBasicTransparentMat");
		}
		if (ItemLabelPrefab == null)
		{
			ItemLabelPrefab = LoadAsset<GameObject>("Prefabs/ItemLabelPrefab");
			ItemLabelPrefab.GetComponent<Renderer>().enabled = false;
		}
		if (HintLabelPrefab == null)
		{
			HintLabelPrefab = LoadAsset<GameObject>("Prefabs/HintTextCanvas");
		}
		if (SensorLinePrefab == null)
		{
			SensorLinePrefab = LoadAsset<GameObject>("SensorLinePrefab");
			SensorLinePrefab.GetComponent<Renderer>().enabled = false;
		}
		if (SensorRectanglePrefab == null)
		{
			SensorRectanglePrefab = LoadAsset<GameObject>("SensorRectanglePrefab");
			SensorRectanglePrefab.GetComponent<Renderer>().enabled = false;
		}
		if (PreInstatiatedSensorLinePrefabArray == null)
		{
			int num = 60;
			PreInstatiatedSensorLinePrefabArray = new GameObject[num];
			int num2 = num;
			for (int i = 0; i < num2; i++)
			{
				PreInstatiatedSensorLinePrefabArray[i] = UnityEngine.Object.Instantiate(SensorLinePrefab);
			}
			lastGivenSensorLineIndex = -1;
		}
		OneTimeDungeonLoadPerformed = true;
	}

	public static void ReInitDungeonResources()
	{
		if (SensorLinePrefab != null)
		{
			SensorLinePrefab.GetComponent<Renderer>().enabled = false;
		}
		if (SensorRectanglePrefab != null)
		{
			SensorRectanglePrefab.GetComponent<Renderer>().enabled = false;
		}
		int num = PreInstatiatedSensorLinePrefabArray.Length;
		for (int i = 0; i < num; i++)
		{
			if (PreInstatiatedSensorLinePrefabArray[i] == null)
			{
				PreInstatiatedSensorLinePrefabArray[i] = UnityEngine.Object.Instantiate(SensorLinePrefab);
			}
		}
		lastGivenSensorLineIndex = -1;
	}

	public static void UnloadDungeonResources()
	{
		if (OneTimeDungeonLoadPerformed)
		{
			if (ShipUpgradeObjectPrefab != null)
			{
				UnloadAsset("ShipUpgradeObjectPrefab");
				ShipUpgradeObjectPrefab = null;
			}
			if (ShipUpgradePermObjectPrefab != null)
			{
				UnloadAsset("ShipUpgradePermObjectPrefab");
				ShipUpgradePermObjectPrefab = null;
			}
			if (UpgradeSubSystem1SlotPrefab != null)
			{
				UnloadAsset("UpgradeSubSystem1SlotPrefab");
				UpgradeSubSystem1SlotPrefab = null;
			}
			if (UpgradeSubSystemPermSlotPrefab != null)
			{
				UnloadAsset("UpgradeSubSystemPermSlotPrefab");
				UpgradeSubSystemPermSlotPrefab = null;
			}
			if (BlankScreenPrefab != null)
			{
				UnloadAsset("Prefabs/BlankScreenPrefab");
				BlankScreenPrefab = null;
			}
			if (GenericTransparantDiffuseMaterial != null)
			{
				LoadAsset<Material>("Materials/GenericTransparantMat");
				GenericTransparantDiffuseMaterial = null;
			}
			if (GenericTransparantDiffuseCharacterMaterial != null)
			{
				LoadAsset<Material>("Materials/CharacterBasicTransparentMat");
				GenericTransparantDiffuseCharacterMaterial = null;
			}
			if (ItemLabelPrefab != null)
			{
				UnloadAsset("Prefabs/ItemLabelPrefab");
				ItemLabelPrefab = null;
			}
			if (HintLabelPrefab != null)
			{
				UnloadAsset("Prefabs/HintTextCanvas");
				HintLabelPrefab = null;
			}
			if (SensorLinePrefab != null)
			{
				UnloadAsset("SensorLinePrefab");
				SensorLinePrefab = null;
			}
			if (SensorRectanglePrefab == null)
			{
				UnloadAsset("SensorRectanglePrefab");
				SensorRectanglePrefab = null;
			}
			OneTimeDungeonLoadPerformed = false;
		}
	}

	public static GameObject GetNextSensorPrefab()
	{
		lastGivenSensorLineIndex++;
		if (lastGivenSensorLineIndex < PreInstatiatedSensorLinePrefabArray.Length)
		{
			return PreInstatiatedSensorLinePrefabArray[lastGivenSensorLineIndex];
		}
		Array.Resize(ref PreInstatiatedSensorLinePrefabArray, PreInstatiatedSensorLinePrefabArray.Length + 1);
		PreInstatiatedSensorLinePrefabArray[PreInstatiatedSensorLinePrefabArray.Length - 1] = UnityEngine.Object.Instantiate(SensorLinePrefab);
		return PreInstatiatedSensorLinePrefabArray[lastGivenSensorLineIndex];
	}

	public static GameObject GetMesh(MeshTypeEnum meshType, string key)
	{
		string text = "Prefabs/Models/";
		switch (meshType)
		{
		case MeshTypeEnum.Debris:
			text += "Floor Details/Debris";
			break;
		case MeshTypeEnum.LargeObject:
			text += "Big Props";
			break;
		default:
			Debug.LogError(string.Format("Mesh type not supported by GetMesh(): {0}", meshType));
			return null;
		}
		text = text + "/" + key;
		if (ModelDict == null)
		{
			ModelDict = new Dictionary<string, GameObject>();
		}
		if (!ModelDict.ContainsKey(text))
		{
			GameObject gameObject = Resources.Load<GameObject>(text);
			if (!(gameObject != null))
			{
				Debug.LogError(string.Format("Model not found: {0}", text));
				return null;
			}
			ModelDict.Add(text, gameObject);
		}
		return ModelDict[text];
	}

	public static void GenerateSemiTransparantBackgroundTexture(ref Texture2D texture, float alpha)
	{
		GenerateSemiTransparantBackgroundTexture(ref texture, alpha, 0f, 0f, 0f);
	}

	public static void GenerateSemiTransparantBackgroundTexture(ref Texture2D texture, float alpha, Color color)
	{
		GenerateSemiTransparantBackgroundTexture(ref texture, alpha, color.r, color.g, color.b);
	}

	public static void GenerateSemiTransparantBackgroundTexture(ref Texture2D texture, float alpha, float r, float g, float b)
	{
		texture = new Texture2D(1, 1);
		Color[] pixels = texture.GetPixels();
		Color color = new Color(r, g, b, alpha);
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = color;
		}
		texture.SetPixels(pixels);
		texture.Apply();
	}

	public static T LoadAsset<T>(string resourcePath) where T : UnityEngine.Object
	{
		if (assetDict == null)
		{
			assetDict = new Dictionary<string, AssetItem>();
		}
		if (!assetDict.ContainsKey(resourcePath))
		{
			UnityEngine.Object obj = Resources.Load(resourcePath);
			T val = (T)Resources.Load(resourcePath);
			if (!(val != null))
			{
				Debug.LogError(string.Format("Failed to load an asset: {0}", resourcePath));
				return (T)null;
			}
			AssetItem value = new AssetItem(val, AssetTypeEnum.Resource);
			assetDict.Add(resourcePath, value);
		}
		return (T)assetDict[resourcePath].referenceObject;
	}

	public static T GetAsset<T>(string resourcePath) where T : UnityEngine.Object
	{
		if (assetDict == null)
		{
			assetDict = new Dictionary<string, AssetItem>();
		}
		if (!assetDict.ContainsKey(resourcePath))
		{
			return LoadAsset<T>(resourcePath);
		}
		assetDict[resourcePath].referenceCount++;
		return (T)assetDict[resourcePath].referenceObject;
	}

	public static Texture2D LoadPNG(string path, int width, int height)
	{
		if (File.Exists(path))
		{
			if (assetDict == null)
			{
				assetDict = new Dictionary<string, AssetItem>();
			}
			if (!assetDict.ContainsKey(path))
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, false);
				texture2D.LoadImage(data);
				AssetItem value = new AssetItem(texture2D, AssetTypeEnum.Byte);
				assetDict.Add(path, value);
			}
			return (Texture2D)assetDict[path].referenceObject;
		}
		return null;
	}

	public static bool UnloadAsset(string resourcePath)
	{
		if (assetDict != null && assetDict.ContainsKey(resourcePath))
		{
			assetDict[resourcePath].referenceCount--;
			if (assetDict[resourcePath].referenceCount <= 0)
			{
				if (assetDict[resourcePath].assetType == AssetTypeEnum.Resource && assetDict[resourcePath].referenceObject.GetType() != typeof(GameObject) && assetDict[resourcePath].referenceObject.GetType() != typeof(Component))
				{
					Resources.UnloadAsset(assetDict[resourcePath].referenceObject);
				}
				else if (assetDict[resourcePath].assetType == AssetTypeEnum.Byte)
				{
					assetDict[resourcePath].referenceObject = null;
				}
				assetDict.Remove(resourcePath);
				return true;
			}
		}
		return false;
	}

	public static bool UnloadAssetFromPartialName(string resourcePathStart)
	{
		if (assetDict != null)
		{
			int count = assetDict.Count;
			char c = resourcePathStart[0];
			for (int num = count - 1; num > 0; num--)
			{
				KeyValuePair<string, AssetItem> keyValuePair = assetDict.ElementAt(num);
				string key = keyValuePair.Key;
				if (key.Length >= resourcePathStart.Length && resourcePathStart[0] == c && keyValuePair.Key.StartsWith(resourcePathStart))
				{
					AssetItem value = keyValuePair.Value;
					if (value.assetType == AssetTypeEnum.Resource && value.referenceObject.GetType() != typeof(GameObject) && value.referenceObject.GetType() != typeof(Component))
					{
						Resources.UnloadAsset(value.referenceObject);
					}
					else if (value.assetType == AssetTypeEnum.Byte)
					{
						value.referenceObject = null;
					}
					assetDict.Remove(key);
				}
			}
		}
		return false;
	}

	public static void QueueAssetToUnload(string path)
	{
		if (pathsToUnload == null)
		{
			pathsToUnload = new List<string>();
		}
		pathsToUnload.Add(path);
	}

	public static void UnloadQueuedAssets()
	{
		if (pathsToUnload != null)
		{
			int count = pathsToUnload.Count;
			for (int i = 0; i < count; i++)
			{
				UnloadAsset(pathsToUnload[i]);
			}
			pathsToUnload = null;
		}
	}

	public static void UnloadAll(bool unloadFonts)
	{
		if (assetDict != null)
		{
			int count = assetDict.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				if (unloadFonts || assetDict.ElementAt(num).Value.referenceObject.GetType() != typeof(Font))
				{
					UnloadAsset(assetDict.ElementAt(num).Key);
				}
			}
			assetDict = null;
		}
		Resources.UnloadUnusedAssets();
	}
}
