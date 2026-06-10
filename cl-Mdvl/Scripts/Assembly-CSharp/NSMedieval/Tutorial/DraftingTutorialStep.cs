using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class DraftingTutorialStep : TutorialStep
	{
		private Vec3Int ArchersStart => new Vec3Int(112, 21, 112);

		private Vec3Int ArchersEnd => new Vec3Int(113, 21, 112);

		private Vec3Int SpearmanPosition => new Vec3Int(112, 21, 111);

		public DraftingTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_drafting_select"),
				new TutorialStepTask("tut_drafting_move_archers"),
				new TutorialStepTask("tut_drafting_move_spearman"),
				new TutorialStepTask("tut_drafting_hold_ground")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<TutorialManager>.Instance.HandleCreatureCommands(allow: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowDraftControls(allow: true);
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				WorkerBehaviour workerBehaviour = key.WorkerBehaviour;
				if (workerBehaviour != null)
				{
					workerBehaviour.CombatModeChangeEvent += OnCombatModeChange;
				}
			}
			MonoSingleton<DraftController>.Instance.OnEndDraftEvent += OnDraftChanged;
			MonoSingleton<DraftController>.Instance.OnStartDraftEvent += OnDraftChanged;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelected;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += OnDeselected;
		}

		private void OnCombatModeChange(HumanoidInstance humanoidInstance)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(14, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(humanoidInstance.Info.FirstName);
				messageBuilder.AppendLiteral(" combat mode: ");
				messageBuilder.AppendFormatted(humanoidInstance.WorkerBehaviour.CombatMode);
			}
			Log.Trace(messageBuilder);
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleCreatureCommands(allow: false);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowDraftControls(allow: false);
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				WorkerBehaviour workerBehaviour = key.WorkerBehaviour;
				if (workerBehaviour != null)
				{
					workerBehaviour.CombatModeChangeEvent -= OnCombatModeChange;
				}
			}
			MonoSingleton<DraftController>.Instance.OnEndDraftEvent -= OnDraftChanged;
			MonoSingleton<DraftController>.Instance.OnStartDraftEvent -= OnDraftChanged;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelected;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnDeselected;
			DeselectAllDelayed();
			HideScreenPointerTarget(ArchersStart, ArchersEnd);
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
		}

		public override void Tick()
		{
			base.Tick();
			CheckCompletion();
		}

		private void CheckCompletion()
		{
			if (!Tasks[0].IsComplete)
			{
				OnCheckDrafted();
			}
			else if (!Tasks[1].IsComplete)
			{
				OnCheckArchers();
			}
			else if (!Tasks[2].IsComplete)
			{
				OnCheckSpearman();
			}
			else if (!Tasks[3].IsComplete)
			{
				OnCheckHoldGround();
			}
		}

		private void OnCheckDrafted()
		{
			float num = 0f;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				WorkerBehaviour workerBehaviour = key.WorkerBehaviour;
				if (workerBehaviour != null && workerBehaviour.IsDrafting)
				{
					num += 1f;
				}
			}
			UpdateTaskCompletion(0, num / (float)MonoSingleton<WorkerManager>.Instance.AllWorkers.Count);
			if (Tasks[0].IsComplete)
			{
				MonoSingleton<TutorialViewManager>.Instance.ShowMarker(ArchersStart, ArchersEnd);
				ShowScreenPointerTarget(ArchersStart, ArchersEnd, Vector3.up, hideIfTargetOnscreen: true);
			}
		}

		private void OnCheckArchers()
		{
			float num = 0f;
			foreach (KeyValuePair<HumanoidInstance, WorkerView> allWorker in MonoSingleton<WorkerManager>.Instance.AllWorkers)
			{
				WorkerBehaviour workerBehaviour = allWorker.Key.WorkerBehaviour;
				if (workerBehaviour == null)
				{
					continue;
				}
				Vec3Int gridPosition = GridUtils.GetGridPosition(allWorker.Value.transform.position);
				EquipmentInstance item = workerBehaviour.Humanoid.Inventory.GetItem(EquipmentSlotType.RightHand);
				if (item != null && item.WeaponType != WeaponType.TwoHandSpear && IsArcherAtValidPosition(gridPosition))
				{
					num += 1f;
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(11, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendFormatted(gridPosition);
						messageBuilder.AppendLiteral(" is valid ");
						messageBuilder.AppendFormatted(num);
						messageBuilder.AppendLiteral(",");
					}
					Log.Debug(messageBuilder);
				}
			}
			UpdateTaskCompletion(1, num / 2f);
			if (Tasks[1].IsComplete)
			{
				GridUtils.GetWorldPosition(SpearmanPosition);
				MonoSingleton<TutorialViewManager>.Instance.ShowMarker(SpearmanPosition);
				ShowScreenPointerTarget(SpearmanPosition, SpearmanPosition, Vector3.up, hideIfTargetOnscreen: true);
			}
		}

		private bool IsArcherAtValidPosition(Vec3Int gridPosition)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(10, 3, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Archer: ");
				messageBuilder.AppendFormatted(gridPosition);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(ArchersStart);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(ArchersEnd);
			}
			Log.Trace(messageBuilder);
			for (int i = ArchersStart.x; i <= ArchersEnd.x; i++)
			{
				for (int j = ArchersStart.z; j <= ArchersEnd.z; j++)
				{
					messageBuilder = new FVLogTraceInterpolationHandler(22, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Archer position: ");
						messageBuilder.AppendFormatted(gridPosition);
						messageBuilder.AppendLiteral(" || ");
						messageBuilder.AppendFormatted(i);
						messageBuilder.AppendLiteral(",");
						messageBuilder.AppendFormatted(j);
					}
					Log.Trace(messageBuilder);
					if (gridPosition.x == i && gridPosition.z == j)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void OnCheckSpearman()
		{
			bool flag = false;
			foreach (KeyValuePair<HumanoidInstance, WorkerView> allWorker in MonoSingleton<WorkerManager>.Instance.AllWorkers)
			{
				WorkerBehaviour workerBehaviour = allWorker.Key.WorkerBehaviour;
				if (workerBehaviour != null)
				{
					Vec3Int gridPosition = GridUtils.GetGridPosition(allWorker.Value.transform.position);
					EquipmentInstance item = workerBehaviour.Humanoid.Inventory.GetItem(EquipmentSlotType.RightHand);
					if (item != null && item.WeaponType == WeaponType.TwoHandSpear && gridPosition.x == SpearmanPosition.x && gridPosition.z == SpearmanPosition.z)
					{
						flag = true;
					}
				}
			}
			UpdateTaskCompletion(2, flag ? 1f : 0f);
			if (Tasks[2].IsComplete)
			{
				MonoSingleton<TutorialViewManager>.Instance.HideAllMarkers();
				HideScreenPointerTarget(SpearmanPosition, SpearmanPosition);
			}
		}

		private void OnCheckHoldGround()
		{
			float num = 0f;
			foreach (KeyValuePair<HumanoidInstance, WorkerView> allWorker in MonoSingleton<WorkerManager>.Instance.AllWorkers)
			{
				WorkerBehaviour workerBehaviour = allWorker.Key.WorkerBehaviour;
				if (workerBehaviour != null && workerBehaviour.CombatMode == UnitCombatModeType.DraftedHoldGround)
				{
					num += 1f;
				}
			}
			UpdateTaskCompletion(3, num / (float)MonoSingleton<WorkerManager>.Instance.AllWorkers.Count);
		}

		private void OnSelected(SelectableObject selectable)
		{
			if (!(selectable is WorkerView workerView))
			{
				return;
			}
			WorkerBehaviour workerBehaviour = workerView.HumanoidInstance.WorkerBehaviour;
			if (workerBehaviour == null)
			{
				return;
			}
			RectTransform targetRectTransform = null;
			if (!workerBehaviour.IsDrafting && workerBehaviour.CombatMode != UnitCombatModeType.DraftedDefault)
			{
				targetRectTransform = MonoSingleton<UIController>.Instance.SelectionPanel.PanelView.GetDraftButtonRectTransform();
			}
			if (workerBehaviour.IsDrafting && workerBehaviour.CombatMode != UnitCombatModeType.DraftedHoldGround && Tasks[1].IsComplete)
			{
				targetRectTransform = MonoSingleton<UIController>.Instance.SelectionPanel.PanelView.GetHoldGroundButtonRectTransform();
			}
			if ((bool)targetRectTransform)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(workerView.HumanoidInstance.Info.FirstName);
					messageBuilder.AppendLiteral(" selected");
				}
				Log.Trace(messageBuilder);
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(targetRectTransform);
				});
			}
		}

		private void OnDeselected(SelectableObject selectable)
		{
			if (selectable is WorkerView)
			{
				Log.Trace("Deselected", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
				MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			}
		}

		private void OnDraftChanged(HumanoidInstance humanoid)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(19, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\DraftingTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Starting draft for ");
				messageBuilder.AppendFormatted(humanoid?.Info?.GetFullName());
			}
			Log.Debug(messageBuilder);
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}
	}
}
