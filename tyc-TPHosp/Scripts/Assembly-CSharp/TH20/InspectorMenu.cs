using FullInspector;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class InspectorMenu : AnimatedMenuBase
	{
		public enum Mode
		{
			None = 0,
			Patient = 1,
			Staff = 2,
			Room = 3
		}

		[SerializeField]
		private InspectorMenuAssetReference _assetReference;

		[InspectorHeader("Header")]
		[SerializeField]
		private TMP_Text _headerTitle;

		[SerializeField]
		private GameObject _headerTitleInputFieldPanel;

		[SerializeField]
		private InputField _headerTitleInputField;

		[SerializeField]
		private DynamicButton _headerTitleEditButton;

		[SerializeField]
		private DynamicButton _headerTitleEditButtonText;

		[SerializeField]
		private DynamicButton _headerTitleInputAcceptButton;

		[SerializeField]
		private TooltipSpawner _headerTitleEditButtonTooltip;

		[SerializeField]
		private Image _headerIconImage;

		[SerializeField]
		private GameObject _headerPolaroidBacking;

		[SerializeField]
		private RawImage _headerIconImagePolaroid;

		[SerializeField]
		private DynamicButton _closeButton;

		[SerializeField]
		private ButtonAnimator[] _headerTabs;

		[SerializeField]
		private TMP_Text[] _headerTabTitles;

		[SerializeField]
		private Button _headerCycleLeftButton;

		[SerializeField]
		private Button _headerCycleRightButton;

		[SerializeField]
		private Button _headerGoToButton;

		[SerializeField]
		private GameObject _panelAlienDiscovered;

		[SerializeField]
		private GameObject _panelPaparazziDiscovered;

		[InspectorHeader("Body")]
		[SerializeField]
		private GameObject _body;

		[InspectorHeader("Footer")]
		[SerializeField]
		private GameObject _largeFooterPanel;

		[SerializeField]
		private ButtonAnimator[] _footerButtons;

		[SerializeField]
		private TooltipSpawner[] _footerTooltips;

		[SerializeField]
		private GameObject _smallFooterPanel;

		[SerializeField]
		private ButtonAnimator[] _smallFooterButtons;

		[SerializeField]
		private TMP_Text[] _smallFooterButtonTexts;

		[SerializeField]
		private TooltipSpawner[] _smallFooterTooltips;

		[SerializeField]
		private GameObject _smallFooterExtraPanel;

		[FullInspector.InspectorName("[DEPRECATED] _smallFooterExtraButtons")]
		[SerializeField]
		private ButtonAnimator _smallFooterExtraButtons;

		[FullInspector.InspectorName("[DEPRECATED] _smallFooterExtraButtonTexts")]
		[SerializeField]
		private TMP_Text _smallFooterExtraButtonTexts;

		[FullInspector.InspectorName("[DEPRECATED] _smallFooterExtraTooltips")]
		[SerializeField]
		private TooltipSpawner _smallFooterExtraTooltips;

		[SerializeField]
		private ButtonAnimator[] _smallFooterExtraMultiButtons;

		[SerializeField]
		private TMP_Text[] _smallFooterExtraMultiButtonTexts;

		[SerializeField]
		private TooltipSpawner[] _smallFooterExtraMultiTooltips;

		private Level _level;

		private GameObject _subMenuItem;

		private int _currentTabIndex;

		private Mode _currentMode;

		private bool _isClosingOrClosed;

		private bool _headerTitleEditModeOn;

		private bool _headerTitleInputCancelPending;

		private string _newUserSpecifiedHeaderTitle;

		private InspectorDataPatient _dataPatient;

		private InspectorDataRoom _dataRoom;

		private InspectorDataStaff _dataStaff;

		private InspectorData _data;

		private bool _bHeaderTitleEditModeEnabled = true;

		private const bool _bHeaderTitleEditButtonTextEnabled = true;

		public bool IsOpen
		{
			get
			{
				if (!_isClosingOrClosed)
				{
					return !IsFirstOpen();
				}
				return false;
			}
		}

		public void Initialise(Level level)
		{
			_level = level;
			if (_dataPatient == null)
			{
				_dataPatient = new InspectorDataPatient(this, level, _assetReference);
			}
			if (_dataStaff == null)
			{
				_dataStaff = new InspectorDataStaff(this, level, _assetReference);
			}
			if (_dataRoom == null)
			{
				_dataRoom = new InspectorDataRoom(this, level, _assetReference);
			}
			_data = null;
		}

		private void Start()
		{
			_closeButton.onPrimaryDown.AddListener(OnClosePressed);
			_headerCycleLeftButton.onClick.AddListener(OnHeaderCycleLeftPressed);
			_headerCycleRightButton.onClick.AddListener(OnHeaderCycleRightPressed);
			_headerGoToButton.onClick.AddListener(OnHeaderGoToButtonPressed);
			InitialiseHeaderTitleEdit();
			for (int i = 0; i < _headerTabs.Length; i++)
			{
				int tabIndex = i;
				_headerTabs[i].Button.onPrimaryDown.AddListener(delegate
				{
					OnTabPressed(tabIndex);
				});
			}
			for (int num = 0; num < _footerButtons.Length; num++)
			{
				int buttonIndex = num;
				_footerButtons[num].Button.onPrimaryDown.AddListener(delegate
				{
					OnFooterButtonPressed(buttonIndex);
				});
			}
			for (int num2 = 0; num2 < _footerTooltips.Length; num2++)
			{
				int buttonIndex2 = num2;
				_footerTooltips[num2].SetDataProvider(delegate(Tooltip tooltip)
				{
					if (_data != null)
					{
						tooltip.Text = (_data.IsFooterButtonVisible(buttonIndex2) ? _data.GetFooterButtonTooltip(buttonIndex2) : _data.GetFooterButtonNotVisibleTooltip(buttonIndex2));
					}
					else
					{
						tooltip.Text = string.Empty;
					}
				});
			}
			for (int num3 = 0; num3 < _smallFooterButtons.Length; num3++)
			{
				int buttonIndex3 = num3;
				_smallFooterButtons[num3].Button.onPrimaryDown.AddListener(delegate
				{
					OnFooterButtonPressed(buttonIndex3);
				});
			}
			for (int num4 = 0; num4 < _smallFooterTooltips.Length; num4++)
			{
				int buttonIndex4 = num4;
				_smallFooterTooltips[num4].SetDataProvider(delegate(Tooltip tooltip)
				{
					if (_data != null)
					{
						tooltip.Text = (_data.IsFooterButtonVisible(buttonIndex4) ? _data.GetFooterButtonTooltip(buttonIndex4) : _data.GetFooterButtonNotVisibleTooltip(buttonIndex4));
					}
					else
					{
						tooltip.Text = string.Empty;
					}
				});
			}
			for (int num5 = 0; num5 < _smallFooterExtraMultiButtons.Length; num5++)
			{
				if (!(_smallFooterExtraMultiButtons[num5] != null))
				{
					continue;
				}
				int buttonIndex5 = num5;
				_smallFooterExtraMultiButtons[num5].Button.onPrimaryDown.AddListener(delegate
				{
					if (_data.OnSmallFooterExtraButtonPressed(buttonIndex5))
					{
						CloseMenu();
					}
				});
			}
			for (int num6 = 0; num6 < _smallFooterExtraMultiTooltips.Length; num6++)
			{
				if (_smallFooterExtraMultiTooltips[num6] != null)
				{
					int buttonIndex6 = num6;
					_smallFooterExtraMultiTooltips[num6].SetDataProvider(delegate(Tooltip tooltip)
					{
						tooltip.Text = ((_data != null && _data.IsSmallFooterExtraButtonVisible(buttonIndex6)) ? _data.GetSmallFooterExtraTooltip(buttonIndex6) : string.Empty);
					});
				}
			}
		}

		public void CloseAndRestoreGeneralNotifications(bool bDoRestoreNotificationsMenu = true)
		{
			if (bDoRestoreNotificationsMenu)
			{
				GeneralNotificationMenu generalNotificationMenu = _level.HUD.FindMenu<GeneralNotificationMenu>(includeInactive: false);
				if (generalNotificationMenu != null)
				{
					generalNotificationMenu.RestoreMenu();
					ElectricityMenu componentInChildren = generalNotificationMenu.GetComponentInChildren<ElectricityMenu>();
					if (componentInChildren != null)
					{
						componentInChildren.Restore();
					}
				}
			}
			_isClosingOrClosed = true;
			_level.HUDEvents.OnInspectorClose.InvokeSafe();
			CloseMenu();
			if (_level != null)
			{
				_level.InputManager.Flush();
			}
		}

		public override void Destroy()
		{
			DeInitialiseHeaderTitleEdit();
			if (_dataPatient != null)
			{
				_dataPatient.Destroy();
			}
			if (_dataStaff != null)
			{
				_dataStaff.Destroy();
			}
			if (_dataRoom != null)
			{
				_dataRoom.Destroy();
			}
			if (_subMenuItem != null)
			{
				Object.Destroy(_subMenuItem);
			}
			_closeButton.onPrimaryDown.AddListener(OnClosePressed);
			_headerCycleLeftButton.onClick.RemoveListener(OnHeaderCycleLeftPressed);
			_headerCycleRightButton.onClick.RemoveListener(OnHeaderCycleRightPressed);
			_headerGoToButton.onClick.RemoveListener(OnHeaderGoToButtonPressed);
		}

		public void Inspect(Character character)
		{
			HeaderTitleInputCancel();
			if (character == null)
			{
				_data = null;
			}
			else if (_level == null)
			{
				_data = null;
			}
			else if (character is Patient patient)
			{
				if (!_dataPatient.SelectPatient(patient))
				{
					_data = null;
					return;
				}
				_data = _dataPatient;
				if (patient.IsAEPatient)
				{
					PlayerAmbulance playerAmbulance = _level.ChallengeManager?.PlayerAmbulanceDepartment?.FindAmbulanceForPatient(patient);
					if (playerAmbulance != null)
					{
						_level.CameraLogic.TrackObject(playerAmbulance.AmbulanceItem.Visual.GameObject.transform);
					}
					else
					{
						_level.CameraLogic.TrackObject(character.GameObject.transform);
					}
				}
				else
				{
					_level.CameraLogic.TrackObject(character.GameObject.transform);
				}
				_isClosingOrClosed = false;
				if (_currentMode != Mode.Patient)
				{
					OnTabPressed(0);
				}
				else
				{
					OnTabPressed(_currentTabIndex);
				}
				_currentMode = Mode.Patient;
				_bHeaderTitleEditModeEnabled = true;
				InitialiseHeaderTitleEdit();
				_level.HUDEvents.OnInspectorOpen.InvokeSafe(this, character);
			}
			else if (character is Staff staff)
			{
				if (!_dataStaff.SelectStaff(staff))
				{
					_data = null;
					return;
				}
				_data = _dataStaff;
				if (staff.CurrentJob is JobAmbulance jobAmbulance && jobAmbulance.Ambulance.IsStaffAboard(staff))
				{
					_level.CameraLogic.TrackObject(jobAmbulance.Ambulance.AmbulanceItem.Visual.GameObject.transform);
				}
				else if (character.GetComponent<StaffPickedUpState>() == null)
				{
					_level.CameraLogic.TrackObject(character.GameObject.transform);
				}
				else
				{
					_level.CameraLogic.TrackObject(null);
				}
				_isClosingOrClosed = false;
				if (_currentMode != Mode.Staff)
				{
					OnTabPressed(0);
				}
				else
				{
					OnTabPressed(_currentTabIndex);
				}
				_currentMode = Mode.Staff;
				if (staff.Definition._cantRename)
				{
					_bHeaderTitleEditModeEnabled = false;
					InitialiseHeaderTitleEdit();
				}
				else
				{
					_bHeaderTitleEditModeEnabled = true;
					InitialiseHeaderTitleEdit();
				}
				_level.HUDEvents.OnInspectorOpen.InvokeSafe(this, character);
			}
			else
			{
				_data = null;
			}
		}

		public void Inspect(Room room, bool selectQueueTab)
		{
			HeaderTitleInputCancel();
			if (!_dataRoom.SelectRoom(room))
			{
				_data = null;
				return;
			}
			_data = _dataRoom;
			_level.CameraLogic.TrackObject(room.GetCameraTrackObject().transform);
			_isClosingOrClosed = false;
			if (_currentMode != Mode.Room)
			{
				OnTabPressed(selectQueueTab ? 1 : 0);
			}
			else
			{
				OnTabPressed(selectQueueTab ? 1 : _currentTabIndex);
			}
			_currentMode = Mode.Room;
			_bHeaderTitleEditModeEnabled = true;
			InitialiseHeaderTitleEdit();
			_level.HUDEvents.OnInspectorOpenRoom.InvokeSafe(this, room);
		}

		protected override void Update()
		{
			base.Update();
			if (_data == null)
			{
				return;
			}
			_data.Update();
			ProcessHeaderTitleInput();
			_headerTitle.text = _data.GetHeaderTitle();
			if (_data.UsePolaroidBacking())
			{
				GameObjectUtils.SetActive(_headerIconImage.gameObject, isActive: false);
				GameObjectUtils.SetActive(_headerPolaroidBacking, isActive: true);
				_headerIconImagePolaroid.texture = _data.GetHeaderPolaroidTexture();
			}
			else
			{
				GameObjectUtils.SetActive(_headerIconImage.gameObject, isActive: true);
				GameObjectUtils.SetActive(_headerPolaroidBacking, isActive: false);
				_headerIconImage.overrideSprite = _data.GetHeaderIcon();
			}
			int tabCount = _data.GetTabCount();
			for (int i = 0; i < tabCount; i++)
			{
				bool flag = _data.IsTabEnabled(i);
				_headerTabs[i].CurrentState = (flag ? ((_currentTabIndex == i) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable) : ButtonAnimator.State.Unselectable);
				GameObjectUtils.SetActive(_headerTabs[i].Button.gameObject, isActive: true);
				TMP_Text obj = _headerTabTitles[i];
				obj.text = _data.GetTabText(i);
				obj.alpha = (flag ? 1f : 0.5f);
			}
			for (int j = tabCount; j < _headerTabs.Length; j++)
			{
				GameObjectUtils.SetActive(_headerTabs[j].gameObject, isActive: false);
			}
			bool flag2 = _data.UsesSmallFooter();
			bool flag3 = _data.UsesSmallFooterExtra();
			GameObjectUtils.SetActive(_smallFooterPanel, flag2);
			GameObjectUtils.SetActive(_largeFooterPanel, !flag2);
			GameObjectUtils.SetActive(_smallFooterExtraPanel, flag3);
			int footerButtonCount = _data.GetFooterButtonCount();
			int smallFooterExtraButtonCount = _data.GetSmallFooterExtraButtonCount();
			if (flag2)
			{
				for (int k = 0; k < footerButtonCount; k++)
				{
					ButtonAnimator buttonAnimator = _smallFooterButtons[k];
					DynamicButton button = _smallFooterButtons[k].Button;
					TMP_Text tMP_Text = _smallFooterButtonTexts[k];
					button.interactable = _data.IsFooterButtonEnabled(k);
					buttonAnimator.CurrentState = ButtonAnimator.State.Selectable;
					bool flag4 = _data.IsFooterButtonVisible(k);
					if (flag4)
					{
						buttonAnimator.CurrentState = ButtonAnimator.State.Selectable;
						button.image.overrideSprite = _data.GetFooterButtonImage(k);
					}
					else
					{
						buttonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
					}
					tMP_Text.text = _data.GetFooterButtonText(k);
					tMP_Text.alpha = (flag4 ? 1f : 0.5f);
				}
				for (int l = footerButtonCount; l < _smallFooterButtons.Length; l++)
				{
					GameObjectUtils.SetActive(_smallFooterButtons[l].gameObject, isActive: false);
				}
				if (flag3)
				{
					for (int m = 0; m < smallFooterExtraButtonCount; m++)
					{
						ButtonAnimator buttonAnimator2 = _smallFooterExtraMultiButtons[m];
						DynamicButton button2 = _smallFooterExtraMultiButtons[m].Button;
						TMP_Text tMP_Text2 = _smallFooterExtraMultiButtonTexts[m];
						button2.enabled = _data.IsSmallFooterExtraButtonEnabled(m);
						bool flag5 = _data.IsSmallFooterExtraButtonEnabled(m);
						if (flag5)
						{
							buttonAnimator2.CurrentState = ButtonAnimator.State.Selectable;
							button2.image.overrideSprite = _data.GetSmallFooterExtraImage(m);
						}
						else
						{
							buttonAnimator2.CurrentState = ButtonAnimator.State.Unselectable;
						}
						tMP_Text2.text = _data.GetSmallFooterExtraText(m);
						tMP_Text2.alpha = (flag5 ? 1f : 0.5f);
					}
					for (int n = smallFooterExtraButtonCount; n < _smallFooterExtraMultiButtons.Length; n++)
					{
						GameObjectUtils.SetActive(_smallFooterExtraMultiButtons[n].gameObject, isActive: false);
					}
				}
			}
			else
			{
				for (int num = 0; num < footerButtonCount; num++)
				{
					ButtonAnimator buttonAnimator3 = _footerButtons[num];
					DynamicButton button3 = buttonAnimator3.Button;
					if (_data.IsFooterButtonVisible(num))
					{
						buttonAnimator3.CurrentState = ButtonAnimator.State.Selectable;
						button3.interactable = _data.IsFooterButtonEnabled(num);
						button3.image.overrideSprite = _data.GetFooterButtonImage(num);
					}
					else
					{
						buttonAnimator3.CurrentState = ButtonAnimator.State.Unselectable;
					}
				}
				for (int num2 = footerButtonCount; num2 < _footerButtons.Length; num2++)
				{
					_footerButtons[num2].CurrentState = ButtonAnimator.State.Unselectable;
				}
			}
			UpdatePaparazziDiscoveredPanel();
			UpdateAlienDiscoveredPanel();
		}

		public void UpdateAlienDiscoveredPanel()
		{
			if (_panelAlienDiscovered != null)
			{
				bool flag = false;
				AliensManager aliensManager = _level.CharacterManager.GetAliensManager();
				if (_currentMode == Mode.Patient && aliensManager != null && !aliensManager.AliensManagerConfig._replaceAliensWithPaparazzi && _dataPatient != null && AliensManager.IsDiscoveredAlienPatient(_dataPatient.GetSelectedPatient()))
				{
					flag = true;
				}
				if (_panelAlienDiscovered.activeSelf != flag)
				{
					_panelAlienDiscovered.SetActive(flag);
				}
			}
		}

		public void UpdatePaparazziDiscoveredPanel()
		{
			if (_panelPaparazziDiscovered != null)
			{
				bool flag = false;
				AliensManager aliensManager = _level.CharacterManager.GetAliensManager();
				if (_currentMode == Mode.Patient && aliensManager != null && aliensManager.AliensManagerConfig._replaceAliensWithPaparazzi && _dataPatient != null && AliensManager.IsDiscoveredAlienPatient(_dataPatient.GetSelectedPatient()))
				{
					flag = true;
				}
				if (_panelPaparazziDiscovered.activeSelf != flag)
				{
					_panelPaparazziDiscovered.SetActive(flag);
				}
			}
		}

		private void OnClosePressed()
		{
			CloseAndRestoreGeneralNotifications();
		}

		private void OnTabPressed(int tabIndex)
		{
			if (_data == null)
			{
				return;
			}
			if (!_data.IsTabEnabled(tabIndex))
			{
				tabIndex = _data.GetDefaultTabIndex();
			}
			if (_isClosingOrClosed)
			{
				return;
			}
			for (int i = 0; i < _headerTabs.Length; i++)
			{
				if (i == tabIndex)
				{
					_headerTabs[i].CurrentState = ButtonAnimator.State.Selected;
					_data.OnTabSelected(tabIndex);
					if (_subMenuItem != null)
					{
						GameObjectUtils.SetActive(_subMenuItem, isActive: false);
					}
					_subMenuItem = _data.GetBodyPrefab(tabIndex);
					if (_subMenuItem != null)
					{
						GameObjectUtils.SetActive(_subMenuItem, isActive: true);
					}
					_currentTabIndex = tabIndex;
					if (_subMenuItem != null)
					{
						_subMenuItem.transform.SetParent(_body.transform, worldPositionStays: false);
					}
				}
				else
				{
					_headerTabs[i].CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		private void OnHeaderCycleLeftPressed()
		{
			if (_data != null)
			{
				_data.OnCycleLeftPressed();
			}
		}

		private void OnHeaderCycleRightPressed()
		{
			if (_data != null)
			{
				_data.OnCycleRightPressed();
			}
		}

		private void OnHeaderGoToButtonPressed()
		{
			if (_data != null)
			{
				_data.OnGoToPressed();
			}
		}

		private void OnFooterButtonPressed(int buttonIndex)
		{
			if (_data != null && !_isClosingOrClosed)
			{
				_data.OnFooterButtonPressed(buttonIndex);
			}
		}

		private void InitialiseHeaderTitleEdit()
		{
			if (!(_headerTitleEditButton != null) || !(_headerTitleInputFieldPanel != null) || !(_headerTitleInputField != null) || !(_headerTitleInputAcceptButton != null))
			{
				return;
			}
			GameObjectUtils.SetActive(_headerTitleEditButton.gameObject, _bHeaderTitleEditModeEnabled);
			GameObjectUtils.SetActive(_headerTitle.gameObject, isActive: true);
			GameObjectUtils.SetActive(_headerTitleInputFieldPanel.gameObject, isActive: false);
			GameObjectUtils.SetActive(_headerTitleInputAcceptButton.gameObject, isActive: true);
			if (_headerTitleEditButtonText != null)
			{
				GameObjectUtils.SetActive(_headerTitleEditButton.gameObject, _bHeaderTitleEditModeEnabled);
				GameObjectUtils.SetActive(_headerTitleEditButtonText.gameObject, _bHeaderTitleEditModeEnabled);
				if (_bHeaderTitleEditModeEnabled)
				{
					_headerTitleEditButton.onPrimaryDown.AddListener(OnHeaderTitleEditButtonPressed);
					_headerTitleEditButtonText.onPrimaryDown.AddListener(OnHeaderTitleEditButtonPressed);
				}
				else
				{
					_headerTitleEditButton.onPrimaryDown.RemoveListener(OnHeaderTitleEditButtonPressed);
					_headerTitleEditButtonText.onPrimaryDown.RemoveListener(OnHeaderTitleEditButtonPressed);
				}
			}
			if (_headerTitleEditButtonTooltip != null)
			{
				_headerTitleEditButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ((_data != null) ? _data.GetUserSpecifiedNameEditButtonTooltip() : string.Empty);
				});
			}
			_headerTitleInputField.characterLimit = 32;
		}

		private void DeInitialiseHeaderTitleEdit()
		{
			if (_headerTitleEditButton != null && _headerTitleInputFieldPanel != null && _headerTitleInputField != null && _headerTitleInputAcceptButton != null)
			{
				HeaderTitleInputCancel();
				_headerTitleEditButton.onPrimaryDown.RemoveListener(OnHeaderTitleEditButtonPressed);
				if (_headerTitleEditButtonText != null)
				{
					_headerTitleEditButtonText.onPrimaryDown.RemoveListener(OnHeaderTitleEditButtonPressed);
				}
			}
		}

		private void OnHeaderTitleEditButtonPressed()
		{
			SetHeaderTitleInputMode(bSet: true);
		}

		private void SetHeaderTitleInputMode(bool bSet)
		{
			_headerTitleInputCancelPending = false;
			if (_headerTitleEditModeOn != bSet)
			{
				_headerTitleEditModeOn = bSet;
				GameObjectUtils.SetActive(_headerTitle.gameObject, !_headerTitleEditModeOn);
				GameObjectUtils.SetActive(_headerTitleInputFieldPanel.gameObject, _headerTitleEditModeOn);
				GameObjectUtils.SetActive(_headerCycleLeftButton.gameObject, !_headerTitleEditModeOn);
				GameObjectUtils.SetActive(_headerCycleRightButton.gameObject, !_headerTitleEditModeOn);
				GameObjectUtils.SetActive(_headerTitleEditButton.gameObject, !_headerTitleEditModeOn);
				if (_headerTitleEditButtonText != null)
				{
					GameObjectUtils.SetActive(_headerTitleEditButtonText.gameObject, !_headerTitleEditModeOn);
				}
				if (_headerTitleEditModeOn)
				{
					_headerTitleInputField.ActivateInputField();
					_headerTitleInputField.text = _data.GetUserSpecifiedName();
					_headerTitleInputAcceptButton.onPrimaryDown.AddListener(OnHeaderTitleInputAcceptButtonPressed);
					_headerTitleInputField.onValueChanged.AddListener(OnHeaderTitleInputChanged);
					_headerTitleInputField.onEndEdit.AddListener(OnHeaderTitleInputEndEdit);
				}
				else
				{
					_headerTitleInputAcceptButton.onPrimaryDown.RemoveListener(OnHeaderTitleInputAcceptButtonPressed);
					_headerTitleInputField.onValueChanged.RemoveListener(OnHeaderTitleInputChanged);
					_headerTitleInputField.onEndEdit.RemoveListener(OnHeaderTitleInputEndEdit);
					_headerTitleInputField.DeactivateInputField();
				}
			}
		}

		private void OnHeaderTitleInputAcceptButtonPressed()
		{
			HeaderTitleInputAccept();
		}

		private void OnHeaderTitleInputChanged(string str)
		{
		}

		private void OnHeaderTitleInputEndEdit(string str)
		{
			_newUserSpecifiedHeaderTitle = _headerTitleInputField.text;
			_headerTitleInputField.text = _data.GetUserSpecifiedName();
			_headerTitleInputCancelPending = true;
		}

		private void HeaderTitleInputAccept()
		{
			UpdateUserSpecifiedName(_newUserSpecifiedHeaderTitle);
			SetHeaderTitleInputMode(bSet: false);
		}

		private void UpdateUserSpecifiedName(string userSpecifiedName)
		{
			_data.SetUserSpecifiedName(userSpecifiedName);
			_headerTitle.text = _data.GetHeaderTitle();
		}

		private void HeaderTitleInputCancel()
		{
			SetHeaderTitleInputMode(bSet: false);
		}

		private void ProcessHeaderTitleInput()
		{
			if (_headerTitleEditModeOn)
			{
				bool flag = false;
				if (Input.GetKeyDown(KeyCode.Return))
				{
					UpdateUserSpecifiedName(_newUserSpecifiedHeaderTitle);
					flag = true;
				}
				else if (Input.GetKeyDown(KeyCode.Escape))
				{
					flag = true;
				}
				if (_headerTitleInputCancelPending)
				{
					flag = true;
				}
				if (flag)
				{
					SetHeaderTitleInputMode(bSet: false);
				}
			}
		}

		public static bool ShouldShowInspector(Room room)
		{
			if (room == null)
			{
				return false;
			}
			if (room.Definition.IsHospitalUnbuilt || room.Definition.IsHospitalOrBay || room.Definition._type == RoomDefinition.Type.Invalid)
			{
				return false;
			}
			return true;
		}

		public static bool ShouldShowInspector(Character character, CharacterManager characterManager)
		{
			if (character == null)
			{
				return false;
			}
			if (character.Definition._selectMenuPrefab == null)
			{
				return false;
			}
			if (character is Patient item)
			{
				if (characterManager != null && characterManager.Patients.Contains(item))
				{
					return true;
				}
				return false;
			}
			return character is Staff;
		}
	}
}
