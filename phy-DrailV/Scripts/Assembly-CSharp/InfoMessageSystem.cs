using System;
using System.Collections;
using DV;
using DV.Common;
using DV.Platform;
using DV.TerrainSystem;
using DV.UI;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

public class InfoMessageSystem : MonoBehaviour
{
	private const float MESSAGE_DURATION = 1f;

	private const string AUTOSAVE_TEXT = "info/autosave";

	private const string LOADING_AREA_TEXT = "info/loading_area";

	private const string TRAIN_SPAWNING_TEXT = "info/train_spawning";

	private const string LOW_MEMORY_TEXT = "info/low_memory";

	private GameObject autosaveNotification;

	private GameObject loadingNotification;

	private GameObject trainSpawningNotification;

	private GameObject lowMemoryNotification;

	public bool LoadingAlerts { get; private set; }

	private NotificationManager NotificationManager => SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.NotificationManager;

	private IEnumerator Start()
	{
		if ((bool)SingletonBehaviour<WorldStreamingInit>.Instance)
		{
			while (!WorldStreamingInit.IsLoaded)
			{
				yield return WaitFor.Seconds(1f);
			}
		}
		else
		{
			yield return null;
		}
		SaveGameManager.AboutToSave += OnAboutToSave;
		MemoryMonitoring.LowMemoryThresholdReached = (MemoryMonitoring.LowMemoryDelegate)Delegate.Combine(MemoryMonitoring.LowMemoryThresholdReached, new MemoryMonitoring.LowMemoryDelegate(OnLowMemory));
	}

	private void OnDestroy()
	{
		SaveGameManager.AboutToSave -= OnAboutToSave;
		MemoryMonitoring.LowMemoryThresholdReached = (MemoryMonitoring.LowMemoryDelegate)Delegate.Remove(MemoryMonitoring.LowMemoryThresholdReached, new MemoryMonitoring.LowMemoryDelegate(OnLowMemory));
	}

	public void EnableLoadingAreaAndCarSpawningInfo(bool set)
	{
		if (LoadingAlerts == set)
		{
			Debug.LogWarning(string.Format("{0} is already set to {1}", "LoadingAlerts", set));
			return;
		}
		LoadingAlerts = set;
		StationController[] array = UnityEngine.Object.FindObjectsOfType<StationController>();
		GameObject[] array2 = GameObject.FindGameObjectsWithTag(Streamer.STREAMERTAG);
		if (set)
		{
			StationController[] array3 = array;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].GetComponent<StationProceduralJobsController>().JobGenerationAttempt += OnJobGenerationAttempt;
			}
			GameObject[] array4 = array2;
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i].GetComponent<Streamer>().LoadingNewScenes += OnLoadingNewScenes;
			}
			if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
			{
				SingletonBehaviour<TerrainGrid>.Instance.TerrainsAboutToBeMoved += OnTerrainsMoved;
			}
		}
		else
		{
			StationController[] array3 = array;
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i].GetComponent<StationProceduralJobsController>().JobGenerationAttempt -= OnJobGenerationAttempt;
			}
			GameObject[] array4 = array2;
			for (int i = 0; i < array4.Length; i++)
			{
				array4[i].GetComponent<Streamer>().LoadingNewScenes -= OnLoadingNewScenes;
			}
			if ((bool)SingletonBehaviour<TerrainGrid>.Instance)
			{
				SingletonBehaviour<TerrainGrid>.Instance.TerrainsAboutToBeMoved -= OnTerrainsMoved;
			}
		}
	}

	private void OnAboutToSave(SaveType saveType)
	{
		if (saveType == SaveType.Auto)
		{
			if ((bool)autosaveNotification)
			{
				NotificationManager.ClearNotification(autosaveNotification);
			}
			autosaveNotification = NotificationManager.ShowNotification("info/autosave", null, 1f, clearExisting: false, null, localize: true, targetIsUI: false, new NotificationManager.SizeOverrides
			{
				overallScale = 0.4f,
				textScale = 2f
			});
		}
	}

	private void OnJobGenerationAttempt()
	{
		if ((bool)trainSpawningNotification)
		{
			NotificationManager.ClearNotification(trainSpawningNotification);
		}
		trainSpawningNotification = NotificationManager.ShowNotification("info/train_spawning", null, 2f, clearExisting: false);
	}

	private void OnLoadingNewScenes()
	{
		if ((bool)loadingNotification)
		{
			NotificationManager.ClearNotification(loadingNotification);
		}
		loadingNotification = NotificationManager.ShowNotification("info/loading_area", null, 1f, clearExisting: false);
	}

	private void OnTerrainsMoved()
	{
		if ((bool)loadingNotification)
		{
			NotificationManager.ClearNotification(loadingNotification);
		}
		loadingNotification = NotificationManager.ShowNotification("info/loading_area", null, 1f, clearExisting: false);
	}

	private void OnLowMemory(long freeKB)
	{
		if ((bool)lowMemoryNotification)
		{
			NotificationManager.ClearNotification(lowMemoryNotification);
		}
		using (PooledArray<string> pooledArray = ArrayPool<string>.New(1, freeKB.FormatBytes()))
		{
			lowMemoryNotification = NotificationManager.ShowNotification("info/low_memory", pooledArray, 4f, clearExisting: false);
		}
	}
}
