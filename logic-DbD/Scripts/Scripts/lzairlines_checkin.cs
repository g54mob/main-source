using TMPro;
using UnityEngine;

public class lzairlines_checkin : WebsiteDownload
{
	[SerializeField]
	private TextMeshProUGUI flightNum;

	[SerializeField]
	private TextMeshProUGUI destination;

	[SerializeField]
	private TextMeshProUGUI date;

	[SerializeField]
	private TextMeshProUGUI time;

	[SerializeField]
	private GameObject checkinPrompt;

	[SerializeField]
	private GameObject flightDeparted;

	public const string URL = "lzairlines.com/checkin/";

	private const int TODAY = 19980704;

	private static int currentFlightNum;

	private string FormatIntTime(int time)
	{
		if (time < 10)
		{
			return $"00:0{time}";
		}
		if (time < 60)
		{
			return $"00:{time}";
		}
		string arg = ((time < 1000) ? "0" : "");
		int num = time / 100;
		int num2 = time % 100;
		if (num2 < 10)
		{
			return $"{arg}{num}:0{num2}";
		}
		return $"{arg}{num}:{num2}";
	}

	private string FormatIntDate(int date)
	{
		int num = date % 100;
		date /= 100;
		int num2 = date % 100;
		date /= 100;
		int num3 = date;
		return string.Format("{0}/{1}{2}/{3}{4}", num3, (num2 < 10) ? "0" : "", num2, (num < 10) ? "0" : "", num);
	}

	public override bool LoadPage(string url)
	{
		currentFlightNum = int.Parse(url.Substring("lzairlines.com/checkin/".Length));
		Flight flight = Level8.GetFlight(currentFlightNum);
		if (flight == null)
		{
			return false;
		}
		bool flag = flight.date < 19980704;
		checkinPrompt.SetActive(!flag);
		flightDeparted.SetActive(flag);
		flightNum.text = $"Flight #{flight.flight_number}";
		destination.text = flight.departing + " to " + flight.arriving;
		date.text = FormatIntDate(flight.date);
		time.text = FormatIntTime(flight.time);
		return true;
	}

	public void DownloadSeatMap()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string tableName = GetTableName(currentFlightNum);
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		Level8.CreateSeatMapTable(currentFlightNum);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
	}

	public static string GetTableName(int flightNumber)
	{
		return $"seats_{flightNumber}";
	}
}
