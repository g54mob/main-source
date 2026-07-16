using System.Linq;
using MLCN_Localization;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogSequence", menuName = "Scriptable Objects/DialogSequence")]
public class DialogSequence : ScriptableObject
{
	public string tag;

	public string stateBinding;

	public string[] dialogKeys;

	public string sound;

	public string GetFirst()
	{
		return LocalizationManager.GetLocalizedString(dialogKeys[0], LocalizationDataTable.Tables.Dialogs);
	}

	public string GetFirstKey()
	{
		return dialogKeys[0];
	}

	public string GetRandomDialog()
	{
		int num = Random.Range(0, dialogKeys.Length);
		return LocalizationManager.GetLocalizedString(dialogKeys[num], LocalizationDataTable.Tables.Dialogs);
	}

	public string GetRandomDialogKey()
	{
		int num = Random.Range(0, dialogKeys.Length);
		return dialogKeys[num];
	}

	public bool IsState(string state)
	{
		return stateBinding.ToLower() == state.ToLower();
	}

	public bool IsTag(string tag)
	{
		return this.tag.ToLower() == tag.ToLower();
	}

	public Dialog GetSingleRandomAsDialog(EntityNameTag nameTag, string sound = "")
	{
		Dialog dialog = new Dialog();
		dialog.nameTag = nameTag;
		dialog.sound = ((sound == "") ? this.sound : sound);
		dialog.sentences = new string[1] { GetRandomDialog() };
		return dialog;
	}

	public Dialog AsDialog(EntityNameTag nameTag, string sound = "")
	{
		return new Dialog
		{
			nameTag = nameTag,
			sound = ((sound == "") ? this.sound : sound),
			sentences = LocalizationManager.GetLocalizedList(dialogKeys.ToList(), LocalizationDataTable.Tables.Dialogs).ToArray()
		};
	}
}
