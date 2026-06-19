using System;
using System.IO;
using UnityEngine;

namespace TH20.ExtContent
{
	public class GameItemDataFloorAndWall : GameItemDataBase
	{
		private GameItemPictureBase.GameItemPictureBaseConfig _config;

		private string _installedFolderPathSpec;

		private EContentType _contentType;

		private string _subTypeID;

		private string _roomItemDefinitionTag;

		private string _textureFileSpec;

		private string _iconFileSpec;

		private int _itemPrice;

		private int _itemKudosh;

		private Texture2D _texture2D;

		private Texture2D _texture2DIcon;

		private string _textureFileSpecActive;

		private string _iconFileSpecActive;

		private int _itemPriceActive;

		private int _itemKudoshActive;

		private bool _bDefnDataDirty;

		private bool _bLevelFixupPending;

		private DateTime _loadedFileModTimeMain;

		private DateTime _loadedFileModTimeIcon;

		private WallVisualOverrideDefinitionUGC _wallDefinitionUGC;

		private FloorVisualOverrideDefinitionUGC _floorDefinitionUGC;

		public string InstalledFolderPathSpec => _installedFolderPathSpec;

		public Texture2D MainTexture2D => _texture2D;

		public Texture2D IconTexture2D => _texture2DIcon;

		public void Init()
		{
		}

		public void DeInit()
		{
			UnloadAllAssets();
		}

		public void SetData(GameItemPictureBase.GameItemPictureBaseConfig config, string contentID, EContentType contentType, string subTypeID, string textureFileSpec, string iconFileSpec, int itemPrice, int itemKudosh)
		{
			Init(contentID);
			_config = config;
			_contentType = contentType;
			_subTypeID = subTypeID;
			_textureFileSpec = textureFileSpec;
			_iconFileSpec = iconFileSpec;
			_itemPrice = itemPrice;
			_itemKudosh = itemKudosh;
			OnDataUpdated();
		}

		public override bool ReloadAllAssets()
		{
			UnloadAllAssets();
			OnDataUpdated();
			return HaveAssetsBeenLoaded();
		}

		public override bool HaveAssetsBeenLoaded()
		{
			if (!(_texture2D != null))
			{
				return _texture2DIcon != null;
			}
			return true;
		}

		public override bool AreAssetsUnloadable()
		{
			return true;
		}

		private bool IsWall()
		{
			return _contentType == EContentType.Wall;
		}

		private bool IsFloor()
		{
			return _contentType == EContentType.Floor;
		}

		public override void UnloadAllAssets()
		{
			if (IsWall())
			{
				UGCGameUtils.RemoveWallVisualOverrideFromLists(_wallDefinitionUGC);
			}
			else if (IsFloor())
			{
				UGCGameUtils.RemoveFloorVisualOverrideFromLists(_floorDefinitionUGC);
			}
			_wallDefinitionUGC = null;
			_texture2D = null;
			_texture2DIcon = null;
		}

		public override void OnLevelLoaded()
		{
			_bLevelFixupPending = true;
			CheckCreateMenuItem();
			CheckLevelFixupPending();
		}

		private void OnDataUpdated()
		{
			CheckCreateMenuItem();
			CheckLevelFixupPending();
			CheckTextureFilesModTimes();
			CheckUpdateTextureFileSpec();
			CheckUpdateIconFileSpec();
			CheckUpdateTexture2D();
			CheckUpdateTexture2DIcon();
			CheckUpdateCostAndKudosh();
			CheckUpdateDefnData();
		}

		private void CheckCreateMenuItem()
		{
			if (IsCreateMenuItemDataValid())
			{
				if (IsWall())
				{
					_wallDefinitionUGC = UGCGameUtils.CreateWall(base.ItemContentID);
				}
				else if (IsFloor())
				{
					_floorDefinitionUGC = UGCGameUtils.CreateFloor(base.ItemContentID);
				}
			}
		}

		private bool IsCreateMenuItemDataValid()
		{
			bool result = false;
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Metagame != null && app.Metagame.CurrentLevel != null)
			{
				result = true;
			}
			return result;
		}

		private void CheckLevelFixupPending()
		{
			if (!_bLevelFixupPending)
			{
				return;
			}
			if (IsWall())
			{
				if (_wallDefinitionUGC != null && UGCGameUtils.PerformWallLevelFixups(_wallDefinitionUGC))
				{
					_bLevelFixupPending = false;
				}
			}
			else if (IsFloor() && _floorDefinitionUGC != null && UGCGameUtils.PerformFloorLevelFixups(_floorDefinitionUGC))
			{
				_bLevelFixupPending = false;
			}
		}

		private void CheckTextureFilesModTimes()
		{
			if (_texture2D != null && File.GetLastWriteTime(_textureFileSpec) > _loadedFileModTimeMain)
			{
				_texture2D = null;
			}
			if (_texture2DIcon != null && File.GetLastWriteTime(_iconFileSpec) > _loadedFileModTimeIcon)
			{
				_texture2DIcon = null;
			}
		}

		private void CheckUpdateTextureFileSpec()
		{
			if (_textureFileSpec != _textureFileSpecActive && !_textureFileSpec.IsNullOrEmpty())
			{
				_texture2D = null;
				_textureFileSpecActive = _textureFileSpec;
			}
		}

		private void CheckUpdateTexture2D()
		{
			if (_texture2D == null && !_textureFileSpec.IsNullOrEmpty())
			{
				_texture2D = ExtContentTextureUtils.LoadTexture2D(_textureFileSpec);
				if (_texture2D != null)
				{
					_loadedFileModTimeMain = File.GetLastWriteTime(_textureFileSpec);
					_bDefnDataDirty = true;
				}
			}
		}

		private void CheckUpdateIconFileSpec()
		{
			if (_iconFileSpec != _iconFileSpecActive && !_iconFileSpec.IsNullOrEmpty())
			{
				_texture2DIcon = null;
				_iconFileSpecActive = _iconFileSpec;
			}
		}

		private void CheckUpdateTexture2DIcon()
		{
			if (_texture2DIcon == null && !_iconFileSpec.IsNullOrEmpty())
			{
				_texture2DIcon = ExtContentTextureUtils.LoadTexture2D(_iconFileSpec);
				if (_texture2DIcon != null)
				{
					_loadedFileModTimeIcon = File.GetLastWriteTime(_iconFileSpec);
					_bDefnDataDirty = true;
				}
			}
		}

		private void CheckUpdateCostAndKudosh()
		{
			if (_itemPrice != _itemPriceActive || _itemKudosh != _itemKudoshActive)
			{
				_bDefnDataDirty = true;
				_itemPriceActive = _itemPrice;
				_itemKudoshActive = _itemKudosh;
			}
		}

		private void CheckUpdateDefnData()
		{
			if (_bDefnDataDirty)
			{
				if (IsWall())
				{
					UGCGameUtils.SetWallVisualOverrideData(base.ItemContentID, _texture2D, _texture2DIcon, _itemPrice, _itemKudosh);
				}
				else if (IsFloor())
				{
					UGCGameUtils.SetFloorVisualOverrideData(base.ItemContentID, _texture2D, _texture2DIcon, _itemPrice, _itemKudosh);
				}
				_bDefnDataDirty = false;
			}
		}
	}
}
