using System;
using UnityEngine;

public class UnreadPCButtonHandler : MonoBehaviour
{
	public enum PCMessageType
	{
		web_BarryMissing = 0,
		web_HallowayHeights = 1,
		web_Arson = 2,
		web_Dissaperances = 3,
		email_SecurityCodes = 4,
		email_ProductionConcerns = 5,
		email_StudioDisregard = 6,
		email_Meeting = 7,
		email_PoliceRansom = 8
	}

	[SerializeField]
	private GameObject unreadImage;

	[SerializeField]
	private GameObject readImage;

	public PCMessageType pcMessageType;

	private void OnEnable()
	{
		try
		{
			ShowHide();
		}
		catch
		{
		}
	}

	private void Start()
	{
		PcManager singleton = PcManager.Singleton;
		singleton.OnPCButtonClicked_Action = (Action)Delegate.Combine(singleton.OnPCButtonClicked_Action, new Action(OnPcButtonClicked));
	}

	private void OnDestroy()
	{
		PcManager singleton = PcManager.Singleton;
		singleton.OnPCButtonClicked_Action = (Action)Delegate.Remove(singleton.OnPCButtonClicked_Action, new Action(OnPcButtonClicked));
	}

	private void OnPcButtonClicked()
	{
		ShowHide();
	}

	private void ShowHide()
	{
		switch (pcMessageType)
		{
		case PCMessageType.web_BarryMissing:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Website_BarryMissing);
			break;
		case PCMessageType.web_HallowayHeights:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Website_HallowayHeights);
			break;
		case PCMessageType.web_Arson:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Website_Arson);
			break;
		case PCMessageType.web_Dissaperances:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Website_Dissappearances);
			break;
		case PCMessageType.email_SecurityCodes:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Email_SecurityCodes);
			break;
		case PCMessageType.email_ProductionConcerns:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Email_ProductionConcerns);
			break;
		case PCMessageType.email_StudioDisregard:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Email_StudioDisregard);
			break;
		case PCMessageType.email_Meeting:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Email_Meeting);
			break;
		case PCMessageType.email_PoliceRansom:
			readImage.SetActive(PlayerStats.Singleton.pc_HasRead_Email_PoliceRansom);
			break;
		}
	}
}
