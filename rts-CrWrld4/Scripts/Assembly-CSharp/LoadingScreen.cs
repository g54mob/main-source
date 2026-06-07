using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	public Texture[] previewImages;

	public TextMeshProUGUI text;

	public RawImage previewImage;

	private static string fileToLoad;

	private static bool embeddedLoad;

	private static bool editMode;

	private static bool importMap;

	private static GameSpace.CATEGORY category;

	private static int colonyID;

	public static void LoadGame(bool editMode, bool importMap)
	{
	}

	public static void LoadGame(string fileToLoad, bool embeddedLoad, bool editMode, GameSpace.CATEGORY category, int colonyID = -1)
	{
	}

	public static void LoadGame(string fileToLoad, bool embeddedLoad, bool editMode, GameSpace.CATEGORY category, bool importMap, int colonyID = -1)
	{
	}

	public void Awake()
	{
	}

	public void Start()
	{
	}

	private void Load()
	{
	}

	public IEnumerator AsynchronousLoad(string scene)
	{
		return null;
	}
}
