using System.Runtime.InteropServices;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class PlayerCostumeManagerNetwork : NetworkEntityBehaviourBase
{
	public PlayerCostumeManager costumeManager;

	[SyncVar]
	public int currentCostumeID;

	private ulong _saveVersion;

	public int NetworkcurrentCostumeID
	{
		get
		{
			return currentCostumeID;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref currentCostumeID, 1uL, null);
		}
	}

	public override void OnStartLocalPlayer()
	{
		if (GameUtil.isRun)
		{
			InitializeCostumeFromSaveData();
		}
		costumeManager.ResetAllCostumes();
	}

	protected override void OnEntityCreated()
	{
		if (!GameUtil.isReady)
		{
			SaveManager.data.TryGetCurrentCostume(out var costume);
			NetworkcurrentCostumeID = costumeManager.GetIndexFromCostumeObject(costume);
			costumeManager.currentCostumeID = currentCostumeID;
			costumeManager.ResetAllCostumes();
		}
		else
		{
			costumeManager.SetUpUnlockedIndicies();
		}
	}

	protected override void OnUpdatePresentationEarly()
	{
		if (base.isLocalPlayer && _saveVersion != SaveManager.data.GetVersion())
		{
			InitializeCostumeFromSaveData();
		}
	}

	public void SetCostumeIndex(int index)
	{
		NetworkcurrentCostumeID = index;
		if (Application.isPlaying)
		{
			SaveManager.data.SetCurrentCostume(costumeManager.costumes[currentCostumeID].costumeObject);
		}
		else
		{
			costumeManager.currentCostumeID = currentCostumeID;
		}
		costumeManager.UpdateCostume();
	}

	public void InitializeCostumeFromSaveData()
	{
		_saveVersion = SaveManager.data.GetVersion();
		if (SaveManager.data.TryGetCurrentCostume(out var costume))
		{
			NetworkcurrentCostumeID = costumeManager.GetIndexFromCostumeObject(costume);
			return;
		}
		NetworkcurrentCostumeID = 0;
		SaveManager.data.SetCurrentCostume(costumeManager.costumes[currentCostumeID].costumeObject);
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(currentCostumeID);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(currentCostumeID);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref currentCostumeID, null, reader.ReadVarInt());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref currentCostumeID, null, reader.ReadVarInt());
		}
	}
}
