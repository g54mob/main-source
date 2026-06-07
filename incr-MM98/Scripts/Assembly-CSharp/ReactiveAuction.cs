using ObservableCollections;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ReactiveAuction : MonoBehaviour
{
	[SerializeField]
	private TMP_Text availableChestsText;

	[SerializeField]
	private SegmentedLoadingBar nextChestLoadingBar;

	[SerializeField]
	private TMP_Text currentItemName;

	[SerializeField]
	private LocalizeStringHandler currentItemValue;

	[SerializeField]
	private LocalizedString noItemLocalized;

	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private AuctionLogEntry entryPrefab;

	private readonly RingBuffer<AuctionLogEntry> _pool = new RingBuffer<AuctionLogEntry>(11);

	private void Start()
	{
		InitializeAuctionLog();
		Database.State.Auction.AvailableLootchests.SubscribeToText(availableChestsText).AddTo(this);
		Database.State.Auction.TimeNextLootchest.SubscribeToLoadingBar(nextChestLoadingBar).AddTo(this);
		Database.State.Auction.CurrentLootItem.Subscribe(HandleCurrentLootItem).AddTo(this);
	}

	private void InitializeAuctionLog()
	{
		for (int i = 0; i < 11; i++)
		{
			AuctionLogEntry auctionLogEntry = Object.Instantiate(entryPrefab, entryParent);
			auctionLogEntry.gameObject.SetActive(value: false);
			_pool.AddLast(auctionLogEntry);
		}
		Database.State.Auction.AuctionLog.CreateView<AuctionLogEntry>(AppendMessage).AddTo(this);
	}

	private AuctionLogEntry AppendMessage(AuctionLogMessage message)
	{
		AuctionLogEntry auctionLogEntry = _pool.RemoveFirst();
		auctionLogEntry.Setup(message);
		auctionLogEntry.gameObject.SetActive(value: true);
		auctionLogEntry.transform.SetAsLastSibling();
		_pool.AddLast(auctionLogEntry);
		return auctionLogEntry;
	}

	private void HandleCurrentLootItem(LootItem? loot)
	{
		currentItemName.SetText(loot.HasValue ? loot.Value.Name : noItemLocalized.GetLocalizedString());
		currentItemValue.SetValue(loot?.Value ?? 0.0);
		currentItemValue.gameObject.SetActive(loot.HasValue);
	}
}
