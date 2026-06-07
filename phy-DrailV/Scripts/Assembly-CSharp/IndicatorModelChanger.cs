using UnityEngine;

public class IndicatorModelChanger : Indicator
{
	[Tooltip("Ordered list of different models that indicator will switch on/off depending on the indicator value")]
	public GameObject[] indicatorModels;

	[Tooltip("Specific ordered low to high percentages, that tell us when the model switch will occur. Number of switchPercentages should always be indicatorModels.Count - 1, because we have implicit 0 percentage")]
	public float[] switchPercentage;

	private int currentModelIndex;

	private const int MODEL_INDEX_NOT_INITIALIZED = -1;

	private void Awake()
	{
		if (indicatorModels.Length - 1 != switchPercentage.Length)
		{
			Debug.LogError("switchPercentage should have 1 less item than indicatorModels", this);
		}
		GameObject[] array = indicatorModels;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: false);
		}
		currentModelIndex = -1;
		OnValueSet();
	}

	protected override void OnValueSet()
	{
		float normalizedValue = GetNormalizedValue();
		if (normalizedValue == 0f)
		{
			GameObject[] array = indicatorModels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
			currentModelIndex = -1;
			return;
		}
		for (int j = 0; j < switchPercentage.Length; j++)
		{
			if (normalizedValue < switchPercentage[j])
			{
				UpdateCurrentModel(j);
				break;
			}
			if (j == switchPercentage.Length - 1)
			{
				UpdateCurrentModel(j + 1);
			}
		}
	}

	private void UpdateCurrentModel(int newModelIndex)
	{
		int num = currentModelIndex;
		if (num != newModelIndex)
		{
			if (num != -1)
			{
				indicatorModels[num].SetActive(value: false);
			}
			currentModelIndex = newModelIndex;
			indicatorModels[currentModelIndex].SetActive(value: true);
		}
	}
}
