using System;
using System.Collections.Generic;
using Localization;
using Steamworks;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverrideSaveView : GameView
{
	[SceneBind("Layer")]
	private Button Layer;

	[SceneBind("AttentionRewrite")]
	private Image AttentionRewrite;

	[SceneBind("AttentionRewrite/WindowBox/Cat_write")]
	private Image CatWrite;

	[SceneBind("AttentionRewrite/WindowBox/Cat_rewrite")]
	private Image Cat_rewrite;

	[SceneBind("AttentionRewrite/WindowBox/HeaderText")]
	private Text attentionRewriteHeader;

	[SceneBind("AttentionRewrite/WindowBox/BottomBox/ButtonsBox/Accept")]
	private Button AttentionRewriteAccept;

	[SceneBind("AttentionRewrite/WindowBox/BottomBox/ButtonsBox/Cancel")]
	private Button AttentionRewriteCancel;

	[SceneBind("AttentionRewrite/WindowBox/InfoInputFieldBox/InfoInputField")]
	private InputField attentionRewriteInputField;

	[SceneBind("AttentionRewrite/WindowBox/SaveInfo")]
	private Text SaveInfo;

	private Callback<FloatingGamepadTextInputDismissed_t> m_FloatingGamepadTextInputDismissed;

	private bool exitFlag;

	private bool InputFieldWasFocused;

	private void OnFloatingGamepadTextInputDismissed(FloatingGamepadTextInputDismissed_t pCallback)
	{
		string pchText = string.Empty;
		uint cchText = 0u;
		SteamUtils.GetEnteredGamepadTextInput(out pchText, cchText);
		attentionRewriteInputField.text = pchText;
		attentionRewriteInputField.OnDeselect(new BaseEventData(EventSystem.current));
	}

	protected override void OnInit()
	{
		base.OnInit();
		AttentionRewriteCancel.onClick.AddListener(CancelRewrite);
		Layer.onClick.AddListener(CloseClickJoyCon);
		CloseButton.onClick.RemoveAllListeners();
		CloseButton.onClick.AddListener(CloseClickJoyCon);
	}

	protected void CloseClickJoyCon()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_CloseWindow");
		ActiveComponent.Program.cursor.SetPosition(ActiveComponent._controller.MenuView.back.transform.position);
		base.gameObject.SetActive(value: false);
	}

	private void AcceptRewrite(int id)
	{
		if (id >= ActiveComponent.Model.globalSaves.Preview.Count)
		{
			WriteInNewSlot();
			return;
		}
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		PreviewData prev = ActiveComponent.Model.curPreview;
		Logic.GetPreviewIdWithSaveKey(prev.saveName);
		ActiveComponent.Model.globalSaves.Preview[id] = new PreviewData();
		ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview[id];
		WriteInSlot(ActiveComponent.Model.globalSaves.Preview[id], prev, rewrite: true);
		ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview.Find((PreviewData x) => x.autoSaved == 1 && x.showName == prev.showName);
	}

	private void CancelRewrite()
	{
		AttentionRewrite.gameObject.SetActive(value: false);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
	}

	private void ShowAttentionRewrite(int saveId)
	{
		AttentionRewriteAccept.onClick.RemoveAllListeners();
		AttentionRewriteAccept.onClick.AddListener(delegate
		{
			AcceptRewrite(saveId);
		});
		if (saveId >= ActiveComponent.Model.globalSaves.Preview.Count)
		{
			attentionRewriteInputField.text = "";
			AttentionRewriteAccept.GetComponentInChildren<Text>().text = TextResources.GetString("WRITE_SAVE_BUTTON");
			attentionRewriteHeader.text = Logic.ColorTransform("WARNING", TextResources.GetString("WRITING_NEW_SAVE"));
			Cat_rewrite.gameObject.SetActive(value: false);
			CatWrite.gameObject.SetActive(value: true);
			ActiveComponent.Program.cursor.SetPosition(AttentionRewriteAccept.transform.position);
		}
		else
		{
			attentionRewriteInputField.text = ActiveComponent.Model.globalSaves.Preview[saveId].info;
			AttentionRewriteAccept.GetComponentInChildren<Text>().text = TextResources.GetString("REWRITEBTN");
			attentionRewriteHeader.text = Logic.ColorTransform("RED", TextResources.GetString("REWRITING_SAVE"));
			Cat_rewrite.gameObject.SetActive(value: true);
			CatWrite.gameObject.SetActive(value: false);
			ActiveComponent.Program.cursor.SetPosition(AttentionRewriteCancel.transform.position);
		}
		AttentionRewrite.gameObject.SetActive(value: true);
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_WarningPopup");
	}

	protected override void SaveClick(int saveId)
	{
		base.SaveClick(saveId);
		ShowAttentionRewrite(saveId);
	}

	private void WriteInSlot(PreviewData pr, PreviewData copyPreview, bool rewrite)
	{
		for (int i = 0; i < ActiveComponent.Model.globalSaves.Preview.Count; i++)
		{
			ActiveComponent.Model.globalSaves.Preview[i].isLastRun = 0;
		}
		pr.autoSaved = 0;
		string startCheckpointKeyName = copyPreview.startCheckpointKeyName;
		PersistentData p = Logic.Clone<PersistentData>(ActiveComponent.Model.P);
		ActiveComponent.Model.P = p;
		pr.date.Set();
		pr.isLastRun = 1;
		pr.startupsNumber = ActiveComponent.Model.P.Startups.Count;
		pr.money = ActiveComponent.Model.P.Money;
		pr.saveName = "PLAYER" + ActiveComponent.Model.globalSaves.newGames;
		ActiveComponent.Model.globalSaves.newGames++;
		pr.startCheckpointKeyName = startCheckpointKeyName;
		pr.showName = copyPreview.showName;
		pr.version = Program.GetVersionString();
		pr.qinfo = Logic.DeserializeObject<Dictionary<string, PreviewData.QuestInfo>>(Logic.SerializeObject(copyPreview.qinfo));
		pr.info = attentionRewriteInputField.text;
		pr.buggleScore = copyPreview.buggleScore;
		Logic.UpdateGameSaves(0);
		Logic.UpdateGlobalSaves();
		if (exitFlag)
		{
			ActiveComponent._controller.construction.OnUnInit();
			SceneManager.LoadSceneAsync("art");
		}
		else
		{
			base.gameObject.SetActive(value: false);
			ActiveComponent.Program.cursor.SetPosition(ActiveComponent._controller.MenuView.back.transform.position);
		}
	}

	private void WriteInNewSlot()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.globalSaves.Preview.Add(new PreviewData());
		PreviewData prev = ActiveComponent.Model.curPreview;
		ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview[ActiveComponent.Model.globalSaves.Preview.Count - 1];
		WriteInSlot(ActiveComponent.Model.globalSaves.Preview[ActiveComponent.Model.globalSaves.Preview.Count - 1], prev, rewrite: false);
		ActiveComponent.Model.curPreview = ActiveComponent.Model.globalSaves.Preview.Find((PreviewData x) => x.autoSaved == 1 && x.showName == prev.showName);
	}

	protected override void InstantiateSave(int saveId, Action saveClickAction)
	{
		if (saveId >= ActiveComponent.Model.globalSaves.Preview.Count || ActiveComponent.Model.globalSaves.Preview[saveId].autoSaved == 0)
		{
			base.InstantiateSave(saveId, saveClickAction);
		}
	}

	public void Redraw(bool exit)
	{
		base.Redraw();
		exitFlag = exit;
		if (ActiveComponent.Model.globalSaves.Preview.Count < ActiveComponent._staticData.Settings.SavesNumber)
		{
			InstantiateSave(ActiveComponent.Model.globalSaves.Preview.Count, delegate
			{
				SaveClick(ActiveComponent.Model.globalSaves.Preview.Count);
			});
		}
		AttentionRewrite.gameObject.SetActive(value: false);
	}

	public void Update()
	{
		if (ActiveComponent._staticData == null)
		{
			return;
		}
		if (Logic.IsSteamDeckRunning())
		{
			bool isFocused = attentionRewriteInputField.isFocused;
			if (isFocused && !InputFieldWasFocused)
			{
				SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 0, 0, 0, 0);
			}
			if (isFocused != InputFieldWasFocused)
			{
				InputFieldWasFocused = isFocused;
			}
		}
		if (!Logic.IsSteamDeckRunning() && (ActiveComponent.Model.CurInputDeviceIsController || ActiveComponent.Model.globalSaves.ForcedVisualKeyBoard))
		{
			bool isFocused2 = attentionRewriteInputField.isFocused;
			if (isFocused2 && !InputFieldWasFocused)
			{
				ActiveComponent.Model.Keyboard.SetInput(attentionRewriteInputField);
			}
			if (isFocused2 != InputFieldWasFocused)
			{
				InputFieldWasFocused = isFocused2;
			}
		}
	}
}
