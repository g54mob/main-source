using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lzu_syllabus : WebsiteDownload
{
	private class SyllabusDownloaded
	{
		public bool seatingDownloaded;

		public bool attendanceDownloaded;

		public bool scoresDownloaded;
	}

	[SerializeField]
	private UniversityLevel.SuspectClass currentClass;

	[SerializeField]
	private Button seatingButton;

	[SerializeField]
	private Button attendanceButton;

	[SerializeField]
	private Button scoresButton;

	private static Dictionary<UniversityLevel.SuspectClass, SyllabusDownloaded> downloaded = new Dictionary<UniversityLevel.SuspectClass, SyllabusDownloaded>();

	protected override void Start()
	{
		base.Start();
		if (!downloaded.ContainsKey(currentClass))
		{
			downloaded[currentClass] = new SyllabusDownloaded();
		}
		iconGenerator = Object.FindObjectOfType<IconGenerator>();
		if (downloaded[currentClass].attendanceDownloaded)
		{
			UIUtils.SetButtonColorSelected(attendanceButton);
		}
		if (downloaded[currentClass].scoresDownloaded)
		{
			UIUtils.SetButtonColorSelected(scoresButton);
		}
		if (downloaded[currentClass].seatingDownloaded)
		{
			UIUtils.SetButtonColorSelected(seatingButton);
		}
	}

	public void GenerateSeatingTable()
	{
		string seatsTableName = GetSeatsTableName(currentClass);
		if (GenerateTable(seatsTableName))
		{
			HintManager.SetHintState(7, 3);
			UniversityLevel.CreateSeatingTable(currentClass);
			iconGenerator.GenerateDeleteonlyIcon(seatsTableName);
			downloaded[currentClass].seatingDownloaded = true;
			UIUtils.SetButtonColorSelected(seatingButton);
		}
	}

	public void GenerateAttendanceTable()
	{
		string attendanceTableName = GetAttendanceTableName(currentClass);
		if (GenerateTable(attendanceTableName))
		{
			HintManager.SetHintState(7, 3);
			UniversityLevel.CreateAttendanceTable(currentClass);
			iconGenerator.GenerateDeleteonlyIcon(attendanceTableName);
			downloaded[currentClass].attendanceDownloaded = true;
			UIUtils.SetButtonColorSelected(attendanceButton);
		}
	}

	public void GenerateExamScoreTable()
	{
		string scoresTableName = GetScoresTableName(currentClass);
		if (GenerateTable(scoresTableName))
		{
			HintManager.SetHintState(7, 3);
			UniversityLevel.CreateExamTable(currentClass);
			iconGenerator.GenerateDeleteonlyIcon(scoresTableName);
			downloaded[currentClass].scoresDownloaded = true;
			UIUtils.SetButtonColorSelected(scoresButton);
		}
	}

	private bool GenerateTable(string tableName)
	{
		if (LevelManager.GetCurrLevel() != 7)
		{
			FailPopup(Messages.LZUDownloadFailed());
			return false;
		}
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return false;
		}
		SuccessPopup(notificationPrefab, tableName);
		return true;
	}

	public static string GetScoresTableName(UniversityLevel.SuspectClass classType)
	{
		return UniversityLevel.GetClassString(classType) + "_scores";
	}

	public static string GetAttendanceTableName(UniversityLevel.SuspectClass classType)
	{
		return UniversityLevel.GetClassString(classType) + "_attendance";
	}

	public static string GetSeatsTableName(UniversityLevel.SuspectClass classType)
	{
		return UniversityLevel.GetClassString(classType) + "_seats";
	}
}
