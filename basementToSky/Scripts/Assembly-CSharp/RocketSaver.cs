using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ES3Internal;
using PaintIn3D;
using UnityEngine;

public class RocketSaver : MonoBehaviour
{
	private const string GUID_LIST_KEY = "AllSavedRocketGUIDs";

	private void Start()
	{
		BusStopUI.OnTotheField += BusStopUI_OnTotheField;
		ES3AutoSaveMgr.OnPauseSaveDone += ES3AutoSaveMgr_OnPauseSaveDone;
		LoadRocket();
	}

	private void ES3AutoSaveMgr_OnPauseSaveDone()
	{
		SaveRockets();
	}

	private void OnDestroy()
	{
		BusStopUI.OnTotheField -= BusStopUI_OnTotheField;
		ES3AutoSaveMgr.OnPauseSaveDone -= ES3AutoSaveMgr_OnPauseSaveDone;
	}

	private void BusStopUI_OnTotheField()
	{
		SaveRockets();
	}

	private void LoadRocket()
	{
		string key = "Rockets";
		List<GameObject> list = new List<GameObject>();
		List<GameObject> list2 = new List<GameObject>();
		ES3AutoSaveMgr current = ES3AutoSaveMgr.Current;
		ES3SerializableSettings settings = ((current != null) ? current.settings : null);
		if (ES3.KeyExists(key, settings))
		{
			list2 = ES3.Load<List<GameObject>>(key, settings);
		}
		StartCoroutine(LoadAllTexturesDeferred());
		foreach (GameObject item in list2)
		{
			if (!item.activeSelf)
			{
				item.SetActive(value: true);
				StartCoroutine(DelayedInitRocket(item));
			}
		}
		if (!FirstPersonController.S.firstBoot)
		{
			return;
		}
		if (ES3.KeyExists("RocketOnHand", settings))
		{
			list = ES3.Load<List<GameObject>>("RocketOnHand", settings);
		}
		foreach (GameObject item2 in list)
		{
			if (item2.TryGetComponent<Rocket>(out var component))
			{
				StartCoroutine(LoadAllTexturesDeferred());
				StartCoroutine(DelayedGetRocket(component));
			}
		}
	}

	private IEnumerator DelayedInitRocket(GameObject rocket)
	{
		yield return null;
		yield return null;
		yield return null;
		rocket.gameObject.SetActive(value: false);
	}

	private IEnumerator DelayedGetRocket(Rocket rocket)
	{
		yield return null;
		rocket.Interact();
		FirstPersonController.S.rocket = rocket;
		FirstPersonController.S.rocketOnHand = true;
	}

	private void Update()
	{
	}

	public void SaveRockets()
	{
		List<GameObject> list = new List<GameObject>();
		Rocket[] array = Object.FindObjectsByType<Rocket>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		List<string> list2 = array.Select((Rocket r) => r.guid).ToList();
		CleanupOrphanedTextures(list2);
		Rocket[] array2 = array;
		foreach (Rocket rocket in array2)
		{
			SaveRocketTextures(rocket);
		}
		ES3.Save("AllSavedRocketGUIDs", list2);
		array2 = array;
		foreach (Rocket rocket2 in array2)
		{
			if (rocket2.gameObject != FirstPersonController.S.itemOnHand)
			{
				ES3Prefab[] componentsInChildren = rocket2.GetComponentsInChildren<ES3Prefab>();
				foreach (ES3Prefab eS3Prefab in componentsInChildren)
				{
					list.Add(eS3Prefab.gameObject);
				}
			}
		}
		string key = "Rockets";
		ES3AutoSaveMgr current = ES3AutoSaveMgr.Current;
		ES3SerializableSettings settings = ((current != null) ? current.settings : null);
		if (ES3.KeyExists(key, settings))
		{
			ES3.DeleteKey(key, settings);
		}
		if (list.Count > 0)
		{
			ES3.Save(key, list, settings);
		}
		if (ES3.KeyExists("RocketOnHand", settings))
		{
			ES3.DeleteKey("RocketOnHand", settings);
		}
		if (FirstPersonController.S.itemOnHand != null)
		{
			List<GameObject> list3 = new List<GameObject>();
			ES3Prefab[] componentsInChildren = FirstPersonController.S.itemOnHand.GetComponentsInChildren<ES3Prefab>();
			foreach (ES3Prefab eS3Prefab2 in componentsInChildren)
			{
				list3.Add(eS3Prefab2.gameObject);
			}
			ES3.Save("RocketOnHand", list3, settings);
		}
	}

