using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FishLogDetailView : MonoBehaviour
{
	[Header("Main Details")]
	public Image mainArtwork;

	public TMP_Text speciesNameText;

	public SuperTextMesh speciesDescriptionText;

	public TMP_Text caughtText;

	[Header("Preferences")]
	public GameObject preferencePrefab;

	public Transform preferenceListParent;

	public TMP_Text baseValueText;

	public TMP_Text levelText;

	public TMP_Text xpText;

	public Image xpBarFill;

	public Shadow artShadow;

	public TMP_Text moneyText;

	[Header("Visuals")]
	public Material silhouetteMaterial;

	[Header("Rarity Details")]
	public GameObject rarityInfoPrefab;

	public Transform rarityListParent;

	private Fish currentlyDisplayedSpecies;

	public void DisplaySpecies(Fish species, FishLogPanel logPanel = null, bool playAnimation = true)
	{
		currentlyDisplayedSpecies = species;
		bool flag = FishLogManager.Instance.HasCaughtSpecies(species.speciesName);
		mainArtwork.transform.DOKill();
		mainArtwork.transform.localScale = Vector3.one;
		if (playAnimation)
		{
			mainArtwork.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f, 4, 0.3f);
			SoundManager.PlaySound("Tooltip_Pop");
		}
		if (species.availableRarities.Count > 0)
		{
			mainArtwork.sprite = species.availableRarities[0].artwork;
		}
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.fishlog.caught.text");
		LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.level.short");
		LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.fishlog.xpbar.text");
		LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.fishlog.baseval.text");
		if (flag)
		{
			mainArtwork.material = null;
			artShadow.enabled = true;
			speciesNameText.text = species.LocalizedName;
			string text = Regex.Replace(species.LocalizedDescription, "\\[(.*?)\\]", "<c=#F0A030>$1</c>");
			speciesDescriptionText.text = text;
			caughtText.text = localizedString.GetLocalizedString(FishLogManager.Instance.GetTotalCatchCountForSpecies(species.speciesName));
			if (species.isBossFish)
			{
				levelText.text = "Lvl --";
				LocalizedString localizedString5 = new LocalizedString("Skills", "#ui.text.defeated");
				xpText.text = localizedString5.GetLocalizedString();
				xpBarFill.DOKill();
				xpBarFill.DOFillAmount(1f, 0.35f).SetEase(Ease.OutCubic);
				RarityData rarityData = species.GetRarityData(FishRarity.Legendary);
				if (rarityData != null)
				{
					baseValueText.text = localizedString4.GetLocalizedString() + " - <color=yellow>" + CurrencyFormatter.FormatMoney(rarityData.value) + "</color>";
				}
				else
				{
					baseValueText.text = localizedString4.GetLocalizedString() + " - ???";
				}
			}
			else
			{
				levelText.text = localizedString2.GetLocalizedString(species.currentLevel);
				xpText.text = localizedString3.GetLocalizedString(species.currentXp, species.GetXpForNextLevel());
				float endValue = (float)species.currentXp / (float)species.GetXpForNextLevel();
				xpBarFill.DOKill();
				xpBarFill.DOFillAmount(endValue, 0.35f).SetEase(Ease.InBack);
				RarityData rarityData2 = species.GetRarityData(FishRarity.Common);
				if (rarityData2 != null)
				{
					baseValueText.text = localizedString4.GetLocalizedString() + " - <color=yellow>" + CurrencyFormatter.FormatMoney(rarityData2.value) + "</color>";
				}
				else
				{
					baseValueText.text = localizedString4.GetLocalizedString() + " - ???";
				}
			}
		}
		else
		{
			LocalizedString localizedString6 = new LocalizedString("Skills", "#ui.fishlog.desc.skeleton");
			mainArtwork.material = silhouetteMaterial;
			artShadow.enabled = false;
			speciesNameText.text = "?????";
			speciesDescriptionText.text = localizedString6.GetLocalizedString();
			caughtText.text = localizedString.GetLocalizedString("??");
			levelText.text = localizedString2.GetLocalizedString("??");
			xpText.text = localizedString3.GetLocalizedString("???", "???");
			xpBarFill.DOKill();
			xpBarFill.DOFillAmount(0f, 0.3f);
			baseValueText.text = localizedString4.GetLocalizedString() + " - ???";
		}
		foreach (Transform item in rarityListParent)
		{
			if (item.gameObject.name != "RarityTitle")
			{
				Object.Destroy(item.gameObject);
			}
		}
		foreach (RarityData availableRarity in species.availableRarities)
		{
			Object.Instantiate(rarityInfoPrefab, rarityListParent).GetComponent<RarityInfoUI>().Setup(species, availableRarity, flag);
		}
		if (!(preferenceListParent != null))
		{
			return;
		}
		foreach (Transform item2 in preferenceListParent)
		{
			Object.Destroy(item2.gameObject);
		}
		if (!flag || species.preferences == null || !(logPanel != null))
		{
			return;
		}
		foreach (FishPreference preference in species.preferences)
		{
			if (preferencePrefab != null)
			{
				FishPreferenceUI component = Object.Instantiate(preferencePrefab, preferenceListParent).GetComponent<FishPreferenceUI>();
				if (component != null)
				{
					Sprite preferenceIcon = logPanel.GetPreferenceIcon(preference.type);
					LocalizedString preferenceDescription = logPanel.GetPreferenceDescription(preference.type);
					LocalizedString strengthFormat = logPanel.GetStrengthFormat(preference.strength);
					component.Setup(preferenceIcon, preference.strength, strengthFormat, preferenceDescription);
				}
			}
		}
	}

	public void RefreshCurrentSpecies(FishLogPanel logPanel = null)
	{
		if (currentlyDisplayedSpecies != null)
		{
			DisplaySpecies(currentlyDisplayedSpecies, logPanel, playAnimation: false);
		}
	}
}
