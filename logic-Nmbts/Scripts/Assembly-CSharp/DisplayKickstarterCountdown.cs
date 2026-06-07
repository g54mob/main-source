using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;

public class DisplayKickstarterCountdown : MonoBehaviour
{
	public UILabel Label;

	private void Update()
	{
		TimeSpan timeSpan = new DateTime(2017, 12, 5, 20, 0, 0, DateTimeKind.Utc) - DateTime.UtcNow;
		Label.text = "";
		if (timeSpan.TotalDays >= 1.0)
		{
			UILabel label = Label;
			label.text = label.text + LabelHelper.KickstarterGreen + timeSpan.Days.ToString("0") + " days ";
		}
		if (timeSpan.TotalHours >= 1.0)
		{
			UILabel label2 = Label;
			label2.text = label2.text + LabelHelper.KickstarterGreen + timeSpan.Hours.ToString("0") + " hours ";
		}
		if (timeSpan.TotalMinutes >= 1.0)
		{
			UILabel label3 = Label;
			label3.text = label3.text + LabelHelper.KickstarterGreen + timeSpan.Minutes.ToString("0") + " min ";
		}
		UILabel label4 = Label;
		label4.text = label4.text + LabelHelper.KickstarterGreen + timeSpan.Seconds.ToString("0") + "s ";
		if (timeSpan.TotalSeconds < 0.0)
		{
			Label.text = "";
		}
	}
}
