using System;
using System.IO;
using UnityEngine;

namespace TH20.ExtContent
{
	public class GameItemDataRoomItemPictureBase : GameItemDataBase
	{
		private GameItemPictureBase.GameItemPictureBaseConfig _config;

		private string _installedFolderPathSpec;

		private string _subTypeID;

		private string _roomItemDefinitionTag;

		private string _textureFileSpec;

		private string _iconFileSpec;

		private int _itemPrice;

		private int _itemKudosh;

		private RoomItemDefinition _roomItemDefinition;

		private RoomItemDefinitionUGC _roomItemDefinitionUGC;

		private GameObject _runtimePrefab;

		private Texture2D _texture2D;

		private Texture2D _texture2DIcon;

		private string _roomItemDefinitionTagActive;

		private RoomItemDefinition _roomItemDefinitionActive;

		private GameObject _runtimePrefabActive;

		private string _textureFileSpecActive;

		private string _iconFileSpecActive;

		private int _itemPriceActive;

		private int _itemKudoshActive;

		private bool _bRuntimePrefabDirty;

		private bool _bRuntimeInstancesDirty;

		private DateTime _loadedFileModTimeMain;

		private DateTime _loadedFileModTimeIcon;

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

		public void SetData(GameItemPictureBase.GameItemPictureBaseConfig config, string contentID, string subTypeID, string textureFileSpec, string iconFileSpec, int itemPrice, int itemKudosh)
		{
			Init(contentID);
			_config = config;
			_subTypeID = subTypeID;
			_textureFileSpec = textureFileSpec;
			_iconFileSpec = iconFileSpec;
			_itemPrice = itemPrice;
			_itemKudosh = itemKudosh;
			_roomItemDefinitionTag = string.Empty;
			if (_config != null)
			{
				_roomItemDefinitionTag = _config._roomItemDefnDebugTag;
			}
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
			if (_roomItemDefinition == null && _roomItemDefinitionUGC == null && !(_runtimePrefab != null) && !(_texture2D != null))
			{
				return _texture2DIcon != null;
			}
			return true;
		}

		public override bool AreAssetsUnloadable()
		{
			return true;
		}

		public override void UnloadAllAssets()
		{
			UGCGameUtils.RemoveUGCRoomItemDefintionFromLists(_roomItemDefinitionUGC);
			if (_runtimePrefab != null)
			{
				UnityEngine.Object.Destroy(_runtimePrefab);
				_runtimePrefab = null;
			}
			_roomItemDefinition = null;
			_roomItemDefinitionUGC = null;
			_texture2D = null;
			_texture2DIcon = null;
		}

		public override void OnLevelLoaded()
		{
			CheckCreateRoomMenuItem();
		}

		private void OnDataUpdated()
		{
			CheckUpdateRoomDefinitionTag();
			CheckUpdateRoomDefinition();
			CheckTextureFilesModTimes();
			CheckUpdateTextureFileSpec();
			CheckUpdateIconFileSpec();
			CheckUpdateTexture2D();
			CheckUpdateTexture2DIcon();
			CheckUpdateRuntimePrefab();
			CheckUpdateCostAndKudosh();
			CheckUpdateRuntimePrefabDirty();
			CheckUpdateRoomItemInstancesDirty();
			CheckCreateRoomMenuItem();
		}

		private bool CheckCreateRoomMenuItem()
		{
			bool result = false;
			if (IsCreateRoomMenuItemDataValid())
			{
				_roomItemDefinitionUGC = UGCGameUtils.CreateRoomItemPictureBase(base.ItemContentID, _roomItemDefinition);
				if (_roomItemDefinitionUGC != null)
				{
					result = true;
				}
			}
			return result;
		}

		private bool IsCreateRoomMenuItemDataValid()
		{
			bool result = false;
			if (_roomItemDefinition != null)
			{
				App app = ExtContentUtils.ExtContentManager.App;
				if (app.Metagame != null && app.Metagame.CurrentLevel != null)
				{
					result = true;
				}
			}
			return result;
		}

		private void CheckUpdateRoomDefinitionTag()
		{
			if (_roomItemDefinitionTag != _roomItemDefinitionTagActive && !_roomItemDefinitionTag.IsNullOrEmpty())
			{
				if (_config != null)
				{
					_roomItemDefinition = _config._roomItemDefn.Instance;
				}
				else
				{
					_roomItemDefinition = UGCGameUtils.GetRoomItemDefinitionForTag(_roomItemDefinitionTag);
				}
				if (_roomItemDefinition != null)
				{
					_roomItemDefinitionTagActive = _roomItemDefinitionTag;
				}
			}
		}

		private void CheckUpdateRoomDefinition()
		{
			if (_roomItemDefinition != _roomItemDefinitionActive)
			{
				_runtimePrefab = UGCGameUtils.CreateRoomItemRuntimePrefab(_roomItemDefinition, base.ItemContentID);
				if (_runtimePrefab != null)
				{
					_roomItemDefinitionActive = _roomItemDefinition;
				}
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

		private void CheckUpdateIconFileSpec()
		{
			if (_iconFileSpec != _iconFileSpecActive && !_iconFileSpec.IsNullOrEmpty())
			{
				_texture2DIcon = null;
				_iconFileSpecActive = _iconFileSpec;
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

		private void CheckUpdateTexture2D()
		{
			if (_texture2D == null && !_textureFileSpec.IsNullOrEmpty())
			{
				_texture2D = ExtContentTextureUtils.LoadTexture2D(_textureFileSpec);
				if (_texture2D != null)
				{
					_loadedFileModTimeMain = File.GetLastWriteTime(_textureFileSpec);
					_bRuntimePrefabDirty = true;
				}
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
					_bRuntimePrefabDirty = true;
				}
			}
		}

		private void CheckUpdateRuntimePrefab()
		{
			if (_runtimePrefab != _runtimePrefabActive)
			{
				_runtimePrefabActive = _runtimePrefab;
				_bRuntimePrefabDirty = true;
			}
		}

		private void CheckUpdateCostAndKudosh()
		{
			if (_itemPrice != _itemPriceActive || _itemKudosh != _itemKudoshActive)
			{
				_bRuntimePrefabDirty = true;
				_itemPriceActive = _itemPrice;
				_itemKudoshActive = _itemKudosh;
			}
		}

		private void CheckUpdateRuntimePrefabDirty()
		{
			if (_bRuntimePrefabDirty)
			{
				UGCGameUtils.SetRuntimePrefabRoomItemPictureBaseData(_runtimePrefab, base.ItemContentID, _texture2D, _texture2DIcon, _itemPrice, _itemKudosh);
				_bRuntimePrefabDirty = false;
				_bRuntimeInstancesDirty = true;
			}
		}

		private void CheckUpdateRoomItemInstancesDirty()
		{
			if (_bRuntimeInstancesDirty && UpdateRoomItemInstances())
			{
				_bRuntimeInstancesDirty = false;
			}
		}

		private bool UpdateRoomItemInstances()
		{
			bool result = false;
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Metagame != null && app.Metagame.CurrentLevel != null)
			{
				foreach (RoomItem item in UGCGameUtils.GetAllUGCRoomItemInstancesWithContentID(base.ItemContentID))
				{
					if (item.Visual != null && item.Visual.GameObject != null)
					{
						UGCGameUtils.ReplaceGameObjectTextures(item.Visual.GameObject, _texture2D);
					}
				}
				result = true;
			}
			return result;
		}
	}
}
