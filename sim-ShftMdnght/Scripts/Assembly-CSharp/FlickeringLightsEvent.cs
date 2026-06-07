using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class FlickeringLightsEvent : NetworkBehaviour
{
	public GeneratorSwitch genSwitch;

	public Transform spawnCopyPos;

	public GameObject employeeCopy;

	public GameObject genSmokeParticles;

	public GameObject storeLights;

	public EntryDoor entryDoor;

	private bool finished;

	private void OnEnable()
	{
		storeLights.SetActive(value: false);
		genSwitch.powerOff = true;
	}

	public void FlickSwitch()
	{
		genSwitch.powerOff = false;
		genSmokeParticles.SetActive(value: false);
		if (base.isServer)
		{
			FlickSwitchRpc();
		}
		else
		{
			FlickSwitchCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void FlickSwitchCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void FlickeringLightsEvent::FlickSwitchCmd()", 2099766929, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void FlickSwitchRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void FlickeringLightsEvent::FlickSwitchRpc()", -913699470, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_FlickSwitchCmd()
	{
		FlickSwitchRpc();
	}

	protected static void InvokeUserCode_FlickSwitchCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command FlickSwitchCmd called on client.");
		}
		else
		{
			((FlickeringLightsEvent)obj).UserCode_FlickSwitchCmd();
		}
	}

	protected void UserCode_FlickSwitchRpc()
	{
		if (!finished)
		{
			finished = true;
			storeLights.SetActive(value: true);
			StoreManager.Instance.FinishObjective();
			base.gameObject.SetActive(value: false);
			genSwitch.powerOff = false;
			genSmokeParticles.SetActive(value: false);
			if (base.isServer)
			{
				entryDoor.Invoke("ActuallyEnter", 1f);
				NetworkServer.Spawn(Object.Instantiate(employeeCopy, spawnCopyPos.position, Quaternion.identity));
			}
		}
	}

	protected static void InvokeUserCode_FlickSwitchRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC FlickSwitchRpc called on server.");
		}
		else
		{
			((FlickeringLightsEvent)obj).UserCode_FlickSwitchRpc();
		}
	}

	static FlickeringLightsEvent()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FlickeringLightsEvent), "System.Void FlickeringLightsEvent::FlickSwitchCmd()", InvokeUserCode_FlickSwitchCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(FlickeringLightsEvent), "System.Void FlickeringLightsEvent::FlickSwitchRpc()", InvokeUserCode_FlickSwitchRpc);
	}
}
