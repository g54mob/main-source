using System;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Enums;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerEntryLayoutItemView : LayoutGroupItemView, IObserver
	{
		[NonSerialized]
		private Agent agent;

		private readonly int iconIndex;

		private readonly int nameIndex = 1;

		private readonly int statusIndex = 2;

		private readonly int buttonIndex = 3;

		private readonly int selectionIndex = 4;

		private readonly int draftIndicatorIndex = 5;

		private readonly int bleedIndicatorIndex = 6;

		private readonly int negativeMoodIndicatorIndex = 7;

		private readonly int weaponIconIndex = 8;

		private readonly int shieldIconIndex = 9;

		private readonly int damageIndicatorIndex = 10;

		private readonly int backgroundGeneralIndex = 11;

		private readonly int backgroundDraftedIndex = 12;

		private readonly int psychoticIndicatorIndex = 13;

		private readonly int psychoticBackgroundIndex = 14;

		private readonly int positiveMoodIndicatorIndex = 15;

		private readonly int prisonerBackgroundIndex = 16;

		private string currentGoal = string.Empty;

		private string currentNameStyle = "Normal";

		[NonSerialized]
		private TMP_Text currentWorkerActionText;

		[NonSerialized]
		private Image image;

		private Button selectionButton;

		private bool initComponentsDone;

		[field: NonSerialized]
		public HumanoidInstance HumanoidInstance { get; private set; }

		private void TryInitComponents()
		{
			if (!initComponentsDone)
			{
				selectionButton = base.GroupItems[buttonIndex].GetComponent<Button>();
				image = base.GroupItems[iconIndex].GetComponent<Image>();
				currentWorkerActionText = base.GroupItems[statusIndex].GetComponent<TMP_Text>();
				initComponentsDone = true;
			}
		}

		public void SetHumanoidInstance(HumanoidInstance humanoidInstance, bool selectable = true)
		{
			if (HumanoidInstance != humanoidInstance)
			{
				TryInitComponents();
				if (HumanoidInstance != null && HumanoidInstance.IsStatsInitialized)
				{
					HumanoidInstance.Stats.OnEffectorStartEvent -= OnEffectorStart;
					HumanoidInstance.Stats.OnEffectorEndEvent -= OnEffectorEnd;
					HumanoidInstance.FireStartedEvent -= OnFireStartEndEvent;
				}
				HumanoidInstance = humanoidInstance;
				if (HumanoidInstance.IsStatsInitialized)
				{
					HumanoidInstance.Stats.OnEffectorStartEvent += OnEffectorStart;
					HumanoidInstance.Stats.OnEffectorEndEvent += OnEffectorEnd;
				}
				HumanoidInstance.FireStartedEvent += OnFireStartEndEvent;
				agent = HumanoidInstance.GetGoapAgent();
				OnWorkerNameChange();
				selectionButton.onClick.RemoveAllListeners();
				if (selectable)
				{
					selectionButton.onClick.AddListener(SelectWorker);
				}
				selectionButton.interactable = selectable;
				base.GroupItems[negativeMoodIndicatorIndex].SetActive(value: false);
				base.GroupItems[positiveMoodIndicatorIndex].SetActive(value: false);
				if (base.TooltipNew is WorkerSkillsTooltipViewNew workerSkillsTooltipViewNew)
				{
					workerSkillsTooltipViewNew.SetOwner(HumanoidInstance);
				}
				WorkerUpdate();
			}
		}

		private void Awake()
		{
			TryInitComponents();
		}

		private void Start()
		{
			MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent += OnWorkerSelect;
			MonoSingleton<SelectableObjectController>.Instance.OnMultiSelectedEvent += OnWorkerSelect;
			MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent += OnWorkerDeSelect;
			MonoSingleton<SelectableObjectController>.Instance.DeselectAllEvent += OnDeselectAll;
			MonoSingleton<WarningMessageController>.Instance.ShowMessageEvent += OnShowWarningMessage;
			MonoSingleton<WarningMessageController>.Instance.HideMessageEvent += OnHideWarningMessage;
			MonoSingleton<WarningMessageController>.Instance.UpdateMessageEvent += OnUpdateWarningMessage;
			MonoSingleton<CombatController>.Instance.DamageTakenEvent += OnDamageTaken;
			MonoSingleton<HumanoidIconManager>.Instance.HumanoidImageUpdatedEvent += OnHumanoidImageUpdated;
			MonoSingleton<DraftController>.Instance.OnStartDraftEvent += OnDraftStateChanged;
			MonoSingleton<DraftController>.Instance.OnEndDraftEvent += OnDraftStateChanged;
			MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent += OnWorkerNameChange;
			CaravanController instance = MonoSingleton<CaravanController>.Instance;
			instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
			CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
			instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Combine(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturned));
			MonoSingleton<GoapController>.Instance.OnGoalStartedEvent += OnGoapPlanCreated;
			MonoSingleton<WorkerController>.Instance.HourTypeChangeEvent += OnHourChange;
		}

		private void OnCaravanReturned(CaravanInstance caravanInstance)
		{
			if (caravanInstance.Workers.Contains(HumanoidInstance))
			{
				WorkerUpdate();
			}
		}

		private void OnCaravanCreated(CaravanInstance caravanInstance)
		{
			if (caravanInstance.Workers.Contains(HumanoidInstance))
			{
				UpdateWorkerIncognito();
				DisplayCurrentAction();
			}
		}

		private void OnEnable()
		{
			WorkerUpdate();
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<SelectableObjectController>.IsInstantiated())
			{
				MonoSingleton<SelectableObjectController>.Instance.OnSelectedEvent -= OnWorkerSelect;
				MonoSingleton<SelectableObjectController>.Instance.OnMultiSelectedEvent -= OnWorkerSelect;
				MonoSingleton<SelectableObjectController>.Instance.OnDeSelectedEvent -= OnWorkerDeSelect;
				MonoSingleton<SelectableObjectController>.Instance.DeselectAllEvent -= OnDeselectAll;
			}
			if (MonoSingleton<WarningMessageController>.IsInstantiated())
			{
				MonoSingleton<WarningMessageController>.Instance.ShowMessageEvent -= OnShowWarningMessage;
				MonoSingleton<WarningMessageController>.Instance.HideMessageEvent -= OnHideWarningMessage;
				MonoSingleton<WarningMessageController>.Instance.UpdateMessageEvent -= OnUpdateWarningMessage;
			}
			if (MonoSingleton<CombatController>.IsInstantiated())
			{
				MonoSingleton<CombatController>.Instance.DamageTakenEvent -= OnDamageTaken;
			}
			if (MonoSingleton<HumanoidIconManager>.IsInstantiated())
			{
				MonoSingleton<HumanoidIconManager>.Instance.HumanoidImageUpdatedEvent -= OnHumanoidImageUpdated;
			}
			if (MonoSingleton<DraftController>.IsInstantiated())
			{
				MonoSingleton<DraftController>.Instance.OnStartDraftEvent -= OnDraftStateChanged;
				MonoSingleton<DraftController>.Instance.OnEndDraftEvent -= OnDraftStateChanged;
			}
			if (HumanoidInstance != null && !HumanoidInstance.HasDisposed && HumanoidInstance.Stats != null)
			{
				HumanoidInstance.Stats.OnEffectorStartEvent -= OnEffectorStart;
				HumanoidInstance.Stats.OnEffectorEndEvent -= OnEffectorEnd;
			}
			if (HumanoidInstance != null)
			{
				HumanoidInstance.FireStartedEvent -= OnFireStartEndEvent;
			}
			if (MonoSingleton<CaravanController>.IsInstantiated())
			{
				CaravanController instance = MonoSingleton<CaravanController>.Instance;
				instance.CaravanCreatedEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance.CaravanCreatedEvent, new CaravanController.CaravanDelegate(OnCaravanCreated));
				CaravanController instance2 = MonoSingleton<CaravanController>.Instance;
				instance2.CaravanReturnedHomeEvent = (CaravanController.CaravanDelegate)Delegate.Remove(instance2.CaravanReturnedHomeEvent, new CaravanController.CaravanDelegate(OnCaravanReturned));
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.HourTypeChangeEvent -= OnHourChange;
			}
			if (MonoSingleton<GoapController>.IsInstantiated())
			{
				MonoSingleton<GoapController>.Instance.OnGoalStartedEvent -= OnGoapPlanCreated;
			}
			if (MonoSingleton<WorkerController>.IsInstantiated())
			{
				MonoSingleton<WorkerController>.Instance.HourTypeChangeEvent -= OnHourChange;
				MonoSingleton<WorkerController>.Instance.WorkerNameChangedEvent -= OnWorkerNameChange;
			}
			agent = null;
			HumanoidInstance = null;
			base.OnDestroy();
		}

		private void UpdateWorkerIncognito()
		{
			Color color = (HumanoidInstance.IsInIncognitoMode() ? Color.Lerp(Color.white, Color.clear, 0.5f) : Color.white);
			image.color = color;
			base.GroupItems[nameIndex].GetComponent<TMP_Text>().color = color;
		}

		private void OnFireStartEndEvent()
		{
			if (!LoadingController.IsSceneTransition && !MonoSingleton<LoadingController>.IsApplicationIsQuitting() && HumanoidInstance != null && !HumanoidInstance.HasDisposed && HumanoidInstance.IsOnFire)
			{
				Animator component = base.GroupItems[damageIndicatorIndex].GetComponent<Animator>();
				if (component.isActiveAndEnabled)
				{
					component.Play("DamageBlinkAnimation");
				}
				MonoSingleton<TaskController>.Instance.WaitFor(2.5f).Then(OnFireStartEndEvent);
			}
		}

		private void WorkerUpdate()
		{
			if (HumanoidInstance == null || HumanoidInstance.HasDisposed)
			{
				return;
			}
			if (agent == null)
			{
				agent = HumanoidInstance.GetGoapAgent();
			}
			Sprite sprite = HumanoidInstance.GetSprite();
			if (sprite == null)
			{
				return;
			}
			image.sprite = sprite;
			UpdateWorkerIncognito();
			DisplayCurrentAction();
			bool active = false;
			HumanoidView agentView = HumanoidInstance.GetAgentView<HumanoidView>();
			if (agentView != null)
			{
				active = agentView.Selected;
			}
			base.GroupItems[selectionIndex].SetActive(active);
			base.GroupItems[negativeMoodIndicatorIndex].SetActive(HumanoidInstance.Stats.IsEffectorActive("MoodLow"));
			base.GroupItems[positiveMoodIndicatorIndex].SetActive(HumanoidInstance.Stats.IsEffectorActive("AgentMoodGood"));
			base.GroupItems[bleedIndicatorIndex].SetActive(HumanoidInstance.HasUntendendWounds());
			WorkerBehaviour workerBehaviour = HumanoidInstance.WorkerBehaviour;
			base.GroupItems[draftIndicatorIndex].SetActive(workerBehaviour?.IsDrafting ?? false);
			base.GroupItems[backgroundDraftedIndex].SetActive(workerBehaviour?.IsDrafting ?? false);
			bool flag = HumanoidInstance.GetGoapAgent() is WorkerGoapAgent workerGoapAgent && workerGoapAgent.CurrentHourType == HourType.PsyhoticCrazy;
			base.GroupItems[psychoticIndicatorIndex].SetActive(flag);
			base.GroupItems[psychoticBackgroundIndex].SetActive(flag);
			base.GroupItems[backgroundGeneralIndex].SetActive((workerBehaviour == null || !workerBehaviour.IsDrafting) && !flag);
			if (base.GroupItems.Count > prisonerBackgroundIndex)
			{
				base.GroupItems[prisonerBackgroundIndex].SetActive(HumanoidInstance.IsCaptive());
			}
			foreach (EquipmentSlotType availableSlot in HumanoidInstance.Inventory.AvailableSlots)
			{
				if (availableSlot == EquipmentSlotType.RightHand)
				{
					ResourceIconItemView component = base.GroupItems[weaponIconIndex].GetComponent<ResourceIconItemView>();
					EquipmentInstance item = HumanoidInstance.Inventory.GetItem(availableSlot);
					if (HumanoidInstance.Inventory.IsSlotBlocked(availableSlot) || item == null)
					{
						component.gameObject.SetActive(value: false);
					}
					else
					{
						component.gameObject.SetActive(value: true);
						component.SetData(item.Blueprint.GetID());
						if (component.TooltipNew is EquipmentTooltipView equipmentTooltipView)
						{
							equipmentTooltipView.SetupData(item, HumanoidInstance);
						}
					}
				}
				if (availableSlot != EquipmentSlotType.LeftHand)
				{
					continue;
				}
				ResourceIconItemView component2 = base.GroupItems[shieldIconIndex].GetComponent<ResourceIconItemView>();
				EquipmentInstance item2 = HumanoidInstance.Inventory.GetItem(availableSlot);
				if (HumanoidInstance.Inventory.IsSlotBlocked(availableSlot) || item2 == null)
				{
					component2.gameObject.SetActive(value: false);
					continue;
				}
				component2.gameObject.SetActive(value: true);
				component2.SetData(item2.Blueprint.GetID());
				if (component2.TooltipNew is EquipmentTooltipView equipmentTooltipView2)
				{
					equipmentTooltipView2.SetupData(item2, HumanoidInstance);
				}
			}
		}

		private void OnHourChange(HumanoidInstance humanoidInstance, HourType hourType)
		{
			if (HumanoidInstance != null && humanoidInstance == HumanoidInstance)
			{
				WorkerUpdate();
			}
		}

		private void DisplayCurrentAction()
		{
			currentWorkerActionText.SetText(CreatureBaseUtils.GetLocalizedCurrentActionInfo(HumanoidInstance));
		}

		public void SelectWorker()
		{
			if (HumanoidInstance == null || HumanoidInstance.HasDisposed)
			{
				return;
			}
			if (HumanoidInstance.IsInIncognitoMode())
			{
				MonoSingleton<CaravanController>.Instance.SelectedWorkerInCaravan(HumanoidInstance);
				return;
			}
			WorkerView view = MonoSingleton<WorkerManager>.Instance.GetView(HumanoidInstance);
			if (!view)
			{
				return;
			}
			if (view.Selected && !MonoSingleton<SelectableObjectManager>.Instance.IsMultipleSelected)
			{
				base.CameraFollowAction(HumanoidInstance.GetTransform());
				return;
			}
			if (!MonoSingleton<KeybindingManager>.Instance.IsKeybindingKeyDown(KeyInputEvent.Multiselect))
			{
				MonoSingleton<SelectableObjectManager>.Instance.DeselectAll();
			}
			view.Select();
		}

		private void ChangeNameStyle(string style)
		{
			currentNameStyle = style;
			OnWorkerNameChange();
		}

		private void OnWorkerNameChange(HumanoidInstance humanoidInstance = null)
		{
			if (HumanoidInstance == null || HumanoidInstance.HasDisposed || !CombatUtils.IsAlive(HumanoidInstance) || (humanoidInstance != null && HumanoidInstance != humanoidInstance))
			{
				return;
			}
			if (base.GroupItems == null)
			{
				Log.Error("GroupItems is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\WorkerEntryLayoutItemView.cs");
				return;
			}
			if (base.GroupItems[nameIndex] == null)
			{
				Log.Error("this.GroupItems[this.nameIndex] is null", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\WorkerEntryLayoutItemView.cs");
				return;
			}
			if (base.GroupItems[nameIndex].GetComponent<TMP_Text>() == null)
			{
				Log.Error("Missing Name TMP_Text component", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\WorkerEntryLayoutItemView.cs");
				return;
			}
			base.GroupItems[nameIndex].GetComponent<TMP_Text>().SetText("<style=" + currentNameStyle + ">" + HumanoidInstance.ActiveBehaviour.HumanoidRoleOwner.GetDefaultDisplayNameRole() + "</style>");
			if (base.TooltipNew is WorkerSkillsTooltipViewNew workerSkillsTooltipViewNew)
			{
				workerSkillsTooltipViewNew.SetOwner(HumanoidInstance);
			}
		}

		private void OnGoapPlanCreated(Agent agent, Goal goal)
		{
			if (HumanoidInstance != null && agent == this.agent && !(agent.GetType() != typeof(WorkerGoapAgent)) && !(goal.Id == currentGoal))
			{
				WorkerUpdate();
			}
		}

		private void OnDraftStateChanged(HumanoidInstance humanoidInstance)
		{
			if (humanoidInstance == HumanoidInstance)
			{
				WorkerUpdate();
			}
		}

		private void OnHumanoidImageUpdated(CreatureBase creature)
		{
			if (creature == HumanoidInstance)
			{
				WorkerUpdate();
			}
		}

		private void OnDamageTaken(IDamageDealAgent deal, IDamageTakingAgent take, CombatHitInfo hitInfo)
		{
			if (HumanoidInstance == take)
			{
				Animator component = base.GroupItems[damageIndicatorIndex].GetComponent<Animator>();
				if (component.isActiveAndEnabled)
				{
					component.Play("DamageBlinkAnimation");
				}
			}
		}

		private void OnShowWarningMessage(WarningMessageData message)
		{
			WorkerUpdate();
		}

		private void OnHideWarningMessage(WarningMessageData message)
		{
			WorkerUpdate();
		}

		private void OnUpdateWarningMessage(WarningMessageData message)
		{
			WorkerUpdate();
		}

		private void OnWorkerSelect(SelectableObject obj)
		{
			if (obj is WorkerView && HumanoidInstance != null)
			{
				WorkerView agentView = HumanoidInstance.GetAgentView<WorkerView>();
				if (!(obj != agentView))
				{
					base.GroupItems[selectionIndex].SetActive(value: true);
				}
			}
		}

		private void OnDeselectAll()
		{
			base.GroupItems[selectionIndex].SetActive(value: false);
		}

		private void OnWorkerDeSelect(SelectableObject obj)
		{
			if (MonoSingleton<WorkerManager>.IsInstantiated() && !(obj.GetType() != typeof(WorkerView)) && ((WorkerView)obj).HumanoidInstance == HumanoidInstance)
			{
				base.GroupItems[selectionIndex].SetActive(value: false);
			}
		}

		private void OnEffectorStart(StatEffector effector)
		{
			if (HumanoidInstance != null && CombatUtils.IsAlive(HumanoidInstance))
			{
				if (effector.GetID().Equals("AgentMoodGood"))
				{
					ChangeNameStyle("DefaultGreen");
				}
				else if (effector.GetID().Equals("MoodLow"))
				{
					ChangeNameStyle("DefaultRed");
				}
			}
		}

		private void OnEffectorEnd(StatEffector effector)
		{
			if (HumanoidInstance != null && CombatUtils.IsAlive(HumanoidInstance))
			{
				if (effector.GetID().Equals("AgentMoodGood") && currentNameStyle == "DefaultGreen")
				{
					ChangeNameStyle("Normal");
				}
				else if (effector.GetID().Equals("MoodLow") && currentNameStyle == "DefaultRed")
				{
					ChangeNameStyle("Normal");
				}
			}
		}
	}
}
