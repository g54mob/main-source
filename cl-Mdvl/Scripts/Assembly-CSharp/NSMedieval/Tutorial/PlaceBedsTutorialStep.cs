using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Manager;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class PlaceBedsTutorialStep : TutorialStep
	{
		private const int TotalSleepSpotsCount = 3;

		private const string HaySleepingSpot = "hay_sleeping_spot";

		private const string RoofButtonName = "RoofsButton";

		protected Vec3Int BedsAreaStart => new Vec3Int(104, 15, 92);

		protected Vec3Int BedsAreaEnd => new Vec3Int(106, 15, 94);

		public PlaceBedsTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_hide_roofs"),
				new TutorialStepTask("tut_open_build_furniture"),
				new TutorialStepTask("tut_select_build_bed"),
				new TutorialStepTask("tut_place_beds", new object[1] { 3 }),
				new TutorialStepTask("tut_wait_to_build")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<GameSpeedManager>.Instance.SetSpeedNormal();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowTimeControls(allow: true);
			MonoSingleton<UIShowManager>.Instance.ShowViewControls();
			MonoSingleton<UIController>.Instance.LeftPanelView.SetViewControlsInteractable(new HashSet<string> { "RoofsButton" }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowRoofsControls(allow: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.LeftPanelView.GetButtonRect("RoofsButton"));
			base.ActiveVillageMap.RoofComponentManager.SetRoofsVisibleEvent += OnRoofsVisibilityChange;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			DeselectAllDelayed();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructFurniture(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
		}

		public override void Tick()
		{
			base.Tick();
			CheckBuiltBeds();
		}

		private void OnRoofsVisibilityChange(bool visible)
		{
			if (!visible)
			{
				CompleteTask(0);
				base.ActiveVillageMap.RoofComponentManager.SetRoofsVisibleEvent -= OnRoofsVisibilityChange;
				MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
				MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
				MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
				MonoSingleton<UIShowManager>.Instance.ShowConstruction();
				MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Furniture }, interactable: true);
				MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Furniture));
				MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructFurniture(allow: true);
			}
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Furniture)
			{
				CompleteTask(1);
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "hay_sleeping_spot" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("hay_sleeping_spot"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(2);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "hay_sleeping_spot" }, interactable: true);
			ShowMarkersAndPointers(BedsAreaStart, BedsAreaEnd, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			if (Tasks[3].IsComplete)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
				});
			}
			else
			{
				if (buildingInstance.BlueprintId != "hay_sleeping_spot")
				{
					return;
				}
				bool flag = true;
				foreach (Vec3Int position in buildingInstance.Positions)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder;
					if (!IsInsideAllowedArea(position, BedsAreaStart, BedsAreaEnd))
					{
						messageBuilder = new FVLogTraceInterpolationHandler(31, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
						if (isEnabled)
						{
							messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
							messageBuilder.AppendLiteral(" (");
							messageBuilder.AppendFormatted(position.x);
							messageBuilder.AppendLiteral(", ");
							messageBuilder.AppendFormatted(position.y);
							messageBuilder.AppendLiteral(", ");
							messageBuilder.AppendFormatted(position.z);
							messageBuilder.AppendLiteral(") is OUTSIDE allowed area");
						}
						Log.Trace(messageBuilder);
						flag = false;
						break;
					}
					messageBuilder = new FVLogTraceInterpolationHandler(30, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(buildingInstance.BlueprintId);
						messageBuilder.AppendLiteral(" (");
						messageBuilder.AppendFormatted(position.x);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(position.y);
						messageBuilder.AppendLiteral(", ");
						messageBuilder.AppendFormatted(position.z);
						messageBuilder.AppendLiteral(") is INSIDE allowed area");
					}
					Log.Trace(messageBuilder);
				}
				if (flag)
				{
					CheckPlacedBlueprints();
					return;
				}
				ShowOptimizedBlackBarMessage("tutorial_wrong_construction_position");
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
				});
			}
		}

		private void CheckPlacedBlueprints()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Bed];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			HashSet<BaseBuildingInstance> hashSet = new HashSet<BaseBuildingInstance>();
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value == null)
				{
					continue;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(27, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Trying to add ");
					messageBuilder.AppendFormatted(item.Value.GetHashCode());
					messageBuilder.AppendLiteral(" contains(");
					messageBuilder.AppendFormatted(hashSet.Count);
					messageBuilder.AppendLiteral("): ");
					messageBuilder.AppendFormatted(hashSet.Contains(item.Value));
				}
				Log.Trace(messageBuilder);
				if (hashSet.Contains(item.Value))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(item.Key.ToString());
						messageBuilder.AppendLiteral(" has already been placed");
					}
					Log.Trace(messageBuilder);
				}
				else if (IsInsideAllowedArea(item.Key, BedsAreaStart, BedsAreaEnd))
				{
					hashSet.Add(item.Value);
				}
			}
			float num = hashSet.Count;
			float num2 = num / 3f;
			messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Blueprints: ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(num2, "P1");
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(3, num2);
			if (Tasks[3].IsComplete)
			{
				HideMarkersAndPointers(BedsAreaStart, BedsAreaEnd);
				DeselectAllDelayed();
				LockAllBuildingTypes();
				MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
			}
		}

		private void CheckBuiltBeds()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Bed];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			HashSet<BaseBuildingInstance> hashSet = new HashSet<BaseBuildingInstance>();
			bool isEnabled;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value == null)
				{
					continue;
				}
				if (hashSet.Contains(item.Value))
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(item.Key.ToString());
						messageBuilder.AppendLiteral(" has already been placed");
					}
					Log.Trace(messageBuilder);
				}
				else if (IsInsideAllowedArea(item.Key, BedsAreaStart, BedsAreaEnd) && item.Value.ConstructionPhase.Equals(ConstructionPhase.Finished))
				{
					hashSet.Add(item.Value);
				}
			}
			float num = hashSet.Count;
			float num2 = num / 3f;
			if (num2 > 0f)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Finished: ");
					messageBuilder.AppendFormatted(num);
					messageBuilder.AppendLiteral(": ");
					messageBuilder.AppendFormatted(num2, "P1");
				}
				Log.Trace(messageBuilder);
			}
			UpdateTaskCompletion(4, num2);
			if (num2 >= 1f)
			{
				Log.Debug("Step Finished", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\PlaceBedsTutorialStep.cs");
			}
		}
	}
}
