using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTutorialManager : NetworkBehaviour
{
	public bool alreadyDone;

	public Image scannedID;

	public Image questionedOccupation;

	public Image questionedAppearance;

	public Sprite tickedCheckbox;

	public bool scannedID_;

	public bool questionedOccupation_;

	public bool questionedAppearance_;

	public GameObject canvas;

	public bool alreadyToldAboutGun;

	public int amountOfObjectivesDone;

	public TextMeshProUGUI amountCompleted;

	public static DialogueTutorialManager Instance { get; private set; }

	public void CompletedTransaction()
	{
		canvas.SetActive(value: false);
		if (!alreadyToldAboutGun && CurrentDayManager.Instance.curDay <= 1)
		{
			alreadyToldAboutGun = true;
			Invoke("GunUnlocked", 1f);
		}
	}

	private void GunUnlocked()
	{
		StoreManager.Instance.SetAlert("Gun Unlocked!", "green");
	}

	private void CheckIfAllObjectivesDone()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		if (amountOfObjectivesDone >= array.Length * 3)
		{
			alreadyDone = true;
			TransactionManager.Instance.canTransact = true;
		}
		int num = amountOfObjectivesDone / 3;
		if (num > 0)
		{
			amountCompleted.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			amountCompleted.text = JSONAccess.Instance.GetMiscText("UI Text 3", "Players Done") + " " + num + " / " + array.Length;
		}
	}

	public void ScannedID()
	{
		if (!scannedID_)
		{
			scannedID_ = true;
			scannedID.sprite = tickedCheckbox;
			if (base.isServer)
			{
				ScannedIDRpc();
			}
			else
			{
				ScannedIDCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void ScannedIDCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DialogueTutorialManager::ScannedIDCmd()", 1261762447, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void ScannedIDRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DialogueTutorialManager::ScannedIDRpc()", 1152966652, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void QuestionedOccupation()
	{
		if (!questionedOccupation_)
		{
			questionedOccupation_ = true;
			questionedOccupation.sprite = tickedCheckbox;
			if (base.isServer)
			{
				QuestionedOccupationRpc();
			}
			else
			{
				QuestionedOccupationCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void QuestionedOccupationCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DialogueTutorialManager::QuestionedOccupationCmd()", -782091896, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void QuestionedOccupationRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DialogueTutorialManager::QuestionedOccupationRpc()", -466917073, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void QuestionedAppearance()
	{
		if (!questionedAppearance_)
		{
			questionedAppearance_ = true;
			questionedAppearance.sprite = tickedCheckbox;
			if (base.isServer)
			{
				QuestionedAppearanceRpc();
			}
			else
			{
				QuestionedAppearanceCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	public void QuestionedAppearanceCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void DialogueTutorialManager::QuestionedAppearanceCmd()", 1556045659, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	public void QuestionedAppearanceRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void DialogueTutorialManager::QuestionedAppearanceRpc()", 183682072, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ScannedIDCmd()
	{
		ScannedIDRpc();
	}

	protected static void InvokeUserCode_ScannedIDCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ScannedIDCmd called on client.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_ScannedIDCmd();
		}
	}

	protected void UserCode_ScannedIDRpc()
	{
		amountOfObjectivesDone++;
		CheckIfAllObjectivesDone();
	}

	protected static void InvokeUserCode_ScannedIDRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ScannedIDRpc called on server.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_ScannedIDRpc();
		}
	}

	protected void UserCode_QuestionedOccupationCmd()
	{
		QuestionedOccupationRpc();
	}

	protected static void InvokeUserCode_QuestionedOccupationCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command QuestionedOccupationCmd called on client.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_QuestionedOccupationCmd();
		}
	}

	protected void UserCode_QuestionedOccupationRpc()
	{
		amountOfObjectivesDone++;
		CheckIfAllObjectivesDone();
	}

	protected static void InvokeUserCode_QuestionedOccupationRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC QuestionedOccupationRpc called on server.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_QuestionedOccupationRpc();
		}
	}

	protected void UserCode_QuestionedAppearanceCmd()
	{
		QuestionedAppearanceRpc();
	}

	protected static void InvokeUserCode_QuestionedAppearanceCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command QuestionedAppearanceCmd called on client.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_QuestionedAppearanceCmd();
		}
	}

	protected void UserCode_QuestionedAppearanceRpc()
	{
		amountOfObjectivesDone++;
		CheckIfAllObjectivesDone();
	}

	protected static void InvokeUserCode_QuestionedAppearanceRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC QuestionedAppearanceRpc called on server.");
		}
		else
		{
			((DialogueTutorialManager)obj).UserCode_QuestionedAppearanceRpc();
		}
	}

	static DialogueTutorialManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::ScannedIDCmd()", InvokeUserCode_ScannedIDCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::QuestionedOccupationCmd()", InvokeUserCode_QuestionedOccupationCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterCommand(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::QuestionedAppearanceCmd()", InvokeUserCode_QuestionedAppearanceCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::ScannedIDRpc()", InvokeUserCode_ScannedIDRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::QuestionedOccupationRpc()", InvokeUserCode_QuestionedOccupationRpc);
		RemoteProcedureCalls.RegisterRpc(typeof(DialogueTutorialManager), "System.Void DialogueTutorialManager::QuestionedAppearanceRpc()", InvokeUserCode_QuestionedAppearanceRpc);
	}
}
