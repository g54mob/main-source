using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class SettingChangeSourceLanguage : SettingChangeSource<string>
	{
		[NullCheck]
		public LanguageSelectorGridView gridView;

		public override string PreferencesName => "Language";

		private bool IsIndexValid
		{
			get
			{
				if (gridView.SelectedModelIndex >= 0)
				{
					return gridView.SelectedModelIndex < gridView.Model.Count;
				}
				return false;
			}
		}

		private string SelectedLanguage
		{
			get
			{
				if (!IsIndexValid)
				{
					return "";
				}
				return gridView.Model[gridView.SelectedModelIndex].languageName;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			gridView.SelectedIndexChanged += OnSelectedIndexChanged;
		}

		private void OnSelectedIndexChanged(AGridView<LanguageItem> _)
		{
			if (IsIndexValid)
			{
				UpdateAndFireEvent(SelectedLanguage);
			}
		}

		protected override void OnResetOrApplied()
		{
			if (!base.gameObject.activeInHierarchy || gridView == null || gridView.Model == null)
			{
				return;
			}
			string latestValueFromProvider = GetLatestValueFromProvider();
			int num = -1;
			if (latestValueFromProvider != null)
			{
				for (int i = 0; i < gridView.Model.Count; i++)
				{
					if (gridView.Model[i].languageName.ToLower() == latestValueFromProvider.ToLower())
					{
						num = i;
						break;
					}
				}
			}
			if (num < 0)
			{
				Debug.LogWarning("Could not find language '" + latestValueFromProvider + "' in the grid view model");
			}
			gridView.SetSelected(num);
			base.OnResetOrApplied();
		}
	}
}