	private void CleanupOrphanedTextures(List<string> currentGuids)
	{
		if (!ES3.KeyExists("AllSavedRocketGUIDs"))
		{
			return;
		}
		foreach (string item in ES3.Load<List<string>>("AllSavedRocketGUIDs"))
		{
			if (!currentGuids.Contains(item))
			{
				DeleteRocketTextureFiles(item);
			}
		}
	}

	private void DeleteRocketTextureFiles(string guid)
	{
		string[] array = new string[3] { "Head", "Body", "Nozzle" };
		foreach (string text in array)
		{
			string filePath = "Tex_" + guid + "_" + text + ".png";
			if (ES3.FileExists(filePath))
			{
				ES3.DeleteFile(filePath);
			}
		}
		int num = 0;
		while (true)
		{
			string filePath2 = $"Tex_{guid}_Wing_{num}.png";
			if (!ES3.FileExists(filePath2))
			{
				break;
			}
			ES3.DeleteFile(filePath2);
			num++;
		}
		Debug.Log("삭제된 로켓(GUID: " + guid + ")의 텍스처 파일을 정리했습니다.");
	}

	private void SaveRocketTextures(Rocket rocket)
	{
		if (rocket == null || string.IsNullOrEmpty(rocket.guid))
		{
			return;
		}
		SavePartTexture(rocket.rocketHead, rocket.guid, "Head");
		SavePartTexture(rocket.rocketBody, rocket.guid, "Body");
		SavePartTexture(rocket.rocketNozzle, rocket.guid, "Nozzle");
		if (rocket.cameraModule != null)
		{
			SavePartTexture(rocket.cameraModule, rocket.guid, "Cam");
		}
		if (rocket.rocketWing != null)
		{
			for (int i = 0; i < rocket.rocketWing.Count; i++)
			{
				SavePartTexture(rocket.rocketWing[i], rocket.guid, "Wing_" + i);
			}
		}
	}

	private void SavePartTexture(GameObject partGO, string guid, string partName)
	{
		CwPaintableMeshTexture componentInChildren = partGO.GetComponentInChildren<CwPaintableMeshTexture>();
		if (componentInChildren != null)
		{
			byte[] pngData = componentInChildren.GetPngData();
			if (pngData != null)
			{
				ES3.SaveRaw(pngData, "Tex_" + guid + "_" + partName + ".png");
			}
		}
	}

	private IEnumerator LoadAllTexturesDeferred()
	{
		yield return new WaitForEndOfFrame();
		Rocket[] array = Object.FindObjectsByType<Rocket>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		foreach (Rocket rocket in array)
		{
			Debug.Log("[RocketSaver] 로켓 " + rocket.guid + " 텍스처 로드 시도 중...");
			LoadRocketTextures(rocket);
		}
	}

	private void LoadRocketTextures(Rocket rocket)
	{
		if (rocket == null || string.IsNullOrEmpty(rocket.guid))
		{
			return;
		}
		LoadPartTexture(rocket.rocketHead, rocket.guid, "Head");
		LoadPartTexture(rocket.rocketBody, rocket.guid, "Body");
		LoadPartTexture(rocket.rocketNozzle, rocket.guid, "Nozzle");
		if (rocket.cameraModule != null)
		{
			LoadPartTexture(rocket.cameraModule, rocket.guid, "Cam");
		}
		if (rocket.rocketWing != null)
		{
			for (int i = 0; i < rocket.rocketWing.Count; i++)
			{
				LoadPartTexture(rocket.rocketWing[i], rocket.guid, "Wing_" + i);
			}
		}
	}

	private void LoadPartTexture(GameObject partGO, string guid, string partName)
	{
		string filePath = "Tex_" + guid + "_" + partName + ".png";
		if (ES3.FileExists(filePath))
		{
			byte[] data = ES3.LoadRawBytes(filePath);
			CwPaintableMeshTexture componentInChildren = partGO.GetComponentInChildren<CwPaintableMeshTexture>();
			if (componentInChildren != null)
			{
				componentInChildren.LoadFromData(data);
			}
		}
	}

	private void Temp()
	{
	}
}
