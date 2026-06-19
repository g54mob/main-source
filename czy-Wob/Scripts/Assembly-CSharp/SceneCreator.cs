using System.Collections.Generic;
using UnityEngine;

public class SceneCreator : MonoBehaviour
{
	public bool loadPenData = true;

	public bool mainMenuScreen;

	public GameObject saveFileHolder;

	private string saveFileHolderName = "SaveFileHolder";

	public GameObject objectRegistration;

	public List<GameObject> startupObjs;

	public List<GameObject> GUIStartupObjs;

	public List<GameObject> persistentObjs;

	public bool createStandardGUI = true;

	public GameObject sceneManager;

	public List<GameObject> customSceneObjects;

	private GameObject holderObj;

	private GameObject objectRegistrationRef;

	private GameObject persistentHolder;

	private void Awake()
	{
		GameSettings.ApplyStoredTextureQuality();
		GlobalProperties.UpdateGravity();
		GlobalProperties.UpdateTargetFramerate();
		SetUpObjects();
	}

	private void CreatePersistentObjects()
	{
		if (persistentObjs.Count != 0)
		{
			persistentHolder = new GameObject("Persistent Objects");
			Object.DontDestroyOnLoad(persistentHolder);
			for (int i = 0; i < persistentObjs.Count; i++)
			{
				GameObject obj = Object.Instantiate(persistentObjs[i]);
				obj.name = persistentObjs[i].name;
				obj.transform.SetParent(persistentHolder.transform);
			}
		}
	}

	private void SetUpObjects()
	{
		GameObject gameObject = GameObject.Find("Persistent Objects");
		if (gameObject != null)
		{
			persistentHolder = gameObject;
		}
		else
		{
			CreatePersistentObjects();
		}
		holderObj = new GameObject("Global Objects");
		objectRegistrationRef = Object.Instantiate(objectRegistration);
		objectRegistrationRef.transform.SetParent(holderObj.transform);
		ObjectRegistration component = objectRegistrationRef.GetComponent<ObjectRegistration>();
		component.StoreRegistryRef();
		GameObject obj = Object.Instantiate(sceneManager);
		obj.transform.SetParent(holderObj.transform);
		RegisterGlobalObject component2 = obj.GetComponent<RegisterGlobalObject>();
		if (component2 != null)
		{
			component2.Register(component);
		}
		GameObject gameObject2 = GameObject.Find(saveFileHolderName);
		if (gameObject2 == null)
		{
			gameObject2 = Object.Instantiate(saveFileHolder);
			gameObject2.name = saveFileHolderName;
			Object.DontDestroyOnLoad(gameObject2);
		}
		gameObject2.GetComponent<RegisterGlobalObject>().Register(component);
		if (persistentHolder != null)
		{
			for (int i = 0; i < persistentHolder.transform.childCount; i++)
			{
				component2 = persistentHolder.transform.GetChild(i).GetComponent<RegisterGlobalObject>();
				if (component2 != null)
				{
					component2.Register(component);
				}
			}
		}
		for (int j = 0; j < startupObjs.Count; j++)
		{
			GameObject obj2 = Object.Instantiate(startupObjs[j]);
			obj2.transform.SetParent(holderObj.transform);
			component2 = obj2.GetComponent<RegisterGlobalObject>();
			if (component2 != null)
			{
				component2.Register(component);
			}
		}
		for (int k = 0; k < customSceneObjects.Count; k++)
		{
			GameObject obj3 = Object.Instantiate(customSceneObjects[k]);
			obj3.transform.SetParent(holderObj.transform);
			component2 = obj3.GetComponent<RegisterGlobalObject>();
			if (component2 != null)
			{
				component2.Register(component);
			}
		}
		component.InitializeSaveLoadManager();
		if (!createStandardGUI)
		{
			return;
		}
		for (int l = 0; l < GUIStartupObjs.Count; l++)
		{
			component2 = Object.Instantiate(GUIStartupObjs[l], holderObj.transform).GetComponent<RegisterGlobalObject>();
			if (component2 != null)
			{
				component2.Register(component);
			}
		}
		GameSettings.ApplyStoredSettings(mainMenuScreen);
		ObjectRegistration.GetRegistrationScript().LoadData(loadPenData, mainMenuScreen);
	}
}
