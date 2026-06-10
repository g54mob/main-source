using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.AdditionalMenuItems;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.View;
using NSMedieval.Views.Resources;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class EquipTutorialStep : TutorialStep
	{
		private readonly Dictionary<int, bool> equippedWorkers = new Dictionary<int, bool>();

		private readonly Dictionary<string, Vec3Int> stashedResourcePositions = new Dictionary<string, Vec3Int>();

		public EquipTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_select_settler"),
				new TutorialStepTask("tut_right_click_order"),
				new TutorialStepTask("tut_equip_all_settlers")
			};
		}

		public override void BeginStep()
		{
			base.BeginStep();
			TutorialStep.CameraJumpToDefault();
			MonoSingleton<World>.Instance.JumpToLayer(new Vec3Int(0, 8, 0));
			MonoSingleton<TutorialManager>.Instance.HandleAdditionalMenu(allow: true);
			bool isEnabled;
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(48, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Adding worker: ");
					messageBuilder.AppendFormatted(key.UniqueId);
					messageBuilder.AppendLiteral(" to the list of workers to equip.");
				}
				Log.Trace(messageBuilder);
				equippedWorkers.TryAdd(key.UniqueId, value: false);
				key.EquipEvent += OnEquip;
				key.DropEvent += OnDrop;
			}
			foreach (KeyValuePair<ResourcePileInstance, ResourcePileView> allPile in MonoSingleton<ResourcePileManager>.Instance.AllPiles)
			{
				if (StashedResourceIds.Contains(allPile.Key.Blueprint.GetID()))
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Stashed Resource: ");
						messageBuilder.AppendFormatted(allPile.Key.Blueprint.GetID());
						messageBuilder.AppendLiteral(" ");
						messageBuilder.AppendFormatted(allPile.Key.UniqueId);
					}
					Log.Trace(messageBuilder);
					Vec3Int gridPosition = GridUtils.GetGridPosition(allPile.Value.transform.position);
					stashedResourcePositions.Add(allPile.Key.Blueprint.GetID(), gridPosition);
					MonoSingleton<TutorialViewManager>.Instance.ShowOutlineMarker(new Vec3Int(gridPosition.x, 15, gridPosition.z), hidePrevious: false);
					MonoSingleton<ScreenPointerManager>.Instance.AddTarget(GridUtils.GetWorldPosition(gridPosition), Vector3.up);
				}
			}
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnSelection;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<TutorialManager>.Instance.HandleAdditionalMenu(allow: false);
			foreach (HumanoidInstance key in MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys)
			{
				key.EquipEvent -= OnEquip;
				key.DropEvent -= OnDrop;
			}
		}

		public override void Tick()
		{
			base.Tick();
			CheckAdditionalMenu();
		}

		private void OnSelection(SelectableObject selectable)
		{
			if (selectable is HumanoidView humanoidView)
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(humanoidView.HumanoidInstance.UniqueId);
					messageBuilder.AppendLiteral(" selected");
				}
				Log.Debug(messageBuilder);
				CompleteTask(0);
				MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnSelection;
			}
		}

		private void CheckAdditionalMenu()
		{
			if (Tasks[1].IsComplete || !MonoSingleton<AdditionalMenuManager>.Instance.IsMenuShown())
			{
				return;
			}
			AdditionalMenuManager.AdditionalMenuInstance currentMenu = MonoSingleton<AdditionalMenuManager>.Instance.CurrentMenu;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(14, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Menu: ");
				messageBuilder.AppendFormatted(currentMenu.GetType().Name);
				messageBuilder.AppendLiteral(" is open");
			}
			Log.Debug(messageBuilder);
			foreach (AdditionalMenuItemBase item in currentMenu.Items)
			{
				messageBuilder = new FVLogDebugInterpolationHandler(12, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Menu Item: ");
					messageBuilder.AppendFormatted(item.MenuTitle);
					messageBuilder.AppendLiteral(" ");
					messageBuilder.AppendFormatted(item.GetType().Name);
				}
				Log.Debug(messageBuilder);
				if (item is PileEquipMenuItem)
				{
					CompleteTask(1);
					break;
				}
			}
		}

		private void OnEquip(HumanoidInstance humanoid, EquipmentInstance equipment)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(humanoid.UniqueId);
				messageBuilder.AppendLiteral(" equiped ");
				messageBuilder.AppendFormatted(equipment.Blueprint.GetID());
			}
			Log.Debug(messageBuilder);
			equippedWorkers[humanoid.UniqueId] = true;
			if (stashedResourcePositions.TryGetValue(equipment.Blueprint.GetID(), out var value))
			{
				stashedResourcePositions.Remove(equipment.Blueprint.GetID());
				MonoSingleton<TutorialViewManager>.Instance.HideOutlineMarker(value);
				MonoSingleton<ScreenPointerManager>.Instance.TryRemoveTarget(GridUtils.GetWorldPosition(value));
			}
			HandleEquippedWorkersCompletion();
		}

		private void OnDrop(HumanoidInstance humanoid, EquipmentInstance equipment)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(9, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(humanoid.UniqueId);
				messageBuilder.AppendLiteral(" dropped ");
				messageBuilder.AppendFormatted(equipment.Blueprint.GetID());
			}
			Log.Debug(messageBuilder);
			equippedWorkers[humanoid.UniqueId] = false;
			HandleEquippedWorkersCompletion();
		}

		private void HandleEquippedWorkersCompletion()
		{
			int num = 0;
			foreach (bool value in equippedWorkers.Values)
			{
				if (value)
				{
					num++;
				}
			}
			float num2 = (float)num / (float)equippedWorkers.Count;
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(3, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\EquipTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(num2);
				messageBuilder.AppendLiteral(" =");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral("/");
				messageBuilder.AppendFormatted(equippedWorkers.Count);
			}
			Log.Trace(messageBuilder);
			UpdateTaskCompletion(2, num2);
		}
	}
}
