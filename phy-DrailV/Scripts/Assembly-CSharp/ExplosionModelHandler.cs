using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionModelHandler : MonoBehaviour
{
	[Serializable]
	public class MaterialSwapData
	{
		public Material swapMaterial;

		public GameObject[] affectedGameObjects;

		[NonSerialized]
		public List<(Renderer renderer, Material originalMat)> affectedRenderers;
	}

	[Serializable]
	public class GameObjectSwapData
	{
		public GameObject gameObjectToReplace;

		public GameObject replacePrefab;

		public GameObjectSwapData(GameObject gameObjectToReplace, GameObject replacePrefab)
		{
			this.gameObjectToReplace = gameObjectToReplace;
			this.replacePrefab = replacePrefab;
		}
	}

	[SerializeField]
	private GameObject[] gameObjectsToDisable;

	[SerializeField]
	private GameObjectSwapData[] gameObjectSwaps;

	[SerializeField]
	private MaterialSwapData[] materialSwaps;

	private List<GameObject> nonExplodedModelGOs;

	private List<GameObject> exploadedModelGOs;

	[NonSerialized]
	public bool usingExplodedModel;

	private bool exploadedPrefabsSpawned;

	private void Awake()
	{
		bool num = gameObjectsToDisable != null && gameObjectsToDisable.Length != 0;
		bool flag = gameObjectSwaps != null && gameObjectSwaps.Length != 0;
		bool flag2 = materialSwaps != null && materialSwaps.Length != 0;
		if (!num && !flag && !flag2)
		{
			Debug.LogError("ExplosionModelHandler has no references set. Destroying self.", TrainCar.Resolve(base.gameObject));
			UnityEngine.Object.Destroy(this);
			return;
		}
		nonExplodedModelGOs = new List<GameObject>();
		nonExplodedModelGOs.AddRange(gameObjectsToDisable);
		GameObjectSwapData[] array = gameObjectSwaps;
		foreach (GameObjectSwapData gameObjectSwapData in array)
		{
			nonExplodedModelGOs.Add(gameObjectSwapData.gameObjectToReplace);
		}
	}

	public void HandleExplosionModelChange()
	{
		if (usingExplodedModel)
		{
			Debug.LogError("Unexpected state: usingExplodedModel is true when trying to set exploded model!");
			return;
		}
		if (!exploadedPrefabsSpawned)
		{
			GameObject[] array = gameObjectsToDisable;
			foreach (GameObject gameObject in array)
			{
				if (gameObject == null)
				{
					Debug.LogError("Entry in gameObjectsToDisable is null! Skipping");
				}
				else
				{
					gameObject.SetActive(value: false);
				}
			}
			exploadedModelGOs = new List<GameObject>();
			for (int num = gameObjectSwaps.Length - 1; num >= 0; num--)
			{
				GameObject gameObjectToReplace = gameObjectSwaps[num].gameObjectToReplace;
				if (gameObjectToReplace == null)
				{
					Debug.LogError(string.Format("{0}th entry in {1} ({2}) is null! Skipping", num, "gameObjectSwaps", "goToReplace"));
				}
				else
				{
					Transform obj = gameObjectToReplace.transform;
					Vector3 position = obj.position;
					Quaternion rotation = obj.rotation;
					Transform parent = obj.parent;
					gameObjectToReplace.SetActive(value: false);
					GameObject replacePrefab = gameObjectSwaps[num].replacePrefab;
					if (replacePrefab == null)
					{
						Debug.LogError(string.Format("{0}th entry in {1} ({2}) is null! Skipping", num, "gameObjectSwaps", "replacePrefab"));
					}
					else
					{
						GameObject gameObject2 = UnityEngine.Object.Instantiate(replacePrefab, parent, worldPositionStays: false);
						gameObject2.transform.position = position;
						gameObject2.transform.rotation = rotation;
						exploadedModelGOs.Add(gameObject2);
					}
				}
			}
			exploadedPrefabsSpawned = true;
		}
		else
		{
			foreach (GameObject nonExplodedModelGO in nonExplodedModelGOs)
			{
				nonExplodedModelGO.SetActive(value: false);
			}
			foreach (GameObject exploadedModelGO in exploadedModelGOs)
			{
				exploadedModelGO.SetActive(value: true);
			}
		}
		MaterialSwapData[] array2 = materialSwaps;
		foreach (MaterialSwapData materialSwapData in array2)
		{
			if (materialSwapData.affectedRenderers == null)
			{
				materialSwapData.affectedRenderers = new List<(Renderer, Material)>();
				GameObject[] array = materialSwapData.affectedGameObjects;
				for (int j = 0; j < array.Length; j++)
				{
					Renderer[] componentsInChildren = array[j].GetComponentsInChildren<Renderer>();
					foreach (Renderer renderer in componentsInChildren)
					{
						materialSwapData.affectedRenderers.Add((renderer, renderer.sharedMaterial));
						renderer.sharedMaterial = materialSwapData.swapMaterial;
					}
				}
				continue;
			}
			foreach (var affectedRenderer in materialSwapData.affectedRenderers)
			{
				affectedRenderer.renderer.sharedMaterial = materialSwapData.swapMaterial;
			}
		}
		usingExplodedModel = true;
	}

	public void RevertToUnexplodedModel()
	{
		if (!usingExplodedModel)
		{
			Debug.LogError("Unexpected state: usingExplodedModel is false when trying to revert to normal model!");
			return;
		}
		foreach (GameObject exploadedModelGO in exploadedModelGOs)
		{
			exploadedModelGO.SetActive(value: false);
		}
		foreach (GameObject nonExplodedModelGO in nonExplodedModelGOs)
		{
			nonExplodedModelGO.SetActive(value: true);
		}
		MaterialSwapData[] array = materialSwaps;
		for (int i = 0; i < array.Length; i++)
		{
			foreach (var affectedRenderer in array[i].affectedRenderers)
			{
				affectedRenderer.renderer.sharedMaterial = affectedRenderer.originalMat;
			}
		}
		usingExplodedModel = false;
	}
}
