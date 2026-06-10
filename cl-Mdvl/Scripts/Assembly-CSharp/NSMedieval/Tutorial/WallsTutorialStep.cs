using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class WallsTutorialStep : TutorialStep
	{
		private const int TotalWallsCount = 24;

		protected static Vec3Int[] StartPositions => new Vec3Int[4]
		{
			new Vec3Int(101, 15, 97),
			new Vec3Int(107, 15, 96),
			new Vec3Int(102, 15, 97),
			new Vec3Int(101, 15, 91)
		};

		protected static Vec3Int[] EndPositions => new Vec3Int[4]
		{
			new Vec3Int(101, 15, 92),
			new Vec3Int(107, 15, 91),
			new Vec3Int(107, 15, 97),
			new Vec3Int(106, 15, 91)
		};

		private Vec3Int Start => new Vec3Int(BasePositionRangeX.Min, 15, BasePositionRangeZ.Min);

		private Vec3Int End => new Vec3Int(BasePositionRangeX.Max, 15, BasePositionRangeZ.Max);

		public WallsTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_build_base"),
				new TutorialStepTask("tut_select_build_wall"),
				new TutorialStepTask("tut_drag_place_walls")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			ForcePause();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent += OnShowConstructionCategory;
			MonoSingleton<UIController>.Instance.ConstructionPanel.ClosePanelEvent += base.OnConstructionPanelClose;
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent += OnChangeBuildingToPlace;
			MonoSingleton<UIShowManager>.Instance.ShowConstruction();
			MonoSingleton<UIController>.Instance.ConstructionPanel.SetCategoriesInteractable(new HashSet<BuildingCategoryUI> { BuildingCategoryUI.Base }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.GetCategoryTransform(BuildingCategoryUI.Base));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: true);
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			DeselectAllDelayed();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.Hide();
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowConstructBase(allow: false);
			HideMarkersAndPointers(Start, End);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent -= OnBlueprintPlaced;
		}

		public override void Tick()
		{
			base.Tick();
			if (!IsComplete)
			{
				CheckPlacedBlueprints();
			}
		}

		private void OnShowConstructionCategory(BuildingCategoryUI category)
		{
			if (category == BuildingCategoryUI.Base)
			{
				CompleteTask(0);
				MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetCategoriesInteractable(new HashSet<string> { "wood_wall_element" }, interactable: true);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.GetSubcategoryTransform("wood_wall_element"));
				});
			}
		}

		private void OnChangeBuildingToPlace()
		{
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.ConstructionPanel.ShowCategoryEvent -= OnShowConstructionCategory;
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<UIController>.Instance.ConstructionPanel.ConstructionManager.SetSubCategoriesInteractable(new HashSet<string> { "wood_wall" }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowMarkers(StartPositions, EndPositions);
			ShowScreenPointerTarget(Start, End, Vector3.up, hideIfTargetOnscreen: true);
			MonoSingleton<ConstructionController>.Instance.ChangeBuildingTypeToPlaceEvent -= OnChangeBuildingToPlace;
			MonoSingleton<ConstructionController>.Instance.BlueprintPlacedEvent += OnBlueprintPlaced;
		}

		private void OnBlueprintPlaced(BaseBuildingInstance buildingInstance)
		{
			if (buildingInstance.BlueprintId != "wood_wall_element")
			{
				Log.Error("OnBlueprintPlaced called with invalid blueprint id", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\WallsTutorialStep.cs");
				return;
			}
			foreach (Vec3Int position in buildingInstance.Positions)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder;
				if (IsOutsideAllowedAreas(position))
				{
					messageBuilder = new FVLogTraceInterpolationHandler(16, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\WallsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(position.ToString());
						messageBuilder.AppendLiteral(" Outside Allowed");
					}
					Log.Trace(messageBuilder);
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("tutorial_wrong_construction_position"));
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						buildingInstance.Map.BuildingsManagerMain.DestroyBuilding(buildingInstance);
					});
					break;
				}
				messageBuilder = new FVLogTraceInterpolationHandler(15, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\WallsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(position.ToString());
					messageBuilder.AppendLiteral(" Inside Allowed");
				}
				Log.Trace(messageBuilder);
			}
		}

		private void CheckPlacedBlueprints()
		{
			Dictionary<Vec3Int, BaseBuildingInstance> dictionary = base.BuildingsManagerMain.TypePositionInstanceDictionary[BuildingType.Wall];
			if (dictionary == null || dictionary.Keys.Count == 0)
			{
				return;
			}
			float num = 0f;
			foreach (KeyValuePair<Vec3Int, BaseBuildingInstance> item in dictionary)
			{
				if (item.Value != null && item.Value.ConstructionPhase.Equals(ConstructionPhase.Blueprint) && !IsOutsideAllowedAreas(item.Key))
				{
					num += 1f;
				}
			}
			UpdateTaskCompletion(2, num / 24f);
			if (Tasks[2].IsComplete)
			{
				DeselectAllDelayed();
				LockAllBuildingTypes();
			}
		}

		protected bool IsOutsideAllowedAreas(Vec3Int position)
		{
			if (position.y != 5)
			{
				return true;
			}
			for (int i = 0; i < StartPositions.Length; i++)
			{
				Vec3Int vec3Int = StartPositions[i];
				Vec3Int vec3Int2 = EndPositions[i];
				int num = Mathf.Min(vec3Int.x, vec3Int2.x);
				int num2 = Mathf.Max(vec3Int.x, vec3Int2.x);
				int num3 = Mathf.Min(vec3Int.z, vec3Int2.z);
				int num4 = Mathf.Max(vec3Int.z, vec3Int2.z);
				if (position.x >= num && position.x <= num2 && position.z >= num3 && position.z <= num4)
				{
					return false;
				}
			}
			return true;
		}
	}
}
