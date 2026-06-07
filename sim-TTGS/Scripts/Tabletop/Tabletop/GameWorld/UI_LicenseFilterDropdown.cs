using System;
using Simulator;
using TMPro;

namespace Tabletop.GameWorld
{
	public class UI_LicenseFilterDropdown : UI_FilterDropdown
	{
		protected override int GetFiltersCount()
		{
			return Enum.GetValues(typeof(ELicense)).Length - 1;
		}

		protected override void OnInstantiateFilterToggle(int index, NavToggle filterToggle)
		{
			TextMeshProUGUI componentInChildren = filterToggle.GetComponentInChildren<TextMeshProUGUI>();
			ELicense eLicense = (ELicense)index;
			componentInChildren.text = eLicense.ToString();
		}

		public bool IsLicenseActive(ELicense license)
		{
			return IsFilterActive((int)license);
		}
	}
}
