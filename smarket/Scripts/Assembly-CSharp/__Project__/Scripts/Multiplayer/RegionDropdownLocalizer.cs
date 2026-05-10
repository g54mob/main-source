using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace __Project__.Scripts.Multiplayer
{
	public class RegionDropdownLocalizer : NoktaSingleton<RegionDropdownLocalizer>
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private LocalizedString asiaString;

		[SerializeField]
		private LocalizedString auString;

		[SerializeField]
		private LocalizedString caeString;

		[SerializeField]
		private LocalizedString euString;

		[SerializeField]
		private LocalizedString hkString;

		[SerializeField]
		private LocalizedString inString;

		[SerializeField]
		private LocalizedString jpString;

		[SerializeField]
		private LocalizedString zaString;

		[SerializeField]
		private LocalizedString saString;

		[SerializeField]
		private LocalizedString krString;

		[SerializeField]
		private LocalizedString trString;

		[SerializeField]
		private LocalizedString uaeString;

		[SerializeField]
		private LocalizedString usString;

		[SerializeField]
		private LocalizedString uswString;

		[SerializeField]
		private LocalizedString usscString;

		public void SetDropdown(RegionInfo[] names)
		{
		}

		private LocalizedString GetLocalizedString(RegionInfo regionInfo)
		{
			return null;
		}

		private void AddLocalizedOption(LocalizedString localizedString)
		{
		}
	}
}
