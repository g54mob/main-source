using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Resources;
using NSMedieval.Terrain;
using NSMedieval.Types;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class DiggingTutorialStep : TutorialStep
	{
		private readonly Vec3Int digPosition = new Vec3Int(89, 15, 102);

		private const string GroundDigMarkerPrefabName = "marker_dig";

		private const string SlopeDigMarkerPrefabName = "marker_dig_slopes";

		public DiggingTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_select_digging"),
				new TutorialStepTask("tut_place_dig_marker"),
				new TutorialStepTask("tut_wait_for_dig")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: false);
			TutorialStep.CameraJumpToDefault();
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType> { OrderType.Digging }, interactable: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.OrdersPanelView.GetCategoryTransform(OrderType.Digging));
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowDigOrder(allow: true);
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent += OnOrderAssigned;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleSelection(canSelect: true);
			MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
			MonoSingleton<ResourceCommonController>.Instance.CreateResourceEvent -= OnCreateResourceEvent;
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
		}

		private void OnOrderAssigned(OrderType orderType, AreaType areaType)
		{
			if (orderType == OrderType.Digging)
			{
				MonoSingleton<SelectionManager>.Instance.AssignOrderEvent -= OnOrderAssigned;
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				CompleteTask(0);
				MonoSingleton<TutorialViewManager>.Instance.ShowMarker(digPosition);
				MonoSingleton<ScreenPointerManager>.Instance.AddTarget(digPosition.ToVector3(), Vector3.up, hideIfTargetOnScreen: true);
				MonoSingleton<ResourceCommonController>.Instance.CreateResourceEvent += OnCreateResourceEvent;
			}
		}

		private void OnCreateResourceEvent(string modelId, Vector3 position, string prefabId)
		{
			if (prefabId != "marker_dig" && prefabId != "marker_dig_slopes")
			{
				return;
			}
			Vec3Int gridPosition = GridUtils.GetGridPosition(position);
			Vec3Int rhs = digPosition - new Vec3Int(0, 10, 0);
			if (gridPosition != rhs)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(23, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DiggingTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(" at wrong position ");
					messageBuilder.AppendFormatted(gridPosition);
					messageBuilder.AppendLiteral(" != ");
					messageBuilder.AppendFormatted(rhs);
				}
				Log.Debug(messageBuilder);
				if (prefabId == "marker_dig")
				{
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
					{
						MonoSingleton<DigMarkerResourceManager>.Instance.OnGroundDestroyedSingle(gridPosition - Vec3Int.up);
					});
					return;
				}
				if (prefabId == "marker_dig_slopes")
				{
					MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(delegate
					{
						MonoSingleton<DigMarkerResourceManager>.Instance.OnGroundDestroyedSingle(gridPosition - Vec3Int.up);
						MonoSingleton<SlopeManager>.Instance.CancelDigMarker(gridPosition - Vec3Int.up);
					});
					return;
				}
			}
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
			DeselectAllDelayed();
			MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(digPosition.ToVector3());
			CompleteTask(1);
			MonoSingleton<UIController>.Instance.OrdersPanelView.SetCategoriesInteractable(new HashSet<OrderType>(), interactable: true);
			MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent += OnGroundDestroyed;
		}

		private void OnGroundDestroyed(Vec3Int position)
		{
			Vec3Int lhs = position + new Vec3Int(0, 11, 0);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DiggingTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Ground destroyed at - ");
				messageBuilder.AppendFormatted(lhs);
				messageBuilder.AppendLiteral(" != ");
				messageBuilder.AppendFormatted(digPosition);
			}
			Log.Debug(messageBuilder);
			if (!(lhs != digPosition))
			{
				MonoSingleton<GroundController>.Instance.OnGroundDestroyedSingleEvent -= OnGroundDestroyed;
				CompleteTask(2);
			}
		}
	}
}
