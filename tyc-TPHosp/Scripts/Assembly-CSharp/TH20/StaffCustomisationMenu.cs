using System;
using System.Collections.Generic;
using TH20.EventAwardSilver;
using TH20.UI;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[DontSave]
	public class StaffCustomisationMenu : AnimatedMenuBase, Interface, IGameEventCallback
	{
		private Level _level;

		private Table _table;

		private Staff _inspectedStaff;

		private CustomisationOption _currentCustomisationOption;

		private bool _showingViewFinder;

		private bool _hasShownViewFinderOnce;

		private List<StaffCustomisationRow> _rows = new List<StaffCustomisationRow>(32);

		[SerializeField]
		private StaffCustomisationMenuData _data;

		public Staff InspectedStaff
		{
			get
			{
				return _inspectedStaff;
			}
			set
			{
				if (_inspectedStaff == value)
				{
					return;
				}
				_inspectedStaff = value;
				if (_inspectedStaff != null)
				{
					_data.StaffNameText.text = _inspectedStaff.NameWithTitle;
					if (GetComponent<Animator>().IsInState("Idle"))
					{
						ShowViewFinder(enabled: true);
					}
					foreach (Transform row4 in _table.Rows)
					{
						UnityEngine.Object.Destroy(row4.gameObject);
					}
					_rows.Clear();
					GameObject gameObject = _table.InstantiateAsRow(_data.RowPrefab);
					StaffCustomisationRow row = gameObject.GetComponent<StaffCustomisationRow>();
					Sprite icon = null;
					switch (_inspectedStaff.Definition._type)
					{
					case StaffDefinition.Type.Doctor:
						icon = _data.DefaultDoctorIcon;
						break;
					case StaffDefinition.Type.Nurse:
						icon = _data.DefaultNurseIcon;
						break;
					case StaffDefinition.Type.Assistant:
						icon = _data.DefaultAssistantIcon;
						break;
					case StaffDefinition.Type.Janitor:
						icon = _data.DefaultJanitorIcon;
						break;
					}
					row.SetupDefault(_data.DefaultRowName, icon);
					row.Button.onPrimaryDown.AddListener(delegate
					{
						SelectRow(row);
					});
					_rows.Add(row);
					CustomisationOption[] options = _data.StaffCustomisationOptions.GetOptions(_inspectedStaff.Definition._type);
					if (options != null)
					{
						CustomisationOption[] array = options;
						foreach (CustomisationOption customisationOption in array)
						{
							bool flag = !customisationOption.DlcPackRequired.IsNull() && DLCUtils.IsDLCOwned(customisationOption.DlcPackRequired.Instance);
							bool num2 = customisationOption.PrimeEntitlementRequired > 0 && _level.App.UserProfile.PrimeEntitlementClaimed(customisationOption.PrimeEntitlementRequired.ToString());
							bool flag2 = customisationOption.DlcPackRequired.IsNull() && customisationOption.PrimeEntitlementRequired == 0;
							bool flag3 = num2 || flag || flag2;
							if (_level.Metagame.HasUnlocked(customisationOption) && flag3 && (!(customisationOption.Mask != null) || !_inspectedStaff.Definition.DisallowModularMasks))
							{
								GameObject gameObject2 = _table.InstantiateAsRow(_data.RowPrefab);
								StaffCustomisationRow row2 = gameObject2.GetComponent<StaffCustomisationRow>();
								row2.SetupOption(customisationOption);
								_rows.Add(row2);
								row2.Button.onPrimaryDown.AddListener(delegate
								{
									SelectRow(row2);
								});
							}
						}
						array = options;
						foreach (CustomisationOption customisationOption2 in array)
						{
							bool flag4 = !customisationOption2.DlcPackRequired.IsNull() && DLCUtils.IsDLCOwned(customisationOption2.DlcPackRequired.Instance);
							bool num3 = customisationOption2.PrimeEntitlementRequired > 0 && _level.App.UserProfile.PrimeEntitlementClaimed(customisationOption2.PrimeEntitlementRequired.ToString());
							bool flag5 = customisationOption2.DlcPackRequired.IsNull() && customisationOption2.PrimeEntitlementRequired == 0;
							bool flag6 = num3 || flag4 || flag5;
							if (!_level.Metagame.HasUnlocked(customisationOption2) && flag6 && (!(customisationOption2.Mask != null) || !_inspectedStaff.Definition.DisallowModularMasks))
							{
								GameObject gameObject3 = _table.InstantiateAsRow(_data.RowPrefab);
								StaffCustomisationRow row3 = gameObject3.GetComponent<StaffCustomisationRow>();
								row3.SetupOption(customisationOption2);
								_rows.Add(row3);
								row3.Button.onPrimaryDown.AddListener(delegate
								{
									SelectRow(row3);
								});
							}
						}
					}
					RefreshRows();
				}
				else
				{
					_data.StaffNameText.text = null;
					StopViewFinderTracking();
					_rows.Clear();
					_currentCustomisationOption = null;
					foreach (Transform row5 in _table.Rows)
					{
						UnityEngine.Object.Destroy(row5.gameObject);
					}
				}
				RefreshApplyAllButton();
				RefreshStaffTabs();
			}
		}

		public void Initialise(Level level)
		{
			_level = level;
			_level.InputManager.AddGraphicRayCaster(_data.GraphicRaycaster);
			_table = _data.Table;
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Combine(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (System.Action)Delegate.Combine(hUDEvents2.OnInspectorClose, new System.Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterRenamed = (Action<Character>)Delegate.Combine(characterEvents.OnCharacterRenamed, new Action<Character>(OnCharacterRenamed));
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents2.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffResigned = (Action<Staff>)Delegate.Combine(characterEvents3.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffDestroyed = (Action<Staff>)Delegate.Combine(characterEvents4.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
			if (_data.CloseButton != null)
			{
				_data.CloseButton.onPrimaryDown.AddListener(CloseMenu);
			}
			if (_data.ApplyToAllButton != null)
			{
				_data.ApplyToAllButton.onPrimaryDown.AddListener(ApplyToAllStaffType);
			}
			_data.DoctorsButton.onPrimaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Doctor, 1);
			});
			_data.NursesButton.onPrimaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Nurse, 1);
			});
			_data.AssistantsButton.onPrimaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Assistant, 1);
			});
			_data.JanitorsButton.onPrimaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Janitor, 1);
			});
			_data.DoctorsButton.onSecondaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Doctor, -1);
			});
			_data.NursesButton.onSecondaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Nurse, -1);
			});
			_data.AssistantsButton.onSecondaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Assistant, -1);
			});
			_data.JanitorsButton.onSecondaryDown.AddListener(delegate
			{
				SelectNextStaffOfType(StaffDefinition.Type.Janitor, -1);
			});
			_data.LeftCycleButton.onClick.AddListener(delegate
			{
				SelectNextStaff(-1);
			});
			_data.RightCycleButton.onClick.AddListener(delegate
			{
				SelectNextStaff(1);
			});
		}

		public void Setup()
		{
			_hasShownViewFinderOnce = false;
			_level.Metagame.OnSilverAwarded.Add(this);
		}

		private void RefreshStaffTabs()
		{
			_data.DoctorsButtonAnimator.CurrentState = GetStaffTabState(StaffDefinition.Type.Doctor);
			_data.NursesButtonAnimator.CurrentState = GetStaffTabState(StaffDefinition.Type.Nurse);
			_data.AssistantsButtonAnimator.CurrentState = GetStaffTabState(StaffDefinition.Type.Assistant);
			_data.JanitorsButtonAnimator.CurrentState = GetStaffTabState(StaffDefinition.Type.Janitor);
		}

		private void SelectNextStaff(int direction)
		{
			if (_inspectedStaff != null)
			{
				SelectNextStaffOfType(_inspectedStaff.Definition._type, direction);
			}
		}

		private void SelectNextStaffOfType(StaffDefinition.Type staffType, int direction)
		{
			List<Staff> list = new List<Staff>();
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == staffType && !staffMember.HasBeenFired() && !staffMember.HasResigned() && staffMember.GetComponent<StaffPickedUpState>() == null)
				{
					list.Add(staffMember);
				}
			}
			if (list.Count != 0)
			{
				int num;
				if (_inspectedStaff != null && _inspectedStaff.Definition._type == staffType)
				{
					num = list.IndexOf(_inspectedStaff);
					num = (num + direction) % list.Count;
					num = (list.Count + num) % list.Count;
				}
				else
				{
					num = 0;
				}
				_level.BuildEvents.OnCursorSelectObject.InvokeSafe(list[num]);
			}
		}

		private ButtonAnimator.State GetStaffTabState(StaffDefinition.Type staffType)
		{
			if (_level.CharacterManager.GetStaffOfTypeCount(staffType) == 0)
			{
				return ButtonAnimator.State.Unselectable;
			}
			if (_inspectedStaff == null)
			{
				return ButtonAnimator.State.Selectable;
			}
			if (_inspectedStaff.Definition._type != staffType)
			{
				return ButtonAnimator.State.Selectable;
			}
			return ButtonAnimator.State.Selected;
		}

		private void SelectRow(StaffCustomisationRow row)
		{
			if (_inspectedStaff == null)
			{
				RefreshRows();
			}
			else if (row.CustomisationOption == null)
			{
				_inspectedStaff.Visual.SetCustomisationOption(null, _inspectedStaff);
				RefreshRows();
				RefreshApplyAllButton();
			}
			else if (!_level.Metagame.HasUnlocked(row.CustomisationOption))
			{
				if (_level.Metagame.CanAffordSilver(row.CustomisationOption))
				{
					ShowUnlockItemMessage(row);
				}
			}
			else
			{
				_inspectedStaff.Visual.SetCustomisationOption(row.CustomisationOption, _inspectedStaff);
				RefreshRows();
				RefreshApplyAllButton();
			}
		}

		private void ShowUnlockItemMessage(StaffCustomisationRow row)
		{
			CustomisationOption customisationOption = row.CustomisationOption;
			NotificationDynamicMessage unlockMessage = new NotificationDynamicMessage(_level.Notifications.MessageDefinitions.UnlockStaffCustomisationSilverMessage.Instance, delegate(int response)
			{
				if (response == 0)
				{
					_level.Metagame.UnlockItem(customisationOption, spendSilver: true, showMessage: false);
					SelectRow(row);
					RefreshRows();
				}
			}, _level);
			NotificationDynamicMessage notificationDynamicMessage = unlockMessage;
			notificationDynamicMessage.FuncGetMessage = (Func<string>)Delegate.Combine(notificationDynamicMessage.FuncGetMessage, (Func<string>)(() => LocalisedString.Replace(unlockMessage.Definition.LocalisedText.Translation, new SubPair[3]
			{
				new SubPair("{[ITEM]}", customisationOption.Name.Translation),
				new SubPair("{[SILVER]}", StringUtils.FormatSilverCurrency(customisationOption.SilverCost())),
				new SubPair("{[BALANCE]}", StringUtils.FormatSilverCurrency(_level.Metagame.TotalSilver()))
			})));
			_level.Notifications.Send(unlockMessage);
		}

		private void RefreshApplyAllButton()
		{
			if (_inspectedStaff == null)
			{
				_data.ApplyToAllButton.gameObject.SetActive(value: false);
				return;
			}
			_data.ApplyToAllButton.gameObject.SetActive(value: true);
			switch (_inspectedStaff.Definition._type)
			{
			case StaffDefinition.Type.Doctor:
				_data.ApplyToAllLocalize.Term = _data.ApplyToAllDoctorsString.Term;
				break;
			case StaffDefinition.Type.Nurse:
				_data.ApplyToAllLocalize.Term = _data.ApplyToAllNursesString.Term;
				break;
			case StaffDefinition.Type.Assistant:
				_data.ApplyToAllLocalize.Term = _data.ApplyToAllAssistantsString.Term;
				break;
			case StaffDefinition.Type.Janitor:
				_data.ApplyToAllLocalize.Term = _data.ApplyToAllJanitorsString.Term;
				break;
			}
			bool flag = true;
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == _inspectedStaff.Definition._type && _inspectedStaff.Visual.CustomisationOption != staffMember.Visual.CustomisationOption)
				{
					flag = false;
					break;
				}
			}
			if (_level.CharacterManager.GetDefaultSaffCustomisationOption(_inspectedStaff.Definition._type) != _inspectedStaff.Visual.CustomisationOption)
			{
				flag = false;
			}
			_data.ApplyToAllButtonAnimator.CurrentState = (flag ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
		}

		private void RefreshRows()
		{
			foreach (StaffCustomisationRow row in _rows)
			{
				if (_inspectedStaff != null && _inspectedStaff.Visual.CustomisationOption == row.CustomisationOption)
				{
					row.CurrentMode = StaffCustomisationRow.Mode.Selected;
					_currentCustomisationOption = row.CustomisationOption;
				}
				else if (row.CustomisationOption != null && !_level.Metagame.HasUnlocked(row.CustomisationOption))
				{
					if (_level.Metagame.CanAffordSilver(row.CustomisationOption))
					{
						row.CurrentMode = StaffCustomisationRow.Mode.LockedAffordable;
					}
					else
					{
						row.CurrentMode = StaffCustomisationRow.Mode.LockedUnaffordable;
					}
				}
				else
				{
					row.CurrentMode = StaffCustomisationRow.Mode.Available;
				}
			}
		}

		private void OnCameraPan(float distance)
		{
			StopViewFinderTracking();
		}

		private void OnInspectorOpen(InspectorMenu menuRef, Character character)
		{
			if (character is Staff && !IsClosed() && !IsClosing())
			{
				InspectedStaff = (Staff)character;
				ShowViewFinder(enabled: true);
			}
		}

		public bool IsShowingViewFinder()
		{
			return _showingViewFinder;
		}

		private void OnInspectorClose()
		{
			StopViewFinderTracking();
		}

		public void ShowViewFinder(bool enabled)
		{
			_showingViewFinder = false;
			if (enabled)
			{
				_hasShownViewFinderOnce = true;
				_showingViewFinder = true;
				Vector2 sizeDelta = _data.PanelRectTransform.sizeDelta;
				float y = sizeDelta.y;
				float x = _data.ViewFinderRectTransform.anchoredPosition.x - _data.PanelRectTransform.anchoredPosition.x - sizeDelta.x - _data.ViewFinderBorder;
				_data.ViewFinderRectTransform.sizeDelta = new Vector2(x, y);
				_level.CameraLogic.TrackObject(_inspectedStaff.Transform);
				_level.CameraLogic.SetTrackedObjectFrame(_data.ViewFinderRectTransform.GetScreenSpaceRect());
			}
			else
			{
				_level.CameraLogic.SetTrackedObjectFrame(null);
			}
			_data.ViewFinderRectTransform.gameObject.SetActive(enabled);
		}

		private void StopViewFinderTracking()
		{
			if (_showingViewFinder && !IsClosed() && !IsClosing())
			{
				ShowViewFinder(enabled: false);
			}
		}

		private void ApplyToAllStaffType()
		{
			if (InspectedStaff == null)
			{
				return;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				if (staffMember.Definition._type == InspectedStaff.Definition._type)
				{
					staffMember.Visual.SetCustomisationOption(_currentCustomisationOption, staffMember);
				}
			}
			switch (InspectedStaff.Definition._type)
			{
			case StaffDefinition.Type.Doctor:
				_level.CharacterManager.DefaultDoctorCustomisationOption = _currentCustomisationOption;
				break;
			case StaffDefinition.Type.Nurse:
				_level.CharacterManager.DefaultNurseCustomisationOption = _currentCustomisationOption;
				break;
			case StaffDefinition.Type.Assistant:
				_level.CharacterManager.DefaultAssistantCustomisationOption = _currentCustomisationOption;
				break;
			case StaffDefinition.Type.Janitor:
				_level.CharacterManager.DefaultJanitorCustomisationOption = _currentCustomisationOption;
				break;
			}
			RefreshApplyAllButton();
		}

		public override void Destroy()
		{
			_level.InputManager.RemoveGraphicRayCaster(_data.GraphicRaycaster);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Remove(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (System.Action)Delegate.Remove(hUDEvents2.OnInspectorClose, new System.Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Remove(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnCharacterRenamed = (Action<Character>)Delegate.Remove(characterEvents.OnCharacterRenamed, new Action<Character>(OnCharacterRenamed));
			_level.Metagame.OnSilverAwarded.Remove(this);
			CharacterEvents characterEvents2 = _level.CharacterEvents;
			characterEvents2.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents2.OnStaffFired, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents3 = _level.CharacterEvents;
			characterEvents3.OnStaffResigned = (Action<Staff>)Delegate.Remove(characterEvents3.OnStaffResigned, new Action<Staff>(OnStaffDestroyed));
			CharacterEvents characterEvents4 = _level.CharacterEvents;
			characterEvents4.OnStaffDestroyed = (Action<Staff>)Delegate.Remove(characterEvents4.OnStaffDestroyed, new Action<Staff>(OnStaffDestroyed));
		}

		private void OnStaffDestroyed(Staff staff)
		{
			if (staff == _inspectedStaff)
			{
				InspectedStaff = null;
				CloseMenu();
			}
		}

		private void OnCharacterRenamed(Character character)
		{
			if (character == _inspectedStaff)
			{
				_data.StaffNameText.text = _inspectedStaff.NameWithTitle;
			}
		}

		void Interface.OnSilverAwardedEvent(int amount)
		{
			if (!IsClosed())
			{
				RefreshRows();
			}
		}

		public override void CloseMenu()
		{
			StopViewFinderTracking();
			base.CloseMenu();
		}

		protected override void Update()
		{
			if (_inspectedStaff != null && !_showingViewFinder && !_hasShownViewFinderOnce && GetComponent<Animator>().IsInState("Idle"))
			{
				ShowViewFinder(enabled: true);
			}
			base.Update();
		}
	}
}
