using System.Collections.Generic;
using UnityEngine;

public class broker : WebsiteDownload
{
	public class StockTickers
	{
		public static string ALIN = "ALIN";

		public static string LZAR = "LZAR";

		public static string MAIL = "MAIL";

		public static string CLWN = "CLWN";

		public static string PYUP = "PYUP";

		public static string NMBY = "NMBY";

		public static string WTHR = "WTHR";

		public static string SPRT = "SPRT";
	}

	[SerializeField]
	private GameObject START;

	[SerializeField]
	private GameObject LZAR;

	[SerializeField]
	private GameObject ALIN;

	[SerializeField]
	private GameObject MAIL;

	[SerializeField]
	private GameObject CLWN;

	[SerializeField]
	private GameObject PYUP;

	[SerializeField]
	private GameObject NMBY;

	[SerializeField]
	private GameObject WTHR;

	[SerializeField]
	private GameObject SPRT;

	private Dictionary<string, GameObject> stockInfoPanels;

	private static string currentActive = "NONE";

	protected override void Start()
	{
		base.Start();
		stockInfoPanels = new Dictionary<string, GameObject>
		{
			{ "NONE", START },
			{
				StockTickers.LZAR,
				LZAR
			},
			{
				StockTickers.ALIN,
				ALIN
			},
			{
				StockTickers.MAIL,
				MAIL
			},
			{
				StockTickers.CLWN,
				CLWN
			},
			{
				StockTickers.PYUP,
				PYUP
			},
			{
				StockTickers.NMBY,
				NMBY
			},
			{
				StockTickers.WTHR,
				WTHR
			},
			{
				StockTickers.SPRT,
				SPRT
			}
		};
		StockSelected(currentActive, playSound: false);
	}

	public void StockSelected(string stockName)
	{
		StockSelected(stockName, playSound: true);
	}

	public void StockSelected(string stockName, bool playSound)
	{
		if (playSound)
		{
			PlaySearch();
		}
		foreach (string key in stockInfoPanels.Keys)
		{
			stockInfoPanels[key].SetActive(stockName == key);
		}
		currentActive = stockName;
	}

	public void GeneratePriceHistoryTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string priceTableName = GetPriceTableName(currentActive);
		if (DatabaseUtils.ContainsTable(priceTableName))
		{
			FailPopup(Messages.AlreadyDownloaded(priceTableName));
			return;
		}
		Level8.CreatePriceTable(currentActive, priceTableName);
		iconGenerator.GenerateDeleteonlyIcon(priceTableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(priceTableName));
	}

	public void GenerateTransactionHistoryTable()
	{
		if (LevelManager.GetCurrLevel() != 8)
		{
			FailPopup(Messages.GenericDownloadFailed());
			return;
		}
		string transactionTableName = GetTransactionTableName(currentActive);
		if (DatabaseUtils.ContainsTable(transactionTableName))
		{
			FailPopup(Messages.AlreadyDownloaded(transactionTableName));
			return;
		}
		Level8.CreateTransactionsTable(currentActive, transactionTableName);
		iconGenerator.GenerateDeleteonlyIcon(transactionTableName);
		SuccessPopupMessage(notificationPrefab, Messages.SuccessfullyDownloaded(transactionTableName));
	}

	public static string GetTransactionTableName(string ticker)
	{
		return ticker.ToLowerInvariant() + "_trans";
	}

	public static string GetPriceTableName(string ticker)
	{
		return ticker.ToLowerInvariant() + "_prices";
	}
}
