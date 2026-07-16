using System.Linq;
using MLCN_Localization;

public class Dialog
{
	public EntityNameTag nameTag;

	public string[] sentences;

	public string sound;

	public bool autoProceed;

	public DialogAnimationProperty animationProperty;

	public Dialog()
	{
	}

	public Dialog(EntityNameTag nameTag, string[] sentenceKeys, string sound, bool autoProceed, bool isLocalized = false)
	{
		this.nameTag = nameTag;
		sentences = (isLocalized ? sentenceKeys : LocalizationManager.GetLocalizedList(sentenceKeys.ToList(), LocalizationDataTable.Tables.Dialogs).ToArray());
		this.sound = sound;
		this.autoProceed = autoProceed;
	}
}
