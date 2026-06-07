using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using SteamLobbyTutorial;
using Steamworks;
using TMPro;
using UnityEngine;

public class DialogueInteractable : Interactable
{
	public Transform player;

	public float rotationSpeed = 5f;

	public float angleThreshold = 1f;

	public Transform head;

	public bool initialInteraction;

	public float initialInteractionSpeakTime;

	public string dialogueId;

	public GameObject dialogueOptionsCanvas;

	public StoreBrowseBehaviour pathfindScript;

	private bool cantExitDialogue;

	public Animator mouthAnim;

	public bool askedQuestion;

	public string playerName;

	public string[] forceDialogue;

	public bool replaceInitialDialogueWithForced;

	public bool dontDoInitialDialogue;

	public int timesToNotExitDialogue;

	public bool interacting;

	public bool faceNearestPlayerAfterTalking;

	public bool faceNearestPlayer;

	public bool takesNameOfRandomPlayer;

	public TextMeshProUGUI nameTag;

	public AudioSource dialoguePickSFX;

	public SkinnedMeshRenderer shirt;

	public Material[] shirtColors;

	public bool inQuestioningMenu;

	public bool cantBeAskedAboutMood;

	public bool setNameToRandomSteamUser;

	public bool cantEscapeToExit;

	public bool canOnlyInteractOnce;

	public float timeBeforeInteractionShowsUp;

	public bool questionAfterInitialInteraction;

	public GameObject questionCanvas;

	private bool askedCanvasQuestion;

	private bool firstTimeExitDialogue = true;

	public Transform target;

	public bool onlyLookAtWithHead;

	public Transform headPivot;

	public override void Start()
	{
		base.Start();
		if (base.isServer && setNameToRandomSteamUser)
		{
			SetNameRpc(GetRandomSteamUsernameFromLobby());
		}
		if ((bool)pathfindScript && pathfindScript.addToReport)
		{
			EODReportValues.Instance.npcID.Add(int.Parse(dialogueId));
		}
	}

