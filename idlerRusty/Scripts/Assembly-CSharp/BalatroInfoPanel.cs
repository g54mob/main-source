using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalatroInfoPanel : MonoBehaviour
{
	[SerializeField]
	private TMP_Text extraInfoText;

	[SerializeField]
	private Image jokerCardImage;

	private void Start()
	{
		SetBlank();
	}

	private bool isBalatroCrossover()
	{
		if (SaveData.ins.checkIfCrossover(out var crossover))
		{
			return crossover == CrossoverFarmType.Balatro;
		}
		return false;
	}

	public void SetInfo(House house)
	{
		if (isBalatroCrossover() && !(house.balatroJokerEffect == ""))
		{
			extraInfoText.text = LocalizationSystem.GetLocalizedValue(house.balatroJokerEffect);
			jokerCardImage.sprite = house.balatroJokerImage;
			base.gameObject.SetActive(value: true);
		}
	}

	public void SetBlank()
	{
		extraInfoText.text = "";
		base.gameObject.SetActive(value: false);
	}
}
