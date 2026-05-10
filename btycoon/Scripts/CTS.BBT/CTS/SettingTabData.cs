using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/UI/Setting Tab")]
	public class SettingTabData : ScriptableStringKey
	{
		[field: SerializeField]
		public Sprite ToggleIcon { get; private set; }

		[field: SerializeField]
		public LocalizedString Title { get; private set; }

		[field: SerializeField]
		public List<SettingCreator> Settings { get; private set; }

		[field: SerializeField]
		public List<string> RestrictedCountry { get; private set; } = new List<string>();
	}
}
