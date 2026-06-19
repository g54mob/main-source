using Aggro.Core;
using Aggro.Core.Networking;
using DevCmdLine;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class NetworkDevCmds : NetworkAggroManagerBase<NetworkDevCmds>
{
	[Command(requiresAuthority = false)]
	public void CmdAllBoxesTakeDamage()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkDevCmds::CmdAllBoxesTakeDamage()", -1273814391, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdBoxTakeDamage(Entity box)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(box);
		SendCommandInternal("System.Void NetworkDevCmds::CmdBoxTakeDamage(Aggro.Core.Entity)", -1165900578, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAllBoxesHeal()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkDevCmds::CmdAllBoxesHeal()", 1864073137, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdBoxHeal(Entity box)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(box);
		SendCommandInternal("System.Void NetworkDevCmds::CmdBoxHeal(Aggro.Core.Entity)", 265315238, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAllBoxesActivate()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkDevCmds::CmdAllBoxesActivate()", -293408838, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdBoxActivate(Entity box)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(box);
		SendCommandInternal("System.Void NetworkDevCmds::CmdBoxActivate(Aggro.Core.Entity)", 834570187, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdBoxSetFire(Entity box)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(box);
		SendCommandInternal("System.Void NetworkDevCmds::CmdBoxSetFire(Aggro.Core.Entity)", 1158636442, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdBoxClearFire(Entity box)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(box);
		SendCommandInternal("System.Void NetworkDevCmds::CmdBoxClearFire(Aggro.Core.Entity)", 594100101, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAllBoxesSetFire()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkDevCmds::CmdAllBoxesSetFire()", 366889235, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdAllBoxesClearFire()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void NetworkDevCmds::CmdAllBoxesClearFire()", -841512654, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void CmdSpawnPrefab(string prefabName, Vector3 position, Quaternion rotation)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(prefabName);
		writer.WriteVector3(position);
		writer.WriteQuaternion(rotation);
		SendCommandInternal("System.Void NetworkDevCmds::CmdSpawnPrefab(System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", -1155062486, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[DevCmd("network", "Various dev cmds for interaction with the network stack.\r\n\r\nUsage:\r\n    network -simlatency\r\n        Toggles on/off default simulated latency (100 latency and 2% packet loss)\r\n\r\n    network -simlatency <latency> <packetloss>\r\n        Toggles on/off simulated latency with the supplied latency and packet loss.", new string[] { "simlatency" })]
	[DevCmdVerify("^-simlatency$")]
	[DevCmdVerify("^-simlatency [0-9]+ [0-9]+$")]
	public static void NetworkDevCmd(DevCmdArg[] args)
	{
		if (args[0].name == "simlatency")
		{
			if (NetworkUtil.IsSimulatingLatency())
			{
				NetworkUtil.DisableSimulatedLatency();
				Debug.Log("Disabled network latency");
				return;
			}
			float latency = 100f;
			float packetLoss = 2f;
			if (args[0].hasValue && int.TryParse(args[0].value, out var result))
			{
				latency = result;
			}
			if (args.Length >= 2 && int.TryParse(args[1].value, out var result2))
			{
				packetLoss = result2;
			}
			NetworkUtil.EnableSimulatedLatency(latency, packetLoss);
			Debug.Log("Enabled network latency");
		}
		else
		{
			Debug.LogWarning("Unknown argument " + args[0].name);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CmdAllBoxesTakeDamage()
	{
		ObjectQuery<BoxHealth> objectQuery = GameUtil.entityManager.CreateObjectQuery<BoxHealth>();
		objectQuery.Run();
		foreach (BoxHealth item in objectQuery)
		{
			item.RequestTakeDamage(DamageType.Damaged);
		}
	}

	protected static void InvokeUserCode_CmdAllBoxesTakeDamage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAllBoxesTakeDamage called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdAllBoxesTakeDamage();
		}
	}

	protected void UserCode_CmdBoxTakeDamage__Entity(Entity box)
	{
		if (box.TryGetObject<BoxHealth>(out var obj))
		{
			obj.RequestTakeDamage(DamageType.Damaged);
		}
	}

	protected static void InvokeUserCode_CmdBoxTakeDamage__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBoxTakeDamage called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdBoxTakeDamage__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdAllBoxesHeal()
	{
		ObjectQuery<BoxHealth> objectQuery = GameUtil.entityManager.CreateObjectQuery<BoxHealth>();
		objectQuery.Run();
		foreach (BoxHealth item in objectQuery)
		{
			item.ServerHeal();
		}
	}

	protected static void InvokeUserCode_CmdAllBoxesHeal(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAllBoxesHeal called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdAllBoxesHeal();
		}
	}

	protected void UserCode_CmdBoxHeal__Entity(Entity box)
	{
		if (box.TryGetObject<BoxHealth>(out var obj))
		{
			obj.ServerHeal();
		}
	}

	protected static void InvokeUserCode_CmdBoxHeal__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBoxHeal called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdBoxHeal__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdAllBoxesActivate()
	{
		ObjectQuery<BoxActivator> objectQuery = GameUtil.entityManager.CreateObjectQuery<BoxActivator>();
		objectQuery.Run();
		foreach (BoxActivator item in objectQuery)
		{
			item.RequestActivate(new ActivationContext(ActivationContextType.DevCmd));
		}
	}

	protected static void InvokeUserCode_CmdAllBoxesActivate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAllBoxesActivate called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdAllBoxesActivate();
		}
	}

	protected void UserCode_CmdBoxActivate__Entity(Entity box)
	{
		if (box.TryGetObject<BoxActivator>(out var obj))
		{
			obj.RequestActivate(new ActivationContext(ActivationContextType.DevCmd));
		}
	}

	protected static void InvokeUserCode_CmdBoxActivate__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBoxActivate called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdBoxActivate__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdBoxSetFire__Entity(Entity box)
	{
		if (box.TryGetObject<Flammable>(out var obj))
		{
			obj.RequestSetFire();
		}
	}

	protected static void InvokeUserCode_CmdBoxSetFire__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBoxSetFire called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdBoxSetFire__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdBoxClearFire__Entity(Entity box)
	{
		if (box.TryGetObject<Flammable>(out var obj))
		{
			obj.RequestClearFire();
		}
	}

	protected static void InvokeUserCode_CmdBoxClearFire__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdBoxClearFire called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdBoxClearFire__Entity(reader.ReadEntity());
		}
	}

	protected void UserCode_CmdAllBoxesSetFire()
	{
		ObjectQuery<Flammable> objectQuery = GameUtil.entityManager.CreateObjectQuery<Flammable>();
		objectQuery.Run();
		foreach (Flammable item in objectQuery)
		{
			item.RequestSetFire();
		}
	}

	protected static void InvokeUserCode_CmdAllBoxesSetFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAllBoxesSetFire called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdAllBoxesSetFire();
		}
	}

	protected void UserCode_CmdAllBoxesClearFire()
	{
		ObjectQuery<Flammable> objectQuery = GameUtil.entityManager.CreateObjectQuery<Flammable>();
		objectQuery.Run();
		foreach (Flammable item in objectQuery)
		{
			item.RequestClearFire();
		}
	}

	protected static void InvokeUserCode_CmdAllBoxesClearFire(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdAllBoxesClearFire called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdAllBoxesClearFire();
		}
	}

	protected void UserCode_CmdSpawnPrefab__String__Vector3__Quaternion(string prefabName, Vector3 position, Quaternion rotation)
	{
		if (DevCmdSpawn.TryGetPrefab(prefabName, out var prefab))
		{
			Entity entity = EntityUtil.Instantiate(prefab, position, rotation);
			if (entity.gameObject.TryGetComponent<DevCmdSpawn>(out var component) && component.spawnOnGround)
			{
				Vector3 position2 = entity.transform.position;
				position2.y = 0f;
				entity.transform.position = position2;
			}
		}
	}

	protected static void InvokeUserCode_CmdSpawnPrefab__String__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CmdSpawnPrefab called on client.");
		}
		else
		{
			((NetworkDevCmds)obj).UserCode_CmdSpawnPrefab__String__Vector3__Quaternion(reader.ReadString(), reader.ReadVector3(), reader.ReadQuaternion());
		}
	}

	static NetworkDevCmds()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdAllBoxesTakeDamage()", InvokeUserCode_CmdAllBoxesTakeDamage, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdBoxTakeDamage(Aggro.Core.Entity)", InvokeUserCode_CmdBoxTakeDamage__Entity, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdAllBoxesHeal()", InvokeUserCode_CmdAllBoxesHeal, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdBoxHeal(Aggro.Core.Entity)", InvokeUserCode_CmdBoxHeal__Entity, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdAllBoxesActivate()", InvokeUserCode_CmdAllBoxesActivate, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdBoxActivate(Aggro.Core.Entity)", InvokeUserCode_CmdBoxActivate__Entity, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdBoxSetFire(Aggro.Core.Entity)", InvokeUserCode_CmdBoxSetFire__Entity, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdBoxClearFire(Aggro.Core.Entity)", InvokeUserCode_CmdBoxClearFire__Entity, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdAllBoxesSetFire()", InvokeUserCode_CmdAllBoxesSetFire, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdAllBoxesClearFire()", InvokeUserCode_CmdAllBoxesClearFire, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(NetworkDevCmds), "System.Void NetworkDevCmds::CmdSpawnPrefab(System.String,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_CmdSpawnPrefab__String__Vector3__Quaternion, requiresAuthority: false);
	}
}
