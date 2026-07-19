using System.Collections.Generic;
using Kengine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
	public static List<PlayModule> playModules = new List<PlayModule>();

	private void Awake()
	{
	}

	public static void StartModule(int index)
	{
		SceneManager.LoadScene("ModuleGalaxy");
	}

	public static void ExportModules()
	{
		foreach (PlayModule playModule in playModules)
		{
			Saving.SaveObject(playModule, "Play/" + playModule.name + ".play");
		}
	}

	public static GameObject LoadModel(string path)
	{
		GameObject gameObject = new GameObject();
		Project.LoadFile(path, merge: true, gameObject.transform);
		return gameObject;
	}
}
