using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.ExtContent
{
	[DontSave]
	public class WorkshopPublishUIScreen : MonoBehaviour
	{
		public class Configuration
		{
			public GameItemBase _sourceGameItem;
		}

		private const bool cUseBusyIconCoroutine = false;

		private const float cWorkshopBusyModeTimeoutSecs = 60f;

		[SerializeField]
		private DynamicButton _buttonCloseMenu;

		[SerializeField]
		private DynamicButton _buttonCreateUpdate;

		[SerializeField]
		private DynamicButton _buttonUpdateOther;

		[SerializeField]
		private DynamicButton _buttonCreateAsNew;

		[SerializeField]
		private DynamicButton _buttonChoosePreviewImage;

		[SerializeField]
		private DynamicButton _buttonChoosePreviewImageLarge;

		[SerializeField]
		private DynamicButton _buttonResetPreviewImage;

		[SerializeField]
		private DynamicButton _buttonVisibilityPrivate;

		[SerializeField]
		private DynamicButton _buttonVisibilityFriends;

		[SerializeField]
		private DynamicButton _buttonVisibilityPublic;

		[SerializeField]
		private DynamicButton _buttonSteamWorkshop;

		[SerializeField]
		private DynamicButton _buttonSteamWorkshopRefresh;

		[SerializeField]
		private DynamicButton _buttonUserAgreementLink;

		[SerializeField]
		private InputField _inputTitle;

		[SerializeField]
		private InputField _inputDescription;

		[SerializeField]
		private Image _imagePreviewImage;

		[SerializeField]
		private Image _imageWorkshopBusyIcon;

		[SerializeField]
		private float _busyIconAngularVelocity;

		[SerializeField]
		private Image _imageBusyModeInputBlocker;

		[SerializeField]
		private TMP_Text _textScollPanelLabel;

		[SerializeField]
		private TMP_Text _textScollPanelContent;

		[SerializeField]
		private ScrollRect _scrollerPackContents;

		private ExtContentSourceLocalMods _contentSourceLocalMods;

		private ExtContentUIManager _uiManager;

		private ExtContentUIManager.ExtContentUIManagerConfig _uiManagerConfig;

		private WorkshopContentCreationManager _workshopContentCreationManager;

		private Transform _parentUITransform;

		private Transform _invokingSiblingUITransform;

		private bool _bIsShown;

		private bool _bAreEventsRegistered;

		private bool _itemDataValidForPublishing;

		private bool _bWorkshopBusyModeActive;

		private bool _bHidePending;

		private bool _bInitialiseScrollPanelPending;

		private bool _bGUIRootPushed;

		private bool _bScaleImageToCompletelyFillParent;

		private bool _bInputTitleActive;

		private bool _bInputTitleDeactivatePending;

		private bool _bInputDescriptionActive;

		private bool _bInputDescriptionDeactivatePending;

		private bool _bHideInvokingSiblingUI;

		private Configuration _currentConfig;

		private WorkshopItemMetaData _currentWorkshopMetaDataUI;

		private List<GameItemMetaData> _currentBundleGameItemsMetaData;

		private EContentType _currentWorkshopItemContentType;

		private string _currentPublishFolderSpec;

		private string _currentPreviewFileSpec;

		private Coroutine _busyIconAnimationCoroutine;

		private float _bWorkshopBusyModeActiveTimeSecs;

		public bool IsShown => _bIsShown;

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

		public void Setup(ExtContentUIManager uiManager, Transform uiParentTransform, ExtContentSourceLocalMods contentSourceLocalMods, WorkshopContentCreationManager workshopContentCreationManager)
		{
			_parentUITransform = uiParentTransform;
			_contentSourceLocalMods = contentSourceLocalMods;
			_uiManager = uiManager;
			_uiManagerConfig = _uiManager.Config;
			_workshopContentCreationManager = workshopContentCreationManager;
			_currentConfig = new Configuration();
			_currentWorkshopMetaDataUI = new WorkshopItemMetaData();
			_bGUIRootPushed = false;
			Hide(bForce: true);
		}

		public void Configure(GameItemBase sourceGameItem)
		{
			_currentConfig._sourceGameItem = sourceGameItem;
			_bScaleImageToCompletelyFillParent = sourceGameItem.ContentType == EContentType.SandboxSave;
		}

		public void Show(Transform invokingSiblingUI = null, bool bHideInvokingSiblingUI = false)
		{
			if (_bIsShown)
			{
				return;
			}
			_invokingSiblingUITransform = invokingSiblingUI;
			_bHideInvokingSiblingUI = bHideInvokingSiblingUI;
			bool flag = false;
			_bIsShown = true;
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
			_itemDataValidForPublishing = false;
			ProcessEventRegistration(bShow: true);
			SetHidePending(bSet: false);
			SetWorkshopBusyMode(bSet: false);
			if (InitialiseWorkshopItemUIData())
			{
				InitialiseUIElementsAll();
				UpdateUIElementsAll();
				CheckValidateAllWorkshopItemData();
				_uiManager.OnUIScreenShownStatusChange();
				flag = true;
			}
			if (!flag)
			{
				IssuePlayerErrorMessaheAndCloseScreen();
			}
		}

		public void Hide(bool bForce = false)
		{
			if (_bIsShown || bForce)
			{
				base.gameObject.SetActive(value: false);
				ProcessEventRegistration(bShow: false);
				SetWorkshopBusyMode(bSet: false);
				_bIsShown = false;
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
				ProcessInitialiseScrollPanelPending();
				ProcessOpenGameItemDevInfoPanel();
				ProcessWorkshopBusyMode();
				ProcessTextInputModeKeys();
				ProcessHidePending();
			}
		}

		private void IssuePlayerErrorMessaheAndCloseScreen()
		{
			ExtContentMessages.ShowPlayerGeneralErrorMessageBox();
			Hide();
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
				if (_buttonCloseMenu != null)
				{
					_buttonCloseMenu.onPrimaryDown.AddListener(OnCloseButton);
				}
				if (_buttonCreateUpdate != null)
				{
					_buttonCreateUpdate.onPrimaryDown.AddListener(OnCreateUpdateButton);
				}
				if (_buttonUpdateOther != null)
				{
					_buttonUpdateOther.onPrimaryDown.AddListener(OnUpdateOtherButton);
				}
				if (_buttonCreateAsNew != null)
				{
					_buttonCreateAsNew.onPrimaryDown.AddListener(OnCreateAsNewButton);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onEndEdit.AddListener(OnTitleInputEndEdit);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onEndEdit.AddListener(OnDescriptionInputEndEdit);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onValueChanged.AddListener(OnTitleInputValueChanged);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onValueChanged.AddListener(OnDescriptionInputValueChanged);
				}
				if (_buttonChoosePreviewImage != null)
				{
					_buttonChoosePreviewImage.onPrimaryDown.AddListener(OnChoosePreviewImageButton);
				}
				if (_buttonChoosePreviewImageLarge != null)
				{
					_buttonChoosePreviewImageLarge.onPrimaryDown.AddListener(OnChoosePreviewImageButton);
				}
				if (_buttonResetPreviewImage != null)
				{
					_buttonResetPreviewImage.onPrimaryDown.AddListener(OnResetPreviewImageButton);
				}
				if (_buttonVisibilityPrivate != null)
				{
					_buttonVisibilityPrivate.onPrimaryDown.AddListener(OnVisibilityPrivateButton);
				}
				if (_buttonVisibilityFriends != null)
				{
					_buttonVisibilityFriends.onPrimaryDown.AddListener(OnVisibilityFriendsButton);
				}
				if (_buttonVisibilityPublic != null)
				{
					_buttonVisibilityPublic.onPrimaryDown.AddListener(OnVisibilityPublicButton);
				}
				if (_buttonSteamWorkshop != null)
				{
					_buttonSteamWorkshop.onPrimaryDown.AddListener(OnSteamWorkshopButton);
				}
				if (_buttonSteamWorkshopRefresh != null)
				{
					_buttonSteamWorkshopRefresh.onPrimaryDown.AddListener(OnSteamWorkshopRefreshButton);
				}
				if (_buttonUserAgreementLink != null)
				{
					_buttonUserAgreementLink.onPrimaryDown.AddListener(OnUserAgreementLinkButton);
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
			}
			else
			{
				if (!_bAreEventsRegistered)
				{
					return;
				}
				_bAreEventsRegistered = false;
				if (_buttonCloseMenu != null)
				{
					_buttonCloseMenu.onPrimaryDown.RemoveListener(OnCloseButton);
				}
				if (_buttonCreateUpdate != null)
				{
					_buttonCreateUpdate.onPrimaryDown.RemoveListener(OnCreateUpdateButton);
				}
				if (_buttonUpdateOther != null)
				{
					_buttonUpdateOther.onPrimaryDown.RemoveListener(OnUpdateOtherButton);
				}
				if (_buttonCreateAsNew != null)
				{
					_buttonCreateAsNew.onPrimaryDown.RemoveListener(OnCreateAsNewButton);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onEndEdit.RemoveListener(OnTitleInputEndEdit);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onEndEdit.RemoveListener(OnDescriptionInputEndEdit);
				}
				if (_inputTitle != null)
				{
					_inputTitle.onValueChanged.RemoveListener(OnTitleInputValueChanged);
				}
				if (_inputDescription != null)
				{
					_inputDescription.onValueChanged.RemoveListener(OnDescriptionInputValueChanged);
				}
				if (_buttonChoosePreviewImage != null)
				{
					_buttonChoosePreviewImage.onPrimaryDown.RemoveListener(OnChoosePreviewImageButton);
				}
				if (_buttonChoosePreviewImageLarge != null)
				{
					_buttonChoosePreviewImageLarge.onPrimaryDown.RemoveListener(OnChoosePreviewImageButton);
				}
				if (_buttonResetPreviewImage != null)
				{
					_buttonResetPreviewImage.onPrimaryDown.RemoveListener(OnResetPreviewImageButton);
				}
				if (_buttonVisibilityPrivate != null)
				{
					_buttonVisibilityPrivate.onPrimaryDown.RemoveListener(OnVisibilityPrivateButton);
				}
				if (_buttonVisibilityFriends != null)
				{
					_buttonVisibilityFriends.onPrimaryDown.RemoveListener(OnVisibilityFriendsButton);
				}
				if (_buttonVisibilityPublic != null)
				{
					_buttonVisibilityPublic.onPrimaryDown.RemoveListener(OnVisibilityPublicButton);
				}
				if (_buttonSteamWorkshop != null)
				{
					_buttonSteamWorkshop.onPrimaryDown.RemoveListener(OnSteamWorkshopButton);
				}
				if (_buttonSteamWorkshopRefresh != null)
				{
					_buttonSteamWorkshopRefresh.onPrimaryDown.RemoveListener(OnSteamWorkshopRefreshButton);
				}
				if (_buttonUserAgreementLink != null)
				{
					_buttonUserAgreementLink.onPrimaryDown.RemoveListener(OnUserAgreementLinkButton);
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
			}
		}

		private bool InitialiseWorkshopItemUIData()
		{
			bool result = false;
			_currentWorkshopMetaDataUI.Reset();
			_currentPublishFolderSpec = string.Empty;
			_currentPreviewFileSpec = string.Empty;
			_currentBundleGameItemsMetaData = null;
			if (_currentConfig._sourceGameItem != null)
			{
				WorkshopItemMetaData retWorkshopMetaData = null;
				if (_contentSourceLocalMods.GetGameItemPublishBundleData(_currentConfig._sourceGameItem, ref _currentPublishFolderSpec, ref _currentWorkshopItemContentType, ref retWorkshopMetaData, ref _currentBundleGameItemsMetaData))
				{
					if (retWorkshopMetaData != null)
					{
						_currentWorkshopMetaDataUI = retWorkshopMetaData;
					}
					if (_currentWorkshopItemContentType != EContentType.Bundle && _currentWorkshopMetaDataUI != null && _currentConfig._sourceGameItem != null)
					{
						if (_currentWorkshopMetaDataUI.Title.IsNullOrEmpty())
						{
							_currentWorkshopMetaDataUI.Title = _currentConfig._sourceGameItem.DisplayName;
						}
						if (_currentWorkshopItemContentType != EContentType.SandboxSave && _currentWorkshopMetaDataUI.Description.IsNullOrEmpty())
						{
							_currentWorkshopMetaDataUI.Description = _currentConfig._sourceGameItem.Description;
						}
					}
					_workshopContentCreationManager.ReadWritWorkshopSourceParamsDatabse(bWrite: false, _currentPublishFolderSpec, ref _currentPreviewFileSpec);
					ValidateCurrentPreviewFileSpec();
					result = true;
				}
			}
			return result;
		}

		private void OnWorkshopItemValueChanged()
		{
			CheckValidateAllWorkshopItemData();
		}

		private void CheckValidateAllWorkshopItemData()
		{
			bool flag = ValidateAllWorkshopItemData();
			if (_itemDataValidForPublishing != flag)
			{
				_itemDataValidForPublishing = flag;
				UpdateUIElementPublishButtons();
			}
		}

		private bool ValidateAllWorkshopItemData()
		{
			bool result = false;
			if ((!IsCurrentItemPreviouslyPublished() || _currentConfig._sourceGameItem != null) && !_currentWorkshopMetaDataUI.Title.IsNullOrEmpty())
			{
				result = true;
			}
			return result;
		}

		private void OnTitleInputValueChanged(string str)
		{
			string title = _currentWorkshopMetaDataUI.Title;
			_currentWorkshopMetaDataUI.Title = str;
			CheckValidateAllWorkshopItemData();
			_currentWorkshopMetaDataUI.Title = title;
		}

		private void OnDescriptionInputValueChanged(string str)
		{
		}

		private char OnTitleInputValidateInput(char inChar)
		{
			char result = '\0';
			if (inChar != '\t')
			{
				result = inChar;
			}
			return result;
		}

		private char OnDescriptionInputValidateInput(char inChar)
		{
			char result = '\0';
			if (inChar != '\t')
			{
				result = inChar;
			}
			return result;
		}

		private void OnTitleInputEndEdit(string str)
		{
			_bInputTitleDeactivatePending = true;
			_currentWorkshopMetaDataUI.Title = str.Trim();
			UpdateUIElementItemTitleText();
			OnWorkshopItemValueChanged();
		}

		private void OnDescriptionInputEndEdit(string str)
		{
			_bInputDescriptionDeactivatePending = true;
			_currentWorkshopMetaDataUI.Description = str.Trim();
			UpdateUIElementItemDescriptionText();
			OnWorkshopItemValueChanged();
		}

		private void ProcessTextInputModeKeys()
		{
			if (_bWorkshopBusyModeActive)
			{
				return;
			}
			if (!ExtContentMessages.MessageBox.IsVisibleOrClosing && Input.GetKeyDown(KeyCode.Tab))
			{
				if (_inputTitle.isFocused)
				{
					_inputDescription.ActivateInputField();
				}
				else
				{
					_inputTitle.ActivateInputField();
				}
			}
			if (!_bInputTitleActive && _inputTitle.isFocused)
			{
				_bInputTitleActive = true;
			}
			if (!_bInputDescriptionActive && _inputDescription.isFocused)
			{
				_bInputDescriptionActive = true;
			}
			if (Input.GetKeyDown(KeyCode.Escape) && !ExtContentMessages.MessageBox.IsVisibleOrClosing && !_bInputTitleActive && !_bInputDescriptionActive && !_bWorkshopBusyModeActive)
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

		private bool IsCurrentItemPreviouslyPublished()
		{
			return !_currentWorkshopMetaDataUI.PublishedFileId.IsNullOrEmpty();
		}

		private void ValidateCurrentPreviewFileSpec()
		{
			if (!_currentPreviewFileSpec.IsNullOrEmpty() && !File.Exists(_currentPreviewFileSpec))
			{
				_currentPreviewFileSpec = string.Empty;
			}
			if (_currentPreviewFileSpec.IsNullOrEmpty())
			{
				switch (_currentWorkshopItemContentType)
				{
				case EContentType.Rug:
				case EContentType.Picture:
				case EContentType.Floor:
				case EContentType.Wall:
					if (_currentConfig._sourceGameItem is GameItemPictureBase gameItemPictureBase)
					{
						_currentPreviewFileSpec = gameItemPictureBase.IconFileSpec;
					}
					break;
				case EContentType.SandboxSave:
					if (_currentConfig._sourceGameItem != null)
					{
						_currentPreviewFileSpec = ExtContentUtils.GetPathSpec(_currentConfig._sourceGameItem.InstalledFolderPathSpec, "PreviewIcon.png");
					}
					break;
				case EContentType.Bundle:
				{
					if (_currentBundleGameItemsMetaData.Count <= 0)
					{
						break;
					}
					GameItemMetaData gameItemMetaData = _currentBundleGameItemsMetaData[0];
					if (gameItemMetaData == null)
					{
						break;
					}
					string value = string.Empty;
					if (!gameItemMetaData.Get("IconFileName", ref value))
					{
						break;
					}
					string pathSpec = ExtContentUtils.GetPathSpec(gameItemMetaData.InstalledFolderPathSpec, value);
					if (!File.Exists(pathSpec))
					{
						break;
					}
					bool flag = true;
					string pathSpec2 = ExtContentUtils.GetPathSpec(_currentPublishFolderSpec, "WorkshopPreviewIcon.png");
					if (File.Exists(pathSpec2))
					{
						DateTime lastWriteTime = File.GetLastWriteTime(pathSpec2);
						DateTime lastWriteTime2 = File.GetLastWriteTime(pathSpec);
						if (lastWriteTime > lastWriteTime2)
						{
							flag = false;
						}
					}
					if (flag)
					{
						if (GenerateBundlePreviewIcon(pathSpec, pathSpec2))
						{
							_currentPreviewFileSpec = pathSpec2;
						}
						else
						{
							_currentPreviewFileSpec = pathSpec;
						}
					}
					else
					{
						_currentPreviewFileSpec = pathSpec2;
					}
					break;
				}
				}
			}
			_currentPreviewFileSpec = _workshopContentCreationManager.GetValidWorkshopItemPreviewImageFileSpec(_currentPreviewFileSpec, _currentWorkshopItemContentType);
		}

		private void UpdateCurrentPreviewImage(string imageFileSpec)
		{
			string currentPreviewFileSpec = _currentPreviewFileSpec;
			if (!UpdateCurrentPreviewImageInternal(imageFileSpec))
			{
				UpdateCurrentPreviewImageInternal(currentPreviewFileSpec);
				ExtContentMessages.ShowErrorMessageBox(ExtContentMessages.GetMessageString(EMessageType.ImageFileFailedToLoadMessageBoxTitle), ExtContentMessages.GetMessageString(EMessageType.ImageFileFailedToLoadMessageBoxBody));
			}
		}

		private bool UpdateCurrentPreviewImageInternal(string imageFileSpec)
		{
			_currentPreviewFileSpec = ExtContentUtils.NormalisePathSpec(imageFileSpec);
			ValidateCurrentPreviewFileSpec();
			_currentWorkshopMetaDataUI.PreviewFileName = Path.GetFileName(_currentPreviewFileSpec);
			return UpdateUIElementPreviewImageFromDisk();
		}

		private bool GenerateBundlePreviewIcon(string sourceIconFileSpec, string targetIconFileSpec)
		{
			bool flag = false;
			if (ExtContentUtils.ExtContentManager.ContentSourceWorkshop.Config._bundleIndicatorTexture2D != null)
			{
				Texture2D texture2D = ExtContentTextureUtils.LoadTexture2D(sourceIconFileSpec);
				if (texture2D != null)
				{
					ExtContentSourceWorkshop.WorkshopConfig config = ExtContentUtils.ExtContentManager.ContentSourceWorkshop.Config;
					ExtContentTextureUtils.OverlayTextures2DAt(texture2D, config._bundleIndicatorTexture2D, config._bundleIndicatorNormPosition.x, config._bundleIndicatorNormPosition.y);
					if (ExtContentTextureUtils.SaveTexture2D(texture2D, targetIconFileSpec))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				ExtContentMessages.LogDebug($"Successfully created workshop bundle preview icon file '{targetIconFileSpec}' from game item icon file '{sourceIconFileSpec}'");
			}
			else
			{
				ExtContentMessages.LogError($"Error creating workshop bundle preview icon file '{targetIconFileSpec}' from game item icon file '{sourceIconFileSpec}'");
			}
			return flag;
		}

		private bool UpdateUIElementPreviewImageFromDisk()
		{
			bool result = false;
			Texture2D texture2DToUpdate = ExtContentTextureUtils.LoadTexture2D(_currentPreviewFileSpec);
			if (texture2DToUpdate != null)
			{
				result = true;
				ExtContentTextureUtils.ConstrainTexture2D(ref texture2DToUpdate, ExtContentUtils.TexturesConfig.MaxStagedIconTextureDimension);
				ExtContentTextureUtils.UpdateImageTexture(ref _imagePreviewImage, texture2DToUpdate, _bScaleImageToCompletelyFillParent);
			}
			return result;
		}

		private bool AreVisibilityButtonsEnabled()
		{
			return !_bWorkshopBusyModeActive;
		}

		private void SetWorkshopBusyMode(bool bSet)
		{
			_imageWorkshopBusyIcon.gameObject.SetActive(bSet);
			_imageBusyModeInputBlocker.gameObject.SetActive(bSet);
			ExtContentUIUtils.SetSelectableInteractable(_buttonCloseMenu, !bSet);
			_bWorkshopBusyModeActive = bSet;
			_bWorkshopBusyModeActiveTimeSecs = 0f;
			SetWorkshopBusyModeCoroutineStatus();
			UpdateUIElementPublishButtons();
			UpdateUIElementItemVisibility();
			UpdateUIElementSteamWorkshopButton();
			UpdateUIElementSteamWorkshopRefreshButton();
			UpdateUIElementUserAgreementLinkButton();
		}

		private void SetWorkshopBusyModeCoroutineStatus()
		{
		}

		private IEnumerator BusyIconAnimationCoroutine()
		{
			yield break;
		}

		private void ProcessWorkshopBusyMode()
		{
			if (_bWorkshopBusyModeActive)
			{
				ProcessWorkshopBusyModeInternal();
			}
		}

		private void ProcessWorkshopBusyModeInternal()
		{
			ProcessWorkshopBusyModeAnimateCursor();
			ProcessWorkshopBusyModeTimeout();
			ProcessBusyModeInputs();
		}

		private void ProcessWorkshopBusyModeAnimateCursor()
		{
			if (_bWorkshopBusyModeActive)
			{
				ExtContentUIUtils.ProcessBusyIndicatorAnimation(_imageWorkshopBusyIcon, _busyIconAngularVelocity);
			}
		}

		private void ProcessWorkshopBusyModeTimeout()
		{
			if (_bWorkshopBusyModeActive)
			{
				_bWorkshopBusyModeActiveTimeSecs += Time.unscaledDeltaTime;
				if (_bWorkshopBusyModeActiveTimeSecs >= 60f)
				{
					_contentSourceLocalMods.AbortPublishFolderToWorkshop();
				}
			}
		}

		private void ProcessBusyModeInputs()
		{
			if (_bWorkshopBusyModeActive && ExtContentUtils.IsGeneralDevModifierOn() && Input.GetKeyDown(KeyCode.Return))
			{
				_contentSourceLocalMods.AbortPublishFolderToWorkshop();
			}
		}

		private void InitialiseUIElementsAll()
		{
			SetWorkshopItemVisibility(_currentWorkshopMetaDataUI.Visibility);
			InitialiseUIElementsScrollPanel();
		}

		private void UpdateUIElementsAll()
		{
			UpdateUIElementItemTitle();
			UpdateUIElementItemDescription();
			UpdateUIElementItemPreviewImage();
			UpdateUIElementItemVisibility();
			UpdateUIElementPublishButtons();
			UpdateUIElementSteamWorkshopButton();
			UpdateUIElementSteamWorkshopRefreshButton();
			UpdateUIElementUserAgreementLinkButton();
			UpdateUIElementScrollPanel();
		}

		private void UpdateUIElementTextInput(InputField inputUIElement, string text)
		{
			inputUIElement.text = text;
		}

		private void UpdateUIElementItemTitle()
		{
			UpdateUIElementTextInput(_inputTitle, _currentWorkshopMetaDataUI.Title);
		}

		private void UpdateUIElementItemDescription()
		{
			UpdateUIElementTextInput(_inputDescription, _currentWorkshopMetaDataUI.Description);
		}

		private void UpdateUIElementItemTitleText()
		{
			_inputTitle.text = _currentWorkshopMetaDataUI.Title;
		}

		private void UpdateUIElementItemDescriptionText()
		{
			_inputDescription.text = _currentWorkshopMetaDataUI.Description;
		}

		private void UpdateUIElementItemPreviewImage()
		{
			UpdateUIElementPreviewImageFromDisk();
		}

		private void UpdateUIElementItemVisibility()
		{
			bool bCanInteract = AreVisibilityButtonsEnabled();
			ExtContentUIUtils.SetSelectableSelectability(_buttonVisibilityPrivate, bCanInteract, _currentWorkshopMetaDataUI.Visibility == EItemVisibility.Private);
			ExtContentUIUtils.SetSelectableSelectability(_buttonVisibilityFriends, bCanInteract, _currentWorkshopMetaDataUI.Visibility == EItemVisibility.Friends);
			ExtContentUIUtils.SetSelectableSelectability(_buttonVisibilityPublic, bCanInteract, _currentWorkshopMetaDataUI.Visibility == EItemVisibility.Public);
		}

		private void UpdateUIElementPublishButtons()
		{
			bool flag = !_itemDataValidForPublishing || _bWorkshopBusyModeActive;
			ExtContentUIUtils.SetSelectableInteractable(_buttonCreateUpdate, !flag);
			ExtContentUIUtils.SetSelectableInteractable(_buttonUpdateOther, bCanInteract: false);
			ExtContentUIUtils.SetSelectableInteractable(_buttonCreateAsNew, !flag && IsCurrentItemPreviouslyPublished());
			UpdateUIElementButtonCreateUpdateText();
		}

		private void UpdateUIElementSteamWorkshopButton()
		{
			bool bWorkshopBusyModeActive = _bWorkshopBusyModeActive;
			ExtContentUIUtils.SetSelectableInteractable(_buttonSteamWorkshop, !bWorkshopBusyModeActive);
		}

		private void UpdateUIElementSteamWorkshopRefreshButton()
		{
			bool bWorkshopBusyModeActive = _bWorkshopBusyModeActive;
			ExtContentUIUtils.SetSelectableInteractable(_buttonSteamWorkshopRefresh, !bWorkshopBusyModeActive);
		}

		private void UpdateUIElementUserAgreementLinkButton()
		{
			bool bWorkshopBusyModeActive = _bWorkshopBusyModeActive;
			ExtContentUIUtils.SetSelectableInteractable(_buttonUserAgreementLink, !bWorkshopBusyModeActive);
		}

		private void UpdateUIElementButtonCreateUpdateText()
		{
			TMP_Text componentInChildren = _buttonCreateUpdate.gameObject.GetComponentInChildren<TMP_Text>();
			if (componentInChildren != null)
			{
				componentInChildren.text = ((!IsCurrentItemPreviouslyPublished()) ? ExtContentMessages.GetMessageString(EMessageType.PublishItemUIButtonCreate) : ExtContentMessages.GetMessageString(EMessageType.PublishItemUIButtonUpdate));
			}
		}

		private void InitialiseUIElementsScrollPanel()
		{
			_bInitialiseScrollPanelPending = true;
		}

		private void ProcessInitialiseScrollPanelPending()
		{
			if (_bInitialiseScrollPanelPending)
			{
				_bInitialiseScrollPanelPending = false;
				_scrollerPackContents.normalizedPosition = new Vector2(0f, 1f);
			}
		}

		private void UpdateUIElementScrollPanel()
		{
			_textScollPanelLabel.text = ExtContentMessages.GetMessageString(EMessageType.PublishScreenThisPackContains);
			List<string> list = new List<string>();
			if (_currentBundleGameItemsMetaData.Count > 0)
			{
				int i = 0;
				for (int count = _currentBundleGameItemsMetaData.Count; i < count; i++)
				{
					GameItemMetaData gameItemMetaData = _currentBundleGameItemsMetaData[i];
					string value = string.Empty;
					string value2 = string.Empty;
					gameItemMetaData.Get("DisplayName", ref value);
					if (value.IsNullOrEmpty())
					{
						gameItemMetaData.Get("Title", ref value);
					}
					gameItemMetaData.Get("ContentType", ref value2);
					string arg = value2;
					EContentType contentType = ExtContentType.StringToContentType(value2);
					if (ExtContentType.IsValid(contentType))
					{
						arg = ExtContentType.ContentTypeToStringLoc(contentType);
					}
					string text = $"{value} ({arg})";
					if (i < count - 1)
					{
						text += "\n";
					}
					list.Add(text);
				}
			}
			_textScollPanelContent.text = string.Empty;
			foreach (string item in list)
			{
				_textScollPanelContent.text += item;
			}
			_scrollerPackContents.content.sizeDelta = new Vector2(_scrollerPackContents.content.sizeDelta.x, (float)list.Count * _textScollPanelContent.fontSize);
		}

		private void SetWorkshopItemVisibility(EItemVisibility visibility)
		{
			_currentWorkshopMetaDataUI.Visibility = visibility;
			UpdateUIElementItemVisibility();
			OnWorkshopItemValueChanged();
		}

		private void OnCloseButton()
		{
			Hide();
		}

		private void OnCreateUpdateButtonGeneral(bool bCreateNew)
		{
			if (WorkshopUtils.CheckSteamWorkshopFeaturesAvailableForPublishing())
			{
				if (_contentSourceLocalMods.PublishLocalModGameItemToWorkshop(_currentConfig._sourceGameItem, _currentWorkshopMetaDataUI.Title, _currentWorkshopMetaDataUI.Description, _currentPreviewFileSpec, _currentWorkshopMetaDataUI.Visibility, bCreateNew, OnPublishComplete))
				{
					SetWorkshopBusyMode(bSet: true);
				}
				else
				{
					ShowWorkshopPublishErrorMessage();
				}
			}
		}

		private void OnPublishComplete(bool bSuccess, bool bAborted, bool bNewItem, WorkshopItemMetaData workshopItemMetaData, string publishFolderSpec)
		{
			SetWorkshopBusyMode(bSet: false);
			if (bSuccess)
			{
				_currentWorkshopMetaDataUI = workshopItemMetaData;
				UpdateUIElementPublishButtons();
				UpdateUIElementItemVisibility();
				UpdateUIElementSteamWorkshopButton();
				UpdateUIElementSteamWorkshopRefreshButton();
				UpdateUIElementUserAgreementLinkButton();
				SetHidePending(bSet: true);
			}
			else if (bAborted)
			{
				ShowWorkshopPublishAbortMessage();
			}
			else
			{
				ShowWorkshopPublishErrorMessage();
			}
		}

		private void ShowWorkshopPublishErrorMessage()
		{
			ExtContentMessages.ShowErrorMessageBox(ExtContentMessages.GetMessageString(EMessageType.WorkshopPublishErrorMessageTitle), ExtContentMessages.GetMessageString(EMessageType.WorkshopPublishErrorMessageBody));
		}

		private void ShowWorkshopPublishAbortMessage()
		{
			ExtContentMessages.ShowMessageBoxOK(ExtContentMessages.GetMessageString(EMessageType.WorkshopPublishAbortMessageTitle), ExtContentMessages.GetMessageString(EMessageType.WorkshopPublishAbortMessageBody));
		}

		private void OnUpdateOtherButton()
		{
		}

		private void OnCreateUpdateButton()
		{
			OnCreateUpdateButtonGeneral(!IsCurrentItemPreviouslyPublished());
		}

		private void OnCreateAsNewButton()
		{
			OnCreateUpdateButtonGeneral(bCreateNew: true);
		}

		private void OnVisibilityPrivateButton()
		{
			SetWorkshopItemVisibility(EItemVisibility.Private);
		}

		private void OnVisibilityFriendsButton()
		{
			SetWorkshopItemVisibility(EItemVisibility.Friends);
		}

		private void OnVisibilityPublicButton()
		{
			SetWorkshopItemVisibility(EItemVisibility.Public);
		}

		private void OnChoosePreviewImageButton()
		{
			ExtContentUIUtils.CallOpenFileBrowserFunction(OnChoosePreviewImageButtonImpl);
		}

		private void OnChoosePreviewImageButtonImpl()
		{
			string text = string.Empty;
			bool flag = false;
			if (!ExtContentUIUtils.IsTextureFileResetModifierActive())
			{
				text = ExtContentUIUtils.PromptUserForImageFileSpec(ExtContentMessages.GetMessageString(EMessageType.FileBrowserSelectPreviewImage), _currentPreviewFileSpec, ExtContentUtils.TexturesConfig.SupportedTextureFileExtensions);
				if (!text.IsNullOrEmpty())
				{
					flag = true;
				}
			}
			else
			{
				ResetPreviewImage();
			}
			if (flag)
			{
				UpdateCurrentPreviewImage(text);
				OnWorkshopItemValueChanged();
			}
		}

		private void OnResetPreviewImageButton()
		{
			ResetPreviewImage();
		}

		private void ResetPreviewImage()
		{
			UpdateCurrentPreviewImage(string.Empty);
			OnWorkshopItemValueChanged();
		}

		private void OnSteamWorkshopButton()
		{
			string steamURL = string.Empty;
			string browserURL = string.Empty;
			ExtContentSourceWorkshop.GetSteamOverlayWorkshopItemURLsForPublishedFileId(_currentWorkshopMetaDataUI?.PublishedFileId, ref steamURL, ref browserURL);
			WorkshopUtils.OpenSteamOverlay(steamURL, browserURL);
		}

		private void OnSteamWorkshopRefreshButton()
		{
			ExtContentUtils.ExtContentManager.ContentSourceWorkshop.CheckDownloadItemsNeedingUpdate(bQueryAllSubscribedToItems: true, WorkshopUtils.cNullPublishedFileId);
		}

		private void OnUserAgreementLinkButton()
		{
			WorkshopUtils.OpenSteamOverlay(ExtContentUtils.ExtContentManager.Config.WorkshopContentCreationManagerConfig.Instance.steamOverlayWorkshopAgreementURL, ExtContentUtils.ExtContentManager.Config.WorkshopContentCreationManagerConfig.Instance.steamOverlayWorkshopAgreementURLBrowser);
		}

		private void ProcessOpenGameItemDevInfoPanel()
		{
			ExtContentUtils.CheckShowGameItemDevInfoPanelInput(_currentConfig._sourceGameItem, bCheckNoUGCUIScreensOpen: false);
		}
	}
}
