using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Research;
using NSMedieval.UI;

namespace NSMedieval.Tutorial
{
	public class ResearchTutorialStep : TutorialStep
	{
		private const string ResearchButtonName = "WorkerResearchButton";

		private const string ResearchPanelName = "ResearchPanelManager";

		private const string ResearchBlueprintId = "architecture_lvl1";

		private ResearchPanelManager researchPanelManager;

		public ResearchTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_research"),
				new TutorialStepTask("tut_select_architecture"),
				new TutorialStepTask("tut_research_unlock")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIShowManager>.Instance.ShowTopLeftButtons();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowResearchControls(allow: true);
			MonoSingleton<UIController>.Instance.LeftPanelView.SetTopLeftButtonsInteractable(new HashSet<string> { "WorkerResearchButton" }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.LeftPanelView.GetButtonRect("WorkerResearchButton"));
			MonoSingleton<SceneUIManager>.Instance.PanelToggleEvent += OnPanelToggle;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			DeselectAllDelayed();
			researchPanelManager.EnableScrolling(enable: true);
			researchPanelManager.Hide();
			researchPanelManager = null;
			MonoSingleton<UIController>.Instance.LeftPanelView.SetTopLeftButtonsInteractable(new HashSet<string>(), interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowResearchControls(allow: false);
			MonoSingleton<SceneUIManager>.Instance.PanelToggleEvent -= OnPanelToggle;
		}

		private void OnPanelToggle(string panelName, bool isOpen)
		{
			if (!(panelName != "ResearchPanelManager"))
			{
				Log.Trace("Jobs Panel ResearchPanelManager", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTutorialStep.cs");
				if (isOpen)
				{
					OnPanelOpen(panelName);
				}
				else
				{
					OnPanelClose();
				}
			}
		}

		private void OnPanelOpen(string panelName)
		{
			if (this.researchPanelManager == null)
			{
				PanelBase panelBase = MonoSingleton<SceneUIManager>.Instance.FindPanel("ResearchPanelManager");
				if (panelBase == null || !(panelBase is ResearchPanelManager researchPanelManager))
				{
					Log.Trace("Jobs Panel ResearchPanelManager not open", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTutorialStep.cs");
					return;
				}
				this.researchPanelManager = researchPanelManager;
				this.researchPanelManager.EnableScrolling(enable: false);
				CompleteTask(0);
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(OnResearchPanelOpen);
		}

		private void OnPanelClose()
		{
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		private void OnResearchPanelOpen()
		{
			Log.Trace("Research Panel Opened", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTutorialStep.cs");
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<ResearchManager>.Instance.GetArchitectureRect());
			MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedEvent += OnNodeSelected;
		}

		private void OnNodeSelected(ResearchNodeInstance obj)
		{
			if (!(obj.Blueprint.GetID() != "architecture_lvl1"))
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Node: ");
					messageBuilder.AppendFormatted(obj.Blueprint.GetID());
					messageBuilder.AppendLiteral(" selected");
				}
				Log.Trace(messageBuilder);
				CompleteTask(1);
				researchPanelManager.EnableScrolling(enable: true);
				MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(researchPanelManager.GetUnlockRect());
				MonoSingleton<ResearchUIController>.Instance.ResearchNodeSelectedEvent -= OnNodeSelected;
				MonoSingleton<ResearchController>.Instance.NodeActivatedEvent += OnResearchActivated;
			}
		}

		private void OnResearchActivated()
		{
			Log.Trace("Activated", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTutorialStep.cs");
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				UpdateTaskCompletion(2, 1f);
			});
		}
	}
}
