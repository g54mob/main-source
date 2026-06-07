using System.Collections.Generic;
using UnityEngine;

public class ModLoader : MonoBehaviour
{
	public static ModLoader instance;

	[SerializeField]
	private Transform modShopItemsParent;

	[SerializeField]
	private GameObject modShopButtonPrefab;

	private Dictionary<int, GameObject> modTemplates;

	private Dictionary<string, GameObject> modTemplatesByFolder;

	private int nextModID;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void LoadAllMods()
	{
	}

	private void LoadMod(string folderPath)
	{
	}

	private GameObject CreateModTemplate(ModConfig config, Mesh mesh, Material material, string folderName)
	{
		return null;
	}

	private void CreateShopButton(int modID, ModConfig config, Sprite icon)
	{
	}

	public GameObject GetModPrefab(int modID)
	{
		return null;
	}

	public GameObject GetModPrefabByFolder(string folderName)
	{
		return null;
	}

	private Texture2D LoadTexture(string path)
	{
		return null;
	}

	private void OnDestroy()
	{
	}
}
