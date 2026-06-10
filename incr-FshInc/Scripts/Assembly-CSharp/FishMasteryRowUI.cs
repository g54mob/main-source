using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FishMasteryRowUI : MonoBehaviour
{
	[Header("Visual References")]
	public Image fishIcon;

	public TMP_Text mainText;

	public SuperTextMesh levelUpSuperText;

	public Image xpBarImage;

	public CanvasGroup rowCanvasGroup;

	public void Setup(CaughtFish fish, int oldLevel, int newLevel, float xpPercent)
	{
		fishIcon.sprite = fish.artwork;
		string localizedName = fish.fish.LocalizedName;
		if (newLevel > oldLevel)
		{
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.up");
			levelUpSuperText.text = "<c=rainbow><w> " + localizedString.GetLocalizedString();
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.level.short");
			mainText.text = $"{localizedName} {localizedString2.GetLocalizedString(oldLevel)} -> {newLevel}";
			if (levelUpSuperText != null)
			{
				levelUpSuperText.gameObject.SetActive(value: true);
			}
		}
		else
		{
			LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.text.level.short");
			mainText.text = localizedName + " " + localizedString3.GetLocalizedString(newLevel);
			if (levelUpSuperText != null)
			{
				levelUpSuperText.gameObject.SetActive(value: false);
			}
		}
		xpBarImage.fillAmount = xpPercent;
		rowCanvasGroup.alpha = 0f;
	}

	public void AnimateIn()
	{
		rowCanvasGroup.DOFade(1f, 0.3f);
		base.transform.DOScale(1f, 0.3f).From(0.9f).SetEase(Ease.OutBack);
	}
}
