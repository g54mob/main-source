using System;
using System.Collections;
using DG.Tweening;
using GPUInstancerPro.PrefabModule;
using Mirror;
using UnityEngine;

public class TreeCollectable : BreakableObject
{
	[SerializeField]
	private LayerMask groundLayers;

	public Vector2 healthRange;

	public Vector2 oreAmountRange;

	private int oreAmount;

	public CollectableItemData collectableItemData;

	public GameObject hitParticle;

	public Transform hitParticlePosition;

	private float plankRewardPerDamage;

	private float totalHitDamage;

	private Rigidbody rb;

	public GameObject destroyingParticle;

	private GPUIPrefab gpuiPrefab;

	private NetworkSoundData networkSoundData;

	private void Start()
	{
		Register();
		rb = GetComponent<Rigidbody>();
		gpuiPrefab = GetComponent<GPUIPrefab>();
		if (!isPreloaded)
		{
			objectServerData.health = UnityEngine.Random.Range(healthRange.x, healthRange.y);
		}
		else
		{
			if (objectServerData.health <= 0f)
			{
				UnityEngine.Random.InitState(TrainGameManager.Instance.seed + objectServerData.cellID + objectServerData.objectID);
				objectServerData.health = UnityEngine.Random.Range(healthRange.x, healthRange.y);
			}
			StartCoroutine(DelayedCheckNetworkStatus());
		}
		oreAmount = (int)UnityEngine.Random.Range(oreAmountRange.x, oreAmountRange.y);
		if (oreAmount <= 0)
		{
			oreAmount = 1;
		}
		plankRewardPerDamage = objectServerData.health / (float)oreAmount;
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
				Debug.Log($"Tree already destroyed: cellID={changedObjectServerData.cellID}, objectID={changedObjectServerData.objectID}");
				if (gpuiPrefab != null)
				{
					GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
				}
				UnityEngine.Object.Destroy(base.gameObject);
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
		oreAmount = (int)UnityEngine.Random.Range(oreAmountRange.x, oreAmountRange.y);
		if (oreAmount <= 0)
		{
			oreAmount = 1;
		}
		plankRewardPerDamage = objectServerData.health / (float)oreAmount;
	}

	public void GetDamage(PlayerInventory player, float damage, Vector3 hitPoint)
	{
		if (NetworkSceneObjectSpawner.Instance == null)
		{
			Debug.LogError("NetworkSceneObjectSpawner.Instance is null!");
			return;
		}
		NetworkSoundPlayer.Instance.PlaySound(GameAudios.AxeTreeHit, base.transform.position);
		DOVirtual.DelayedCall(0.2f, delegate
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
						Debug.Log("Object already destroyed in network, removing...");
						UnityEngine.Object.Destroy(base.gameObject);
						return;
					}
				}
			}
			NetworkSceneObjectSpawner.Instance.SpawnHitParticle(new Vector3(hitParticlePosition.position.x, hitPoint.y, hitParticlePosition.position.z));
			totalHitDamage += damage;
			objectServerData.health -= damage;
			Debug.Log($"Object {objectServerData.cellID}-{objectServerData.objectID} damaged: health={objectServerData.health}");
			NetworkSceneObjectSpawner.Instance.NetworkobjectOwner = player.GetComponent<NetworkIdentity>();
			NetworkSceneObjectSpawner.Instance.AddOrUpdateObject(objectServerData);
			if (totalHitDamage >= plankRewardPerDamage)
			{
				int num = (int)(totalHitDamage / plankRewardPerDamage);
				totalHitDamage %= plankRewardPerDamage;
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
				TaskEventManager.OnCollectableEarned.Invoke(collectableItemData, num);
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
				TaskEventManager.OnCollectableEarned.Invoke(collectableItemData, 1);
				if (gpuiPrefab != null)
				{
					GPUIPrefabAPI.RemovePrefabInstance(gpuiPrefab);
				}
				if (rb == null)
				{
					rb = base.gameObject.AddComponent<Rigidbody>();
				}
				rb.isKinematic = false;
				GetComponent<Collider>().enabled = false;
				Vector3 rhs = player.transform.position + player.transform.forward * 4f - base.transform.position;
				rb.angularVelocity = Vector3.Cross(base.transform.position, rhs) * rhs.magnitude * (MathF.PI / 180f) * 0.05f;
				NetworkSceneObjectSpawner.Instance.SpawnDestroyingParticle(hitParticlePosition.position);
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

	public void UpdateHealthFromServer(float newHealth)
	{
		objectServerData.health = newHealth;
		Debug.Log($"Health updated from server: {objectServerData.cellID}-{objectServerData.objectID} = {newHealth}");
	}
}
