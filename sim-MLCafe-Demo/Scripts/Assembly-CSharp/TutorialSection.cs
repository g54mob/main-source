using System;
using System.Collections.Generic;

[Serializable]
public class TutorialSection
{
	public TutorialManager.TutorialState associatedState;

	public List<DialogSequence> dialogSequences = new List<DialogSequence>();

	public string checkListTitleKey = "";

	public bool autoHideCheckList;

	public List<TutorialChecklistOption> options = new List<TutorialChecklistOption>();

	public TutorialChecklistOption GetCheckListOption(string key)
	{
		return options.Find((TutorialChecklistOption x) => x.checkListTitleKey == key);
	}
}
