using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Events;
using Jundroo.Common.Settings;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Settings
{
	public class ResolutionDialogScript : PanelDialogScript
	{
		private Widget _applyButton;

		private Widget _cancelButton;

		private Widget _container;

		private Action _onClose;

		private Dictionary<Widget, string> _resolutionOptions;

		private Widget _selectedWidget;

		public Action OnClose
		{
			get
			{
				return _onClose;
			}
			set
			{
				_onClose = value;
			}
		}

		public override void Close()
		{
			base.Close();
			_onClose?.Invoke();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_container = base.Widget.FindWidget("options-container");
			_cancelButton = base.Widget.FindWidget("CancelButton");
			_applyButton = base.Widget.FindWidget("OkayButton");
			_resolutionOptions = new Dictionary<Widget, string>();
			GenerateResolutionOptions(_container);
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this)
			{
				if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
				{
					OnCancelClicked(null);
				}
				else if (UnityEngine.Input.GetKeyDown(KeyCode.Return) || UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					OnOkayClicked(null);
				}
			}
		}

		private void GenerateResolutionOptions(Widget parent)
		{
			List<string> list = new List<string>(Screen.resolutions.Length);
			for (int i = 0; i < Screen.resolutions.Length; i++)
			{
				string item = Screen.resolutions[i].ToString().Split('@')[0].Trim();
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			list.Sort(delegate(string x, string y)
			{
				string[] array = x.Split(new string[1] { " x " }, StringSplitOptions.None);
				int num = int.Parse(array[0]);
				int num2 = int.Parse(array[1]);
				string[] array2 = y.Split(new string[1] { " x " }, StringSplitOptions.None);
				int num3 = int.Parse(array2[0]);
				int num4 = int.Parse(array2[1]);
				if (num * num2 == num3 * num4)
				{
					return 0;
				}
				return (num * num2 <= num3 * num4) ? 1 : (-1);
			});
			foreach (string item2 in list)
			{
				Widget widget = base.Widget.Context.CreateWidgetFromTemplate("control-button", parent, new XAttribute[3]
				{
					new XAttribute("id", "resolution-option"),
					new XAttribute("text", item2),
					new XAttribute("onClick", "OnResolutionClicked")
				});
				_resolutionOptions.Add(widget, item2);
				if (Game.Instance.Settings.Quality.Display.Resolution.Value.ToString().Contains(item2))
				{
					SetSelectedWidget(widget);
				}
			}
		}

		private void OnCancelClicked(Widget widget)
		{
			Close();
		}

		private void OnOkayClicked(Widget widget)
		{
			TrySetResolution(_resolutionOptions[_selectedWidget]);
		}

		private void OnResolutionClicked(Widget widget)
		{
			SetSelectedWidget(widget);
		}

		private void SetSelectedWidget(Widget widget)
		{
			if (_selectedWidget != widget)
			{
				_selectedWidget?.RemoveClass("btn-primary");
				_selectedWidget?.AddClass("btn-default");
				widget?.RemoveClass("btn-default");
				widget?.AddClass("btn-primary");
				_selectedWidget = widget;
			}
		}

		private void TrySetResolution(string resolutionWH)
		{
			ResolutionSetting setting = Game.Instance.Settings.Quality.Display.Resolution;
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
			Debug.Log($"Change Resolution: {Screen.width} x {Screen.height} --> {resolution}");
			Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
			if (Game.Instance == null || Game.Instance.UserInterface == null)
			{
				return;
			}
			MessageDialogScript resolutionConfirmationDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			string baseText = "Changed resolution to " + resolutionWH + "\n How does this look?\nReverting resolution change in [t] seconds, just in case something went wrong.";
			float num = 10f;
			float endTime = Time.time + num;
			resolutionConfirmationDialog.MessageText = baseText.Replace("[t]", (endTime - Time.time).ToString("0"));
			resolutionConfirmationDialog.CancelClicked += delegate(MessageDialogScript x)
			{
				ResetResolution();
				x.Close();
			};
			resolutionConfirmationDialog.OkayClicked += delegate
			{
				resolution.refreshRateRatio = Screen.currentResolution.refreshRateRatio;
				setting.Value = resolution;
				setting.CommitChanges();
				Game.Instance.Settings.Quality.Save();
				resolutionConfirmationDialog.Close();
				Close();
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
				SetSelectedWidget(_resolutionOptions.FirstOrDefault((KeyValuePair<Widget, string> x) => oldResolution.ToString().Contains(x.Value)).Key);
			}
		}
	}
}
