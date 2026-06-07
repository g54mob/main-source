using System;
using UnityEngine;

public class DateRangeWindow : MonoBehaviour
{
	public DatePicker FromDate;

	public DatePicker ToDate;

	public GameObject FromPanel;

	public GUIWindow Window;

	public Action<SDateTime, SDateTime> WhenDone;

	public Action<SDateTime> WhenDone2;

	public void Show(SDateTime from, SDateTime to, Action<SDateTime, SDateTime> action)
	{
		Window.Show();
		FromPanel.SetActive(true);
		FromDate.CurrentDate = from;
		ToDate.CurrentDate = to;
		WhenDone = action;
		WhenDone2 = null;
	}

	public void Show(SDateTime to, Action<SDateTime> action)
	{
		Window.Show();
		FromPanel.SetActive(false);
		ToDate.CurrentDate = to;
		WhenDone = null;
		WhenDone2 = action;
	}

	public void ClickOK()
	{
		Action<SDateTime, SDateTime> whenDone = WhenDone;
		if (whenDone != null)
		{
			whenDone(FromDate.CurrentDate, ToDate.CurrentDate);
		}
		Action<SDateTime> whenDone2 = WhenDone2;
		if (whenDone2 != null)
		{
			whenDone2(ToDate.CurrentDate);
		}
		WhenDone = null;
		WhenDone2 = null;
		Window.Close();
	}
}
