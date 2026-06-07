using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Multiplayer.ActivityFramework;
using Assets.Scripts.Multiplayer.ActivityFramework.Events;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI.Panels
{
	public class ActivitySettingsScript : FlightPanelScript
	{
		public enum ActivitySettingsVisibility
		{
			HostMenu = 0,
			HostLobby = 1,
			ClientLobby = 2
		}

		private class SettingWidget
		{
			public Action UpdateSettingValue { get; set; }

			public Widget Widget { get; set; }
		}

		private bool _recreate;

		private bool _refresh;

		private NetworkedActivitySettings _settings;

		private ActivitySettingsVisibility _visibility;

		private List<SettingWidget> _widgets = new List<SettingWidget>();

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			Widget widget2 = widget.FindWidget("restore-defaults-button");
			if (widget2 != null)
			{
				widget2.Clicked += OnRestoreDefaultsClicked;
			}
		}

		public void ReleaseActivitySettings()
		{
			SetActivitySettings(null, ActivitySettingsVisibility.ClientLobby);
		}

		public void SetActivitySettings(NetworkedActivitySettings activitySettings, ActivitySettingsVisibility visibility)
		{
			_visibility = visibility;
			if (_settings != null)
			{
				_settings.SettingAdded -= OnSettingAdded;
				_settings.SettingValueChanged -= OnSettingValueChanged;
			}
			_settings = activitySettings;
			if (_settings != null)
			{
				_settings.SettingAdded += OnSettingAdded;
				_settings.SettingValueChanged += OnSettingValueChanged;
				_recreate = true;
				Widget widget = base.Widget.FindWidget("host-is-in-control");
				if (widget != null)
				{
					widget.Visible = visibility == ActivitySettingsVisibility.ClientLobby;
				}
			}
			else
			{
				DestroySettingWidgets();
			}
		}

		protected void Update()
		{
			if (_recreate)
			{
				_recreate = false;
				CreateSettingWidgets();
			}
			if (_refresh)
			{
				_refresh = false;
				foreach (SettingWidget widget in _widgets)
				{
					widget.UpdateSettingValue();
				}
			}
			if (!UnityEngine.Input.GetMouseButton(0))
			{
				base.Widget.EnableClass("default-values", _settings.IsDefault);
			}
		}

		private void CreateSettingWidget(NetworkedActivitySetting setting, bool isHost)
		{
			NetworkedActivitySetting.VisibilityType visibilityType = ((_visibility == ActivitySettingsVisibility.HostMenu) ? setting.MenuVisibility : setting.LobbyVisibility);
			if (visibilityType == NetworkedActivitySetting.VisibilityType.Hidden)
			{
				return;
			}
			SettingWidget settingWidget = new SettingWidget();
			XAttribute[] instanceAttributes = new XAttribute[1]
			{
				new XAttribute("label", setting.DisplayName)
			};
			if (setting.ValueType == NetworkedActivitySetting.SettingValueType.Float || setting.ValueType == NetworkedActivitySetting.SettingValueType.Int)
			{
				if (setting.ValueRange.HasValue)
				{
					settingWidget.Widget = base.Widget.Context.CreateWidgetFromTemplate("control-slider", base.Widget, instanceAttributes);
					SliderControl sliderControl = new SliderControl(settingWidget.Widget);
					sliderControl.SetRange(setting.ValueRange.Value.MinValue, setting.ValueRange.Value.MaxValue);
					sliderControl.ValueFormatter = (float x) => x.ToString(setting.ValueFormat);
					if (setting.ValueType == NetworkedActivitySetting.SettingValueType.Int)
					{
						sliderControl.Slider.NumberOfSteps = (int)setting.ValueRange.Value.MaxValue - (int)setting.ValueRange.Value.MinValue + 1;
					}
					if (isHost)
					{
						sliderControl.Slider.ValueChanged += delegate(float x)
						{
							if (setting.ValueType == NetworkedActivitySetting.SettingValueType.Float)
							{
								setting.ValueFloat = x;
							}
							else
							{
								setting.ValueInt = (int)x;
							}
						};
					}
					settingWidget.UpdateSettingValue = delegate
					{
						float value = ((setting.ValueType == NetworkedActivitySetting.SettingValueType.Float) ? setting.ValueFloat : ((float)setting.ValueInt));
						sliderControl.SetValue(value);
					};
				}
				else
				{
					settingWidget.Widget = base.Widget.Context.CreateWidgetFromTemplate("control-spinner-input-label", base.Widget, instanceAttributes);
					NumericSpinnerControl spinnerControl = new NumericSpinnerControl(settingWidget.Widget);
					spinnerControl.StepSize = 1f;
					if (isHost)
					{
						NumericSpinnerControl numericSpinnerControl = spinnerControl;
						numericSpinnerControl.OnValueChanged = (OnValueChanged<float>)Delegate.Combine(numericSpinnerControl.OnValueChanged, (OnValueChanged<float>)delegate(float _, float x)
						{
							if (setting.ValueType == NetworkedActivitySetting.SettingValueType.Float)
							{
								setting.ValueFloat = x;
							}
							else
							{
								setting.ValueInt = (int)x;
							}
						});
					}
					settingWidget.UpdateSettingValue = delegate
					{
						float value = ((setting.ValueType == NetworkedActivitySetting.SettingValueType.Float) ? setting.ValueFloat : ((float)setting.ValueInt));
						spinnerControl.Value = value;
					};
				}
			}
			else if (setting.ValueType == NetworkedActivitySetting.SettingValueType.Bool)
			{
				settingWidget.Widget = base.Widget.Context.CreateWidgetFromTemplate("control-toggle", base.Widget, instanceAttributes);
				ToggleControl toggleControl = new ToggleControl(settingWidget.Widget);
				if (isHost)
				{
					toggleControl.Toggle.ValueChanged += delegate(bool x)
					{
						setting.ValueBool = x;
					};
				}
				settingWidget.UpdateSettingValue = delegate
				{
					toggleControl.Toggle.IsOn = setting.ValueBool;
				};
			}
			else if (setting.ValueType == NetworkedActivitySetting.SettingValueType.String)
			{
				settingWidget.Widget = base.Widget.Context.CreateWidgetFromTemplate("control-spinner-button", base.Widget, instanceAttributes);
				SpinnerControl spinnerControl2 = new SpinnerControl(settingWidget.Widget);
				spinnerControl2.Values.AddRange(setting.ValueOptions);
				if (isHost)
				{
					SpinnerControl spinnerControl3 = spinnerControl2;
					spinnerControl3.OnValueChanged = (OnValueChanged<string>)Delegate.Combine(spinnerControl3.OnValueChanged, (OnValueChanged<string>)delegate(string _, string x)
					{
						setting.ValueString = x;
					});
				}
				settingWidget.UpdateSettingValue = delegate
				{
					spinnerControl2.Value = setting.ValueString;
				};
			}
			if (!isHost || visibilityType == NetworkedActivitySetting.VisibilityType.VisibleReadOnly)
			{
				settingWidget.Widget.AddClass("read-only");
			}
			settingWidget.UpdateSettingValue();
			_widgets.Add(settingWidget);
		}

		private void CreateSettingWidgets()
		{
			DestroySettingWidgets();
			if (_settings == null)
			{
				return;
			}
			foreach (NetworkedActivitySetting allSetting in _settings.AllSettings)
			{
				CreateSettingWidget(allSetting, _visibility != ActivitySettingsVisibility.ClientLobby);
			}
		}

		private void DestroySettingWidgets()
		{
			foreach (SettingWidget widget in _widgets)
			{
				widget.Widget.Destroy();
			}
			_widgets.Clear();
		}

		private void OnRestoreDefaultsClicked(Widget widget)
		{
			_settings.RestoreDefaultValues();
			_recreate = true;
		}

		private void OnSettingAdded(object sender, NetworkedActivitySettingEventArgs e)
		{
			_recreate = true;
		}

		private void OnSettingValueChanged(object sender, NetworkedActivitySettingValueChangedEventArgs<object> e)
		{
			if (_visibility == ActivitySettingsVisibility.ClientLobby)
			{
				_refresh = true;
			}
		}
	}
}
