using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class lzairlines_departures : WebsiteDownload
{
	public static string TABLE_NAME = "flights";

	[SerializeField]
	protected TMP_InputField searchInput;

	[SerializeField]
	protected Button searchButton;

	protected override void Start()
	{
		base.Start();
		GetComponent<PlayerInput>().actions["Enter"].performed += delegate
		{
			if (searchInput.text.Length > 0 && searchInput.isFocused)
			{
				SearchFlightNumber();
			}
		};
	}

	public void GenerateFlightsTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string tABLE_NAME = TABLE_NAME;
		if (DatabaseUtils.ContainsTable(tABLE_NAME))
		{
			FailPopup(Messages.AlreadyDownloaded(tABLE_NAME));
			return;
		}
		Level8.CreateFlightsTable(tABLE_NAME);
		iconGenerator.GenerateDeleteonlyIcon(tABLE_NAME);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(tABLE_NAME));
	}

	public void CheckEnableSearch()
	{
		searchButton.interactable = searchInput.text.Length > 0;
	}

	public void SearchFlightNumber()
	{
		if (searchInput.text.Length == 0)
		{
			FailPopup("Please enter a valid flight number.");
			return;
		}
		int num = int.Parse(searchInput.text);
		if (Level8.GetFlight(num) == null)
		{
			FailPopup($"Cannot find flight with flight number: {num}");
		}
		else
		{
			LaunchInnerSite($"lzairlines.com/checkin/{num}");
		}
	}
}
