using UnityEngine;

public class ModsErrorPanel : BaseMenu
{
	private Transform m_Panel;

	private BaseText TitleText;

	private BaseText DescriptionText;

	protected new void Awake()
	{
		base.Awake();
		m_Panel = base.transform.Find("BasePanelOptions").Find("Panel");
	}

	private void CheckGadgets()
	{
		if (!TitleText)
		{
			TitleText = m_Panel.Find("ErrorTitle").GetComponent<BaseText>();
			DescriptionText = m_Panel.Find("ErrorInfo").GetComponent<BaseText>();
			StandardAcceptButton component = m_Panel.Find("StandardAcceptButton").GetComponent<StandardAcceptButton>();
			AddAction(component, OnOKClicked);
			BaseButton component2 = m_Panel.Find("QuitGame").GetComponent<BaseButton>();
			AddAction(component2, OnQuit);
		}
	}

	public void SetCurrentError()
	{
		CheckGadgets();
		if (ModManager.Instance.CurrentErrorState != ModManager.ErrorState.No_Error)
		{
			switch (ModManager.Instance.CurrentErrorState)
			{
			case ModManager.ErrorState.Error_Restart:
				TitleText.SetTextFromID("ModsInfoRestart");
				DescriptionText.SetTextFromID("ModsInfoRestartDescription");
				break;
			case ModManager.ErrorState.Error_Upload_Description:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetTextFromID("ModsInfoUploadFailedDescription");
				break;
			case ModManager.ErrorState.Error_Upload_Image:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetTextFromID("ModsInfoUploadFailedImage");
				break;
			case ModManager.ErrorState.Error_Upload_Tags:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetTextFromID("ModsInfoUploadFailedTags");
				break;
			case ModManager.ErrorState.Error_Upload_Title:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetTextFromID("ModsInfoUploadFailedTitle");
				break;
			case ModManager.ErrorState.Error_FailedSubcribe:
				TitleText.SetTextFromID("ModsInfoSubscribeFailedTitle");
				DescriptionText.SetText("Error Code: " + ModManager.Instance.SteamErrorCode);
				break;
			case ModManager.ErrorState.Error_FailedUnsubcribe:
				TitleText.SetTextFromID("ModsInfoUnsubscribeFailedTitle");
				DescriptionText.SetText("Error Code: " + ModManager.Instance.SteamErrorCode);
				break;
			case ModManager.ErrorState.Error_Upload_Steam:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetText("Error Code: " + ModManager.Instance.SteamErrorCode);
				break;
			case ModManager.ErrorState.Error_Delete_Steam:
				TitleText.SetTextFromID("ModsInfoDeleteFailedTitle");
				DescriptionText.SetText("Error Code: " + ModManager.Instance.SteamErrorCode);
				break;
			case ModManager.ErrorState.Error_FailedResults:
				TitleText.SetTextFromID("ModsInfoResultsFailedTitle");
				DescriptionText.SetText("Error Code: " + ModManager.Instance.SteamErrorCode);
				break;
			case ModManager.ErrorState.Error_AcceptTCs:
				TitleText.SetTextFromID("ModsInfoUploadFailed");
				DescriptionText.SetTextFromID("ModsInfoResultsFailedTCs");
				break;
			case ModManager.ErrorState.Error_Lua:
				TitleText.SetTextFromID("ModsInfoLuaErrorTitle");
				DescriptionText.SetText(ModManager.Instance.OverrideErrorMessage);
				break;
			case ModManager.ErrorState.Error_Misc:
				TitleText.SetTextFromID("ModsInfoStandardErrorTitle");
				DescriptionText.SetText(ModManager.Instance.OverrideErrorMessage);
				break;
			case ModManager.ErrorState.Error_Clash:
				TitleText.SetTextFromID("ModsInfoClashTitle");
				DescriptionText.SetText(ModManager.Instance.OverrideErrorMessage);
				break;
			}
		}
		else
		{
			GameStateManager.Instance.PopState();
		}
		ModManager.Instance.ClearError();
	}

	public void SetInformation(string TitleID, string DescriptionID)
	{
		CheckGadgets();
		TitleText.SetTextFromID(TitleID);
		DescriptionText.SetText(DescriptionID);
	}

	public void OnOKClicked(BaseGadget NewGadget)
	{
		GameStateManager.Instance.PopState();
	}

	public void OnQuit(BaseGadget NewGadget)
	{
		AudioManager.Instance.StartEvent("UIOptionSelected");
		GameStateManager.Instance.PushState(GameStateManager.State.Confirm);
		GameStateManager.Instance.GetCurrentState().GetComponent<GameStateConfirm>().SetConfirm(ConfirmQuit, "ConfirmQuitMainMenu");
	}

	public void ConfirmQuit()
	{
		Application.Quit();
	}

	protected new void Update()
	{
		base.Update();
	}
}
