#define LOG_LEVEL_VERBOSE
using FullSerializerSave;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	public class FloorVisualOverrideDefinitionUGC : IFloorVisualOverrideDefinition, ISilverUnlockable
	{
		[fsProperty]
		private string _contentID;

		[DontSave]
		private UGCFloorVisualOverrideDefinitionDatabase _database;

		[DontSave]
		private Sprite _iconSprite;

		[DontSave]
		private GameItemBase _extContentGameItem;

		public GameItemBase ExtContentGameItem => GetExtContentGameItem();

		public ISilverUnlockToken SilverUnlockToken => new UGCSilverUnlockToken(_contentID);

		public Sprite Icon => GetIconSprite();

		public string Name => GetExtContentName();

		public string Description => GetExtContentInGameDescription();

		public string ContentID => _contentID;

		public FloorVisualOverrideDefinitionUGC(string contentID, UGCFloorVisualOverrideDefinitionDatabase ugcFloorVisualOverrideDefinitionDatabase)
		{
			_contentID = contentID;
			_database = ugcFloorVisualOverrideDefinitionDatabase;
		}

		public void RestoreFromSave(UGCFloorVisualOverrideDefinitionDatabase ugcFloorVisualOverrideDefinitionDatabase)
		{
			_database = ugcFloorVisualOverrideDefinitionDatabase;
		}

		public int SilverCost()
		{
			int result = 10;
			if (GetExtContentGameItem() is GameItemPictureBase gameItemPictureBase)
			{
				result = gameItemPictureBase.ItemKudosh;
			}
			return result;
		}

		public LocalisedString GetUnlockName()
		{
			return new LocalisedString(string.Empty);
		}

		public LocalisedString GetUnlockMessage()
		{
			return new LocalisedString(string.Empty);
		}

		public Sprite GetUnlockIcon()
		{
			return Icon;
		}

		public ESandboxCheckType GetSandboxCheckType()
		{
			return ESandboxCheckType.RoomItems;
		}

		public string GetContentID()
		{
			return _contentID;
		}

		public Texture2D GetDiffuseTexture()
		{
			if (_database == null)
			{
				Logging.Error(LogChannels.ExternalContent, "FloorVisualOverrideDefinitionUGC contains a null UGCFloorVisualOverrideDefinitionDatabase!!! Save/load fixup has gone wrong D:");
			}
			if (_database != null && _database.TryGetDiffuseTexture(_contentID, out var texture))
			{
				return texture;
			}
			return null;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC))
			{
				return false;
			}
			if (floorVisualOverrideDefinitionUGC.ContentID == ContentID)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _contentID.GetHashCode();
		}

		private GameItemBase GetExtContentGameItem()
		{
			if (_extContentGameItem == null)
			{
				_extContentGameItem = ExtContentUtils.ExtContentManager.FindGameItemByContentID(_contentID);
			}
			return _extContentGameItem;
		}

		private string GetExtContentName()
		{
			return ExtContentUtils.GetGameItemInGameName(GetExtContentGameItem());
		}

		private Sprite GetIconSprite()
		{
			return ExtContentUtils.GetPictureBaseGameItemInGameIconSprite(GetExtContentGameItem());
		}

		private string GetExtContentInGameDescription()
		{
			return ExtContentUtils.GetGameItemInGameDescription(GetExtContentGameItem());
		}
	}
}
