using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Character;
using Assets.Scripts.Character.Suit;
using Assets.Scripts.Flight;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI
{
	public class CustomizeCharacterScript : WidgetScript
	{
		private Widget _changeSpacer;

		private Widget _changeWidget;

		private SpinnerControl _danceSpinner;

		private List<Action> _itemVisibilityUpdaters = new List<Action>();

		private string _originalCharacterSelection;

		private string _originalConfigNameSelection;

		private CharacterSuitData _originalConfigSelectionCopy;

		private CharacterManager.CharacterDance _originalDanceSelection;

		private string _originalSuitSelection;

		private Widget _saveButton;

		private CharacterSuitScript _suit;

		private SpinnerControl _suitSpinner;

		private SpinnerControl _themeSpinner;

		private List<Widget> _widgets = new List<Widget>();

		public FlyoutScript Flyout => base.Widget.GetComponentInParent<FlyoutScript>(includeInactive: true);

		public string SelectedCharacter => CharacterManager.Instance.SelectedCharacter.Name;

		public string SelectedConfig => CharacterManager.Instance.SelectedConfigName;

		public CharacterManager.CharacterDance SelectedDance => CharacterManager.Instance.SelectedDance;

		public string SelectedSuit => CharacterManager.Instance.SelectedSuit.Name;

		public bool PendingChanges()
		{
			if (SelectedDance != _originalDanceSelection)
			{
				return true;
			}
			if (SelectedCharacter != _originalCharacterSelection)
			{
				return true;
			}
			if (SelectedSuit != _originalSuitSelection)
			{
				return true;
			}
			if (SelectedConfig != _originalConfigNameSelection)
			{
				return true;
			}
			CharacterSuitData selectedConfig = CharacterManager.Instance.SelectedConfig;
			if (selectedConfig.Items.Count != _originalConfigSelectionCopy.Items.Count)
			{
				return true;
			}
			for (int i = 0; i < _originalConfigSelectionCopy.Items.Count; i++)
			{
				if (_originalConfigSelectionCopy.Items[i].Enabled != selectedConfig.Items[i].Enabled || _originalConfigSelectionCopy.Items[i].Name != selectedConfig.Items[i].Name || _originalConfigSelectionCopy.Items[i].Colors.Count != selectedConfig.Items[i].Colors.Count)
				{
					return true;
				}
				for (int j = 0; j < _originalConfigSelectionCopy.Items[i].Colors.Count; j++)
				{
					if (_originalConfigSelectionCopy.Items[i].Colors[j] != selectedConfig.Items[i].Colors[j])
					{
						return true;
					}
				}
			}
			return false;
		}

		public void SetCharacterSuit(CharacterSuitScript suit)
		{
			_suit = suit;
			if (Game.Instance.SceneManager.InFlightScene)
			{
				FlightSceneScript.Instance.LocalPlayer.SetCharacterSuit(suit);
			}
			foreach (Widget widget3 in _widgets)
			{
				widget3.Visible = false;
				widget3.Destroy();
			}
			_widgets.Clear();
			_itemVisibilityUpdaters.Clear();
			Widget parent = base.Widget.FindWidget("items-parent");
			CharacterSuitData data = suit.GetData();
			foreach (CharacterSuitItem item in suit.SuitItems)
			{
				CharacterSuitData.CharacterSuitItemData itemData = data.Items.First((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.Name);
				CharacterSuitData.CharacterSuitItemData parentItem = ((item.ParentName != null) ? data.Items.FirstOrDefault((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.ParentName) : null);
				CharacterSuitData.CharacterSuitItemData antiDependentItem = ((item.AntiDependentName != null) ? data.Items.FirstOrDefault((CharacterSuitData.CharacterSuitItemData x) => x.Name == item.AntiDependentName) : null);
				if (item.Optional)
				{
					Widget widget = base.Widget.Context.CreateWidgetFromTemplate("control-toggle", parent);
					_widgets.Add(widget);
					ToggleControl toggleControl = new ToggleControl(widget);
					toggleControl.LabelText = item.Name;
					toggleControl.Toggle.IsOn = itemData.Enabled;
					toggleControl.Toggle.ValueChanged += delegate(bool x)
					{
						itemData.Enabled = x;
						OnSuitDataChanged(suit, data);
						UpdateItemVisibility();
					};
					if (parentItem != null)
					{
						_itemVisibilityUpdaters.Add(delegate
						{
							toggleControl.Visible = parentItem.Enabled;
						});
					}
				}
				for (int num = 0; num < item.Colors.Length; num++)
				{
					int colorIndex = num;
					CharacterSuitItem.SuitItemColor suitItemColor = item.Colors[colorIndex];
					Widget widget2 = base.Widget.Context.CreateWidgetFromTemplate("control-color-button", parent);
					_widgets.Add(widget2);
					ColorButtonControl buttonControl = new ColorButtonControl(widget2);
					buttonControl.LabelText = suitItemColor.Name;
					Color color = itemData.Colors[colorIndex].Color;
					color.a = 1f;
					buttonControl.Color = color;
					buttonControl.ColorChanged += delegate(object sender, ColorButtonControl.ColorChangedEventArgs e)
					{
						itemData.Colors[colorIndex].Color = e.Color;
						OnSuitDataChanged(suit, data);
					};
					_itemVisibilityUpdaters.Add(delegate
					{
						ColorButtonControl colorButtonControl = buttonControl;
						int visible;
						if (itemData.Enabled)
						{
							CharacterSuitData.CharacterSuitItemData characterSuitItemData = parentItem;
							if (characterSuitItemData == null || characterSuitItemData.Enabled)
							{
								CharacterSuitData.CharacterSuitItemData characterSuitItemData2 = antiDependentItem;
								visible = ((characterSuitItemData2 == null || !characterSuitItemData2.Enabled) ? 1 : 0);
								goto IL_004e;
							}
						}
						visible = 0;
						goto IL_004e;
						IL_004e:
						colorButtonControl.Visible = (byte)visible != 0;
					});
				}
			}
			_changeSpacer.SetIndex(_widgets.Last().Index + 1);
			_changeWidget.SetIndex(_changeSpacer.Index + 1);
			UpdateItemVisibility();
		}

		protected void Start()
		{
			_danceSpinner = new SpinnerControl(base.Widget.FindWidget("dance-spinner"));
			_suitSpinner = new SpinnerControl(base.Widget.FindWidget("suit-spinner"));
			_themeSpinner = new SpinnerControl(base.Widget.FindWidget("theme-spinner"));
			_changeSpacer = base.Widget.FindWidget("change-button-spacer");
			_changeWidget = base.Widget.FindWidget("change-button-row");
			CharacterManager.Instance.LoadCharacterData();
			SetUnchangedData();
			UpdateSpinnerValues();
			SpinnerControl danceSpinner = _danceSpinner;
			danceSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(danceSpinner.OnValueChanged, new OnValueChanged<string>(OnDanceSpinnerValueChanged));
			SpinnerControl suitSpinner = _suitSpinner;
			suitSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(suitSpinner.OnValueChanged, new OnValueChanged<string>(OnSuitSpinnerValueChanged));
			SpinnerControl themeSpinner = _themeSpinner;
			themeSpinner.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(themeSpinner.OnValueChanged, new OnValueChanged<string>(OnSuitConfigSpinnerValueChanged));
			if (Flyout != null)
			{
				Flyout.Closed += OnFlyoutClosed;
			}
			CharacterSuitScript characterSuitScript = null;
			if (Game.Instance.SceneManager.InMenuScene)
			{
				characterSuitScript = UnityEngine.Object.FindFirstObjectByType<CharacterSuitScript>();
			}
			else if (Game.Instance.SceneManager.InFlightScene)
			{
				characterSuitScript = FlightSceneScript.Instance.LocalPlayer.Graphics.GetComponentInChildren<CharacterSuitScript>();
			}
			if (characterSuitScript != null)
			{
				SetCharacterSuit(characterSuitScript);
			}
		}

		private void ApplyData(CharacterSuitScript suit, CharacterSuitData data)
		{
			suit.ApplyData(data);
		}

		private void ApplySuitConfig(string suitConfig)
		{
			CharacterManager.Instance.SelectedCharacter.SelectedSuit.SetSelectedConfig(suitConfig);
			CharacterSuitData selectedConfig = CharacterManager.Instance.SelectedCharacter.SelectedSuit.SelectedConfig;
			if (selectedConfig != null)
			{
				ApplyData(_suit, selectedConfig);
				SetCharacterSuit(_suit);
			}
		}

		private void CopyCurrentConfigToManager(CharacterSuitData configData)
		{
			CharacterManager.Instance.SetSuitConfig(SelectedCharacter, SelectedSuit, SelectedConfig, configData);
		}

		private void DiscardSettings()
		{
			CharacterManager.Instance.LoadCharacterData();
			SetCharacterSuit(CharacterManager.Instance.SwapCharacterSuit(_suit, SelectedCharacter, SelectedSuit, CharacterManager.Instance.SelectedConfig));
			SetUnchangedData();
			UpdateSpinnerValues();
		}

		private void OnDanceSpinnerValueChanged(string oldValue, string newValue)
		{
			int dance = _danceSpinner.Values.IndexOf(newValue);
			CharacterManager.Instance.SelectedCharacter.Dance = (CharacterManager.CharacterDance)dance;
			SetChangeButtonsActive(PendingChanges());
		}

		private void OnDiscardClicked(Widget buttonWidget)
		{
			DiscardSettings();
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			if (_changeSpacer.Visible || _changeWidget.Visible)
			{
				MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.ThreeButtons, "You have unsaved character settings.\n\n Save changes?", null, delegate(MessageDialogScript x)
				{
					x.Close();
					SaveSettings();
				});
				messageDialogScript.OkayButtonText = "Save";
				messageDialogScript.MiddleButtonText = "Discard";
				messageDialogScript.MiddleClicked += delegate(MessageDialogScript x)
				{
					x.Close();
					DiscardSettings();
				};
				messageDialogScript.CancelClicked += delegate(MessageDialogScript x)
				{
					x.Close();
					flyout.Show(show: true);
				};
			}
		}

		private void OnSaveClicked(Widget buttonWidget)
		{
			SaveSettings();
		}

		private void OnSuitConfigSpinnerValueChanged(string oldValue, string newValue)
		{
			ApplySuitConfig(newValue);
			SetChangeButtonsActive(PendingChanges());
		}

		private void OnSuitDataChanged(CharacterSuitScript suit, CharacterSuitData data)
		{
			ApplyData(suit, data);
			if (SelectedConfig == CharacterManager.DefaultConfigName)
			{
				CharacterSuitData suitConfig = CharacterManager.Instance.GetSuitConfig(SelectedCharacter, SelectedSuit, SelectedConfig);
				if (suitConfig.Items.Count != data.Items.Count)
				{
					Debug.LogError($"Suit data does not have the correct number of items. Has {data.Items.Count}, should have {suitConfig.Items.Count}");
					return;
				}
				for (int i = 0; i < suitConfig.Items.Count; i++)
				{
					if (suitConfig.Items[i].Enabled != data.Items[i].Enabled)
					{
						CharacterManager.Instance.SelectedCharacter.SelectedSuit.SetSelectedConfig("Custom");
						_themeSpinner.Value = SelectedConfig;
						CopyCurrentConfigToManager(data);
						break;
					}
					if (suitConfig.Items[i].Colors.Count != data.Items[i].Colors.Count)
					{
						Debug.LogError($"Suit data item {i} does not have the correct number of colors. Has {data.Items[i].Colors.Count}, should have {suitConfig.Items[i].Colors.Count}");
						return;
					}
					for (int j = 0; j < suitConfig.Items[i].Colors.Count; j++)
					{
						if (suitConfig.Items[i].Colors[j] != data.Items[i].Colors[j])
						{
							CharacterManager.Instance.SelectedCharacter.SelectedSuit.SetSelectedConfig("Custom");
							_themeSpinner.Value = SelectedConfig;
							break;
						}
					}
				}
			}
			else
			{
				CopyCurrentConfigToManager(data);
			}
			SetChangeButtonsActive(PendingChanges());
		}

		private void OnSuitSpinnerValueChanged(string oldValue, string newValue)
		{
			CharacterManager.Instance.SelectedCharacter.SetSelectedSuit(newValue);
			CharacterManager.Instance.SelectedSuit.SetSelectedConfig(SelectedConfig);
			CharacterSuitData selectedConfig = CharacterManager.Instance.SelectedConfig;
			SetCharacterSuit(CharacterManager.Instance.SwapCharacterSuit(_suit, SelectedCharacter, newValue, selectedConfig));
			UpdateSpinnerValues();
			SetChangeButtonsActive(PendingChanges());
		}

		private void SaveSettings()
		{
			CharacterManager.Instance.SaveCharacterSettings();
			SetUnchangedData();
			if (Game.Instance.SceneManager.InFlightScene)
			{
				FlightSceneScript.Instance.LocalPlayer.NetworkPlayer.SendSuitData(SelectedCharacter, SelectedSuit, CharacterManager.Instance.SelectedConfig);
			}
		}

		private void SetChangeButtonsActive(bool active)
		{
			_changeSpacer.SetVisible(active);
			_changeWidget.SetVisible(active);
		}

		private void SetUnchangedData()
		{
			_originalDanceSelection = SelectedDance;
			_originalCharacterSelection = SelectedCharacter;
			_originalSuitSelection = SelectedSuit;
			_originalConfigNameSelection = SelectedConfig;
			_originalConfigSelectionCopy = new CharacterSuitData();
			foreach (CharacterSuitData.CharacterSuitItemData item in CharacterManager.Instance.SelectedConfig.Items)
			{
				CharacterSuitData.CharacterSuitItemData characterSuitItemData = new CharacterSuitData.CharacterSuitItemData();
				characterSuitItemData.Name = item.Name;
				characterSuitItemData.Enabled = item.Enabled;
				characterSuitItemData.Colors.AddRange(item.Colors);
				_originalConfigSelectionCopy.Items.Add(characterSuitItemData);
			}
			SetChangeButtonsActive(active: false);
		}

		private void UpdateItemVisibility()
		{
			foreach (Action itemVisibilityUpdater in _itemVisibilityUpdaters)
			{
				itemVisibilityUpdater();
			}
		}

		private void UpdateSpinnerValues()
		{
			_danceSpinner.Values.Clear();
			string[] names = Enum.GetNames(typeof(CharacterManager.CharacterDance));
			foreach (string value in names)
			{
				_danceSpinner.Values.Add(value.PascalCaseToDisplay());
			}
			_danceSpinner.Value = CharacterManager.Instance.SelectedCharacter.Dance.DisplayName();
			_suitSpinner.Values.Clear();
			_suitSpinner.Values.AddRange(CharacterManager.Instance.SelectedCharacter.Suits.Keys);
			_suitSpinner.Value = SelectedSuit;
			_themeSpinner.Values.Clear();
			_themeSpinner.Values.AddRange(CharacterManager.Instance.SelectedSuit.Configs.Keys);
			_themeSpinner.Value = SelectedConfig;
		}
	}
}
