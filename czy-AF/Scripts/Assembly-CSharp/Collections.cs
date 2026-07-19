using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Dummiesman;
using UnityEngine;

public class Collections : MonoBehaviour
{
	public static List<Collection> collections = new List<Collection>();

	private static List<string> fileFormats = new List<string> { ".gltf", ".obj", ".fbx", ".3ds", ".blend", ".dae" };

	public static List<string> collectionsList = new List<string>();

	public static List<Block> blocks = new List<Block>();

	public static List<Block> recentlyUsedBlocks = new List<Block>();

	public static DirectoryInfo customCollectionPath;

	public Transform templateBlock;

	public static Material blitMaterial;

	public static Collections instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		blitMaterial = Resources.Load<Material>("Materials/Internal/Downsample");
		collections.Sort();
		collections.Add(new Collection("All", 3));
		collections.Add(new Collection("Recently used", 3));
		collections.Add(new Collection("Favorites", 3));
		GameObject[] array = Resources.LoadAll<GameObject>("Collections");
		foreach (GameObject gameObject in array)
		{
			collections.Add(new Collection(gameObject.name));
		}
		foreach (PlayModule playModule in Play.playModules)
		{
			if (playModule.unlocked && Resources.Load<GameObject>("Modules/" + playModule.name + "/Collection/collection") != null)
			{
				collections.Add(new Collection(playModule.name, 2));
			}
		}
		customCollectionPath = new DirectoryInfo(Global.GetDataFolder("Collections"));
		try
		{
			DirectoryInfo[] directories = customCollectionPath.GetDirectories();
			foreach (DirectoryInfo directoryInfo in directories)
			{
				if (new DirectoryInfo(Global.GetDataFolder("Collections") + directoryInfo.Name).GetFiles("*.obj").Length != 0)
				{
					collections.Add(new Collection(directoryInfo.Name, 1));
				}
			}
		}
		catch (Exception ex)
		{
			Global.Log("Directory for collections could not be found (" + ex?.ToString() + ")");
		}
		Global.Log("(Custom) collections found:");
		foreach (Collection collection in collections)
		{
			Global.Log(collection.name);
		}
		UpdateList();
		CollectBlocks();
	}

	public void UpdateList()
	{
		foreach (Collection collection in collections)
		{
			collectionsList.Add(collection.name);
		}
	}

	public void CollectBlocks()
	{
		foreach (Collection collection in collections)
		{
			if (collection.type == 0)
			{
				foreach (Transform item in Resources.Load<GameObject>("Collections/" + collection.name).transform)
				{
					if (!item.name.Contains("%") || (Global.deluxe && item.name.Contains("%")))
					{
						blocks.Add(new Block(item.name, collection.name, item.gameObject));
					}
				}
			}
			else if (collection.type == 1)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(Global.GetDataFolder("Collections") + collection.name);
				FileInfo[] files = directoryInfo.GetFiles("*.obj");
				foreach (FileInfo fileInfo in files)
				{
					Block block = new Block(Path.GetFileNameWithoutExtension(fileInfo.FullName), collection.name, fileInfo.FullName);
					if (File.Exists(directoryInfo?.ToString() + "/meta.ini"))
					{
						StreamReader streamReader = new StreamReader(directoryInfo?.ToString() + "/meta.ini");
						string[] array = streamReader.ReadToEnd().Split("\n"[0]);
						foreach (string text in array)
						{
							if (text.Contains("scale"))
							{
								block.scale = float.Parse(text.Split("="[0])[1]);
							}
							if (text.Contains("rotation"))
							{
								block.rotation = Global.ParseVector3(text.Split("="[0])[1]);
							}
						}
						streamReader.Close();
					}
					blocks.Add(block);
				}
				foreach (string item2 in Directory.EnumerateFiles(Global.GetDataFolder("Collections") + collection.name, "*.png", SearchOption.AllDirectories))
				{
					Texture2D texture2D = new Texture2D(2, 2);
					texture2D.LoadImage(File.ReadAllBytes(item2));
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(item2);
					fileNameWithoutExtension = collection.name.ToLower().Replace(" ", "_") + "-" + fileNameWithoutExtension;
					Textures.AddTexture(fileNameWithoutExtension, "Custom", texture2D, _custom: true);
				}
			}
			else
			{
				if (collection.type != 2)
				{
					continue;
				}
				foreach (Transform item3 in Resources.Load<GameObject>("Modules/" + collection.name + "/Collection/collection").transform)
				{
					blocks.Add(new Block(item3.name, collection.name, item3.gameObject));
				}
			}
		}
	}

	public static List<Block> GetBlocks(string filterCollection = "", string filterType = "", bool strict = false)
	{
		if (filterCollection == "All")
		{
			filterCollection = "";
		}
		List<Block> list = new List<Block>();
		foreach (Block block in blocks)
		{
			bool flag = true;
			if (filterCollection != "" && block.collection != filterCollection)
			{
				flag = false;
			}
			if (!strict)
			{
				if (filterType != "" && !block.type.Contains(filterType))
				{
					flag = false;
				}
			}
			else if (filterType != "" && block.type != filterType)
			{
				flag = false;
			}
			if (flag)
			{
				list.Add(block);
			}
		}
		return list;
	}

	public void LoadCollection(int c)
	{
		ComponentPages component = PanelCollection.collectionList.GetComponent<ComponentPages>();
		component.Clear();
		List<Block> list = GetBlocks(collections[c].name);
		for (int i = 0; i < list.Count; i++)
		{
			component.AddData(new Hashtable
			{
				{
					"name",
					"item_" + list[i].type
				},
				{
					"block",
					list[i]
				},
				{
					"deluxe",
					list[i].type.Contains("%")
				},
				{
					"custom",
					list[i].path != null
				},
				{
					"tooltip",
					list[i].type.Replace("%", "")
				}
			});
		}
		component.UpdateDisplay();
	}

	public void LoadCollectionDynamic(int c)
	{
		string text = collections[c].name;
		ComponentPages component = PanelCollection.collectionList.GetComponent<ComponentPages>();
		component.Clear();
		List<Block> list = new List<Block>();
		if (!(text == "Recently used"))
		{
			if (text == "Favorites")
			{
				foreach (string favorite in Preferences.data.favorites)
				{
					foreach (Block block in blocks)
					{
						if ($"{block.collection}/{block.type}" == favorite)
						{
							list.Add(block);
							break;
						}
					}
				}
			}
		}
		else
		{
			list = recentlyUsedBlocks;
		}
		for (int i = 0; i < list.Count; i++)
		{
			component.AddData(new Hashtable
			{
				{
					"name",
					"item_" + list[i].type
				},
				{
					"block",
					list[i]
				},
				{
					"deluxe",
					list[i].type.Contains("%")
				},
				{
					"custom",
					list[i].path != null
				},
				{
					"tooltip",
					list[i].type.Replace("%", "")
				}
			});
		}
		component.UpdateDisplay();
	}

	public static void ToggleFavorite(Block _block)
	{
		string item = $"{_block.collection}/{_block.type}";
		if (Preferences.data.favorites.Contains(item))
		{
			Preferences.data.favorites.Remove(item);
			Global.ShowMessage($"{_block.type} removed from favorites");
		}
		else
		{
			Preferences.data.favorites.Add(item);
			Global.ShowMessage($"{_block.type} added to favorites");
		}
	}

	public static void AddRecentlyUsedBlock(Block _block)
	{
		foreach (Block recentlyUsedBlock in recentlyUsedBlocks)
		{
			if (recentlyUsedBlock == _block)
			{
				recentlyUsedBlocks.Remove(_block);
				break;
			}
		}
		recentlyUsedBlocks.Insert(0, _block);
	}

	public static GameObject CreateBlock(string _collection, string _block, bool addComponent = false)
	{
		GameObject gameObject = null;
		List<Block> list = GetBlocks(_collection, _block, strict: true);
		if (list.Count == 0)
		{
			return null;
		}
		Block block = list[0];
		if (block.path != null)
		{
			GameObject gameObject2 = LoadMesh(block.path);
			if (gameObject2 == null)
			{
				Debug.LogWarning("CreateBlock warning: Failed to load mesh from path '" + block.path + "'.");
				return null;
			}
			GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2);
			gameObject3.AddComponent<MeshCollider>().sharedMesh = gameObject3.GetComponent<MeshFilter>().sharedMesh;
			gameObject3.transform.localScale = new Vector3(block.scale, block.scale, block.scale);
			gameObject3.transform.eulerAngles = block.rotation;
			Shaders.ShaderCheck(gameObject3.transform);
			Material[] materials = gameObject3.transform.GetComponent<Renderer>().materials;
			foreach (Material material in materials)
			{
				string text = _collection.ToLower().Replace(" ", "_");
				material.name = text + "-" + material.name;
				if (material.mainTexture != null)
				{
					material.mainTexture.name = text + "-" + material.mainTexture.name;
					material.mainTexture = Textures.GetTexture(material.mainTexture.name).texture;
				}
			}
			gameObject = gameObject3;
			gameObject.name = block.type;
			UnityEngine.Object.DestroyImmediate(gameObject2);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate(block.model, Vector3.zero, Quaternion.identity);
			gameObject.name = block.model.name;
			_ = gameObject.GetComponent<MeshFilter>().mesh;
		}
		if (addComponent)
		{
			BlockComponent blockComponent = gameObject.AddComponent<BlockComponent>();
			blockComponent.data.collection = _collection;
			blockComponent.data.type = _block;
		}
		return gameObject;
	}

	public static GameObject CreateBlock(string block)
	{
		string[] array = block.Split("/"[0]);
		return CreateBlock(array[0], array[1]);
	}

	public static void PrepareBlock(Transform target)
	{
		foreach (Material material in Swatches.GetMaterials(target))
		{
			Swatches.AddMaterial(material);
		}
		Swatches.UpdateMaterials();
	}

	public static void PrepareBlock(GameObject target)
	{
		PrepareBlock(target.transform);
	}

	public void Select(int i)
	{
		LoadCollection(i);
		Toolbox.collectionSearch.GetComponent<ComponentSearch>().Clear();
	}

	public static Texture2D RenderCamera(Camera camera, int resolution)
	{
		resolution *= 2;
		blitMaterial.SetInt("_Resolution", resolution);
		RenderTexture obj = (camera.targetTexture = new RenderTexture(resolution, resolution, 32));
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = camera.targetTexture;
		camera.Render();
		RenderTexture renderTexture2 = new RenderTexture(camera.targetTexture.width / 2, camera.targetTexture.height / 2, 32, RenderTextureFormat.ARGB32);
		Graphics.Blit(camera.targetTexture, renderTexture2, blitMaterial);
		Texture2D texture2D = new Texture2D(renderTexture2.width, renderTexture2.height, TextureFormat.ARGB32, mipChain: false);
		RenderTexture.active = renderTexture2;
		texture2D.ReadPixels(new Rect(0f, 0f, renderTexture2.width, renderTexture2.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		camera.targetTexture = null;
		UnityEngine.Object.Destroy(renderTexture2);
		UnityEngine.Object.Destroy(obj);
		return texture2D;
	}

	public static GameObject LoadMesh(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			Debug.LogError("LoadMesh failed: Path is null or empty.");
			return null;
		}
		if (!File.Exists(path))
		{
			Debug.LogError("LoadMesh failed: File does not exist at path {path}");
			return null;
		}
		try
		{
			GameObject gameObject = new OBJLoader
			{
				SplitMode = SplitMode.Material
			}.Load(path);
			if (gameObject == null)
			{
				Global.ShowDialog("error", null, "error", $"There was a problem loading {path}");
				Debug.LogError("LoadMesh failed: OBJLoader returned null.");
				return null;
			}
			GameObject gameObject2 = MeshCombiner.Combine(gameObject);
			if (gameObject2 == null)
			{
				Debug.LogError("LoadMesh failed: MeshCombiner returned null.");
				UnityEngine.Object.DestroyImmediate(gameObject);
				return null;
			}
			UnityEngine.Object.DestroyImmediate(gameObject);
			return gameObject2;
		}
		catch (Exception ex)
		{
			Debug.LogError("LoadMesh failed: Exception occurred while loading mesh. " + ex.Message);
			return null;
		}
	}

	public static void CountCollections()
	{
		int num = 0;
		int num2 = 0;
		foreach (Block block in blocks)
		{
			num++;
			if (block.type.Contains("%"))
			{
				num2++;
			}
		}
		MonoBehaviour.print(string.Format("Total of {0} blocks, of which {1} deluxe only ({2}%)", num, num2, ((float)(num2 * 100 / num)).ToString("F1")));
	}
}
