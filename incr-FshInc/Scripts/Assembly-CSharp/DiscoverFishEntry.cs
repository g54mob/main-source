using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverFishEntry : MonoBehaviour
{
	[Header("UI References")]
	public Image fishIcon;

	public Image fishOutline;

	public TMP_Text fishNameText;

	public TMP_Text fishLevelText;

	public TMP_Text fishChanceText;

	[Header("Assets")]
	[Tooltip("Assign your M_Silhouette material here")]
	public Material silhouetteMaterial;

	public void Setup(Fish fishData, float encounterWeight, float totalWeight, bool isDiscovered)
	{
		if (fishData.availableRarities.Count > 0)
		{
			fishIcon.sprite = fishData.availableRarities[0].artwork;
			fishOutline.sprite = fishData.availableRarities[0].artwork;
		}
		float num = encounterWeight / totalWeight * 100f;
		fishChanceText.text = $"{num:F1}%";
		if (isDiscovered)
		{
			fishIcon.material = null;
			fishNameText.text = fishData.speciesName;
			int fishLevel = FishLogManager.Instance.GetFishLevel(fishData.speciesName);
			fishLevelText.text = $"LVL {fishLevel}";
		}
		else
		{
			fishIcon.material = silhouetteMaterial;
			fishNameText.text = "???";
			fishLevelText.text = "LVL ?";
		}
	}
}
