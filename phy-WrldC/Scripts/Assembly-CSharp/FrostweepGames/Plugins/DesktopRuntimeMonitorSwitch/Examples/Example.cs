using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrostweepGames.Plugins.DesktopRuntimeMonitorSwitch.Examples
{
	public class Example : MonoBehaviour
	{
		public Dropdown displaysDropdown;

		public InputField widthInputField;

		public InputField heightInputField;

		public Toggle fullScreenToggle;

		public Button applyButton;

		private void Start()
		{
			GetDisplays();
			applyButton.onClick.AddListener(ApplyButtonOnClickHandler);
		}

		private void PostDisplaysInConsole()
		{
			List<DisplayInfo> displays = RuntimeMonitorSwitchLib.GetDisplays();
			string text = string.Empty;
			foreach (DisplayInfo item in displays)
			{
				text = text + "Available - " + (item.Availability == "1") + Environment.NewLine;
				text = text + "width: " + item.ScreenWidth + " height: " + item.ScreenHeight + Environment.NewLine;
				text = text + "centerX: " + item.CenterX + " centerY: " + item.CenterY + Environment.NewLine;
				text = text + "top: " + item.Top + " bottom: " + item.Bottom + " left: " + item.Left + " right: " + item.Right + Environment.NewLine + Environment.NewLine;
			}
			Debug.Log(text);
		}

		private void GetDisplays()
		{
			List<DisplayInfo> displays = RuntimeMonitorSwitchLib.GetDisplays();
			displaysDropdown.ClearOptions();
			List<string> list = new List<string>();
			foreach (DisplayInfo item in displays)
			{
				list.Add(item.ScreenWidth + "x" + item.ScreenHeight);
			}
			displaysDropdown.AddOptions(list);
			if (displays.Count > 0)
			{
				widthInputField.text = displays[0].ScreenWidth.ToString();
				heightInputField.text = displays[0].ScreenHeight.ToString();
			}
		}

		private void ApplyButtonOnClickHandler()
		{
			if (widthInputField.text.Length >= 2 && heightInputField.text.Length >= 2)
			{
				RuntimeMonitorSwitchLib.SetDisplay(displaysDropdown.value, int.Parse(widthInputField.text), int.Parse(heightInputField.text), fullScreenToggle.isOn);
			}
		}
	}
}
