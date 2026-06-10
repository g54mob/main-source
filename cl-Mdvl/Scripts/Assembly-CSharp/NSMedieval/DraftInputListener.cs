using System.Linq;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.Utils;
using NSMedieval.View;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval
{
	public class DraftInputListener : InputListener
	{
		private bool stopPropagation;

		private SelectableObject hoveredObject;

		private bool wasCursorShown;

		public DraftInputListener()
			: base(InputListenerType.Draft)
		{
			hoveredObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
			MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent += OnObjectHoverChanged;
		}

		public override void OnRemoved()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent -= OnObjectHoverChanged;
			base.OnRemoved();
		}

		public override void Begin()
		{
			stopPropagation = false;
			base.Begin();
		}

		public override void Dispose()
		{
			base.Dispose();
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent -= OnObjectHoverChanged;
			}
			hoveredObject = null;
		}

		public override void MouseFullClick(int button, Vector3 position)
		{
			if (button != 1 || !MonoSingleton<DraftController>.IsInstantiated() || MonoSingleton<DraftController>.Instance.DraftedWorkers.Count == 0 || !MonoSingleton<DraftController>.Instance.DraftedWorkers.Any((HumanoidInstance item) => item.GetAgentView<WorkerView>()?.Selected ?? false))
			{
				return;
			}
			SelectableObject mouseHoverObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
			if (mouseHoverObject is NPCView { HumanoidInstance: not null } nPCView && nPCView.HumanoidInstance.IsEnemy())
			{
				IGoapAgentOwner goapAgentOwner = nPCView.GetAgent()?.AgentOwner;
				if (goapAgentOwner is IDamageTakingAgent target && !goapAgentOwner.HasDisposed && MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(target, draftedOnly: true))
				{
					stopPropagation = true;
					MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
					return;
				}
			}
			else if (mouseHoverObject is AnimalView animalView && IsAnimalValidToAutoAttack((AnimalInstance)(animalView.GetAgent()?.AgentOwner)))
			{
				if (MonoSingleton<DraftManager>.Instance.HandleRightClickAttack((AnimalInstance)animalView.GetAgent().AgentOwner, draftedOnly: true))
				{
					stopPropagation = true;
					MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
					return;
				}
			}
			else if (mouseHoverObject is BaseBuildingViewComponent baseBuildingViewComponent && CombatInputUtils.IsBuildingAutoAttackable(baseBuildingViewComponent.BaseBuildingInstance))
			{
				BaseBuildingInstance baseBuildingInstance = baseBuildingViewComponent.BaseBuildingInstance;
				if (MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(baseBuildingInstance, draftedOnly: true))
				{
					stopPropagation = true;
					MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
					return;
				}
			}
			if (MonoSingleton<InputManager>.Instance.GetListener(InputListenerType.SelectableObject) is SelectableObjectInputListener selectableObjectInputListener && selectableObjectInputListener.HandleAdditionalMenu())
			{
				stopPropagation = true;
				return;
			}
			if (MonoSingleton<DraftManager>.Instance.HandleMovementOnClick())
			{
				stopPropagation = true;
				MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
			}
			base.MouseButtonDown(button, position);
		}

		public override bool IsStopEventPropagation()
		{
			return stopPropagation;
		}

		private void OnObjectHoverChanged(SelectableObject hoveredSelectable)
		{
			if (hoveredObject == hoveredSelectable || (hoveredSelectable != null && hoveredSelectable.Selected))
			{
				return;
			}
			bool flag = MonoSingleton<InputManager>.Instance.HasListener((InputListener item) => item is ManualAttackInputListener);
			if (hoveredObject != null)
			{
				if (!hoveredObject.Selected)
				{
					hoveredObject.ResetSelectionOutline();
				}
				hoveredObject = null;
			}
			if ((!(hoveredSelectable != null) || !hoveredSelectable.IsBuilding || !(hoveredSelectable is BaseBuildingViewComponent baseBuildingViewComponent) || !CombatInputUtils.IsBuildingAutoAttackable(baseBuildingViewComponent.BaseBuildingInstance)) && (!(hoveredSelectable is IAgentView) || hoveredSelectable is WorkerView))
			{
				hoveredObject = null;
				if (wasCursorShown)
				{
					wasCursorShown = false;
					if (!flag)
					{
						MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
					}
				}
				return;
			}
			if (hoveredObject == null)
			{
				hoveredObject = hoveredSelectable;
			}
			if (hoveredObject != null && MonoSingleton<DraftController>.Instance.DraftedWorkers.Count > 0 && MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject item) => item is WorkerView))
			{
				if (hoveredObject is AnimalView animalView && !IsAnimalValidToAutoAttack(animalView.AnimalInstance))
				{
					wasCursorShown = false;
					if (!flag)
					{
						MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
					}
				}
				else if (!(hoveredObject is NPCView nPCView) || nPCView.HumanoidInstance.IsEnemy())
				{
					hoveredObject.ShowSelectionOutline();
					wasCursorShown = true;
					MonoSingleton<UIController>.Instance.UpdateInfoCursorContent("order_attack", background: false, 2f);
				}
			}
			else if (wasCursorShown)
			{
				wasCursorShown = false;
				if (!flag)
				{
					MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
				}
			}
		}

		private static bool IsAnimalValidToAutoAttack(AnimalInstance animalInstance)
		{
			AnimalType? animalType = animalInstance?.AnimalType;
			if (animalType.HasValue)
			{
				AnimalType valueOrDefault = animalType.GetValueOrDefault();
				if ((uint)(valueOrDefault - 3) <= 1u)
				{
					return true;
				}
			}
			return false;
		}
	}
}
