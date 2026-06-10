using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.FloatingOverlaySystem;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI;
using NSMedieval.View;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval
{
	public class AdditionalMenuItemBase : IGameDisposable, IDisposable
	{
		private readonly bool canDoWhileDrafted;

		private readonly IAdditionalMenuOwner owner;

		private bool isEnabled;

		private string text;

		private string tooltip;

		private JobType requiredJob;

		private CustomUiButton button;

		private string menuTitle;

		public bool HasDisposed { get; private set; }

		public bool IsEnabled
		{
			get
			{
				return isEnabled;
			}
			protected set
			{
				isEnabled = value;
			}
		}

		public string Text
		{
			get
			{
				return text;
			}
			protected set
			{
				text = value;
			}
		}

		public string MenuTitle
		{
			get
			{
				return menuTitle;
			}
			protected set
			{
				menuTitle = value;
			}
		}

		protected JobType RequiredJob
		{
			get
			{
				return requiredJob;
			}
			set
			{
				requiredJob = value;
			}
		}

		protected CustomUiButton Button
		{
			get
			{
				return button;
			}
			set
			{
				button = value;
			}
		}

		protected string Tooltip
		{
			get
			{
				return tooltip;
			}
			set
			{
				tooltip = value;
				RefreshTooltip();
			}
		}

		protected IAdditionalMenuOwner Owner => owner;

		public event Action<IGameDisposable> OnDisposedEvent;

		protected AdditionalMenuItemBase(IAdditionalMenuOwner owner, JobType requiredJob = JobType.None, bool canDoWhileDrafted = false)
		{
			this.owner = owner;
			this.canDoWhileDrafted = canDoWhileDrafted;
			this.requiredJob = requiredJob;
		}

		public virtual void Dispose()
		{
			HasDisposed = true;
			this.OnDisposedEvent?.Invoke(this);
			this.OnDisposedEvent = null;
		}

		public virtual bool Setup(AdditionalMenuFloatingElement overlayElement, AdditionalMenuItemData data)
		{
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (!canDoWhileDrafted && selectedWorker == null && GetSelectedFaintedWorker() == null)
			{
				return false;
			}
			if (selectedWorker?.WorkerBehaviour != null && selectedWorker.WorkerBehaviour.IsBanished)
			{
				return false;
			}
			string buttonTextSuffix = GetButtonTextSuffix();
			button = overlayElement.AddButton(text + buttonTextSuffix, OnClickCallback);
			button.interactable = IsEnabled;
			RefreshTooltip();
			return true;
		}

		protected virtual string GetButtonTextSuffix()
		{
			return string.Empty;
		}

		protected IGoapAgentOwner GetReserver()
		{
			if (!(Owner.GetAsTarget() is IReservable reservable))
			{
				return null;
			}
			if (!MonoSingleton<ReservationManager>.Instance.IsReserved(reservable))
			{
				return null;
			}
			return MonoSingleton<ReservationManager>.Instance.GetSingleReserver(reservable);
		}

		protected void DisableIfReserved(bool ignoreNonHumanReservations = false)
		{
			if (!(Owner.GetAsTarget() is IReservable reservable) || !MonoSingleton<ReservationManager>.Instance.IsReserved(reservable))
			{
				return;
			}
			IsEnabled = false;
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (!MonoSingleton<ReservationManager>.Instance.IsReservedBy(reservable, selectedWorker))
			{
				if (MonoSingleton<ReservationManager>.Instance.GetSingleReserver(reservable) is HumanoidInstance humanoidInstance)
				{
					string firstName = humanoidInstance.Info.FirstName;
					Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_reserved_by_other_worker") + ": " + firstName;
					return;
				}
				Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_reserved_by_other_worker");
				if (ignoreNonHumanReservations)
				{
					isEnabled = true;
				}
			}
			else
			{
				Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("already_working_on_target");
			}
		}

		protected bool SelectedWorkerIsOwner()
		{
			if (!(owner is WorkerView))
			{
				return false;
			}
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject item) => item is WorkerView workerView && workerView == (WorkerView)owner))
			{
				return true;
			}
			return false;
		}

		protected virtual void DisableIfUnreachableFromSelectedWorker(params IGoapTargetable[] targets)
		{
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				IsEnabled = false;
				return;
			}
			foreach (IGoapTargetable goapTargetable in targets)
			{
				if (!PathfinderUtil.IsPathPossible(selectedWorker, goapTargetable))
				{
					IsEnabled = false;
					Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("error_no_possible_path").Replace("<object>", goapTargetable.GetLocalizedName());
					break;
				}
			}
		}

		protected bool IsReachableFromSelectedWorker(params IGoapTargetable[] targets)
		{
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (selectedWorker == null)
			{
				return false;
			}
			foreach (IGoapTargetable target in targets)
			{
				if (!PathfinderUtil.IsPathPossible(selectedWorker, target))
				{
					return false;
				}
			}
			return true;
		}

		protected void EnableIfWorkerIsSelected(bool canTargetOwner = false, bool draftedOnly = false)
		{
			HashSet<SelectableObject> selectedObjects = MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects;
			if (selectedObjects.Count == 0)
			{
				IsEnabled = false;
				Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("requires_selected_worker");
				return;
			}
			HumanoidInstance selectedWorker = GetSelectedWorker();
			if (!(owner is WorkerView))
			{
				IsEnabled = selectedWorker != null;
				if (!IsEnabled)
				{
					if (GetSelectedFaintedWorker() != null)
					{
						Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("requires_conscious_worker_selected");
					}
					else
					{
						Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("requires_selected_worker");
					}
				}
			}
			else
			{
				IsEnabled = selectedObjects.Any((SelectableObject item) => item is WorkerView workerView && (canTargetOwner || workerView != (WorkerView)owner) && (canDoWhileDrafted || !workerView.HumanoidInstance.WorkerBehaviour.IsDrafting));
				if (!IsEnabled)
				{
					Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("can_not_execute_order_on_self");
				}
			}
			if (!canDoWhileDrafted && !IsEnabled && GetSelectedFaintedWorker() == null && selectedObjects.Any((SelectableObject item) => item is WorkerView))
			{
				Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("can_not_do_while_drafted");
			}
			else if (selectedWorker != null && IsEnabled && requiredJob != JobType.None && !IsJobSatisfied(selectedWorker, requiredJob))
			{
				Tooltip = MonoSingleton<LocalizationController>.Instance.GetText("job_not_enabled") + ": " + MonoSingleton<LocalizationController>.Instance.GetText("job_name_" + requiredJob.ToString().ToLower());
				IsEnabled = false;
			}
			if (draftedOnly && selectedWorker != null && !selectedWorker.WorkerBehaviour.IsDrafting)
			{
				IsEnabled = false;
			}
		}

		protected bool EnableIfOwnerIsVillageCaptive()
		{
			if (!(Owner.GetAsTarget() is HumanoidInstance humanoidInstance) || !humanoidInstance.IsCaptive() || !humanoidInstance.CaptiveNpcBehaviour.IsPlayerVillagePrisoner)
			{
				IsEnabled = false;
				return false;
			}
			IsEnabled = true;
			return true;
		}

		private static bool IsJobSatisfied(HumanoidInstance humanoid, JobType jobType)
		{
			if (humanoid == null)
			{
				return false;
			}
			bool flag = humanoid.WorkerBehaviour.IsJobActive(jobType);
			if (jobType == JobType.Hauling)
			{
				flag = flag || humanoid.WorkerBehaviour.IsJobActive(JobType.UrgentHaul);
			}
			return flag;
		}

		protected virtual void OnClickCallback()
		{
			MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
		}

		protected void RefreshTooltip()
		{
			TooltipViewNew tooltipViewNew = ((button == null) ? null : button.GetComponent<TooltipViewNew>());
			if (tooltipViewNew == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(tooltip))
			{
				tooltipViewNew.enabled = false;
				return;
			}
			tooltipViewNew.enabled = true;
			tooltipViewNew.SetSingleLineTooltip(tooltip);
			if (!button.interactable)
			{
				button.ClearClickEvents();
				button.OnUnInteractableClick += delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(Tooltip);
				};
			}
			else
			{
				button.ClearClickEvents();
			}
		}

		protected HumanoidInstance GetSelectedFaintedWorker()
		{
			return (from item in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.OfType<WorkerView>()
				where item.HumanoidInstance?.HasFainted ?? false
				select item).FirstOrDefault()?.HumanoidInstance;
		}

		protected HumanoidInstance GetSelectedWorker()
		{
			HumanoidInstance result = null;
			foreach (WorkerView item in MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.OfType<WorkerView>())
			{
				if (item.HumanoidInstance != null && !item.HumanoidInstance.HasFainted && !item.HumanoidInstance.HasDisposed && (canDoWhileDrafted || !item.HumanoidInstance.WorkerBehaviour.IsDrafting))
				{
					if (requiredJob == JobType.None)
					{
						return item.HumanoidInstance;
					}
					if (item.HumanoidInstance.WorkerBehaviour.IsJobActive(requiredJob))
					{
						return item.HumanoidInstance;
					}
					result = item.HumanoidInstance;
				}
			}
			return result;
		}
	}
}
