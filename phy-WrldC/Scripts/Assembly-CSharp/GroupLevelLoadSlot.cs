using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupLevelLoadSlot : MonoBehaviour
{
	private Toggle toggle;

	private TextMeshProUGUI indexText;

	private TextMeshProUGUI completedText;

	private TextMeshProUGUI starsText;

	private Image background;

	private Image borderIsOn;

	private bool isLevelCompleted;

	private bool isAllBoth;

	private bool isAllGold;

	private bool isAllSilver;

	private string goldCollectableDefaultText;

	private string silverCollectableDefaultText;

	public event Action<LevelModel> OnSlotSelectedEvent;

	public void Initialize()
	{
		toggle = GetComponent<Toggle>();
		indexText = base.transform.FindComponent<TextMeshProUGUI>("IndexText", isRecursively: true);
		completedText = base.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		starsText = base.transform.FindComponent<TextMeshProUGUI>("StarsText", isRecursively: true);
		background = base.transform.FindComponent<Image>("Background", isRecursively: true);
		borderIsOn = base.transform.FindComponent<Image>("BorderIsOn", isRecursively: true);
		toggle.onValueChanged.AddListener(SetToggleStyles);
	}

	public void SetConfiguration(LevelModel levelModel, string levelIndexText, ToggleGroup toggleGroup)
	{
		indexText.SetText(levelIndexText);
		toggle.group = toggleGroup;
		toggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			if (isOn)
			{
				this.OnSlotSelectedEvent?.Invoke(levelModel);
			}
		});
		SetLevelCompleteness(levelModel.IsLevelCompleted);
		SetLevelCollectables(levelModel.IsThereCollectables, levelModel.LevelStatus);
		SetToggleValue(isOn: false);
	}

	public void SetLevelCompleteness(bool isLevelCompleted)
	{
		this.isLevelCompleted = isLevelCompleted;
		completedText.SetText(isLevelCompleted ? "\uf046" : "\uf096");
		completedText.color = (toggle.isOn ? Util.HexToColor("#212224FF") : (isLevelCompleted ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#787878FF")));
	}

	public void SetLevelCollectables(bool isThereCollectables, LevelStatus levelStatus)
	{
		starsText.gameObject.SetActive(isThereCollectables);
		if (isThereCollectables)
		{
			if (levelStatus == null)
			{
				(goldCollectableDefaultText, silverCollectableDefaultText) = Util.GetLevelStarsDefaultIcons(isAllBoth: false, isAllGold: false, isAllSilver: false);
			}
			else
			{
				isAllBoth = levelStatus.AllBothCollectables;
				isAllGold = levelStatus.AllGoldCollectables;
				isAllSilver = levelStatus.AllSilverCollectables;
				(goldCollectableDefaultText, silverCollectableDefaultText) = Util.GetLevelStarsDefaultIcons(isAllBoth, isAllGold, isAllSilver);
			}
			starsText.SetText(goldCollectableDefaultText + silverCollectableDefaultText);
		}
	}

	public void SetToggleValue(bool isOn)
	{
		if (toggle.isOn != isOn)
		{
			toggle.SetValue(isOn);
			SetToggleStyles(isOn);
		}
	}

	private void SetToggleStyles(bool isOn)
	{
		borderIsOn.gameObject.SetActive(isOn);
		indexText.color = (isOn ? Util.HexToColor("#212224FF") : Util.HexToColor("#FFFFFFFF"));
		completedText.color = (isOn ? Util.HexToColor("#212224FF") : (isLevelCompleted ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#787878FF")));
		background.color = (isOn ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#2B2C2EFF"));
		if (starsText.gameObject.activeSelf)
		{
			string text = ((!isOn) ? goldCollectableDefaultText : ((isAllBoth || (isAllGold && !isAllSilver)) ? "<#212224>\uf005" : ((isAllGold && isAllSilver) ? "<#212224>\uf123" : "<#212224>\uf006")));
			string text2 = ((!isOn) ? silverCollectableDefaultText : ((isAllBoth || (!isAllGold && isAllSilver)) ? "<#212224>\uf005" : ((isAllGold && isAllSilver) ? "<#212224>\uf123" : "<#212224>\uf006")));
			starsText.SetText(text + text2);
		}
	}
}
