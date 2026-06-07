using System;
using System.Linq;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(Selector))]
	public class SettingChangeSourceSelectorString : SettingChangeSource<string>
	{
		public bool localizeValues;

		private Selector selector;

		protected override void Awake()
		{
			base.Awake();
			selector = GetComponent<Selector>();
			selector.SelectionChanged += OnSelectionChanged;
		}

		private void OnSelectionChanged(IClickable clickable, int selectedIndex)
		{
			UpdateAndFireEvent(selector.GetValues()[selectedIndex]);
		}

		protected override void OnResetOrApplied()
		{
			if (base.gameObject.activeSelf)
			{
				string[] localizationKeysForSelector = provider.GetLocalizationKeysForSelector(PreferencesName);
				selector.LocalizedValues = localizeValues;
				selector.SetValues(localizationKeysForSelector.ToList());
				selector.SetSelectedIndex(Math.Max(0, Array.IndexOf(localizationKeysForSelector, GetLatestValueFromProvider())));
				base.OnResetOrApplied();
			}
		}
	}
}
