using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class BuildObjectSpawner : NetworkBehaviour
{
	[Header("References")]
	public TrainBuildManager trainBuildManager;

	private PlayerInventory playerInventory;

	[Header("Legacy References - Deprecated")]
	public List<GameObject> objects = new List<GameObject>();

	public GameObject objectPrefab;

	public Transform objectParent;

	private void Start()
	{
		playerInventory = GetComponent<PlayerInventory>();
	}

	private TrainBuildManager GetTrainBuildManager()
	{
		if (trainBuildManager == null)
		{
			trainBuildManager = TrainBuildManager.Instance;
		}
		if (trainBuildManager == null)
		{
			trainBuildManager = Object.FindObjectOfType<TrainBuildManager>();
		}
		return trainBuildManager;
	}

	[Command(requiresAuthority = false)]
	public void SpawnObjectOnServer(Vector3 localPos, Vector3 localEuler, string itemID, int targetWagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPos);
		writer.WriteVector3(localEuler);
		writer.WriteString(itemID);
		writer.WriteInt(targetWagonID);
		SendCommandInternal("System.Void BuildObjectSpawner::SpawnObjectOnServer(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32)", -1561127923, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void SpawnObjectOnDoorServer(Vector3 leafLocalPos, Vector3 leafLocalEuler, string itemID, int targetWagonID, string parentObjectID, int parentLeafIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(leafLocalPos);
		writer.WriteVector3(leafLocalEuler);
		writer.WriteString(itemID);
		writer.WriteInt(targetWagonID);
		writer.WriteString(parentObjectID);
		writer.WriteInt(parentLeafIndex);
		SendCommandInternal("System.Void BuildObjectSpawner::SpawnObjectOnDoorServer(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32,System.String,System.Int32)", 1803079648, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void DestroyObjectOnServer(Vector3 localPosition, string itemName, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(localPosition);
		writer.WriteString(itemName);
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void BuildObjectSpawner::DestroyObjectOnServer(UnityEngine.Vector3,System.String,System.Int32)", 107132415, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void DestroyObjectByIdOnServer(string uniqueID, Vector3 localPosition, string itemName, int wagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(uniqueID);
		writer.WriteVector3(localPosition);
		writer.WriteString(itemName);
		writer.WriteInt(wagonID);
		SendCommandInternal("System.Void BuildObjectSpawner::DestroyObjectByIdOnServer(System.String,UnityEngine.Vector3,System.String,System.Int32)", -1130164363, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void MoveObjectOnServer(Vector3 oldLocalPosition, string itemName, int oldWagonID, Vector3 newWorldPosition, Vector3 newWorldEuler, int newWagonID)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVector3(oldLocalPosition);
		writer.WriteString(itemName);
		writer.WriteInt(oldWagonID);
		writer.WriteVector3(newWorldPosition);
		writer.WriteVector3(newWorldEuler);
		writer.WriteInt(newWagonID);
		SendCommandInternal("System.Void BuildObjectSpawner::MoveObjectOnServer(UnityEngine.Vector3,System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", 48118397, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	public void SpawnObject(Vector3 worldPos, Quaternion worldRot, string itemID, int targetWagonID)
	{
		ConvertWorldToLocal(worldPos, worldRot.eulerAngles, targetWagonID, out var localPos, out var localEuler);
		Debug.Log($"[ramp] BuildObjectSpawner.SpawnObject | itemID: {itemID} | worldRot: {worldRot.eulerAngles} | localEuler: {localEuler} | wagonID: {targetWagonID}");
		SpawnObjectOnServer(localPos, localEuler, itemID, targetWagonID);
	}

	public void DestroyObject(GameObject targetObject)
	{
		PropBase component = targetObject.GetComponent<PropBase>();
		if (component != null && component.data != null)
		{
			Vector3 localPosition = targetObject.transform.localPosition;
			int assignedWagonID = component.assignedWagonID;
			DestroyObjectOnServer(localPosition, component.data.itemName, assignedWagonID);
		}
		else
		{
			Debug.LogWarning("Obje üzerinde PropBase component'i veya data bulunamadı!");
		}
	}

	private int GetNearestWagonID(Vector3 worldPosition)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager?.trainController == null)
		{
			return 0;
		}
		WagonController wagonController = null;
		float num = float.MaxValue;
		foreach (WagonController wagonController2 in trainBuildManager.trainController.wagonControllers)
		{
			if (!(wagonController2 == null))
			{
				float num2 = Vector3.Distance(worldPosition, wagonController2.transform.position);
				if (num2 < num)
				{
					num = num2;
					wagonController = wagonController2;
				}
			}
		}
		return wagonController?.wagonID ?? 0;
	}

	private void ConvertWorldToLocal(Vector3 worldPos, Vector3 worldEuler, int targetWagonID, out Vector3 localPos, out Vector3 localEuler)
	{
		localPos = worldPos;
		localEuler = worldEuler;
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager?.trainController == null)
		{
			Debug.LogWarning("TrainController referansı bulunamadı, world pozisyon kullanılıyor!");
			return;
		}
		WagonController wagonByID = trainBuildManager.trainController.GetWagonByID(targetWagonID);
		if (wagonByID == null)
		{
			Debug.LogWarning($"Wagon ID {targetWagonID} bulunamadı! World pozisyon kullanılıyor.");
			return;
		}
		localPos = wagonByID.transform.InverseTransformPoint(worldPos);
		Quaternion quaternion = Quaternion.Euler(worldEuler);
		localEuler = (Quaternion.Inverse(wagonByID.transform.rotation) * quaternion).eulerAngles;
	}

	public Vector3 ConvertLocalToWorld(Vector3 localPos, int wagonID)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager?.trainController == null)
		{
			return localPos;
		}
		WagonController wagonByID = trainBuildManager.trainController.GetWagonByID(wagonID);
		if (wagonByID == null)
		{
			return localPos;
		}
		return wagonByID.transform.TransformPoint(localPos);
	}

	public Vector3 GetSuggestedSpawnPosition(int wagonID, PlaceableType type)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager?.trainController == null)
		{
			return Vector3.zero;
		}
		WagonController wagonByID = trainBuildManager.trainController.GetWagonByID(wagonID);
		if (wagonByID == null)
		{
			return Vector3.zero;
		}
		switch (type)
		{
		case PlaceableType.Prop:
			if (!(wagonByID.propParent != null))
			{
				return Vector3.zero;
			}
			return wagonByID.propParent.localPosition;
		case PlaceableType.Build:
			if (!(wagonByID.buildParent != null))
			{
				return Vector3.zero;
			}
			return wagonByID.buildParent.localPosition;
		default:
			return Vector3.zero;
		}
	}

	[ContextMenu("List Nearby Wagons")]
	public void ListNearbyWagons()
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager?.trainController == null)
		{
			Debug.Log("TrainController bulunamadı!");
			return;
		}
		Vector3 position = base.transform.position;
		foreach (WagonController wagonController in trainBuildManager.trainController.wagonControllers)
		{
			if (!(wagonController == null))
			{
				float num = Vector3.Distance(position, wagonController.transform.position);
				Debug.Log($"Wagon ID {wagonController.wagonID}: Mesafe {num:F2}m - Pozisyon {wagonController.transform.position}");
			}
		}
		GetNearestWagonID(position);
	}

	public void SpawnObjectOnServer(Vector3 pos, Quaternion rot, string itemID, int targetWagonID)
	{
		SpawnObject(pos, rot, itemID, targetWagonID);
	}

	public void DestroyObjectOnServer(Vector3 position, string itemName)
	{
		int nearestWagonID = GetNearestWagonID(position);
		DestroyObjectOnServer(position, itemName, nearestWagonID);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SpawnObjectOnServer__Vector3__Vector3__String__Int32(Vector3 localPos, Vector3 localEuler, string itemID, int targetWagonID)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager == null)
		{
			Debug.LogError("TrainBuildManager referansı bulunamadı!");
		}
		else
		{
			trainBuildManager.SpawnBuildObjectOnServer(localPos, localEuler, itemID, targetWagonID);
		}
	}

	protected static void InvokeUserCode_SpawnObjectOnServer__Vector3__Vector3__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpawnObjectOnServer called on client.");
		}
		else
		{
			((BuildObjectSpawner)obj).UserCode_SpawnObjectOnServer__Vector3__Vector3__String__Int32(reader.ReadVector3(), reader.ReadVector3(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_SpawnObjectOnDoorServer__Vector3__Vector3__String__Int32__String__Int32(Vector3 leafLocalPos, Vector3 leafLocalEuler, string itemID, int targetWagonID, string parentObjectID, int parentLeafIndex)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager == null)
		{
			Debug.LogError("TrainBuildManager referansı bulunamadı!");
		}
		else
		{
			trainBuildManager.SpawnBuildObjectOnServer(leafLocalPos, leafLocalEuler, itemID, targetWagonID, parentObjectID, parentLeafIndex);
		}
	}

	protected static void InvokeUserCode_SpawnObjectOnDoorServer__Vector3__Vector3__String__Int32__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SpawnObjectOnDoorServer called on client.");
		}
		else
		{
			((BuildObjectSpawner)obj).UserCode_SpawnObjectOnDoorServer__Vector3__Vector3__String__Int32__String__Int32(reader.ReadVector3(), reader.ReadVector3(), reader.ReadString(), reader.ReadInt(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_DestroyObjectOnServer__Vector3__String__Int32(Vector3 localPosition, string itemName, int wagonID)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager == null)
		{
			Debug.LogError("TrainBuildManager referansı bulunamadı!");
			return;
		}
		trainBuildManager.DestroyBuildObjectOnServer(localPosition, itemName, wagonID);
		Debug.Log($"BuildObjectSpawner: Obje {itemName} yok etme komutu TrainBuildManager'a iletildi (Wagon ID: {wagonID})");
	}

	protected static void InvokeUserCode_DestroyObjectOnServer__Vector3__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DestroyObjectOnServer called on client.");
		}
		else
		{
			((BuildObjectSpawner)obj).UserCode_DestroyObjectOnServer__Vector3__String__Int32(reader.ReadVector3(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_DestroyObjectByIdOnServer__String__Vector3__String__Int32(string uniqueID, Vector3 localPosition, string itemName, int wagonID)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager == null)
		{
			Debug.LogError("TrainBuildManager referansı bulunamadı!");
		}
		else
		{
			trainBuildManager.DestroyBuildObjectOnServer(localPosition, itemName, wagonID, uniqueID);
		}
	}

	protected static void InvokeUserCode_DestroyObjectByIdOnServer__String__Vector3__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command DestroyObjectByIdOnServer called on client.");
		}
		else
		{
			((BuildObjectSpawner)obj).UserCode_DestroyObjectByIdOnServer__String__Vector3__String__Int32(reader.ReadString(), reader.ReadVector3(), reader.ReadString(), reader.ReadInt());
		}
	}

	protected void UserCode_MoveObjectOnServer__Vector3__String__Int32__Vector3__Vector3__Int32(Vector3 oldLocalPosition, string itemName, int oldWagonID, Vector3 newWorldPosition, Vector3 newWorldEuler, int newWagonID)
	{
		TrainBuildManager trainBuildManager = GetTrainBuildManager();
		if (trainBuildManager == null)
		{
			Debug.LogError("TrainBuildManager referansı bulunamadı!");
			return;
		}
		ConvertWorldToLocal(newWorldPosition, newWorldEuler, newWagonID, out var localPos, out var localEuler);
		trainBuildManager.MoveBuildObjectOnServer(oldLocalPosition, itemName, oldWagonID, localPos, localEuler, newWagonID);
	}

	protected static void InvokeUserCode_MoveObjectOnServer__Vector3__String__Int32__Vector3__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command MoveObjectOnServer called on client.");
		}
		else
		{
			((BuildObjectSpawner)obj).UserCode_MoveObjectOnServer__Vector3__String__Int32__Vector3__Vector3__Int32(reader.ReadVector3(), reader.ReadString(), reader.ReadInt(), reader.ReadVector3(), reader.ReadVector3(), reader.ReadInt());
		}
	}

	static BuildObjectSpawner()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BuildObjectSpawner), "System.Void BuildObjectSpawner::SpawnObjectOnServer(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32)", InvokeUserCode_SpawnObjectOnServer__Vector3__Vector3__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildObjectSpawner), "System.Void BuildObjectSpawner::SpawnObjectOnDoorServer(UnityEngine.Vector3,UnityEngine.Vector3,System.String,System.Int32,System.String,System.Int32)", InvokeUserCode_SpawnObjectOnDoorServer__Vector3__Vector3__String__Int32__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildObjectSpawner), "System.Void BuildObjectSpawner::DestroyObjectOnServer(UnityEngine.Vector3,System.String,System.Int32)", InvokeUserCode_DestroyObjectOnServer__Vector3__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildObjectSpawner), "System.Void BuildObjectSpawner::DestroyObjectByIdOnServer(System.String,UnityEngine.Vector3,System.String,System.Int32)", InvokeUserCode_DestroyObjectByIdOnServer__String__Vector3__String__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(BuildObjectSpawner), "System.Void BuildObjectSpawner::MoveObjectOnServer(UnityEngine.Vector3,System.String,System.Int32,UnityEngine.Vector3,UnityEngine.Vector3,System.Int32)", InvokeUserCode_MoveObjectOnServer__Vector3__String__Int32__Vector3__Vector3__Int32, requiresAuthority: false);
	}
}
