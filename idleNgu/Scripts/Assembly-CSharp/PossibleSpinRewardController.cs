using UnityEngine;
using UnityEngine.UI;

public class PossibleSpinRewardController : MonoBehaviour
{
	public Character character;

	public Text[] rewardTexts;

	public Image[] rewardRarityBG;

	public void updateList()
	{
		for (int i = 0; i < rewardTexts.Length; i++)
		{
			if (i >= character.dailyController.rewardNames[character.dailyController.currentTier()].Count)
			{
				rewardTexts[i].text = "";
				rewardRarityBG[i].color = Color.white;
			}
			else
			{
				rewardTexts[i].text = character.dailyController.rewardNames[character.dailyController.currentTier()][i];
				rewardRarityBG[i].color = rarityColor(character.dailyController.rewardRarity[character.dailyController.currentTier()][i]);
			}
		}
	}

	public Color rarityColor(int id)
	{
		switch (id)
		{
		case 0:
			return Color.white;
		case 1:
			return new Color(0.6f, 0.851f, 0.917f);
		case 2:
			return new Color(1f, 0.682f, 0.788f);
		case 3:
			return new Color(0.784f, 0.749f, 0.906f);
		case 4:
			return new Color(1f, 0.827f, 0.235f);
		default:
			return Color.white;
		}
	}
}
