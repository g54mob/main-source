using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lzu_hwk : WebsiteDownload
{
	[SerializeField]
	private Image q1;

	[SerializeField]
	private Image q2;

	[SerializeField]
	private Image q3;

	[SerializeField]
	private UniversityLevel.SuspectClass currentClass;

	[SerializeField]
	private Button hwkQuestion;

	private static Dictionary<UniversityLevel.SuspectClass, bool> downloaded = new Dictionary<UniversityLevel.SuspectClass, bool>();

	protected override void Start()
	{
		base.Start();
		if (!downloaded.ContainsKey(currentClass))
		{
			downloaded[currentClass] = false;
		}
		if (downloaded[currentClass])
		{
			UIUtils.SetButtonColorSelected(hwkQuestion);
		}
		string text = "";
		switch (currentClass)
		{
		case UniversityLevel.SuspectClass.Economics:
			text = "economics";
			break;
		case UniversityLevel.SuspectClass.Science:
			text = "science";
			break;
		case UniversityLevel.SuspectClass.Philosophy:
			text = "philosophy";
			break;
		}
		string text2 = "Website UI/lzu-" + text + "/multiple choice ";
		if (UniversityLevel.SUSPECT_CLASS == currentClass)
		{
			q1.sprite = ResourcesManager.GetImage(text2 + "1 correct");
			q2.sprite = ResourcesManager.GetImage(text2 + "2 correct");
			q3.sprite = ResourcesManager.GetImage(text2 + "3 correct");
		}
		else if (UniversityLevel.CLOSE_CLASS == currentClass)
		{
			q1.sprite = ResourcesManager.GetImage(text2 + "1 correct");
			q2.sprite = ResourcesManager.GetImage(text2 + "2 correct");
			q3.sprite = ResourcesManager.GetImage(text2 + "3");
		}
		else
		{
			q1.sprite = ResourcesManager.GetImage(text2 + "1");
			q2.sprite = ResourcesManager.GetImage(text2 + "2");
			q3.sprite = ResourcesManager.GetImage(text2 + "3 correct");
		}
	}

	public void GenerateHomeworkTable()
	{
		if (LevelManager.GetCurrLevel() != 7)
		{
			FailPopup(Messages.LZUDownloadFailed());
			return;
		}
		string tableName = UniversityLevel.GetClassString(currentClass) + "_hwk";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		switch (currentClass)
		{
		case UniversityLevel.SuspectClass.Economics:
			UniversityLevel.CreateEconomicsTable();
			break;
		case UniversityLevel.SuspectClass.Science:
			UniversityLevel.CreateScienceTable();
			break;
		case UniversityLevel.SuspectClass.Philosophy:
			UniversityLevel.CreatePhilosophyTable();
			break;
		}
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopup(notificationPrefab, tableName);
		downloaded[currentClass] = true;
		UIUtils.SetButtonColorSelected(hwkQuestion);
	}
}
