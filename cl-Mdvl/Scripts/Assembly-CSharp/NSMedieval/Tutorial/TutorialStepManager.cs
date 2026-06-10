using System.Collections;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class TutorialStepManager : MonoSingleton<TutorialStepManager>
	{
		private const float TickInterval = 0.3f;

		private float tickValue;

		private int currentIndex;

		private TutorialStep currentStep;

		private TutorialPanelView tutorialPanelView;

		private TutorialInputManager tutorialInputManager;

		public TutorialInputManager TutorialInputManager => tutorialInputManager;

		public int CurrentIndex => currentIndex;

		public int TotalSteps => MonoSingleton<TutorialManager>.Instance.TutorialSteps.Count;

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (tutorialPanelView != null)
			{
				tutorialPanelView.PanelHideReadyEvent -= OnNextStep;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= OnTick;
			}
		}

		private void Start()
		{
			if (TutorialManager.IsTutorialActive)
			{
				tutorialInputManager = new TutorialInputManager();
				MonoSingleton<UIController>.Instance.GameStartedEvent += OnGameplayStart;
			}
		}

		private void OnGameplayStart(bool started)
		{
			if (!started)
			{
				return;
			}
			MonoSingleton<UIController>.Instance.GameStartedEvent -= OnGameplayStart;
			tutorialPanelView = Object.FindObjectOfType<TutorialPanelView>();
			if (tutorialPanelView == null)
			{
				Log.Error("TutorialPanelView not found!", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialStepManager.cs");
				return;
			}
			List<TutorialStep> tutorialSteps = MonoSingleton<TutorialManager>.Instance.TutorialSteps;
			if (tutorialSteps != null && tutorialSteps.Count == 0)
			{
				Log.Error("TutorialSteps not found!", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialStepManager.cs");
				return;
			}
			tutorialPanelView.PanelHideReadyEvent += OnNextStep;
			tutorialPanelView.PanelShowReadyEvent += OnNextStepReady;
			MonoSingleton<GlobalKeybindingManager>.Instance.BlockEscapeKey(block: true);
			MonoSingleton<InputManager>.Instance.SetInputEnabled(value: false);
			MonoSingleton<UIShowManager>.Instance.HideAll();
			foreach (HumanoidInstance item in WorkerManager.WorkersEverywhere)
			{
				item.Info.SetFirstName(Repository<NameRepository, Names>.Instance.GetFirstName());
				item.Info.SetLastName(Repository<NameRepository, Names>.Instance.GetLastName());
				MonoSingleton<WorkerController>.Instance.WorkerNameChanged(item);
			}
			foreach (CreatureBase creature in MonoSingleton<CreatureManager>.Instance.Creatures)
			{
				if (creature is AnimalInstance animalInstance)
				{
					animalInstance.SetName(string.Empty);
				}
			}
			StartCoroutine(DelayedStartCoroutine());
		}

		private IEnumerator DelayedStartCoroutine()
		{
			yield return new WaitForSeconds(1f);
			float zoomSpeed = 0.005f;
			float zoomTime = 1f;
			while (zoomTime > 0f)
			{
				MonoSingleton<RtsCamera>.Instance.SetDesiredRotation(MonoSingleton<RtsCamera>.Instance.DesiredRotation + 0f / (float)Screen.width * MonoSingleton<RtsCamera>.Instance.Settings.MouseRotateSpeed);
				MonoSingleton<RtsCamera>.Instance.SetDesiredHeight(MonoSingleton<RtsCamera>.Instance.DesiredHeight - zoomSpeed * MonoSingleton<RtsCamera>.Instance.Settings.MouseZoomSpeed * MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraSensitivity);
				MonoSingleton<RtsCamera>.Instance.UpdateTilt((0f - 0f / (float)Screen.width) * MonoSingleton<RtsCamera>.Instance.Settings.MouseTiltSpeed);
				zoomTime -= Time.deltaTime;
				yield return null;
			}
			yield return new WaitForSeconds(0.5f);
			DelayedStart();
		}

		private void DelayedStart()
		{
			OnNextStep();
			MonoSingleton<SceneController>.Instance.Tick += OnTick;
		}

		private void OnTick(float deltaTime)
		{
			tickValue += 0.01f;
			if (!(tickValue < 0.3f))
			{
				tickValue = 0f;
				currentStep?.Tick();
			}
		}

		private void OnNextStep()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\TutorialStepManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Next step: ");
				messageBuilder.AppendFormatted(currentIndex);
			}
			Log.Debug(messageBuilder);
			if (currentIndex >= MonoSingleton<TutorialManager>.Instance.TutorialSteps.Count)
			{
				MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadHomeScene();
				return;
			}
			currentStep = MonoSingleton<TutorialManager>.Instance.TutorialSteps[currentIndex];
			tutorialPanelView.UpdateDataAndShow(currentStep);
			currentIndex++;
		}

		private void OnNextStepReady()
		{
			currentStep.BeginStep();
		}
	}
}