	[ClientRpc]
	private void SetNameRpc(string name)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(name);
		SendRPCInternal("System.Void DialogueInteractable::SetNameRpc(System.String)", 1746126061, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SetColor()
	{
		if (ClientPlayer.Instance.isServer)
		{
			SetColorRpc(PlayerPrefs.GetInt("ShirtColor", 1));
		}
		else
		{
			SetColorCmd(PlayerPrefs.GetInt("ShirtColor", 1));
		}
	}

	[Command(requiresAuthority = false)]
	public void SetColorCmd(int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(colorIndex);
		SendCommandInternal("System.Void DialogueInteractable::SetColorCmd(System.Int32)", 1337290419, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void SetColorRpc(int colorIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(colorIndex);
		SendRPCInternal("System.Void DialogueInteractable::SetColorRpc(System.Int32)", -973443728, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public static string GetRandomSteamUsernameFromLobby()
	{
		if (!SteamManager.Initialized || SteamLobby.Instance == null)
		{
			Debug.LogWarning("Steam not initialized or SteamLobby instance missing.");
			return null;
		}
		ulong lobbyID = SteamLobby.Instance.lobbyID;
		if (lobbyID == 0L)
		{
			Debug.LogWarning("No active Steam lobby.");
			return null;
		}
		CSteamID steamIDLobby = new CSteamID(lobbyID);
		int numLobbyMembers = SteamMatchmaking.GetNumLobbyMembers(steamIDLobby);
		if (numLobbyMembers <= 0)
		{
			Debug.LogWarning("No players in lobby.");
			return null;
		}
		int iMember = Random.Range(0, numLobbyMembers);
		return SteamFriends.GetFriendPersonaName(SteamMatchmaking.GetLobbyMemberByIndex(steamIDLobby, iMember));
	}

	public void InitialDialogue(bool onlyClientSide)
	{
		SpeakingManager.Instance.NewDialogueBranch(dialogueId, "Greeting", null, this, onlyClientSide);
		if ((bool)mouthAnim)
		{
			mouthAnim.SetBool("Talking", value: true);
		}
		Invoke("StopMouth", initialInteractionSpeakTime);
		curPlayerMan = ClientPlayer.Instance.playerMan;
		curPlayerMan.canPause = false;
	}

	private void InitialDialogueClientSide()
	{
		InitialDialogue(onlyClientSide: false);
	}

	public override void Interact(PlayerManager playerMan)
	{
		if (!interactable)
		{
			return;
		}
		playerMan.curNpcScript = this;
		inQuestioningMenu = true;
		if ((bool)StoreManager.Instance.dialogueTutorialCanv)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: false);
		}
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		interacting = true;
		if (canOnlyInteractOnce)
		{
			Invoke("InitialDialogueClientSide", timeBeforeInteractionShowsUp);
		}
		else
		{
			InitialDialogue(onlyClientSide: true);
		}
		playerMan.canPause = false;
		curPlayerMan = playerMan;
		askedQuestion = false;
		if (dialogueOptionsCanvas != null)
		{
			TurnOnDialogueOptions();
		}
		if (pathfindScript != null)
		{
			pathfindScript.ChangeSpeed(0f);
		}
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		player = playerMan.transform;
		playerMan.fpsScript.lockMove = true;
		playerMan.fpsScript.lockCam = true;
		playerMan.fpsScript.lookAtState = true;
		playerMan.fpsScript.objectToLookAt = head;
		playerMan.fpsScript.UnlockCursor();
		base.Interact(playerMan);
		base.StopLookAt();
		StartLerpLookAtTarget(ClientPlayer.Instance.transform);
		pathfindScript.TriggerAnim(pathfindScript.idleAnim);
		if (PlayerPrefs.GetInt("AskQuestion3") != 1 && PlayerPrefs.GetInt("FirstTimeCompletingTransaction", 0) != 1)
		{
			StoreManager.Instance.NextHint();
			PlayerPrefs.SetInt("AskQuestion3", 1);
		}
		if (canOnlyInteractOnce)
		{
			if (base.isServer)
			{
				ChangeInteractableStatusRpc(change: false);
			}
			else
			{
				ChangeInteractableStatusCmd(change: false);
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void StartLerpLookAtTarget(Transform target)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(target);
		SendCommandInternal("System.Void DialogueInteractable::StartLerpLookAtTarget(UnityEngine.Transform)", 1038018682, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void StartLerpLookAtTargetRpc(Transform target_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteTransform(target_);
		SendRPCInternal("System.Void DialogueInteractable::StartLerpLookAtTargetRpc(UnityEngine.Transform)", -355851709, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void StopMouth()
	{
		if (!askedQuestion && (bool)mouthAnim)
		{
			mouthAnim.SetBool("Talking", value: false);
		}
	}

	public void ExitInteraction()
	{
		inQuestioningMenu = false;
		SpeakingManager.Instance.CancelAllDialogue();
	}

	private void OnDisable()
	{
		ExitDialogue();
		SpeakingManager.Instance.CancelAllDialogue();
	}

	public void ForceTalkToPlayer()
	{
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		curPlayerMan = ClientPlayer.Instance.playerMan;
		SpeakingManager.Instance.NewDialogueBranch(dialogueId, "Forced Greeting", null, this);
		float num = 0f;
		string[] array = forceDialogue;
		foreach (string text in array)
		{
			num += (float)text.Length * 0.02f;
			num += 1.8f;
		}
		if (pathfindScript.forceTalkAtVeryStart)
		{
			pathfindScript.Invoke("FinishedStartForceTalk", num);
		}
		curPlayerMan.canPause = false;
		askedQuestion = false;
		if (pathfindScript != null)
		{
			pathfindScript.pathfinder.maxSpeed = 0f;
		}
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		player = curPlayerMan.transform;
		curPlayerMan.fpsScript.lockMove = true;
		curPlayerMan.fpsScript.lockCam = true;
		curPlayerMan.fpsScript.lookAtState = true;
		curPlayerMan.fpsScript.objectToLookAt = head;
		base.StopLookAt();
		StartLerpLookAtTarget(ClientPlayer.Instance.transform);
		pathfindScript.TriggerAnim(pathfindScript.idleAnim);
	}

	public void CanPauseAgain()
	{
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		CancelInvoke("CantPause");
		ClientPlayer.Instance.playerMan.canPause = false;
	}

	public void AskQuestion(string question)
	{
		if ((bool)questionCanvas)
		{
			questionCanvas.SetActive(value: false);
		}
		inQuestioningMenu = false;
		DialogueTutorialManager.Instance.QuestionedAppearance();
		SpeakingManager.Instance.CancelAllDialogue();
		dialogueOptionsCanvas.SetActive(value: false);
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			ExitDialogue();
			StoreManager.Instance.outOfQuestions.SetActive(value: false);
			StoreManager.Instance.outOfQuestions.SetActive(value: true);
			StoreManager.Instance.SetExaminationsRemaining(0);
			return;
		}
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			StoreManager.Instance.SetExaminationsRemaining(StoreManager.Instance.examinationsRemaining - 1);
		}
		if ((bool)pathfindScript && pathfindScript.isThief && question == "Reject" && !pathfindScript.doesntGiveBackItems)
		{
			StoreManager.Instance.Invoke("ThiefCaught", 1f);
			pathfindScript.ChangeHasStolenItems(change: false);
		}
		dialoguePickSFX.Play();
		askedQuestion = true;
		SpeakingManager.Instance.NewDialogueBranch(dialogueId, question, null, this);
		StartLerpLookAtTarget(ClientPlayer.Instance.transform);
		interacting = false;
	}

	public void DisableInteract()
	{
	}

	private void Update()
	{
		if (interacting && !cantEscapeToExit && Input.GetKeyDown(KeyCode.Escape) && inQuestioningMenu)
		{
			ExitDialogue();
			ExitInteraction();
			dialogueOptionsCanvas.SetActive(value: false);
		}
		if (faceNearestPlayer)
		{
			Vector3 forward = target.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * rotationSpeed);
		}
	}

	private void SetTargetToNearestPlayer()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		float num = 10000f;
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			float num2 = Vector3.Distance(base.transform.position, gameObject.transform.position);
			if (num2 < num)
			{
				target = gameObject.transform;
				num = num2;
			}
		}
		Invoke("SetTargetToNearestPlayer", 3f);
	}

	public void EnterDialogue()
	{
		inQuestioningMenu = false;
		curPlayerMan = ClientPlayer.Instance.playerMan;
		SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
		curPlayerMan.canPause = false;
		askedQuestion = false;
		if (pathfindScript != null)
		{
			pathfindScript.pathfinder.maxSpeed = 0f;
		}
		ClientPlayer.Instance.inventoryMan.PauseUseItem();
		player = curPlayerMan.transform;
		curPlayerMan.fpsScript.lockMove = true;
		curPlayerMan.fpsScript.lockCam = true;
		curPlayerMan.fpsScript.lookAtState = true;
		curPlayerMan.fpsScript.objectToLookAt = head;
		base.Interact(curPlayerMan);
		base.StopLookAt();
		StartLerpLookAtTarget(ClientPlayer.Instance.transform);
		pathfindScript.TriggerAnim(pathfindScript.idleAnim);
	}

	[Command(requiresAuthority = false)]
	private void AskedCanvasQuestionCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DialogueInteractable::AskedCanvasQuestionCmd()", 35646167, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AskedCanvasQuestionRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DialogueInteractable::AskedCanvasQuestionRpc()", 495256628, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void ActuallyPersonallyExitDialogue()
	{
		if (!firstTimeExitDialogue)
		{
			return;
		}
		firstTimeExitDialogue = false;
		if (questionAfterInitialInteraction && !askedCanvasQuestion)
		{
			inQuestioningMenu = true;
			ClientPlayer.Instance.inventoryMan.PauseUseItem();
			ClientPlayer.Instance.fpsScript.lockMove = true;
			ClientPlayer.Instance.fpsScript.lockCam = true;
			ClientPlayer.Instance.fpsScript.lookAtState = true;
			ClientPlayer.Instance.fpsScript.objectToLookAt = head;
			ClientPlayer.Instance.fpsScript.UnlockCursor();
			base.Interact(ClientPlayer.Instance.playerMan);
			base.StopLookAt();
			SpeakingManager.Instance.chatLogHolder.SetActive(value: false);
			questionCanvas.SetActive(value: true);
			askedCanvasQuestion = true;
			if (base.isServer)
			{
				AskedCanvasQuestionRpc();
			}
			else
			{
				AskedCanvasQuestionCmd();
			}
			ChangeInteractableStatus(change: false);
			ClientPlayer.Instance.playerMan.canPause = false;
			Invoke("CantPause", 0.1f);
			Invoke("CantPause", 0.2f);
			Invoke("CantPause", 0.3f);
			Invoke("CantPause", 0.4f);
			Invoke("CantPause", 0.5f);
			Invoke("CantPause", 0.6f);
			Invoke("CantPause", 0.7f);
		}
	}

	private void CantPause()
	{
		ClientPlayer.Instance.playerMan.canPause = false;
	}

	public void ExitDialogue()
	{
		if ((bool)questionCanvas)
		{
			questionCanvas.SetActive(value: false);
		}
		inQuestioningMenu = false;
		SpeakingManager.Instance.CancelAllDialogue();
		SpeakingManager.Instance.chatLogHolder.SetActive(value: true);
		if ((bool)StoreManager.Instance.dialogueTutorialCanv && !ClientPlayer.Instance.playerMan.paused && !ClientPlayer.Instance.playerMan.lookingAtComputer && !ClientPlayer.Instance.playerMan.lookingAtShelf)
		{
			StoreManager.Instance.dialogueTutorialCanv.SetActive(value: true);
		}
		if (!curPlayerMan)
		{
			return;
		}
		if (pathfindScript != null)
		{
			if (!pathfindScript.canNeverInteract)
			{
				if (base.isServer)
				{
					ChangeInteractableStatusRpc(change: true);
				}
				else
				{
					ChangeInteractableStatusCmd(change: true);
				}
			}
			if (canOnlyInteractOnce)
			{
				pathfindScript.TurnOffInteractable();
			}
			pathfindScript.RevertToCurSpeed();
			if (pathfindScript.isThief)
			{
				pathfindScript.TriggerAnim(pathfindScript.walkAnim);
			}
		}
		else if (base.isServer)
		{
			ChangeInteractableStatusRpc(change: true);
		}
		else
		{
			ChangeInteractableStatusCmd(change: true);
		}
		curPlayerMan = ClientPlayer.Instance.playerMan;
		if (!curPlayerMan.dontAllowLockCursor && !curPlayerMan.lookingAtShelf && !curPlayerMan.lookingAtComputer && !curPlayerMan.paused)
		{
			curPlayerMan.fpsScript.LockCursor();
			curPlayerMan.Invoke("TurnPauseBackOn", 0.1f);
			curPlayerMan.fpsScript.lockMove = false;
			curPlayerMan.fpsScript.lockCam = false;
			curPlayerMan.fpsScript.lookAtState = false;
			curPlayerMan.fpsScript.objectToLookAt = head;
		}
		CancelInvoke("TurnOnDialogueOptions");
		dialogueOptionsCanvas.SetActive(value: false);
		StopMouth();
	}

	private void TurnOnDialogueOptions()
	{
		dialogueOptionsCanvas.SetActive(value: true);
	}

	private IEnumerator LerpLookAtTarget()
	{
		float elapsedTime = 0f;
		while (elapsedTime < 1f)
		{
			Vector3 forward = target.position - base.transform.position;
			forward.y = 0f;
			Quaternion b = Quaternion.LookRotation(forward);
			if (onlyLookAtWithHead)
			{
				headPivot.rotation = Quaternion.Lerp(headPivot.rotation, b, Time.deltaTime * rotationSpeed);
			}
			else
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * rotationSpeed);
			}
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_SetNameRpc__String(string name)
	{
		playerName = name;
		if ((bool)nameTag)
		{
			nameTag.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			nameTag.text = name;
		}
		if (name == SteamFriends.GetPersonaName())
		{
			SetColor();
		}
	}

	protected static void InvokeUserCode_SetNameRpc__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetNameRpc called on server.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_SetNameRpc__String(reader.ReadString());
		}
	}

	protected void UserCode_SetColorCmd__Int32(int colorIndex)
	{
		SetColorRpc(colorIndex);
	}

	protected static void InvokeUserCode_SetColorCmd__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command SetColorCmd called on client.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_SetColorCmd__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_SetColorRpc__Int32(int colorIndex)
	{
		Material[] materials = shirt.materials;
		materials[0] = shirtColors[colorIndex];
		shirt.materials = materials;
	}

	protected static void InvokeUserCode_SetColorRpc__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SetColorRpc called on server.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_SetColorRpc__Int32(reader.ReadVarInt());
		}
	}

