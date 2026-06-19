namespace TH20.ExtContent
{
	[DontSave]
	public class GameItemPicture : GameItemPictureBase
	{
		public class GameItemPictureConfig : GameItemPictureBaseConfig
		{
		}

		private GameItemDataRoomItemPictureBase _roomItemDataPictureBase;

		public override void Init(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			base.Init(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
			_roomItemDataPictureBase = new GameItemDataRoomItemPictureBase();
			_roomItemDataPictureBase.Init();
		}

		public override void DeInit()
		{
			_roomItemDataPictureBase?.DeInit();
			_roomItemDataPictureBase = null;
			base.DeInit();
		}

		public override void OnDataUpdated()
		{
			base.OnDataUpdated();
			_roomItemDataPictureBase.SetData(GetGameItemConfigPictureBaseForSubTypeID(), base.ContentID, base.ItemSubTypeID, base.TextureFileSpec, base.IconFileSpec, base.ItemPrice, base.ItemKudosh);
		}

		public override GameItemDataBase GetGameItemDataBase()
		{
			return _roomItemDataPictureBase;
		}

		public override int GetNumSubTypeIDs()
		{
			return ExtContentUtils.ExtContentManager.Config.ExtContentConfig.Instance._configPictures.Length;
		}

		public override GameItemPictureBaseConfig GetGameItemConfigPictureBase(int index)
		{
			return ExtContentUtils.ExtContentManager.Config.ExtContentConfig.Instance._configPictures[index].Instance;
		}
	}
}
