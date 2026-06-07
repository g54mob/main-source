using System;
using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class VehicleRescueManager : NetworkBehaviour
{
	[Serializable]
	public class ForkliftRescueEntry
	{
		public SCC_Network vehicle;

		public string displayName;

		public Transform rescuePoint;
	}

	[Serializable]
	public class TruckRescueEntry
	{
		public SCC_Network vehicle;

		public string displayName;

		public Transform factoryRescuePoint;
	}

	[Header("Forklift Rescue")]
	[SerializeField]
	private List<ForkliftRescueEntry> forklifts = new List<ForkliftRescueEntry>();

	[Header("Truck Rescue")]
	[SerializeField]
	private List<TruckRescueEntry> trucks = new List<TruckRescueEntry>();

	private DigsiteRescueProvider currentDigsiteProvider;

	public static VehicleRescueManager Instance { get; private set; }

	public IReadOnlyList<ForkliftRescueEntry> Forklifts => forklifts;

	public IReadOnlyList<TruckRescueEntry> Trucks => trucks;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void RegisterDigsiteProvider(DigsiteRescueProvider provider)
	{
		currentDigsiteProvider = provider;
	}

	public void UnregisterDigsiteProvider(DigsiteRescueProvider provider)
	{
		if (currentDigsiteProvider == provider)
		{
			currentDigsiteProvider = null;
		}
	}

	[Command(requiresAuthority = false)]
	public void CmdRequestRescue(int vehicleType, int index, NetworkConnectionToClient sender = null)
	{
		if (base.isServer && base.isClient)
		{
			UserCode_CmdRequestRescue__Int32__Int32__NetworkConnectionToClient(vehicleType, index, sender);
			return;
		}
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(vehicleType);
		writer.WriteVarInt(index);
		SendCommandInternal("System.Void VehicleRescueManager::CmdRequestRescue(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", -724906514, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerExecuteRescue(int vehicleType, int index)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void VehicleRescueManager::ServerExecuteRescue(System.Int32,System.Int32)' called when server was not active");
			return;
		}
		SCC_Network vehicle;
		Transform transform;
		switch (vehicleType)
		{
		case 0:
		{
			if (index < 0 || index >= forklifts.Count)
			{
				return;
			}
			ForkliftRescueEntry forkliftRescueEntry = forklifts[index];
			vehicle = forkliftRescueEntry.vehicle;
			transform = forkliftRescueEntry.rescuePoint;
			break;
		}
		case 1:
		{
			if (index < 0 || index >= trucks.Count)
			{
				return;
			}
			TruckRescueEntry truckRescueEntry = trucks[index];
			vehicle = truckRescueEntry.vehicle;
			if (vehicle.isInDigsite)
			{
				if (currentDigsiteProvider == null)
				{
					return;
				}
				transform = currentDigsiteProvider.GetTruckRescuePoint(index);
			}
			else
			{
				transform = truckRescueEntry.factoryRescuePoint;
			}
			break;
		}
		default:
			return;
		}
		if (!(vehicle == null) && !(transform == null) && !vehicle.HasDriverAll && !vehicle.IsTravelActive)
		{
			vehicle.ServerTeleport(transform.position, transform.rotation);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdRequestRescue__Int32__Int32__NetworkConnectionToClient(int vehicleType, int index, NetworkConnectionToClient sender)
	{
		ServerExecuteRescue(vehicleType, index);
	}

	protected static void InvokeUserCode_CmdRequestRescue__Int32__Int32__NetworkConnectionToClient(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdRequestRescue called on client.");
		}
		else
		{
			((VehicleRescueManager)obj).UserCode_CmdRequestRescue__Int32__Int32__NetworkConnectionToClient(reader.ReadVarInt(), reader.ReadVarInt(), senderConnection);
		}
	}

	static VehicleRescueManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(VehicleRescueManager), "System.Void VehicleRescueManager::CmdRequestRescue(System.Int32,System.Int32,Mirror.NetworkConnectionToClient)", InvokeUserCode_CmdRequestRescue__Int32__Int32__NetworkConnectionToClient, requiresAuthority: false);
	}
}
