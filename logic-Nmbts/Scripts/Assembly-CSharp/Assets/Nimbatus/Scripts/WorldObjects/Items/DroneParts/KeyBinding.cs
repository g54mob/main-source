using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	[Serializable]
	public class KeyBinding
	{
		private static readonly Dictionary<string, int> UsedStrings = new Dictionary<string, int>();

		public string DisplayName;

		public string Name;

		public KeyCode KeyCode;

		public string StringCode = "";

		public bool HasBeenAssigned;

		public bool DisplayNotAssignedWarning;

		public KeyBinding()
		{
		}

		public static void ResetUsedTags()
		{
			UsedStrings.Clear();
		}

		public KeyBinding(string name, KeyCode key, bool required = true)
		{
			Name = name;
			DisplayName = LocalizationManager.GetTermTranslation("DroneKeyBindings/" + name);
			if (DisplayName.IsNullOrWhitespace())
			{
				DisplayName = name;
			}
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null)
			{
				KeyCode = key;
			}
			else
			{
				KeyCode = KeyCode.None;
			}
			DisplayNotAssignedWarning = required;
		}

		public void SetKey(KeyCode pressedKey)
		{
			KeyCode = pressedKey;
		}

		public static List<string> GetUsedStrings()
		{
			return (from k in UsedStrings
				where k.Value > 0
				select k.Key).ToList();
		}

		public void RemoveFromUsedTags()
		{
			if (UsedStrings.ContainsKey(StringCode))
			{
				UsedStrings[StringCode]--;
			}
		}

		public void SetKey(string newStringCode)
		{
			if (!UsedStrings.ContainsKey(newStringCode))
			{
				UsedStrings.Add(newStringCode, 1);
			}
			else
			{
				UsedStrings[newStringCode]++;
			}
			if (UsedStrings.ContainsKey(StringCode))
			{
				UsedStrings[StringCode]--;
			}
			StringCode = newStringCode;
		}

		public bool IsPressed(EventKeyHub hub)
		{
			if (KeyCode != KeyCode.None && hub.GetKey(KeyCode))
			{
				return true;
			}
			if (!string.IsNullOrEmpty(StringCode))
			{
				return hub.GetKey(StringCode);
			}
			return false;
		}

		public void Load(KeyBindingData data)
		{
			Name = data.Name;
			KeyCode = data.Key;
			HasBeenAssigned = data.HasBeenAssigned;
			string tag = data.Tag;
			SetKey(tag);
		}

		public KeyBindingData GetSaveData()
		{
			return new KeyBindingData
			{
				Name = Name,
				Key = KeyCode,
				HasBeenAssigned = HasBeenAssigned,
				Tag = StringCode
			};
		}
	}
}
