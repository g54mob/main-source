using Mirror;
using Mirror.RemoteCalls;
using OutlineFx;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IDCard : Interactable
{
	public bool carInspectable;

	public GameObject newCam;

	public new PlayerManager curPlayerMan;

	private bool interacting;

	public Image icon;

	public Image signature;

	public TextMeshProUGUI nameText;

	public string dbName;

	public AudioSource inspectSFX;

	public Animator idPromptAnim;

	public GameObject checkComputerPrompt;

	public bool actualIDCard;

	public GameObject tutorial;

	public UnityEvent stopInteractEvent;

	public GameObject fakeID;

	public bool allPlayersMustLookAt;

	public float extraTimeBeforeFirstOccurrence = 0.1f;

	public AudioSource scanSfx;

	private bool alreadyLookedAt;

	public int amountOfLookAts;

	public override void Interact(PlayerManager playerMan)
	{
		if (carInspectable)
		{
			StoreManager.Instance.FlashlightToggled(1);
		}
		if (onlyInvokeEventLocally)
		{
			interactEvent.Invoke();
		}
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: false);
		}
		StopLookAt();
		ClientPlayer.Instance.playerMan.dontAllowLockCursor = true;
		if (base.isServer)
		{
			ActuallyInteract(playerMan);
		}
		else
		{
			InteractCmd(playerMan);
		}
	}

	[Command(requiresAuthority = false)]
	public override void InteractCmd(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendCommandInternal("System.Void IDCard::InteractCmd(PlayerManager)", -1806193178, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public override void ActuallyInteract(PlayerManager playerMan)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteNetworkBehaviour(playerMan);
		SendRPCInternal("System.Void IDCard::ActuallyInteract(PlayerManager)", -375267793, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayScanSFX()
	{
		DialogueTutorialManager.Instance.ScannedID();
		if (base.isServer)
		{
			PlayScanSFXRpc();
		}
		else
		{
			PlayScanSFXCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void PlayScanSFXCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void IDCard::PlayScanSFXCmd()", 75616034, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PlayScanSFXRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void IDCard::PlayScanSFXRpc()", -2081794971, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void PlayerLookAt()
	{
		GameObject.FindGameObjectsWithTag("Player");
		if (!alreadyLookedAt)
		{
			alreadyLookedAt = true;
			if (base.isServer)
			{
				AnotherPlayerLookAtRpc_();
				InvokeRepeating("CheckWhosLookAt", 1f, 1f);
			}
			else
			{
				AnotherPlayerLookAtCmd_();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void AnotherPlayerLookAtCmd_()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void IDCard::AnotherPlayerLookAtCmd_()", -956720197, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AnotherPlayerLookAtRpc_()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void IDCard::AnotherPlayerLookAtRpc_()", -1187083518, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CheckWhosLookAt()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		if (amountOfLookAts >= array.Length)
		{
			CancelInvoke("CheckWhosLookAt");
			StoreManager.Instance.FinishObjective();
			CurrentDayManager.Instance.Invoke("PlayNextOccurence", extraTimeBeforeFirstOccurrence);
		}
		StoreManager.Instance.amountToLookAtObjectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		StoreManager.Instance.amountToLookAtObjectiveText.text = "( " + amountOfLookAts + " / " + array.Length + " )";
	}

	public void CheckIfFakeID()
	{
		if (actualIDCard && fakeID.activeInHierarchy)
		{
			StoreManager.Instance.AddHint("Use the Computer to SEARCH names.");
			StoreManager.Instance.NextHint();
		}
	}

	public void ScanID()
	{
		StopInteract();
		StoreManager.Instance.SetAlert("Scanned successfully.", "green");
		Computer.Instance.ClickResult(dbName);
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			Invoke("CheckComputerHint", 0.5f);
		}
	}

	[Command(requiresAuthority = false)]
	private void ScanIDToComputerCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void IDCard::ScanIDToComputerCmd()", -1723571962, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ScanIDToComputerRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void IDCard::ScanIDToComputerRpc()", 1897407801, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void FinishObjective()
	{
		StoreManager.Instance.FinishObjective();
	}

	public void StopInteract()
	{
		if ((bool)curPlayerMan)
		{
			if ((bool)StoreManager.Instance.dialogueTutorialCanv)
			{
				StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
			}
			ClientPlayer.Instance.playerMan.dontAllowLockCursor = false;
			stopInteractEvent.Invoke();
			if (actualIDCard)
			{
				tutorial.SetActive(value: false);
			}
			if (carInspectable)
			{
				StoreManager.Instance.FlashlightToggled(-1);
			}
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: true);
			}
			else
			{
				ChangeInteractableStatusCmd(change: true);
			}
			newCam.SetActive(value: false);
			if (!curPlayerMan.dontAllowLockCursor && !curPlayerMan.lookingAtShelf && !curPlayerMan.lookingAtComputer && !curPlayerMan.paused)
			{
				curPlayerMan.Invoke("TurnPauseBackOn", 0.1f);
				curPlayerMan.fpsScript.playerCamera.gameObject.SetActive(value: true);
				curPlayerMan.fpsScript.lockMove = false;
				curPlayerMan.fpsScript.lockCam = false;
				curPlayerMan.fpsScript.LockCursor();
			}
			interacting = false;
		}
	}

	public void LogCheckedID()
	{
		PlayerPrefs.SetInt("CheckedID", 1);
	}

	private void CheckComputerHint()
	{
		StoreManager.Instance.AddHint("Now check the computer.");
		StoreManager.Instance.NextHint();
	}

	public void PayAttentionHint()
	{
		StoreManager.Instance.AddHint("Pay attention to info you are given at the start of the day.");
		StoreManager.Instance.NextHint();
	}

	private void Update()
	{
		if (interacting && Input.GetKeyDown(KeyCode.Escape))
		{
			StopInteract();
		}
	}

	public void FinishObjectives()
	{
		TutorialManager.Instance.FinishObjective();
	}

	public void FinishTutorial()
	{
		TutorialManager.Instance.FinishTutorial();
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
			((IDCard)obj).UserCode_InteractCmd__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected override void UserCode_ActuallyInteract__PlayerManager(PlayerManager playerMan)
	{
		if (!interactable || playerMan != ClientPlayer.Instance.playerMan)
		{
			return;
		}
		CheckIfFakeID();
		if (interactSFX != null)
		{
			interactSFX.Play();
		}
		if (interactAnim != null)
		{
			interactAnim.SetTrigger("Interact");
		}
		if (!onlyInvokeEventLocally)
		{
			interactEvent.Invoke();
		}
		if (useInteractCooldown)
		{
			global::OutlineFx.OutlineFx[] array = outlines;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].enabled = false;
			}
			Invoke("CanInteract", interactCooldown);
		}
		playerMan.canPause = false;
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		StopLookAt();
		newCam.SetActive(value: true);
		curPlayerMan = playerMan;
		playerMan.fpsScript.lockMove = true;
		playerMan.fpsScript.lockCam = true;
		curPlayerMan.fpsScript.UnlockCursor();
		interacting = true;
		inspectSFX.Play();
		if (idPromptAnim != null)
		{
			idPromptAnim.SetTrigger("Normal");
		}
		if (actualIDCard && CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2 && (bool)tutorial)
		{
			StoreManager.Instance.NextHint();
			tutorial.SetActive(value: true);
			PlayerPrefs.SetInt("AskQuestion4", 1);
		}
		else if ((bool)tutorial)
		{
			tutorial.SetActive(value: false);
		}
		StopLookAt();
	}

	protected new static void InvokeUserCode_ActuallyInteract__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ActuallyInteract called on server.");
		}
		else
		{
			((IDCard)obj).UserCode_ActuallyInteract__PlayerManager(reader.ReadNetworkBehaviour<PlayerManager>());
		}
	}

	protected void UserCode_PlayScanSFXCmd()
	{
		PlayScanSFXRpc();
	}

	protected static void InvokeUserCode_PlayScanSFXCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PlayScanSFXCmd called on client.");
		}
		else
		{
			((IDCard)obj).UserCode_PlayScanSFXCmd();
		}
	}

	protected void UserCode_PlayScanSFXRpc()
	{
		scanSfx.Play();
	}

	protected static void InvokeUserCode_PlayScanSFXRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PlayScanSFXRpc called on server.");
		}
		else
		{
			((IDCard)obj).UserCode_PlayScanSFXRpc();
		}
	}

	protected void UserCode_AnotherPlayerLookAtCmd_()
	{
		AnotherPlayerLookAtRpc_();
	}

	protected static void InvokeUserCode_AnotherPlayerLookAtCmd_(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AnotherPlayerLookAtCmd_ called on client.");
		}
		else
		{
			((IDCard)obj).UserCode_AnotherPlayerLookAtCmd_();
		}
	}

	protected void UserCode_AnotherPlayerLookAtRpc_()
	{
		amountOfLookAts++;
		InvokeRepeating("CheckWhosLookAt", 0.5f, 1f);
	}

	protected static void InvokeUserCode_AnotherPlayerLookAtRpc_(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AnotherPlayerLookAtRpc_ called on server.");
		}
		else
		{
			((IDCard)obj).UserCode_AnotherPlayerLookAtRpc_();
		}
	}

	protected void UserCode_ScanIDToComputerCmd()
	{
		ScanIDToComputerRpc();
	}

	protected static void InvokeUserCode_ScanIDToComputerCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ScanIDToComputerCmd called on client.");
		}
		else
		{
			((IDCard)obj).UserCode_ScanIDToComputerCmd();
		}
	}

	protected void UserCode_ScanIDToComputerRpc()
	{
		StoreManager.Instance.SetAlert("Scanned successfully.", "green");
		Computer.Instance.ClickResult(dbName);
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			Invoke("CheckComputerHint", 0.5f);
		}
	}

	protected static void InvokeUserCode_ScanIDToComputerRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ScanIDToComputerRpc called on server.");
		}
		else
		{
			((IDCard)obj).UserCode_ScanIDToComputerRpc();
		}
	}

	static IDCard()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(IDCard), "System.Void IDCard::InteractCmd(PlayerManager)", InvokeUserCode_InteractCmd__PlayerManager, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(IDCard), "System.Void IDCard::PlayScanSFXCmd()", InvokeUserCode_PlayScanSFXCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(IDCard), "System.Void IDCard::AnotherPlayerLookAtCmd_()", InvokeUserCode_AnotherPlayerLookAtCmd_, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(IDCard), "System.Void IDCard::ScanIDToComputerCmd()", InvokeUserCode_ScanIDToComputerCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(IDCard), "System.Void IDCard::ActuallyInteract(PlayerManager)", InvokeUserCode_ActuallyInteract__PlayerManager);
		RemoteProcedureCalls.RegisterRpc(typeof(IDCard), "System.Void IDCard::PlayScanSFXRpc()", InvokeUserCode_PlayScanSFXRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(IDCard), "System.Void IDCard::AnotherPlayerLookAtRpc_()", InvokeUserCode_AnotherPlayerLookAtRpc_);
		RemoteProcedureCalls.RegisterRpc(typeof(IDCard), "System.Void IDCard::ScanIDToComputerRpc()", InvokeUserCode_ScanIDToComputerRpc);
	}
}
