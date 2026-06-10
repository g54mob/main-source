using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.BuildingComponents;
using NSMedieval.Components;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI;
using NSMedieval.Utils;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval
{
	public class ManualAttackInputListener : InputListener
	{
		private SelectableObject hoveredObject;

		private bool endOnMouseUp;

		private int tmpCounter;

		private readonly int raycastLayerMask;

		private event Action OnRemovedAction;

		public ManualAttackInputListener(Action onRemovedAction)
			: base(InputListenerType.AttackOrder)
		{
			if (onRemovedAction != null)
			{
				OnRemovedAction += onRemovedAction;
			}
			raycastLayerMask = LayerMask.GetMask("VoxelMap");
		}

		public override void OnAdded()
		{
			hoveredObject = MonoSingleton<SelectableObjectManager>.Instance.MouseHoverObject;
			MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent += OnObjectHoverChanged;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += OnObjectDeselected;
			endOnMouseUp = false;
			base.OnAdded();
		}

		public override void OnRemoved()
		{
			this.OnRemovedAction?.Invoke();
			MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent -= OnObjectHoverChanged;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnObjectDeselected;
			base.OnRemoved();
		}

		public override void Dispose()
		{
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.OnHoverEvent -= OnObjectHoverChanged;
				MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnObjectDeselected;
			}
			this.OnRemovedAction = null;
			hoveredObject = null;
			base.Dispose();
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			switch (button)
			{
			case 0:
				if (hoveredObject is IAgentView agentView)
				{
					HandleManualAttackAgent(agentView);
				}
				else
				{
					HandleManualAttackVoxel(position);
				}
				break;
			case 1:
				EndListener();
				break;
			}
			base.MouseButtonDown(button, position);
		}

		private void HandleManualAttackVoxel(Vector3 clickedScreenPos)
		{
			if (MonoSingleton<SelectableObjectManager>.Instance.GetFirstSelected(out var selected) && selected is HumanoidView humanoidView)
			{
				Vector3 worldSpacePosition;
				if (hoveredObject == null)
				{
					RaycastUtils.RaycastFromScreen(clickedScreenPos, out var position, raycastLayerMask);
					worldSpacePosition = position.SnapToGrid(0.1f);
				}
				else
				{
					worldSpacePosition = hoveredObject.transform.position;
				}
				if (hoveredObject is BaseBuildingViewComponent baseBuildingViewComponent && baseBuildingViewComponent.BaseBuildingInstance.FactionOwnership == FactionOwnership.Enemy)
				{
					endOnMouseUp = true;
					MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(baseBuildingViewComponent.BaseBuildingInstance, draftedOnly: true);
					return;
				}
				VillageMap map = humanoidView.HumanoidInstance.Map;
				AttackablePointTarget newPooled = AttackablePointTarget.GetNewPooled();
				newPooled.Init(map, worldSpacePosition);
				endOnMouseUp = true;
				MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(newPooled, draftedOnly: true);
			}
		}

		private void HandleManualAttackAgent(IAgentView agentView)
		{
			if (agentView == null || agentView.GetAgent() == null)
			{
				agentView = GetAgentViewAt(Vector3.down * 0.5f + (Vector3)MonoSingleton<PlayerVoxelInfo>.Instance.HoverGridPosition);
			}
			if (agentView != null && agentView.GetAgent() != null && !agentView.GetAgent().HasDisposed && (!(hoveredObject != null) || !hoveredObject.Selected) && (!(agentView is WorkerView workerView) || !workerView.HumanoidInstance.WorkerBehaviour.IsCrazy) && agentView.GetAgent().AgentOwner is IDamageTakingAgent target)
			{
				endOnMouseUp = true;
				MonoSingleton<DraftManager>.Instance.HandleRightClickAttack(target, draftedOnly: true);
			}
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			if (button == 0 && endOnMouseUp)
			{
				EndListener();
			}
			base.MouseButtonUp(button, position);
		}

		public override void KeyDown(KeyCode key)
		{
			if (MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.Escape, key))
			{
				EndListener();
			}
			base.KeyDown(key);
		}

		public override void Update()
		{
			if (endOnMouseUp && !Input.GetMouseButton(0))
			{
				EndListener();
			}
			base.Update();
		}

		public override bool IsStopEventPropagation()
		{
			return true;
		}

		private void OnObjectDeselected(SelectableObject obj)
		{
			if (!MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject item) => (item as WorkerView)?.HumanoidInstance?.WorkerBehaviour.IsDrafting == true))
			{
				EndListener();
			}
		}

		private void OnObjectHoverChanged(SelectableObject obj)
		{
			if (obj == null)
			{
				HandleHoveredObjectChange(isHover: false);
				hoveredObject = null;
			}
			else if (!(obj == hoveredObject))
			{
				HandleHoveredObjectChange(isHover: false);
				hoveredObject = obj;
				HandleHoveredObjectChange(isHover: true);
			}
		}

		private void HandleHoveredObjectChange(bool isHover)
		{
			if (hoveredObject == null || hoveredObject.Selected)
			{
				return;
			}
			if (hoveredObject.IsBuilding)
			{
				BaseBuildingViewComponent baseBuildingViewComponent = hoveredObject as BaseBuildingViewComponent;
				if (baseBuildingViewComponent == null || !CombatInputUtils.IsBuildingAutoAttackable(baseBuildingViewComponent.BaseBuildingInstance))
				{
					return;
				}
			}
			else if (!(hoveredObject is IAgentView))
			{
				return;
			}
			if (isHover)
			{
				hoveredObject.ShowSelectionOutline();
				MonoSingleton<UIController>.Instance.UpdateInfoCursorContent("order_attack", background: false, 2f);
				return;
			}
			if (!base.IsEnabled)
			{
				MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false);
			}
			hoveredObject.ResetSelectionOutline();
		}

		private void EndListener()
		{
			HandleHoveredObjectChange(isHover: false);
			MonoSingleton<InputManager>.Instance.RemoveListener(this);
		}

		private IAgentView GetAgentViewAt(Vector3 gridPosition)
		{
			using PooledList<HumanoidInstance> pooledList = MonoSingleton<NPCManager>.Instance.GetNPCsPooled((HumanoidInstance enemy) => !enemy.HasDied && !enemy.HasDisposed && Vec3Int.Distance(enemy.GetGridPosition(), in gridPosition) < 1.5f);
			if (pooledList.Count > 0)
			{
				return pooledList[tmpCounter++ % pooledList.Count].GetAgentView<IAgentView>();
			}
			List<HumanoidInstance> list = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.Where((HumanoidInstance worker) => !worker.HasDisposed && !worker.HasDied && Vec3Int.Distance(worker.GetGridPosition(), in gridPosition) < 1.5f).ToList();
			if (list.Count > 0)
			{
				return list[tmpCounter++ % list.Count()].GetAgentView<IAgentView>();
			}
			return null;
		}
	}
}
