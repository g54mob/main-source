using TMPro;
using UnityEngine;

public class errandboy : WebsiteDownload
{
	[SerializeField]
	private TMP_InputField order;

	[SerializeField]
	private TMP_InputField address;

	[SerializeField]
	private TMP_InputField ccInfo;

	[SerializeField]
	private TMP_InputField notes;

	[SerializeField]
	private string orderNumber;

	private GameObject popup;

	public void GenerateOrderTable()
	{
		if (LevelManager.GetCurrLevel() != 5)
		{
			FailPopup(Messages.OrderDownloadFailed());
			return;
		}
		string tableName = "order_" + orderNumber;
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.OrderAlreadyDownloaded());
			return;
		}
		Level5.CreateOrdersTable(tableName);
		SuccessPopupMessage(notificationPrefab, Messages.OrderDownloadedSuccess());
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}

	public void SubmitOrder()
	{
		string message = ((order.text.Length == 0) ? "Please fill in your order." : ((address.text.Length == 0) ? "Please enter your address." : ((ccInfo.text.Length != 0) ? "Please enter a valid credit card number." : "Please enter your credit card number.")));
		FailPopup(message);
	}
}
