using System;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.StatisticsSystem;
using CTS.DevConsole.Variables;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class Worker : Agent, IRoomAssignable, IBBTObject, IObject
	{
		[Inject(false)]
		private WorkerCharacteristics _characteristics;

		[Inject(false)]
		private WorkerTechTreeWorkerBubble _workerTechTreeWorkerBubble;

		[Inject(false)]
		private AgentEyesBlinkControler _agentEyesBlinkControler;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private WorkerBasicInformationCanvas _hireInformationCanvas;

		private bool _isSpawned;

		private PooledRef<Customer> _controlledHuman;

		private static CVarBoolReference _cVarAutonomyEnabled;

		[field: Inject(false)]
		public WorkerChoreAssigner ChoreAssigner { get; }

		[field: Inject(false)]
		internal WorkerFSM FSM { get; }

		[field: Inject(false)]
		public WorkerPassives PassiveFeatures { get; }

		[field: Inject(false)]
		public WorkerPowerFeature PowerFeatures { get; }

		[field: Inject(false)]
		public RoomAssignations RoomAssignations { get; }

		public WorkerCharacteristics Characteristics
		{
			get
			{
				if (!_characteristics)
				{
					_characteristics = GetComponent<WorkerCharacteristics>();
				}
				return _characteristics;
			}
		}

		public WorkerTechTreeWorkerBubble WorkerTechTreeBubble
		{
			get
			{
				if (!_workerTechTreeWorkerBubble)
				{
					_workerTechTreeWorkerBubble = GetComponent<WorkerTechTreeWorkerBubble>();
				}
				return _workerTechTreeWorkerBubble;
			}
		}

		[field: Inject(false)]
		public WorkerLevel Level { get; }

		[field: Inject(false)]
		public WorkerSalary WorkerSalary { get; }

		[field: Inject(false)]
		internal BarVisualObject[] BarVisuals { get; }

		[field: SerializeField]
		public WorkerParameters WorkerParameters { get; set; }

		[field: SerializeField]
		public bool IsMainWorker { get; set; }

		public bool IsEngaged { get; private set; }

		public int Salary => WorkerSalary.CurrentSalary;

		public bool AssignationBypassNeeds { get; set; }

		public bool AssignationBypassPowers { get; set; }

		public Customer ControlledHuman
		{
			get
			{
				if (!_controlledHuman.TryGetValue(out var outValue))
				{
					return null;
				}
				return outValue;
			}
			private set
			{
				_controlledHuman = (value ? new PooledRef<Customer>(value) : default(PooledRef<Customer>));
			}
		}

		public bool IsControllingCustomer => ControlledHuman;

		public static CVarBoolReference CVarAutonomyEnabled
		{
			get
			{
				if (_cVarAutonomyEnabled == null)
				{
					_cVarAutonomyEnabled = ConsoleVar.GetVariable<CVarBoolReference>("WorkerAutonomy");
				}
				return _cVarAutonomyEnabled;
			}
		}

		public static bool GlobalAutonomyEnabled => CVarAutonomyEnabled.GetCurrentValue();

		public bool Dismissable { get; set; } = true;

		[field: SerializeField]
		[field: NavArea(true)]
		public int RandomMovementAreaMask { get; private set; }

		public override int RandomMovementMask => RandomMovementAreaMask;

		public static event Action<Worker> OnSelect;

		public static event Action<Worker> WorkerSpawned;

		public static event Action<Worker> Fired;

		private void Start()
		{
			_hireInformationCanvas.gameObject.SetActive(!IsEngaged);
		}

		public void Spawn(int p_level, CharacterData characterData, WorkerParameters parameters = null)
		{
			if (!_isSpawned)
			{
				if (parameters != null)
				{
					WorkerParameters = parameters;
				}
				_isSpawned = true;
				base.Statistics.LoadStatistics();
				base.Selection.Selectable = true;
				base.ContextualFSM.SetStateNormal();
				base.AgentVisualControler.RigSelection(characterData);
				EGender gender = ((UnityEngine.Random.value > 0.75f) ? EGender.NonBinary : ((!base.HasDeepVoice) ? EGender.Female : EGender.Male));
				GenerateName(this, gender);
				SetEngagable();
				CreateStatsAndAbilities(p_level);
				base.gameObject.name = "Worker - " + base.agentFirstName + " " + base.agentName;
				InvokeSpawned();
			}
		}

		private void CreateStatsAndAbilities(int p_level)
		{
			Characteristics.Initialization();
			PassiveFeatures.SpawnInitialization();
			WorkerSalary.SetupBaseSalary();
			Level.SetStartLevel(p_level);
		}

		public void SetEngagable()
		{
			FSM.enabled = false;
			IsEngaged = false;
			base.Animator.SetUpdateMode(AnimatorUpdateMode.UnscaledTime);
			_hireInformationCanvas.gameObject.SetActive(value: true);
			_hireInformationCanvas.UpdateInformations();
			base.transform.localScale = Vector3.one * 0.9f;
			_agentEyesBlinkControler.UseUnscaledDeltaTime = true;
		}

		public void Engage()
		{
			base.Animator.ReturnToIdle();
			base.Selection.Selectable = true;
			base.Material.SetKeyword(CTS.AgentVisual.Keyword("EMISSIVE_MASK_ON"), value: false);
			FSM.enabled = true;
			IsEngaged = true;
			base.Animator.SetUpdateMode(AnimatorUpdateMode.Normal);
			_hireInformationCanvas.gameObject.SetActive(value: false);
			base.transform.localScale = Vector3.one;
			_agentEyesBlinkControler.UseUnscaledDeltaTime = false;
			base.Tags.AddTag(EAgentTag.IsInside);
			WorkerList.Add(this);
			if (!PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				ChoreAssigner.SetCategoryPriority(ChoreCategory.Capture, 10);
				ChoreAssigner.TogglePriority(ChoreCategory.Capture, value: false);
			}
			if (!PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.ClearingMemory))
			{
				ChoreAssigner.SetCategoryPriority(ChoreCategory.Witnesses, 10);
				ChoreAssigner.TogglePriority(ChoreCategory.Witnesses, value: false);
			}
			base.RoomObject.TryFindCurrentRoom();
			if (TryGetComponent<SituationnalBarks>(out var component))
			{
				component.EnterBar();
			}
			Worker.WorkerSpawned?.Invoke(this);
		}

		public int GetCharismaCheck()
		{
			NumericStatistic numericStatistic = base.Statistics.GetNumericStatistic(EAgentStatistics.Charisma);
			int intValue = numericStatistic.IntValue;
			int num = (int)(numericStatistic.Max * 0.5f);
			if (intValue == num)
			{
				return 0;
			}
			bool flag = intValue > num;
			intValue = Math.Abs(intValue - num);
			if (UnityEngine.Random.Range(0, num) < intValue)
			{
				if (!flag)
				{
					return -1;
				}
				return 1;
			}
			return 0;
		}

		protected override void OnAgentSelected()
		{
			base.OnAgentSelected();
			Worker.OnSelect?.Invoke(this);
			MonoSingleton<AgentPanelGroup>.Instance.UpdateAgent(this);
		}

		protected override void OnAgentDeselected()
		{
			base.OnAgentDeselected();
			Worker.OnSelect?.Invoke(null);
			if (MonoSingleton<AgentPanelGroup>.InstanceExists())
			{
				MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
			}
		}

		public override void ClearObject()
		{
			InvokeDespawned();
			WorkerList.Remove(this);
			base.FurnitureAssignment.StopUsing();
			if ((bool)ControlledHuman)
			{
				SetControlledHuman(null);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnDestroy()
		{
			WorkerList.Remove(this);
			if (!IsEngaged && MonoSingleton<AgentPanelGroup>.InstanceExists() && MonoSingleton<AgentPanelGroup>.Instance.CurrentAgent == this)
			{
				MonoSingleton<AgentPanelGroup>.Instance.HidePanel();
			}
		}

		internal void SetControlledHuman(Customer p_human)
		{
			if ((bool)p_human && (bool)p_human.ControllingVampire)
			{
				if (p_human.ControllingVampire == this)
				{
					return;
				}
				p_human.ControllingVampire.SetControlledHuman(null);
			}
			if ((bool)ControlledHuman)
			{
				ControlledHuman.SetControllingVampire(null);
			}
			ControlledHuman = p_human;
			if ((bool)ControlledHuman)
			{
				ControlledHuman.SetControllingVampire(this);
			}
			else
			{
				base.VFXManager.Kill(VFXList.HypnosisTether);
			}
		}

		public void PayForDrink(int price)
		{
		}

		[Button(null, EButtonEnableMode.Always)]
		public void Dismiss()
		{
			if (IsEngaged)
			{
				WorkerList.Remove(this);
				IsEngaged = false;
				base.ActionPlayer.ForceAction(new AgentActionLeave(), (EActionPriority)10);
				base.Selection.Selectable = false;
				WorldSelector.Deselect(base.Selection.SelectableObject);
				MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(MonoSingleton<MoneyHandler>.Instance.CurrentMoney - Mathf.FloorToInt((float)Salary * MonoSingleton<CalendarHandlers>.Instance.ProgressPercentCurrentMonth));
				Worker.Fired?.Invoke(this);
			}
		}
	}
}
