using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls.Keybinds
{
	public class KeybindManager : BaseSingleton<KeybindManager>
	{
		private Dictionary<EKeybinding, KeybindSetting> _keyBindings = new Dictionary<EKeybinding, KeybindSetting>();

		private string Filename = "Keybindings.xml";

		protected override void Awake()
		{
			base.Awake();
			UnityEngine.Object.DontDestroyOnLoad(BaseSingleton<KeybindManager>.Instance);
			Init();
			Load();
		}

		public List<KeybindSetting> GetKeybinds()
		{
			return _keyBindings.Values.ToList();
		}

		public List<KeybindSetting> GetWorkshopKeybinds()
		{
			List<EKeybinding> allowedKeybinds = new List<EKeybinding>
			{
				EKeybinding.ReplaceDronePart,
				EKeybinding.CopyDronePart,
				EKeybinding.PasteDronePart,
				EKeybinding.DuplicateDronePart,
				EKeybinding.MultiSelect,
				EKeybinding.Undo,
				EKeybinding.Redo,
				EKeybinding.DeleteDronePart,
				EKeybinding.FlipDronePartHorizontal,
				EKeybinding.FlipDronePartVertical,
				EKeybinding.RotateDronePartLeft,
				EKeybinding.RotateDronePartRight,
				EKeybinding.HideSkins,
				EKeybinding.DisableAudioParts,
				EKeybinding.HideUi,
				EKeybinding.CaptureGif,
				EKeybinding.CaptureScreenshot
			};
			return _keyBindings.Values.Where((KeybindSetting k) => allowedKeybinds.Contains(k.Binding)).ToList();
		}

		protected void Init()
		{
			_keyBindings = new Dictionary<EKeybinding, KeybindSetting>();
			SetBinding(EKeybinding.ReplaceDronePart, KeyCode.LeftAlt, KeyCode.None, false, false);
			SetBinding(EKeybinding.CopyDronePart, KeyCode.C, KeyCode.None, true, false);
			SetBinding(EKeybinding.PasteDronePart, KeyCode.V, KeyCode.None, true, false);
			SetBinding(EKeybinding.DuplicateDronePart, KeyCode.D, KeyCode.None, true, false);
			SetBinding(EKeybinding.Undo, KeyCode.Z, KeyCode.None, true, false);
			SetBinding(EKeybinding.Redo, KeyCode.Y, KeyCode.None, true, false);
			SetBinding(EKeybinding.DeleteDronePart, KeyCode.Delete, KeyCode.Backspace, false, false);
			SetBinding(EKeybinding.FlipDronePartHorizontal, KeyCode.G, KeyCode.None, false, false);
			SetBinding(EKeybinding.FlipDronePartVertical, KeyCode.F, KeyCode.None, false, false);
			SetBinding(EKeybinding.RotateDronePartLeft, KeyCode.Comma, KeyCode.None, false, false);
			SetBinding(EKeybinding.RotateDronePartRight, KeyCode.Period, KeyCode.None, false, false);
			SetBinding(EKeybinding.HideSkins, KeyCode.F6, KeyCode.None, false, false);
			SetBinding(EKeybinding.DisableAudioParts, KeyCode.F10, KeyCode.None, false, false);
			SetBinding(EKeybinding.HideUi, KeyCode.F7, KeyCode.None, false, false);
			SetBinding(EKeybinding.CaptureScreenshot, KeyCode.F8, KeyCode.None, false, false);
			SetBinding(EKeybinding.CaptureGif, KeyCode.F9, KeyCode.None, false, false);
			SetBinding(EKeybinding.CameraModeAuto, KeyCode.Q, KeyCode.None, false, false);
			SetBinding(EKeybinding.CameraModePlayer1, KeyCode.W, KeyCode.None, false, false);
			SetBinding(EKeybinding.CameraModePlayer2, KeyCode.E, KeyCode.None, false, false);
			SetBinding(EKeybinding.CameraModeFree, KeyCode.R, KeyCode.None, false, false);
			SetBinding(EKeybinding.DefaultThrusterForward, KeyCode.W, KeyCode.None, false, false);
			SetBinding(EKeybinding.DefaultThrusterRight, KeyCode.D, KeyCode.None, false, false);
			SetBinding(EKeybinding.DefaultThrusterLeft, KeyCode.A, KeyCode.None, false, false);
			SetBinding(EKeybinding.DefaultShootButton, KeyCode.Mouse0, KeyCode.None, false, false);
			SetBinding(EKeybinding.SecondaryShootButton, KeyCode.Mouse1, KeyCode.None, false, false);
			SetBinding(EKeybinding.HingeRotationLeft, KeyCode.Q, KeyCode.None, false, false);
			SetBinding(EKeybinding.HingeRotationRight, KeyCode.E, KeyCode.None, false, false);
			SetBinding(EKeybinding.MultiSelect, KeyCode.LeftControl, KeyCode.RightControl, false, false);
		}

		public bool GetKey(EKeybinding binding)
		{
			return _keyBindings[binding].GetKey();
		}

		public bool GetKeyDown(EKeybinding binding)
		{
			return _keyBindings[binding].GetKeyDown();
		}

		public void SetBinding(EKeybinding binding, KeyCode primary, KeyCode secondary, bool hasModPrimary, bool hasModSecondary)
		{
			if (_keyBindings.ContainsKey(binding))
			{
				_keyBindings[binding].PrimaryKey = primary;
				_keyBindings[binding].SecondaryKey = secondary;
				_keyBindings[binding].ModPrimary = hasModPrimary;
				_keyBindings[binding].ModSecondary = hasModSecondary;
			}
			else
			{
				_keyBindings.Add(binding, new KeybindSetting(binding, primary, hasModPrimary, secondary, hasModSecondary));
			}
		}

		public void ResetToDefault()
		{
			Init();
		}

		public void Save()
		{
			if (BaseSingleton<KeybindManager>.Instance == null || string.IsNullOrEmpty(Filename))
			{
				return;
			}
			using (FileStream stream = new FileStream(Path.Combine(SaveManager.GlobalFilePath, BaseSingleton<KeybindManager>.Instance.Filename), FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					SerializationHelper.Serialize(writer, _keyBindings);
				}
			}
		}

		public void Load()
		{
			if (BaseSingleton<KeybindManager>.Instance == null || string.IsNullOrEmpty(Filename))
			{
				return;
			}
			string path = Path.Combine(SaveManager.GlobalFilePath, BaseSingleton<KeybindManager>.Instance.Filename);
			try
			{
				if (!File.Exists(path))
				{
					return;
				}
				using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						Dictionary<EKeybinding, KeybindSetting> dictionary = new Dictionary<EKeybinding, KeybindSetting>();
						SerializationHelper.Deserialize(reader, dictionary);
						foreach (KeyValuePair<EKeybinding, KeybindSetting> item in dictionary)
						{
							if (_keyBindings.ContainsKey(item.Key))
							{
								_keyBindings[item.Key] = item.Value;
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public KeyCode GetKeyCode(EKeybinding key)
		{
			if (_keyBindings.ContainsKey(key))
			{
				return _keyBindings[key].PrimaryKey;
			}
			return KeyCode.None;
		}
	}
}
