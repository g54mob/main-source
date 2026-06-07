using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceRewardRow : MonoBehaviour
{
	public TextMeshProUGUI descriptionLabel;

	public TextMeshProUGUI scoreLabel;

	public Image scoreImage;

	public List<DiceValueIcon> diceImages;

	public void Awake()
	{
		scoreImage.sprite = IconManager.SpriteForItem(ItemType.UtilityDiceGamePoint);
	}

	public void SetValueTextVisibility(bool visibleState)
	{
		foreach (DiceValueIcon diceImage in diceImages)
		{
			diceImage.valueTextRegion.gameObject.SetActive(visibleState);
		}
	}

	public void SetDiceIndexToValue(int index, int face)
	{
		if (index < diceImages.Count)
		{
			DiceValueIcon diceValueIcon = diceImages[index];
			diceValueIcon.gameObject.SetActive(value: true);
			diceValueIcon.iconImage.sprite = IconManager.SpriteForDiceFace(face);
			TextDisplay.SetNumber(diceValueIcon.valueLabel, MinigamePanelDice.FaceValue(face));
		}
	}

	public void HideDiceAtAndAboveIndex(int index)
	{
		for (int i = index; i < diceImages.Count; i++)
		{
			diceImages[i].gameObject.SetActive(value: false);
		}
	}
}