	protected void UserCode_StartLerpLookAtTarget__Transform(Transform target)
	{
		StartLerpLookAtTargetRpc(target);
	}

	protected static void InvokeUserCode_StartLerpLookAtTarget__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command StartLerpLookAtTarget called on client.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_StartLerpLookAtTarget__Transform(reader.ReadTransform());
		}
	}

	protected void UserCode_StartLerpLookAtTargetRpc__Transform(Transform target_)
	{
		target = target_;
		if (faceNearestPlayerAfterTalking)
		{
			SetTargetToNearestPlayer();
			faceNearestPlayer = true;
		}
		else
		{
			StartCoroutine(LerpLookAtTarget());
		}
	}

	protected static void InvokeUserCode_StartLerpLookAtTargetRpc__Transform(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC StartLerpLookAtTargetRpc called on server.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_StartLerpLookAtTargetRpc__Transform(reader.ReadTransform());
		}
	}

	protected void UserCode_AskedCanvasQuestionCmd()
	{
		AskedCanvasQuestionRpc();
	}

	protected static void InvokeUserCode_AskedCanvasQuestionCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AskedCanvasQuestionCmd called on client.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_AskedCanvasQuestionCmd();
		}
	}

	protected void UserCode_AskedCanvasQuestionRpc()
	{
		askedCanvasQuestion = true;
	}

	protected static void InvokeUserCode_AskedCanvasQuestionRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AskedCanvasQuestionRpc called on server.");
		}
		else
		{
			((DialogueInteractable)obj).UserCode_AskedCanvasQuestionRpc();
		}
	}

	static DialogueInteractable()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueInteractable), "System.Void DialogueInteractable::SetColorCmd(System.Int32)", InvokeUserCode_SetColorCmd__Int32, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueInteractable), "System.Void DialogueInteractable::StartLerpLookAtTarget(UnityEngine.Transform)", InvokeUserCode_StartLerpLookAtTarget__Transform, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueInteractable), "System.Void DialogueInteractable::AskedCanvasQuestionCmd()", InvokeUserCode_AskedCanvasQuestionCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueInteractable), "System.Void DialogueInteractable::SetNameRpc(System.String)", InvokeUserCode_SetNameRpc__String);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueInteractable), "System.Void DialogueInteractable::SetColorRpc(System.Int32)", InvokeUserCode_SetColorRpc__Int32);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueInteractable), "System.Void DialogueInteractable::StartLerpLookAtTargetRpc(UnityEngine.Transform)", InvokeUserCode_StartLerpLookAtTargetRpc__Transform);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueInteractable), "System.Void DialogueInteractable::AskedCanvasQuestionRpc()", InvokeUserCode_AskedCanvasQuestionRpc);
	}
}
