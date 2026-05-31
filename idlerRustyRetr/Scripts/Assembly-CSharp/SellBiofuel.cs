using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellBiofuel : MonoBehaviour
{
	private int multiplierIndex;

	[SerializeField]
	private List<int> multiplierValues;

	[SerializeField]
	private TMP_Text multiplierText;

	[SerializeField]
	private AudioClip purchaseAudio;

	public void IncreaseMultiplier(bool increase)
	{
		if (increase)
		{
			multiplierIndex++;
		}
		else
		{
			multiplierIndex--;
		}
		if (multiplierIndex <= 0)
		{
			multiplierIndex = 0;
		}
		if (multiplierIndex >= multiplierValues.Count - 1)
		{
			multiplierIndex = multiplierValues.Count - 1;
		}
		multiplierText.text = multiplierValues[multiplierIndex].ToString();
	}

	public void ConvertBiofuel()
	{
		Sell(multiplierValues[multiplierIndex]);
		GameManager.ins.convertBiofuelTutorial.SetActive(value: false);
		if (!GameManager.ins.convertBiofuelTutorialPlayed)
		{
			GameManager.ins.convertBiofuelTutorialPlayed = true;
		}
	}

	private void Sell(int amount)
	{
		TooltipSystem.HideIcontip();
		if (amount > Inventory.ins.biofuel)
		{
			SoundManager.ins.PlaySound(GameManager.ins.errorAudio);
			return;
		}
		Inventory.ins.AddBiofuel(-amount);
		Inventory.ins.AddSpareParts(amount * GameManager.ins.biofuelToSparePartsRatio);
		SoundManager.ins.PlaySound(purchaseAudio);
	}
}
