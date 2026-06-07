using System;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Structure;
using Gh.Tk.UI;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public class ScenarioInfo3DUIView : MonoBehaviour
	{
		[SerializeField]
		private ScenarioStoryStartNode _scenario;

		[SerializeField]
		private TMP_Text _scenarioTitleText;

		[SerializeField]
		private TMP_Text _scenarioDescriptionText;

		[SerializeField]
		private SpriteRenderer _scenarioImage;

		[SerializeField]
		private TextBlock3DUIView _scenarioDescriptionTextBlock;

		[SerializeField]
		protected Button3DUIView _scenarioStartButton;

		public string tutorialSkipKey;

		[SerializeField]
		protected CheckBox3DUIView _skipTutorialCheckBox;

		[SerializeField]
		private GameObject _scenarioAvailableIcon;

		[SerializeField]
		private GameObject _scenarioCompletedIcon;

		[SerializeField]
		private string _scenarioId;

		[SerializeField]
		protected string _levelId;

		protected bool _showSetupDialog;

		private const string TEASER_FINISHED_STAT_KEY = "finished_teaser";

		private const string _tutorialStoryFlag = "gameTutorial1Complete";

		private const string _skipItemWorkshopTutorialFlag = "skipItemWorkshopTutorial";

		public bool IsFreeplayScenario => false;

		public static event EventHandler ScenarioSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected void ApplyScenarioData()
		{
		}

		private bool ShouldShowSetupDialog()
		{
			return false;
		}

		protected virtual void Start()
		{
		}

		private void OnProfileChanged(object sender, EventArgs<PlayerProfile> e)
		{
		}

		private void ResetTutorialCheckbox()
		{
		}

		public void Show(ScenarioStoryStartNode scenario)
		{
		}

		public void Show(string levelId, string scenarioId, string labelKey, string descriptionKey, bool showSetupDialog)
		{
		}

		private void UpdateScenarioIcon()
		{
		}

		protected void UpdateImage()
		{
		}

		protected virtual void UpdateDescription(string descriptionKey)
		{
		}

		private void StartButtonClicked()
		{
		}

		private void ShowTavernSettings()
		{
		}

		protected virtual void StartScenario()
		{
		}

		protected void UpdateTutorialFlag()
		{
		}

		public void Hide()
		{
		}
	}
}
