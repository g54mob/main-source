using UnityEngine;

public class TimeAdvancementButton : CoreButton
{
	public GameObject tooltipRef;

	private void Awake()
	{
		tooltipRef.SetActive(value: false);
	}

	private void Update()
	{
		if (isLarge)
		{
			ShowTooltip();
		}
		else
		{
			HideTooltip();
		}
	}

	public void HideTooltip()
	{
		tooltipRef.SetActive(value: false);
	}

	public void ShowTooltip()
	{
		tooltipRef.SetActive(value: true);
	}
}
