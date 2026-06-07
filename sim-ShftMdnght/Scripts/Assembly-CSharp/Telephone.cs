using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

public class Telephone : Interactable
{
	public string whosCalling;

	public GameObject chasingNathan;

	public GameObject brokenDownCar;

	public Outline outline;

	public GameObject ratInfestationCountdownCanvas;

	public GameObject ratInfestationCamera;

	public GameObject roachInfestationCountdownCanvas;

	public GameObject roachInfestationCamera;

	public bool telephoneDone;

	public int curChatIndex = 1;

	public RatCountdown ratCountdown;

	public RoachCountdown roachCountdown;

	public GameObject carBrokenDown;

	public GameObject forestLimbsEvent;

	public Animator[] ventAnims;

	public GameObject rat;

	public GameObject roach;

	public Transform[] roachSpawnPoints;

	private int roachSpawnIndex;

	public static Telephone Instance { get; private set; }

	public override void Interact(PlayerManager playerMan)
	{
		switch (whosCalling)
		{
		case "CarBrokenDown":
			if (!telephoneDone)
			{
				for (int k = 0; k < 3; k++)
				{
					Invoke("RunDialogue", k * 3);
				}
				if (base.isServer)
				{
					ActuallyInteract(playerMan);
				}
				else
				{
					InteractCmd(playerMan);
				}
				if (base.isServer)
				{
					CarBrokenDownEventRpc(playerMan);
				}
				else
				{
					CarBrokenDownEventCmd(playerMan);
				}
			}
			else
			{
				StoreManager.Instance.SetAlert("No one is calling", "red");
			}
			break;
		case "RatInfestation":
			if (!telephoneDone)
			{
				for (int l = 0; l < 4; l++)
				{
					Invoke("RunDialogue", l * 4);
				}
				if (base.isServer)
				{
					ActuallyInteract(playerMan);
				}
				else
				{
					InteractCmd(playerMan);
				}
				if (base.isServer)
				{
					RatInfestationEventRpc();
				}
				else
				{
					RatInfestationEventCmd();
				}
			}
			else
			{
				StoreManager.Instance.SetAlert("No one is calling", "red");
			}
			break;
		case "RoachInfestation":
			if (!telephoneDone)
			{
				for (int j = 0; j < 5; j++)
				{
					Invoke("RunDialogue", j * 4);
				}
				if (base.isServer)
				{
					ActuallyInteract(playerMan);
				}
				else
				{
					InteractCmd(playerMan);
				}
				if (base.isServer)
				{
					RoachInfestationEventRpc();
				}
				else
				{
					RoachInfestationEventCmd();
				}
			}
			else
			{
				StoreManager.Instance.SetAlert("No one is calling", "red");
			}
			break;
		case "ForestLimbs":
			if (!telephoneDone)
			{
				for (int i = 0; i < 6; i++)
				{
					Invoke("RunDialogue", (float)i * 5.2f);
				}
				if (base.isServer)
				{
					ActuallyInteract(playerMan);
				}
				else
				{
					InteractCmd(playerMan);
				}
				if (base.isServer)
				{
					ForestLimbsEventRpc(playerMan);
				}
				else
				{
					ForestLimbsEventCmd(playerMan);
				}
			}
			else
			{
				StoreManager.Instance.SetAlert("No one is calling", "red");
			}
			break;
		default:
			StoreManager.Instance.SetAlert("No one is calling", "red");
			break;
		}
	}

	private void RunDialogue()
	{
		SpeakingManager.Instance.AddChatLogNode(SpeakingManager.Instance.GetDialogueText(whosCalling, "Name", usesKeyIndex: false), SpeakingManager.Instance.GetDialogueText(whosCalling, "ChatDialogue" + curChatIndex, usesKeyIndex: false), 0);
		curChatIndex++;
	}

