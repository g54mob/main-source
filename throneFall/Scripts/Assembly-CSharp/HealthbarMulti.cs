using UnityEngine;

public class HealthbarMulti : Healthbar
{
	[SerializeField]
	private int segments = 10;

	[SerializeField]
	private Transform lifes;

	public override void UpdateDisplay()
	{
		float fillAmount = target.HpPercentage * (float)segments % 1f;
		_ = target.HpPercentage * (float)segments % 1f;
		int num = Mathf.FloorToInt(target.HpPercentage / (1f / (float)segments));
		for (int i = 0; i < lifes.childCount; i++)
		{
			lifes.GetChild(i).gameObject.SetActive(num > i);
		}
		if (target.invulnerable)
		{
			fillAmount = 1f;
		}
		if (target.HpPercentage == 1f)
		{
			canvasParent.SetActive(value: false);
			base.enabled = false;
			hpLast = 1f;
			delayedFill.fillAmount = hpLast;
		}
		else
		{
			canvasParent.SetActive(value: true);
			base.enabled = true;
		}
		fill.fillAmount = fillAmount;
		if (Mathf.Approximately(fill.fillAmount, 0f))
		{
			delayedFill.color = deathFillColor;
		}
		else
		{
			delayedFill.color = defaultDelayedFillColor;
		}
	}
}
