using System;
using TMPro;
using UnityEngine.Events;

public class SlotButton : MenuButton
{
	public TextMeshProUGUI slotLabel;

	public TextMeshProUGUI townNameLabel;

	public TextMeshProUGUI levelLabel;

	public TextMeshProUGUI noDataLabel;

	public CapacityRegion LevelCapacityRegion;

	[NonSerialized]
	public int slotNumber;

	public UnityAction<SlotButton> clickDelegate;

	public bool isEmpty;

	public MenuButton deleteButton;

	protected override void Awake()
	{
		base.Awake();
		deleteButton.AddPointerClickTrigger(OnDeletePressed);
		animateSize = true;
	}

	protected override void Update()
	{
		base.Update();
		deleteButton.gameObject.SetActive(IsHighlighted() && !isEmpty);
	}

	public void OnSlotClick()
	{
		clickDelegate?.Invoke(this);
	}

	public void ReloadLabels()
	{
		slotLabel.text = "SaveSlot".Localized() + " " + TextDisplay.LocalizedNumber(slotNumber);
	}

	public void ConfigureFromGameData(GameDataContainer d)
	{
		SetToEmptyState(state: false);
		townNameLabel.text = d.townName;
		TextDisplay.FormatLevel(levelLabel, d.townLevel);
	}

	public void SetToEmptyState(bool state)
	{
		isEmpty = state;
		noDataLabel.enabled = state;
		townNameLabel.enabled = !state;
		levelLabel.enabled = !state;
		deleteButton.buttonState = CustomButtonState.Background;
	}

	private void OnDeletePressed()
	{
		isSelected = true;
		UpdateBackgroundColor();
		string text = townNameLabel.text;
		MenuManager.Instance.playerPromptPanel.ShowConfirmDelete(OnConfirmDeletePressed, text, OnDeletionPromptDismissed);
	}

	private void OnConfirmDeletePressed()
	{
		FileMetadata fileMetadata = Platform.Instance.CreateFileMetadata(slotNumber, 0);
		Platform.Instance.DeleteFile(fileMetadata);
		SetToEmptyState(state: true);
	}

	private void OnDeletionPromptDismissed()
	{
	}
}
