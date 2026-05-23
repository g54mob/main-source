using TMPro;
using UnityEngine;

public class ModeRulesDisplay : MonoBehaviour
{
	public TextMeshProUGUI rulesDisplay;

	public GameObject modeRulePanel;

	public UIParentResizer sizer;

	public void Refresh()
	{
		LevelInfo levelInfo = null;
		levelInfo = ((!(LevelInteractor.lastActiveLevelInfo != null)) ? LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName() : LevelInteractor.lastActiveLevelInfo);
		if (levelInfo == null)
		{
			modeRulePanel.SetActive(value: false);
		}
		else if (levelInfo.displayModeDescription.Length > 0)
		{
			rulesDisplay.text = "<size=" + 20 + "><style=Subheader>" + levelInfo.displaySubtitle + ":</size></style>\n" + levelInfo.displayModeDescription;
			modeRulePanel.SetActive(value: true);
			sizer.Trigger();
		}
		else
		{
			modeRulePanel.SetActive(value: false);
		}
	}
}
