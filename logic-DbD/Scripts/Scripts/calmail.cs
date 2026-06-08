using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class calmail : WebsiteDownload
{
	[SerializeField]
	protected TMP_InputField searchInput;

	[SerializeField]
	protected Button searchButton;

	public void GeneratePackagesTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string text = searchInput.text;
		if (!Level8.HasPackage(text))
		{
			FailPopup(Messages.NoPackageFound(text));
			return;
		}
		string text2 = text.Replace(" ", "").ToLowerInvariant();
		string tableName = "packages_" + text2;
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(tableName));
			return;
		}
		Level8.CreatePackagesTable(text, tableName);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
	}
}
