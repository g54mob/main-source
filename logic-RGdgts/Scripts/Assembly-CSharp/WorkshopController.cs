using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Steamworks;
using UI.Common;
using UnityEngine;

public class WorkshopController : Controller
{
	public delegate void OnItemPublishedDelegate(SerializedGadgetMetaData metadata, bool success, WorkshopItemPublishResult result);

	public delegate void OnItemUnpublishedDelegate(SerializedGadgetMetaData metadata, bool success);

	public delegate void OnQueryCompletedDelegate(bool success, WorkshopQueryResult result);

	public delegate void OnItemDownloadedDelegate(ulong publishedFileId, bool success, WorkshopItemDownloadedResult result);

	public delegate void OnItemSubscribedDelegate(bool success);

	public delegate void OnGadgetSubscribedDelegate(SerializedGadgetMetaData metadata, bool success);

	public delegate void OnItemUnsubscribedDelegate(bool success);

	public delegate void OnGadgetUnsubscribedDelegate(SerializedGadgetMetaData metadata, bool success);

	public delegate void OnItemVotedDelegate(bool success);

	public delegate void OnItemUserVoteDetailsDelegate(bool success, bool? vote);

	public enum ItemQueryResult
	{
		Ok = 0,
		ItemNotFound = 1,
		ConnectionError = 2
	}

	public delegate void OnItemQueryCompletedDelegate(ItemQueryResult result, WorkshopItemDetails itemDetail);

	public enum Sorting
	{
		None = 0,
		Date = 1,
		Alphabetical = 2,
		Subscriptions = 3,
		Likes = 4
	}

	public class WorkshopQueryResult
	{
		public uint totalQueryResultsCount;

		public WorkshopItemDetails[] items;
	}

	public class WorkshopItemDetails
	{
		public ulong authorSteamId;

		public ulong publishedFileId;

		public string previewUrl;

		public string title;

		public string description;

		public DateTime publishedDate;

		public DateTime updateDate;

		public EItemState itemState;

		public string[] tags;

		public uint votesUp;

		public uint votesDown;

		public float positiveVotesRatio;

		public bool wasUnpublished;
	}

	public class WorkshopItemPublishResult
	{
		public ulong publishedFileId;

		public bool userNeedsToAcceptLegalAgreement;
	}

	public class WorkshopItemDownloadedResult
	{
		public ulong publishedFileId;
	}

	public class WorkshopGadgetMetadata : SerializedGadgetMetaData
	{
		public string previewUrl;

		public bool wasUnpublished;

		protected WorkshopGadgetMetadata(WorkshopItemDetails itemDetail)
		{
		}

		public override void RequestCompleteData(Action<SerializedGadgetMetaData> onComplete)
		{
		}

		public void FillData(byte[] data)
		{
		}

		public override GadgetWorkshopStates GetWorkshopState()
		{
			return default(GadgetWorkshopStates);
		}

		public static SerializedGadgetMetaData Get(WorkshopItemDetails itemDetail)
		{
			return null;
		}
	}

	private class WorkshopRequest<T>
	{
		private CallResult<T> callResult;

		public WorkshopRequest(SteamAPICall_t callHandle, CallResult<T>.APIDispatchDelegate onComplete)
		{
		}
	}

	public int previewWidth;

	public int previewHeight;

	public Texture2D previewBackgroundTexture;

	private HashSet<ulong> unpublishedFileId;

	private OnItemPublishedDelegate _itemPublishedHandler;

	private OnItemUnpublishedDelegate _itemUnpublishedHandler;

	private OnItemVotedDelegate _itemVotedHandler;

	private OnItemUserVoteDetailsDelegate _itemUserVoteDetailsHandler;

	private Callback<ItemInstalled_t> _itemInstalled;

	private Callback<DownloadItemResult_t> _downloadItemResult;

	private Callback<RemoteStoragePublishedFileSubscribed_t> _remoteStoragePublishedFileSubscribed;

	private Callback<RemoteStoragePublishedFileUnsubscribed_t> _remoteStoragePublishedFileUnsubscribed;

	private CallResult<CreateItemResult_t> OnCreateGadgetItemResultCallResult;

	private CallResult<SubmitItemUpdateResult_t> OnSubmitItemUpdateResultCallResult;

	private CallResult<SetUserItemVoteResult_t> OnRemoteStorageUpdateUserPublishedItemVoteCallResult;

	private CallResult<GetUserItemVoteResult_t> OnRemoteStorageUserVoteDetailsCallResult;

	private CallResult<DeleteItemResult_t> OnDeleteItemResultCallResult;

	private SerializedGadgetMetaData _uploadingGadgetMetaData;

	private SerializedGadgetMetaData _unpublishGadgetMetaData;

	private ulong votingItemId;

	private const int _metaDataFields = 3;

	private UGCQueryHandle_t _UGCQueryHandle;

	private PublishedFileId_t _publishedFileId;

	private UGCUpdateHandle_t _UGCUpdateHandle;

	private const string _gadgetTag = "Gadget";

	private Queue<(WorkshopGadgetMetadata, Action<WorkshopGadgetMetadata>)> fillMetadataRequestes;

	private Coroutine fillMetadataRequestCoroutine;

	public event OnItemDownloadedDelegate onItemDownloadedEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public override void Init()
	{
	}

