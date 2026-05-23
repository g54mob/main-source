using TMPro;
using UnityEngine;

public class LevelNameDisplay : MonoBehaviour
{
	public TextMeshProUGUI levelTitle;

	public bool displaySubtitle;

	public float untertitleSize = 20f;

	public void UpdateLevelTitle()
	{
		LevelInfo levelInfo = null;
		levelInfo = ((!(LevelInteractor.lastActiveLevelInfo != null)) ? LevelProgressManager.instance.GetLevelInfoFromCurrentSceneName() : LevelInteractor.lastActiveLevelInfo);
		if (!(levelInfo == null))
		{
			levelTitle.text = levelInfo.LocalizedDisplayName;
			if (levelInfo.displaySubtitle.Length > 0 && displaySubtitle)
			{
				TextMeshProUGUI textMeshProUGUI = levelTitle;
				textMeshProUGUI.text = textMeshProUGUI.text + "\n<size=" + untertitleSize + "><style=Subheader>" + levelInfo.displaySubtitle + "</size></style>";
			}
		}
	}
}
