using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DogBuilderSlider : MonoBehaviour
{
	public Gene geneRef;

	public Button leftButton;

	public Button rightButton;

	public TextMeshProUGUI choiceText;

	private int maxValue = 1;

	private int currentValue = 1;

	public float GetChoiceValue()
	{
		return (float)(currentValue - 1) / (float)(maxValue - 1);
	}

	public void SetMaxValue(int newValue)
	{
		maxValue = newValue;
		leftButton.onClick.AddListener(delegate
		{
			DecrementValue();
		});
		rightButton.onClick.AddListener(delegate
		{
			IncrementValue();
		});
	}

	public void SetCurrentValue(int newValue)
	{
		currentValue = newValue;
		choiceText.text = currentValue.ToString();
		if (newValue == 1)
		{
			if (geneRef.key == "PatternType")
			{
				choiceText.text = "No Pattern";
			}
			else if (geneRef.key == "TailType")
			{
				choiceText.text = "No Tail";
			}
		}
	}

	private void DecrementValue()
	{
		currentValue--;
		if (currentValue <= 0)
		{
			currentValue = maxValue;
		}
		SetCurrentValue(currentValue);
	}

	private void IncrementValue()
	{
		currentValue++;
		if (currentValue > maxValue)
		{
			currentValue = 1;
		}
		SetCurrentValue(currentValue);
	}
}
