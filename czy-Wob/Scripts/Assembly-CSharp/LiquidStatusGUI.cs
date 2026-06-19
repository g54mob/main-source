using UnityEngine;
using UnityEngine.UI;

public class LiquidStatusGUI : WorldSpaceBillboard
{
	public Image timerGraphic;

	public GameObject timerHolder;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		timerHolder.SetActive(value: false);
	}

	public void UpdateTimer(float percentage)
	{
		timerGraphic.fillAmount = percentage;
	}

	public void HideTimer()
	{
		timerHolder.SetActive(value: false);
	}

	public void ShowTimer()
	{
		timerHolder.SetActive(value: true);
	}
}
