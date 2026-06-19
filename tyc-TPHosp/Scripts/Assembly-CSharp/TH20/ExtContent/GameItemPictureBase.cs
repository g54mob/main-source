using System.Collections.Generic;
using FullInspector;

namespace TH20.ExtContent
{
	public class GameItemPictureBase : GameItemBase
	{
		public enum PictureBaseItemDataType
		{
			None = 0,
			RoomItem = 1,
			FloorAndWall = 2
		}

		public class GameItemPictureBaseConfig : GameItemBaseConfig
		{
			public int _itemCostDefault = 100;

			public int _itemCostMin;

			public int _itemCostMax = 1000;

			public int _itemCostRoundValue = 10;

			public int _itemKudoshDefault = 10;

			public int _itemKudoshMin;

			public int _itemKudoshMax = 1000;

			public int _itemKudoshRoundValue = 1;

			public float _preferredTextureWidth = 256f;

			public float _preferredTextureHeight = 256f;

			public string _roomItemDefnDebugTag;

			public SharedInstance<RoomItemDefinition> _roomItemDefn;

			public IconGenData _iconGenData;
		}

		public const string cKey_SubTypeID = "SubTypeID";

		public const string cKey_TextureFileName = "TextureFileName";

		public const string cKey_IconFileName = "IconFileName";

		public const string cKey_ItemPrice = "ItemPrice";

		public const string cKey_ItemKudosh = "ItemKudosh";

		private string _itemSubTypeID;

		private string _textureFileName;

		private string _iconFileName;

		private int _itemPrice;

		private int _itemKudosh;

		public string ItemSubTypeID => _itemSubTypeID;

		public string TextureFileName => _textureFileName;

		public string TextureFileSpec => ExtContentUtils.GetPathSpec(base.InstalledFolderPathSpec, _textureFileName);

		public string IconFileName => _iconFileName;

		public string IconFileSpec
		{
			get
			{
				if (_iconFileName.IsNullOrEmpty())
				{
					return string.Empty;
				}
				return ExtContentUtils.GetPathSpec(base.InstalledFolderPathSpec, _iconFileName);
			}
		}

		public int ItemPrice => _itemPrice;

		public int ItemKudosh => _itemKudosh;

		public override void Init(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			base.Init(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public override void DeInit()
		{
			base.DeInit();
		}

		public void SetData(string subTypeID, string textureFileName, string iconOverrideTextureFileName, int price, int kudosh)
		{
			_itemSubTypeID = subTypeID;
			_textureFileName = textureFileName;
			_iconFileName = iconOverrideTextureFileName;
			_itemPrice = price;
			_itemKudosh = kudosh;
			OnDataUpdated();
		}

		public override bool ValidateReadyForDelete(bool bSilent = false)
		{
			bool result = true;
			List<RoomItem> allUGCRoomItemInstancesWithContentID = UGCGameUtils.GetAllUGCRoomItemInstancesWithContentID(base.ContentID);
			if (allUGCRoomItemInstancesWithContentID.Count > 0)
			{
				result = false;
				if (!bSilent)
				{
					ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteFailedMessageTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteFailedMessageBody), allUGCRoomItemInstancesWithContentID.Count));
				}
			}
			return result;
		}

		public override void UpdateMetaData()
		{
			base.UpdateMetaData();
			base.GameItemMetaData.Add("SubTypeID", _itemSubTypeID);
			base.GameItemMetaData.Add("TextureFileName", _textureFileName);
			base.GameItemMetaData.Add("IconFileName", _iconFileName);
			base.GameItemMetaData.Add("ItemPrice", $"{_itemPrice}");
			base.GameItemMetaData.Add("ItemKudosh", $"{_itemKudosh}");
		}

		protected override bool UpdateFromMetaData()
		{
			bool result = false;
			if (base.UpdateFromMetaData())
			{
				base.GameItemMetaData.Get("SubTypeID", ref _itemSubTypeID);
				base.GameItemMetaData.Get("TextureFileName", ref _textureFileName);
				base.GameItemMetaData.Get("IconFileName", ref _iconFileName);
				base.GameItemMetaData.Get("ItemPrice", ref _itemPrice);
				base.GameItemMetaData.Get("ItemKudosh", ref _itemKudosh);
				result = true;
			}
			return result;
		}

		public virtual int GetNumSubTypeIDs()
		{
			return 0;
		}

		public virtual GameItemPictureBaseConfig GetGameItemConfigPictureBase(int index)
		{
			return null;
		}

		public GameItemPictureBaseConfig GetGameItemConfigPictureBaseForSubTypeID()
		{
			GameItemPictureBaseConfig result = null;
			int configIndexForSubTypeID = GetConfigIndexForSubTypeID();
			if (configIndexForSubTypeID >= 0 && configIndexForSubTypeID < GetNumSubTypeIDs())
			{
				result = GetGameItemConfigPictureBase(configIndexForSubTypeID);
			}
			return result;
		}

		public int GetConfigIndexForSubTypeID()
		{
			int result = 0;
			int i = 0;
			for (int numSubTypeIDs = GetNumSubTypeIDs(); i < numSubTypeIDs; i++)
			{
				if (GetGameItemConfigPictureBase(i)._itemConfigTag == ItemSubTypeID)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public override string GetLogInfoString()
		{
			return string.Concat(base.GetLogInfoString() + ", ", string.Format(ExtContentUtils.HiliteParams("SubT:'{0}, 'Txt:'{1}', $:{2}, K:{3}"), _itemSubTypeID, _textureFileName, _itemPrice, _itemKudosh));
		}
	}
}
