public class CharacterTypeSelectionMenu : RadicalMenu
{
	public RadicalMenuOption_Done doneButton;

	public CharacterTypeOption_Selection selectionOption;

	private int saveFileId;

	public override void Activate()
	{
		base.Activate();
		doneButton.SetInteractable(interactable: true);
		selectionOption.ResetType();
		saveFileId = Manager.saves.GetCharacterId();
	}

	public void OnDone()
	{
		Manager.saves.SetCharacterType(saveFileId, (CharacterType)selectionOption.activeVariationIndex);
		Manager.menu.PushMenu(MenuType.CHARACTER_CUSTOMIZATION);
	}
}
