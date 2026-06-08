using UnityEngine;
using UnityEngine.UI;

public class pizzaslices : WebsiteDownload
{
	[SerializeField]
	private GameObject downloadMenu;

	[SerializeField]
	private GameObject missingMenu;

	[SerializeField]
	private Button menuButton;

	private static bool menuTableGenerated;

	protected override void Start()
	{
		base.Start();
		bool flag = LevelManager.GetCurrLevel() == 4;
		if (flag && menuTableGenerated)
		{
			UIUtils.SetButtonColorSelected(menuButton);
		}
		downloadMenu.SetActive(flag);
		missingMenu.SetActive(!flag);
	}

	public void GenerateMenuTable()
	{
		string tableName = "menu";
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup("You must be starving!\nYou've already downloaded our menu!");
			return;
		}
		SetHint();
		Level4.CreateMenuTable();
		SuccessPopupMessage(notificationPrefab, Messages.MenuDownloadSuccess());
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		menuTableGenerated = true;
		UIUtils.SetButtonColorSelected(menuButton);
	}

	private void SetHint()
	{
		if (LevelManager.GetCurrLevel() == 4)
		{
			if (HintManager.GetQueryState() == 0)
			{
				HintManager.SetQueryState(1);
			}
			else if (HintManager.GetQueryState() == 2)
			{
				HintManager.SetQueryState(3);
			}
		}
	}
}
