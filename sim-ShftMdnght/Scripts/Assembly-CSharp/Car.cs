using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;

public class Car : NetworkBehaviour
{
	public Animator carAnim;

	public MaterialFader[] matFaders;

	public GameObject[] objsToTurnOffWhenFade;

	public AudioSource carEngineRunning;

	public Interactable[] carDoorInteractables;

	public Animator[] carDoorAnims;

	public DialogueInteractable npc;

	public PetrolTank petrolTank;

	public string carLicencePlate;

	public string localizedCarLicencePlate;

	public GameObject carDescriptionQuestion;

	private bool fadeOutAudio;

	public GameObject tutorialArrow;

	public Collider[] carColliders;

	public TextMeshProUGUI licensePlate;

	public GameObject leaveBtn;

	private bool alreadyFaded;

	public GameObject howMayIHelpBtn;

	public static Car Instance { get; private set; }

	private void Start()
	{
		if (base.isServer)
		{
			npc.pathfindScript.RpcTrigger(npc.pathfindScript.walkAnim);
		}
		else
		{
			npc.pathfindScript.CmdTrigger(npc.pathfindScript.walkAnim);
		}
		localizedCarLicencePlate = JSONAccess.Instance.GetCarDatabaseInnerName(carLicencePlate);
		licensePlate.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		licensePlate.text = localizedCarLicencePlate;
	}

	private void FixedUpdate()
	{
		if (fadeOutAudio)
		{
			carEngineRunning.volume = Mathf.Lerp(carEngineRunning.volume, 0f, Time.deltaTime / 5f);
		}
	}

	public void CarDone()
	{
		if (!alreadyFaded)
		{
			if (base.isServer)
			{
				CarDoneRpc();
			}
			else
			{
				CarDoneCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void CarDoneCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Car::CarDoneCmd()", 992990135, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CarDoneRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Car::CarDoneRpc()", 1452600596, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CarDestroy()
	{
		if (base.isServer)
		{
			NetworkServer.Destroy(base.gameObject);
		}
	}

	public void CarUnlock()
	{
		if (base.isServer)
		{
			CarUnlockRpc();
		}
		else
		{
			CarUnlockCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void CarUnlockCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Car::CarUnlockCmd()", -1082588389, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CarUnlockRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Car::CarUnlockRpc()", -1712621352, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void CarFadeAway()
	{
		Collider[] array = carColliders;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].enabled = false;
		}
		if (base.isServer)
		{
			Invoke("CarFadeAwayRpc", 1f);
		}
		else
		{
			Invoke("CarFadeAwayCmd", 1f);
		}
	}

	[Command(requiresAuthority = false)]
	private void CarFadeAwayCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Car::CarFadeAwayCmd()", -115597389, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void CarFadeAwayRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Car::CarFadeAwayRpc()", -247760096, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void NewQuestioningTopicHint()
	{
		StoreManager.Instance.AddHint("New topic unlocked. You can now ask the driver about this.");
		StoreManager.Instance.NextHint();
	}

	public void InteractWithNPC()
	{
		if (base.isServer)
		{
			InteractWithNPCRpc();
		}
		else
		{
			InteractWithNPCCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void InteractWithNPCCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void Car::InteractWithNPCCmd()", -736909546, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void InteractWithNPCRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Car::InteractWithNPCRpc()", 93431817, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CloseAllDoors()
	{
		if (alreadyFaded)
		{
			return;
		}
		Animator[] array = carDoorAnims;
		foreach (Animator animator in array)
		{
			if (!(animator == null))
			{
				animator.SetTrigger("Close");
			}
		}
		DisableAllInteractables();
		npc.ExitDialogue();
	}

	private void DisableAllInteractables()
	{
		Interactable[] array = carDoorInteractables;
		foreach (Interactable interactable in array)
		{
			if (!(interactable == null))
			{
				interactable.ChangeInteractableStatus(change: false);
				if ((bool)interactable.GetComponent<AudioSource>())
				{
					interactable.GetComponent<AudioSource>().Play();
				}
			}
		}
		npc.ExitDialogue();
	}

	private void CarLeave()
	{
		if (!alreadyFaded)
		{
			if (base.isServer)
			{
				StoreManager.Instance.ChangeRevenue("Fuelled Car", petrolTank.maxMoneySpent);
			}
			StoreManager.Instance.flashlightOutline.enabled = false;
			StoreManager.Instance.flashlightOutlineAnim.enabled = false;
			carAnim.SetTrigger("DriveOut");
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.1f);
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_CarDoneCmd()
	{
		CarDoneRpc();
	}

	protected static void InvokeUserCode_CarDoneCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CarDoneCmd called on client.");
		}
		else
		{
			((Car)obj).UserCode_CarDoneCmd();
		}
	}

	protected void UserCode_CarDoneRpc()
	{
		if (!alreadyFaded)
		{
			leaveBtn.SetActive(value: false);
			if (npc.pathfindScript.isDoppelganger)
			{
				StoreManager.Instance.doppelsLetThru++;
				CurrentDayManager.Instance.HuntCaused();
			}
			npc.pathfindScript.hittable.ChangeHealth(1000000f);
			Invoke("CloseAllDoors", 2f);
			Invoke("CarLeave", 3f);
			Invoke("CarDestroy", 11f);
			petrolTank.uiCanvas.SetActive(value: false);
		}
	}

	protected static void InvokeUserCode_CarDoneRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CarDoneRpc called on server.");
		}
		else
		{
			((Car)obj).UserCode_CarDoneRpc();
		}
	}

	protected void UserCode_CarUnlockCmd()
	{
		CarUnlockRpc();
	}

	protected static void InvokeUserCode_CarUnlockCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CarUnlockCmd called on client.");
		}
		else
		{
			((Car)obj).UserCode_CarUnlockCmd();
		}
	}

