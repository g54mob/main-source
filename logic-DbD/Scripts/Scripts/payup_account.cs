using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class payup_account : WebsiteDownload
{
	public const string URL = "payup.com/pay/";

	public static string ACCOUNTS_NAME = "payupAccounts";

	[SerializeField]
	private GameObject profileNotFoundObject;

	[SerializeField]
	private GameObject profileFoundObject;

	[SerializeField]
	private TextMeshProUGUI payupName;

	[SerializeField]
	private Image profileImage;

	private static string thisAccount;

	protected override void Start()
	{
		base.Start();
		iconGenerator = Object.FindObjectOfType<IconGenerator>();
	}

	public override bool LoadPage(string url)
	{
		thisAccount = url.Substring("payup.com/pay/".Length);
		if (!WikiLevel.ContainsAccount(thisAccount))
		{
			ProfileFound(found: false);
			return true;
		}
		ProfileFound(found: true);
		payupName.text = thisAccount;
		profileImage.sprite = GetProfileImage();
		return true;
	}

	private void ProfileFound(bool found)
	{
		profileNotFoundObject.SetActive(!found);
		profileFoundObject.SetActive(found);
	}

	public void DownloadHistory()
	{
		if (LevelManager.GetCurrLevel() != 6)
		{
			FailPopup(Messages.PayupDownloadError());
			return;
		}
		string tableName = GetTableName(thisAccount);
		if (DatabaseUtils.ContainsTable(tableName))
		{
			FailPopup(Messages.PayupDownloadFailed(thisAccount));
			return;
		}
		SetHintState();
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tableName));
		WikiLevel.CreatePayupAccountTable(thisAccount);
		iconGenerator.GenerateDeleteonlyIcon(tableName);
	}

	private void SetHintState()
	{
		if (thisAccount == "goldtooth")
		{
			HintManager.SetHintState(6, 3);
		}
		else if (thisAccount == "sefrgswrg")
		{
			HintManager.SetHintState(6, 4);
		}
		else if (thisAccount == "jmeister")
		{
			HintManager.SetHintState(6, 8);
		}
	}

	public static string GetTableName(string accountName)
	{
		return "payup_" + accountName;
	}

	public Sprite GetProfileImage()
	{
		Sprite image = ResourcesManager.GetImage("Website UI/payme/profiles/" + thisAccount);
		if (image == null)
		{
			image = ResourcesManager.GetImage("Website UI/payme/profiles/default");
		}
		return image;
	}
}
