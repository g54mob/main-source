using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class NamePlateHandler : NetworkEntityBehaviourBase
{
	[SyncVar]
	public string nameText = "Player";

	public PlayerColorManager playerColorManager;

	public GameObject namePlatePrefab;

	private GameObject namePlate;

	private NamePlateUI ui;

	public bool nameSet;

	public Transform playerUITransform;

	[SyncVar]
	public bool proceeding;

	public string NetworknameText
	{
		get
		{
			return nameText;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref nameText, 1uL, null);
		}
	}

	public bool Networkproceeding
	{
		get
		{
			return proceeding;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref proceeding, 2uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		namePlate = Object.Instantiate(namePlatePrefab, Vector3.zero, Quaternion.identity);
		Object.DontDestroyOnLoad(namePlate);
		ui = namePlate.GetComponent<NamePlateUI>();
		ui.playerColorManager = playerColorManager;
		ui.player = playerUITransform;
		ui.playerEntity = base.entity;
	}

	protected override void OnUpdatePresentation()
	{
		if (!nameSet && base.isLocalPlayer)
		{
			NetworknameText = Platform.GetUserName();
			if (nameText != null && nameText != "<UNKNOWN>")
			{
				nameSet = true;
			}
		}
		if (GameUtil.isLobby)
		{
			if (base.isLocalPlayer)
			{
				Networkproceeding = NetworkAggroManagerBase<PlayersManager>.instance.proceededLastTimer || NetworkAggroManagerBase<PlayersManager>.instance.GetAmIProceeding();
			}
			if (proceeding != ui.readyUpCheck.activeSelf)
			{
				ui.readyUpCheck.SetActive(proceeding);
			}
		}
		if (nameText != ui.nameTextUI.text)
		{
			ui.nameTextUI.text = nameText;
		}
		ModifierFaultyWiring modifier;
		bool flag = !GameUtil.isRun || !NetworkAggroManagerBase<ModifierManager>.instance.TryGetModiferAs<ModifierFaultyWiring>(out modifier) || modifier.lightsOffValue < 0.8f;
		if (base.isLocalPlayer && !GameUtil.isLobby)
		{
			flag = false;
		}
		if (flag != namePlate.activeSelf)
		{
			namePlate.SetActive(flag);
		}
	}

	protected override void OnEntityDestroyed()
	{
		Object.Destroy(namePlate);
		namePlate = null;
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
			writer.WriteString(nameText);
			writer.WriteBool(proceeding);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteString(nameText);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteBool(proceeding);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref nameText, null, reader.ReadString());
			GeneratedSyncVarDeserialize(ref proceeding, null, reader.ReadBool());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref nameText, null, reader.ReadString());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref proceeding, null, reader.ReadBool());
		}
	}
}
