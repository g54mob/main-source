using System.Collections.Generic;
using Data.UI.Controls;
using Presentation.UI.Menus.SettingsCategories.Controls;
using UnityEngine;

namespace Presentation.UI.Controls
{
	public class SettingsControlsPopulator : MonoBehaviour
	{
		[SerializeField]
		private SettingsRebindRuntimeInfo _rebindInfo;

		[SerializeField]
		private SettingsControlsSubtitle _rebindGroupPrefab;

		[SerializeField]
		private SettingsRebindActionUI _rebindActionPrefab;

		[SerializeField]
		private GameObject _spacerPrefab;

		[SerializeField]
		private Transform _resetButton;

		private readonly List<SettingsRebindActionUI> _settingsRebindActionUIs = new List<SettingsRebindActionUI>();

		private readonly List<(SettingsControlsSubtitle, SettingsRebindAction)> _subtitles = new List<(SettingsControlsSubtitle, SettingsRebindAction)>();

		public IEnumerable<SettingsRebindActionUI> SettingsRebindActionUIs => _settingsRebindActionUIs;

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		public void Populate()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			_rebindGroupPrefab.gameObject.SetActive(value: true);
			_rebindActionPrefab.gameObject.SetActive(value: true);
			_spacerPrefab.SetActive(value: true);
			SettingsRebindGroup settingsRebindGroup = null;
			SettingsRebindAction settingsRebindAction = null;
			foreach (SettingsRebindAction allRebindAction in _rebindInfo.AllRebindActions)
			{
				if (!allRebindAction.Data.IsHidden && allRebindAction != settingsRebindAction)
				{
					if (settingsRebindGroup != allRebindAction.Group)
					{
						SettingsControlsSubtitle settingsControlsSubtitle = Object.Instantiate(_rebindGroupPrefab, _rebindGroupPrefab.transform.parent);
						settingsControlsSubtitle.SetText(allRebindAction.Group.GetLocalizedName());
						_subtitles.Add((settingsControlsSubtitle, allRebindAction));
						settingsRebindGroup = allRebindAction.Group;
					}
					if (allRebindAction.Data.AddUISpaceAbove)
					{
						Object.Instantiate(_spacerPrefab, _spacerPrefab.transform.parent);
					}
					SettingsRebindActionUI settingsRebindActionUI = Object.Instantiate(_rebindActionPrefab, _rebindActionPrefab.transform.parent);
					settingsRebindAction = allRebindAction.SiblingRebindAction;
					settingsRebindActionUI.Initialize(allRebindAction, settingsRebindAction);
					_settingsRebindActionUIs.Add(settingsRebindActionUI);
				}
			}
			_spacerPrefab.SetActive(value: false);
			_rebindGroupPrefab.gameObject.SetActive(value: false);
			_rebindActionPrefab.gameObject.SetActive(value: false);
		}

		private void OnLanguageUpdate()
		{
			for (int i = 0; i < _subtitles.Count; i++)
			{
				_subtitles[i].Item1.SetText(_subtitles[i].Item2.Group.GetLocalizedName());
			}
		}
	}
}
