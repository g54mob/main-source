using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModApi;
using ModApi.Common.Events;
using ModApi.Settings.Core;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Settings
{
	public class SettingsDialogScript : DialogScript, ICanvasScaleChangeHandler
	{
		private class CategoryUi
		{
			public XmlElement Arrow { get; set; }

			public SettingsCategory Category { get; set; }

			public XmlElement Header { get; set; }

			public XmlElement Layout { get; set; }

			public SpinnerScript PresetSpinner { get; set; }

			public List<SettingUi> SettingElements { get; set; } = new List<SettingUi>();

			public void Collapse()
			{
				Layout.Hide();
				Arrow.SetAndApplyAttribute("rotation", "0,0,0");
				Category.Expanded = false;
			}

			public void Destruct()
			{
				UnityEngine.Object.Destroy(Header.gameObject);
				UnityEngine.Object.Destroy(Layout.gameObject);
				SettingElements.Clear();
				Category = null;
				Header = null;
				Layout = null;
				SettingElements = null;
			}

			public void Expand()
			{
				Layout.Show();
				Arrow.SetAndApplyAttribute("rotation", "0,0,-90");
				Category.Expanded = true;
			}

			public void ToggleCollapsed()
			{
				if (Layout.Visible)
				{
					Collapse();
				}
				else
				{
					Expand();
				}
			}
		}

		private class SettingUi
		{
			public Setting Setting { get; set; }

			public XmlElement SettingElement { get; set; }
		}

		private const string CustomPresetName = "Custom";

		private const string DiscardOrApplyMessage = "You have pending changes in the current tab.\n\nPlease discard or apply changes before switching tabs.";

		private const string PrimaryButtonClass = "btn-primary";

		private XmlElement _applyButton;

		private XmlElement _buttonTemplate;

		private XmlElement _cancelButton;

		private List<CategoryUi> _categories;

		private List<SettingsCategory> _categoriesPendingChanges = new List<SettingsCategory>();

		private XmlElement _categoryHeaderTemplate;

		private XmlElement _closeButton;

		private List<SettingsCategory> _currentSettingsCategories;

		private XmlElement _discardButton;

		private XmlElement _dropdownTemplate;

		private XmlElement _itemsParent;

		private XmlElement _layoutTemplate;

		private XmlElement _panel;

		private bool _refreshScrollRectViewPort;

		private Transform _scrollRectViewPort;

		private List<XmlElement> _settingCategoryButtons;

		private XmlElement _sliderTemplate;

		private XmlElement _spinnerTemplate;

		private XmlElement _textInputTemplate;

		private XmlElement _toggleTemplate;

		public bool PendingChanges => _categoriesPendingChanges.Count > 0;

		public static SettingsDialogScript Create()
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/Settings/SettingsDialog", Game.Instance.UserInterface.Transform, delegate(SettingsDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
		}

		void ICanvasScaleChangeHandler.OnCanvasScaleChanged(float canvasScaleFactor)
		{
			_refreshScrollRectViewPort = true;
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
			Game.Instance.QualitySettings.Display.DoFullscreenCheck();
			BuildCategories(_currentSettingsCategories);
		}

		protected virtual void Update()
		{
			if (_refreshScrollRectViewPort && _scrollRectViewPort != null)
			{
				_refreshScrollRectViewPort = false;
				_scrollRectViewPort.gameObject.SetActive(value: false);
				_scrollRectViewPort.gameObject.SetActive(value: true);
			}
			if (Game.Instance.UserInterface.ActiveDialog != this)
			{
				return;
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				OnCancelButtonClicked();
			}
			bool value = Game.Instance.QualitySettings.Display.Fullscreen.Value;
			Game.Instance.QualitySettings.Display.DoFullscreenCheck();
			if (value == Game.Instance.QualitySettings.Display.Fullscreen.Value)
			{
				return;
			}
			foreach (CategoryUi category in _categories)
			{
				if (category.Category != Game.Instance.QualitySettings.Display)
				{
					break;
				}
				foreach (SettingUi settingElement in category.SettingElements)
				{
					if (settingElement.Setting == Game.Instance.QualitySettings.Display.Fullscreen)
					{
						settingElement.SettingElement.GetComponentInChildren<Toggle>().isOn = Game.Instance.QualitySettings.Display.Fullscreen;
						break;
					}
				}
			}
		}

		private void BuildCategories(List<SettingsCategory> categories)
		{
			foreach (CategoryUi category in _categories)
			{
				category.Destruct();
			}
			_categories.Clear();
			foreach (SettingsCategory category2 in categories)
			{
				CreateCategoryUi(category2);
			}
		}

		private void ChangeResolutionSetting(ResolutionSetting setting, string resolutionWH, TMP_Dropdown resolutionDropdown)
		{
			Resolution resolution = default(Resolution);
			string[] array = resolutionWH.Split(new string[1] { " x " }, StringSplitOptions.None);
			resolution.width = int.Parse(array[0]);
			resolution.height = int.Parse(array[1]);
			resolution.refreshRateRatio = setting.Value.refreshRateRatio;
			if (resolution.Equals(setting.Value))
			{
				return;
			}
			Resolution oldResolution = default(Resolution);
			oldResolution.width = setting.Value.width;
			oldResolution.height = setting.Value.height;
			oldResolution.refreshRateRatio = setting.Value.refreshRateRatio;
			Debug.Log($"Change Resolution: {Screen.currentResolution} --> {resolution}");
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
			if (Game.Instance == null || Game.Instance.UserInterface == null)
			{
				return;
			}
			ModApi.Ui.MessageDialogScript resolutionConfirmationDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, base.transform.parent);
			string baseText = "Changed resolution to " + resolutionWH + "\n How does this look?\nReverting resolution change in [t] seconds, just in case something went wrong.";
			float num = 10f;
			float endTime = Time.time + num;
			resolutionConfirmationDialog.MessageText = baseText.Replace("[t]", (endTime - Time.time).ToString("0"));
			resolutionConfirmationDialog.CancelClicked += delegate(ModApi.Ui.MessageDialogScript x)
			{
				ResetResolution();
				x.Close();
			};
			resolutionConfirmationDialog.OkayClicked += delegate
			{
				resolution.refreshRateRatio = Screen.currentResolution.refreshRateRatio;
				setting.Value = resolution;
				setting.CommitChanges();
				Game.Instance.Settings.Save();
				resolutionConfirmationDialog.Close();
				_refreshScrollRectViewPort = true;
			};
			UnityEventDispatcher.Instance.ExecuteCustomYield(delegate
			{
				if (resolutionConfirmationDialog == null)
				{
					return false;
				}
				resolutionConfirmationDialog.MessageText = baseText.Replace("[t]", (endTime - Time.time).ToString("0"));
				return Time.time < endTime;
			}, delegate
			{
				if (resolutionConfirmationDialog != null)
				{
					ResetResolution();
					resolutionConfirmationDialog.Close();
				}
			});
			void ResetResolution()
			{
				Debug.Log($"Reset Resolution: {Screen.currentResolution} --> {oldResolution}");
				Screen.SetResolution(oldResolution.width, oldResolution.height, Screen.fullScreenMode, oldResolution.refreshRateRatio);
				setting.Value = oldResolution;
				resolutionDropdown.value = resolutionDropdown.options.IndexOf(resolutionDropdown.options.FirstOrDefault((TMP_Dropdown.OptionData x) => x.text == setting.Value.ToString().Split('@')[0].Trim()));
				_refreshScrollRectViewPort = true;
			}
		}

		private XmlElement CreateCategoryHeader(SettingsCategory category)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_categoryHeaderTemplate, _itemsParent);
			xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", category.CategoryName);
			XmlElement elementByInternalId = xmlElement.GetElementByInternalId("spinner");
			if (category.AvailablePresets != null && category.AvailablePresets.Count > 1)
			{
				SpinnerScript component = elementByInternalId.GetComponent<SpinnerScript>();
				foreach (SettingsCategoryPreset availablePreset in category.AvailablePresets)
				{
					component.Values.Add(GetPresetDisplayName(availablePreset));
				}
				component.Value = GetPresetDisplayName(category.Preset);
				component.OnValueChanged = (Action<string>)Delegate.Combine(component.OnValueChanged, (Action<string>)delegate(string x)
				{
					SetCategoryPreset(category, x);
				});
			}
			else
			{
				elementByInternalId.SetActive(active: false);
			}
			return xmlElement;
		}

		private void CreateCategoryUi(SettingsCategory category)
		{
			CategoryUi categoryUi = new CategoryUi
			{
				Category = category,
				Header = CreateCategoryHeader(category),
				Layout = UiUtilities.CloneTemplate(_layoutTemplate, _itemsParent)
			};
			categoryUi.Arrow = categoryUi.Header.GetElementByInternalId("arrow");
			categoryUi.Header.AddOnClickEvent(delegate
			{
				categoryUi.ToggleCollapsed();
			});
			_categories.Add(categoryUi);
			foreach (Setting setting in category.Settings)
			{
				if (setting.Visibility != SettingVisibility.Hidden)
				{
					categoryUi.SettingElements.Add(CreateSettingUi(categoryUi, setting));
				}
			}
			XmlElement elementByInternalId = categoryUi.Header.GetElementByInternalId("spinner");
			categoryUi.PresetSpinner = elementByInternalId.GetComponent<SpinnerScript>();
			if (category.Expanded)
			{
				categoryUi.Expand();
			}
			else
			{
				categoryUi.Collapse();
			}
		}

		private XmlElement CreateSettingElement(CategoryUi category, Setting setting)
		{
			XmlElement xmlElement = null;
			IEnumSetting enumSetting = setting as IEnumSetting;
			if (enumSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_spinnerTemplate, category.Layout);
				xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", setting.DisplayName);
				SpinnerScript elementByInternalId = xmlElement.GetElementByInternalId<SpinnerScript>("spinner");
				foreach (string availableStringValue in enumSetting.AvailableStringValues)
				{
					elementByInternalId.Values.Add(enumSetting.GetDisplayValue(availableStringValue));
				}
				elementByInternalId.Value = enumSetting.DisplayValue;
				if (setting.Visibility != SettingVisibility.ReadOnly)
				{
					elementByInternalId.OnValueChanged = (Action<string>)Delegate.Combine(elementByInternalId.OnValueChanged, new Action<string>(enumSetting.SetInternalValueFromDisplayValue));
					elementByInternalId.OnValueChanged = (Action<string>)Delegate.Combine(elementByInternalId.OnValueChanged, (Action<string>)delegate
					{
						OnSettingChanged(setting);
					});
				}
				else
				{
					elementByInternalId.OnValueChanged = (Action<string>)Delegate.Combine(elementByInternalId.OnValueChanged, (Action<string>)delegate(string x)
					{
						enumSetting.SetInternalValueFromDisplayValue(x);
						SetCategoryPreset(category.Category, "Custom");
					});
				}
			}
			NumericSetting<float> floatNumericSetting = setting as NumericSetting<float>;
			if (floatNumericSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_sliderTemplate, category.Layout);
				SliderControl slider = new SliderControl(xmlElement);
				slider.LabelText.SetText(floatNumericSetting.DisplayName);
				slider.Slider.wholeNumbers = true;
				slider.Slider.minValue = 0f;
				float num = floatNumericSetting.Max - floatNumericSetting.Min;
				slider.Slider.maxValue = 1f / floatNumericSetting.Step * num;
				slider.Slider.value = (floatNumericSetting.Value - floatNumericSetting.Min) / floatNumericSetting.Step;
				slider.ValueText.SetText(floatNumericSetting.DisplayValue);
				if (setting.Visibility != SettingVisibility.ReadOnly)
				{
					slider.Slider.onValueChanged.AddListener(delegate(float x)
					{
						float value = floatNumericSetting.Min + floatNumericSetting.Step * x;
						floatNumericSetting.Value = value;
						slider.ValueText.SetText(floatNumericSetting.DisplayValue);
						OnSettingChanged(setting);
					});
				}
				else
				{
					slider.Slider.onValueChanged.AddListener(delegate(float x)
					{
						float value = floatNumericSetting.Min + floatNumericSetting.Step * x;
						floatNumericSetting.Value = value;
						slider.ValueText.SetText(floatNumericSetting.DisplayValue);
						SetCategoryPreset(category.Category, "Custom");
					});
				}
			}
			NumericSetting<int> intNumericSetting = setting as NumericSetting<int>;
			if (intNumericSetting != null)
			{
				if (intNumericSetting.UseSpinnerUI)
				{
					xmlElement = UiUtilities.CloneTemplate(_spinnerTemplate, category.Layout);
					xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", setting.DisplayName);
					SpinnerScript elementByInternalId2 = xmlElement.GetElementByInternalId<SpinnerScript>("spinner");
					if (intNumericSetting.ReverseSpinnerUIValues)
					{
						for (int num2 = intNumericSetting.Max; num2 >= intNumericSetting.Min; num2 -= intNumericSetting.Step)
						{
							elementByInternalId2.Values.Add(num2.ToString());
						}
					}
					else
					{
						for (int num3 = intNumericSetting.Min; num3 <= intNumericSetting.Max; num3 += intNumericSetting.Step)
						{
							elementByInternalId2.Values.Add(num3.ToString());
						}
					}
					int defaultValue = intNumericSetting.Min;
					elementByInternalId2.OnLabelRequested = (string x) => intNumericSetting.GetDisplayValue(Utilities.ParseInt(x, defaultValue));
					elementByInternalId2.Value = intNumericSetting.Value.ToString();
					elementByInternalId2.OnValueChanged = (Action<string>)Delegate.Combine(elementByInternalId2.OnValueChanged, (Action<string>)delegate(string x)
					{
						intNumericSetting.Value = Utilities.ParseInt(x, defaultValue);
						SetCategoryPreset(category.Category, "Custom");
					});
					elementByInternalId2.OnValueChanged = (Action<string>)Delegate.Combine(elementByInternalId2.OnValueChanged, (Action<string>)delegate
					{
						OnSettingChanged(setting);
					});
				}
				else
				{
					xmlElement = UiUtilities.CloneTemplate(_sliderTemplate, category.Layout);
					SliderControl slider2 = new SliderControl(xmlElement);
					slider2.LabelText.SetText(intNumericSetting.DisplayName);
					slider2.Slider.wholeNumbers = true;
					slider2.Slider.minValue = 0f;
					slider2.Slider.maxValue = (intNumericSetting.Max - intNumericSetting.Min) / intNumericSetting.Step;
					slider2.Slider.value = (intNumericSetting.Value - intNumericSetting.Min) / intNumericSetting.Step;
					slider2.ValueText.SetText(intNumericSetting.DisplayValue);
					if (setting.Visibility != SettingVisibility.ReadOnly)
					{
						slider2.Slider.onValueChanged.AddListener(delegate(float x)
						{
							int value = intNumericSetting.Min + intNumericSetting.Step * (int)x;
							intNumericSetting.Value = value;
							slider2.ValueText.SetText(intNumericSetting.DisplayValue.ToString());
							OnSettingChanged(setting);
						});
					}
					else
					{
						slider2.Slider.onValueChanged.AddListener(delegate(float x)
						{
							int value = intNumericSetting.Min + intNumericSetting.Step * (int)x;
							intNumericSetting.Value = value;
							slider2.ValueText.SetText(intNumericSetting.DisplayValue.ToString());
							SetCategoryPreset(category.Category, "Custom");
						});
					}
				}
			}
			ButtonSetting buttonSetting = setting as ButtonSetting;
			if (buttonSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_buttonTemplate, category.Layout);
				xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", buttonSetting.DisplayName);
				xmlElement.GetElementByInternalId<Button>("button").onClick.AddListener(delegate
				{
					buttonSetting.RaiseSettingChangedEvent();
				});
				xmlElement.GetElementByInternalId<TextMeshProUGUI>("button-text").SetText(buttonSetting.ButtonText);
			}
			BoolSetting boolSetting = setting as BoolSetting;
			if (boolSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_toggleTemplate, category.Layout);
				xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", boolSetting.DisplayName);
				Toggle toggle = xmlElement.GetElementByInternalId<Toggle>("toggle");
				toggle.isOn = boolSetting.Value;
				if (setting.Visibility != SettingVisibility.ReadOnly)
				{
					toggle.onValueChanged.AddListener(delegate(bool x)
					{
						boolSetting.Value = x;
					});
					toggle.onValueChanged.AddListener(delegate
					{
						OnSettingChanged(setting);
					});
				}
				else
				{
					toggle.onValueChanged.AddListener(delegate
					{
						boolSetting.Value = toggle.isOn;
					});
					toggle.onValueChanged.AddListener(delegate
					{
						SetCategoryPreset(category.Category, "Custom");
					});
				}
			}
			StringSetting stringSetting = setting as StringSetting;
			if (stringSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_textInputTemplate, category.Layout);
				xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", stringSetting.DisplayName);
				TMP_InputField elementByInternalId3 = xmlElement.GetElementByInternalId<TMP_InputField>("input");
				elementByInternalId3.text = stringSetting.Value;
				if (setting.Visibility != SettingVisibility.ReadOnly)
				{
					elementByInternalId3.onValueChanged.AddListener(delegate(string x)
					{
						stringSetting.Value = x;
					});
					elementByInternalId3.onValueChanged.AddListener(delegate
					{
						OnSettingChanged(setting);
					});
				}
				else
				{
					elementByInternalId3.readOnly = true;
				}
			}
			ResolutionSetting resolutionSetting = setting as ResolutionSetting;
			if (resolutionSetting != null)
			{
				xmlElement = UiUtilities.CloneTemplate(_dropdownTemplate, category.Layout);
				xmlElement.GetElementByInternalId("label").SetAndApplyAttribute("text", resolutionSetting.DisplayName);
				TMP_Dropdown dropdown = xmlElement.gameObject.GetComponentInChildren<TMP_Dropdown>();
				dropdown.transform.Find("Template").GetComponent<ScrollRect>().scrollSensitivity = 20f;
				List<string> resolutions = new List<string>(Screen.resolutions.Length);
				for (int num4 = 0; num4 < Screen.resolutions.Length; num4++)
				{
					string item = Screen.resolutions[num4].ToString().Split('@')[0].Trim();
					if (!resolutions.Contains(item))
					{
						resolutions.Add(item);
					}
				}
				resolutions.Sort(delegate(string x, string y)
				{
					string[] array = x.Split(new string[1] { " x " }, StringSplitOptions.None);
					int num6 = int.Parse(array[0]);
					int num7 = int.Parse(array[1]);
					string[] array2 = y.Split(new string[1] { " x " }, StringSplitOptions.None);
					int num8 = int.Parse(array2[0]);
					int num9 = int.Parse(array2[1]);
					if (num6 * num7 == num8 * num9)
					{
						return 0;
					}
					return (num6 * num7 <= num8 * num9) ? 1 : (-1);
				});
				dropdown.AddOptions(resolutions);
				int num5 = resolutions.IndexOf($"{Screen.width} x {Screen.height}");
				if (num5 == -1)
				{
					num5 = resolutions.IndexOf($"{Screen.currentResolution.width} x {Screen.currentResolution.height}");
				}
				dropdown.value = num5;
				if (setting.Visibility != SettingVisibility.ReadOnly)
				{
					dropdown.onValueChanged.AddListener(delegate(int x)
					{
						ChangeResolutionSetting(resolutionSetting, dropdown.options[x].text, dropdown);
					});
				}
				else
				{
					dropdown.onValueChanged.AddListener(delegate
					{
						dropdown.value = resolutions.IndexOf($"{resolutionSetting.Value.width} x {resolutionSetting.Value.width}");
					});
				}
			}
			if (xmlElement != null)
			{
				XmlElement elementByInternalId4 = xmlElement.GetElementByInternalId("setting-info");
				if (elementByInternalId4 != null && !string.IsNullOrEmpty(setting.Description))
				{
					elementByInternalId4.Tooltip = setting.Description;
				}
				else
				{
					elementByInternalId4.SetActive(active: false);
				}
			}
			return xmlElement;
		}

		private SettingUi CreateSettingUi(CategoryUi category, Setting setting)
		{
			XmlElement xmlElement = CreateSettingElement(category, setting);
			if (!(xmlElement == null))
			{
				return new SettingUi
				{
					Setting = setting,
					SettingElement = xmlElement
				};
			}
			return null;
		}

		private void FinalizeApply()
		{
			List<SettingsCategory> list = new List<SettingsCategory>(_categoriesPendingChanges);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			foreach (SettingsCategory item in list)
			{
				foreach (Setting setting in item.Settings)
				{
					if (setting.PendingChange && setting.ApplyType != SettingApplyType.Immediate)
					{
						switch (setting.ApplyType)
						{
						case SettingApplyType.RequiresQuadsphereReload:
							flag3 = true;
							break;
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
			}
			Game.Instance.Settings.Save();
			if (!(flag || flag2 || flag3))
			{
				return;
			}
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, base.transform.parent);
			messageDialogScript.MessageText = string.Empty;
			if (flag)
			{
				messageDialogScript.MessageText += "Some settings won't take effect until the next time the designer or solar system is loaded.";
			}
			else if (flag3)
			{
				messageDialogScript.MessageText += "Some settings won't take effect until the next time a planet is loaded.";
			}
			if (flag2)
			{
				if (!string.IsNullOrEmpty(messageDialogScript.MessageText))
				{
					messageDialogScript.MessageText += Environment.NewLine;
				}
				messageDialogScript.MessageText = "Some settings won't take effect until the next time you start the game.";
			}
		}

		private string GetPresetDisplayName(SettingsCategoryPreset preset)
		{
			return preset switch
			{
				SettingsCategoryPreset.VeryHigh => "Very High", 
				SettingsCategoryPreset.VeryLow => "Very Low", 
				SettingsCategoryPreset.LittleGreenMen => "Little Green Men", 
				_ => preset.ToString(), 
			};
		}

		private IReadOnlyList<SettingsCategory> GetSelectedCategories()
		{
			return _settingCategoryButtons.FirstOrDefault((XmlElement x) => x.HasClass("btn-primary")).internalId switch
			{
				"Game" => Game.Instance.Settings.Game.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList(), 
				"Quality" => Game.Instance.Settings.Quality.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList(), 
				"Mods" => Game.Instance.Settings.ModSettings.Categories.Where((SettingsCategory x) => x.State == SettingState.Enabled).ToList(), 
				_ => null, 
			};
		}

		private void OnApplyButtonClicked()
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
			ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel, base.transform.parent);
			if (num > 1)
			{
				messageDialogScript.MessageText = "There are warnings for some settings you changed:\n\n" + stringBuilder.ToString() + "Do you still wish to apply settings?";
			}
			else
			{
				messageDialogScript.MessageText = "There is a warning for a setting you changed:\n\n" + stringBuilder.ToString() + "Do you still wish to apply settings?";
			}
			messageDialogScript.OkayButtonText = "Apply";
			messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript x)
			{
				x.Close();
				FinalizeApply();
			};
		}

		private void OnButtonCategoryClicked(XmlElement button)
		{
			XmlElement xmlElement = _settingCategoryButtons.FirstOrDefault((XmlElement x) => x.HasClass("btn-primary"));
			if (xmlElement != null)
			{
				if (xmlElement == button)
				{
					return;
				}
				if (PendingChanges)
				{
					ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, base.transform.parent);
					messageDialogScript.MessageText = "You have pending changes in the current tab.\n\nPlease discard or apply changes before switching tabs.";
					messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript x)
					{
						x.Close();
					};
					return;
				}
				if (xmlElement.HasClass("btn-primary"))
				{
					xmlElement.RemoveClass("btn-primary");
					xmlElement.ApplyAttributes();
				}
			}
			button.AddClass("btn-primary");
			button.ApplyAttributes();
			_currentSettingsCategories = new List<SettingsCategory>(GetSelectedCategories());
			BuildCategories(_currentSettingsCategories);
		}

		private void OnCancelButtonClicked()
		{
			foreach (SettingsCategory categoriesPendingChange in _categoriesPendingChanges)
			{
				categoriesPendingChange.RevertChanges();
			}
			Close();
		}

		private void OnCloseButtonClicked()
		{
			Game.Instance.Settings.Save();
			Close();
		}

		private void OnControlsButtonClicked()
		{
			if (PendingChanges)
			{
				ModApi.Ui.MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, base.transform.parent);
				messageDialogScript.MessageText = "You have pending changes in the current tab.\n\nPlease discard or apply changes before switching tabs.";
				messageDialogScript.OkayClicked += delegate(ModApi.Ui.MessageDialogScript x)
				{
					x.Close();
				};
			}
			else
			{
				ControlSettingsDialogScript.Create(base.transform.parent);
			}
		}

		private void OnDiscardButtonClicked()
		{
			foreach (SettingsCategory item in new List<SettingsCategory>(_categoriesPendingChanges))
			{
				item.RevertChanges();
				SetPendingChanges(item, pendingChanges: false);
			}
			_currentSettingsCategories = new List<SettingsCategory>(GetSelectedCategories());
			BuildCategories(_currentSettingsCategories);
		}

		private void OnDoneButtonClicked()
		{
			Close();
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_itemsParent = xmlLayout.GetElementById("items-parent");
			_scrollRectViewPort = xmlLayout.GetElementById<ScrollRect>("items-scroll")?.viewport;
			XmlElement elementById = xmlLayout.GetElementById("control-categories");
			_settingCategoryButtons = new List<XmlElement>(elementById.childElements.Where((XmlElement x) => !string.IsNullOrEmpty(x.internalId)));
			foreach (XmlElement button in _settingCategoryButtons)
			{
				button.AddOnClickEvent(delegate
				{
					OnButtonCategoryClicked(button);
				});
				if (button.internalId == "Mods")
				{
					button.SetActive(Game.Instance.Settings.ModSettings.Categories.Count > 0);
				}
			}
			_categoryHeaderTemplate = xmlLayout.GetElementById("template-header");
			_layoutTemplate = xmlLayout.GetElementById("template-layout");
			_dropdownTemplate = xmlLayout.GetElementById("template-dropdown");
			_spinnerTemplate = xmlLayout.GetElementById("template-spinner-text");
			_sliderTemplate = xmlLayout.GetElementById("template-slider");
			_toggleTemplate = xmlLayout.GetElementById("template-toggle");
			_buttonTemplate = xmlLayout.GetElementById("template-button");
			_textInputTemplate = xmlLayout.GetElementById("template-text-input");
			_closeButton = xmlLayout.GetElementById("close-button");
			_cancelButton = xmlLayout.GetElementById("cancel-button");
			_discardButton = xmlLayout.GetElementById("discard-button");
			_applyButton = xmlLayout.GetElementById("apply-button");
			_panel.SetAttribute("active", "false");
			_categories = new List<CategoryUi>();
			_currentSettingsCategories = new List<SettingsCategory>(GetSelectedCategories());
		}

		private void OnSettingChanged(Setting setting)
		{
			if (setting.PendingChange)
			{
				SetPendingChanges(setting.Category);
			}
			else if (!setting.Category.PendingChanges)
			{
				SetPendingChanges(setting.Category, pendingChanges: false);
			}
		}

		private void SetCategoryPreset(SettingsCategory category, string presetString, bool updatingOverall = false)
		{
			string value = presetString.Replace(" ", string.Empty);
			SettingsCategoryPreset settingsCategoryPreset = (SettingsCategoryPreset)Enum.Parse(typeof(SettingsCategoryPreset), value);
			CategoryUi categoryUi = _categories.FirstOrDefault((CategoryUi x) => x.Category == category);
			if ((category.Preset == settingsCategoryPreset && categoryUi.PresetSpinner.Value == presetString) || !category.AvailablePresets.Contains(settingsCategoryPreset))
			{
				return;
			}
			category.SetPreset(settingsCategoryPreset);
			categoryUi.PresetSpinner.Value = presetString;
			foreach (SettingUi settingElement in categoryUi.SettingElements)
			{
				UnityEngine.Object.Destroy(settingElement.SettingElement.gameObject);
			}
			categoryUi.SettingElements = new List<SettingUi>();
			foreach (Setting setting in category.Settings)
			{
				if (setting.Visibility != SettingVisibility.Hidden)
				{
					categoryUi.SettingElements.Add(CreateSettingUi(categoryUi, setting));
				}
			}
			if (settingsCategoryPreset == SettingsCategoryPreset.Custom && category.Settings.Count >= 1)
			{
				categoryUi.Expand();
			}
			if (category.CategoryName == "Overall Quality" && settingsCategoryPreset != SettingsCategoryPreset.Custom)
			{
				foreach (CategoryUi category2 in _categories)
				{
					if (category2 != categoryUi)
					{
						SetCategoryPreset(category2.Category, GetPresetDisplayName(category2.Category.Preset), updatingOverall: true);
					}
				}
			}
			else if (!updatingOverall)
			{
				CategoryUi categoryUi2 = _categories.FirstOrDefault((CategoryUi x) => x.Category.CategoryName == "Overall Quality");
				if (categoryUi2 != null)
				{
					SetCategoryPreset(categoryUi2.Category, "Custom");
				}
			}
			SetPendingChanges(category, category.PendingChanges);
		}

		private void SetPendingChanges(SettingsCategory pendingCategory, bool pendingChanges = true)
		{
			if (pendingChanges && !PendingChanges)
			{
				_closeButton.SetActive(active: false);
				_cancelButton.SetActive(active: true);
				_discardButton.SetActive(active: true);
				_applyButton.SetActive(active: true);
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
					_closeButton.SetActive(active: true);
					_cancelButton.SetActive(active: false);
					_discardButton.SetActive(active: false);
					_applyButton.SetActive(active: false);
				}
			}
		}
	}
}
