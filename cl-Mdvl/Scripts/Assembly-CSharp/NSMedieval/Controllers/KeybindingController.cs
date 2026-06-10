using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using UnityEngine;

namespace NSMedieval.Controllers
{
	public class KeybindingController : MonoSingleton<KeybindingController>
	{
		private DefaultPlayerControls defaultControls;

		private Keybinding[] keybindingCached;

		public Keybinding[] Keybindings { get; private set; }

		public KeyCode KeybindingCancelKey { get; private set; }

		public HashSet<KeyCode> RestrictedKeys { get; private set; }

		public event Action KeybindingsUpdatedEvent;

		private void Start()
		{
			Keybindings = GetClone(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.Keybindings);
			defaultControls = Repository<DefaultPlayerControlsData, DefaultPlayerControls>.Instance.GetData<DefaultPlayerControls>();
			KeybindingCancelKey = defaultControls.KeybindingCancelKey;
			RestrictedKeys = new HashSet<KeyCode>(defaultControls.RestrictedKeys);
			InitializeData();
		}

		public void SaveKeybindings()
		{
			keybindingCached = GetClone(Keybindings);
			MonoSingleton<SettingsController>.Instance.SaveKeybindings(Keybindings);
		}

		public void ReloadDefaultKeybindings()
		{
			Keybindings = GetClone(defaultControls.Keybindings);
			this.KeybindingsUpdatedEvent?.Invoke();
		}

		public void CancelAllChanges()
		{
			Keybindings = GetClone(keybindingCached);
		}

		private void InitializeData()
		{
			List<Keybinding> list = new List<Keybinding>();
			bool flag = false;
			Keybinding[] keybindings = defaultControls.Keybindings;
			foreach (Keybinding defaultKeybinding in keybindings)
			{
				Keybinding keybinding = Keybindings.FirstOrDefault((Keybinding kb) => kb.KeyInputEvent == defaultKeybinding.KeyInputEvent);
				if (keybinding != null)
				{
					list.Add(keybinding.Clone());
					continue;
				}
				flag = true;
				KeyCode primaryKey = defaultKeybinding.PrimaryKey;
				if (Keybindings.Any((Keybinding kb) => kb.PrimaryKey == defaultKeybinding.PrimaryKey))
				{
					primaryKey = KeyCode.None;
				}
				KeyCode alternativeKey = defaultKeybinding.AlternativeKey;
				if (Keybindings.Any((Keybinding kb) => kb.AlternativeKey == defaultKeybinding.AlternativeKey))
				{
					alternativeKey = KeyCode.None;
				}
				list.Add(new Keybinding(defaultKeybinding.KeyInputEvent, primaryKey, alternativeKey, defaultKeybinding.Group));
			}
			Keybindings = list.ToArray();
			keybindingCached = list.ToArray();
			if (flag)
			{
				SaveKeybindings();
			}
		}

		private Keybinding[] GetClone(IEnumerable<Keybinding> original)
		{
			return original.Select((Keybinding defaultKeybinding) => defaultKeybinding.Clone()).ToArray();
		}
	}
}
