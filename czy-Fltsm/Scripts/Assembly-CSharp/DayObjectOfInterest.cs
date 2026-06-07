using System.Text.RegularExpressions;
using UnityEngine;

public class DayObjectOfInterest : INotificationObjectOfInterest, DailyReportPanel.Context, IPanelContext
{
	public GameObject GameObjectOfInterest { get; private set; }

	public ObjectType ObjectOfInterestType => ObjectType.Day;

	public PanelID PanelID => PanelID.DailyReportPanel;

	public int DayIndex { get; private set; }

	public DayObjectOfInterest(int dayIndex)
	{
		DayIndex = dayIndex;
		GameObjectOfInterest = Construction.Townheart.gameObject;
	}

	public void NotificationLeftClick()
	{
		GameManager.UIManager.DisplayPanel(this);
	}

	public string NotificationReplaceVariables(string str)
	{
		return Regex.Replace(str, "%DAY%", (DayIndex + 1).ToString(), RegexOptions.IgnoreCase);
	}

	public bool IsMatch(INotificationObjectOfInterest objectOfInterest)
	{
		if (objectOfInterest.ObjectOfInterestType == ObjectType.Day)
		{
			DayObjectOfInterest dayObjectOfInterest = objectOfInterest as DayObjectOfInterest;
			if (GameObjectOfInterest == objectOfInterest.GameObjectOfInterest)
			{
				return DayIndex == dayObjectOfInterest.DayIndex;
			}
			return false;
		}
		return false;
	}
}
