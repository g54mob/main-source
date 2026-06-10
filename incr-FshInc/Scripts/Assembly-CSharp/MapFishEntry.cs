using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapFishEntry : MonoBehaviour
{
	[Header("UI References")]
	[Tooltip("The Image component for the fish icon.")]
	public Image iconImage;

	[Tooltip("The Text component for the fish name.")]
	public TMP_Text nameText;

	[Tooltip("The Text component for the fish level.")]
	public TMP_Text levelText;

	[Tooltip("The Image component that fills up based on XP.")]
	public Image xpBarFill;

	[Tooltip("The parent object of the XP bar (to hide it when undiscovered).")]
	public GameObject xpBarContainer;

	[Header("Undiscovered Settings")]
	public string unknownName = "???";

	public Color silhouetteColor = Color.black;

	public Material silhouetteMaterial;

	public void Setup(Fish fish, bool isDiscovered)
	{
		if (fish == null)
		{
			return;
		}
		Sprite sprite = null;
		RarityData rarityData = fish.GetRarityData(FishRarity.Common);
		if (rarityData != null)
		{
			sprite = rarityData.artwork;
		}
		else if (fish.availableRarities != null && fish.availableRarities.Count > 0)
		{
			sprite = fish.availableRarities[0].artwork;
		}
		if (iconImage != null)
		{
			iconImage.sprite = sprite;
		}
		if (isDiscovered)
		{
			if ((bool)nameText)
			{
				nameText.text = fish.speciesName;
			}
			if ((bool)levelText)
			{
				levelText.text = $"Lvl {fish.currentLevel}";
			}
			if ((bool)xpBarContainer)
			{
				xpBarContainer.SetActive(value: true);
			}
			if ((bool)xpBarFill)
			{
				int xpForNextLevel = fish.GetXpForNextLevel();
				float fillAmount = ((xpForNextLevel > 0) ? ((float)fish.currentXp / (float)xpForNextLevel) : 1f);
				xpBarFill.fillAmount = fillAmount;
			}
			if ((bool)iconImage)
			{
				iconImage.material = null;
				iconImage.color = Color.white;
			}
		}
		else
		{
			if ((bool)nameText)
			{
				nameText.text = unknownName;
			}
			if ((bool)levelText)
			{
				levelText.text = "";
			}
			if ((bool)xpBarContainer)
			{
				xpBarContainer.SetActive(value: false);
			}
			if ((bool)iconImage)
			{
				iconImage.material = silhouetteMaterial;
				iconImage.color = silhouetteColor;
			}
		}
	}
}
