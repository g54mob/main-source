using System;
using UnityEngine;

public class NotificationMacros
{
	private static float posY;

	public static void FTUE()
	{
	}

	private static void FTUE(DateTime reminderDate)
	{
		string title = Te.xt("tid_notification_ftue_t");
		string body = Te.xt("tid_notification_ftue_b2");
		LocalNotifications.singleton.Schedule(title, body, reminderDate);
	}

	public static void UndeadCryptIntro(DateTime treasureAvailableDate)
	{
	}

	public static void LegendQuestUnlock(DateTime unlockDate)
	{
	}

	public static void OfflineFarmingComplete(string locationName, DateTime completionDate)
	{
	}

	public static void SeasonalEventStarting(string eventTitle, string eventBody, DateTime startDate)
	{
		eventTitle = eventTitle.Replace('\n', ' ');
		eventBody = eventBody.Replace('\n', ' ');
		LocalNotifications.singleton.Schedule(eventTitle, eventBody, startDate, autoReschedule: true);
	}

	public static void DebugGUI()
	{
		BeginButtons();
		if (AddButton("Schedule"))
		{
			LocalNotifications.singleton.Schedule("Hello", "World!", DateTime.Now.AddSeconds(10.0));
		}
		if (AddButton("FTUE"))
		{
			FTUE(DateTime.Now.AddSeconds(10.0));
		}
		if (AddButton("Scotty"))
		{
			UndeadCryptIntro(DateTime.Now.AddSeconds(10.0));
		}
		if (AddButton("Legend Quest"))
		{
			LegendQuestUnlock(DateTime.Now.AddSeconds(10.0));
		}
		if (AddButton("Offline Farm"))
		{
			OfflineFarmingComplete("Rocky Plateau", DateTime.Now.AddSeconds(10.0));
		}
	}

	private static void BeginButtons()
	{
		posY = -60f;
	}

	private static bool AddButton(string label)
	{
		posY += 70f;
		return GUI.Button(new Rect(10f, posY, 200f, 65f), label);
	}
}
