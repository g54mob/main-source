namespace RLD
{
	public enum ObjectDeselectReason
	{
		None = 0,
		ClickSelectOther = 1,
		CickAppendAlreadySelected = 2,
		ClickAir = 3,
		MultiDeselect = 4,
		MultiSelectNotOverlapped = 5,
		Undo = 6,
		Redo = 7,
		RemoveFromSelectionCall = 8,
		ClearSelectionCall = 9,
		SetSelectedCall = 10,
		Inactive = 11,
		WillBeDeleted = 12
	}
}
