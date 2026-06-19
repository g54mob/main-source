namespace TH20.ExtContent
{
	public class GameItemFactory
	{
		public static GameItemBase CreateFolderGameItemCreditsScreen(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemCreditsScreen>(EContentType.CreditsScreen, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemRug(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemRug>(EContentType.Rug, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemPicture(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemRug>(EContentType.Picture, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemSandboxSave(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemSandboxSave>(EContentType.SandboxSave, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemFloor(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemFloor>(EContentType.Floor, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemWall(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemWall>(EContentType.Wall, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateFolderGameItemMusicPack(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			return CreateFolderGameItem<GameItemMusicPack>(EContentType.MusicPack, contentSource, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemCreditsScreen(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemCreditsScreen>(EContentType.CreditsScreen, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemRug(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemRug>(EContentType.Rug, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemPicture(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemPicture>(EContentType.Picture, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemSandboxSave(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemSandboxSave>(EContentType.SandboxSave, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemFloor(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemFloor>(EContentType.Floor, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemWall(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemWall>(EContentType.Wall, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateRawGameItemMusicPack(EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			return CreateRawGameItem<GameItemMusicPack>(EContentType.MusicPack, contentSource, title, description, contentID, installedFolderPathSpec);
		}

		public static GameItemBase CreateTypedGameItem(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec)
		{
			GameItemBase result = null;
			switch (contentType)
			{
			case EContentType.CreditsScreen:
				result = CreateRawGameItem<GameItemCreditsScreen>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.Rug:
				result = CreateRawGameItem<GameItemRug>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.Picture:
				result = CreateRawGameItem<GameItemPicture>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.SandboxSave:
				result = CreateRawGameItem<GameItemSandboxSave>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.Floor:
				result = CreateRawGameItem<GameItemFloor>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.Wall:
				result = CreateRawGameItem<GameItemWall>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			case EContentType.MusicPack:
				result = CreateRawGameItem<GameItemMusicPack>(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
				break;
			}
			return result;
		}

		public static GameItemBase CreateFolderGameItem<T>(EContentType expectedContentType, EContentSourceType contentSource, string installedFolderPathSpec) where T : GameItemBase, new()
		{
			GameItemBase gameItemBase = null;
			GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(installedFolderPathSpec);
			if (gameItemMetaData != null)
			{
				EContentType retContentType = EContentType.None;
				if (GameItemUtils.GetGameItemMetaDataContentType(gameItemMetaData, ref retContentType))
				{
					if (retContentType == expectedContentType)
					{
						string empty = string.Empty;
						string empty2 = string.Empty;
						string empty3 = string.Empty;
						gameItemBase = CreateRawGameItem<T>(retContentType, contentSource, empty, empty2, empty3, installedFolderPathSpec);
						gameItemBase.SetAndUpdateFromMetaData(gameItemMetaData, bDeferDataUpdate: true);
					}
					else
					{
						ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(EMessageType.ExpectedGameItemContentTypeMismatch), ExtContentType.ContentTypeToString(expectedContentType), ExtContentType.ContentTypeToString(retContentType)));
					}
				}
			}
			return gameItemBase;
		}

		public static GameItemBase CreateFolderGameItem(EContentSourceType contentSource, string installedFolderPathSpec)
		{
			GameItemBase result = null;
			GameItemMetaData gameItemMetaData = GameItemUtils.LoadGameItemMetaData(installedFolderPathSpec);
			if (gameItemMetaData != null)
			{
				EContentType retContentType = EContentType.None;
				if (GameItemUtils.GetGameItemMetaDataContentType(gameItemMetaData, ref retContentType))
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					string empty3 = string.Empty;
					GameItemBase gameItemBase = CreateTypedGameItem(retContentType, contentSource, empty, empty2, empty3, installedFolderPathSpec);
					if (gameItemBase.SetAndUpdateFromMetaData(gameItemMetaData, bDeferDataUpdate: true))
					{
						result = gameItemBase;
					}
				}
			}
			return result;
		}

		public static GameItemBase CreateRawGameItem<T>(EContentType contentType, EContentSourceType contentSource, string title, string description, string contentID, string installedFolderPathSpec) where T : GameItemBase, new()
		{
			T val = new T();
			val.Init(contentType, contentSource, title, description, contentID, installedFolderPathSpec);
			return val;
		}
	}
}
