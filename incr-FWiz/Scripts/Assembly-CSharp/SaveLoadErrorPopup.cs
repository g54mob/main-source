using UnityEngine;
using UnityEngine.Localization.Components;

public class SaveLoadErrorPopup : Popup
{
	public const string FailedSlotIndexKey = "FailedSlotIndex";

	[SerializeField]
	private LocalizeStringEvent _worldNameText;

	public override string ID => null;

	public override bool CanHandle(object obj)
	{
		return false;
	}

	protected override bool DoHandle(object obj)
	{
		return false;
	}

	public void OnOpenFolderPressed()
	{
	}
}
