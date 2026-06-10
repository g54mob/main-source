using System;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.TaskManager;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.View.Animals;
using UnityEngine;

namespace NSMedieval.View
{
	[RequireComponent(typeof(ClickDetection))]
	public class CombatHoverTargetPointer : MonoBehaviour
	{
		private ClickDetection clickDetection;

		[NonSerialized]
		private IDamageDealAgent combatAgent;

		private bool isTargetingLineShown;

		[NonSerialized]
		private AnimatedAgentView view;

		private Task updateTargetPositionTask;

		private ClickDetection ClickDetection
		{
			get
			{
				if (!clickDetection)
				{
					clickDetection = GetComponent<ClickDetection>();
				}
				return clickDetection;
			}
		}

		private void Start()
		{
			combatAgent = null;
			WorkerView component = GetComponent<WorkerView>();
			if (component != null)
			{
				combatAgent = component.HumanoidInstance;
				view = component;
			}
			NPCView component2 = GetComponent<NPCView>();
			if (component2 != null)
			{
				combatAgent = component2.HumanoidInstance;
				view = component2;
			}
			AnimalView component3 = GetComponent<AnimalView>();
			if (component3 != null)
			{
				combatAgent = component3.AnimalInstance;
				view = component3;
			}
			if (combatAgent == null)
			{
				Log.Error("Use of this script requires combat agent's view be owned by same GameObject", "C:\\GIT\\dev\\Assets\\Scripts\\View\\Universal\\CombatHoverTargetPointer.cs");
				return;
			}
			MonoSingleton<CombatController>.Instance.AgentAttackStreamStart += OnAttackStreamStart;
			MonoSingleton<CombatController>.Instance.AgentAttackStreamEnd += OnAttackStreamEnd;
			ClickDetection.OnEnter += MouseEnterInternal;
			ClickDetection.OnExit += MouseExitInternal;
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += AgentSelected;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += AgentDeSelected;
		}

		private void AgentSelected(SelectableObject selectable)
		{
			if (selectable != view)
			{
				if (isTargetingLineShown)
				{
					HideTargetingLine();
					ClickDetection.OnExit += MouseExitInternal;
				}
			}
			else if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count > 1)
			{
				HideTargetingLine();
				ClickDetection.OnExit += MouseExitInternal;
			}
			else
			{
				ShowTargetingLine();
				ClickDetection.OnExit -= MouseExitInternal;
			}
		}

		private void AgentDeSelected(SelectableObject selectable)
		{
			if (isTargetingLineShown && !(selectable != view))
			{
				HideTargetingLine();
				ClickDetection.OnExit += MouseExitInternal;
			}
		}

		private void OnDestroy()
		{
			HideTargetingLine();
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.AgentAttackStreamStart -= OnAttackStreamStart;
				MonoSingleton<CombatController>.Instance.AgentAttackStreamEnd -= OnAttackStreamEnd;
			}
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= AgentSelected;
				MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= AgentDeSelected;
			}
			view = null;
			combatAgent = null;
		}

		private void OnAttackStreamStart(IDamageDealAgent agent)
		{
			if (agent == combatAgent && (ClickDetection.IsMouseOverElement || (view.Selected && MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Count <= 1)))
			{
				ShowTargetingLine();
			}
		}

		private void OnAttackStreamEnd(IDamageDealAgent agent)
		{
			if (agent == combatAgent)
			{
				HideTargetingLine();
			}
		}

		private void ShowTargetingLine()
		{
			if (isTargetingLineShown)
			{
				return;
			}
			IDamageTakingAgent target = combatAgent.GetTarget();
			if (combatAgent.CurrentAttackStream > 0 && target != null)
			{
				MonoSingleton<TargetLineRenderManager>.Instance.ShowLine(combatAgent.GetPosition(), target.GetPosition());
				isTargetingLineShown = true;
				updateTargetPositionTask = MonoSingleton<TaskController>.Instance.DoUntil(UpdateTargetPositionTick, () => true);
				MonoSingleton<CombatTargetIndicatorManager>.Instance.ShowIndicator(target);
			}
		}

		private void HideTargetingLine()
		{
			if (isTargetingLineShown)
			{
				isTargetingLineShown = false;
				updateTargetPositionTask?.Stop();
				updateTargetPositionTask = null;
				if (MonoSingleton<TargetLineRenderManager>.IsInstantiated())
				{
					MonoSingleton<TargetLineRenderManager>.Instance.HideLine();
				}
				if (MonoSingleton<CombatTargetIndicatorManager>.IsInstantiated())
				{
					MonoSingleton<CombatTargetIndicatorManager>.Instance.HideIndicator();
				}
			}
		}

		private void UpdateTargetPositionTick()
		{
			if (MonoSingleton<TargetLineRenderManager>.IsInstantiated() && isTargetingLineShown)
			{
				IDamageTakingAgent target = combatAgent.GetTarget();
				if (target != null && CombatUtils.IsAlive(target))
				{
					MonoSingleton<TargetLineRenderManager>.Instance.ShowLine(combatAgent.GetPosition(), target.GetPosition());
				}
			}
		}

		private void MouseEnterInternal(Vector3 pos)
		{
			ShowTargetingLine();
		}

		private void MouseExitInternal(Vector3 pos)
		{
			if (isTargetingLineShown)
			{
				HideTargetingLine();
			}
		}
	}
}
