using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : NetworkBehaviour
{
	public GameObject[] objectiveObjs;

	public string[] objectiveToolTips;

	public int objectiveIndex;

	public GameObject tutorialObjects;

	public bool alreadyDone;

	public Outline[] outlines;

	public Outline noteOutline;

	public Outline trashBagOutline1;

	public Outline trashBagOutline2;

	public Outline trashBagOutline3;

	public Outline mopOutline;

	public Outline boxOutline1;

	public Outline boxOutline2;

	public UnityEvent disableShelfOutline;

	public GameObject[] limbs;

	public GameObject[] blood;

	public Image finishedBlood;

	public Image finishedLimbs;

	public Image finishedShelf;

	public Sprite checkboxSprite;

	public bool finishedObjectives;

	public GameObject instructions;

	public GameObject tutorialObjCanvas;

	public GameObject tutorialObjCanvasHolder;

	public GameObject tutorialObjCanvasHolderAsWell;

	public bool alreadyLookedAt;

	public int amountOfLookAts;

	public TextMeshProUGUI amountToLookAtText;

	public static TutorialManager Instance { get; private set; }

	public void StartObjective()
	{
		if (!alreadyDone)
		{
			objectiveObjs[objectiveIndex].SetActive(value: false);
			objectiveIndex++;
			if (objectiveIndex == 3)
			{
				noteOutline.enabled = true;
			}
			objectiveObjs[objectiveIndex].SetActive(value: true);
			StoreManager.Instance.NewObjective("Tutorial Objective", objectiveIndex.ToString());
		}
	}

	public void FinishObjective()
	{
		if (alreadyDone || finishedObjectives)
		{
			return;
		}
		tutorialObjCanvas.SetActive(value: true);
		finishedObjectives = true;
		StoreManager.Instance.FinishObjective();
		Outline[] array = outlines;
		foreach (Outline outline in array)
		{
			if (outline != null)
			{
				outline.enabled = true;
			}
		}
		CheckForLimbsDone();
		CheckForBloodDone();
	}

	public void FinishTutorial()
	{
		Outline[] array = outlines;
		foreach (Outline outline in array)
		{
			if (outline != null)
			{
				outline.enabled = false;
			}
		}
		if (!alreadyLookedAt)
		{
			alreadyLookedAt = true;
			if (base.isServer)
			{
				AnotherPlayerLookedAtRpc();
			}
			else
			{
				AnotherPlayerLookedAtCmd();
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void AnotherPlayerLookedAtCmd()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendCommandInternal("System.Void TutorialManager::AnotherPlayerLookedAtCmd()", -414472299, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void AnotherPlayerLookedAtRpc()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void TutorialManager::AnotherPlayerLookedAtRpc()", -769330314, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void CheckWhosLookAt()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		if (amountOfLookAts >= array.Length)
		{
			CancelInvoke("CheckWhosLookAt");
			StoreManager.Instance.FinishObjective();
			tutorialObjCanvasHolder.SetActive(value: false);
			CurrentDayManager.Instance.PlayNextOccurence();
		}
		StoreManager.Instance.amountToLookAtObjectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		StoreManager.Instance.amountToLookAtObjectiveText.text = "( " + amountOfLookAts + " / " + array.Length + " )";
	}

	public void FinishedShelf()
	{
		finishedShelf.sprite = checkboxSprite;
		disableShelfOutline.Invoke();
		if (finishedBlood.sprite == checkboxSprite && finishedShelf.sprite == checkboxSprite && finishedLimbs.sprite == checkboxSprite)
		{
			StartObjective();
			disableShelfOutline.Invoke();
			instructions.SetActive(value: true);
			tutorialObjCanvasHolder.SetActive(value: false);
		}
	}

	public void FinishedLimbs()
	{
		finishedLimbs.sprite = checkboxSprite;
		if (finishedBlood.sprite == checkboxSprite && finishedShelf.sprite == checkboxSprite && finishedLimbs.sprite == checkboxSprite)
		{
			StartObjective();
			disableShelfOutline.Invoke();
			instructions.SetActive(value: true);
			tutorialObjCanvasHolder.SetActive(value: false);
		}
	}

	public void FinishedBlood()
	{
		finishedBlood.sprite = checkboxSprite;
		if (finishedBlood.sprite == checkboxSprite && finishedShelf.sprite == checkboxSprite && finishedLimbs.sprite == checkboxSprite)
		{
			StartObjective();
			disableShelfOutline.Invoke();
			instructions.SetActive(value: true);
			tutorialObjCanvasHolder.SetActive(value: false);
		}
	}

	private void CheckForLimbsDone()
	{
		GameObject[] array = limbs;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].activeInHierarchy)
			{
				Invoke("CheckForLimbsDone", 1f);
				return;
			}
		}
		FinishedLimbs();
	}

	private void CheckForBloodDone()
	{
		GameObject[] array = blood;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].activeInHierarchy)
			{
				Invoke("CheckForBloodDone", 1f);
				return;
			}
		}
		FinishedBlood();
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_AnotherPlayerLookedAtCmd()
	{
		AnotherPlayerLookedAtRpc();
	}

	protected static void InvokeUserCode_AnotherPlayerLookedAtCmd(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command AnotherPlayerLookedAtCmd called on client.");
		}
		else
		{
			((TutorialManager)obj).UserCode_AnotherPlayerLookedAtCmd();
		}
	}

	protected void UserCode_AnotherPlayerLookedAtRpc()
	{
		amountOfLookAts++;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		if (amountOfLookAts >= array.Length)
		{
			CancelInvoke("CheckWhosLookAt");
			StoreManager.Instance.FinishObjective();
			tutorialObjCanvasHolder.SetActive(value: false);
			CurrentDayManager.Instance.PlayNextOccurence();
		}
		else if (base.isServer)
		{
			InvokeRepeating("CheckWhosLookAt", 1f, 1f);
		}
		StoreManager.Instance.amountToLookAtObjectiveText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		StoreManager.Instance.amountToLookAtObjectiveText.text = "( " + amountOfLookAts + " / " + array.Length + " )";
	}

	protected static void InvokeUserCode_AnotherPlayerLookedAtRpc(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC AnotherPlayerLookedAtRpc called on server.");
		}
		else
		{
			((TutorialManager)obj).UserCode_AnotherPlayerLookedAtRpc();
		}
	}

	static TutorialManager()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(TutorialManager), "System.Void TutorialManager::AnotherPlayerLookedAtCmd()", InvokeUserCode_AnotherPlayerLookedAtCmd, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(TutorialManager), "System.Void TutorialManager::AnotherPlayerLookedAtRpc()", InvokeUserCode_AnotherPlayerLookedAtRpc);
	}
}
