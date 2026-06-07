using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuPanel : MenuPanel
{
	public LayoutGroup buttonLayoutGroup;

	public GameObject menuButtonPrefab;

	public GameObject modifiersRegion;

	public TextMeshProUGUI headerLabel;

	public TextMeshProUGUI modifiersLabel;

	private readonly List<LabelButton> buttons = new List<LabelButton>();

	protected override void Awake()
	{
		base.Awake();
		LoadMainButtons();
	}

	public override bool IsFixedPosition()
	{
		return true;
	}

	public override void Show()
	{
		base.Show();
		ReloadLabels();
	}

	public override void Hide()
	{
		base.Hide();
	}

	private void LoadMainButtons()
	{
		AddLabelButton("MenuFunctionSave").AddPointerClickTrigger(OnSavePressed);
		AddLabelButton("SaveAs").AddPointerClickTrigger(OnSaveAsPressed);
		AddLabelButton("MenuFunctionOptions").AddPointerClickTrigger(OnOptionsPressed);
		AddLabelButton("MenuFunctionControls").AddPointerClickTrigger(OnControlsPressed);
		AddLabelButton("MenuFunctionSaveAndQuit").AddPointerClickTrigger(OnQuitPressed);
		GameObject obj = new GameObject();
		obj.transform.parent = buttonLayoutGroup.transform;
		obj.AddComponent<LayoutElement>().minHeight = 30f;
		AddLabelButton("Back").AddPointerClickTrigger(OnBackPressed);
	}

	private LabelButton AddLabelButton(string localizationKey)
	{
		LabelButton component = MenuManager.GetMenuObject(menuButtonPrefab, buttonLayoutGroup.transform).GetComponent<LabelButton>();
		buttons.Add(component);
		component.localizationKey = localizationKey;
		component.buttonState = CustomButtonState.Default;
		return component;
	}

	private void OnQuitPressed()
	{
		Hide();
		FileManager.Save();
		MenuManager.Instance.queuedLoadingMenuAction = 0;
		GameManager.Instance.ClearGameState();
		MenuManager.Instance.HideAllModals();
		MusicPlayer.Instance.FadeOutPlayingSong();
		MenuManager.Instance.FadeLoadingCoverIn();
	}

	private void OnSavePressed()
	{
		FileManager.Save();
		MenuManager.Instance.ShowMessage("GameSaved".Localized());
		Hide();
	}

	private void OnSaveAsPressed()
	{
		MenuManager.Instance.fileListPanel.inputField.text = GameManager.Instance.overrideFileName;
		MenuManager.Instance.fileListPanel.ShowForMode(FilePanelMode.Save, OnCancelledSaveAs);
		MenuPanel.m.fileListPanel.CreateLayout();
	}

	private void OnCancelledSaveAs()
	{
	}

	private void OnOptionsPressed()
	{
		MenuPanel.m.optionsPanel.Show();
		Hide();
	}

	private void OnControlsPressed()
	{
		MenuPanel.m.controlsPanel.Show();
		Hide();
	}

	private void OnBackPressed()
	{
		Hide();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		headerLabel.text = "Menu".Localized();
		foreach (LabelButton button in buttons)
		{
			button.ReloadLabels();
		}
		if (MenuPanel.gm.appliedModifiers.Count == 0)
		{
			modifiersLabel.text = string.Empty;
			modifiersRegion.SetActive(value: false);
			return;
		}
		modifiersRegion.SetActive(value: true);
		StringBuilder pooledStringBuilder = GameUtility.GetPooledStringBuilder();
		pooledStringBuilder.Append("Modifiers".Localized());
		pooledStringBuilder.Append(':');
		pooledStringBuilder.Append('\n');
		foreach (GameModifier appliedModifier in MenuPanel.gm.appliedModifiers)
		{
			pooledStringBuilder.Append(TextDisplay.LabelForGameModifier(appliedModifier));
			pooledStringBuilder.Append('\n');
		}
		modifiersLabel.SetText(pooledStringBuilder);
		GameUtility.ReturnToPool(pooledStringBuilder);
	}
}
