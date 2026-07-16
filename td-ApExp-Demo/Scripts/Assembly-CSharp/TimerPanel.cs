using TMPro;
using UnityEngine;

public class TimerPanel : MonoBehaviour
{
	private TextMeshProUGUI timerText;

	private void Awake()
	{
		timerText = base.transform.Find("TimerText").GetComponent<TextMeshProUGUI>();
	}

	public void SetTimer(int enemyCount, float waveTimer, float timeBetweenWaves)
	{
		if (base.isActiveAndEnabled)
		{
			if (waveTimer <= 0f)
			{
				timerText.text = string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGB(UIManager.Instance.ColorRed), "Enemies Imminent");
				return;
			}
			float time = Mathf.Clamp01(waveTimer / timeBetweenWaves);
			Color color = UIManager.Instance.GradientGYR.Evaluate(time);
			string arg = waveTimer.ToString("N1") + "s";
			string arg2 = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{arg}</color>";
			timerText.text = $"Enemies in {arg2}";
		}
	}
}
