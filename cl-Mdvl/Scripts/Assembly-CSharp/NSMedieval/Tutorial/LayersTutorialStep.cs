using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.UI;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class LayersTutorialStep : TutorialStep
	{
		private const string LayerUpButtonName = "LayerUpButton";

		private const string LayerDownButtonName = "LayerDownButton";

		private const float TargetLayer = 3f;

		private Transform cameraTarget;

		private Vec3Int MarkerStart => new Vec3Int(92, 9, 99);

		private Vec3Int MarkerEnd => new Vec3Int(88, 9, 102);

		public LayersTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_change_layer_down", new object[1] { 3f }),
				new TutorialStepTask("tut_change_layer_up", new object[1] { 8f })
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(5, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LayersTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pile ");
					messageBuilder.AppendFormatted(allPile.Key.BlueprintId);
				}
				Log.Trace(messageBuilder);
				if (allPile.Key.BlueprintId == StashedResourceIds.First())
				{
					cameraTarget = allPile.Value.transform;
					break;
				}
			}
			MonoSingleton<World>.Instance.LayerChangeEvent += OnLayerChanged;
			MonoSingleton<UIController>.Instance.LeftPanelView.SetViewControlsInteractable(new HashSet<string> { "LayerUpButton", "LayerDownButton" }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowLayerControls(allow: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.LeftPanelView.GetButtonRect("LayerDownButton"));
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<World>.Instance.LayerChangeEvent -= OnLayerChanged;
		}

		private void OnLayerChanged(float layerLevel, int sizeY)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\LayersTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Layer level: ");
				messageBuilder.AppendFormatted(layerLevel);
				messageBuilder.AppendLiteral(", Y:");
				messageBuilder.AppendFormatted(sizeY);
			}
			Log.Trace(messageBuilder);
			if (!Tasks[0].IsComplete && Mathf.Approximately(layerLevel, 3f))
			{
				MonoSingleton<TutorialViewManager>.Instance.ShowOutlineMarker(MarkerStart, MarkerEnd);
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("tutorial_stash_found"), cameraTarget.position);
				MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(cameraTarget);
				CompleteTask(0);
				MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.LeftPanelView.GetButtonRect("LayerUpButton"));
			}
			else if (Tasks[0].IsComplete && !Tasks[1].IsComplete && Mathf.Approximately(layerLevel, 8f))
			{
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				CompleteTask(1);
			}
		}
	}
}
