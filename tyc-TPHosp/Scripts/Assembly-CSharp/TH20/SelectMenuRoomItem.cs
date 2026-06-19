using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SelectMenuRoomItem : SelectMenuRoomItemBase
	{
		private AttributeFloat _maintenanceLevel;

		[SerializeField]
		private DynamicButton _pickupButton;

		[SerializeField]
		private TooltipSpawner _pickupButtonTooltip;

		[SerializeField]
		private DynamicButton _sellButton;

		[SerializeField]
		private TooltipSpawner _sellButtonTooltip;

		[SerializeField]
		private DynamicButton _repairButton;

		[SerializeField]
		private TooltipSpawner _repairButtonTooltip;

		[SerializeField]
		private DynamicButton _upgradeButton;

		[SerializeField]
		private TooltipSpawner _upgradeButtonTooltip;

		[SerializeField]
		private DynamicButton _localUGCButton;

		[SerializeField]
		private TooltipSpawner _localUGCButtonTooltip;

		[SerializeField]
		private DynamicButton _workshopUGCButton;

		[SerializeField]
		private TooltipSpawner _workshopUGCButtonTooltip;

		[SerializeField]
		private GameObject _callRepairButtonImage;

		[SerializeField]
		private GameObject _cancelRepairButtonImage;

		[SerializeField]
		private TMP_Text _itemName;

		[SerializeField]
		private ProgressBarMaskable _maintenanceBar;

		[SerializeField]
		private Image _maintenanceIcon;

		[SerializeField]
		private TooltipSpawner _maintenanceBarTooltip;

		[SerializeField]
		private TMP_Text _janitorText;

		[SerializeField]
		private Button _janitorButton;

		[SerializeField]
		private GameObject _maintenanceSection;

		[SerializeField]
		private GameObject _maintenanceRegenAnim;

		[SerializeField]
		private ProgressBarMaskable _upgradeBar;

		[SerializeField]
		private TooltipSpawner _upgradeBarTooltip;

		[SerializeField]
		private GameObject _upgradeSection;

		[SerializeField]
		private GameObject _callUpgradeButtonImage;

		[SerializeField]
		private GameObject _cancelUpgradeButtonImage;

		[SerializeField]
		private TMP_Text _staffText;

		[SerializeField]
		private TMP_Text _queueText;

		[SerializeField]
		private LocalisedString _ugcEditTooltipString;

		[SerializeField]
		private LocalisedString _ugcWorkshopTooltipString;

		[SerializeField]
		private string _audioEventUpgradeStart;

		[SerializeField]
		private string _audioEventUpgradeCancel;

		[SerializeField]
		private string _audioEventRepairStart;

		[SerializeField]
		private string _audioEventRepairCancel;

		private Staff _janitorAssigned;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			if (_maintenanceRegenAnim != null && roomItem != null && roomItem.Definition.IgnoredByJanitors && (bool)roomItem.Definition.MaintenanceIconOverride)
			{
				GameObjectUtils.SetActive(_maintenanceRegenAnim, isActive: true);
			}
			if (_pickupButton != null)
			{
				_pickupButton.onPrimaryDown.AddListener(PickupButton);
				_pickupButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Pickup_CS;
				});
			}
			if (_sellButton != null)
			{
				_sellButton.onPrimaryDown.AddListener(SellButton);
				_sellButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					string newValue = StringUtils.FormatCurrency(_roomItem.SellValue());
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Sell_CS.Replace("{[COST]}", newValue);
				});
			}
			if (_repairButton != null)
			{
				_repairButton.onPrimaryDown.AddListener(RepairButton);
			}
			if (_upgradeButton != null)
			{
				_upgradeButton.onPrimaryDown.AddListener(UpgradeButton);
			}
			GameItemBase gameItemBase = (_roomItem.Definition as RoomItemDefinitionUGC)?.ExtContentGameItem;
			bool flag = gameItemBase != null && gameItemBase.ContentSource == EContentSourceType.LocalMods;
			bool flag2 = gameItemBase != null && gameItemBase.ContentSource == EContentSourceType.Workshop;
			if (flag && _localUGCButtonTooltip != null)
			{
				_localUGCButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _ugcEditTooltipString.Translation;
				});
			}
			if (flag2 && _workshopUGCButtonTooltip != null)
			{
				_workshopUGCButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _ugcWorkshopTooltipString.Translation;
				});
			}
			if (_localUGCButton != null)
			{
				if (flag)
				{
					_localUGCButton.gameObject.SetActive(value: true);
					_localUGCButton.onPrimaryDown.AddListener(UGCButton);
				}
				else
				{
					_localUGCButton.gameObject.SetActive(value: false);
				}
			}
			if (_workshopUGCButton != null)
			{
				if (flag2)
				{
					_workshopUGCButton.gameObject.SetActive(value: true);
					_workshopUGCButton.onPrimaryDown.AddListener(UGCButton);
				}
				else
				{
					_workshopUGCButton.gameObject.SetActive(value: false);
				}
			}
			IRoomItemDefinition definition = _roomItem.Definition;
			if ((!_roomItem.CanBeSold() || (roomItem.FloorPlan.Definition.IsRequiredItem(definition) && RoomItemAlgorithms.RequiredItemCount(roomItem.FloorPlan, definition) <= 1 && !_roomItem.IsCanBeSoldOverridden())) && _sellButton != null)
			{
				GameObjectUtils.SetActive(_sellButton.gameObject, isActive: false);
			}
			if (!definition.CanBePickedUp && _pickupButton != null)
			{
				GameObjectUtils.SetActive(_pickupButton.gameObject, isActive: false);
			}
			_maintenanceLevel = _roomItem.MaintenanceLevel;
			if (_maintenanceSection != null)
			{
				if (_maintenanceLevel == null || _roomItem.IgnoredByJanitors())
				{
					GameObjectUtils.SetActive(_maintenanceSection, isActive: false);
					HideRepairButton();
				}
				else
				{
					_maintenanceLevel.LessThan(GameAlgorithms.Config.ItemFullyRepairedThreshold, HideRepairButton, checkCallback: true);
					_maintenanceLevel.GreaterThan(GameAlgorithms.Config.ItemFullyRepairedThreshold, ShowRepairButton, checkCallback: true);
					_maintenanceBarTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						string newValue = StringUtils.FormatPercentageValue((100f - _roomItem.MaintenanceLevel.Value()) / 100f);
						tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_Maintenance_CS.Replace("{[LEVEL]}", newValue);
					});
				}
				_maintenanceIcon.overrideSprite = null;
				if (_maintenanceIcon != null && definition.MaintenanceIconOverride != null)
				{
					_maintenanceIcon.overrideSprite = definition.MaintenanceIconOverride;
				}
			}
			if (_itemName != null)
			{
				_itemName.text = roomItem.LocalisedName;
			}
			if (_janitorButton != null)
			{
				_janitorButton.onClick.RemoveAllListeners();
				_janitorButton.onClick.AddListener(delegate
				{
					if (_janitorAssigned != null)
					{
						base.Level.CameraLogic.TrackObject(_janitorAssigned.GetCameraTrackObject().transform);
					}
				});
			}
			Update();
		}

		private void ShowRepairButton()
		{
			if (!(_repairButton != null))
			{
				return;
			}
			GameObjectUtils.SetActive(_repairButton.gameObject, isActive: true);
			JobMaintenance jobMaintenance = _roomItem.GetComponent<RoomItemMaintenanceComponent>()?.Job;
			string actionString = GameStringUtils.GetJobActionString(_roomItem.Definition.MaintenanceDescription).Replace("{[ITEM]}", _roomItem.LocalisedName);
			if (jobMaintenance != null && jobMaintenance.HighPriority)
			{
				GameObjectUtils.SetActive(_callRepairButtonImage, isActive: false);
				GameObjectUtils.SetActive(_cancelRepairButtonImage, isActive: true);
				SetButtonSFXCustomAudioEvent(_repairButton, _audioEventRepairCancel);
				_repairButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_CancelJanitor_CS.Replace("{[ACTION]}", actionString);
				});
			}
			else
			{
				GameObjectUtils.SetActive(_callRepairButtonImage, isActive: true);
				GameObjectUtils.SetActive(_cancelRepairButtonImage, isActive: false);
				SetButtonSFXCustomAudioEvent(_repairButton, _audioEventRepairStart);
				_repairButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_CallJanitor_CS.Replace("{[ACTION]}", actionString);
				});
			}
		}

		private void HideRepairButton()
		{
			if (_repairButton != null)
			{
				GameObjectUtils.SetActive(_repairButton.gameObject, isActive: false);
			}
		}

		public override void CloseMenu()
		{
			if (_pickupButton != null)
			{
				_pickupButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_sellButton != null)
			{
				_sellButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_repairButton != null)
			{
				_repairButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_upgradeButton != null)
			{
				_upgradeButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_localUGCButton != null)
			{
				_localUGCButton.onPrimaryDown.RemoveAllListeners();
			}
			if (_workshopUGCButton != null)
			{
				_workshopUGCButton.onPrimaryDown.RemoveAllListeners();
			}
			base.CloseMenu();
		}

		protected override void Update()
		{
			base.Update();
			if (IsClosing())
			{
				return;
			}
			if (_roomItem.HasBeenDestroyed() || _roomItem.Visual == null || _roomItem.Visual.GameObject == null || !_roomItem.IsSelectable())
			{
				CloseMenu();
				return;
			}
			RoomItemUpgradeComponent upgradeComponent = _roomItem.GetComponent<RoomItemUpgradeComponent>();
			RoomItemUpgradeDefinition upgradeDefinition = _roomItem.Definition.GetNextUpgrade(_roomItem.UpgradeLevel);
			QualificationDefinition upgradeQualification = _roomItem.UpgradeQualification;
			bool flag = upgradeDefinition != null && base.Level.Metagame.HasUnlocked(upgradeDefinition);
			bool flag2 = _roomItem.GetComponent<RoomItemFlammableComponent>()?.IsOnFire ?? false;
			bool flag3 = _roomItem.GetComponent<RoomItemAmbulanceComponent>()?.IsOutOfParkingSpace ?? false;
			if (_maintenanceLevel != null)
			{
				GameObjectUtils.SetActive(_maintenanceSection, isActive: true);
				_maintenanceBar.Progress = 1f - _maintenanceLevel.Value() / 100f;
			}
			if (_janitorText != null)
			{
				if (upgradeComponent != null || _repairButton.gameObject.activeSelf)
				{
					_janitorText.text = GameStringUtils.GetRoomItemJanitorText(_roomItem, (upgradeComponent != null) ? upgradeQualification : null, out _janitorAssigned);
					GameObjectUtils.SetActive(_janitorText.gameObject, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_janitorText.gameObject, isActive: false);
				}
			}
			if (_upgradeSection != null && _upgradeButton != null && _upgradeBar != null)
			{
				bool canAffordUpgrade = upgradeDefinition != null && base.Level.FinanceManager.CanAfford(upgradeDefinition.Cost);
				bool staffQualified = upgradeQualification == null || GameAlgorithms.AnyStaffCompletedQualification(base.Level, upgradeQualification);
				if (upgradeComponent != null)
				{
					_upgradeBar.Progress = upgradeComponent.Progress;
					GameObjectUtils.SetActive(_upgradeSection, isActive: true);
					GameObjectUtils.SetActive(_upgradeButton.gameObject, isActive: true);
					GameObjectUtils.SetActive(_callUpgradeButtonImage, isActive: false);
					GameObjectUtils.SetActive(_cancelUpgradeButtonImage, isActive: true);
					SetButtonSFXCustomAudioEvent(_upgradeButton, _audioEventUpgradeCancel);
					_upgradeBarTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						string newValue = StringUtils.FormatPercentageValue(upgradeComponent.Progress);
						tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_UpgradeProgress_CS.Replace("{[PERCENT]}", newValue);
					});
				}
				else
				{
					GameObjectUtils.SetActive(_upgradeSection, isActive: false);
					GameObjectUtils.SetActive(_upgradeButton.gameObject, flag);
					GameObjectUtils.SetActive(_callUpgradeButtonImage, isActive: true);
					GameObjectUtils.SetActive(_cancelUpgradeButtonImage, isActive: false);
					SetButtonSFXCustomAudioEvent(_upgradeButton, _audioEventUpgradeStart);
					Image component = _callUpgradeButtonImage.GetComponent<Image>();
					ButtonAnimator component2 = _upgradeButton.GetComponent<ButtonAnimator>();
					bool flag4 = canAffordUpgrade && staffQualified && !flag2 && !flag3;
					GameObjectUtils.SetInteractable(_upgradeButton, flag4);
					if (component != null)
					{
						component.color = (flag4 ? Color.white : Color.gray);
					}
					if (component2 != null)
					{
						component2.CurrentState = ((!flag4) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
					}
				}
				if (_upgradeButtonTooltip != null && flag)
				{
					_upgradeButtonTooltip.SetDataProvider(delegate(Tooltip tooltip)
					{
						if (upgradeComponent != null)
						{
							tooltip.Text = ScriptLocalization.Tooltip.SelectMenuRoomItem_UpgradeCancel_CS;
						}
						else
						{
							string translation = upgradeDefinition.LocalisedName.Translation;
							string translation2 = upgradeDefinition.LocalisedDescription.Translation;
							string text = StringUtils.FormatCurrency(upgradeDefinition.Cost);
							string text2 = ((upgradeQualification != null) ? upgradeQualification.NameLocalised.Translation : "");
							string roomModifiersTooltipText = GameStringUtils.GetRoomModifiersTooltipText(upgradeDefinition.RoomModifiers);
							int num = (int)((float)(int)upgradeDefinition.Points / GameAlgorithms.Config.SecondsPerDay);
							if (!staffQualified)
							{
								text2 = StringUtils.AddColorTag(text2, Color.red);
							}
							if (!canAffordUpgrade)
							{
								text = StringUtils.AddColorTag(text, Color.red);
							}
							string selectMenuRoomItem_UpgradeDetails_CS = ScriptLocalization.Tooltip.SelectMenuRoomItem_UpgradeDetails_CS;
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[NAME]}", translation);
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[DESC]}", translation2);
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[MODIFIERS]}", roomModifiersTooltipText);
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[COST]}", text);
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[DAYS]}", num.ToString());
							selectMenuRoomItem_UpgradeDetails_CS = selectMenuRoomItem_UpgradeDetails_CS.Replace("{[QUALIFICATION]}", text2);
							tooltip.Text = selectMenuRoomItem_UpgradeDetails_CS;
						}
					});
				}
			}
			if (_roomItem.Definition.ShowQueuePositions)
			{
				RoomItemJobComponent component3 = _roomItem.GetComponent<RoomItemJobComponent>();
				if (component3 != null && component3.Job != null)
				{
					Staff staff = component3.Job.GetStaff();
					if (staff != null)
					{
						_staffText.text = ScriptLocalization.Menu.Hover_Room_StaffList_CS;
						TMP_Text staffText = _staffText;
						staffText.text = staffText.text + "\n" + staff.NameWithTitle;
					}
					else
					{
						_staffText.text = ScriptLocalization.Menu.Hover_Room_StaffRequired_CS;
						TMP_Text staffText2 = _staffText;
						staffText2.text = staffText2.text + "\n" + component3.StaffRequired;
					}
					GameObjectUtils.SetActive(_staffText.gameObject, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(_staffText.gameObject, isActive: false);
				}
				_queueText.text = ScriptLocalization.Menu.Hover_Room_QueueLength_CS.Replace("{[LENGTH]}", _roomItem.QueueLength.ToString());
			}
			else
			{
				if (_queueText != null)
				{
					GameObjectUtils.SetActive(_queueText.gameObject, isActive: false);
				}
				if (_staffText != null)
				{
					GameObjectUtils.SetActive(_staffText.gameObject, isActive: false);
				}
			}
			ExtContentUtils.CheckShowGameItemDevInfoPanelInput((_roomItem.Definition as RoomItemDefinitionUGC)?.ExtContentGameItem);
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			if (_maintenanceLevel != null)
			{
				_maintenanceLevel.RemoveCallback(ShowRepairButton);
				_maintenanceLevel.RemoveCallback(HideRepairButton);
			}
			base.Destroy();
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem == _roomItem)
			{
				CloseMenu();
			}
		}

		private void PickupButton()
		{
			base.Level.BuildEvents.StartItemEdit(_roomItem, _roomItem.OwningRoom);
			CloseMenu();
		}

		private void SellButton()
		{
			base.Level.BuildEvents.OnCursorDeleteObject.InvokeSafe(_roomItem);
			CloseMenu();
		}

		private void RepairButton()
		{
			JobMaintenance jobMaintenance = _roomItem.GetComponent<RoomItemMaintenanceComponent>()?.Job;
			if (jobMaintenance == null || !jobMaintenance.HighPriority)
			{
				base.Level.BuildEvents.OnRoomItemRequestRepair.InvokeSafe(_roomItem);
			}
			else
			{
				base.Level.BuildEvents.OnRoomItemCancelRepair.InvokeSafe(_roomItem);
			}
			CloseMenu();
		}

		private void UpgradeButton()
		{
			if (_roomItem.GetComponent<RoomItemUpgradeComponent>() != null)
			{
				base.Level.BuildEvents.OnRoomItemCancelUpgrade.InvokeSafe(_roomItem);
			}
			else
			{
				base.Level.BuildEvents.OnRoomItemRequestUpgrade.InvokeSafe(_roomItem);
			}
			CloseMenu();
		}

		private void UGCButton()
		{
			GameItemBase gameItemBase = (_roomItem.Definition as RoomItemDefinitionUGC)?.ExtContentGameItem;
			if (gameItemBase != null)
			{
				ExtContentUIUtils.OpenGameItemUIOrWorkshopUIScreen(gameItemBase);
				CloseMenu();
			}
		}

		private void SetButtonSFXCustomAudioEvent(DynamicButton button, string audioEvent)
		{
			if (!audioEvent.IsNullOrEmpty())
			{
				ButtonSFX component = button.GetComponent<ButtonSFX>();
				if ((bool)component)
				{
					component.SetCustomAudioEvent(audioEvent);
				}
			}
		}
	}
}
