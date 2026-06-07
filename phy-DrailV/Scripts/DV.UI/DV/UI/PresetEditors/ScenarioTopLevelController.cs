using System;
using Cysharp.Threading.Tasks;
using DV.Scenarios.Common;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.PresetEditors
{
	[RequireComponent(typeof(UIMenuController))]
	public class ScenarioTopLevelController : AUIController
	{
		[NullCheck]
		public ScenarioEditorController scenarioEditor;

		[NullCheck]
		public TrainEditorController trainEditor;

		private UIMenuController menuController;

		private AScenarioProvider provider;

		public event Action<IScenario> BackRequested;

		public void SetData(AScenarioProvider provider, IScenario scenario)
		{
			this.provider = provider;
			scenarioEditor.SetData(provider, scenario);
		}

		protected override void Awake()
		{
			base.Awake();
			menuController = GetComponent<UIMenuController>();
			NullChecking.NullCheck(menuController, "menuController", this, "Awake");
		}

		private void OnEnable()
		{
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				scenarioEditor.TrainEditorRequested += OnTrainEditorRequested;
				scenarioEditor.BackRequested += OnBackFromScenarioEditorRequested;
				trainEditor.BackRequested += OnBackFromTrainEditorRequested;
			}
			else
			{
				scenarioEditor.TrainEditorRequested -= OnTrainEditorRequested;
				scenarioEditor.BackRequested -= OnBackFromScenarioEditorRequested;
				trainEditor.BackRequested -= OnBackFromTrainEditorRequested;
			}
		}

		private void OnBackFromScenarioEditorRequested(IScenario scenario)
		{
			this.BackRequested?.Invoke(scenario);
		}

		private void OnTrainEditorRequested(IScenario scenarioToEdit)
		{
			menuController.SwitchMenuTask(1).ContinueWith(delegate
			{
				trainEditor.SetData(provider, scenarioToEdit);
			}).Forget();
		}

		private void OnBackFromTrainEditorRequested(ITrain train)
		{
			menuController.SwitchMenuTask(0).ContinueWith(delegate
			{
				scenarioEditor.CurrentThing.Train = train;
				scenarioEditor.RefreshData();
			}).Forget();
		}
	}
}
