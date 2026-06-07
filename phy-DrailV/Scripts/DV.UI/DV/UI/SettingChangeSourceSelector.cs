using System.Linq;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(Selector))]
	public class SettingChangeSourceSelector : SettingChangeSource<int>
	{
		public bool localizeValues;

		protected override void Awake()
		{
			base.Awake();
			GetComponent<Selector>().SelectionChanged += OnSelectionChanged;
		}

		private void OnSelectionChanged(IClickable clickable, int selectedIndex)
		{
			UpdateAndFireEvent(selectedIndex);
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				Selector component = GetComponent<Selector>();
				string[] localizationKeysForSelector = provider.GetLocalizationKeysForSelector(PreferencesName);
				component.LocalizedValues = localizeValues;
				component.SetValues(localizationKeysForSelector.ToList());
				component.SetSelectedIndex(GetLatestValueFromProvider());
				base.OnResetOrApplied();
			}
		}
	}
}
