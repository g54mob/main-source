using System;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
	public static LeaderboardUI Instance;

	public Text title;

	public Text inputText;

	public Text waitingText;

	public Text lbSelectionText;

	public Text changeInputText;

	public Text scopeText;

	public Text totalEntriesText;

	public Text totalEntriesText2;

	public Text timeUntilNextText;

	public LBTable table;

	private DateTime currentDaily;

	private bool canRefresh;

	private GameModeEnum currentGameMode = GameModeEnum.DailyChallenge;

	private bool isFriendsOnly;

	private bool isShowingCurrentData;

	private bool forceRefreshAfterDelay;

	private float timerRefresh;

	private void Awake()
	{
		Instance = this;
		waitingText.gameObject.SetActive(true);
		table.gameObject.SetActive(false);
		totalEntriesText.gameObject.SetActive(false);
		totalEntriesText2.gameObject.SetActive(false);
		timeUntilNextText.gameObject.SetActive(false);
		currentDaily = DateTime.UtcNow;
		Hide();
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void ShowCurrent()
	{
		forceRefreshAfterDelay = true;
		timerRefresh = 2f;
		Show();
	}

	public void Show()
	{
		if (GlobalSettings.ShowDailyLeaderboard)
		{
			GlobalSettings.ShowDailyLeaderboard = false;
			currentGameMode = GameModeEnum.DailyChallenge;
			lbSelectionText.text = "Switch to [W]eekly Leaderboard";
		}
		else if (GlobalSettings.ShowWeeklyLeaderboard)
		{
			GlobalSettings.ShowWeeklyLeaderboard = false;
			currentGameMode = GameModeEnum.WeeklyChallenge;
			lbSelectionText.text = "Switch to [D]aily Leaderboard";
		}
		Show(true);
	}

	public void Show(bool forceRefresh)
	{
		base.gameObject.SetActive(true);
		double value = 0.0;
		double num = 0.0;
		if (currentGameMode == GameModeEnum.DailyChallenge)
		{
			title.text = "Daily Leaderboard - " + currentDaily.ToString("MM/dd/yyyy");
			SteamLeaderboard.RequestLeaderboard(isFriendsOnly, string.Format("DailyLeaderboard{0}", currentDaily.ToString("yyyyMMdd")), title.text, forceRefresh, SteamStatusDelegate);
			value = currentDaily.Subtract(DateTime.UtcNow).TotalDays;
			num = 1.0;
		}
		else if (currentGameMode == GameModeEnum.WeeklyChallenge)
		{
			string weekKey = GetWeekKey();
			string text = weekKey.Substring(0, 4);
			string text2 = weekKey.Substring(4, 2);
			title.text = "Weekly Leaderboard - Week #" + text2 + " of " + text;
			SteamLeaderboard.RequestLeaderboard(isFriendsOnly, string.Format("WeeklyLeaderboard{0}", weekKey), title.text, forceRefresh, SteamStatusDelegate);
			value = currentDaily.Subtract(DateTime.UtcNow).TotalDays;
			num = 7.0;
		}
		if (Math.Abs(value) < 1.0)
		{
			inputText.text = "[R]efresh";
			canRefresh = true;
		}
		else
		{
			inputText.text = "Jump to [C]urrent";
			canRefresh = false;
		}
	}

	public void Hide()
	{
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		bool flag = false;
		bool flag2 = false;
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B))
		{
			if (MainMenu.Instance != null)
			{
				ChallengeMenu.Instance.HideLeaderboard();
			}
		}
		else if (canRefresh && Input.GetKeyDown(KeyCode.R))
		{
			waitingText.gameObject.SetActive(true);
			table.gameObject.SetActive(false);
			totalEntriesText.gameObject.SetActive(false);
			totalEntriesText2.gameObject.SetActive(false);
			timeUntilNextText.gameObject.SetActive(false);
			Show(true);
		}
		else if (currentGameMode == GameModeEnum.DailyChallenge && Input.GetKeyDown(KeyCode.W))
		{
			currentGameMode = GameModeEnum.WeeklyChallenge;
			lbSelectionText.text = "Switch to [D]aily Leaderboard";
			currentDaily = DateTime.UtcNow;
			flag2 = true;
		}
		else if (currentGameMode == GameModeEnum.WeeklyChallenge && Input.GetKeyDown(KeyCode.D))
		{
			currentGameMode = GameModeEnum.DailyChallenge;
			lbSelectionText.text = "Switch to [W]eekly Leaderboard";
			currentDaily = DateTime.UtcNow;
			flag2 = true;
		}
		else if (!isFriendsOnly && Input.GetKeyDown(KeyCode.F))
		{
			isFriendsOnly = true;
			scopeText.text = "Friends Leaderboard";
			changeInputText.text = "[G]lobal Leaderboard";
			flag = true;
		}
		else if (isFriendsOnly && Input.GetKeyDown(KeyCode.G))
		{
			isFriendsOnly = false;
			scopeText.text = "Global Leaderboard";
			changeInputText.text = "[F]riends Leaderboard";
			flag = true;
		}
		else
		{
			if (Input.GetButtonDown("Left"))
			{
				if (currentGameMode == GameModeEnum.DailyChallenge)
				{
					currentDaily = currentDaily.AddDays(-1.0);
				}
				else
				{
					currentDaily = currentDaily.AddDays(-7.0);
				}
				flag = true;
			}
			else if (Input.GetButtonDown("Right"))
			{
				if (currentGameMode == GameModeEnum.DailyChallenge)
				{
					currentDaily = currentDaily.AddDays(1.0);
				}
				else
				{
					currentDaily = currentDaily.AddDays(7.0);
				}
				double totalDays = currentDaily.Subtract(DateTime.UtcNow).TotalDays;
				if (totalDays > 0.0)
				{
					GameAudio.Play2DSFX(GameAudio.SoundEnum.CommandError);
					currentDaily = DateTime.UtcNow;
				}
				else if (totalDays >= -0.001 && totalDays < 1.0)
				{
					flag2 = true;
				}
				else
				{
					flag = true;
				}
			}
			else if (!canRefresh && Input.GetKeyDown(KeyCode.C))
			{
				currentDaily = DateTime.UtcNow;
				flag2 = true;
			}
			if (flag || flag2)
			{
				waitingText.text = "Waiting for Data...";
				waitingText.gameObject.SetActive(true);
				table.Clear();
				table.gameObject.SetActive(false);
				totalEntriesText.gameObject.SetActive(false);
				totalEntriesText2.gameObject.SetActive(false);
				timeUntilNextText.gameObject.SetActive(false);
				Show(flag2);
			}
		}
		if (flag || flag2)
		{
			waitingText.text = "Waiting for Data...";
			waitingText.gameObject.SetActive(true);
			table.Clear();
			table.gameObject.SetActive(false);
			totalEntriesText.gameObject.SetActive(false);
			totalEntriesText2.gameObject.SetActive(false);
			timeUntilNextText.gameObject.SetActive(false);
			forceRefreshAfterDelay = false;
			Show(flag2);
		}
		if (isShowingCurrentData)
		{
			RefreshLBCountDown();
		}
		if (forceRefreshAfterDelay)
		{
			timerRefresh -= Time.deltaTime;
			if (timerRefresh <= 0f)
			{
				forceRefreshAfterDelay = false;
				Show(true);
			}
		}
	}

	private void SteamStatusDelegate(bool success, SteamLeaderboard.ScoreInfo[] scoreInfoArray, int recCount, int totalKnownRecordCount, string titleAtRequest)
	{
		if (success)
		{
			if (title.text == titleAtRequest)
			{
				waitingText.gameObject.SetActive(false);
				table.gameObject.SetActive(true);
				if (totalKnownRecordCount > 0)
				{
					totalEntriesText.gameObject.SetActive(true);
					totalEntriesText.text = string.Format("Total Entries: {0}", totalKnownRecordCount);
					totalEntriesText2.gameObject.SetActive(true);
					totalEntriesText2.text = totalEntriesText.text;
				}
				double totalDays = currentDaily.Subtract(DateTime.UtcNow).TotalDays;
				if (totalDays >= -0.001 && totalDays < 1.0)
				{
					timeUntilNextText.gameObject.SetActive(true);
					isShowingCurrentData = true;
					RefreshLBCountDown();
				}
				else
				{
					isShowingCurrentData = false;
				}
				Instance.table.RefreshRows(scoreInfoArray, recCount);
			}
		}
		else
		{
			waitingText.text = "No Data Available for this Period";
		}
	}

	public string GetWeekKey()
	{
		CalendarWeekRule rule = CalendarWeekRule.FirstFullWeek;
		DayOfWeek firstDayOfWeek = DayOfWeek.Sunday;
		Calendar calendar = Thread.CurrentThread.CurrentCulture.Calendar;
		int weekOfYear = calendar.GetWeekOfYear(currentDaily, rule, firstDayOfWeek);
		int num = currentDaily.Year;
		if (weekOfYear == 52 && currentDaily.Month == 1)
		{
			num--;
		}
		else if (weekOfYear == 1 && currentDaily.Month == 12)
		{
			num++;
		}
		return string.Format("{0:0000}{1:00}", num, weekOfYear);
	}

	private DateTime GetNextWeekDate()
	{
		CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstFullWeek;
		DayOfWeek dayOfWeek = DayOfWeek.Sunday;
		Calendar calendar = Thread.CurrentThread.CurrentCulture.Calendar;
		DateTime time = calendar.AddWeeks(DateTime.UtcNow, 1);
		DayOfWeek dayOfWeek2 = calendar.GetDayOfWeek(time);
		int num = time.Day;
		int num2 = time.Month;
		int num3 = time.Year;
		switch (dayOfWeek2)
		{
		case DayOfWeek.Monday:
			num--;
			goto default;
		case DayOfWeek.Tuesday:
			num -= 2;
			goto default;
		case DayOfWeek.Wednesday:
			num -= 3;
			goto default;
		case DayOfWeek.Thursday:
			num -= 4;
			goto default;
		case DayOfWeek.Friday:
			num -= 5;
			goto default;
		case DayOfWeek.Saturday:
			num -= 6;
			goto default;
		default:
			if (num < 1)
			{
				num2--;
				if (num2 < 1)
				{
					num2 = 12;
					num3--;
				}
				int num4 = DateTime.DaysInMonth(num3, num2);
				num4 += num;
				num = num4;
			}
			break;
		case DayOfWeek.Sunday:
			break;
		}
		return new DateTime(num3, num2, num, 0, 0, 0);
	}

	private void RefreshLBCountDown()
	{
		TimeSpan timeSpan = default(TimeSpan);
		if (currentGameMode == GameModeEnum.DailyChallenge)
		{
			DateTime dateTime = DateTime.UtcNow.AddDays(1.0);
			DateTime dateTime2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
			timeSpan = dateTime2 - DateTime.UtcNow;
		}
		else
		{
			DateTime nextWeekDate = GetNextWeekDate();
			timeSpan = nextWeekDate - DateTime.UtcNow;
		}
		timeUntilNextText.text = string.Format("Next Challenge: {0:00}:{1:00}:{2:00}:{3:00}", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
	}
}
