using KitchenMods;
using Platforms;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class DisplayVersion : MonoBehaviour
	{
		public string BaseText;

		public TextMeshPro Text;

		private bool SpeedrunModeInUse;

		private string GetBaseText()
		{
			if (PlatformSettings.IsDemoMode)
			{
				BaseText = "PlateUp! " + Application.version + " (DEMO)";
			}
			else
			{
				string text = "PlateUp! " + Application.version;
				int count = ModPreload.Mods.Count;
				if (count > 0)
				{
					BaseText = text + string.Format(" - {0} mod{1}", count, (count > 1) ? "s" : "");
				}
				else
				{
					BaseText = text;
				}
			}
			Text.text = BaseText;
			return BaseText;
		}

		private void Awake()
		{
			GetBaseText();
		}

		private void Update()
		{
			Preferences.TryGet<bool>(Pref.SpeedrunMode, out var value);
			if (SpeedrunModeInUse != value)
			{
				if (value)
				{
					Text.text = BaseText + " - Speedrun Mode";
				}
				else
				{
					Text.text = BaseText;
				}
			}
			SpeedrunModeInUse = value;
		}
	}
}