	protected void UserCode_CarUnlockRpc()
	{
		StoreManager.Instance.flashlightOutline.enabled = true;
		StoreManager.Instance.flashlightOutlineAnim.enabled = true;
		tutorialArrow.SetActive(value: true);
		Interactable[] array = carDoorInteractables;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].ChangeInteractableStatus(change: true);
		}
	}

	protected static void InvokeUserCode_CarUnlockRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CarUnlockRpc called on server.");
		}
		else
		{
			((Car)obj).UserCode_CarUnlockRpc();
		}
	}

	protected void UserCode_CarFadeAwayCmd()
	{
		CarFadeAwayRpc();
	}

	protected static void InvokeUserCode_CarFadeAwayCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command CarFadeAwayCmd called on client.");
		}
		else
		{
			((Car)obj).UserCode_CarFadeAwayCmd();
		}
	}

	protected void UserCode_CarFadeAwayRpc()
	{
		if (alreadyFaded)
		{
			return;
		}
		StoreManager.Instance.flashlightOutline.enabled = false;
		StoreManager.Instance.flashlightOutlineAnim.enabled = false;
		alreadyFaded = true;
		DisableAllInteractables();
		fadeOutAudio = true;
		if (base.isServer)
		{
			CurrentDayManager.Instance.Invoke("CompleteOccurrence", 0.1f);
		}
		GameObject[] array = objsToTurnOffWhenFade;
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				gameObject.SetActive(value: false);
			}
		}
		MaterialFader[] array2 = matFaders;
		foreach (MaterialFader materialFader in array2)
		{
			if (!(materialFader == null))
			{
				materialFader.PlayFadeOut(4f);
			}
		}
		Invoke("CarDestroy", 4f);
	}

	protected static void InvokeUserCode_CarFadeAwayRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC CarFadeAwayRpc called on server.");
		}
		else
		{
			((Car)obj).UserCode_CarFadeAwayRpc();
		}
	}

	protected void UserCode_InteractWithNPCCmd()
	{
		InteractWithNPCRpc();
	}

	protected static void InvokeUserCode_InteractWithNPCCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command InteractWithNPCCmd called on client.");
		}
		else
		{
			((Car)obj).UserCode_InteractWithNPCCmd();
		}
	}

	protected void UserCode_InteractWithNPCRpc()
	{
		if (!petrolTank.petrolFull)
		{
			petrolTank.uiCanvas.SetActive(value: true);
			petrolTank.petrolTankDoor.ChangeInteractableStatus(change: true);
		}
		howMayIHelpBtn.SetActive(value: false);
	}

	protected static void InvokeUserCode_InteractWithNPCRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC InteractWithNPCRpc called on server.");
		}
		else
		{
			((Car)obj).UserCode_InteractWithNPCRpc();
		}
	}

	static Car()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(Car), "System.Void Car::CarDoneCmd()", InvokeUserCode_CarDoneCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Car), "System.Void Car::CarUnlockCmd()", InvokeUserCode_CarUnlockCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Car), "System.Void Car::CarFadeAwayCmd()", InvokeUserCode_CarFadeAwayCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(Car), "System.Void Car::InteractWithNPCCmd()", InvokeUserCode_InteractWithNPCCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(Car), "System.Void Car::CarDoneRpc()", InvokeUserCode_CarDoneRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Car), "System.Void Car::CarUnlockRpc()", InvokeUserCode_CarUnlockRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Car), "System.Void Car::CarFadeAwayRpc()", InvokeUserCode_CarFadeAwayRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(Car), "System.Void Car::InteractWithNPCRpc()", InvokeUserCode_InteractWithNPCRpc);
	}
}
