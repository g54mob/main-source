using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Workshop
{
	public class UiPreferences : SerializableMonobehaviour<UiPreferences, UiPreferencesData>
	{
		[HideInInspector]
		public bool TagsEnabled { get; set; }

		[HideInInspector]
		public bool ShowKeyBindings { get; set; }

		[HideInInspector]
		public bool OverlapDetectionEnabled { get; set; }

		[HideInInspector]
		public bool ShowCenterOfMass { get; set; }

		[HideInInspector]
		public bool EnableWireless { get; set; }

		internal override string Filename
		{
			get
			{
				return "UiPreferences.xml";
			}
		}

		protected override void PreLoad()
		{
			base.PreLoad();
			TagsEnabled = false;
			ShowKeyBindings = true;
			OverlapDetectionEnabled = true;
			ShowCenterOfMass = false;
			EnableWireless = false;
		}

		protected override void LoadFromFile(UiPreferencesData data)
		{
			if (data != null)
			{
				TagsEnabled = data.TagsEnabled;
				OverlapDetectionEnabled = data.OverlapDetectionEnabled;
				ShowKeyBindings = data.ShowKeyBindings;
				ShowCenterOfMass = data.ShowCenterOfMass;
				EnableWireless = data.EnableWireless;
			}
		}

		protected override UiPreferencesData SaveToFile()
		{
			return new UiPreferencesData
			{
				TagsEnabled = TagsEnabled,
				OverlapDetectionEnabled = OverlapDetectionEnabled,
				ShowKeyBindings = ShowKeyBindings,
				ShowCenterOfMass = ShowCenterOfMass,
				EnableWireless = EnableWireless
			};
		}
	}
}
