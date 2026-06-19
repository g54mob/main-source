using System;
using System.Collections.Generic;
using System.IO;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	[DontSave]
	public class ExtContentGameItemUIScreen : MonoBehaviour
	{
		public class Configuration
		{
			public string _screenTitle;

			public bool _bCreateNewItem;

			public bool _bAllowAmendContentType;

			public bool _bAllowAmendContentSubType;

			public EContentType _initialContentType;

			public List<EContentType> _allowedContentTypes;

			public GameItemBase _updateGameItem;
		}

		public class GameItemUIData
		{
			public EContentType _contentType;

			public string _title;

			public string _description;

			public string _contentSubType;

			public ExtContentImageSpec _mainImageSpec;

			public ExtContentImageSpec _iconImageSpec;

			public DateTime _mainImageModTime;

			public DateTime _iconImageModTime;

			public bool _bIsPictureBaseItemType;

			public int _itemPrice;

			public int _itemPriceMin;

			public int _itemPriceMax;

			public int _itemPriceDefault;

			public int _itemPriceRoundValue;

			public int _itemKudosh;

			public int _itemKudoshMin;

			public int _itemKudoshMax;

			public int _itemKudoshDefault;

			public int _itemKudoshRoundValue;

			public int _itemIconVariationIndex;

			public List<MusicPackSourceItem> _musicPackSourceItems;

			public List<ExtContentUIMusicItemRow> _musicPackItemRows;

			public ExtContentUIMusicItemRow _musicPackAddNewItemButtonRow;

			public DynamicPlaylistUITrackProgressPanel _trackProgressPanel;

			public bool _bMusicPackItemDecodeFatalErrorMsgShown;

			public string _artistName;

			public string _songTitle;

			public string _artistNameOriginal;

			public string _songTitleOriginal;

			public int _currentMusicPackItemIndex;

			public bool _bMusicItemRowDragModeOn;

			public List<string> _contentSubTypeItems;

			public List<string> _contentSubTypeItemsLoc;

			public Dictionary<string, string> _contentSubTypeItemDisplayNamesLoc;

			public GameItemUIData()
			{
				_contentSubTypeItems = new List<string>();
				_contentSubTypeItemsLoc = new List<string>();
				_contentSubTypeItemDisplayNamesLoc = new Dictionary<string, string>();
				_mainImageSpec = new ExtContentImageSpec();
				_iconImageSpec = new ExtContentImageSpec();
				_musicPackSourceItems = new List<MusicPackSourceItem>();
				_musicPackItemRows = new List<ExtContentUIMusicItemRow>();
				_itemIconVariationIndex = -1;
			}

			public void UpdateGameItemDataFrom(GameItemUIData other)
			{
				_contentType = other._contentType;
				_title = other._title;
				_description = other._description;
				_contentSubType = other._contentSubType;
				_itemPrice = other._itemPrice;
				_itemKudosh = other._itemKudosh;
				_mainImageSpec.UpdateFrom(other._mainImageSpec);
				_iconImageSpec.UpdateFrom(other._iconImageSpec);
			}

			public bool IsGameItemdataEqualTo(GameItemUIData other)
			{
				bool result = false;
				if (_contentType == other._contentType && _title == other._title && _description == other._description && _contentSubType == other._contentSubType && _itemPrice == other._itemPrice && _itemKudosh == other._itemKudosh && _mainImageSpec.IsEqualTo(other._mainImageSpec) && _iconImageSpec.IsEqualTo(other._iconImageSpec))
				{
					result = true;
				}
				return result;
			}
		}

		public delegate void OnUIScreenClosedCallback(GameItemBase gameItem);

		public const bool _bAllowBlankDescriptions = true;

		[SerializeField]
		private DynamicButton _buttonCloseMenu;

		[SerializeField]
		private DynamicButton _buttonCreateUpdate;

		[SerializeField]
		private DynamicButton _buttonPublish;

		[SerializeField]
		private DynamicButton _buttonDelete;

		[SerializeField]
		private DynamicButton _buttonSteamWorkshop;

		[SerializeField]
		private DynamicButton _buttonCostSliderIncrement;

		[SerializeField]
		private DynamicButton _buttonCostSliderDecrement;

		[SerializeField]
		private DynamicButton _buttonKudoshSliderIncrement;

		[SerializeField]
		private DynamicButton _buttonKudoshSliderDecrement;

		[SerializeField]
		private TooltipSpawner _tooltipMainEditModeButton;

		[SerializeField]
		private TooltipSpawner _tooltipIconEditModeButton;

		[SerializeField]
		private GameObject _gameObjectMainPanel;

		[SerializeField]
		private GameObject _gameObjectContentTypeAndSubTypePanel;

		[SerializeField]
		private GameObject _gameObjectItemTitlePanel;

		[SerializeField]
		private GameObject _gameObjectItemDescriptionPanel;

		[SerializeField]
		private GameObject _gameObjectSongTitleDisablePanel;

		[SerializeField]
		private GameObject _gameObjectArtistNameDisablePanel;

		[SerializeField]
		private GameObject _gameObjectContentTypeDropDown;

		[SerializeField]
		private TMP_Dropdown _dropdownContentType;

		[SerializeField]
		private TMP_Text _textContentTypeDropDownValue;

		[SerializeField]
		private GameObject _gameObjectContentSubTypeDropDown;

		[SerializeField]
		private TMP_Dropdown _dropdownContentSubType;

		[SerializeField]
		private TMP_Text _textContentSubTypeLabel;

		[SerializeField]
		private TMP_Text _textContentSubTypeDropDownValue;

		[SerializeField]
		private TMP_Text _textRecommendedResolution;

		[SerializeField]
		private GameObject[] _gameObjectContentTypePanel;

		[SerializeField]
		private GameObject _gameObjectCostSliderDarken;

		[SerializeField]
		private GameObject _gameObjectKudoshSliderDarken;

		[SerializeField]
		private GameObject _gameObjectSubTypeDarken;

		[SerializeField]
		private float _disabledTextUIElementAlphaValue;

		[SerializeField]
		private InputField _inputTitle;

		[SerializeField]
		private InputField _inputDescription;

		[SerializeField]
		private InputField _inputMusicPackName;

		[SerializeField]
		private InputField _inputSongTitle;

		[SerializeField]
		private InputField _inputArtistName;

		[SerializeField]
		private TMP_Text _textScreenTitle;

		[SerializeField]
		private TMP_Text _textPreviewIconValue;

		[SerializeField]
		private TMP_Text _textPreviewTitle;

		[SerializeField]
		private Image _imageIconTexturePreview;

		[SerializeField]
		private Image _imageIconTexturePreviewDefault;

		[SerializeField]
		private Slider _sliderCost;

		[SerializeField]
		private Slider _sliderKudosh;

		[SerializeField]
		private TMP_Text _textSliderCost;

		[SerializeField]
		private TMP_Text _textSliderKudosh;

		[SerializeField]
		private GameObject _prefabMusicItemRow;

		[SerializeField]
		private GameObject _gameObjectMusicItemsContent;

		[SerializeField]
		private DynamicButton _buttonAddMusicItem;

		[SerializeField]
		private DynamicButton _buttonMusicItemMoveUp;

		[SerializeField]
		private DynamicButton _buttonMusicItemMoveDown;

		[SerializeField]
		private LocalisedString _locTextAddMusicItem;

		[SerializeField]
		private DynamicPlaylistScrollRect _scrollRectMusicPackContents;

		[SerializeField]
		private TMP_Text _textPlaybackProgress;

		[SerializeField]
		private GameObject _gameObjectTrackProgressPanelParent;

		[SerializeField]
		private GameObject _prefabTrackProgressPanel;

		[SerializeField]
		private ExtContentUISelectableImage _selectableImageMainTexture;

		[SerializeField]
		private ExtContentUISelectableImage _selectableImageIconTexture;

		private ExtContentSourceLocalMods _contentSourceLocalMods;

		private ExtContentUIManager _uiManager;

		private ExtContentUIManager.ExtContentUIManagerConfig _uiManagerConfig;

		private ExtContentConfig _extContentConfig;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private Transform _parentUITransform;

		private Transform _invokingSiblingUITransform;

		private bool _bIsShown;

		private bool _bIsInitialising;

		private bool _bAreEventsRegistered;

		private bool _bHidePending;

		private bool _bGameItemDataValid;

		private bool _bGameItemDataDirty;

		private bool _buttonDeleteAllowed;

		private bool _buttonSteamWorkshopAllowed;

		private bool _buttonPublishAllowed;

		private bool _bGUIRootPushed;

		private bool _bHideInvokingSiblingUI;

		private bool _bInputTitleActive;

		private bool _bInputDescriptionActive;

		private bool _bInputMusicPackNameActive;

		private bool _bInputSongTitleActive;

		private bool _bInputArtistNameActive;

		private bool _bInputTitleDeactivatePending;

		private bool _bInputDescriptionDeactivatePending;

		private bool _bInputMusicPackNameDeactivatePending;

		private bool _bInputSongTitleDeactivatePending;

		private bool _bInputArtistNameDeactivatePending;

		private bool _bPreTextInputTitleDirtyStatus;

		private bool _bPreTextInputDescriptionDirtyStatus;

		private bool _bPreTextInputMusicPackNameDirtyStatus;

		private bool _bPreTextInputSongTitleDirtyStatus;

		private bool _bPreTextInputArtistNameDirtyStatus;

		private bool _bCheckUpdateIconPreviewTexturePending;

		private bool _bCheckUpdateIconPreviewTextureForce;

		private ExtContentImageSpec _displayedIconPreviewImageSpec;

		private Configuration _currentConfig;

		private GameItemUIData _currentGameItemUIData;

		private GameItemUIData _previousGameItemUIData;

		private Texture2D _texture2DPreviewIconBG;

		private List<RoomItem> _currentGameItemRoomItemInstancesInLevel;

		private string _lastChosenMusicFileSpec;

		public bool IsShown => _bIsShown;

		public bool HideInvokingSiblingUI
		{
			get
			{
				return _bHideInvokingSiblingUI;
			}
			set
			{
				_bHideInvokingSiblingUI = value;
			}
		}

		public Transform InvokingSiblingUITransform
		{
			get
			{
				return _invokingSiblingUITransform;
			}
			set
			{
				_invokingSiblingUITransform = value;
			}
		}

		public Transform ParentUITransform
		{
			get
			{
				return _parentUITransform;
			}
			set
			{
				_parentUITransform = value;
			}
		}

		public event OnUIScreenClosedCallback OnUIScreenClosed;

		public ExtContentGameItemUIScreen()
		{
			_disabledTextUIElementAlphaValue = 0.2f;
		}

		public void Setup(ExtContentUIManager uiManager, Transform uiParentTransform, ExtContentSourceLocalMods contentSourceLocalMods)
		{
			_parentUITransform = uiParentTransform;
			_contentSourceLocalMods = contentSourceLocalMods;
			_uiManager = uiManager;
			_uiManagerConfig = _uiManager.Config;
			_extContentConfig = _uiManager.ExtContentManager.Config.ExtContentConfig.Instance;
			_dynamicPlaylistManager = ExtContentUtils.ExtContentManager.App.DynamicPlaylistManager;
			_currentConfig = new Configuration();
			_currentGameItemUIData = new GameItemUIData();
			_previousGameItemUIData = new GameItemUIData();
			_displayedIconPreviewImageSpec = new ExtContentImageSpec();
			_bGUIRootPushed = false;
			_selectableImageMainTexture.Setup("MAIN", ExtContentUtils.TexturesConfig.SupportedTextureFileExtensions, bScaleImageToCompletelyFillParent: false, OnMainTextureChanged, OnMainTextureDisplayedChanged, OnMainTextureEditModeStatusChanged);
			_selectableImageIconTexture.Setup("ICON", ExtContentUtils.TexturesConfig.SupportedTextureFileExtensions, bScaleImageToCompletelyFillParent: true, OnIconTextureChanged, OnIconTextureDisplayedChanged, OnIconTextureEditModeStatusChanged);
			if (_tooltipMainEditModeButton != null)
			{
				_tooltipMainEditModeButton.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ((!_selectableImageMainTexture.EditModeOn) ? ScriptLocalization.Menu_UGC.Image_SelectionArea_Edit_CS : ScriptLocalization.Menu_UGC.Image_SelectionArea_Confirm_CS);
				});
			}
			if (_tooltipIconEditModeButton != null)
			{
				_tooltipIconEditModeButton.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ((!_selectableImageIconTexture.EditModeOn) ? ScriptLocalization.Menu_UGC.Image_SelectionArea_Edit_CS : ScriptLocalization.Menu_UGC.Image_SelectionArea_Confirm_CS);
				});
			}
			Hide(bForce: true);
		}

		public void Configure(bool bCreateNewItem, bool bAllowAmendContentType, EContentType intialContentType, List<EContentType> allowedContentTypes, GameItemBase updateGameItem)
		{
			_currentConfig._bAllowAmendContentType = bAllowAmendContentType && updateGameItem == null;
			_currentConfig._initialContentType = intialContentType;
			_currentConfig._allowedContentTypes = allowedContentTypes;
			if (_currentConfig._allowedContentTypes == null)
			{
				_currentConfig._allowedContentTypes = new List<EContentType>();
				_currentConfig._allowedContentTypes.Add(_currentConfig._initialContentType);
			}
			UpdateConfigurationCreateUpdateMode(bCreateNewItem, intialContentType, updateGameItem);
			ValidateConfiguration();
		}

		public void Show(Transform invokingSiblingUI = null, bool bHideInvokingSiblingUI = false)
		{
			if (_bIsShown)
			{
				return;
			}
			_invokingSiblingUITransform = invokingSiblingUI;
			_bHideInvokingSiblingUI = bHideInvokingSiblingUI;
			_bIsShown = true;
			_bIsInitialising = true;
			if (!_bGUIRootPushed)
			{
				_bGUIRootPushed = true;
				TooltipManager.Instance.PushGUIRoot(base.transform);
			}
			base.gameObject.SetActive(value: true);
			if (_invokingSiblingUITransform == null)
			{
				base.gameObject.transform.SetParent(_parentUITransform);
				base.gameObject.transform.SetAsLastSibling();
			}
			else
			{
				base.gameObject.transform.SetParent(_invokingSiblingUITransform.parent);
				base.gameObject.transform.SetSiblingIndex(_invokingSiblingUITransform.GetSiblingIndex() + 1);
				if (_bHideInvokingSiblingUI)
				{
					_invokingSiblingUITransform.gameObject.SetActive(value: false);
				}
			}
			_selectableImageMainTexture.Show();
			_selectableImageIconTexture.Show();
			ProcessEventRegistration(bShow: true);
			SetHidePending(bSet: false);
			UpdateUIElementScreenTitle(_currentConfig._screenTitle);
			UpdateInputFieldCharacterLimits();
			SetCurrentContentType(_currentConfig._initialContentType, bForce: true);
			InitialiseGameItemUIData(_currentConfig._initialContentType, _currentConfig._bCreateNewItem, _currentConfig._updateGameItem);
			SetInitialSliderExtents();
			UpdateUIElementDisplayItemCostSlider();
			UpdateUIElementDisplayItemKudoshSlider();
			UpdateCostSliderArrowsVisibility();
			UpdateKudoshSliderArrowsVisibility();
			UpdateContentTypeUIElements();
			UpdateGameItemDataValidStatus();
			UpdateUIElementButtonsText();
			UpdateContentTypeDropDownUIElements();
			UpdateContentSubTypeDropDownUIElements();
			UpdateRecommendedResolutionTextUIElement();
			UpdateUIElementCurrentMusicItemInputPanels();
			CheckUpdateIconPreviewTexture();
			UpdatePreviewTitleText();
			UpdateContentTypeSpecificUIElementsActiveStatus();
			_uiManager.OnUIScreenShownStatusChange();
			if (!_currentGameItemUIData._bIsPictureBaseItemType)
			{
				_bIsInitialising = false;
				SetGameItemDataDirty(bDirty: false);
				_previousGameItemUIData.UpdateGameItemDataFrom(_currentGameItemUIData);
				UpdateGameItemDataValidStatus();
				UpdateButtonISelectableStatusAll();
			}
		}

		public void Hide(bool bForce = false)
		{
			if (_bIsShown || bForce)
			{
				_selectableImageMainTexture.Hide();
				_selectableImageIconTexture.Hide();
				HideExpandedDropdownControl(_dropdownContentType);
				HideExpandedDropdownControl(_dropdownContentSubType);
				DeInitMusicPackItemRows();
				base.gameObject.SetActive(value: false);
				ProcessEventRegistration(bShow: false);
				_bIsShown = false;
				_texture2DPreviewIconBG = null;
				if (_bIsShown && this.OnUIScreenClosed != null)
				{
					this.OnUIScreenClosed(_currentConfig._updateGameItem);
				}
				_uiManager.OnUIScreenShownStatusChange();
				if (_bGUIRootPushed)
				{
					_bGUIRootPushed = false;
					TooltipManager.Instance.PopGUIRoot(base.transform);
				}
				if (_invokingSiblingUITransform != null && _bHideInvokingSiblingUI)
				{
					_invokingSiblingUITransform.gameObject.SetActive(value: true);
				}
				_dynamicPlaylistManager.StopPreview();
			}
		}

		public void Toggle()
		{
			if (!_bIsShown)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		public void Update()
		{
			if (_bIsShown)
			{
				ProcessCheckSelectableImagesInitialised();
				ProcessCheckUpdateIconPreviewTexturePending();
				ProcessUpdateIconSelectableImageBGColourStatus();
				ProcessOpenGameItemDevInfoPanel();
				ProcessInvokeEditModeInputs();
				ProcessTextInputModeKeys();
				ProcessHidePending();
				ProcessUpdateUIPlaybackProgressBar();
				ProcessMusicItemRows();
				ProcessMusicItemRowDragMode();
			}
		}

		private void ProcessCheckSelectableImagesInitialised()
		{
			if (_bIsInitialising && _selectableImageMainTexture.Initialised && _selectableImageIconTexture.Initialised)
			{
				_bIsInitialising = false;
				SetGameItemDataDirty(bDirty: false);
				_previousGameItemUIData.UpdateGameItemDataFrom(_currentGameItemUIData);
				CheckImageFileModTimesForSettingDataDirty();
				UpdateGameItemDataValidStatus();
				UpdateButtonISelectableStatusAll();
			}
		}

		private void UpdateConfigurationCreateUpdateMode(bool bCreateNewItem, EContentType contentType, GameItemBase updateGameItem)
		{
			_currentConfig._bCreateNewItem = bCreateNewItem;
			_currentConfig._updateGameItem = updateGameItem;
			if (_currentConfig._bAllowAmendContentType)
			{
				_currentConfig._bAllowAmendContentType = updateGameItem == null;
			}
			_currentConfig._bAllowAmendContentSubType = updateGameItem == null;
			UpdateContentSubTypeDropDownUIElements();
			UpdateContentTypeSpecificUIElementsActiveStatus();
			_currentConfig._screenTitle = GetUIScreenTitleLoc(contentType, _currentConfig._bCreateNewItem);
			UpdateUIElementScreenTitle(_currentConfig._screenTitle);
			UpdateUIElementButtonTextCreateUpdate();
			_buttonDeleteAllowed = !_currentConfig._bCreateNewItem && _currentConfig._updateGameItem != null;
			_buttonSteamWorkshopAllowed = WorkshopUtils.AreSteamWorkshopFeaturesAvailable();
			UpdateButtonISelectableStatusAll();
		}

		private string GetUIScreenTitleLoc(EContentType contentType, bool bCreateNewItem)
		{
			_ = string.Empty;
			EMessageType eMessageType = EMessageType.None;
			return ExtContentMessages.GetMessageString(contentType switch
			{
				EContentType.CreditsScreen => bCreateNewItem ? EMessageType.GameItemUICreateCreditsScreen : EMessageType.GameItemUIUpdateCreditsScreen, 
				EContentType.Rug => bCreateNewItem ? EMessageType.GameItemUICreateRug : EMessageType.GameItemUIUpdateRug, 
				EContentType.Picture => bCreateNewItem ? EMessageType.GameItemUICreatePicture : EMessageType.GameItemUIUpdatePicture, 
				EContentType.Floor => bCreateNewItem ? EMessageType.GameItemUICreateFloor : EMessageType.GameItemUIUpdateFloor, 
				EContentType.Wall => bCreateNewItem ? EMessageType.GameItemUICreateWall : EMessageType.GameItemUIUpdateWall, 
				EContentType.MusicPack => bCreateNewItem ? EMessageType.GameItemUICreateMusicPack : EMessageType.GameItemUIUpdateMusicPack, 
				_ => bCreateNewItem ? EMessageType.GameItemUICreateAnItem : EMessageType.GameItemUIUpdateAnItem, 
			});
		}

		private void ProcessOpenGameItemDevInfoPanel()
		{
			ExtContentUtils.CheckShowGameItemDevInfoPanelInput(_currentConfig._updateGameItem, bCheckNoUGCUIScreensOpen: false);
		}

		private void ProcessInvokeEditModeInputs()
		{
		}

		private void OnInputValueChangedGeneral(string str)
		{
			SetGameItemDataDirty(bDirty: true);
			UpdateButtonISelectableStatusAll();
		}

		private void OnTitleInputValueChanged(string str)
		{
			OnInputValueChangedGeneral(str);
		}

		private void OnDescriptionInputValueChanged(string str)
		{
			OnInputValueChangedGeneral(str);
		}

		private void OnMusicPackNameInputValueChanged(string str)
		{
			OnInputValueChangedGeneral(str);
		}

		private void OnSongTitleInputValueChanged(string str)
		{
			OnInputValueChangedGeneral(str);
		}

		private void OnArtistNameInputValueChanged(string str)
		{
			OnInputValueChangedGeneral(str);
		}

		private char OnInputValidateInputGeneral(char inChar)
		{
			char result = '\0';
			if (inChar != '\t')
			{
				result = inChar;
			}
			return result;
		}

		private char OnTitleInputValidateInput(char inChar)
		{
			return OnInputValidateInputGeneral(inChar);
		}

		private char OnDescriptionInputValidateInput(char inChar)
		{
			return OnInputValidateInputGeneral(inChar);
		}

		private char OnMusicPackNameInputValidateInput(char inChar)
		{
			return OnInputValidateInputGeneral(inChar);
		}

		private char OnSongTitleInputValidateInput(char inChar)
		{
			return OnInputValidateInputGeneral(inChar);
		}

		private char OnArtistNameInputValidateInput(char inChar)
		{
			return OnInputValidateInputGeneral(inChar);
		}

		private void OnTitleInputEndEdit(string str)
		{
			_bInputTitleDeactivatePending = true;
			if (CheckSetValidGameItemTitle(str.Trim()))
			{
				OnGameItemValueChanged();
			}
			else
			{
				SetGameItemDataDirty(_bPreTextInputTitleDirtyStatus);
			}
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
		}

		private void OnDescriptionInputEndEdit(string str)
		{
			_bInputDescriptionDeactivatePending = true;
			string text = str.Trim();
			if (text != _currentGameItemUIData._description)
			{
				_currentGameItemUIData._description = text;
				OnGameItemValueChanged();
			}
			else
			{
				SetGameItemDataDirty(_bPreTextInputDescriptionDirtyStatus);
			}
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
		}

		private void OnMusicPackNameInputEndEdit(string str)
		{
			_bInputMusicPackNameDeactivatePending = true;
			if (CheckSetValidGameItemTitle(str.Trim()))
			{
				OnGameItemValueChanged();
			}
			else
			{
				SetGameItemDataDirty(_bPreTextInputMusicPackNameDirtyStatus);
			}
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
		}

		private void OnSongTitleInputEndEdit(string str)
		{
			_bInputSongTitleDeactivatePending = true;
			string trackName = str.Trim();
			bool flag = false;
			if (trackName != _currentGameItemUIData._songTitle)
			{
				if (IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
				{
					ValidateTrackNameOnEdit(ref trackName, _currentGameItemUIData._songTitleOriginal);
				}
				if (!trackName.IsNullOrEmpty())
				{
					flag = true;
					_currentGameItemUIData._songTitle = trackName;
					UpdateCurrentMusicItemRowData();
					OnGameItemValueChanged();
				}
			}
			if (!flag)
			{
				SetGameItemDataDirty(_bPreTextInputSongTitleDirtyStatus);
			}
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
			UpdateUIElementDisplayItemSongTitle();
		}

		private void OnArtistNameInputEndEdit(string str)
		{
			_bInputArtistNameDeactivatePending = true;
			string artistName = str.Trim();
			if (artistName != _currentGameItemUIData._artistName)
			{
				ValidateArtistNameOnEdit(ref artistName, _currentGameItemUIData._artistNameOriginal);
				if (!artistName.IsNullOrEmpty())
				{
					_currentGameItemUIData._artistName = artistName;
					UpdateCurrentMusicItemRowData();
					OnGameItemValueChanged();
				}
			}
			if (0 == 0)
			{
				SetGameItemDataDirty(_bPreTextInputArtistNameDirtyStatus);
			}
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
			UpdateUIElementDisplayItemArtistName();
		}

		private bool CheckSetValidGameItemTitle(string newTitle)
		{
			bool result = false;
			if (!IsValidGameItemTitle(newTitle))
			{
				ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.LocalModAlreadyExistsMessageTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.LocalModAlreadyExistsMessageBody), newTitle));
			}
			else if (_currentGameItemUIData._title != newTitle)
			{
				result = true;
				_currentGameItemUIData._title = newTitle;
				UpdatePreviewTitleText();
			}
			return result;
		}

		private bool IsValidGameItemTitle(string title)
		{
			bool result = true;
			string text = _contentSourceLocalMods.SanitizeTitle(title);
			text = text.ToLower();
			foreach (GameItemBase item in _contentSourceLocalMods.GetAllGameItemsRef())
			{
				if (item != _currentConfig._updateGameItem && item.Title.ToLower() == text)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		private void SetHidePending(bool bSet)
		{
			_bHidePending = bSet;
		}

		private void ProcessHidePending()
		{
			if (_bHidePending)
			{
				_bHidePending = false;
				Hide();
			}
		}

		private void ValidateConfiguration()
		{
		}

		private void ProcessEventRegistration(bool bShow)
		{
			if (bShow)
			{
				if (_bAreEventsRegistered)
				{
					return;
				}
				_bAreEventsRegistered = true;
				LocalizationManager.OnLocalizeEvent += OnLocalize;
				_dynamicPlaylistManager.OnTrackAudioInfoUpdated += OnTrackAudioInfoUpdated;
				if (_buttonCloseMenu != null)
				{
					_buttonCloseMenu.onPrimaryDown.AddListener(OnCloseButton);
				}
				if (_buttonCreateUpdate != null)
				{
					_buttonCreateUpdate.onPrimaryDown.AddListener(OnCreateUpdateButton);
				}
				if (_buttonPublish != null)
				{
					_buttonPublish.onPrimaryDown.AddListener(OnPublishButton);
				}
				if (_buttonDelete != null)
				{
					_buttonDelete.onPrimaryDown.AddListener(OnDeleteButton);
				}
				if (_buttonSteamWorkshop != null)
				{
					_buttonSteamWorkshop.onPrimaryDown.AddListener(OnSteamWorkshopButton);
				}
				if (_dropdownContentType != null)
				{
					_dropdownContentType.onValueChanged.AddListener(OnContentTypeValueChanged);
				}
				if (_dropdownContentSubType != null)
				{
					_dropdownContentSubType.onValueChanged.AddListener(OnContentSubTypeValueChanged);
				}
				if (_sliderCost != null)
				{
					_sliderCost.onValueChanged.AddListener(OnSliderItemCostInput);
				}
				if (_sliderKudosh != null)
				{
					_sliderKudosh.onValueChanged.AddListener(OnSliderItemKudoshInput);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onEndEdit.AddListener(OnTitleInputEndEdit);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onValueChanged.AddListener(OnTitleInputValueChanged);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onEndEdit.AddListener(OnDescriptionInputEndEdit);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onValueChanged.AddListener(OnDescriptionInputValueChanged);
				}
				if (_inputMusicPackName != null)
				{
					_inputMusicPackName.onEndEdit.AddListener(OnMusicPackNameInputEndEdit);
				}
				if (_inputMusicPackName != null)
				{
					_inputMusicPackName.onValueChanged.AddListener(OnMusicPackNameInputValueChanged);
				}
				if (_inputSongTitle != null)
				{
					_inputSongTitle.onEndEdit.AddListener(OnSongTitleInputEndEdit);
				}
				if (_inputSongTitle != null)
				{
					_inputSongTitle.onValueChanged.AddListener(OnSongTitleInputValueChanged);
				}
				if (_inputArtistName != null)
				{
					_inputArtistName.onEndEdit.AddListener(OnArtistNameInputEndEdit);
				}
				if (_inputArtistName != null)
				{
					_inputArtistName.onValueChanged.AddListener(OnArtistNameInputValueChanged);
				}
				if (_buttonCostSliderIncrement != null)
				{
					_buttonCostSliderIncrement.onPrimaryDown.AddListener(OnCostSliderIncrButton);
				}
				if (_buttonCostSliderDecrement != null)
				{
					_buttonCostSliderDecrement.onPrimaryDown.AddListener(OnCostSliderDecrButton);
				}
				if (_buttonKudoshSliderIncrement != null)
				{
					_buttonKudoshSliderIncrement.onPrimaryDown.AddListener(OnKudoshSliderIncrButton);
				}
				if (_buttonKudoshSliderDecrement != null)
				{
					_buttonKudoshSliderDecrement.onPrimaryDown.AddListener(OnKudoshSliderDecrButton);
				}
				if (_buttonAddMusicItem != null)
				{
					_buttonAddMusicItem.onPrimaryDown.AddListener(OnAddMusicItemButton);
				}
				if (_buttonMusicItemMoveUp != null)
				{
					_buttonMusicItemMoveUp.onPrimaryDown.AddListener(OnMusicItemMoveUpButton);
				}
				if (_buttonMusicItemMoveDown != null)
				{
					_buttonMusicItemMoveDown.onPrimaryDown.AddListener(OnMusicItemMoveDownButton);
				}
				if (_inputTitle != null)
				{
					InputField inputTitle = _inputTitle;
					inputTitle.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputTitle.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnTitleInputValidateInput(addedChar)));
				}
				if (_inputDescription != null)
				{
					InputField inputDescription = _inputDescription;
					inputDescription.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputDescription.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnDescriptionInputValidateInput(addedChar)));
				}
				if (_inputMusicPackName != null)
				{
					InputField inputMusicPackName = _inputMusicPackName;
					inputMusicPackName.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputMusicPackName.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnMusicPackNameInputValidateInput(addedChar)));
				}
				if (_inputSongTitle != null)
				{
					InputField inputSongTitle = _inputSongTitle;
					inputSongTitle.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputSongTitle.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnSongTitleInputValidateInput(addedChar)));
				}
				if (_inputArtistName != null)
				{
					InputField inputArtistName = _inputArtistName;
					inputArtistName.onValidateInput = (InputField.OnValidateInput)Delegate.Combine(inputArtistName.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnArtistNameInputValidateInput(addedChar)));
				}
			}
			else
			{
				if (!_bAreEventsRegistered)
				{
					return;
				}
				_bAreEventsRegistered = false;
				LocalizationManager.OnLocalizeEvent -= OnLocalize;
				_dynamicPlaylistManager.OnTrackAudioInfoUpdated -= OnTrackAudioInfoUpdated;
				if (_buttonCloseMenu != null)
				{
					_buttonCloseMenu.onPrimaryDown.RemoveListener(OnCloseButton);
				}
				if (_buttonCreateUpdate != null)
				{
					_buttonCreateUpdate.onPrimaryDown.RemoveListener(OnCreateUpdateButton);
				}
				if (_buttonPublish != null)
				{
					_buttonPublish.onPrimaryDown.RemoveListener(OnPublishButton);
				}
				if (_buttonDelete != null)
				{
					_buttonDelete.onPrimaryDown.RemoveListener(OnDeleteButton);
				}
				if (_buttonSteamWorkshop != null)
				{
					_buttonSteamWorkshop.onPrimaryDown.RemoveListener(OnSteamWorkshopButton);
				}
				if (_dropdownContentType != null)
				{
					_dropdownContentType.onValueChanged.RemoveListener(OnContentTypeValueChanged);
				}
				if (_dropdownContentSubType != null)
				{
					_dropdownContentSubType.onValueChanged.RemoveListener(OnContentSubTypeValueChanged);
				}
				if (_sliderCost != null)
				{
					_sliderCost.onValueChanged.RemoveListener(OnSliderItemCostInput);
				}
				if (_sliderKudosh != null)
				{
					_sliderKudosh.onValueChanged.RemoveListener(OnSliderItemKudoshInput);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onEndEdit.RemoveListener(OnTitleInputEndEdit);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onValueChanged.RemoveListener(OnTitleInputValueChanged);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onEndEdit.RemoveListener(OnDescriptionInputEndEdit);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onValueChanged.RemoveListener(OnDescriptionInputValueChanged);
				}
				if (_inputMusicPackName != null)
				{
					_inputMusicPackName.onEndEdit.RemoveListener(OnMusicPackNameInputEndEdit);
				}
				if (_inputMusicPackName != null)
				{
					_inputMusicPackName.onValueChanged.RemoveListener(OnMusicPackNameInputValueChanged);
				}
				if (_inputSongTitle != null)
				{
					_inputSongTitle.onEndEdit.RemoveListener(OnSongTitleInputEndEdit);
				}
				if (_inputSongTitle != null)
				{
					_inputSongTitle.onValueChanged.RemoveListener(OnSongTitleInputValueChanged);
				}
				if (_inputArtistName != null)
				{
					_inputArtistName.onEndEdit.RemoveListener(OnArtistNameInputEndEdit);
				}
				if (_inputArtistName != null)
				{
					_inputArtistName.onValueChanged.RemoveListener(OnArtistNameInputValueChanged);
				}
				if (_buttonCostSliderIncrement != null)
				{
					_buttonCostSliderIncrement.onPrimaryDown.RemoveListener(OnCostSliderIncrButton);
				}
				if (_buttonCostSliderDecrement != null)
				{
					_buttonCostSliderDecrement.onPrimaryDown.RemoveListener(OnCostSliderDecrButton);
				}
				if (_buttonKudoshSliderIncrement != null)
				{
					_buttonKudoshSliderIncrement.onPrimaryDown.RemoveListener(OnKudoshSliderIncrButton);
				}
				if (_buttonKudoshSliderDecrement != null)
				{
					_buttonKudoshSliderDecrement.onPrimaryDown.RemoveListener(OnKudoshSliderDecrButton);
				}
				if (_buttonAddMusicItem != null)
				{
					_buttonAddMusicItem.onPrimaryDown.RemoveListener(OnAddMusicItemButton);
				}
				if (_buttonMusicItemMoveUp != null)
				{
					_buttonMusicItemMoveUp.onPrimaryDown.RemoveListener(OnMusicItemMoveUpButton);
				}
				if (_buttonMusicItemMoveDown != null)
				{
					_buttonMusicItemMoveDown.onPrimaryDown.RemoveListener(OnMusicItemMoveDownButton);
				}
				if (_inputTitle != null)
				{
					InputField inputTitle2 = _inputTitle;
					inputTitle2.onValidateInput = (InputField.OnValidateInput)Delegate.Remove(inputTitle2.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnTitleInputValidateInput(addedChar)));
				}
				if (_inputDescription != null)
				{
					InputField inputDescription2 = _inputDescription;
					inputDescription2.onValidateInput = (InputField.OnValidateInput)Delegate.Remove(inputDescription2.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnDescriptionInputValidateInput(addedChar)));
				}
				if (_inputMusicPackName != null)
				{
					InputField inputMusicPackName2 = _inputMusicPackName;
					inputMusicPackName2.onValidateInput = (InputField.OnValidateInput)Delegate.Remove(inputMusicPackName2.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnMusicPackNameInputValidateInput(addedChar)));
				}
				if (_inputSongTitle != null)
				{
					InputField inputSongTitle2 = _inputSongTitle;
					inputSongTitle2.onValidateInput = (InputField.OnValidateInput)Delegate.Remove(inputSongTitle2.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnSongTitleInputValidateInput(addedChar)));
				}
				if (_inputArtistName != null)
				{
					InputField inputArtistName2 = _inputArtistName;
					inputArtistName2.onValidateInput = (InputField.OnValidateInput)Delegate.Remove(inputArtistName2.onValidateInput, (InputField.OnValidateInput)((string input, int charIndex, char addedChar) => OnArtistNameInputValidateInput(addedChar)));
				}
			}
		}

		private void OnCloseButton()
		{
			SetHidePending(bSet: true);
		}

		private void OnCreateUpdateButton()
		{
			switch (_currentGameItemUIData._contentType)
			{
			case EContentType.CreditsScreen:
				OnCreateUpdateButtonCreditsScreen();
				break;
			case EContentType.Rug:
				OnCreateUpdateButtonPictureBase();
				break;
			case EContentType.Picture:
				OnCreateUpdateButtonPictureBase();
				break;
			case EContentType.Floor:
				OnCreateUpdateButtonPictureBase();
				break;
			case EContentType.Wall:
				OnCreateUpdateButtonPictureBase();
				break;
			case EContentType.MusicPack:
				OnCreateUpdateButtonMusicPack();
				break;
			case EContentType.SandboxSave:
				break;
			}
		}

		private void OnCreateUpdateButtonCreditsScreen()
		{
			SetGameItemDataDirty(bDirty: false);
		}

		private void OnCreateUpdateButtonPictureBase()
		{
			GameItemPictureBase gameItemPictureBase = null;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			_ = string.Empty;
			_ = string.Empty;
			if (ValidateTitleInformingPlayer(_currentGameItemUIData._title))
			{
				if (_currentConfig._bCreateNewItem)
				{
					gameItemPictureBase = _contentSourceLocalMods.CreateItemPictureBase(_currentGameItemUIData._contentType, _currentGameItemUIData._title, _currentGameItemUIData._description, _currentGameItemUIData._contentSubType, _currentGameItemUIData._mainImageSpec, _currentGameItemUIData._iconImageSpec, _currentGameItemUIData._itemIconVariationIndex, _currentGameItemUIData._itemPrice, _currentGameItemUIData._itemKudosh);
					flag = gameItemPictureBase != null;
				}
				else
				{
					GameItemPictureBase gameItemPictureBase2 = _currentConfig._updateGameItem as GameItemPictureBase;
					flag3 = _currentGameItemUIData._contentSubType != gameItemPictureBase2.ItemSubTypeID;
					flag = _contentSourceLocalMods.UpdateItemPictureBase(_currentGameItemUIData._contentType, gameItemPictureBase2, _currentGameItemUIData._title, _currentGameItemUIData._description, _currentGameItemUIData._contentSubType, _currentGameItemUIData._mainImageSpec, _currentGameItemUIData._iconImageSpec, _currentGameItemUIData._itemIconVariationIndex, _currentGameItemUIData._itemPrice, _currentGameItemUIData._itemKudosh);
					if (flag)
					{
						gameItemPictureBase = gameItemPictureBase2;
					}
				}
			}
			else
			{
				flag2 = true;
			}
			if (gameItemPictureBase != null)
			{
				UpdateConfigurationCreateUpdateMode(bCreateNewItem: false, gameItemPictureBase.ContentType, gameItemPictureBase);
			}
			if (flag)
			{
				SetGameItemDataDirty(bDirty: false);
				UpdateButtonISelectableStatusAll();
				UpdateContentTypeDropDownUIElements();
				if (flag3)
				{
					UpdateLevelInstancesOfGameItemPictureBase(gameItemPictureBase);
				}
			}
			else if (!flag2)
			{
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
		}

		private void OnCreateUpdateButtonMusicPack()
		{
			GameItemMusicPack gameItemMusicPack = null;
			bool flag = false;
			bool flag2 = false;
			UpdateMusicPackSourceItemsFromUIRows();
			if (ValidateTitleInformingPlayer(_currentGameItemUIData._title))
			{
				if (_currentConfig._bCreateNewItem)
				{
					gameItemMusicPack = _contentSourceLocalMods.CreateItemMusicPack(_currentGameItemUIData._title, _currentGameItemUIData._description, _currentGameItemUIData._musicPackSourceItems);
					flag = gameItemMusicPack != null;
				}
				else
				{
					GameItemMusicPack gameItemMusicPack2 = _currentConfig._updateGameItem as GameItemMusicPack;
					flag = _contentSourceLocalMods.UpdateItemMusicPack(gameItemMusicPack2, _currentGameItemUIData._title, _currentGameItemUIData._description, _currentGameItemUIData._musicPackSourceItems);
					if (flag)
					{
						gameItemMusicPack = gameItemMusicPack2;
					}
				}
			}
			else
			{
				flag2 = true;
			}
			if (gameItemMusicPack != null)
			{
				UpdateConfigurationCreateUpdateMode(bCreateNewItem: false, gameItemMusicPack.ContentType, gameItemMusicPack);
			}
			if (flag)
			{
				SetGameItemDataDirty(bDirty: false);
				UpdateButtonISelectableStatusAll();
				UpdateContentTypeDropDownUIElements();
			}
			else if (!flag2)
			{
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
		}

		private bool ValidateTitleInformingPlayer(string title)
		{
			bool result = true;
			if (!ExtContentUtils.IsValidForFileOrFolderName(title))
			{
				result = false;
				ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.TitleContainsSpecialCharactersTitle), ExtContentMessages.GetMessageString(EMessageType.TitleContainsSpecialCharactersBody));
			}
			return result;
		}

		private void OnPublishButton()
		{
			if (WorkshopUtils.CheckSteamWorkshopFeaturesAvailableForPublishing())
			{
				_uiManager.SetUIScreenOpenPending();
				Hide();
				_uiManager.ProcessPendingHideScreenItems();
				_uiManager.WorkshopPublishUIScreen.Configure(_currentConfig._updateGameItem);
				_uiManager.WorkshopPublishUIScreen.Show(InvokingSiblingUITransform, HideInvokingSiblingUI);
			}
		}

		private void OnDeleteButton()
		{
			UpdateGameItemInstancesList();
			if (_currentGameItemRoomItemInstancesInLevel.Count > 0)
			{
				OnDeleteButtonDeleteInstancesInLevel();
			}
			else
			{
				OnDeleteButtonPreventedByInstancesInLevel();
			}
		}

		private void UpdateGameItemInstancesList()
		{
			_currentGameItemRoomItemInstancesInLevel = UGCGameUtils.GetAllUGCRoomItemInstancesWithContentID(_currentConfig._updateGameItem.ContentID);
		}

		private void ClearGameItemInstancesList()
		{
			_currentGameItemRoomItemInstancesInLevel.Clear();
		}

		private void OnDeleteButtonPreventedByInstancesInLevel()
		{
			ExtContentMessages.ShowOneOptionMessageBox(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteConfirmTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteConfirmBody), _currentConfig._updateGameItem.Title, _currentConfig._updateGameItem.InstalledFolderPathSpec), ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, OnConfirmDeleteItemPreventedByInstancesInLevel);
		}

		private void OnConfirmDeleteItemPreventedByInstancesInLevel()
		{
			if (_contentSourceLocalMods.DeleteLocalModGameItem(_currentConfig._updateGameItem))
			{
				_currentConfig._updateGameItem = null;
				ExtContentUtils.ExtContentManager.App.Level?.HospitalHUDManager.HideRibbonMenu();
				SetHidePending(bSet: true);
			}
		}

		private void OnDeleteButtonDeleteInstancesInLevel()
		{
			string text = string.Format(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteConfirmBody), _currentConfig._updateGameItem.Title, _currentConfig._updateGameItem.InstalledFolderPathSpec);
			text += "\n\n";
			text += string.Format(ExtContentMessages.GetMessageString(EMessageType.ThisWillDeleteGameItemInstances), _currentGameItemRoomItemInstancesInLevel.Count);
			ExtContentMessages.ShowOneOptionMessageBox(ExtContentMessages.GetMessageString(EMessageType.GameItemDeleteConfirmTitle), text, ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, OnConfirmDeleteItemDeleteInstancesInLevel);
		}

		private void OnConfirmDeleteItemDeleteInstancesInLevel()
		{
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Level != null)
			{
				foreach (RoomItem item in _currentGameItemRoomItemInstancesInLevel)
				{
					app.Level.BuildEvents.OnRoomItemSold.InvokeSafe(item);
					app.Level.BuildEvents.OnRoomItemDestroy.InvokeSafe(item);
				}
			}
			ClearGameItemInstancesList();
			OnConfirmDeleteItemPreventedByInstancesInLevel();
		}

		private void OnSteamWorkshopButton()
		{
			string publishedFileId = string.Empty;
			if (_currentConfig._updateGameItem != null && _currentConfig._updateGameItem.PublishedWorkshopMetaData != null)
			{
				publishedFileId = _currentConfig._updateGameItem.PublishedWorkshopMetaData.PublishedFileId;
			}
			string steamURL = string.Empty;
			string browserURL = string.Empty;
			ExtContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForPublishedFileId(publishedFileId, ref steamURL, ref browserURL);
			WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
		}

		private void OnMainTextureChanged()
		{
			_currentGameItemUIData._mainImageSpec.UpdateFrom(_selectableImageMainTexture.ImageSpec);
			CheckGameItemValueChanged();
			CheckUpdateIconTexture();
		}

		private void OnIconTextureChanged()
		{
			_currentGameItemUIData._iconImageSpec.UpdateFrom(_selectableImageIconTexture.ImageSpec);
			CheckGameItemValueChanged();
			CheckUpdateIconTexture();
		}

		private void OnMainTextureDisplayedChanged()
		{
			OnMainTextureChanged();
		}

		private void OnIconTextureDisplayedChanged()
		{
			_currentGameItemUIData._iconImageSpec.UpdateFrom(_selectableImageIconTexture.ImageSpec);
			CheckGameItemValueChanged();
			SetCheckUpdateIconPreviewTexturePending(bForce: true);
		}

		private void CheckUpdateIconTexture()
		{
			if (!_selectableImageIconTexture.HasValidFileSpec)
			{
				int rotateRightAnlgesCount = 0;
				GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
				if (currentUIDataPictureBaseConfig != null)
				{
					IconGenParams variationIconGenParams = IconGenData.GetVariationIconGenParams(currentUIDataPictureBaseConfig._iconGenData, _currentGameItemUIData._itemIconVariationIndex);
					if (variationIconGenParams != null)
					{
						rotateRightAnlgesCount = variationIconGenParams._rotateIconImageCount;
					}
				}
				_selectableImageIconTexture.UpdateDisplayedImageFrom(_selectableImageMainTexture, rotateRightAnlgesCount);
			}
			SetCheckUpdateIconPreviewTexturePending();
		}

		private void SetCheckUpdateIconPreviewTexturePending(bool bForce = false)
		{
			if (_currentGameItemUIData._bIsPictureBaseItemType)
			{
				_bCheckUpdateIconPreviewTexturePending = true;
				_bCheckUpdateIconPreviewTextureForce |= bForce;
			}
		}

		private void ProcessCheckUpdateIconPreviewTexturePending()
		{
			if (_bCheckUpdateIconPreviewTexturePending)
			{
				_bCheckUpdateIconPreviewTexturePending = false;
				if (_currentGameItemUIData._bIsPictureBaseItemType)
				{
					CheckUpdateIconPreviewTexture(_bCheckUpdateIconPreviewTextureForce);
					_bCheckUpdateIconPreviewTextureForce = false;
				}
			}
		}

		private void CheckUpdateIconPreviewTexture(bool bForce = false)
		{
			if (!_currentGameItemUIData._bIsPictureBaseItemType)
			{
				return;
			}
			bool active = true;
			if (_imageIconTexturePreview != null)
			{
				ExtContentImageSpec displayIconImageSpec = GetDisplayIconImageSpec();
				if (!displayIconImageSpec.IsEqualTo(_displayedIconPreviewImageSpec) || bForce)
				{
					_displayedIconPreviewImageSpec.Reset();
					bool flag = false;
					bool flag2 = _currentGameItemUIData._iconImageSpec.FileSpec.IsNullOrEmpty();
					Texture2D texture2D = (flag2 ? _selectableImageMainTexture.Texture2DSelectedArea : _selectableImageIconTexture.Texture2DSelectedArea);
					if (texture2D != null)
					{
						GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
						if (currentUIDataPictureBaseConfig != null)
						{
							IconGenParams variationIconGenParams = IconGenData.GetVariationIconGenParams(currentUIDataPictureBaseConfig._iconGenData, _currentGameItemUIData._itemIconVariationIndex);
							if (variationIconGenParams != null && variationIconGenParams.GetTexture2D() != null)
							{
								if (flag2 && variationIconGenParams._rotateIconImageCount != 0)
								{
									texture2D = ExtContentTextureUtils.RotateTexture2D(texture2D, variationIconGenParams._rotateIconImageCount);
								}
								float imageAspectRatioMain = GetImageAspectRatioMain(currentUIDataPictureBaseConfig);
								float iconImageAspectRatio = variationIconGenParams.GetIconImageAspectRatio(imageAspectRatioMain);
								ImageSelectionArea imageSelectionArea = new ImageSelectionArea();
								imageSelectionArea.ScaleToFitAspectRatios((float)texture2D.width / (float)texture2D.height, iconImageAspectRatio);
								Texture2D texture2D2 = ExtContentTextureUtils.CreateTexture2DForSelectionArea(texture2D, imageSelectionArea);
								if (texture2D2 != null)
								{
									bool editorUIEnabled = false;
									int editorUIVertexIndex = 0;
									int editorUIVertexIndex2 = 0;
									Texture2D texture2D3 = ExtContentTextureUtils.CreateTargetTextureWithSourceIcon(texture2D2, variationIconGenParams, IconGenData.GetImageBGColour(currentUIDataPictureBaseConfig._iconGenData), editorUIEnabled, editorUIVertexIndex, editorUIVertexIndex2);
									if (texture2D3 != null && ExtContentTextureUtils.SetImageTextureSprite(ref _imageIconTexturePreview, texture2D3))
									{
										flag = true;
										active = false;
									}
								}
							}
						}
					}
					if (!flag)
					{
						ExtContentTextureUtils.SetImageDefaultBG(ref _imageIconTexturePreview);
					}
					_displayedIconPreviewImageSpec.UpdateFrom(displayIconImageSpec);
				}
				else
				{
					active = false;
				}
			}
			if (_imageIconTexturePreviewDefault != null)
			{
				_imageIconTexturePreviewDefault.gameObject.SetActive(active);
			}
		}

		private void UpdatePreviewTitleText()
		{
			_textPreviewTitle.text = _currentGameItemUIData._title;
		}

		private void OnMainTextureEditModeStatusChanged()
		{
			_selectableImageIconTexture.SetEditModeAllowedExternal(!_selectableImageMainTexture.EditModeOn);
			UpdateButtonISelectableStatusAll();
		}

		private void OnIconTextureEditModeStatusChanged()
		{
			_selectableImageMainTexture.SetEditModeAllowedExternal(!_selectableImageIconTexture.EditModeOn);
			UpdateButtonISelectableStatusAll();
		}

		private bool IsAnyEditModeOn()
		{
			if (_currentGameItemUIData._bIsPictureBaseItemType)
			{
				if (!_selectableImageMainTexture.EditModeOn)
				{
					return _selectableImageIconTexture.EditModeOn;
				}
				return true;
			}
			return false;
		}

		private ExtContentImageSpec GetDisplayIconImageSpec()
		{
			if (_currentGameItemUIData._iconImageSpec.FileSpec.IsNullOrEmpty())
			{
				return _currentGameItemUIData._mainImageSpec;
			}
			return _currentGameItemUIData._iconImageSpec;
		}

		private void UpdateContentTypeDropDownUIElements()
		{
			bool flag = _currentConfig._bAllowAmendContentType && _currentConfig._allowedContentTypes.Count > 1;
			_gameObjectContentTypeDropDown.SetActive(flag);
			_dropdownContentType.interactable = flag;
			_dropdownContentType.ClearOptions();
			string text = ExtContentType.ContentTypeToStringLoc(_currentGameItemUIData._contentType);
			if (flag)
			{
				List<string> list = new List<string>();
				foreach (EContentType allowedContentType in _currentConfig._allowedContentTypes)
				{
					list.Add(ExtContentType.ContentTypeToStringLoc(allowedContentType));
				}
				_dropdownContentType.AddOptions(list);
				_dropdownContentType.value = list.IndexOf(text);
			}
			_textContentTypeDropDownValue.gameObject.SetActive(value: true);
			_textContentTypeDropDownValue.text = text;
		}

		private void OnContentTypeValueChanged(int index)
		{
			if (index < 0 || index >= _currentConfig._allowedContentTypes.Count)
			{
				return;
			}
			EContentType contentType = _currentConfig._allowedContentTypes[index];
			if (ExtContentType.IsValid(contentType))
			{
				EContentType contentType2 = _currentGameItemUIData._contentType;
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Received new drop down content type '{0}'"), ExtContentType.ContentTypeToString(contentType)));
				SetCurrentContentType(contentType);
				if (_currentGameItemUIData._contentType != contentType2)
				{
					InitialiseGameItemUIDataOnContentTypeChanged(contentType, _currentConfig._bCreateNewItem, _currentConfig._updateGameItem);
					OnGameItemValueChanged();
					SetCheckUpdateIconPreviewTexturePending(bForce: true);
				}
			}
		}

		private void UpdateContentSubTypes()
		{
			_currentGameItemUIData._contentSubTypeItems.Clear();
			_currentGameItemUIData._contentSubTypeItemsLoc.Clear();
			_currentGameItemUIData._contentSubTypeItemDisplayNamesLoc.Clear();
			ExtContentUtils.GetContentSubTypesForContentType(_currentGameItemUIData._contentType, ref _currentGameItemUIData._contentSubTypeItems, ref _currentGameItemUIData._contentSubTypeItemsLoc);
			int i = 0;
			for (int count = _currentGameItemUIData._contentSubTypeItemsLoc.Count; i < count; i++)
			{
				_currentGameItemUIData._contentSubTypeItemDisplayNamesLoc[_currentGameItemUIData._contentSubTypeItems[i]] = _currentGameItemUIData._contentSubTypeItemsLoc[i];
			}
			if (GetCurrentSubTypesIndexForSubType(_currentGameItemUIData._contentSubType) < 0)
			{
				SetCurrentContentSubType("");
			}
		}

		private int GetCurrentSubTypesIndexForSubType(string contentSubType)
		{
			return _currentGameItemUIData._contentSubTypeItems.IndexOf(contentSubType);
		}

		private void UpdateContentSubTypeDropDownUIElements()
		{
			bool flag = _currentConfig._bAllowAmendContentSubType && _currentGameItemUIData._contentSubTypeItems.Count > 1;
			_gameObjectContentSubTypeDropDown.SetActive(flag);
			_dropdownContentSubType.interactable = flag;
			_dropdownContentSubType.ClearOptions();
			if (flag)
			{
				int num = _currentGameItemUIData._contentSubTypeItems.IndexOf(_currentGameItemUIData._contentSubType);
				if (num < 0)
				{
					num = 0;
				}
				_dropdownContentSubType.AddOptions(_currentGameItemUIData._contentSubTypeItemsLoc);
				_dropdownContentSubType.value = num;
			}
			_textContentSubTypeDropDownValue.gameObject.SetActive(value: true);
			_textContentSubTypeDropDownValue.text = string.Empty;
			if (!_currentGameItemUIData._contentSubType.IsNullOrEmpty() && _currentGameItemUIData._contentSubTypeItemDisplayNamesLoc != null && _currentGameItemUIData._contentSubTypeItemDisplayNamesLoc.Count > 0)
			{
				string text = _currentGameItemUIData._contentSubTypeItemDisplayNamesLoc[_currentGameItemUIData._contentSubType];
				if (!text.IsNullOrEmpty())
				{
					_textContentSubTypeDropDownValue.text = text;
				}
			}
		}

		private void OnContentSubTypeValueChanged(int index)
		{
			if (index >= 0 && index < _currentGameItemUIData._contentSubTypeItems.Count)
			{
				string contentSubType = _currentGameItemUIData._contentSubType;
				string text = _currentGameItemUIData._contentSubTypeItems[index];
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("Received new drop down content sub type '{0}'"), text));
				SetCurrentContentSubType(text);
				if (_currentGameItemUIData._contentSubType != contentSubType)
				{
					OnGameItemValueChanged();
					SetCheckUpdateIconPreviewTexturePending(bForce: true);
				}
			}
		}

		private void UpdateRecommendedResolutionTextUIElement()
		{
			if (_textRecommendedResolution != null)
			{
				GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
				if (currentUIDataPictureBaseConfig != null)
				{
					string recommendedResolution_CS = ScriptLocalization.Menu_UGC.RecommendedResolution_CS;
					recommendedResolution_CS = recommendedResolution_CS.Replace("{[WIDTH]}", ((int)currentUIDataPictureBaseConfig._preferredTextureWidth).ToString());
					recommendedResolution_CS = recommendedResolution_CS.Replace("{[HEIGHT]}", ((int)currentUIDataPictureBaseConfig._preferredTextureHeight).ToString());
					_textRecommendedResolution.text = recommendedResolution_CS;
				}
			}
		}

		private void ActivateContentTypeSpecificUIPanel(EContentType contentType)
		{
			int i = 0;
			for (int num = _gameObjectContentTypePanel.Length; i < num; i++)
			{
				if (_gameObjectContentTypePanel[i] != null)
				{
					_gameObjectContentTypePanel[i].SetActive(value: false);
				}
			}
			if (_gameObjectContentTypePanel[(int)contentType] != null)
			{
				_gameObjectContentTypePanel[(int)contentType].SetActive(value: true);
			}
		}

		private void SetCurrentContentType(EContentType contentType, bool bForce = false)
		{
			if (_currentGameItemUIData._contentType != contentType || bForce)
			{
				_currentGameItemUIData._contentType = contentType;
				_currentGameItemUIData._bIsPictureBaseItemType = false;
				EContentType contentType2 = _currentGameItemUIData._contentType;
				if ((uint)(contentType2 - 4) <= 1u || (uint)(contentType2 - 7) <= 1u)
				{
					_currentGameItemUIData._bIsPictureBaseItemType = true;
				}
				UpdateContentSubTypes();
				ActivateContentTypeSpecificUIPanel(_currentGameItemUIData._contentType);
				UpdateContentTypeDropDownUIElements();
				_currentConfig._screenTitle = GetUIScreenTitleLoc(_currentGameItemUIData._contentType, _currentConfig._bCreateNewItem);
				UpdateUIElementScreenTitle(_currentConfig._screenTitle);
				UpdateContentTypeUIElements();
			}
		}

		private void SetCurrentContentSubType(string contentSubType, bool bForce = false)
		{
			if (contentSubType.IsNullOrEmpty() && _currentGameItemUIData._contentSubTypeItems.Count > 0)
			{
				contentSubType = _currentGameItemUIData._contentSubTypeItems[0];
			}
			if (_currentGameItemUIData._contentSubType != contentSubType || bForce)
			{
				_currentGameItemUIData._contentSubType = contentSubType;
				UpdateContentSubTypeDropDownUIElements();
				GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
				if (currentUIDataPictureBaseConfig != null)
				{
					_currentGameItemUIData._itemIconVariationIndex = -1;
					ValidateRandomIconVariationIndex();
					float imageAspectRatioMain = GetImageAspectRatioMain(currentUIDataPictureBaseConfig);
					float imageAspectRatioIcon = GetImageAspectRatioIcon(currentUIDataPictureBaseConfig);
					_selectableImageMainTexture.SetDisplayAspectRatio(imageAspectRatioMain);
					_selectableImageIconTexture.SetDisplayAspectRatio(imageAspectRatioIcon);
					SetGameItemUIDataForPictureBaseConfig(currentUIDataPictureBaseConfig, bResetItemValuesToDefault: false);
					SetInitialSliderExtents();
					UpdateUIElementDisplayItemCostSlider();
					UpdateUIElementDisplayItemKudoshSlider();
					UpdateSelectableImagesBGColour();
					UpdateRecommendedResolutionTextUIElement();
				}
			}
		}

		private void UpdateSelectableImagesBGColour()
		{
			GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
			if (currentUIDataPictureBaseConfig != null)
			{
				Color imageBGColour = IconGenData.GetImageBGColour(currentUIDataPictureBaseConfig._iconGenData);
				_selectableImageMainTexture.SetMainTextureBGColour(imageBGColour);
				_selectableImageIconTexture.SetMainTextureBGColour(imageBGColour);
			}
		}

		private void ProcessUpdateIconSelectableImageBGColourStatus()
		{
			if (!_selectableImageIconTexture.HasValidFileSpec)
			{
				_selectableImageIconTexture.UseImageBGColour = _selectableImageMainTexture.UseImageBGColour;
			}
		}

		private void ProcessTextInputModeKeys()
		{
			ProcessTextInputModeTabKeyInputs();
			if (!_bInputTitleActive && _inputTitle.isFocused)
			{
				_bInputTitleActive = true;
				_bPreTextInputTitleDirtyStatus = _bGameItemDataDirty;
			}
			if (!_bInputDescriptionActive && _inputDescription.isFocused)
			{
				_bInputDescriptionActive = true;
				_bPreTextInputDescriptionDirtyStatus = _bGameItemDataDirty;
			}
			if (!_bInputMusicPackNameActive && _inputMusicPackName.isFocused)
			{
				_bInputMusicPackNameActive = true;
				_bPreTextInputMusicPackNameDirtyStatus = _bGameItemDataDirty;
			}
			if (!_bInputSongTitleActive && _inputSongTitle.isFocused)
			{
				_bInputSongTitleActive = true;
				_bPreTextInputSongTitleDirtyStatus = _bGameItemDataDirty;
			}
			if (!_bInputArtistNameActive && _inputArtistName.isFocused)
			{
				_bInputArtistNameActive = true;
				_bPreTextInputArtistNameDirtyStatus = _bGameItemDataDirty;
			}
			if (Input.GetKeyDown(KeyCode.Escape) && !ExtContentMessages.MessageBox.IsVisibleOrClosing && !_bInputTitleActive && !_bInputDescriptionActive && !_bInputMusicPackNameActive && !_bInputSongTitleActive && !_bInputArtistNameActive && !_dropdownContentType.IsExpanded && !_dropdownContentSubType.IsExpanded)
			{
				SetHidePending(bSet: true);
			}
			if (_bInputTitleDeactivatePending)
			{
				_bInputTitleDeactivatePending = false;
				_bInputTitleActive = false;
			}
			if (_bInputDescriptionDeactivatePending)
			{
				_bInputDescriptionDeactivatePending = false;
				_bInputDescriptionActive = false;
			}
			if (_bInputMusicPackNameDeactivatePending)
			{
				_bInputMusicPackNameDeactivatePending = false;
				_bInputMusicPackNameActive = false;
			}
			if (_bInputSongTitleDeactivatePending)
			{
				_bInputSongTitleDeactivatePending = false;
				_bInputSongTitleActive = false;
			}
			if (_bInputArtistNameDeactivatePending)
			{
				_bInputArtistNameDeactivatePending = false;
				_bInputArtistNameActive = false;
			}
		}

		private void ProcessTextInputModeTabKeyInputs()
		{
			if (ExtContentMessages.MessageBox.IsVisibleOrClosing || !Input.GetKeyDown(KeyCode.Tab))
			{
				return;
			}
			if (_currentGameItemUIData._contentType == EContentType.MusicPack)
			{
				if (IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
				{
					if (_inputMusicPackName.isFocused)
					{
						_inputSongTitle.ActivateInputField();
					}
					else if (_inputSongTitle.isFocused)
					{
						_inputArtistName.ActivateInputField();
					}
					else
					{
						_inputMusicPackName.ActivateInputField();
					}
				}
				else
				{
					_inputMusicPackName.ActivateInputField();
				}
			}
			else if (_inputTitle.isFocused)
			{
				_inputDescription.ActivateInputField();
			}
			else
			{
				_inputTitle.ActivateInputField();
			}
		}

		private void SetGameItemDataDirty(bool bDirty)
		{
			if (_bGameItemDataDirty != bDirty)
			{
				_bGameItemDataDirty = bDirty;
			}
		}

		private void UpdateButtonISelectableStatusPublish()
		{
			ExtContentUIUtils.SetSelectableInteractable(_buttonPublish, !IsAnyEditModeOn() && _bGameItemDataValid && !_bGameItemDataDirty);
		}

		private void UpdateButtonISelectableStatusAll()
		{
			UpdateButtonISelectableStatusPublish();
			UpdateButtonISelectableStatusCreateUpdate();
			UpdateButtonISelectableStatusDelete();
			UpdateButtonISelectableStatusSteamWorkshop();
		}

		private void UpdateButtonISelectableStatusCreateUpdate()
		{
			bool bCanInteract = !IsAnyEditModeOn() && _bGameItemDataValid && _bGameItemDataDirty;
			ExtContentUIUtils.SetSelectableInteractable(_buttonCreateUpdate, bCanInteract);
		}

		private void UpdateButtonISelectableStatusDelete()
		{
			ExtContentUIUtils.SetSelectableInteractable(_buttonDelete, !IsAnyEditModeOn() && _buttonDeleteAllowed);
		}

		private void UpdateButtonISelectableStatusSteamWorkshop()
		{
			ExtContentUIUtils.SetSelectableInteractable(_buttonSteamWorkshop, _buttonSteamWorkshopAllowed);
		}

		private void UpdateUIElementDisplayTitleTypeAndDescActiveStatus(bool bShow)
		{
			_gameObjectContentTypeAndSubTypePanel?.SetActive(bShow);
			_gameObjectItemTitlePanel?.SetActive(bShow);
			_gameObjectItemDescriptionPanel?.SetActive(bShow);
		}

		private void UpdateUIElementDisplayItemTitle()
		{
			UpdateUIElementDisplayItemTextInput(_inputTitle, _currentGameItemUIData._title);
		}

		private void UpdateUIElementDisplayItemDescription()
		{
			UpdateUIElementDisplayItemTextInput(_inputDescription, _currentGameItemUIData._description);
		}

		private void UpdateUIElementDisplayItemMusicPackName()
		{
			UpdateUIElementDisplayItemTextInput(_inputMusicPackName, _currentGameItemUIData._title);
		}

		private void UpdateUIElementDisplayItemSongTitle()
		{
			UpdateUIElementDisplayItemTextInput(_inputSongTitle, _currentGameItemUIData._songTitle);
		}

		private void UpdateUIElementDisplayItemArtistName()
		{
			UpdateUIElementDisplayItemTextInput(_inputArtistName, _currentGameItemUIData._artistName);
		}

		private void ProcessUpdateUIPlaybackProgressBar()
		{
			if (_currentGameItemUIData._contentType == EContentType.MusicPack && _currentGameItemUIData._trackProgressPanel != null)
			{
				_currentGameItemUIData._trackProgressPanel.RefreshUI();
			}
		}

		private void CheckCreateTrackProgressPanel()
		{
			if (_currentGameItemUIData._trackProgressPanel == null)
			{
				CreateTrackProgressPanel();
			}
		}

		private void CreateTrackProgressPanel()
		{
			if (!(_gameObjectTrackProgressPanelParent != null) || !(_prefabTrackProgressPanel != null))
			{
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(_prefabTrackProgressPanel, _gameObjectTrackProgressPanelParent.transform);
			if (gameObject != null)
			{
				_currentGameItemUIData._trackProgressPanel = gameObject.GetComponent<DynamicPlaylistUITrackProgressPanel>();
				if (_currentGameItemUIData._trackProgressPanel != null)
				{
					_currentGameItemUIData._trackProgressPanel.Init(_dynamicPlaylistManager);
				}
			}
		}

		private void DestroyTrackProgressPanel()
		{
			if (_currentGameItemUIData._trackProgressPanel != null)
			{
				_currentGameItemUIData._trackProgressPanel.DeInit();
				_currentGameItemUIData._trackProgressPanel = null;
			}
		}

		private void UpdateUIElementDisplayItemTextInput(InputField inputUIElement, string text)
		{
			inputUIElement.text = text;
			inputUIElement.gameObject.SetActive(value: true);
		}

		private void UpdateUIElementCurrentMusicItemInputPanels()
		{
			bool active = _currentGameItemUIData._contentType == EContentType.MusicPack && _currentGameItemUIData._currentMusicPackItemIndex < 0;
			if (_gameObjectSongTitleDisablePanel != null)
			{
				_gameObjectSongTitleDisablePanel.SetActive(active);
			}
			if (_gameObjectArtistNameDisablePanel != null)
			{
				_gameObjectArtistNameDisablePanel.SetActive(active);
			}
		}

		private void UpdateUIElementDisplayCreditsScreen()
		{
			UpdateUIElementDisplayTitleTypeAndDescActiveStatus(bShow: true);
			UpdateUIElementDisplayItemTitle();
			UpdateUIElementDisplayItemDescription();
		}

		private void UpdateContentTypeUIElements()
		{
			switch (_currentGameItemUIData._contentType)
			{
			case EContentType.CreditsScreen:
				UpdateUIElementDisplayCreditsScreen();
				break;
			case EContentType.Rug:
				UpdateUIElementDisplayPictureBase();
				break;
			case EContentType.Picture:
				UpdateUIElementDisplayPictureBase();
				break;
			case EContentType.Floor:
				UpdateUIElementDisplayPictureBase();
				break;
			case EContentType.Wall:
				UpdateUIElementDisplayPictureBase();
				break;
			case EContentType.MusicPack:
				UpdateUIElementDisplayMusicPack();
				break;
			case EContentType.SandboxSave:
				break;
			}
		}

		private void UpdateUIElementDisplayPictureBase()
		{
			UpdateUIElementDisplayTitleTypeAndDescActiveStatus(bShow: true);
			UpdateUIElementDisplayItemTitle();
			UpdateUIElementDisplayItemDescription();
			UpdateContentSubTypeDropDownUIElements();
			UpdateUIElementDisplayItemCostSlider();
			UpdateUIElementDisplayItemKudoshSlider();
			UpdateContentTypeSpecificUIElementsActiveStatus();
		}

		private void UpdateUIElementDisplayMusicPack()
		{
			UpdateUIElementDisplayTitleTypeAndDescActiveStatus(bShow: false);
			UpdateUIElementDisplayItemMusicPackName();
			UpdateUIElementDisplayItemSongTitle();
			UpdateUIElementDisplayItemArtistName();
			UpdateContentTypeSpecificUIElementsActiveStatus();
		}

		private void InitialiseGameItemUIData(EContentType contentType, bool bNewItem, GameItemBase existingGameItem)
		{
			InitialiseGameItemUIDataCommon(bNewItem, existingGameItem);
			switch (contentType)
			{
			case EContentType.CreditsScreen:
				InitialiseGameItemUIDataCreditsScreen(bNewItem, existingGameItem);
				break;
			case EContentType.Rug:
				InitialiseGameItemUIDataRug(bNewItem, existingGameItem as GameItemPictureBase);
				break;
			case EContentType.Picture:
				InitialiseGameItemUIDataPicture(bNewItem, existingGameItem as GameItemPictureBase);
				break;
			case EContentType.Floor:
				InitialiseGameItemUIDataFloor(bNewItem, existingGameItem as GameItemPictureBase);
				break;
			case EContentType.Wall:
				InitialiseGameItemUIDataWall(bNewItem, existingGameItem as GameItemPictureBase);
				break;
			case EContentType.MusicPack:
				InitialiseGameItemUIDataMusicPack(bNewItem, existingGameItem as GameItemMusicPack);
				break;
			case EContentType.SandboxSave:
				break;
			}
		}

		private void InitialiseGameItemUIDataOnContentTypeChanged(EContentType contentType, bool bNewItem, GameItemBase existingGameItem)
		{
			if (contentType == EContentType.MusicPack)
			{
				InitialiseGameItemUIDataMusicPack(bNewItem, existingGameItem as GameItemMusicPack);
			}
		}

		private void InitialiseGameItemUIDataCommon(bool bNewItem, GameItemBase existingGameItem)
		{
			if (bNewItem)
			{
				_currentGameItemUIData._title = string.Empty;
				_currentGameItemUIData._description = string.Empty;
			}
			else
			{
				_currentGameItemUIData._title = existingGameItem.Title;
				_currentGameItemUIData._description = existingGameItem.Description;
			}
		}

		private void InitialiseGameItemUIDataCreditsScreen(bool bNewItem, GameItemBase existingGameItem)
		{
		}

		private void InitialiseGameItemUIDataRug(bool bNewItem, GameItemPictureBase existingGameItem)
		{
			InitialiseGameItemUIDataPictureBase(bNewItem, existingGameItem, GetGameItemPictureBaseConfig(EContentType.Rug, existingGameItem, _currentGameItemUIData._contentSubType));
		}

		private void InitialiseGameItemUIDataPicture(bool bNewItem, GameItemPictureBase existingGameItem)
		{
			InitialiseGameItemUIDataPictureBase(bNewItem, existingGameItem, GetGameItemPictureBaseConfig(EContentType.Picture, existingGameItem, _currentGameItemUIData._contentSubType));
		}

		private void InitialiseGameItemUIDataFloor(bool bNewItem, GameItemPictureBase existingGameItem)
		{
			InitialiseGameItemUIDataPictureBase(bNewItem, existingGameItem, GetGameItemPictureBaseConfig(EContentType.Floor, existingGameItem, _currentGameItemUIData._contentSubType));
		}

		private void InitialiseGameItemUIDataWall(bool bNewItem, GameItemPictureBase existingGameItem)
		{
			InitialiseGameItemUIDataPictureBase(bNewItem, existingGameItem, GetGameItemPictureBaseConfig(EContentType.Wall, existingGameItem, _currentGameItemUIData._contentSubType));
		}

		private int GetPictureBaseConfigTypeIndex(GameItemPictureBase gameItem)
		{
			int result = 0;
			if (gameItem != null)
			{
				result = gameItem.GetConfigIndexForSubTypeID();
			}
			return result;
		}

		private GameItemPictureBase.GameItemPictureBaseConfig GetGameItemPictureBaseConfig(EContentType contentType, GameItemPictureBase gameItemPictureBase, string defaultContentSubType)
		{
			int num = -1;
			if (gameItemPictureBase != null)
			{
				num = gameItemPictureBase.GetConfigIndexForSubTypeID();
			}
			else if (!defaultContentSubType.IsNullOrEmpty())
			{
				num = GetCurrentSubTypesIndexForSubType(defaultContentSubType);
			}
			if (num < 0)
			{
				num = 0;
			}
			return ExtContentUtils.GetPictureBaseConfigForContentType(contentType, num);
		}

		private GameItemPictureBase.GameItemPictureBaseConfig GetCurrentUIDataPictureBaseConfig()
		{
			int num = _currentGameItemUIData._contentSubTypeItems.IndexOf(_currentGameItemUIData._contentSubType);
			if (num < 0)
			{
				num = 0;
			}
			return ExtContentUtils.GetPictureBaseConfigForContentType(_currentGameItemUIData._contentType, num);
		}

		private void InitialiseGameItemUIDataPictureBase(bool bNewItem, GameItemBase existingGameItem, GameItemPictureBase.GameItemPictureBaseConfig config)
		{
			SetGameItemUIDataForPictureBaseConfig(config);
			_currentGameItemUIData._mainImageSpec = new ExtContentImageSpec();
			_currentGameItemUIData._iconImageSpec = new ExtContentImageSpec();
			_currentGameItemUIData._itemIconVariationIndex = -1;
			_currentGameItemUIData._mainImageModTime = DateTime.Now;
			_currentGameItemUIData._iconImageModTime = DateTime.Now;
			if (!bNewItem)
			{
				GameItemPictureBase gameItemPictureBase = existingGameItem as GameItemPictureBase;
				_currentGameItemUIData._itemPrice = gameItemPictureBase.ItemPrice;
				_currentGameItemUIData._itemKudosh = gameItemPictureBase.ItemKudosh;
				SetCurrentContentSubType(gameItemPictureBase.ItemSubTypeID);
				_contentSourceLocalMods.ReadWriteLocalModSourceMetaDataPictureBase(bWrite: false, gameItemPictureBase.InstalledFolderPathSpec, ref _currentGameItemUIData._mainImageSpec, ref _currentGameItemUIData._iconImageSpec, ref _currentGameItemUIData._mainImageModTime, ref _currentGameItemUIData._iconImageModTime, ref _currentGameItemUIData._itemIconVariationIndex);
			}
			ValidateRandomIconVariationIndex();
			UpdateSelectableImagesBGColour();
			_selectableImageIconTexture.Initialise(GetImageAspectRatioIcon(config), _currentGameItemUIData._iconImageSpec);
			_selectableImageMainTexture.Initialise(GetImageAspectRatioMain(config), _currentGameItemUIData._mainImageSpec);
		}

		private void SetGameItemUIDataForPictureBaseConfig(GameItemPictureBase.GameItemPictureBaseConfig config, bool bResetItemValuesToDefault = true)
		{
			if (config != null)
			{
				if (bResetItemValuesToDefault)
				{
					_currentGameItemUIData._itemPrice = config._itemCostDefault;
					_currentGameItemUIData._itemKudosh = config._itemKudoshDefault;
				}
				_currentGameItemUIData._itemPriceRoundValue = config._itemCostRoundValue;
				_currentGameItemUIData._itemKudoshRoundValue = config._itemKudoshRoundValue;
				_currentGameItemUIData._itemPriceDefault = config._itemCostDefault;
				_currentGameItemUIData._itemPriceMin = config._itemCostMin;
				_currentGameItemUIData._itemPriceMax = config._itemCostMax;
				_currentGameItemUIData._itemKudoshDefault = config._itemKudoshDefault;
				_currentGameItemUIData._itemKudoshMin = config._itemKudoshMin;
				_currentGameItemUIData._itemKudoshMax = config._itemKudoshMax;
				_currentGameItemUIData._itemPrice = GetValidItemPriceValue(_currentGameItemUIData._itemPrice);
				_currentGameItemUIData._itemKudosh = GetValidItemKudoshValue(_currentGameItemUIData._itemKudosh);
			}
		}

		private void InitialiseGameItemUIDataMusicPack(bool bNewItem, GameItemMusicPack existingGameItem)
		{
			_currentGameItemUIData._bMusicPackItemDecodeFatalErrorMsgShown = false;
			_currentGameItemUIData._musicPackSourceItems.Clear();
			_currentGameItemUIData._songTitle = string.Empty;
			_currentGameItemUIData._artistName = string.Empty;
			_currentGameItemUIData._songTitleOriginal = string.Empty;
			_currentGameItemUIData._artistNameOriginal = string.Empty;
			if (!bNewItem)
			{
				_contentSourceLocalMods.ReadWriteLocalModSourceMetaDataMusicPack(bWrite: false, existingGameItem.InstalledFolderPathSpec, ref _currentGameItemUIData._musicPackSourceItems);
			}
			if (_currentGameItemUIData._musicPackAddNewItemButtonRow == null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_prefabMusicItemRow, _gameObjectMusicItemsContent.transform);
				_currentGameItemUIData._musicPackAddNewItemButtonRow = gameObject.GetComponent<ExtContentUIMusicItemRow>();
				_currentGameItemUIData._musicPackAddNewItemButtonRow.Init(this, bIsAddNewButtonItem: true, string.Empty);
			}
			UpdateMusicPackUIRowsFromSourceItems();
			SetCurrentMusicItemRowIndex((_currentGameItemUIData._musicPackItemRows.Count <= 0) ? (-1) : 0, bForce: true);
			CheckCreateTrackProgressPanel();
		}

		private void UpdateUIElementScreenTitle(string screenTitle)
		{
			_textScreenTitle.text = screenTitle;
		}

		private void UpdateInputFieldCharacterLimits()
		{
			if (_inputSongTitle != null)
			{
				_inputSongTitle.characterLimit = _dynamicPlaylistManager.Config._maxSongAndArtistNameLength;
			}
			if (_inputArtistName != null)
			{
				_inputArtistName.characterLimit = _dynamicPlaylistManager.Config._maxSongAndArtistNameLength;
			}
		}

		private void UpdateUIElementButtonsText()
		{
			UpdateUIElementButtonTextCreateUpdate();
		}

		private void UpdateUIElementButtonTextCreateUpdate()
		{
			TMP_Text componentInChildren = _buttonCreateUpdate.gameObject.GetComponentInChildren<TMP_Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = (_currentConfig._bCreateNewItem ? ExtContentMessages.GetMessageString(EMessageType.GameItemUIButtonCreate) : ExtContentMessages.GetMessageString(EMessageType.GameItemUIButtonUpdate));
			}
		}

		private void SetInitialSliderExtents()
		{
			SetInitialSliderExtentsCost();
			SetInitialSliderExtentsKudosh();
		}

		private void SetInitialSliderExtentsCost()
		{
			_sliderCost.onValueChanged.RemoveListener(OnSliderItemCostInput);
			_sliderCost.minValue = _currentGameItemUIData._itemPriceMin;
			_sliderCost.maxValue = _currentGameItemUIData._itemPriceMax;
			_sliderCost.onValueChanged.AddListener(OnSliderItemCostInput);
		}

		private void SetInitialSliderExtentsKudosh()
		{
			_sliderKudosh.onValueChanged.RemoveListener(OnSliderItemKudoshInput);
			_sliderKudosh.minValue = _currentGameItemUIData._itemKudoshMin;
			_sliderKudosh.maxValue = _currentGameItemUIData._itemKudoshMax;
			_sliderKudosh.onValueChanged.AddListener(OnSliderItemKudoshInput);
		}

		private void UpdateUIElementDisplayItemCostSlider()
		{
			_sliderCost.value = _currentGameItemUIData._itemPrice;
			UpdateUIElementCostSliderText();
		}

		private void UpdateUIElementCostSliderText()
		{
			string text = StringUtils.FormatCurrency(_currentGameItemUIData._itemPrice);
			_textSliderCost.text = text;
		}

		private void UpdateUIElementDisplayItemKudoshSlider()
		{
			_sliderKudosh.value = _currentGameItemUIData._itemKudosh;
			UpdateUIElementKudoshSliderText();
		}

		private void UpdateCostSliderArrowsVisibility()
		{
			bool active = false;
			bool active2 = false;
			if (_currentGameItemUIData._itemPrice < _currentGameItemUIData._itemPriceMax)
			{
				active = true;
			}
			if (_currentGameItemUIData._itemPrice > _currentGameItemUIData._itemPriceMin)
			{
				active2 = true;
			}
			_buttonCostSliderIncrement.gameObject.SetActive(active);
			_buttonCostSliderDecrement.gameObject.SetActive(active2);
		}

		private void UpdateKudoshSliderArrowsVisibility()
		{
			bool active = false;
			bool active2 = false;
			if (_currentGameItemUIData._itemKudosh < _currentGameItemUIData._itemKudoshMax)
			{
				active = true;
			}
			if (_currentGameItemUIData._itemKudosh > _currentGameItemUIData._itemKudoshMin)
			{
				active2 = true;
			}
			_buttonKudoshSliderIncrement.gameObject.SetActive(active);
			_buttonKudoshSliderDecrement.gameObject.SetActive(active2);
		}

		private void OnSliderItemCostInput(float value)
		{
			SetItemCost((int)value);
		}

		private bool SetItemCost(int value)
		{
			bool result = false;
			value = GetValidItemPriceValue(value);
			if (_currentGameItemUIData._itemPrice != value)
			{
				_currentGameItemUIData._itemPrice = value;
				UpdateCostSliderArrowsVisibility();
				UpdateUIElementCostSliderText();
				OnGameItemValueChanged();
				result = true;
			}
			return result;
		}

		private void UpdateUIElementKudoshSliderText()
		{
			string text = StringUtils.FormatSilverCurrency(_currentGameItemUIData._itemKudosh);
			_textSliderKudosh.text = text;
			_textPreviewIconValue.text = text;
		}

		private void OnSliderItemKudoshInput(float value)
		{
			SetItemKudosh((int)value);
		}

		private bool SetItemKudosh(int value)
		{
			bool result = false;
			value = GetValidItemKudoshValue(value);
			if (_currentGameItemUIData._itemKudosh != value)
			{
				_currentGameItemUIData._itemKudosh = value;
				UpdateKudoshSliderArrowsVisibility();
				UpdateUIElementKudoshSliderText();
				OnGameItemValueChanged();
				result = true;
			}
			return result;
		}

		private void OnCostSliderIncrButton()
		{
			if (SetItemCost(_currentGameItemUIData._itemPrice + _currentGameItemUIData._itemPriceRoundValue))
			{
				UpdateUIElementDisplayItemCostSlider();
			}
		}

		private void OnCostSliderDecrButton()
		{
			if (SetItemCost(_currentGameItemUIData._itemPrice - _currentGameItemUIData._itemPriceRoundValue))
			{
				UpdateUIElementDisplayItemCostSlider();
			}
		}

		private void OnKudoshSliderIncrButton()
		{
			if (SetItemKudosh(_currentGameItemUIData._itemKudosh + _currentGameItemUIData._itemKudoshRoundValue))
			{
				UpdateUIElementDisplayItemKudoshSlider();
			}
		}

		private void OnKudoshSliderDecrButton()
		{
			if (SetItemKudosh(_currentGameItemUIData._itemKudosh - _currentGameItemUIData._itemKudoshRoundValue))
			{
				UpdateUIElementDisplayItemKudoshSlider();
			}
		}

		private int GetValidItemPriceValue(int value)
		{
			return Mathf.Clamp(value - value % _currentGameItemUIData._itemPriceRoundValue, _currentGameItemUIData._itemPriceMin, _currentGameItemUIData._itemPriceMax);
		}

		private int GetValidItemKudoshValue(int value)
		{
			return Mathf.Clamp(value - value % _currentGameItemUIData._itemKudoshRoundValue, _currentGameItemUIData._itemKudoshMin, _currentGameItemUIData._itemKudoshMax);
		}

		private void CheckGameItemValueChanged()
		{
			if (!_currentGameItemUIData.IsGameItemdataEqualTo(_previousGameItemUIData))
			{
				OnGameItemValueChanged();
			}
		}

		private void OnGameItemValueChanged()
		{
			SetGameItemDataDirty(bDirty: true);
			UpdateGameItemDataValidStatus();
			UpdateButtonISelectableStatusAll();
			_previousGameItemUIData.UpdateGameItemDataFrom(_currentGameItemUIData);
		}

		private void UpdateMusicPackAddNewItemButtonRowPosition()
		{
			if (_currentGameItemUIData._musicPackAddNewItemButtonRow != null)
			{
				_currentGameItemUIData._musicPackAddNewItemButtonRow.gameObject.transform.SetAsLastSibling();
			}
		}

		private void OnMusicPackItemRowSelectionChanged()
		{
			if (_currentGameItemUIData._currentMusicPackItemIndex >= 0)
			{
				ExtContentUIMusicItemRow extContentUIMusicItemRow = _currentGameItemUIData._musicPackItemRows[_currentGameItemUIData._currentMusicPackItemIndex];
				_currentGameItemUIData._songTitle = extContentUIMusicItemRow.SongTitle;
				_currentGameItemUIData._artistName = extContentUIMusicItemRow.ArtistName;
				_currentGameItemUIData._songTitleOriginal = extContentUIMusicItemRow.MusicPackSourceItem.TrackNameOriginal;
				_currentGameItemUIData._artistNameOriginal = extContentUIMusicItemRow.MusicPackSourceItem.ArtistNameOriginal;
			}
			else
			{
				_currentGameItemUIData._songTitle = string.Empty;
				_currentGameItemUIData._artistName = string.Empty;
				_currentGameItemUIData._songTitleOriginal = string.Empty;
				_currentGameItemUIData._artistNameOriginal = string.Empty;
			}
			UpdateUIElementCurrentMusicItemInputPanels();
			UpdateUIElementDisplayItemSongTitle();
			UpdateUIElementDisplayItemArtistName();
		}

		private void UpdateCurrentMusicItemRowData()
		{
			if (_currentGameItemUIData._currentMusicPackItemIndex >= 0)
			{
				_currentGameItemUIData._musicPackItemRows[_currentGameItemUIData._currentMusicPackItemIndex].SetData(_currentGameItemUIData._artistName, _currentGameItemUIData._songTitle);
			}
		}

		private int GetMaxNumAllowedMusicItems()
		{
			return ExtContentUtils.ExtContentManager.Config.ExtContentConfig.Instance._configMusicPack.Instance._maxNumMusicFilesPerPack;
		}

		private void OnAddMusicItemButton()
		{
			ExtContentUIUtils.CallOpenFileBrowserFunction(OnAddMusicItemButtonImpl);
		}

		private void OnAddMusicItemButtonImpl()
		{
			bool flag = false;
			int maxNumAllowedMusicItems = GetMaxNumAllowedMusicItems();
			if (_currentGameItemUIData._musicPackItemRows.Count < maxNumAllowedMusicItems)
			{
				string promptStr = ScriptLocalization.Menu_UGC_ImageBrowser.SelectMusicFiles_CS;
				if (!_locTextAddMusicItem.Term.IsNullOrEmpty())
				{
					promptStr = _locTextAddMusicItem.Translation;
				}
				string currentFileSpec = _lastChosenMusicFileSpec;
				if (_lastChosenMusicFileSpec.IsNullOrEmpty() && _currentGameItemUIData._musicPackSourceItems.Count > 0)
				{
					currentFileSpec = _currentGameItemUIData._musicPackSourceItems[0].FileSpec;
				}
				string[] array = ExtContentUIUtils.PromptUserForMusicFileSpecs(promptStr, currentFileSpec);
				if (array != null && array.Length != 0)
				{
					bool flag2 = false;
					List<string> list = new List<string>();
					int i = 0;
					for (int num = array.Length; i < num; i++)
					{
						string fileName = Path.GetFileName(array[i]);
						if (_currentGameItemUIData._musicPackItemRows.Find((ExtContentUIMusicItemRow row) => Path.GetFileName(row.FileSpec).Equals(fileName, StringComparison.OrdinalIgnoreCase)) == null)
						{
							list.Add(array[i]);
						}
						else
						{
							flag2 = true;
						}
					}
					if (flag2)
					{
						array = list.ToArray();
						ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.DuplicateMusicPackItemsEncounteredTitle), ExtContentMessages.GetMessageString(EMessageType.DuplicateMusicPackItemsEncounteredBody));
					}
				}
				bool flag3 = false;
				if (array != null && array.Length != 0)
				{
					_lastChosenMusicFileSpec = array[0];
					string currentMusicPackSourceItemId = GetCurrentMusicPackSourceItemId();
					int num2 = Mathf.Min(maxNumAllowedMusicItems, array.Length);
					if (num2 > 0)
					{
						_currentGameItemUIData._bMusicPackItemDecodeFatalErrorMsgShown = false;
					}
					for (int num3 = 0; num3 < num2; num3++)
					{
						string retArtistName = string.Empty;
						string retTrackName = string.Empty;
						_dynamicPlaylistManager.ReadArtistAndTrackNamesForMP3File(array[num3], ref retArtistName, ref retTrackName);
						ValidateArtistNameUnknown(ref retArtistName);
						ValidateTrackNameUnknown(ref retTrackName, array[num3]);
						if (AddMusicPackItemRow(currentMusicPackSourceItemId, array[num3], retArtistName, retTrackName, retArtistName, retTrackName))
						{
							flag3 = true;
							_dynamicPlaylistManager.CheckAddMP3AudioInfoUpdatePending(array[num3]);
						}
					}
					if (array.Length > maxNumAllowedMusicItems)
					{
						flag = true;
					}
				}
				if (flag3)
				{
					OnGameItemValueChanged();
					RepositionMusicItemsScrollAreaToEnd();
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.MaxNumMusicPackItemsAddedTitle), string.Format(ExtContentMessages.GetMessageString(EMessageType.MaxNumMusicPackItemsAddedBody), maxNumAllowedMusicItems));
			}
		}

		private void OnMusicItemMoveUpButton()
		{
		}

		private void OnMusicItemMoveDownButton()
		{
		}

		private void UpdateMusicPackSourceItemsFromUIRows()
		{
			_currentGameItemUIData._musicPackSourceItems.Clear();
			foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
			{
				_currentGameItemUIData._musicPackSourceItems.Add(musicPackItemRow.MusicPackSourceItem);
			}
		}

		private string GetCurrentMusicPackSourceItemId()
		{
			string result = string.Empty;
			if (_currentConfig._updateGameItem != null)
			{
				result = _currentConfig._updateGameItem.ContentID;
			}
			return result;
		}

		private void UpdateMusicPackUIRowsFromSourceItems()
		{
			foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
			{
				musicPackItemRow.DeInit();
			}
			_currentGameItemUIData._musicPackItemRows.Clear();
			if (_currentGameItemUIData._musicPackSourceItems.Count > 0)
			{
				string currentMusicPackSourceItemId = GetCurrentMusicPackSourceItemId();
				foreach (MusicPackSourceItem musicPackSourceItem in _currentGameItemUIData._musicPackSourceItems)
				{
					AddMusicPackItemRow(currentMusicPackSourceItemId, musicPackSourceItem.FileSpec, musicPackSourceItem.ArtistName, musicPackSourceItem.TrackName, musicPackSourceItem.ArtistNameOriginal, musicPackSourceItem.TrackNameOriginal);
				}
			}
			else
			{
				UpdateMusicPackAddNewItemButtonRowPosition();
			}
			RepositionMusicItemsScrollAreaToEnd();
		}

		private bool AddMusicPackItemRow(string sourceItemId, string fileSpec, string artistName, string trackName, string artistNameOriginal, string trackNameOriginal)
		{
			bool result = false;
			ExtContentUIMusicItemRow extContentUIMusicItemRow = null;
			if (_prefabMusicItemRow != null && _gameObjectMusicItemsContent != null)
			{
				bool flag = false;
				string text = ExtContentUtils.SanitizeFileOrFolderName(fileSpec).ToLower();
				foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
				{
					if (ExtContentUtils.SanitizeFileOrFolderName(musicPackItemRow.MusicPackSourceItem.FileSpec).ToLower() == text)
					{
						extContentUIMusicItemRow = musicPackItemRow;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					extContentUIMusicItemRow = UnityEngine.Object.Instantiate(_prefabMusicItemRow, _gameObjectMusicItemsContent.transform).GetComponent<ExtContentUIMusicItemRow>();
					if (extContentUIMusicItemRow != null)
					{
						MusicPackSourceItem nusicPackSourceItem = new MusicPackSourceItem(fileSpec, artistName, trackName, artistNameOriginal, trackNameOriginal);
						AddUIMusicItemRow(extContentUIMusicItemRow, sourceItemId, nusicPackSourceItem);
						result = true;
					}
				}
				else
				{
					extContentUIMusicItemRow.MusicPackSourceItem.ArtistName = artistName;
					extContentUIMusicItemRow.MusicPackSourceItem.TrackName = trackName;
					extContentUIMusicItemRow.MusicPackSourceItem.ArtistNameOriginal = artistNameOriginal;
					extContentUIMusicItemRow.MusicPackSourceItem.TrackNameOriginal = trackNameOriginal;
				}
			}
			return result;
		}

		public void AddUIMusicItemRow(ExtContentUIMusicItemRow row, string sourceItemId, MusicPackSourceItem nusicPackSourceItem)
		{
			_ = _currentGameItemUIData._musicPackItemRows.Count;
			row.Init(this, bIsAddNewButtonItem: false, sourceItemId, nusicPackSourceItem);
			_currentGameItemUIData._musicPackItemRows.Add(row);
			if (!IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
			{
				SetCurrentMusicItemRowIndex(0);
			}
			UpdateMusicPackAddNewItemButtonRowPosition();
		}

		public void RemoveUIMusicItemRow(ExtContentUIMusicItemRow row)
		{
			if (_dynamicPlaylistManager.IsPlayingPreviewMP3FileSpec(row.FileSpec))
			{
				_dynamicPlaylistManager.StopPreview();
			}
			_dynamicPlaylistManager.CheckRemoveMP3AudioInfoUpdatePending(row.FileSpec);
			int num = _currentGameItemUIData._musicPackItemRows.IndexOf(row);
			int num2 = _currentGameItemUIData._currentMusicPackItemIndex;
			if (num2 >= 0)
			{
				if (num2 != num)
				{
					if (num2 > num)
					{
						num2--;
					}
				}
				else
				{
					num2 = -1;
				}
			}
			_currentGameItemUIData._musicPackItemRows.Remove(row);
			row.DeInit();
			UnityEngine.Object.Destroy(row.gameObject);
			OnGameItemValueChanged();
			UpdateMusicPackAddNewItemButtonRowPosition();
			SetCurrentMusicItemRowIndex(num2);
		}

		private void DeInitMusicPackItemRows()
		{
			int i = 0;
			for (int count = _currentGameItemUIData._musicPackItemRows.Count; i < count; i++)
			{
				_currentGameItemUIData._musicPackItemRows[i].DeInit();
				UnityEngine.Object.Destroy(_currentGameItemUIData._musicPackItemRows[i].gameObject);
				_currentGameItemUIData._musicPackItemRows[i] = null;
			}
			_currentGameItemUIData._musicPackItemRows.Clear();
			UpdateMusicPackAddNewItemButtonRowPosition();
			SetCurrentMusicItemRowIndex(-1);
		}

		public void PromptForNewMusicPackItem()
		{
			OnAddMusicItemButton();
		}

		public void SelectMusicItemRow(ExtContentUIMusicItemRow row)
		{
			int rowIndex = _currentGameItemUIData._musicPackItemRows.IndexOf(row);
			SetCurrentMusicItemRowIndex(rowIndex);
		}

		public void ValidateArtistName(ref string artistName)
		{
			if (artistName.IsNullOrEmpty())
			{
				artistName = ScriptLocalization.Misc.Unknown_CS;
			}
		}

		public void ValidateTrackName(ref string trackName, string mp3FileSpec)
		{
			if (trackName.IsNullOrEmpty() && !mp3FileSpec.IsNullOrEmpty())
			{
				trackName = Path.GetFileName(mp3FileSpec);
				string[] array = trackName.Split('.');
				if (array.Length >= 2)
				{
					trackName = array[0];
				}
			}
		}

		public void ValidateArtistNameOnEdit(ref string artistName, string artistNameOriginal)
		{
			if (artistName.IsNullOrEmpty())
			{
				artistName = artistNameOriginal;
			}
		}

		public void ValidateTrackNameOnEdit(ref string trackName, string trackNameOriginal)
		{
			if (trackName.IsNullOrEmpty())
			{
				trackName = trackNameOriginal;
			}
		}

		public void ValidateArtistNameUnknown(ref string artistName)
		{
			if (artistName.IsNullOrEmpty())
			{
				artistName = ScriptLocalization.Misc.Unknown_CS;
			}
		}

		public void ValidateTrackNameUnknown(ref string trackName, string mp3FileSpec)
		{
			if (trackName.IsNullOrEmpty() && !mp3FileSpec.IsNullOrEmpty())
			{
				trackName = Path.GetFileName(mp3FileSpec);
				string[] array = trackName.Split('.');
				if (array.Length >= 2)
				{
					trackName = array[0];
				}
			}
		}

		private bool IsMusicItemRowIndexValid(int index)
		{
			if (index >= 0)
			{
				return index < _currentGameItemUIData._musicPackItemRows.Count;
			}
			return false;
		}

		private void SetCurrentMusicItemRowIndex(int rowIndex, bool bForce = false)
		{
			if (_currentGameItemUIData._currentMusicPackItemIndex != rowIndex || bForce)
			{
				if (IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
				{
					_currentGameItemUIData._musicPackItemRows[_currentGameItemUIData._currentMusicPackItemIndex].SetItemSelected(bSelected: false);
				}
				_currentGameItemUIData._currentMusicPackItemIndex = rowIndex;
				if (IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
				{
					_currentGameItemUIData._musicPackItemRows[_currentGameItemUIData._currentMusicPackItemIndex].SetItemSelected(bSelected: true);
				}
				OnMusicPackItemRowSelectionChanged();
			}
		}

		public void OnTrackAudioInfoUpdated(DynPlaylistTrackItem updatedTrackItem)
		{
			OnMusicItemPreviewStatusChanged(updatedTrackItem);
		}

		public void OnMusicItemPreviewStatusChanged(DynPlaylistTrackItem updatedTrackItem)
		{
			foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
			{
				musicPackItemRow.OnMusicItemPreviewStatusChanged(updatedTrackItem);
			}
		}

		public void OnMusicItemRowDecodeFatalError()
		{
			if (!_currentGameItemUIData._bMusicPackItemDecodeFatalErrorMsgShown)
			{
				_currentGameItemUIData._bMusicPackItemDecodeFatalErrorMsgShown = true;
				ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			}
		}

		public void StartMusicItemRowDragMode(ExtContentUIMusicItemRow row)
		{
			if (!_currentGameItemUIData._bMusicItemRowDragModeOn && IsMusicItemRowIndexValid(_currentGameItemUIData._currentMusicPackItemIndex))
			{
				_currentGameItemUIData._bMusicItemRowDragModeOn = true;
			}
		}

		private void ProcessMusicItemRows()
		{
			if (_currentGameItemUIData._contentType != EContentType.MusicPack)
			{
				return;
			}
			foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
			{
				musicPackItemRow.FrameUpdate();
			}
		}

		private void ProcessMusicItemRowDragMode()
		{
			if (!_currentGameItemUIData._bMusicItemRowDragModeOn)
			{
				return;
			}
			if (Input.GetMouseButton(0))
			{
				int num = -1;
				int currentMusicPackItemIndex = _currentGameItemUIData._currentMusicPackItemIndex;
				ExtContentUIMusicItemRow value = _currentGameItemUIData._musicPackItemRows[currentMusicPackItemIndex];
				int count = _currentGameItemUIData._musicPackItemRows.Count;
				Vector2 screenPoint = Input.mousePosition;
				RectTransform component = _scrollRectMusicPackContents.GetComponent<RectTransform>();
				if (RectTransformUtility.RectangleContainsScreenPoint(component, screenPoint))
				{
					for (int i = 0; i < count; i++)
					{
						if (i != _currentGameItemUIData._currentMusicPackItemIndex && RectTransformUtility.RectangleContainsScreenPoint(_currentGameItemUIData._musicPackItemRows[i].gameObject.GetComponent<RectTransform>(), screenPoint))
						{
							num = i;
							break;
						}
					}
				}
				else
				{
					float num2 = (float)Screen.height - screenPoint.y;
					Rect screenSpaceRect = component.GetScreenSpaceRect();
					float num3 = 0f;
					float num4 = 0f;
					if (num2 < screenSpaceRect.yMin)
					{
						num3 = 1f;
						num4 = screenSpaceRect.yMin - num2;
					}
					else if (num2 > screenSpaceRect.yMax)
					{
						num3 = -1f;
						num4 = num2 - screenSpaceRect.yMax;
					}
					if (num3 != 0f)
					{
						float t = Mathf.Clamp((num4 - 40f) / 260f, 0f, 1f);
						float num5 = Mathf.Lerp(0.5f, 50f, t) / (float)count * Time.unscaledDeltaTime * num3;
						float verticalNormalizedPosition = _scrollRectMusicPackContents.verticalNormalizedPosition;
						verticalNormalizedPosition = Mathf.Clamp(verticalNormalizedPosition + num5, 0f, 1f);
						_scrollRectMusicPackContents.verticalNormalizedPosition = verticalNormalizedPosition;
						int num6 = ((!(num3 > 0f)) ? (count - 1) : 0);
						int num7 = ((num3 > 0f) ? 1 : (-1));
						int num8 = Mathf.CeilToInt(screenSpaceRect.yMin);
						int num9 = Mathf.CeilToInt(screenSpaceRect.yMax);
						int num10 = 0;
						int num11 = num6;
						while (num10 < count)
						{
							Rect screenSpaceRect2 = _currentGameItemUIData._musicPackItemRows[num11].gameObject.GetComponent<RectTransform>().GetScreenSpaceRect();
							if (Mathf.CeilToInt(screenSpaceRect2.yMin) >= num8 && Mathf.CeilToInt(screenSpaceRect2.yMax) <= num9)
							{
								num = num11;
								break;
							}
							num10++;
							num11 += num7;
						}
					}
				}
				if (num < 0 || !IsMusicItemRowIndexValid(num) || num == currentMusicPackItemIndex)
				{
					return;
				}
				SetCurrentMusicItemRowIndex(-1);
				if (num > currentMusicPackItemIndex)
				{
					for (int j = currentMusicPackItemIndex; j < num; j++)
					{
						_currentGameItemUIData._musicPackItemRows[j] = _currentGameItemUIData._musicPackItemRows[j + 1];
					}
				}
				else
				{
					for (int num12 = currentMusicPackItemIndex; num12 > num; num12--)
					{
						_currentGameItemUIData._musicPackItemRows[num12] = _currentGameItemUIData._musicPackItemRows[num12 - 1];
					}
				}
				_currentGameItemUIData._musicPackItemRows[num] = value;
				for (int k = 0; k < count; k++)
				{
					_currentGameItemUIData._musicPackItemRows[k].gameObject.transform.SetSiblingIndex(k);
				}
				SetCurrentMusicItemRowIndex(num);
				UpdateMusicPackAddNewItemButtonRowPosition();
			}
			else
			{
				_currentGameItemUIData._bMusicItemRowDragModeOn = false;
			}
		}

		private void RepositionMusicItemsScrollAreaToEnd()
		{
			if (_scrollRectMusicPackContents != null)
			{
				_scrollRectMusicPackContents.verticalNormalizedPosition = 0f;
			}
		}

		private bool UpdateGameItemDataValidStatus()
		{
			bool bGameItemDataValid = _bGameItemDataValid;
			_bGameItemDataValid = ValidateAllGameItemData();
			return bGameItemDataValid != _bGameItemDataValid;
		}

		private bool ValidateAllGameItemData()
		{
			bool result = true;
			switch (_currentGameItemUIData._contentType)
			{
			case EContentType.CreditsScreen:
				result = ValidateAllGameItemDataCreditsScreen();
				break;
			case EContentType.Rug:
				result = ValidateAllGameItemDataPictureBase();
				break;
			case EContentType.Picture:
				result = ValidateAllGameItemDataPictureBase();
				break;
			case EContentType.Floor:
				result = ValidateAllGameItemDataPictureBase();
				break;
			case EContentType.Wall:
				result = ValidateAllGameItemDataPictureBase();
				break;
			case EContentType.MusicPack:
				result = ValidateAllGameItemDataMusicPack();
				break;
			}
			return result;
		}

		private bool ValidateAllGameItemDataGeneral()
		{
			bool result = false;
			if (ExtContentType.IsValid(_currentGameItemUIData._contentType))
			{
				bool flag = false;
				if (!_currentGameItemUIData._title.IsNullOrEmpty())
				{
					result = true;
				}
			}
			return result;
		}

		private bool ValidateAllGameItemDataCreditsScreen()
		{
			return false;
		}

		private bool ValidateAllGameItemDataMusicPack()
		{
			bool result = false;
			if (ValidateAllGameItemDataGeneral() && _currentGameItemUIData._musicPackItemRows != null && _currentGameItemUIData._musicPackItemRows.Count > 0)
			{
				bool flag = false;
				foreach (ExtContentUIMusicItemRow musicPackItemRow in _currentGameItemUIData._musicPackItemRows)
				{
					if (!musicPackItemRow.DecodeFatalError)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					result = true;
				}
			}
			return result;
		}

		private bool ValidateAllGameItemDataPictureBase()
		{
			bool result = false;
			if (ValidateAllGameItemDataGeneral() && !_currentGameItemUIData._mainImageSpec.FileSpec.IsNullOrEmpty() && File.Exists(_currentGameItemUIData._mainImageSpec.FileSpec))
			{
				if (!_currentGameItemUIData._iconImageSpec.FileSpec.IsNullOrEmpty())
				{
					if (File.Exists(_currentGameItemUIData._iconImageSpec.FileSpec))
					{
						result = true;
					}
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		private void ValidateRandomIconVariationIndex(bool bForce = false)
		{
			GameItemPictureBase.GameItemPictureBaseConfig currentUIDataPictureBaseConfig = GetCurrentUIDataPictureBaseConfig();
			if (currentUIDataPictureBaseConfig != null && currentUIDataPictureBaseConfig._iconGenData != null && !currentUIDataPictureBaseConfig._iconGenData.IsVariationIndexValid(_currentGameItemUIData._itemIconVariationIndex))
			{
				_currentGameItemUIData._itemIconVariationIndex = currentUIDataPictureBaseConfig._iconGenData.GetRandomVariationIndex();
			}
		}

		private float GetImageAspectRatioMain(GameItemPictureBase.GameItemPictureBaseConfig config)
		{
			return config._preferredTextureWidth / config._preferredTextureHeight;
		}

		private float GetImageAspectRatioIcon(GameItemPictureBase.GameItemPictureBaseConfig config)
		{
			float num = GetImageAspectRatioMain(config);
			IconGenParams variationIconGenParams = IconGenData.GetVariationIconGenParams(config._iconGenData, _currentGameItemUIData._itemIconVariationIndex);
			if (variationIconGenParams != null)
			{
				num = variationIconGenParams.GetIconImageAspectRatio(num);
			}
			return num;
		}

		private void OnLocalize()
		{
			UpdateContentTypeUIElements();
			UpdateGameItemDataValidStatus();
			UpdateUIElementButtonsText();
			UpdateContentTypeDropDownUIElements();
			UpdateContentSubTypeDropDownUIElements();
			UpdatePreviewTitleText();
		}

		private void UpdateContentTypeSpecificUIElementsActiveStatus()
		{
			bool flag = true;
			bool flag2 = true;
			bool flag3 = true;
			switch (_currentGameItemUIData._contentType)
			{
			case EContentType.Floor:
			case EContentType.Wall:
				flag = false;
				flag3 = false;
				break;
			case EContentType.MusicPack:
				flag = false;
				flag2 = false;
				flag3 = false;
				break;
			}
			if (_gameObjectCostSliderDarken != null)
			{
				_gameObjectCostSliderDarken.SetActive(!flag);
			}
			if (_textSliderCost != null)
			{
				_textSliderCost.gameObject.SetActive(flag);
			}
			if (_sliderCost != null && !flag)
			{
				_sliderCost.minValue = 0f;
				_sliderCost.value = 0f;
			}
			if (_gameObjectKudoshSliderDarken != null)
			{
				_gameObjectKudoshSliderDarken.SetActive(!flag2);
			}
			if (_textSliderKudosh != null)
			{
				_textSliderKudosh.gameObject.SetActive(flag2);
			}
			if (_sliderKudosh != null && !flag2)
			{
				_sliderKudosh.minValue = 0f;
				_sliderKudosh.value = 0f;
			}
			if (_gameObjectSubTypeDarken != null)
			{
				_gameObjectSubTypeDarken.SetActive(!flag3);
			}
			if (_textContentSubTypeLabel != null)
			{
				_textContentSubTypeLabel.alpha = (flag3 ? 1f : _disabledTextUIElementAlphaValue);
			}
			if (_textContentSubTypeDropDownValue != null)
			{
				_textContentSubTypeDropDownValue.alpha = (flag3 ? 1f : 0f);
			}
		}

		private void HideExpandedDropdownControl(TMP_Dropdown dropdown)
		{
			if (!(dropdown != null) || !(dropdown.template != null) || !(dropdown.template.gameObject != null) || !(dropdown.template.gameObject.transform.parent != null))
			{
				return;
			}
			int i = 0;
			for (int childCount = dropdown.template.gameObject.transform.parent.childCount; i < childCount; i++)
			{
				GameObject gameObject = dropdown.template.gameObject.transform.parent.GetChild(i).gameObject;
				if (gameObject.name.ToLower() == "dropdown list")
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}

		private void CheckImageFileModTimesForSettingDataDirty()
		{
			bool flag = false;
			if (!_currentGameItemUIData._mainImageSpec.FileSpec.IsNullOrEmpty() && ExtContentUtils.IsFileModTimeMoreRecentThan(File.GetLastWriteTime(_currentGameItemUIData._mainImageSpec.FileSpec), _currentGameItemUIData._mainImageModTime))
			{
				flag = true;
			}
			if (!flag && !_currentGameItemUIData._iconImageSpec.FileSpec.IsNullOrEmpty() && ExtContentUtils.IsFileModTimeMoreRecentThan(File.GetLastWriteTime(_currentGameItemUIData._iconImageSpec.FileSpec), _currentGameItemUIData._iconImageModTime))
			{
				flag = true;
			}
			if (flag)
			{
				SetGameItemDataDirty(bDirty: true);
			}
		}

		private void UpdateLevelInstancesOfGameItemPictureBase(GameItemPictureBase gameItemPictureBase)
		{
		}
	}
}
