using System;
using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
	public static TutorialManager S;

	private bool isCraftingTableUIShowed;

	private bool isPartTimeUIShowed;

	private bool isCookingTableUIShowed;

	private bool isPowderRocketUIShowed;

	private bool isCameraUIShowed;

	private bool isRocketCrashedUIShowed;

	private bool isRcCarUIShowed;

	private bool isMotorCraftingTableUIShowed;

	private bool isPaintTableUIShowed;

	private bool isTheftUIShowed;

	private bool isCodingUIShowed;

	private bool isTicketUIShowed;

	private bool craftingTutorialDone;

	private bool rocketCrashedTutorialDone;

	private bool cameraTutorialDone;

	private bool cookingTutorialDone;

	private bool theftTutorialDone;

	private bool rcTutorialDone;

	private bool motorCraftingTutorialDone;

	private bool powderRocketTutorialDone;

	private bool parttimeTutorialDone;

	private bool codingTutorialDone;

	private bool paintTutorialDone;

	private bool ticketTutorialDone;

	private void Awake()
	{
		if (S != null && S != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadData();
	}

	private void BusStopUI_OnRocketRetrived()
	{
		StartCoroutine(OpenTutorialUI());
	}

	private IEnumerator OpenTutorialUI()
	{
		yield return null;
		bool flag = false;
		if (isRocketCrashedUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(5);
			FirstPersonController.S.canControl = false;
			isRocketCrashedUIShowed = false;
			rocketCrashedTutorialDone = true;
			flag = true;
		}
		if (isCraftingTableUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(0);
			FirstPersonController.S.canControl = false;
			isCraftingTableUIShowed = false;
			cameraTutorialDone = true;
			flag = true;
		}
		else if (isPartTimeUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(4);
			FirstPersonController.S.canControl = false;
			isPartTimeUIShowed = false;
			parttimeTutorialDone = true;
			flag = true;
		}
		else if (isCookingTableUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(2);
			FirstPersonController.S.canControl = false;
			isCookingTableUIShowed = false;
			cookingTutorialDone = true;
			flag = true;
		}
		else if (isPowderRocketUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(3);
			FirstPersonController.S.canControl = false;
			isPowderRocketUIShowed = false;
			powderRocketTutorialDone = true;
			flag = true;
		}
		else if (isCameraUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(1);
			FirstPersonController.S.canControl = false;
			isCameraUIShowed = false;
			cameraTutorialDone = true;
			flag = true;
		}
		else if (isRcCarUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(6);
			FirstPersonController.S.canControl = false;
			isRcCarUIShowed = false;
			rcTutorialDone = true;
			flag = true;
		}
		else if (isMotorCraftingTableUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(7);
			FirstPersonController.S.canControl = false;
			isMotorCraftingTableUIShowed = false;
			motorCraftingTutorialDone = true;
			flag = true;
		}
		else if (isPaintTableUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(8);
			FirstPersonController.S.canControl = false;
			isPaintTableUIShowed = false;
			paintTutorialDone = true;
			flag = true;
		}
		else if (isTheftUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(9);
			FirstPersonController.S.canControl = false;
			isTheftUIShowed = false;
			theftTutorialDone = true;
			flag = true;
		}
		else if (isCodingUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(10);
			FirstPersonController.S.canControl = false;
			isCodingUIShowed = false;
			codingTutorialDone = true;
			flag = true;
		}
		else if (isTicketUIShowed)
		{
			Cursor.visible = true;
			GameManager.S.TutorialWIndowOn(11);
			FirstPersonController.S.canControl = false;
			isTicketUIShowed = false;
			ticketTutorialDone = true;
			flag = true;
		}
		if (!flag)
		{
			GameManager.S.TutorialWIndowOn(-1);
		}
	}

	private void Start()
	{
		BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		if (!codingTutorialDone)
		{
			RocketComputer.OnCpuInstalled += RocketComputer_OnCpuInstalled;
		}
		if (!paintTutorialDone)
		{
			GameManager.S.OnPaintingTable += S_OnPaintingTable;
		}
		if (!craftingTutorialDone)
		{
			GameManager.S.OnBasementUnlocked += Gm_OnBasementUnlocked;
		}
		if (!cookingTutorialDone)
		{
			GameManager.S.OnCookingTableUnlocked += S_OnCookingTableUnlocked;
		}
		if (!parttimeTutorialDone)
		{
			GameManager.S.OnPartTimeUnlocked += S_OnPartTimeUnlocked;
		}
		if (!powderRocketTutorialDone)
		{
			QuestManager.S.OnPowerRocketUnlocked += Qm_OnPowerRocketUnlocked;
		}
		if (!rocketCrashedTutorialDone)
		{
			GameManager.S.OnRocketCrashed += S_OnRocketCrashed;
		}
		if (!cameraTutorialDone)
		{
			GameManager.S.OnVideoUnlocked += S_OnVideoUnlocked;
		}
		if (!theftTutorialDone)
		{
			Grocery.OnHandleTheft += Grocery_OnHandleTheft;
		}
		if (!rcTutorialDone)
		{
			RocketAndRcBox.OnRcBoxInteracted += RocketAndRcBox_OnRcBoxInteracted;
		}
		if (!motorCraftingTutorialDone)
		{
			GameManager.S.OnMotorCraftingTableInteracted += S_OnMotorCraftingTableInteracted;
		}
		if (!ticketTutorialDone)
		{
			GameManager.S.OnTicketUpdated += S_OnTicketUpdated;
		}
	}

	private void SaveData()
	{
		ES3.Save("craftingTutorialDone", craftingTutorialDone);
		ES3.Save("rocketCrashedTutorialDone", rocketCrashedTutorialDone);
		ES3.Save("cameraTutorialDone", cameraTutorialDone);
		ES3.Save("cookingTutorialDone", cookingTutorialDone);
		ES3.Save("theftTutorialDone", theftTutorialDone);
		ES3.Save("rcTutorialDone", rcTutorialDone);
		ES3.Save("motorCraftingTutorialDone", motorCraftingTutorialDone);
		ES3.Save("powderRocketTutorialDone", powderRocketTutorialDone);
		ES3.Save("parttimeTutorialDone", parttimeTutorialDone);
		ES3.Save("codingTutorialDone", codingTutorialDone);
		ES3.Save("paintTutorialDone", paintTutorialDone);
		ES3.Save("ticketTutorialDone", ticketTutorialDone);
	}

	private void LoadData()
	{
		craftingTutorialDone = ES3.Load("craftingTutorialDone", craftingTutorialDone);
		rocketCrashedTutorialDone = ES3.Load("rocketCrashedTutorialDone", rocketCrashedTutorialDone);
		cameraTutorialDone = ES3.Load("cameraTutorialDone", cameraTutorialDone);
		cookingTutorialDone = ES3.Load("cookingTutorialDone", cookingTutorialDone);
		theftTutorialDone = ES3.Load("theftTutorialDone", theftTutorialDone);
		rcTutorialDone = ES3.Load("rcTutorialDone", rcTutorialDone);
		motorCraftingTutorialDone = ES3.Load("motorCraftingTutorialDone", motorCraftingTutorialDone);
		powderRocketTutorialDone = ES3.Load("powderRocketTutorialDone", powderRocketTutorialDone);
		parttimeTutorialDone = ES3.Load("parttimeTutorialDone", parttimeTutorialDone);
		codingTutorialDone = ES3.Load("codingTutorialDone", codingTutorialDone);
		paintTutorialDone = ES3.Load("paintTutorialDone", paintTutorialDone);
		ticketTutorialDone = ES3.Load("paintTutorialDone", ticketTutorialDone);
	}

	private void S_OnTicketUpdated()
	{
		isTicketUIShowed = true;
		GameManager.S.OnTicketUpdated -= S_OnTicketUpdated;
		StartCoroutine(OpenTutorialUI());
	}

	private void RocketComputer_OnCpuInstalled()
	{
		isCodingUIShowed = true;
		Grocery.OnHandleTheft -= RocketComputer_OnCpuInstalled;
		StartCoroutine(OpenTutorialUI());
	}

	private void Grocery_OnHandleTheft()
	{
		isTheftUIShowed = true;
		Grocery.OnHandleTheft -= Grocery_OnHandleTheft;
		StartCoroutine(OpenTutorialUI());
	}

	private void RocketAndRcBox_OnRcBoxInteracted()
	{
		isRcCarUIShowed = true;
		RocketAndRcBox.OnRcBoxInteracted -= RocketAndRcBox_OnRcBoxInteracted;
		StartCoroutine(OpenTutorialUI());
	}

	private void S_OnPaintingTable(Rocket obj)
	{
		isPaintTableUIShowed = true;
		GameManager.S.OnPaintingTable -= S_OnPaintingTable;
		StartCoroutine(OpenTutorialUI());
	}

	private void S_OnMotorCraftingTableInteracted(object sender, EventArgs e)
	{
		isMotorCraftingTableUIShowed = true;
		GameManager.S.OnMotorCraftingTableInteracted -= S_OnMotorCraftingTableInteracted;
		StartCoroutine(OpenTutorialUI());
	}

	private void S_OnVideoUnlocked()
	{
		isCameraUIShowed = true;
		GameManager.S.OnVideoUnlocked -= S_OnVideoUnlocked;
		StartCoroutine(OpenTutorialUI());
	}

	private void OnDestroy()
	{
		RocketComputer.OnCpuInstalled -= RocketComputer_OnCpuInstalled;
		GameManager.S.OnPaintingTable -= S_OnPaintingTable;
		GameManager.S.OnMotorCraftingTableInteracted -= S_OnMotorCraftingTableInteracted;
		GameManager.S.OnRocketCrashed -= S_OnRocketCrashed;
		GameManager.S.OnBasementUnlocked -= Gm_OnBasementUnlocked;
		GameManager.S.OnCookingTableUnlocked -= S_OnCookingTableUnlocked;
		GameManager.S.OnPartTimeUnlocked -= S_OnPartTimeUnlocked;
		QuestManager.S.OnPowerRocketUnlocked -= Qm_OnPowerRocketUnlocked;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		BusStopUI.OnRocketRetrived -= BusStopUI_OnRocketRetrived;
		GameManager.S.OnVideoUnlocked -= S_OnVideoUnlocked;
		RocketAndRcBox.OnRcBoxInteracted -= RocketAndRcBox_OnRcBoxInteracted;
		Grocery.OnHandleTheft -= Grocery_OnHandleTheft;
		GameManager.S.OnTicketUpdated -= S_OnTicketUpdated;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		SaveData();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void S_OnRocketCrashed()
	{
		isRocketCrashedUIShowed = true;
		GameManager.S.OnRocketCrashed -= S_OnRocketCrashed;
	}

	private void Gm_OnBasementUnlocked()
	{
		isCraftingTableUIShowed = true;
		GameManager.S.OnBasementUnlocked -= Gm_OnBasementUnlocked;
	}

	private void Qm_OnPowerRocketUnlocked()
	{
		isPowderRocketUIShowed = true;
		GameManager.S.isPowderRocketUnlocked = true;
	}

	private void S_OnCookingTableUnlocked()
	{
		isCookingTableUIShowed = true;
		GameManager.S.OnCookingTableUnlocked -= S_OnCookingTableUnlocked;
		FirstPersonController.S.MoneyUpdated(2f);
	}

	private void S_OnPartTimeUnlocked()
	{
		isPartTimeUIShowed = true;
		GameManager.S.OnPartTimeUnlocked -= S_OnPartTimeUnlocked;
	}

	private void Update()
	{
	}
}
