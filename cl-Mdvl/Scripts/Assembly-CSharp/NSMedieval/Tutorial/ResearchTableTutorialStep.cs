using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Managers.Selection;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class ResearchTableTutorialStep : TutorialStep
	{
		private const string BlueprintName = "basic_research_table";

		protected Vec3Int ResearchTableAreaStart => new Vec3Int(102, 15, 95);

		protected Vec3Int ResearchTableAreaEnd => new Vec3Int(106, 15, 96);

		public ResearchTableTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_production"),
				new TutorialStepTask("tut_select_research_table"),
				new TutorialStepTask("tut_place_research_table"),
				new TutorialStepTask("tut_wait_to_build")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: false);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
			MonoSingleton<UIShowManager>.Instance.ShowConstruction();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Production }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Production));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructProduction(allow: true);
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<SelectionManager>.Instance.DeselectTool();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructProduction(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
		}

		public override void Tick()
		{
			base.Tick();
			CheckAllBuildingsFinished();
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Production)
			{
				CompleteTask(0);
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "basic_research_table" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("basic_research_table"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "basic_research_table" }, interactable: true);
			ShowMarkersAndPointers(ResearchTableAreaStart, ResearchTableAreaEnd, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "basic_research_table")
			{
				return;
			}
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(11, 2, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted("basic_research_table");
				messageBuilder.AppendLiteral(" placed at ");
				messageBuilder.AppendFormatted(buildingInstance.Positions.FirstOrDefault());
			}
			Log.Trace(messageBuilder);
			foreach (Vec3Int position in buildingInstance.Positions)
			{
				if (!IsInsideAllowedArea(position, ResearchTableAreaStart, ResearchTableAreaEnd))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(position.ToString());
						messageBuilder.AppendLiteral(" Outside Allowed");
					}
					Log.Trace(messageBuilder);
					ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
					});
					return;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(position.ToString());
					messageBuilder.AppendLiteral(" Inside Allowed");
				}
				Log.Trace(messageBuilder);
			}
			MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
			{
				DeselectAllDelayed();
				LockAllBuildingTypes();
				HideMarkersAndPointers(ResearchTableAreaStart, ResearchTableAreaEnd);
				CompleteTask(2);
			});
		}

		private void CheckAllBuildingsFinished()
		{
			if (Tasks[3].IsComplete)
			{
				return;
			}
			Log.Trace("Checking Campfire finished", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
			float num = 0f;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			foreach (Dictionary<BaseBuildingInstance, BaseBuildingViewComponent> value in base.BuildingsManagerMain.TypeInstanceView.Values)
			{
				foreach (BaseBuildingInstance key in value.Keys)
				{
					if (key == null || key.BlueprintId != "basic_research_table")
					{
						continue;
					}
					if (key.ConstructionPhase != ConstructionPhase.Finished)
					{
						num = ((float)key.Blueprint.BuildTime - key.RemainingTime) / (float)key.Blueprint.BuildTime;
						messageBuilder = new FVLogTraceInterpolationHandler(37, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Building ");
							messageBuilder.AppendFormatted(key.RemainingTime);
							messageBuilder.AppendLiteral(" / ");
							messageBuilder.AppendFormatted(key.Blueprint.BuildTime);
							messageBuilder.AppendLiteral(" not finished, progress: ");
							messageBuilder.AppendFormatted(num);
						}
						Log.Trace(messageBuilder);
					}
					else
					{
						num = 1f;
					}
				}
			}
			messageBuilder = new FVLogTraceInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ResearchTableTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Complete ");
				messageBuilder.AppendFormatted(num);
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(3, num);
		}
	}
}
