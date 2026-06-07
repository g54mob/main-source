using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using UnityEngine;

public class ShelfItemManager : NetworkBehaviour
{
	public global::OutlineFx.OutlineFx outline;

	public GameObject productObj;

	[SyncVar]
	public int amountOfProducts;

	public List<Transform> products;

	public float halfLength;

	public float zHalfLength;

	public int itemIndex;

	public ShelfManager shelfMan;

	public int NetworkamountOfProducts
	{
		get
		{
			return amountOfProducts;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref amountOfProducts, 1uL, null);
		}
	}

	public void Start_()
	{
		if (!base.isServer)
		{
			Invoke("LocalReloadItems", 0.5f);
			return;
		}
		ServerAddItem(autoSort: false);
		ServerAddItem(autoSort: false);
		ServerAddItem(autoSort: false);
		ServerAddItem(autoSort: false);
		AutoSort();
	}

	public void LocalReloadItems()
	{
		int num = products.Count - amountOfProducts;
		if (num < 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				LocalAddItem(autoSort: false);
			}
		}
		else if (num > 0)
		{
			for (int j = 0; j < Mathf.Abs(num); j++)
			{
				LocalRemoveItem();
			}
		}
		AutoSort();
	}

	[ClientRpc]
	public void ReloadItemsRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShelfItemManager::ReloadItemsRpc()", 1552761007, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void AddItem(bool autoSort)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(autoSort);
		SendCommandInternal("System.Void ShelfItemManager::AddItem(System.Boolean)", 2019630724, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void RemoveItem()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void ShelfItemManager::RemoveItem()", -2132062562, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void AddItemRpc(bool autoSort)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(autoSort);
		SendRPCInternal("System.Void ShelfItemManager::AddItemRpc(System.Boolean)", 1871656535, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RemoveItemRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void ShelfItemManager::RemoveItemRpc()", -1310289773, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void LocalAddItem(bool autoSort)
	{
		Transform item = Object.Instantiate(productObj, base.transform).transform;
		products.Add(item);
		if (autoSort)
		{
			AutoSort();
		}
	}

	public void LocalRemoveItem()
	{
		if (products.Count > 1)
		{
			Object.Destroy(products[products.Count - 1].gameObject);
			products.RemoveAt(products.Count - 1);
			StopCoroutine(SortItems());
			StartCoroutine(SortItems());
		}
	}

	public void ServerAddItem(bool autoSort)
	{
		ReviewsManager.Instance.UpdateStockPenalty(-1);
		NetworkamountOfProducts = amountOfProducts + 1;
		Transform item = Object.Instantiate(productObj, base.transform).transform;
		products.Add(item);
		if (autoSort)
		{
			AutoSort();
		}
	}

	public void ServerRemoveItem()
	{
		if (products.Count > 1)
		{
			ReviewsManager.Instance.UpdateStockPenalty(1);
			NetworkamountOfProducts = amountOfProducts - 1;
			Object.Destroy(products[products.Count - 1].gameObject);
			products.RemoveAt(products.Count - 1);
			StopCoroutine(SortItems());
			StartCoroutine(SortItems());
			Invoke("ReloadItemsRpc", 1f);
		}
	}

	private IEnumerator SortItems()
	{
		float elapsedTime = 0f;
		while (elapsedTime < 2f)
		{
			int count = products.Count;
			int num = count / 4;
			int num2 = count % 4;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int index = i * 4 + j;
					float x = Mathf.Lerp(0f - halfLength, halfLength, (float)j / 3f);
					float num3 = (float)i * (0f - zHalfLength);
					Vector3 b = new Vector3(x, 0f, num3 + zHalfLength);
					products[index].localPosition = Vector3.Lerp(products[index].localPosition, b, Time.deltaTime * 10f);
				}
			}
			float[] residualOffsets = GetResidualOffsets(halfLength, num2);
			float num4 = (float)num * (0f - zHalfLength);
			for (int k = 0; k < num2; k++)
			{
				int index2 = num * 4 + k;
				float x2 = residualOffsets[k];
				Vector3 b2 = new Vector3(x2, 0f, num4 + zHalfLength);
				products[index2].localPosition = Vector3.Lerp(products[index2].localPosition, b2, Time.deltaTime * 10f);
			}
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	public void Hover(Vector3 startPos)
	{
		outline.enabled = true;
		outline._color = Color.green;
		Transform transform = Object.Instantiate(productObj, base.transform).transform;
		transform.position = startPos;
		products.Add(transform);
		StoreManager.Instance.hoverAudio.Play();
		StopCoroutine(SortItems());
		StartCoroutine(SortItems());
	}

	public void Unhover()
	{
		outline.enabled = false;
		Object.Destroy(products[products.Count - 1].gameObject);
		products.RemoveAt(products.Count - 1);
		StopCoroutine(SortItems());
		StartCoroutine(SortItems());
	}

	private void AutoSort()
	{
		int count = products.Count;
		int num = count / 4;
		int num2 = count % 4;
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				int index = i * 4 + j;
				float x = Mathf.Lerp(0f - halfLength, halfLength, (float)j / 3f);
				float num3 = (float)i * (0f - zHalfLength);
				Vector3 localPosition = new Vector3(x, 0f, num3 + zHalfLength);
				products[index].localPosition = localPosition;
			}
		}
		float[] residualOffsets = GetResidualOffsets(halfLength, num2);
		float num4 = (float)num * (0f - zHalfLength);
		for (int k = 0; k < num2; k++)
		{
			int index2 = num * 4 + k;
			float x2 = residualOffsets[k];
			Vector3 localPosition2 = new Vector3(x2, 0f, num4 + zHalfLength);
			products[index2].localPosition = localPosition2;
		}
	}

	private float[] GetResidualOffsets(float halfLength, int residualCount)
	{
		return residualCount switch
		{
			1 => new float[1], 
			2 => new float[2]
			{
				(0f - halfLength) / 1.5f,
				halfLength / 1.5f
			}, 
			3 => new float[3]
			{
				(0f - halfLength) / 2f,
				0f,
				halfLength / 2f
			}, 
			_ => new float[0], 
		};
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ReloadItemsRpc()
	{
		int num = products.Count - amountOfProducts;
		if (num < 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				LocalAddItem(autoSort: false);
			}
		}
		else if (num > 0)
		{
			for (int j = 0; j < Mathf.Abs(num); j++)
			{
				LocalRemoveItem();
			}
		}
		AutoSort();
	}

	protected static void InvokeUserCode_ReloadItemsRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ReloadItemsRpc called on server.");
		}
		else
		{
			((ShelfItemManager)obj).UserCode_ReloadItemsRpc();
		}
	}

	protected void UserCode_AddItem__Boolean(bool autoSort)
	{
		NetworkamountOfProducts = amountOfProducts + 1;
		ReviewsManager.Instance.UpdateStockPenalty(-1);
		Transform item = Object.Instantiate(productObj, base.transform).transform;
		products.Add(item);
		if (autoSort)
		{
			AutoSort();
		}
		Invoke("ReloadItemsRpc", 0.1f);
		Invoke("ReloadItemsRpc", 0.3f);
	}

	protected static void InvokeUserCode_AddItem__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AddItem called on client.");
		}
		else
		{
			((ShelfItemManager)obj).UserCode_AddItem__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RemoveItem()
	{
		if (products.Count > 1)
		{
			ReviewsManager.Instance.UpdateStockPenalty(1);
			NetworkamountOfProducts = amountOfProducts - 1;
			Object.Destroy(products[products.Count - 1].gameObject);
			products.RemoveAt(products.Count - 1);
			StopCoroutine(SortItems());
			StartCoroutine(SortItems());
			Invoke("ReloadItemsRpc", 0.1f);
			Invoke("ReloadItemsRpc", 0.3f);
		}
	}

	protected static void InvokeUserCode_RemoveItem(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RemoveItem called on client.");
		}
		else
		{
			((ShelfItemManager)obj).UserCode_RemoveItem();
		}
	}

	protected void UserCode_AddItemRpc__Boolean(bool autoSort)
	{
		NetworkamountOfProducts = amountOfProducts + 1;
		if (base.isServer)
		{
			ReviewsManager.Instance.UpdateStockPenalty(-1);
		}
		Transform item = Object.Instantiate(productObj, base.transform).transform;
		products.Add(item);
		if (autoSort)
		{
			AutoSort();
		}
		CancelInvoke("LocalReloadItems");
		Invoke("LocalReloadItems", 0.1f);
	}

	protected static void InvokeUserCode_AddItemRpc__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AddItemRpc called on server.");
		}
		else
		{
			((ShelfItemManager)obj).UserCode_AddItemRpc__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RemoveItemRpc()
	{
		if (products.Count > 1)
		{
			NetworkamountOfProducts = amountOfProducts - 1;
			if (base.isServer)
			{
				ReviewsManager.Instance.UpdateStockPenalty(1);
			}
			Object.Destroy(products[products.Count - 1].gameObject);
			products.RemoveAt(products.Count - 1);
			StopCoroutine(SortItems());
			StartCoroutine(SortItems());
			CancelInvoke("LocalReloadItems");
			Invoke("LocalReloadItems", 0.1f);
		}
	}

	protected static void InvokeUserCode_RemoveItemRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RemoveItemRpc called on server.");
		}
		else
		{
			((ShelfItemManager)obj).UserCode_RemoveItemRpc();
		}
	}

	static ShelfItemManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(ShelfItemManager), "System.Void ShelfItemManager::AddItem(System.Boolean)", InvokeUserCode_AddItem__Boolean, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(ShelfItemManager), "System.Void ShelfItemManager::RemoveItem()", InvokeUserCode_RemoveItem, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(ShelfItemManager), "System.Void ShelfItemManager::ReloadItemsRpc()", InvokeUserCode_ReloadItemsRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(ShelfItemManager), "System.Void ShelfItemManager::AddItemRpc(System.Boolean)", InvokeUserCode_AddItemRpc__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(ShelfItemManager), "System.Void ShelfItemManager::RemoveItemRpc()", InvokeUserCode_RemoveItemRpc);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(amountOfProducts);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(amountOfProducts);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref amountOfProducts, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref amountOfProducts, null, reader.ReadVarInt());
		}
	}
}