	public void GetGadgetItemDetail(OnItemQueryCompletedDelegate onComplete, ulong fileId)
	{
	}

	public void GetAllGadgetItems(OnQueryCompletedDelegate onComplete, string searchText, Sorting sorting, uint page, IEnumerable<string> tags = null)
	{
	}

	public void GetSubscribedGadgetItems(OnQueryCompletedDelegate onComplete, string searchText, Sorting sorting, uint page = 1u, IEnumerable<string> tags = null)
	{
	}

	public PublishedFileId_t[] GetAllSubscribedGadgetItems()
	{
		return null;
	}

	public void PublishGadget(SerializedGadgetMetaData metaData, OnItemPublishedDelegate handler)
	{
	}

	public void UnpublishGadget(SerializedGadgetMetaData metaData, OnItemUnpublishedDelegate handler)
	{
	}

	public void SubscribeGadget(SerializedGadgetMetaData metaData, OnGadgetSubscribedDelegate handler)
	{
	}

	public void UnsubscribeGadget(SerializedGadgetMetaData metaData, OnItemUnsubscribedDelegate handler)
	{
	}

	public void VoteGadget(SerializedGadgetMetaData metaData, OnItemVotedDelegate handler, bool voteUp)
	{
	}

	public void GetGadgetVote(SerializedGadgetMetaData metaData, OnItemUserVoteDetailsDelegate handler)
	{
	}

	public bool IsItemNeedInstalled(ulong publishedFileId)
	{
		return false;
	}

	public bool DoesSubscribedItemNeedUpdating(ulong publishedFileId)
	{
		return false;
	}

	public bool IsItemSubscribed(ulong publishedFileId)
	{
		return false;
	}

	public bool IsItemDownloading(ulong publishedFileId)
	{
		return false;
	}

	public bool PrioritizeItemDownload(ulong publishedFileId)
	{
		return false;
	}

	public Texture2D GenerateWorkshopPreview(ArchiveController.GadgetPreview preview)
	{
		return null;
	}

	public bool IsPublishInProgress(SerializedGadgetMetaData metadata)
	{
		return false;
	}

	private void Update()
	{
	}

	private IEnumerator DoFillMetadataRequest((WorkshopGadgetMetadata, Action<WorkshopGadgetMetadata>) request)
	{
		return null;
	}

	protected void FillGadgetMetadata(WorkshopGadgetMetadata metadata, Action<WorkshopGadgetMetadata> onComplete)
	{
	}

	private void SubscribeItem(ulong publishedFileId, OnItemSubscribedDelegate onComplete)
	{
	}

	private void UnsubscribeItem(ulong publishedFileId, OnItemUnsubscribedDelegate onComplete)
	{
	}

	private void VoteItem(ulong publishedFileId, OnItemVotedDelegate handler, bool voteUp)
	{
	}

	private void GetItemVote(ulong publishedFileId, OnItemUserVoteDetailsDelegate handler)
	{
	}

	private void UpdatePublishedGadgetItem(ulong publishedFileId)
	{
	}

	private static EItemState GetItemState(ulong publishedFileId)
	{
		return default(EItemState);
	}

	public static string GetLocalFilePathForItem(ulong publishedFileId)
	{
		return null;
	}

	public bool GetDownloadInfoForItem(ulong publishedFileId, out float percentual)
	{
		percentual = default(float);
		return false;
	}

	public bool GetUpdateProgress(out float percentual)
	{
		percentual = default(float);
		return false;
	}

	private void OnRemoteStorageSubscribePublishedFileResult(RemoteStorageSubscribePublishedFileResult_t pCallback, bool bIOFailure, OnItemSubscribedDelegate onComplete)
	{
	}

	private void OnRemoteStorageUnsubscribePublishedFileResult(RemoteStorageUnsubscribePublishedFileResult_t pCallback, bool bIOFailure, OnItemUnsubscribedDelegate onComplete)
	{
	}

	private void OnRemoteStorageUpdateUserPublishedItemVoteResult(SetUserItemVoteResult_t pCallback, bool bIOFailure)
	{
	}

	private void OnRemoteStorageUserVoteDetailsResult(GetUserItemVoteResult_t pCallback, bool bIOFailure)
	{
	}

	private void OnSteamUGCQueryCompleted(SteamUGCQueryCompleted_t pCallback, bool bIOFailure, OnQueryCompletedDelegate onComplete)
	{
	}

	private void OnCreateGadgetItemResult(CreateItemResult_t pCallback, bool bIOFailure)
	{
	}

	private void OnSubmitItemUpdateResult(SubmitItemUpdateResult_t pCallback, bool bIOFailure)
	{
	}

	private void OnDeleteItemResult(DeleteItemResult_t pCallback, bool bIOFailure)
	{
	}

	private void OnItemSubscribed(RemoteStoragePublishedFileSubscribed_t pCallback)
	{
	}

	private void OnItemUnsubscribed(RemoteStoragePublishedFileUnsubscribed_t pCallback)
	{
	}

	private void OnItemInstalled(ItemInstalled_t pCallback)
	{
	}

	private void OnDownloadItemResult(DownloadItemResult_t pCallback)
	{
	}

	private WorkshopItemDetails ParseDetails(SteamUGCDetails_t details, UGCQueryHandle_t UGCQueryHandle, uint index)
	{
		return null;
	}
}
