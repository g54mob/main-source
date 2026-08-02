using System.Collections.Generic;
using UnityEngine;

public class CustomShapeFill : MonoBehaviour
{
	[SerializeField]
	private List<FillImageData> fillImages = new List<FillImageData>();

	[Range(0f, 1f)]
	public float currentValue;

	private void Start()
	{
		UpdateFill();
	}

	public void UpdateFill()
	{
		foreach (FillImageData fillImage in fillImages)
		{
			if (!(fillImage.image == null))
			{
				float x = fillImage.totalFillData.x;
				float y = fillImage.totalFillData.y;
				if (currentValue < x)
				{
					fillImage.image.fillAmount = 0f;
					continue;
				}
				if (currentValue >= y)
				{
					fillImage.image.fillAmount = 1f;
					continue;
				}
				float num = y - x;
				float value = (currentValue - x) / num;
				fillImage.image.fillAmount = Mathf.Clamp01(value);
			}
		}
	}

	public void SetCurrentValue(float value)
	{
		currentValue = Mathf.Clamp01(value);
		UpdateFill();
	}
}
