using DV.Utils;
using UnityEngine;

namespace DV.Optimizers
{
	public class TerrainAndStreamersLoadedGameObjectsDisabler : MonoBehaviour
	{
		public enum StreamersCheckType
		{
			REGION = 0,
			CELL = 1
		}

		public StreamersCheckType checkType;

		public Transform referencePointToCheck;

		public GameObject[] gameObjectsToDisable;

		private bool gameObjectsDisabled;

		public void Awake()
		{
			if (referencePointToCheck == null)
			{
				referencePointToCheck = base.gameObject.transform;
			}
			if (gameObjectsToDisable == null || gameObjectsToDisable.Length == 0)
			{
				Debug.LogError("Unexpected state: gameObjectsToDisable is null or empty! " + base.gameObject.GetPath() + ". Deleting self", base.gameObject);
				Object.Destroy(this);
			}
			else if (SingletonBehaviour<WorldStreamingInit>.Instance == null)
			{
				Debug.LogError("Unexpected state: WorldStreamingInit is null, can't function. Deleting self!");
				Object.Destroy(this);
			}
			else if (!WorldStreamingInit.IsLoaded)
			{
				WorldStreamingInit.LoadingFinished += OnLoadingFinished;
			}
			else
			{
				SingletonBehaviour<WorldStreamingInit>.Instance.TerrainsOrScenesLoadStateChanged += OnStateChanged;
				OnStateChanged();
			}
		}

		private void OnLoadingFinished()
		{
			WorldStreamingInit.LoadingFinished -= OnLoadingFinished;
			SingletonBehaviour<WorldStreamingInit>.Instance.TerrainsOrScenesLoadStateChanged += OnStateChanged;
			OnStateChanged();
		}

		private void OnDestroy()
		{
			WorldStreamingInit.LoadingFinished -= OnLoadingFinished;
			if ((bool)SingletonBehaviour<WorldStreamingInit>.Instance)
			{
				SingletonBehaviour<WorldStreamingInit>.Instance.TerrainsOrScenesLoadStateChanged -= OnStateChanged;
			}
		}

		private void OnStateChanged()
		{
			bool flag = ((checkType == StreamersCheckType.REGION) ? (!SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainRegionLoaded(referencePointToCheck.position)) : (!SingletonBehaviour<WorldStreamingInit>.Instance.IsSceneAndTerrainCellLoaded(referencePointToCheck.position)));
			if (flag != gameObjectsDisabled)
			{
				GameObject[] array = gameObjectsToDisable;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(!flag);
				}
				gameObjectsDisabled = flag;
			}
		}
	}
}