	[Command(requiresAuthority = false)]
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Telephone::InteractCmd(PlayerManager)", -892249919, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Telephone::ActuallyInteract(PlayerManager)", -1011679790, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void ForestLimbsEventCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Telephone::ForestLimbsEventCmd(PlayerManager)", -1736001855, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ForestLimbsEventRpc(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Telephone::ForestLimbsEventRpc(PlayerManager)", -211367196, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void ForestLimbsEvent()
	{
		forestLimbsEvent.SetActive(value: true);
	}

	[Command(requiresAuthority = false)]
	public void CarBrokenDownEventCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void Telephone::CarBrokenDownEventCmd(PlayerManager)", -2019373310, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void CarBrokenDownEventRpc(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void Telephone::CarBrokenDownEventRpc(PlayerManager)", 183612783, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void RatInfestationEventCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Telephone::RatInfestationEventCmd()", -1811044284, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RatInfestationEventRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Telephone::RatInfestationEventRpc()", 2001211403, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Command(requiresAuthority = false)]
	public void RoachInfestationEventCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Telephone::RoachInfestationEventCmd()", -972827830, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void RoachInfestationEventRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Telephone::RoachInfestationEventRpc()", 2070804285, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SpawnRat()
	{
		NetworkServer.Spawn(Object.Instantiate(rat, EventManager.Instance.playerDoppelgangerSpawnpoint.position, Quaternion.identity));
	}

	private void SpawnRoach()
	{
		NetworkServer.Spawn(Object.Instantiate(roach, roachSpawnPoints[roachSpawnIndex].position, roachSpawnPoints[roachSpawnIndex].rotation));
		roachSpawnIndex++;
		if (roachSpawnIndex >= roachSpawnPoints.Length)
		{
			roachSpawnIndex = 0;
		}
	}

	private void GivePlayerControlAgain()
	{
		StoreManager.Instance.ExitCutscene();
		string text = whosCalling;
		if (!(text == "RatInfestation"))
		{
			if (text == "RoachInfestation")
			{
				roachCountdown.StartEvent(StoreManager.Instance.playerMans.Count * 8 + 12);
				roachCountdown.gameObject.SetActive(value: true);
			}
		}
		else
		{
			ratCountdown.StartEvent(StoreManager.Instance.playerMans.Count * 7 + 10);
			ratCountdown.gameObject.SetActive(value: true);
		}
	}

	private void TurnOnNextCanvas()
	{
		StoreManager.Instance.NewObjective("Objectives", "Help Him");
	}

	private void TurnOnRatCanvas()
	{
	}

	private void TurnOnRoachCanvas()
	{
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected override void UserCode_InteractCmd__PlayerManager(PlayerManager playerMan)
	{
		ActuallyInteract(playerMan);
	}

	protected new static void InvokeUserCode_InteractCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractCmd called on client.");
		}
		else
		{
			((Telephone)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		StoreManager.Instance.FinishObjective();
		if (interactSFX != null)
		{
			interactSFX.Play();
		}
		if (interactAnim != null)
		{
			interactAnim.SetTrigger("Interact");
		}
		interactEvent.Invoke();
		outline.enabled = false;
		telephoneDone = true;
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((Telephone)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_ForestLimbsEventCmd__PlayerManager(PlayerManager playerMan)
	{
		ForestLimbsEventRpc(playerMan);
	}

	protected static void InvokeUserCode_ForestLimbsEventCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ForestLimbsEventCmd called on client.");
		}
		else
		{
			((Telephone)obj).UserCode_ForestLimbsEventCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_ForestLimbsEventRpc__PlayerManager(PlayerManager playerMan)
	{
		Invoke("ForestLimbsEvent", 30f);
	}

	protected static void InvokeUserCode_ForestLimbsEventRpc__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ForestLimbsEventRpc called on server.");
		}
		else
		{
			((Telephone)obj).UserCode_ForestLimbsEventRpc__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_CarBrokenDownEventCmd__PlayerManager(PlayerManager playerMan)
	{
		CarBrokenDownEventRpc(playerMan);
	}

	protected static void InvokeUserCode_CarBrokenDownEventCmd__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CarBrokenDownEventCmd called on client.");
		}
		else
		{
			((Telephone)obj).UserCode_CarBrokenDownEventCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_CarBrokenDownEventRpc__PlayerManager(PlayerManager playerMan)
	{
		carBrokenDown.SetActive(value: true);
		Invoke("TurnOnNextCanvas", 10f);
		chasingNathan.SetActive(value: true);
	}

	protected static void InvokeUserCode_CarBrokenDownEventRpc__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CarBrokenDownEventRpc called on server.");
		}
		else
		{
			((Telephone)obj).UserCode_CarBrokenDownEventRpc__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_RatInfestationEventCmd()
	{
		RatInfestationEventRpc();
	}

	protected static void InvokeUserCode_RatInfestationEventCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RatInfestationEventCmd called on client.");
		}
		else
		{
			((Telephone)obj).UserCode_RatInfestationEventCmd();
		}
	}

	protected void UserCode_RatInfestationEventRpc()
	{
		StoreManager.Instance.EnterCutscene();
		Invoke("GivePlayerControlAgain", 15f);
		ratInfestationCamera.SetActive(value: true);
		Invoke("TurnOnRatCanvas", 10f);
		if (ClientPlayer.Instance.isServer)
		{
			int count = StoreManager.Instance.playerMans.Count;
			int num = 11 + count * 9;
			for (int i = 0; i < num; i++)
			{
				float time = (float)i * 0.3f + Random.Range(0f, 1f) + 2.1f;
				Invoke("SpawnRat", time);
			}
		}
	}

	protected static void InvokeUserCode_RatInfestationEventRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RatInfestationEventRpc called on server.");
		}
		else
		{
			((Telephone)obj).UserCode_RatInfestationEventRpc();
		}
	}

	protected void UserCode_RoachInfestationEventCmd()
	{
		RoachInfestationEventRpc();
	}

	protected static void InvokeUserCode_RoachInfestationEventCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command RoachInfestationEventCmd called on client.");
		}
		else
		{
			((Telephone)obj).UserCode_RoachInfestationEventCmd();
		}
	}

	protected void UserCode_RoachInfestationEventRpc()
	{
		Animator[] array = ventAnims;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetBool("Open", value: true);
		}
		StoreManager.Instance.EnterCutscene();
		Invoke("GivePlayerControlAgain", 17f);
		roachInfestationCamera.SetActive(value: true);
		Invoke("TurnOnRoachCanvas", 17f);
		if (ClientPlayer.Instance.isServer)
		{
			int count = StoreManager.Instance.playerMans.Count;
			int num = 15 + count * 10;
			for (int j = 0; j < num; j++)
			{
				float time = (float)j * 0.285f + 7f;
				Invoke("SpawnRoach", time);
			}
		}
	}

	protected static void InvokeUserCode_RoachInfestationEventRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RoachInfestationEventRpc called on server.");
		}
		else
		{
			((Telephone)obj).UserCode_RoachInfestationEventRpc();
		}
	}

	static Telephone()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Telephone), "System.Void Telephone::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Telephone), "System.Void Telephone::ForestLimbsEventCmd(PlayerManager)", InvokeUserCode_ForestLimbsEventCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Telephone), "System.Void Telephone::CarBrokenDownEventCmd(PlayerManager)", InvokeUserCode_CarBrokenDownEventCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Telephone), "System.Void Telephone::RatInfestationEventCmd()", InvokeUserCode_RatInfestationEventCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Telephone), "System.Void Telephone::RoachInfestationEventCmd()", InvokeUserCode_RoachInfestationEventCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Telephone), "System.Void Telephone::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(Telephone), "System.Void Telephone::ForestLimbsEventRpc(PlayerManager)", InvokeUserCode_ForestLimbsEventRpc__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(Telephone), "System.Void Telephone::CarBrokenDownEventRpc(PlayerManager)", InvokeUserCode_CarBrokenDownEventRpc__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(Telephone), "System.Void Telephone::RatInfestationEventRpc()", InvokeUserCode_RatInfestationEventRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Telephone), "System.Void Telephone::RoachInfestationEventRpc()", InvokeUserCode_RoachInfestationEventRpc);
	}
}
