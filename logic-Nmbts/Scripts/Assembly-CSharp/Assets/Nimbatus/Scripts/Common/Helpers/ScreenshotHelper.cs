using System;
using System.IO;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class ScreenshotHelper : MonoBehaviour
	{
		private bool _disableGui;

		public void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		public void Update()
		{
			if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.CaptureScreenshot))
			{
				string text = Application.dataPath + "/../Nimbatus_Screenshots/";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				DateTime dateTime = DateTime.UtcNow;
				try
				{
					dateTime = DateTime.Now;
				}
				catch (TimeZoneNotFoundException)
				{
				}
				string text2 = dateTime.ToString("yyyyMMddHHmmssffff");
				string text3 = text + "Nimbatus_Screenshot_" + text2 + ".png";
				ScreenCapture.CaptureScreenshot(text3, 1);
				if (SteamManager.Initialized)
				{
					SteamScreenshots.AddScreenshotToLibrary(text3, null, Screen.width, Screen.height);
				}
			}
			if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.HideUi) && RuntimeGlobals.RunningMode != ERunningMode.Menu && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused)
			{
				Camera component = UnityEngine.Object.FindObjectOfType<UICamera>().gameObject.GetComponent<Camera>();
				_disableGui = !_disableGui;
				component.enabled = !_disableGui;
			}
			if (_disableGui && Input.GetKeyDown(KeyCode.Escape))
			{
				Camera component2 = UnityEngine.Object.FindObjectOfType<UICamera>().gameObject.GetComponent<Camera>();
				_disableGui = false;
				component2.enabled = true;
			}
		}
	}
}
