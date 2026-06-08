using UnityEngine.UI;

public class nimby_button : WebsiteDownload
{
	private string d_tableName;

	protected override void Start()
	{
		base.Start();
		if (LevelManager.GetCurrLevel() == 8)
		{
			string text = base.transform.parent.name;
			string text2 = string.Join("_", text.Split(' '));
			d_tableName = "nimby_sold_" + text2;
			Level8.AddNimbyPurchase(d_tableName, text);
		}
		GetComponent<Button>().onClick.AddListener(delegate
		{
			GeneratePurchaseDetails();
		});
	}

	public void GeneratePurchaseDetails()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		if (DatabaseUtils.ContainsTable(d_tableName))
		{
			FailPopup(Messages.AlreadyDownloaded(d_tableName));
			return;
		}
		Level8.CreateNimbyPurchaseTable(d_tableName);
		iconGenerator.GenerateDeleteonlyIcon(d_tableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(d_tableName));
	}
}
