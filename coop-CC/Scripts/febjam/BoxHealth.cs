using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class BoxHealth : NetworkEntityBehaviourBase, IBoxActivated
{
	public bool takeDamageOnActivation;

	public DamageMask allowedMask = DamageMask.Damaged | DamageMask.Burnt;

	[Space]
	public GameObject undamagedContainer;

	public GameObject damagedContainer;

	[Space]
	public GameObject damagedVfx;

	[SyncVar]
	private DamageMask _syncDamage;

	public bool useProceduralDamaged = true;

	public bool useProceduralBurnt = true;

	public Renderer[] damagedEnableRenderers;

	public DamageMask damage => _syncDamage;

	public bool isDamaged => _syncDamage != DamageMask.None;

	public DamageMask Network_syncDamage
	{
		get
		{
			return _syncDamage;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncDamage, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		if (base.isServer)
		{
			Network_syncDamage = DamageMask.None;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (undamagedContainer != null)
		{
			undamagedContainer.SetActive(!isDamaged);
		}
		if (damagedContainer != null)
		{
			damagedContainer.SetActive(isDamaged);
		}
		Renderer[] boxMeshRenderers = base.entity.GetObject<Grabbable>().boxMeshRenderers;
		foreach (Renderer meshRenderer in boxMeshRenderers)
		{
			if (_syncDamage.HasFlag(DamageMask.Damaged) && useProceduralDamaged)
			{
				meshRenderer.SetPropertyBlockFloat("_damaged", 1f);
			}
			if (_syncDamage.HasFlag(DamageMask.Burnt) && useProceduralBurnt)
			{
				meshRenderer.SetPropertyBlockFloat("_burnt", 1f);
			}
		}
		if (_syncDamage.HasFlag(DamageMask.Damaged))
		{
			boxMeshRenderers = damagedEnableRenderers;
			for (int i = 0; i < boxMeshRenderers.Length; i++)
			{
				boxMeshRenderers[i].gameObject.SetActive(value: true);
			}
		}
		else
		{
			boxMeshRenderers = damagedEnableRenderers;
			for (int i = 0; i < boxMeshRenderers.Length; i++)
			{
				boxMeshRenderers[i].gameObject.SetActive(value: false);
			}
		}
	}

	public void RequestTakeDamage(DamageType type)
	{
		if (base.isServer)
		{
			ServerTakeDamage(type);
		}
		else if (!isDamaged)
		{
			CmdTakeDamage(type);
		}
	}

	[Command(requiresAuthority = false)]
	private void CmdTakeDamage(DamageType type)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		GeneratedNetworkCode._Write_DamageType(writer, type);
		SendCommandInternal("System.Void BoxHealth::CmdTakeDamage(DamageType)", -634999573, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private void ServerTakeDamage(DamageType type)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxHealth::ServerTakeDamage(DamageType)' called when server was not active");
		}
		else
		{
			if (base.entity.GetObject<BoxProps>().serverIsSafe || base.entity.GetObject<Grabbable>().serverIsOutbounding || ((uint)(byte)(1 << (int)type) & (uint)allowedMask) == 0)
			{
				return;
			}
			if (!isDamaged)
			{
				NetworkAggroManagerBase<VFXManager>.instance.Play(damagedVfx, base.entity.transform.position);
				if (isDamaged && base.entity.tags.Has(CCTags.TAG_FRAGILE))
				{
					EntityUtil.Destroy(base.entity);
				}
			}
			Network_syncDamage = (DamageMask)((uint)_syncDamage | (uint)(byte)(1 << (int)type));
		}
	}

	[Server]
	public void ServerHeal()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void BoxHealth::ServerHeal()' called when server was not active");
		}
		else
		{
			Network_syncDamage = DamageMask.None;
		}
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (takeDamageOnActivation || base.entity.tags.Has(CCTags.TAG_FRAGILE))
		{
			ServerTakeDamage(DamageType.Damaged);
		}
	}

	[DevCmd("health", "Change the health of boxes.\r\n\r\nUsage:\r\n    health <box>\r\n        Prints the current health of the box.\r\n\r\n    health <box> -damage\r\n        Damages the box.\r\n\r\n    health -all -damage\r\n        Damages all boxes.\r\n\r\n    health <box> -heal\r\n        Heals the box completely.\r\n\r\n    health -all -heal\r\n        Heals all boxes completely.", new string[] { "all", "damage", "heal" })]
	[DevCmdVerify("^[\\S]+$")]
	[DevCmdVerify("^[\\S]+ -damage$")]
	[DevCmdVerify("^-all -damage$")]
	[DevCmdVerify("^[\\S]+ -heal")]
	[DevCmdVerify("^-all -heal")]
	private static void HealthDevCmd(DevCmdArg[] args)
	{
		if (!GameUtil.isReady)
		{
			Debug.LogWarning("Entity world is not ready!");
			return;
		}
		string text = args[0].name;
		Entity box;
		if (text == null || text.Length != 0)
		{
			if (text == "all")
			{
				string text2 = args[1].name;
				if (!(text2 == "damage"))
				{
					if (text2 == "heal")
					{
						NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdAllBoxesHeal();
					}
					else
					{
						Debug.LogWarning("Unknown argument! (" + args[1].name + ")");
					}
				}
				else
				{
					NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdAllBoxesTakeDamage();
				}
			}
			else
			{
				Debug.LogWarning("Unknown argument! (" + args[0].name + ")");
			}
		}
		else if (DevCmdUtil.TryGetEntityFromDevCmdName(args[0].value, out box))
		{
			BoxHealth obj;
			if (args.Length > 1)
			{
				string text2 = args[1].name;
				if (!(text2 == "damage"))
				{
					if (text2 == "heal")
					{
						NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdBoxHeal(box);
					}
					else
					{
						Debug.LogWarning("Unknown argument! (" + args[1].name + ")");
					}
				}
				else
				{
					NetworkAggroManagerBase<NetworkDevCmds>.instance.CmdBoxTakeDamage(box);
				}
			}
			else if (box.TryGetObject<BoxHealth>(out obj))
			{
				Debug.Log($"Damage: {obj.damage}");
			}
			else
			{
				Debug.LogWarning("Entity does not have BoxHealth! (" + args[0].value + ")");
			}
		}
		else
		{
			Debug.LogWarning("Could not find an entity with dev cmd name! (" + args[0].value + ")");
		}
	}

	[DevCmdCompleteFunction("health", "", DevCmdCompleteFlags.Sort)]
	private static string[] HealthBoxDevComplete()
	{
		return DevCmdUtil.GetEntityNames<BoxHealth>();
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdTakeDamage__DamageType(DamageType type)
	{
		ServerTakeDamage(type);
	}

	protected static void InvokeUserCode_CmdTakeDamage__DamageType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdTakeDamage called on client.");
		}
		else
		{
			((BoxHealth)obj).UserCode_CmdTakeDamage__DamageType(GeneratedNetworkCode._Read_DamageType(reader));
		}
	}

	static BoxHealth()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(BoxHealth), "System.Void BoxHealth::CmdTakeDamage(DamageType)", InvokeUserCode_CmdTakeDamage__DamageType, requiresAuthority: false);
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			GeneratedNetworkCode._Write_DamageMask(writer, _syncDamage);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			GeneratedNetworkCode._Write_DamageMask(writer, _syncDamage);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _syncDamage, null, GeneratedNetworkCode._Read_DamageMask(reader));
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncDamage, null, GeneratedNetworkCode._Read_DamageMask(reader));
		}
	}
}
