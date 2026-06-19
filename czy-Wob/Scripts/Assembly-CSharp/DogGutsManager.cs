using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogGutsManager : MonoBehaviour
{
	public Camera gutRenderCam;

	private Scene gutScene;

	private PhysicsScene2D gutPhysics;

	private float gutPhysicsTimer;

	private string gutSceneName = "GutScene";

	private string basePath = "GutFlora/";

	public List<GutFloraResource> allFlora = new List<GutFloraResource>();

	public Dictionary<string, string> floraNameToPathDict = new Dictionary<string, string>();

	private Vector3 offset = new Vector3(15f, 0f, 0f);

	private Vector3 startingPos = new Vector3(0f, 0f, -1000f);

	private int maxGuts = 100;

	private List<int> activeGutKeys = new List<int>();

	private Dictionary<int, DogGut> gutDict = new Dictionary<int, DogGut>();

	private PauseController pauseRef;

	private void Awake()
	{
		LoadFlora();
		CreateGutScene();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		pauseRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<PauseController>(GlobalObject.GLOBAL_CLOCK);
		if (!ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).IsBreedingScene() && !SceneManager.GetSceneByName(gutSceneName).IsValid())
		{
			CreateGutScene();
		}
	}

	private void CreateGutScene()
	{
		gutScene = SceneManager.CreateScene(parameters: new CreateSceneParameters(LocalPhysicsMode.Physics2D), sceneName: gutSceneName);
		gutPhysics = gutScene.GetPhysicsScene2D();
	}

	private void Update()
	{
		if (pauseRef == null || AreGutsPaused())
		{
			return;
		}
		gutPhysicsTimer += Time.unscaledDeltaTime;
		_ = gutPhysics;
		if (!gutPhysics.IsValid())
		{
			return;
		}
		while (gutPhysicsTimer >= Time.fixedDeltaTime)
		{
			for (int i = 0; i < activeGutKeys.Count; i++)
			{
				gutDict[activeGutKeys[i]].ManualFixedUpdate();
			}
			gutPhysicsTimer -= Time.fixedDeltaTime;
			gutPhysics.Simulate(Time.fixedDeltaTime);
		}
	}

	public bool AreGutsPaused()
	{
		if (PauseController.IsPaused() && !pauseRef.DogGutScreenOpen())
		{
			return true;
		}
		return false;
	}

	public PhysicsScene2D GetGutPhysicsScene()
	{
		return gutPhysics;
	}

	public void RenderGut(DogGut newGut)
	{
		if (!(newGut == null))
		{
			gutRenderCam.transform.position = newGut.transform.position - gutRenderCam.transform.forward * 5f;
		}
	}

	public void AddNewGut(GameObject gutObject)
	{
		int num = 0;
		for (int i = 0; i < maxGuts; i++)
		{
			if (!gutDict.ContainsKey(i) || gutDict[i] == null)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogError("Invalid gut index!");
			return;
		}
		gutDict[num] = gutObject.GetComponent<DogGut>();
		gutObject.transform.position = startingPos + offset * num;
		activeGutKeys.Add(num);
		SceneManager.MoveGameObjectToScene(gutObject, gutScene);
	}

	public void RemoveGut(DogGut gutObject)
	{
		int num = -1;
		for (int i = 0; i < activeGutKeys.Count; i++)
		{
			if (gutDict[activeGutKeys[i]] == gutObject)
			{
				num = activeGutKeys[i];
				break;
			}
		}
		if (num < 0)
		{
			Debug.LogError("No gut index found for: " + gutObject);
			return;
		}
		gutDict[num] = null;
		activeGutKeys.Remove(num);
	}

	private void LoadFlora()
	{
		LoadFloraPath(basePath);
	}

	private void LoadFloraPath(string path)
	{
		Object[] array = Resources.LoadAll(path);
		for (int i = 0; i < array.Length; i++)
		{
			GutFloraResource gutFloraResource = (GutFloraResource)array[i];
			floraNameToPathDict[gutFloraResource.gutFloraName] = path + gutFloraResource.name;
			if ((gutFloraResource.associatedItemSet != ItemSet.FISH || CheatEngine.fishPackEnabled) && (gutFloraResource.associatedItemSet != ItemSet.GROCERY || CheatEngine.groceryPackEnabled) && (gutFloraResource.associatedItemSet != ItemSet.DESERT || CheatEngine.desertPackEnabled) && (gutFloraResource.associatedItemSet != ItemSet.BASEMENT || CheatEngine.basementPackEnabled))
			{
				allFlora.Add(gutFloraResource);
			}
		}
	}

	public string GetPathForFlora(GutFloraResource flora)
	{
		if (flora == null)
		{
			return "";
		}
		return floraNameToPathDict[flora.gutFloraName];
	}

	public GutFloraResource GetFloraForPath(string path)
	{
		return (GutFloraResource)Resources.Load(path);
	}
}
