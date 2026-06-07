using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Automation;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Flight;
using ModApi.Automation;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CommandPodScript : PartModifierScript<CommandPodData>, ICommandPod, IFlightStart, IGameLoopItem, IFlightFixedUpdate, ICommandPodScript, IFlightUpdate
	{
		private EventMigrator<ICommandPod> _activeCommandPodActivationGroupChangedChangedMigrator;

		private EventMigrator<ICraftScript> _activeCommandPodChangedMigrator;

		private EventMigrator<ICommandPod> _activeCommandPodStageActivatedMigrator;

		private float _alignmentLastFrame;

		private IFuelSource _battery;

		private float _powerConsumption;

		public List<string> ActivationGroupNames => base.Data.ActivationGroupNames;

		public IAutoPilot AutoPilot { get; set; }

		public bool AutoRecalculateStages
		{
			get
			{
				return base.Data.AutoRecalculateStages;
			}
			set
			{
				base.Data.AutoRecalculateStages = value;
			}
		}

		public IFuelSource BatteryFuelSource { get; set; }

		public CraftControls Controls { get; private set; }

		public ICraftConfiguration CraftConfiguration => base.Data.CraftConfiguration;

		public int CurrentStage => base.Data.CurrentStage;

		public IEvaScript EvaScript { get; private set; }

		public Func<int, bool> GetStageActivationPermission { get; set; }

		public bool IsEva { get; private set; }

		public bool IsPlayerControlled
		{
			get
			{
				if (base.PartScript.CraftScript.ActiveCommandPod == this)
				{
					return base.PartScript.CraftScript.CraftNode.IsPlayer;
				}
				return false;
			}
		}

		public IFuelSource JetFuelSource { get; set; }

		public IFuelSource MonoFuelSource { get; set; }

		public int NumStages { get; private set; }

		public PartData Part => base.PartScript.Data;

		public Transform PilotSeatOrientation { get; private set; }

		public ActivationGroupReplicationMode ReplicateActivationGroups
		{
			get
			{
				return base.Data.ReplicateActivationGroups;
			}
			set
			{
				base.Data.ReplicateActivationGroups = value;
			}
		}

		public bool ReplicateControls
		{
			get
			{
				return base.Data.ReplicateControls;
			}
			set
			{
				base.Data.ReplicateControls = value;
				RaiseCraftControlsChangedEvent();
			}
		}

		public bool ReplicateStageActivations
		{
			get
			{
				return base.Data.ReplicateStageActivations;
			}
			set
			{
				base.Data.ReplicateStageActivations = value;
				RaiseCraftControlsChangedEvent();
			}
		}

		public int StageCalculationVersion
		{
			get
			{
				return base.Data.StageCalculationVersion;
			}
			set
			{
				base.Data.StageCalculationVersion = value;
			}
		}

		public bool SupressSwitchedToCraftMessage
		{
			get
			{
				return base.Data.SupressSwitchedToCraftMessage;
			}
			set
			{
				base.Data.SupressSwitchedToCraftMessage = value;
			}
		}

		private bool ReorientControlsOnChanges { get; set; } = true;

		public event ActivationGroupChangedHandler ActivationGroupChanged;

		public event ControlsChangedHandler ControlsChanged;

		public event CommandPodIsPlayerControlledHandler IsPlayerControlledChanged;

		public event StageActivatedHandler StageActivated;

		public void ActivateStage()
		{
			int stageActivated = -1;
			if (CurrentStage <= NumStages && (GetStageActivationPermission == null || GetStageActivationPermission(CurrentStage)))
			{
				stageActivated = CurrentStage;
				foreach (PartData part in base.PartScript.CraftScript.Data.Assembly.Parts)
				{
					if (part.CommandPod == Part && !part.Activated && part.ActivationStage == base.Data.CurrentStage && part.Config.SupportsActivation && part.Config.StageActivationType != StageActivationType.None)
					{
						part.PartScript.Activate();
					}
				}
				base.Data.CurrentStage++;
				base.PartScript.CraftScript.SetStructureChanged();
			}
			this.StageActivated?.Invoke(this, stageActivated);
		}

		public void CreateControls(XElement controlsStateElement)
		{
			Controls = new CraftControls(this, controlsStateElement);
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			AutoPilot.Update(Controls.TargetHeading.HasValue && (BatteryFuelSource.TotalFuel > 0.0 || base.Data.PowerConsumption <= 0f), frame);
			if (!ReplicateControls)
			{
				return;
			}
			ICommandPod activeCommandPod = base.PartScript.CraftScript.ActiveCommandPod;
			if (activeCommandPod != null)
			{
				bool flag = activeCommandPod.IsEva && activeCommandPod.EvaScript.UnloadingFromCrewCompartmentInProgress;
				if (activeCommandPod != this && !flag)
				{
					CraftControls.CopyControls(activeCommandPod.Controls, Controls);
				}
				else if (activeCommandPod.IsEva && activeCommandPod.EvaScript.UnloadingFromCrewCompartmentInProgress)
				{
					CraftControls.ZeroControls(Controls);
				}
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_powerConsumption = 0f;
			if (_battery == null || !Part.Activated)
			{
				return;
			}
			ICommandPod activeCommandPod = base.PartScript.CraftScript.ActiveCommandPod;
			if (activeCommandPod == null || !activeCommandPod.IsEva)
			{
				CrewCompartmentData modifier = Part.GetModifier<CrewCompartmentData>();
				if ((modifier == null || modifier.Script.Crew.Count == 0) && base.Data.PowerConsumption != 0f)
				{
					_powerConsumption = base.Data.PowerConsumption * (Controls.TargetHeading.HasValue ? 1f : 0.1f) / 1000f;
					_battery.RemoveFuel(_powerConsumption * (float)frame.DeltaTimeWorld);
				}
			}
		}

		public void GenerateStateXml(XElement xml)
		{
			xml.Add(Controls.GenerateStateXml());
		}

		public bool GetActivationGroupState(int activationGroup)
		{
			int num = activationGroup - 1;
			if (num >= 0 && num < base.Data.ActivationGroupStates.Count)
			{
				return base.Data.ActivationGroupStates[num];
			}
			return false;
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			_battery = base.PartScript.BatteryFuelSource;
			RaiseCraftControlsChangedEvent();
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			if (Game.InDesignerScene && base.Data.UseDefaultPilotSeatRotation)
			{
				SetPilotSeatRotationToDefault(updatePartData: true, suppressEvent: true);
			}
			RaiseCraftControlsChangedEvent();
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnDesignerPullout(Assembly assembly)
		{
			base.OnDesignerPullout(assembly);
			if (base.Data.CraftConfigAutoAssign)
			{
				base.Data.SetCraftConfiguration(Game.Instance.Designer.ActiveCraftConfiguration, false);
			}
			SetPilotSeatRotationToDefault(updatePartData: true);
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			ICommandPod commandPod = this;
			model.Add(new TextModel("Player Control", () => (FlightSceneScript.Instance.CraftNode.CraftScript.ActiveCommandPod != commandPod) ? "No" : "Yes"));
			model.Add(new TextModel("Power Usage", () => Units.GetPowerString(_powerConsumption * 1000f)));
			model.Add(new TextButtonModel("Take Control", delegate
			{
				SetActiveCommandPod();
			}, null, () => FlightSceneScript.Instance.CraftNode.CraftScript.ActiveCommandPod != commandPod));
			model.Add(new TextModel("Config", () => CraftConfiguration.Type.ToString()));
			model.Add(new ToggleModel("Auto Config Controls", () => ReorientControlsOnChanges, delegate(bool x)
			{
				SetReorientControls(x);
			}, "Determines whether certain controls (ex. RCS) are re-evaluated when the craft configuration changes (staging, docking, etc).  Disable this to prevent controls from changing.  Toggling immediately causes controls to be re-evaluated/assigned."));
			model.Add(new ToggleModel("Replicate Commands", () => ReplicateControls, delegate(bool x)
			{
				ReplicateControls = x;
			}, "Determines whether this command pod will replicate inputs from the active pod when this command pod isn't active."));
			model.Add(new ToggleModel("Replicate Stage Act.", () => ReplicateStageActivations, delegate(bool x)
			{
				ReplicateStageActivations = x;
			}, "Determines whether this command pod will replicate stage activations from the active pod when this command pod isn't active."));
			model.Add(new EnumDropdownModel<ActivationGroupReplicationMode>("Replicate AG", () => ReplicateActivationGroups, "Determines how this command pod will replicate activation groups from the active command pod when this pod isn't active.")).ValueChanged += delegate(ActivationGroupReplicationMode newVal, ActivationGroupReplicationMode oldVal)
			{
				SetReplicateActivationGroups(newVal);
			};
		}

		public override void OnIsPlayerCraftChanged(bool isPlayer, ICraftNode other)
		{
			base.OnIsPlayerCraftChanged(isPlayer, other);
			if (base.PartScript.CraftScript.ActiveCommandPod == this)
			{
				this.IsPlayerControlledChanged?.Invoke(IsPlayerControlled, this, other.CraftScript.ActiveCommandPod);
			}
		}

		public override void OnModifiersCreated()
		{
			EvaScript = GetComponentInChildren<EvaScript>();
			IsEva = EvaScript != null;
			_activeCommandPodChangedMigrator = new EventMigrator<ICraftScript>(() => base.PartScript.CraftScript, delegate(ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged += OnActiveCommandPodChanged;
			}, delegate(ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged -= OnActiveCommandPodChanged;
			});
			_activeCommandPodChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICraftScript> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
			_activeCommandPodActivationGroupChangedChangedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CraftScript.ActiveCommandPod, delegate(ICommandPod activePod)
			{
				activePod.ActivationGroupChanged += OnActiveCommandPodActivationGroupChanged;
			}, delegate(ICommandPod activePod)
			{
				activePod.ActivationGroupChanged -= OnActiveCommandPodActivationGroupChanged;
			});
			_activeCommandPodActivationGroupChangedChangedMigrator.AddMigrationTrigger(() => base.PartScript.CraftScript, delegate(EventMigrator<ICommandPod> migrator, ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged -= migrator.MigrateEvent;
			});
			_activeCommandPodActivationGroupChangedChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
			_activeCommandPodStageActivatedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CraftScript.ActiveCommandPod, delegate(ICommandPod activePod)
			{
				activePod.StageActivated += OnActiveCommandPodStageActivated;
			}, delegate(ICommandPod activePod)
			{
				activePod.StageActivated -= OnActiveCommandPodStageActivated;
			});
			_activeCommandPodStageActivatedMigrator.AddMigrationTrigger(() => base.PartScript.CraftScript, delegate(EventMigrator<ICommandPod> migrator, ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, ICraftScript craftScript)
			{
				craftScript.ActiveCommandPodChanged -= migrator.MigrateEvent;
			});
			_activeCommandPodStageActivatedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.MovedToNewCraft -= migrator.MigrateEvent;
			});
			base.Data.UpdateOtherModifiersAndStuff();
		}

		public override void OnNodeLoaded()
		{
			base.OnNodeLoaded();
			Controls.TargetHeading = null;
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			_activeCommandPodActivationGroupChangedChangedMigrator?.Dispose();
			_activeCommandPodStageActivatedMigrator?.Dispose();
			_activeCommandPodChangedMigrator?.Dispose();
		}

		public void RecalculateNumStages()
		{
			int num = 0;
			foreach (PartData part in base.PartScript.CraftScript.Data.Assembly.Parts)
			{
				if (part.Config.StageActivationType != StageActivationType.None)
				{
					num = Mathf.Max(num, part.ActivationStage);
				}
			}
			NumStages = num + 1;
		}

		public void SetActivationGroupState(int activationGroup, bool state)
		{
			int num = activationGroup - 1;
			if (num < base.Data.ActivationGroupStates.Count && state != base.Data.ActivationGroupStates[num])
			{
				base.Data.ActivationGroupStates[num] = state;
				if (Game.InFlightScene)
				{
					ActivatePartsInActivationGroup(activationGroup, state);
				}
				this.ActivationGroupChanged?.Invoke(this, activationGroup, state);
			}
		}

		public void SetAutopilotEmulation(ICommandPod commandPodToEmulate)
		{
			base.Data.AutopilotEmulation = commandPodToEmulate;
		}

		public void SetPilotSeatRotation(Vector3 eulerAngles, bool updatePartData)
		{
			SetPilotSeatRotation(eulerAngles, updatePartData, suppressEvent: false);
		}

		public void SetPilotSeatRotationToDefault(bool updatePartData)
		{
			SetPilotSeatRotationToDefault(updatePartData, suppressEvent: false);
		}

		public void SetPilotSeatRotationToDefault(bool updatePartData, bool suppressEvent)
		{
			SetPilotSeatRotation(base.Data.CraftConfiguration.DefaultPilotOrientation, updatePartData, suppressEvent);
		}

		public override void ValidatePart(ValidationResult result)
		{
			if (_battery == null)
			{
				_battery = base.PartScript.BatteryFuelSource;
			}
			IFuelSource battery = _battery;
			if ((battery == null || battery.IsEmpty) && !IsEva)
			{
				CrewCompartmentData modifier = Part.GetModifier<CrewCompartmentData>();
				if (modifier == null || modifier.Capacity == 0)
				{
					result.AddPartWarning("NoBattery", base.PartScript.Data, "Needs battery to use autopilot");
				}
				else
				{
					result.AddPartWarning("LowBattery", base.PartScript.Data, "Needs battery and won't be able to use autopilot without crew inside");
				}
			}
		}

		protected override void OnDisposed()
		{
			base.OnDisposed();
			AutoPilot?.Dispose();
		}

		protected override void OnInitialized()
		{
			RecalculateNumStages();
			PilotSeatOrientation = new GameObject("PilotSeat").transform;
			PilotSeatOrientation.parent = base.transform;
			PilotSeatOrientation.localPosition = Vector3.zero;
			PilotSeatOrientation.localEulerAngles = base.Data.PilotSeatRotation;
			AutoPilot = new AutoPilot();
			AutoPilot.Initialize(this);
		}

		private static void SynchronizeActivationGroups(ICommandPod source, ICommandPod dest)
		{
			int num = Mathf.Min(source.ActivationGroupNames.Count, dest.ActivationGroupNames.Count);
			for (int i = 0; i < num; i++)
			{
				int activationGroup = i + 1;
				dest.SetActivationGroupState(activationGroup, source.GetActivationGroupState(activationGroup));
			}
		}

		private void ActivatePartsInActivationGroup(int activationGroup, bool state)
		{
			foreach (PartData part in base.PartScript.CraftScript.Data.Assembly.Parts)
			{
				if (part.ActivationGroup == activationGroup && state != part.Activated && part.CommandPod == Part)
				{
					if (state)
					{
						part.PartScript.Activate();
					}
					else
					{
						part.PartScript.Deactivate();
					}
				}
			}
		}

		private void OnActiveCommandPodActivationGroupChanged(ICommandPod source, int activationGroup, bool state)
		{
			if (source != this && ReplicateActivationGroups != ActivationGroupReplicationMode.None)
			{
				SetActivationGroupState(activationGroup, state);
			}
		}

		private void OnActiveCommandPodChanged(ICraftScript source, ICommandPod newPod, ICommandPod oldPod)
		{
			RaiseCraftControlsChangedEvent();
			if (ReplicateActivationGroups == ActivationGroupReplicationMode.All && base.PartScript.CraftScript.ActiveCommandPod != null)
			{
				SynchronizeActivationGroups(base.PartScript.CraftScript.ActiveCommandPod, this);
			}
			if ((oldPod == this || newPod == this) && base.PartScript.CraftScript.CraftNode.IsPlayer)
			{
				ICommandPod other = ((newPod == this) ? oldPod : newPod);
				this.IsPlayerControlledChanged?.Invoke(IsPlayerControlled, this, other);
			}
		}

		private void OnActiveCommandPodStageActivated(ICommandPod source, int stageActivated)
		{
			if (source != this && ReplicateStageActivations)
			{
				ActivateStage();
			}
		}

		private void RaiseCraftControlsChangedEvent()
		{
			this.ControlsChanged?.Invoke(this, ReorientControlsOnChanges);
		}

		private void SetActiveCommandPod()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance.ChangePlayersActiveCommandPodImmediate(this, base.PartScript.CraftScript.CraftNode))
			{
				instance.FlightSceneUI.ShowMessage("Switched to selected command pod.");
			}
			else
			{
				instance.FlightSceneUI.ShowMessage("Command pod is too far away to take control");
			}
		}

		private void SetPilotSeatRotation(Vector3 eulerAngles, bool updatePartData, bool suppressEvent)
		{
			PilotSeatOrientation.eulerAngles = eulerAngles;
			if (updatePartData)
			{
				base.Data.PilotSeatRotation = PilotSeatOrientation.localEulerAngles;
			}
			if (Game.InDesignerScene && !suppressEvent)
			{
				base.PartScript.CraftScript.SetStructureChanged();
			}
		}

		private void SetReorientControls(bool reorient)
		{
			ReorientControlsOnChanges = reorient;
			RaiseCraftControlsChangedEvent();
		}

		private void SetReplicateActivationGroups(ActivationGroupReplicationMode mode)
		{
			if (mode == ActivationGroupReplicationMode.All)
			{
				SynchronizeActivationGroups(base.PartScript.CraftScript.ActiveCommandPod, this);
			}
			ReplicateActivationGroups = mode;
		}
	}
}
