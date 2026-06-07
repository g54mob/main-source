using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class TruckManager : NetworkBehaviour
{
	public GameObject[] deliveryItems;

	private int deliveryIndex;

	public Transform boxSpawnPoint;

	public GameObject topGateObj;

	public Animator truckAnim;

	public bool go;

	public Transform insideTruck;

	private Vector3 startVector;

	private float speed;

	public Outline gateOutline;

	private bool initialCheck = true;

	public Interactable garageDoorSwitch;

	private bool doorsHasBeenOpened;

	public int purchaseIndex;

	private void Awake()
	{
		startVector = base.transform.position;
	}

	private void OnEnable()
	{
		doorsHasBeenOpened = false;
		deliveryIndex = 0;
		initialCheck = true;
		speed = 0f;
		go = false;
		base.transform.position = startVector;
	}

	private void FixedUpdate()
	{
		if (go)
		{
			speed = Mathf.Lerp(speed, 13f, Time.deltaTime * 1.5f);
			base.transform.position -= insideTruck.up * speed * Time.deltaTime;
		}
	}

	public void CheckIfDoorOpen()
	{
		if (!topGateObj.activeInHierarchy)
		{
			gateOutline.enabled = false;
			truckAnim.SetTrigger("Continue");
			if (PlayerPrefs.GetInt("DeliveryHint") != 1)
			{
				Invoke("DoHint", 10f);
				PlayerPrefs.SetInt("DeliveryHint", 1);
			}
			garageDoorSwitch.ReInvokeInteractCooldown();
			doorsHasBeenOpened = true;
		}
		else
		{
			if (initialCheck)
			{
				RecheckHint();
				gateOutline.enabled = true;
			}
			initialCheck = false;
		}
	}

	private void RecheckHint()
	{
		if (!doorsHasBeenOpened)
		{
			StoreManager.Instance.AddHint("Delivery has arrived. Open the Loading Bay Gate.");
			StoreManager.Instance.NextHint();
			Invoke("RecheckHint", 20f);
		}
	}

	private void DoHint()
	{
		StoreManager.Instance.AddHint("Use the traps if the store comes under attack.");
		StoreManager.Instance.NextHint();
	}

	public void DropBoxes()
	{
		if (SaveManager.Instance.curDay == 1)
		{
			for (int i = 0; i < deliveryItems.Length; i++)
			{
				Invoke("DropBox", (float)i * 0.2f);
			}
			EventManager.Instance.Invoke("SpawnChasingNathan", 8f);
		}
		else
		{
			purchaseIndex = 0;
			for (int j = 0; j < PurchaseManager.Instance.purchaseQueue.Count; j++)
			{
				Invoke("DropPurchase", (float)j * 0.2f);
			}
		}
		Invoke("Delete", 14f);
		Invoke("Go", 3f);
	}

	private void DropPurchase()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GameObject obj = Object.Instantiate(PurchaseManager.Instance.purchaseQueue[purchaseIndex], boxSpawnPoint.position, Quaternion.identity);
			NetworkServer.Spawn(obj);
			obj.GetComponent<Rigidbody>().velocity = boxSpawnPoint.forward * 10f;
			purchaseIndex++;
			if (purchaseIndex >= PurchaseManager.Instance.purchaseQueue.Count)
			{
				ClearPurchaseQueueRpc();
			}
		}
	}

	[ClientRpc]
	private void ClearPurchaseQueueRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TruckManager::ClearPurchaseQueueRpc()", -907019675, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Go()
	{
		go = true;
	}

	private void Delete()
	{
		if (PurchaseManager.Instance.purchaseQueue.Count > 0)
		{
			base.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void DropBox()
	{
		if (ClientPlayer.Instance.isServer)
		{
			GameObject obj = Object.Instantiate(deliveryItems[deliveryIndex], boxSpawnPoint.position, Quaternion.identity);
			NetworkServer.Spawn(obj);
			obj.GetComponent<Rigidbody>().velocity = boxSpawnPoint.forward * 10f;
			deliveryIndex++;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ClearPurchaseQueueRpc()
	{
		PurchaseManager.Instance.purchaseQueue.Clear();
	}

	protected static void InvokeUserCode_ClearPurchaseQueueRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ClearPurchaseQueueRpc called on server.");
		}
		else
		{
			((TruckManager)obj).UserCode_ClearPurchaseQueueRpc();
		}
	}

	static TruckManager()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(TruckManager), "System.Void TruckManager::ClearPurchaseQueueRpc()", InvokeUserCode_ClearPurchaseQueueRpc);
	}
}
