using System;
using System.Collections;
using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public class TutorialEnabler : MonoBehaviour
{
	public GameObject tutorial;

	public GameObject[] objectsToDestroy;

	public Transform movePlayerTo;

	private List<GameObject> items = new List<GameObject>();

	private void Awake()
	{
		GameObject[] array = objectsToDestroy;
		for (int i = 0; i < array.Length; i++)
		{
			InventoryItemSpec[] componentsInChildren = array[i].GetComponentsInChildren<InventoryItemSpec>(includeInactive: true);
			foreach (InventoryItemSpec inventoryItemSpec in componentsInChildren)
			{
				items.Add(inventoryItemSpec.gameObject);
			}
		}
	}

	private IEnumerator Start()
	{
		while (SingletonBehaviour<SaveGameManager>.Instance.data == null)
		{
			Debug.Log("[TutorialEnabler] Waiting for savegame", this);
			yield return null;
		}
		var (flag, flag2, flag3) = GetTutorialCompletionStates();
		Debug.Log("[TutorialEnabler] " + string.Format("{0}: {1}, ", "completedTutorialPartOne", flag) + string.Format("{0}: {1}, ", "completedTutorialPartTwo", flag2) + string.Format("{0}: {1}", "completedTutorialAll", flag3), base.gameObject);
		if (!flag3)
		{
			SingletonBehaviour<SaveGameManager>.Instance.disableAutosave = true;
			tutorial.SetActive(value: true);
			Debug.Log("[TutorialEnabler] Enabling tutorial", base.gameObject);
			UnityEngine.Object.Destroy(this);
			yield break;
		}
		UnityEngine.Object.Destroy(tutorial);
		SingletonBehaviour<SaveGameManager>.Instance.disableAutosave = false;
		Debug.Log("[TutorialEnabler] Not enabling tutorial", base.gameObject);
		GameObject[] array = objectsToDestroy;
		for (int i = 0; i < array.Length; i++)
		{
			UnityEngine.Object.Destroy(array[i]);
		}
		foreach (GameObject item in items)
		{
			if ((bool)item)
			{
				UnityEngine.Object.Destroy(item);
			}
		}
		UnityEngine.Object.Destroy(this);
	}

	public static (bool completedTutorialPartOne, bool completedTutorialPartTwo, bool completedTutorialAll) GetTutorialCompletionStates()
	{
		if (SingletonBehaviour<SaveGameManager>.Instance.data == null)
		{
			throw new InvalidOperationException("GetTutorialCompletionStates called before waiting for SaveGameManager");
		}
		bool? flag = SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_01_completed");
		bool? flag2 = SingletonBehaviour<SaveGameManager>.Instance.data.GetBool("Tutorial_02_completed");
		bool flag3 = flag.HasValue && flag.Value;
		bool flag4 = flag2.HasValue && flag2.Value;
		return (completedTutorialPartOne: flag3, completedTutorialPartTwo: flag4, completedTutorialAll: flag3 && flag4);
	}
}
