using System.Collections;
using DG.Tweening;
using GPUInstancerPro.PrefabModule;
using Mirror;
using UnityEngine;

public class OreCollectable : BreakableObject
{
	public Vector2 healthRange;

	public int oreAmount = 6;

	public CollectableItemData collectableItemData;

	public OreType oreType;

	public GameObject hitParticle;

	public Transform hitParticlePosition;

	private float oreRewardPerDamage;

	private float totalHitDamage;

	public GameObject destroyingParticle;

	private GPUIPrefab gpuiPrefab;

	private void Start()
	{
		Register();
		gpuiPrefab = GetComponent<GPUIPrefab>();
		if (!isPreloaded)
		{
			objectServerData.health = Random.Range(healthRange.x, healthRange.y);
		}
		else
		{
			if (objectServerData.health <= 0f)
			{
				Random.InitState(TrainGameManager.Instance.seed + objectServerData.cellID + objectServerData.objectID);
				objectServerData.health = Random.Range(healthRange.x, healthRange.y);
			}
			StartCoroutine(DelayedCheckNetworkStatus());
		}
		oreAmount = Random.Range(oreAmount - 2, oreAmount + 2);
		if (oreAmount <= 0)
		{
			oreAmount = 1;
		}
		oreRewardPerDamage = objectServerData.health / (float)oreAmount;
	}

	private IEnumerator DelayedCheckNetworkStatus()
	{
		CheckNetworkStatus();
		yield return new WaitForSeconds(1f);
		CheckNetworkStatus();
	}

	private void CheckNetworkStatus()
	{
		if (!(NetworkSceneObjectSpawner.Instance != null) || NetworkSceneObjectSpawner.Instance.changedObjectServerDatas == null)
		{
			return;
		}
		foreach (ObjectServerData changedObjectServerData in NetworkSceneObjectSpawner.Instance.changedObjectServerDatas)
		{
			if (changedObjectServerData.cellID != objectServerData.cellID || changedObjectServerData.objectID != objectServerData.objectID)
			{
				continue;
			}
			if (changedObjectServerData.isDestroyed || changedObjectServerData.health <= 0f)
			{
				Debug.Log($"Ore already destroyed: cellID={changedObjectServerData.cellID}, objectID={changedObjectServerData.objectID}");
				if (gpuiPrefab != null)
				{
					GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
				}
				Object.Destroy(base.gameObject);
			}
			else
			{
				objectServerData.health = changedObjectServerData.health;
			}
			break;
		}
	}

	public void InitializeForPreload(float health)
	{
		objectServerData.health = health;
		oreAmount = Random.Range(oreAmount - 2, oreAmount + 2);
		if (oreAmount <= 0)
		{
			oreAmount = 1;
		}
		oreRewardPerDamage = objectServerData.health / (float)oreAmount;
	}

	public void UpdateHealthFromServer(float newHealth)
	{
		objectServerData.health = newHealth;
		Debug.Log($"Ore health updated from server: {objectServerData.cellID}-{objectServerData.objectID} = {newHealth}");
	}

	public void GetDamage(PlayerInventory player, float damage, Vector3 hitPoint)
	{
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			Debug.LogError("NetworkSceneObjectSpawner.Instance is null!");
			return;
		}
		DOVirtual.DelayedCall(0.1f, delegate
		{
			NetworkSoundPlayer.Instance.PlaySound(GameAudios.PickaxeOreHit, base.transform.position);
		});
		DOVirtual.DelayedCall(0.25f, delegate
		{
			if (NetworkSceneObjectSpawner.Instance.changedObjectServerDatas != null)
			{
				foreach (ObjectServerData changedObjectServerData in NetworkSceneObjectSpawner.Instance.changedObjectServerDatas)
				{
					if (changedObjectServerData.cellID == objectServerData.cellID && changedObjectServerData.objectID == objectServerData.objectID)
					{
						objectServerData.health = changedObjectServerData.health;
						objectServerData.isDestroyed = changedObjectServerData.isDestroyed;
						if (!changedObjectServerData.isDestroyed && !(changedObjectServerData.health <= 0f))
						{
							break;
						}
						Debug.Log("Ore already destroyed in network, removing...");
						Object.Destroy(base.gameObject);
						return;
					}
				}
			}
			NetworkSceneObjectSpawner.Instance.SpawnOreHitParticle(hitPoint);
			totalHitDamage += damage;
			objectServerData.health -= damage;
			Debug.Log($"Ore {objectServerData.cellID}-{objectServerData.objectID} damaged: health={objectServerData.health}");
			NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
			NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
			if (totalHitDamage >= oreRewardPerDamage)
			{
				int num = (int)(totalHitDamage / oreRewardPerDamage);
				totalHitDamage %= oreRewardPerDamage;
				int availableSpaceForItem = player.GetAvailableSpaceForItem(collectableItemData);
				int num2 = Mathf.Min(num, availableSpaceForItem);
				int num3 = num - num2;
				if (num2 > 0)
				{
					Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + num2 + " " + collectableItemData.GetLocalizedDisplayName(), collectableItemData);
					player.AddItemInventory(collectableItemData, num2);
				}
				if (num3 > 0)
				{
					DropOverflow(player, collectableItemData, num3);
					if (Singleton<UserMessagePanel>.Instance != null)
					{
						Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
					}
				}
				TaskEventManager.OnCollectOreTaskCompleted.Invoke(collectableItemData, num);
			}
			if (objectServerData.health <= 0f)
			{
				objectServerData.isDestroyed = true;
				NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
				if (player.GetAvailableSpaceForItem(collectableItemData) > 0)
				{
					Singleton<UserMessagePanel>.Instance.SendMessageToPanel("+" + 1 + " " + collectableItemData.GetLocalizedDisplayName(), collectableItemData);
					player.AddItemInventory(collectableItemData, 1);
				}
				else
				{
					DropOverflow(player, collectableItemData, 1);
					if (Singleton<UserMessagePanel>.Instance != null)
					{
						Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
					}
				}
				TaskEventManager.OnCollectOreTaskCompleted.Invoke(collectableItemData, 1);
				if (gpuiPrefab != null)
				{
					GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
				}
				SpawnDestroyingParticle();
				Object.Destroy(base.gameObject);
			}
		});
	}

	private void DropOverflow(PlayerInventory player, CollectableItemData item, int amount)
	{
		Transform transform = player.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (item.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(item.itemName, amount, spawnPoint, spawnForward, item.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(item.itemName, amount, spawnPoint, spawnForward);
		}
	}

	private void SpawnDestroyingParticle()
	{
		Object.Instantiate(destroyingParticle).transform.position = hitParticlePosition.position;
	}
}
