using TMPro;
using UnityEngine;

public class DaytimeDisplay : MonoBehaviour
{
	public TextMeshProUGUI display;

	private void Update()
	{
		if ((bool)DayNightCycle.Instance)
		{
			display.text = DayNightCycle.Instance.CurrentTimestate.ToString();
		}
	}
}
