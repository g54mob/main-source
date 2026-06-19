using System.Collections.Generic;
using Steamworks;

namespace TH20.ExtContent
{
	public class WorkshopInstalledItem
	{
		private WorkshopItemDetail _itemDetail;

		public List<GameItemBase> _gameItems;

		public WorkshopItemDetail ItemDetail => _itemDetail;

		public List<GameItemBase> GameItems => _gameItems;

		public string Title => _itemDetail.Title;

		public EContentType ContentType => _itemDetail.ContentType;

		public string ContentTypeString => _itemDetail.ContentTypeString;

		public PublishedFileId_t PublishedFileId => _itemDetail.PublishedFileId;

		public void Init(WorkshopItemDetail itemDetail)
		{
			SetItemDetail(itemDetail);
		}

		public void DeInit()
		{
			DeInitGameItems();
			_itemDetail = null;
		}

		private void SetItemDetail(WorkshopItemDetail itemDetail, bool bIsInitialItemDetail = false, bool bCheckUpdateMetaDataFileFromFile = true)
		{
			_itemDetail = itemDetail;
			_itemDetail.CheckReadInstalledItemMetaDataFile();
			InitGameItems();
		}

		public void UpdateItemDetail(WorkshopItemDetail itemDetail)
		{
			_itemDetail = itemDetail;
			_itemDetail.CheckReadInstalledItemMetaDataFile();
			CheckUpdateGameItems();
		}

		private void InitGameItems()
		{
			DeInitGameItems();
			if (!_itemDetail.InstalledInfoValid)
			{
				return;
			}
			_gameItems = new List<GameItemBase>();
			GameItemUtils.ScanFoldersForGameItems(EContentSourceType.Workshop, _itemDetail.InstalledFolderPathSpec, ref _gameItems);
			foreach (GameItemBase gameItem in _gameItems)
			{
				gameItem.ProcessOnDataUpdatedPending();
			}
			UpdateGameItemsLastUpdateTime(_itemDetail.GetGameItemUpdateTime());
			UpdateGameItemsPublishedDataRefs();
		}

		private void DeInitGameItems()
		{
			if (_gameItems == null)
			{
				return;
			}
			foreach (GameItemBase gameItem in _gameItems)
			{
				gameItem.DeInit();
			}
			_gameItems.Clear();
			_gameItems = null;
		}

		private bool CheckUpdateGameItems()
		{
			bool flag = false;
			int num = 0;
			List<GameItemMetaData> retGameItemsMetaData = null;
			if (GameItemUtils.ScanFoldersForGameItemMetaData(_itemDetail.InstalledFolderPathSpec, ref retGameItemsMetaData))
			{
				flag = true;
				foreach (GameItemMetaData item in retGameItemsMetaData)
				{
					bool flag2 = false;
					string contentID = string.Empty;
					if (item.Get("ContentID", ref contentID))
					{
						ExtContentSourceType.EnsureValidSourceTypePrefix(EContentSourceType.Workshop, ref contentID);
						GameItemBase gameItemBase = _gameItems.Find((GameItemBase item) => item.ContentID == contentID);
						if (gameItemBase != null)
						{
							long value = 0L;
							if (item.Get("LastUpdatedTimeStamp", ref value) && value > gameItemBase.LastUpdatedTimeStamp && gameItemBase.SetAndUpdateFromMetaData(item, bDeferDataUpdate: false))
							{
								flag2 = true;
								num++;
							}
						}
						else
						{
							gameItemBase = GameItemFactory.CreateFolderGameItem(EContentSourceType.Workshop, item.InstalledFolderPathSpec);
							if (gameItemBase != null)
							{
								_gameItems.Add(gameItemBase);
								num++;
								flag2 = true;
							}
						}
						gameItemBase.PublishedWorkshopMetaData = ItemDetail.WorkshopMetaData;
					}
					if (!flag2)
					{
						flag = false;
					}
				}
			}
			if (flag && num > 0)
			{
				UpdateGameItemsLastUpdateTime(_itemDetail.GetGameItemUpdateTime());
			}
			return flag;
		}

		private bool UpdateGameItemsPublishedDataRefs()
		{
			bool result = true;
			foreach (GameItemBase gameItem in _gameItems)
			{
				gameItem.PublishedWorkshopMetaData = ItemDetail.WorkshopMetaData;
			}
			return result;
		}

		private bool UpdateGameItemsLastUpdateTime(long gameItemUpdateTime)
		{
			bool flag = false;
			foreach (GameItemBase gameItem in _gameItems)
			{
				if (gameItem.LastUpdatedTimeStamp != gameItemUpdateTime)
				{
					gameItem.LastUpdatedTimeStamp = gameItemUpdateTime;
					if (!gameItem.UpdateMetaDataFile(bSetLastUpdateTimeToNow: false))
					{
						flag = true;
					}
				}
			}
			return !flag;
		}

		public string GetLogInfoString()
		{
			string empty = string.Empty;
			return $"{empty}, {_itemDetail.GetLogInfoString()}";
		}
	}
}
