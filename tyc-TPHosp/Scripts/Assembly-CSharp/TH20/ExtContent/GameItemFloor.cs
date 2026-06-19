namespace TH20.ExtContent
{
	[DontSave]
	public class GameItemFloor : GameItemPictureBase
	{
		public class GameItemFloorConfig : GameItemPictureBaseConfig
		{
		}

		private GameItemDataFloorAndWall _floorAndWallDataPictureBase;

		public override void Init(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			base.Init(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
			_floorAndWallDataPictureBase = new GameItemDataFloorAndWall();
			_floorAndWallDataPictureBase.Init();
		}

		public override void DeInit()
		{
			_floorAndWallDataPictureBase?.DeInit();
			_floorAndWallDataPictureBase = null;
			base.DeInit();
		}

		public override void OnDataUpdated()
		{
			base.OnDataUpdated();
			_floorAndWallDataPictureBase.SetData(GetGameItemConfigPictureBaseForSubTypeID(), base.ContentID, base.ContentType, base.ItemSubTypeID, base.TextureFileSpec, base.IconFileSpec, base.ItemPrice, base.ItemKudosh);
		}

		public override GameItemDataBase GetGameItemDataBase()
		{
			return _floorAndWallDataPictureBase;
		}

		public override int GetNumSubTypeIDs()
		{
			return ExtContentUtils.ExtContentManager.Config.ExtContentConfig.Instance._configFloors.Length;
		}

		public override GameItemPictureBaseConfig GetGameItemConfigPictureBase(int index)
		{
			return ExtContentUtils.ExtContentManager.Config.ExtContentConfig.Instance._configFloors[index].Instance;
		}
	}
}
