using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Settings
{
	public class SettingsDialogScript : PanelDialogScript
	{
		private class SettingsCategoryUi
		{
			public SettingsCategory Category { get; set; }

			public HeaderScript Header { get; set; }

			public Widget Layout { get; set; }

			public List<SettingUi> SettingWidgets { get; set; }

			public SettingsCategoryUi(SettingsCategory category, HeaderScript header, Widget layout)
			{
				SettingWidgets = new List<SettingUi>();
				Category = category;
				Header = header;
				Layout = layout;
				if (!Category.Expanded)
				{
					Header.Collapsed = true;
				}
			}

			public void Destruct()
			{
				if (Header != null)
				{
					Header.Widget.Destroy();
				}
				if (Layout != null)
				{
					Layout.Destroy();
				}
				SettingWidgets.Clear();
				Category = null;
				Header = null;
				Layout = null;
				SettingWidgets = null;
			}
		}

		private class SettingUi
		{
			public Setting Setting { get; set; }

			public Widget Widget { get; set; }

			public SettingUi(Setting setting, Widget widget)
			{
				Setting = setting;
				Widget = widget;
			}
		}

		private Widget _applyButton;

		private List<SettingsCategoryUi> _categories;

		private List<SettingsCategory> _categoriesPendingChanges;

		private Widget _closeButton;

		private Widget _container;

		private List<SettingsCategory> _currentSettingsCategories;

		private Widget _discardButton;

		private EnumSpinnerControl<SettingsCategoryPreset> _overallQualitySpinner;

		public bool PendingChanges => _categoriesPendingChanges.Count > 0;

		public override void Close()
		{
			base.Close();
		}

		public void OnControlsTabClicked(Widget widget)
		{
			Game.Instance.UserInterface.CreateControlSettingsDialog();
		}

		public void OnGameTabClicked(Widget widget)
		{
			if (!_currentSettingsCategories.Contains(Game.Instance.Settings.Gameplay.General))
			{
				_currentSettingsCategories = Game.Instance.Settings.Gameplay.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList();
				BuildCategories(_currentSettingsCategories);
				base.Widget.FindWidget("QualityButton").RemoveClass("btn-primary");
				widget.AddClass("btn-primary");
			}
		}

		public void OnQualityTabClicked(Widget widget)
		{
			if (!_currentSettingsCategories.Contains(Game.Instance.Settings.Quality.Display))
			{
				_currentSettingsCategories = Game.Instance.Settings.Quality.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList();
				BuildCategories(_currentSettingsCategories);
				base.Widget.FindWidget("GameButton").RemoveClass("btn-primary");
				widget.AddClass("btn-primary");
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_container = base.Widget.FindWidget("settings-container");
			_categories = new List<SettingsCategoryUi>();
			_closeButton = base.Widget.FindWidget("CloseButton");
			_discardButton = base.Widget.FindWidget("DiscardButton");
			_applyButton = base.Widget.FindWidget("ApplyButton");
			_discardButton.SetVisible(visible: false);
			_applyButton.SetVisible(visible: false);
			_categoriesPendingChanges = new List<SettingsCategory>();
			_currentSettingsCategories = Game.Instance.Settings.Gameplay.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList();
			BuildCategories(_currentSettingsCategories);
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCloseClicked(null);
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					OnApplyClicked(null);
				}
			}
		}

		private void BuildCategories(List<SettingsCategory> categories)
		{
			_overallQualitySpinner = null;
			foreach (SettingsCategoryUi category in _categories)
			{
				category.Destruct();
			}
			_categories.Clear();
			foreach (SettingsCategory category2 in categories)
			{
				BuildCategory(category2);
			}
		}

		private void BuildCategory(SettingsCategory category)
		{
			List<Setting> value;
			using (CollectionPool<List<Setting>, Setting>.Get(out value))
			{
				bool flag = (Device.IsUnityEditor || Device.IsDebugBuild) && UnityEngine.Input.GetKey(KeyCode.LeftControl);
				foreach (Setting setting in category.Settings)
				{
					if ((setting.State != SettingState.Hidden || flag) && setting.State != SettingState.HiddenReadOnly && setting.State != SettingState.Disabled)
					{
						value.Add(setting);
					}
				}
				if (category.CategoryName == "Overall Quality")
				{
					Widget widget = base.Widget.Context.CreateWidgetFromTemplate("overall-quality-header", _container);
					_overallQualitySpinner = new EnumSpinnerControl<SettingsCategoryPreset>(widget);
					EnumSpinnerControl<SettingsCategoryPreset> overallQualitySpinner = _overallQualitySpinner;
					overallQualitySpinner.OnValueChanged = (OnValueChanged<SettingsCategoryPreset>)Delegate.Combine(overallQualitySpinner.OnValueChanged, new OnValueChanged<SettingsCategoryPreset>(OnOverallQualityChanged));
					_overallQualitySpinner.Values.Clear();
					_overallQualitySpinner.Values.AddRange(category.AvailablePresets);
					_overallQualitySpinner.Value = category.Preset;
					_categories.Add(new SettingsCategoryUi(category, widget.GetComponent<HeaderScript>(), null));
				}
				else
				{
					if (value.Count == 0)
					{
						return;
					}
					HeaderScript componentInChildren = base.Widget.Context.CreateWidgetFromTemplate("control-header", _container).GetComponentInChildren<HeaderScript>();
					componentInChildren.LabelText = category.CategoryName;
					componentInChildren.CollapsedStateChanged += delegate(object w, HeaderScript.CollapsedStateChangedEventArgs e)
					{
						category.Expanded = !e.IsCollapsed;
					};
					Widget widget2 = base.Widget.Context.CreateWidgetFromTemplate("settings-group", _container);
					SettingsCategoryUi settingsCategoryUi = new SettingsCategoryUi(category, componentInChildren, widget2);
					_categories.Add(settingsCategoryUi);
					{
						foreach (Setting item in value)
						{
							settingsCategoryUi.SettingWidgets.Add(CreateSettingsWidget(item, widget2));
						}
						return;
					}
				}
			}
		}

		private SettingUi CreateSettingsWidget(Setting setting, Widget parent)
		{
			Widget widget = null;
			Widget widget2 = base.Widget.Context.CreateWidgetFromTemplate("setting-row", parent);
			Widget parent2 = widget2.FindWidget("setting");
			string text = setting.DisplayName;
			if (setting.State != SettingState.Enabled)
			{
				text = "*" + text;
			}
			IEnumSetting enumSetting = setting as IEnumSetting;
			if (enumSetting != null)
			{
				widget = base.Widget.Context.CreateWidgetFromTemplate("control-spinner-button", parent2);
				SpinnerControl spinnerControl = new SpinnerControl(widget);
				spinnerControl.LabelText = text;
				foreach (string availableStringValue in enumSetting.AvailableStringValues)
				{
					spinnerControl.Values.Add(enumSetting.GetDisplayValue(availableStringValue));
				}
				spinnerControl.Value = enumSetting.DisplayValue;
				spinnerControl.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(spinnerControl.OnValueChanged, (OnValueChanged<string>)delegate(string _, string x)
				{
					enumSetting.SetInternalValueFromDisplayValue(x);
					OnSettingChanged(setting);
				});
			}
			else
			{
				NumericSetting<float> floatSetting = setting as NumericSetting<float>;
				if (floatSetting != null)
				{
					widget = base.Widget.Context.CreateWidgetFromTemplate("control-slider", parent2);
					widget2.AddClass("setting-row-slider");
					SliderControl sliderControl = new SliderControl(widget);
					sliderControl.SetRange(floatSetting.Min, floatSetting.Max);
					sliderControl.ValueFormatter = (float x) => floatSetting.GetDisplayValue(x);
					sliderControl.Slider.Value = floatSetting.Value;
					sliderControl.Slider.ValueChanged += delegate(float x)
					{
						float value = Mathf.Round(x / floatSetting.Step) * floatSetting.Step;
						sliderControl.Slider.Value = value;
						if (!floatSetting.ApplyOnSliderRelease)
						{
							floatSetting.Value = value;
							OnSettingChanged(setting);
						}
					};
					if (floatSetting.ApplyOnSliderRelease)
					{
						sliderControl.OnRelease += delegate(float _, float value)
						{
							floatSetting.Value = Mathf.Round(value / floatSetting.Step) * floatSetting.Step;
							OnSettingChanged(setting);
						};
					}
					sliderControl.LabelText = text;
				}
				else
				{
					NumericSetting<int> intSetting = setting as NumericSetting<int>;
					if (intSetting != null)
					{
						if (intSetting.UseSpinnerUI)
						{
							widget = base.Widget.Context.CreateWidgetFromTemplate("control-spinner-button", parent2);
							SpinnerControl spinnerControl2 = new SpinnerControl(widget);
							spinnerControl2.LabelText = text;
							if (intSetting.ReverseSpinnerUIValues)
							{
								for (int num = intSetting.Max; num >= intSetting.Min; num -= intSetting.Step)
								{
									spinnerControl2.Values.Add(num.ToString());
								}
							}
							else
							{
								for (int num2 = intSetting.Min; num2 <= intSetting.Max; num2 += intSetting.Step)
								{
									spinnerControl2.Values.Add(num2.ToString());
								}
							}
							spinnerControl2.OnLabelRequested = (string x) => intSetting.GetDisplayValue(int.TryParse(x, out var result) ? result : intSetting.Value);
							spinnerControl2.Value = intSetting.DisplayValue;
							spinnerControl2.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(spinnerControl2.OnValueChanged, (OnValueChanged<string>)delegate(string _, string x)
							{
								int value = intSetting.Value;
								if (int.TryParse(x, out var result))
								{
									value = result;
								}
								intSetting.Value = value;
								OnSettingChanged(setting);
							});
						}
						else
						{
							widget = base.Widget.Context.CreateWidgetFromTemplate("control-slider", parent2);
							widget2.AddClass("setting-row-slider");
							SliderControl sliderControl2 = new SliderControl(widget);
							sliderControl2.LabelText = text;
							sliderControl2.SetRange(intSetting.Min, intSetting.Max);
							sliderControl2.ValueFormatter = (float x) => intSetting.GetDisplayValue((int)x);
							sliderControl2.Slider.Value = intSetting.Value;
							sliderControl2.Slider.Slider.wholeNumbers = true;
							sliderControl2.Slider.Slider.minValue = intSetting.Min;
							sliderControl2.Slider.Slider.maxValue = intSetting.Max;
							Action<float> updateAction = delegate(float value)
							{
								int num3 = (int)value;
								if (intSetting.Value != num3)
								{
									intSetting.Value = num3;
									OnSettingChanged(setting);
								}
							};
							if (intSetting.ApplyOnSliderRelease)
							{
								sliderControl2.OnRelease += delegate(float _, float value)
								{
									updateAction(value);
								};
							}
							else
							{
								sliderControl2.Slider.ValueChanged += updateAction;
							}
						}
					}
					else
					{
						BoolSetting boolSetting = setting as BoolSetting;
						if (boolSetting != null)
						{
							widget = base.Widget.Context.CreateWidgetFromTemplate("control-toggle", parent2);
							ToggleControl toggleControl = new ToggleControl(widget);
							toggleControl.LabelText = text;
							toggleControl.Toggle.IsOn = boolSetting.Value;
							toggleControl.Toggle.ValueChanged += delegate(bool x)
							{
								boolSetting.Value = x;
								OnSettingChanged(setting);
							};
						}
						else
						{
							StringSetting stringSetting = setting as StringSetting;
							if (stringSetting != null)
							{
								widget = base.Widget.Context.CreateWidgetFromTemplate("control-text-input-label", parent2);
								TextInputControl textInputControl = new TextInputControl(widget);
								textInputControl.LabelText = text;
								textInputControl.Value = stringSetting.Value;
								if (setting.Visibility != SettingVisibility.ReadOnly)
								{
									textInputControl.OnValueChanged = (Action<string>)Delegate.Combine(textInputControl.OnValueChanged, (Action<string>)delegate(string x)
									{
										stringSetting.Value = x;
										OnSettingChanged(setting);
									});
								}
								else
								{
									textInputControl.InputField.Input.readOnly = true;
								}
							}
							else
							{
								ResolutionSetting resolutionSetting = setting as ResolutionSetting;
								if (resolutionSetting != null)
								{
									widget = base.Widget.Context.CreateWidgetFromTemplate("control-button-label", parent2);
									ButtonControl buttonControl = new ButtonControl(widget);
									buttonControl.LabelText = text;
									buttonControl.ValueText.Text = $"{resolutionSetting.Value.width} x {resolutionSetting.Value.height}";
									buttonControl.Button.Button.onClick.AddListener(delegate
									{
										ResolutionDialogScript resolutionDialogScript = Game.Instance.UserInterface.CreateResolutionDialog();
										resolutionDialogScript.OnClose = (Action)Delegate.Combine(resolutionDialogScript.OnClose, (Action)delegate
										{
											buttonControl.ValueText.Text = $"{resolutionSetting.Value.width} x {resolutionSetting.Value.height}";
										});
									});
								}
							}
						}
					}
				}
			}
			widget2.FindWidget("tooltip").Tooltip = setting.Description;
			widget2.AddClass("setting-row");
			return new SettingUi(setting, widget2);
		}

		private void DiscardSettings()
		{
			foreach (SettingsCategory item in new List<SettingsCategory>(_categoriesPendingChanges))
			{
				item.RevertChanges();
				SetPendingChanges(item, pendingChanges: false);
			}
		}

		private void FinalizeApply()
		{
			List<SettingsCategory> list = new List<SettingsCategory>(_categoriesPendingChanges);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			IGameSettings gameplay = Game.Instance.Settings.Gameplay;
			IGameQualitySettings quality = Game.Instance.Settings.Quality;
			bool flag4 = false;
			bool flag5 = false;
			foreach (SettingsCategory item in list)
			{
				foreach (Setting setting in item.Settings)
				{
					if (setting.PendingChange && setting.ApplyType != SettingApplyType.Immediate)
					{
						switch (setting.ApplyType)
						{
						case SettingApplyType.RequiresSceneRestart:
							flag = true;
							break;
						case SettingApplyType.RequiresGameRestart:
							flag2 = true;
							break;
						}
					}
				}
				item.CommitChanges();
				SetPendingChanges(item, pendingChanges: false);
				flag4 |= gameplay.Categories.Contains(item);
				flag5 |= quality.Categories.Contains(item);
			}
			if (flag4)
			{
				gameplay.Save();
			}
			if (flag5)
			{
				quality.Save();
			}
			if (!(flag || flag2 || flag3))
			{
				return;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, string.Empty);
			messageDialogScript.Title = "Reload Required";
			if (flag)
			{
				if (Game.Instance.SceneManager.InFlightScene)
				{
					messageDialogScript.MessageText += "Some settings won't take effect until the flight scene is fully reloaded. To apply them, return to the main menu and re-enter the designer or flight scene.";
				}
				else
				{
					messageDialogScript.MessageText += "Some settings won't take effect until the next time the designer or flight scene is loaded.";
				}
			}
			if (flag2)
			{
				if (!string.IsNullOrEmpty(messageDialogScript.MessageText))
				{
					messageDialogScript.MessageText += System.Environment.NewLine;
				}
				messageDialogScript.MessageText = "Some settings won't take effect until the next time you start the game.";
			}
		}

		private void OnApplyClicked(Widget widget)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (SettingsCategory categoriesPendingChange in _categoriesPendingChanges)
			{
				foreach (Setting setting in categoriesPendingChange.Settings)
				{
					if (setting.PendingChange && !string.IsNullOrEmpty(setting.Warning))
					{
						stringBuilder.Append(setting.DisplayName);
						stringBuilder.Append(" - ");
						stringBuilder.Append(setting.Warning);
						stringBuilder.Append("\n\n");
						num++;
					}
				}
			}
			if (num == 0)
			{
				FinalizeApply();
				return;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, string.Empty);
			if (num > 1)
			{
				messageDialogScript.MessageText = "There are warnings for some settings you changed:\n\n" + stringBuilder.ToString() + "Do you still wish to apply settings?";
			}
			else
			{
				messageDialogScript.MessageText = "There is a warning for a setting you changed:\n\n" + stringBuilder.ToString() + "Do you still wish to apply settings?";
			}
			messageDialogScript.OkayButtonText = "Apply";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript x)
			{
				x.Close();
				FinalizeApply();
			};
		}

		private void OnCloseClicked(Widget widget)
		{
			DiscardSettings();
			Close();
		}

		private void OnDiscardClicked(Widget widget)
		{
			DiscardSettings();
			BuildCategories(_currentSettingsCategories);
		}

		private void OnOverallQualityChanged(SettingsCategoryPreset oldValue, SettingsCategoryPreset newValue)
		{
			OverallQualitySetting overallQuality = Game.Instance.Settings.Quality.OverallQuality;
			overallQuality.SetPreset(newValue);
			BuildCategories(_currentSettingsCategories);
			SetPendingChanges(overallQuality);
			foreach (SettingsCategory category in Game.Instance.Settings.Quality.Categories)
			{
				if (category.PendingChanges)
				{
					SetPendingChanges(category);
				}
			}
		}

		private void OnSettingChanged(Setting setting)
		{
			if (_overallQualitySpinner != null)
			{
				OverallQualitySetting overallQuality = Game.Instance.Settings.Quality.OverallQuality;
				if (overallQuality.Preset != SettingsCategoryPreset.Custom)
				{
					_overallQualitySpinner.Value = SettingsCategoryPreset.Custom;
					overallQuality.SetPreset(SettingsCategoryPreset.Custom);
					SetPendingChanges(overallQuality);
				}
				if (setting.Category.AvailablePresets.Contains(SettingsCategoryPreset.Custom))
				{
					setting.Category.SetPreset(SettingsCategoryPreset.Custom);
				}
			}
			if (setting.PendingChange)
			{
				SetPendingChanges(setting.Category);
			}
			else if (!setting.Category.PendingChanges)
			{
				SetPendingChanges(setting.Category, pendingChanges: false);
			}
		}

		private void SetPendingChanges(SettingsCategory pendingCategory, bool pendingChanges = true)
		{
			if (pendingChanges && !PendingChanges)
			{
				_closeButton.SetVisible(visible: false);
				_discardButton.SetVisible(visible: true);
				_applyButton.SetVisible(visible: true);
			}
			if (pendingChanges && !_categoriesPendingChanges.Contains(pendingCategory))
			{
				_categoriesPendingChanges.Add(pendingCategory);
			}
			else if (!pendingChanges && _categoriesPendingChanges.Contains(pendingCategory))
			{
				_categoriesPendingChanges.Remove(pendingCategory);
				if (!PendingChanges)
				{
					_closeButton.SetVisible(visible: true);
					_discardButton.SetVisible(visible: false);
					_applyButton.SetVisible(visible: false);
				}
			}
		}
	}
}
