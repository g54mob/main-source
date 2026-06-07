using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetrolTank : NetworkBehaviour
{
	public Image filledBar;

	public TextMeshProUGUI moneyText;

	public TextMeshProUGUI filledMoneyText;

	public AudioSource petrolFillSfx;

	private float curMoneySpent;

	public float maxMoneySpent;

	private bool pumping;

	public GameObject petrolFullSfx;

	public Interactable petrolTankDoor;

	public Animator petrolTankDoorAnim;

	public GameObject leaveDialogueOption;

	public GameObject uiCanvas;

	public GameObject beforeUI;

	public GameObject afterUI;

	public bool petrolFull;

	private void Start()
	{
		filledMoneyText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		filledMoneyText.text = JSONAccess.Instance.GetMiscText("UI Text 4", "FILL TO") + " $" + maxMoneySpent;
	}

	public void PetrolPumped()
	{
		if (base.isServer)
		{
			PetrolPumpedRpc();
		}
		else
		{
			PetrolPumpedCmd();
		}
	}

	[Command(requiresAuthority = false)]
	private void PetrolPumpedCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void PetrolTank::PetrolPumpedCmd()", -1190840642, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void PetrolPumpedRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void PetrolTank::PetrolPumpedRpc()", -728412991, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void StopPumping()
	{
		pumping = false;
	}

	private void FixedUpdate()
	{
		if (pumping)
		{
			petrolFillSfx.volume = Mathf.Lerp(petrolFillSfx.volume, 0.6f, Time.deltaTime);
		}
		else
		{
			petrolFillSfx.volume = Mathf.Lerp(petrolFillSfx.volume, 0f, Time.deltaTime * 10f);
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_PetrolPumpedCmd()
	{
		PetrolPumpedRpc();
	}

	protected static void InvokeUserCode_PetrolPumpedCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command PetrolPumpedCmd called on client.");
		}
		else
		{
			((PetrolTank)obj).UserCode_PetrolPumpedCmd();
		}
	}

	protected void UserCode_PetrolPumpedRpc()
	{
		if (!petrolFull)
		{
			if (curMoneySpent >= maxMoneySpent)
			{
				StoreManager.Instance.AddHint("If the driver checks out as human, tell them to leave.");
				StoreManager.Instance.NextHint();
				beforeUI.SetActive(value: false);
				afterUI.SetActive(value: true);
				leaveDialogueOption.SetActive(value: true);
				petrolTankDoor.ChangeInteractableStatus(change: false);
				petrolTankDoorAnim.SetTrigger("Close");
				petrolFillSfx.volume = 0f;
				pumping = false;
				petrolFull = true;
				curMoneySpent = maxMoneySpent;
				petrolFullSfx.SetActive(value: true);
			}
			else
			{
				pumping = true;
				CancelInvoke("StopPumping");
				Invoke("StopPumping", 0.3f);
				curMoneySpent += 0.1f;
				moneyText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
				moneyText.text = "$" + Mathf.Abs(curMoneySpent).ToString("0.00");
				filledBar.fillAmount = curMoneySpent / maxMoneySpent;
			}
		}
	}

	protected static void InvokeUserCode_PetrolPumpedRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC PetrolPumpedRpc called on server.");
		}
		else
		{
			((PetrolTank)obj).UserCode_PetrolPumpedRpc();
		}
	}

	static PetrolTank()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(PetrolTank), "System.Void PetrolTank::PetrolPumpedCmd()", InvokeUserCode_PetrolPumpedCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(PetrolTank), "System.Void PetrolTank::PetrolPumpedRpc()", InvokeUserCode_PetrolPumpedRpc);
	}
}
