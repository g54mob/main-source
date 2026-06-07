using System;
using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TavernSetupSettingsDialog3DUIView : BaseDialog3DUIView, IPrefabProvider
	{
		[SerializeField]
		private Button3DUIView _startButton;

		[SerializeField]
		private TextMeshProI18n _titleText;

		private TavernSetupPage3DUIView[] _pages;

		[SerializeField]
		private Stars3DUIView _maxStarRating;

		[SerializeField]
		private TavernLayoutSelector3DUIView _tavernLayoutSelector;

		[SerializeField]
		private List<GameObject> _settingsPrefabs;

		public ScenarioSettings ScenarioSettings { get; set; }

		protected override void Awake()
		{
		}

		private void OnStartButtonClicked()
		{
		}

		private void PostLoadEvent(object sender, EventArgs eventArgs)
		{
		}

		private void CleanUpEvents()
		{
		}

		private void OnLoadAborted(object sender, EventArgs e)
		{
		}

		public GameObject GetPrefab(string prefabName)
		{
			return null;
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void OnScenarioChanged(object sender, EventArgs e)
		{
		}

		public void SetData(string title, ScenarioSettings settings)
		{
		}
	}
}
