using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBonusLevelSelect : MonoBehaviour
{
	public class LevelButtonPair
	{
		public ThronefallUIElement button;

		public LevelInfo info;

		public LevelButtonPair(ThronefallUIElement _button, LevelInfo _info)
		{
			button = _button;
			info = _info;
		}
	}

	public UIFrame frame;

	public ThronefallUIElement buttonPrefab;

	public Transform buttonParent;

	public TextMeshProUGUI levelTitle;

	public float untertitleSize = 20f;

	public Color crownLocked;

	public Color crownUnlocked;

	private List<LevelButtonPair> levelButtonPairs = new List<LevelButtonPair>();

	public void OnShow()
	{
		UpdateLevelTitle();
		levelButtonPairs.Clear();
		for (int num = buttonParent.childCount - 1; num >= 0; num--)
		{
			Object.Destroy(buttonParent.GetChild(num).gameObject);
		}
		LevelInfo[] levelsToPick = BonusLevelInteractor.lastSelected.levelsToPick;
		foreach (LevelInfo levelInfo in levelsToPick)
		{
			ThronefallUIElement thronefallUIElement = Object.Instantiate(buttonPrefab, buttonParent);
			thronefallUIElement.GetComponent<TextMeshProUGUI>().text = levelInfo.displaySubtitle;
			int num2 = levelInfo.QuestsComplete();
			Transform child = thronefallUIElement.transform.GetChild(0);
			for (int j = 0; j < child.childCount; j++)
			{
				if (j >= num2)
				{
					child.GetChild(j).GetComponent<Image>().color = crownLocked;
				}
				else
				{
					child.GetChild(j).GetComponent<Image>().color = crownUnlocked;
				}
			}
			levelButtonPairs.Add(new LevelButtonPair(thronefallUIElement, levelInfo));
		}
		for (int k = 0; k < levelButtonPairs.Count; k++)
		{
			int num3 = k - 1;
			int num4 = k + 1;
			if (num3 < 0)
			{
				num3 = levelButtonPairs.Count - 1;
			}
			if (num4 > levelButtonPairs.Count - 1)
			{
				num4 = 0;
			}
			levelButtonPairs[k].button.topNav = levelButtonPairs[num3].button;
			levelButtonPairs[k].button.botNav = levelButtonPairs[num4].button;
		}
		frame.firstSelected = levelButtonPairs[0].button;
	}

	public void OnSelectionApplied()
	{
		ThronefallUIElement lastApplied = frame.LastApplied;
		bool flag = false;
		foreach (LevelButtonPair levelButtonPair in levelButtonPairs)
		{
			if (levelButtonPair.button == lastApplied)
			{
				flag = true;
				LevelInteractor.lastActiveLevelInfo = levelButtonPair.info;
				break;
			}
		}
		if (flag)
		{
			UIFrameManager.ForceOpenLevelSelect();
		}
	}

	public void UpdateLevelTitle()
	{
		levelTitle.text = BonusLevelInteractor.lastSelected.baseLevelInfo.LocalizedDisplayName;
		TextMeshProUGUI textMeshProUGUI = levelTitle;
		textMeshProUGUI.text = textMeshProUGUI.text + "\n<size=" + untertitleSize + "><style=Subheader>" + LocalizationManager.GetTermTranslation("Menu/Bonus Modes") + "</size></style>";
	}
}
