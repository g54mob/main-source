using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class RarityInfoUI : MonoBehaviour
{
	public List<Color> rarityColors = new List<Color>
	{
		Color.gray,
		Color.green,
		Color.blue,
		Color.magenta,
		Color.red
	};

	public Image BgImage;

	public TMP_Text caughtText;

	public SuperTextMesh RarityText;

	public void Setup(Fish fish, RarityData rarityData, bool isSpeciesDiscovered)
	{
		BgImage.color = rarityColors[(int)rarityData.rarity];
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.fishlog.caught.text");
		if (!isSpeciesDiscovered)
		{
			RarityText.text = rarityData.rarity.GetLocalizedText() + " -> ??%";
			if (caughtText != null)
			{
				caughtText.text = localizedString.GetLocalizedString("??");
			}
			return;
		}
		if (fish.isBossFish)
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.unit.percent");
			string text = ((rarityData.rarity == FishRarity.Legendary) ? "100" : "0") + localizedString2.GetLocalizedString();
			RarityText.text = "<c=" + rarityData.rarity.ToString() + "><j>" + rarityData.rarity.GetLocalizedText() + "</c></j> -> " + text;
			if (caughtText != null)
			{
				int catchCount = FishLogManager.Instance.GetCatchCount(fish.speciesName, rarityData.rarity.ToString());
				caughtText.text = localizedString.GetLocalizedString(catchCount);
			}
			return;
		}
		Dictionary<FishRarity, float> levelModifiedRarityWeights = fish.GetLevelModifiedRarityWeights(fish.currentLevel);
		float valueOrDefault = levelModifiedRarityWeights.GetValueOrDefault(rarityData.rarity);
		float num = levelModifiedRarityWeights.Values.Sum();
		float num2 = 0f;
		if (num > 0f)
		{
			num2 = valueOrDefault / num * 100f;
		}
		LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.unit.percent");
		string text2 = num2.ToString("F0") + localizedString3.GetLocalizedString();
		RarityText.text = "<c=" + rarityData.rarity.ToString() + "><j>" + rarityData.rarity.GetLocalizedText() + "</c></j> -> " + text2;
		if (caughtText != null)
		{
			int catchCount2 = FishLogManager.Instance.GetCatchCount(fish.speciesName, rarityData.rarity.ToString());
			caughtText.text = localizedString.GetLocalizedString(catchCount2);
		}
	}
}
