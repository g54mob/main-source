using System.Collections;
using System.Collections.Generic;
using DV.CabControls;
using DV.Interaction;
using DV.InventorySystem;
using DV.JObjectExtstensions;
using DV.Logic.Job;
using DV.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(ItemSaveData))]
public class JobBooklet : MonoBehaviour, IInventoryItemLocalizer
{
	private const string JOB_ID_SAVE_KEY = "jobId";

	private InventoryItemSpec itemSpecs;

	private RespawnOnDrop respawner;

	private float initialRespawnDistance;

	private ItemSaveData itemSaveData;

	public static List<JobBooklet> allExistingJobBooklets = new List<JobBooklet>();

	public Job job { get; private set; }

	public string jobIdLoadedData { get; private set; }

	private void Awake()
	{
		itemSpecs = GetComponent<InventoryItemSpec>();
		if (itemSpecs == null)
		{
			Debug.LogError("Inventory specs not found. This should not happen", this);
			return;
		}
		itemSaveData = GetComponent<ItemSaveData>();
		itemSaveData.ItemSaveDataLoaded += OnSaveDataLoaded;
		itemSaveData.ItemSaveDataRequested += OnSaveDataRequested;
		base.gameObject.AddComponent<JobBookletUse>();
		allExistingJobBooklets.Add(this);
		SingletonBehaviour<CoroutineManager>.Instance.Run(DelayedSetEssential());
	}

	private void OnDestroy()
	{
		allExistingJobBooklets.Remove(this);
		if (HasJobAssigned())
		{
			SetupListeners(on: false);
		}
	}

	public void AssignJob(Job jobToAssign)
	{
		if (jobToAssign == null)
		{
			Debug.LogError("jobToAssign is null!");
		}
		else if (HasJobAssigned())
		{
			Debug.LogError("Trying to assign a job [" + jobToAssign.ID + "] to JobBooklet that already has assigned job [" + job.ID + "]!", this);
		}
		else
		{
			job = jobToAssign;
			base.gameObject.name = "JobBooklet[" + job.ID + "]";
			SetupListeners(on: true);
		}
	}

	public bool HasJobAssigned()
	{
		return job != null;
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			job.JobCompleted += OnJobCompleted;
			job.JobAbandoned += OnJobAbandoned;
			return;
		}
		job.JobCompleted -= OnJobCompleted;
		job.JobAbandoned -= OnJobAbandoned;
		itemSaveData.ItemSaveDataLoaded -= OnSaveDataLoaded;
		itemSaveData.ItemSaveDataRequested -= OnSaveDataRequested;
	}

	private void OnJobCompleted(Job obj)
	{
		SetToBeEssentialItem(set: false);
	}

	private void OnJobAbandoned(Job obj)
	{
		DestroyJobBooklet();
	}

	public void DestroyJobBooklet()
	{
		ItemBase component = GetComponent<ItemBase>();
		if (component == null)
		{
			Debug.LogError("Couldn't find ItemBase on JobBooklet!");
			return;
		}
		int num = SingletonBehaviour<Inventory>.Instance.IndexOf(component.gameObject);
		if (num < 0)
		{
			SingletonBehaviour<StorageController>.Instance.RemoveItemFromStorageItemList(component);
		}
		else
		{
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(num);
		}
		if (component.IsGrabbed())
		{
			StartCoroutine(UngrabAndDestroyCoro(component));
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private IEnumerator DelayedSetEssential()
	{
		yield return null;
		SetToBeEssentialItem(set: true);
	}

	public void SetToBeEssentialItem(bool set)
	{
		if (respawner == null)
		{
			respawner = GetComponent<RespawnOnDrop>();
		}
		if (set)
		{
			initialRespawnDistance = 1000f;
			respawner.SetMaxDistance(200f);
			itemSpecs.BelongsToPlayer = true;
			respawner.ignoreDistanceFromSpawnPosition = true;
		}
		else
		{
			respawner.SetMaxDistance(initialRespawnDistance);
			respawner.respawnOnDropThroughFloor = false;
			respawner.ignoreDistanceFromSpawnPosition = true;
			itemSpecs.BelongsToPlayer = false;
		}
	}

	private IEnumerator UngrabAndDestroyCoro(ItemBase item)
	{
		item.ForceEndInteraction();
		yield return null;
		Object.Destroy(base.gameObject);
	}

	public JObject OnSaveDataRequested(JObject data)
	{
		if (!HasJobAssigned())
		{
			data.Remove("jobId");
		}
		else
		{
			data.SetString("jobId", job.ID);
		}
		return data;
	}

	public void OnSaveDataLoaded(JObject data)
	{
		if (data == null)
		{
			Debug.LogError("OnSaveDataLoaded got null data");
			return;
		}
		string text = data.GetString("jobId");
		if (text != null)
		{
			jobIdLoadedData = text;
		}
		else
		{
			Debug.LogError("jobId data missing!");
		}
	}

	public string GetNameParam()
	{
		if (!HasJobAssigned())
		{
			return "[NO JOB]";
		}
		return job.ID;
	}

	public string GetCustomDescription()
	{
		return null;
	}
}
