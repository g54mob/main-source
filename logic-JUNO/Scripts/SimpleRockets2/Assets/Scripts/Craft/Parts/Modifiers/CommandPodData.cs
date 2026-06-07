using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Automation;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties;
using Assets.Scripts.Design.Tools;
using Jundroo.ModTools.Serialization.Xml;
using ModApi;
using ModApi.Automation;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Propulsion;
using ModApi.Design.PartProperties;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Command", typeof(CommandPodPartProperties))]
	public class CommandPodData : PartModifierData<CommandPodScript>
	{
		public delegate void CraftConfigChangedHandler(ICraftConfiguration newMode, ICraftConfiguration oldMode);

		public const string AutoPilotPidDerivativeDesc = "Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.";

		public const string AutoPilotPidIntegralDesc = "Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.";

		public const string AutoPilotPidProportionalDesc = "The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.";

		public const string AutoPilotPidRangeDesc = "Adjusts the range of the PID sliders in the UI...does not impact flight performance.";

		private const string AutoPilotAgressivenessDesc = "Adjusts how agressive auto-pilot reacts to errors for the given axis.  This may need to be lowered for higly maneuverable aircraft, or oscillations will occur.";

		private const int AutoPilotOrderNumAgressiveness = 12;

		private const int AutoPilotOrderNumPidPitch = 14;

		private const int AutoPilotOrderNumPidRoll = 18;

		private const int AutoPilotOrderNumStart = 10;

		private const string AutoPilotPidDesc = "Auto-pilot uses a \"PID\" controller, which has 3 main components Proportional, Integral, and Derivative.  They can be adjusted while in-flight to determine optimal values (View Panel->Auto-Pilot), and can then be adjusted here to save with the craft.\nThe difficult part of pid tuning is controlling oscillation when the craft is nearly on-target.  The values should typically be large enough to produce the desired response rate without introducing oscillation, at a variety of airspeeds.  All may introduce oscillation if they're too high.\n\nGeneral advice to begin tuning - While in flight, start with integral and derivative at zero.  Adjust proportional until desired response rate is achieved, and oscillation is minimized (may not be able to eliminate).  Increase derivative until overshoot/oscillation is minimized.  Add integral until any persistent error scenarios are addressed while keeping oscillation to a minimum. Tip: Display input sliders to monitor oscillation in inputs.";

		[DesignerPropertySlider(0f, 200f, 201, PreserveState = false, NeverSerialize = true, Label = "Range", Order = 15, Tooltip = "Adjusts the range of the PID sliders in the UI...does not impact flight performance.")]
		private float _autoPilotMaxPitchPid = 100f;

		[DesignerPropertySlider(0f, 200f, 201, PreserveState = false, NeverSerialize = true, Label = "Range", Order = 19, Tooltip = "Adjusts the range of the PID sliders in the UI...does not impact flight performance.")]
		private float _autoPilotMaxRollPid = 100f;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Derivative", Order = 18, Tooltip = "Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.")]
		private float _autoPilotPitchDerivative = 50f;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Integral", Order = 17, Tooltip = "Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.")]
		private float _autoPilotPitchIntegral;

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Label = "Pitch", Order = 14)]
		private string _autoPilotPitchPidLabel = string.Empty;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Proportional", Order = 16, Tooltip = "The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.")]
		private float _autoPilotPitchProportional;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Derivative", Order = 22, Tooltip = "Used to reduce overshooting/oscillations, although excessive amounts will introduce oscillation. Highly maneuverable crafts will not tolerate much if any derivative without introducing oscillation.")]
		private float _autoPilotRollDerivative;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Integral", Order = 21, Tooltip = "Attempts to compensate for cases where the proportional is not sufficient to maintain the target. Not typically recommended for roll.")]
		private float _autoPilotRollIntegral;

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Label = "Roll", Order = 18)]
		private string _autoPilotRollPidLabel = string.Empty;

		[DesignerPropertySlider(0f, 1f, 101, PreserveState = false, NeverSerialize = true, Label = "Proportional", Order = 20, Tooltip = "The primary value which dictates how strongly the auto-pilot reacts to errors.  Craft with large control lag will need proportional reduced considerably below the craft's maximum rate to get oscillation to an acceptable level.")]
		private float _autoPilotRollProportional;

		[DesignerPropertyLabel(Header = "Auto Pilot", HeaderCollapsed = true, PreserveState = false, NeverSerialize = true, Order = 10, Tooltip = "Auto-pilot uses a \"PID\" controller, which has 3 main components Proportional, Integral, and Derivative.  They can be adjusted while in-flight to determine optimal values (View Panel->Auto-Pilot), and can then be adjusted here to save with the craft.\nThe difficult part of pid tuning is controlling oscillation when the craft is nearly on-target.  The values should typically be large enough to produce the desired response rate without introducing oscillation, at a variety of airspeeds.  All may introduce oscillation if they're too high.\n\nGeneral advice to begin tuning - While in flight, start with integral and derivative at zero.  Adjust proportional until desired response rate is achieved, and oscillation is minimized (may not be able to eliminate).  Increase derivative until overshoot/oscillation is minimized.  Add integral until any persistent error scenarios are addressed while keeping oscillation to a minimum. Tip: Display input sliders to monitor oscillation in inputs.")]
		private string _descriptionLabel = "Adjust these settings to fine-tune how the auto-pilot controls the craft.";

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = (XmlSerializationFlags.SingleAttribute | XmlSerializationFlags.KeepEmptyEntries))]
		private List<string> _activationGroupNames = new List<string>();

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private List<bool> _activationGroupStates = new List<bool>();

		private IAutoPilot _autoPilotBackup;

		private Vector3 _autoPilotBackupPidGainPitch;

		private Vector3 _autoPilotBackupPidGainRoll;

		private CommandPodScript _autoPilotEmulation;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _autoRecalculateStages = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _configurableContents;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 101, Label = "Volume for Battery", Order = 1, Tooltip = "Define the percentage of the available volume to use for batteries.", TechTreeIdForMaxValue = "Command.Battery")]
		private float _configureBattery;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 101, Label = "Volume for Gyros", Order = 2, Tooltip = "Define the percentage of the available volume to use for gyroscopes.", TechTreeIdForMaxValue = "Command.Gyro")]
		private float _configureGyros;

		private XElement _controlsStateElement;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _craftConfigAutoAssign = true;

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Rocket", "Plane" }, Label = "Configuration", Order = 0, Tooltip = "Changes the configuration of a craft. The configuration is used to drive various functions such as pilot orientation, rotation when certain parts are pulled out, and some default settings for parts.", IsHidden = false)]
		private CrafConfigurationType _craftConfigType;

		private ICraftConfiguration _craftConfiguration;

		[SerializeField]
		[HideInInspector]
		[PartModifierProperty(true, false)]
		private int _currentStage;

		private Vector3 _originalPilotSeatRotation;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _pidPitch;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _pidRoll;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _pilotSeatRotation;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _powerConsumption;

		[DesignerPropertyCenterButton(Order = 5, PreserveState = false, NeverSerialize = true, Label = "Set Primary", Tooltip = "Assigns this as the primary command pod for the craft. The primary command pod will control all parts in the craft, except for those added from a previously made subassembly that included its own command pod.\nNote: The primary command pod cannot be deleted.")]
		private bool _primaryButton;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Reorient On Config Change", Order = 54, Tooltip = "If enabled, the craft in the designer will rotate when the configuration type changes (Plane/Rocket).  You would want to disable this if a craft is already oriented correctly but it needs to have its configuration type changed.  This option does not impact operation during flight.")]
		private bool _reorientCraftOnConfigChange = true;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Replicate AG", Order = 53, Tooltip = "Determines how this command pod will replicate activation groups from the active command pod when this pod isn't active.")]
		private ActivationGroupReplicationMode _replicateActivationGroups;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Replicate Commands", Order = 50, Header = "Control Settings", HeaderCollapsed = true, Tooltip = "Determines whether this command pod will replicate inputs from the active pod when this command pod isn't active.")]
		private bool _replicateControls;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Replicate Stage Act", Order = 52, Tooltip = "Determines whether this command pod will replicate stage activations from the active pod when this command pod isn't active.")]
		private bool _replicateStageActivations;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _stageCalculationVersion;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _useDefaultPilotSeatRotation = true;

		public List<string> ActivationGroupNames => _activationGroupNames;

		public List<bool> ActivationGroupStates => _activationGroupStates;

		public ICommandPod AutopilotEmulation
		{
			get
			{
				return _autoPilotEmulation;
			}
			set
			{
				CommandPodScript commandPodScript = value as CommandPodScript;
				bool num = _autoPilotEmulation != commandPodScript;
				_autoPilotEmulation = commandPodScript;
				if (num)
				{
					CommandPodScript script = base.Script;
					Vector3 euler;
					if (_autoPilotEmulation != null)
					{
						euler = (Quaternion.Inverse(base.Script.transform.rotation) * _autoPilotEmulation.PilotSeatOrientation.rotation).eulerAngles;
						AutoPilot source = commandPodScript.AutoPilot as AutoPilot;
						_autoPilotBackup = script.AutoPilot;
						_autoPilotBackupPidGainPitch = commandPodScript.Data.PidGainPitch;
						_autoPilotBackupPidGainRoll = commandPodScript.Data.PidGainRoll;
						script.AutoPilot = new AutoPilot();
						script.AutoPilot.Initialize(script, source);
						PidGainPitch = commandPodScript.Data.PidGainPitch;
						PidGainRoll = commandPodScript.Data.PidGainRoll;
					}
					else
					{
						euler = _originalPilotSeatRotation;
						script.AutoPilot?.Dispose();
						script.AutoPilot = _autoPilotBackup;
						script.Data.PidGainPitch = _autoPilotBackupPidGainPitch;
						script.Data.PidGainRoll = _autoPilotBackupPidGainRoll;
					}
					Quaternion quaternion = base.Script.transform.rotation * Quaternion.Euler(euler);
					base.Script.SetPilotSeatRotation(quaternion.eulerAngles, updatePartData: false);
				}
			}
		}

		public bool AutoRecalculateStages
		{
			get
			{
				return _autoRecalculateStages;
			}
			set
			{
				_autoRecalculateStages = value;
			}
		}

		public float Battery
		{
			get
			{
				return _configureBattery;
			}
			set
			{
				_configureBattery = value;
				_configureGyros = Math.Min(_configureGyros, 1f - _configureBattery);
				UpdateOtherModifiersAndStuff();
				base.Part?.PartScript?.CraftScript?.SetStructureChanged();
			}
		}

		public float Gyros
		{
			get
			{
				return _configureGyros;
			}
			set
			{
				_configureGyros = value;
				_configureBattery = Math.Min(_configureBattery, 1f - _configureGyros);
				UpdateOtherModifiersAndStuff();
				base.Part?.PartScript?.CraftScript?.SetStructureChanged();
			}
		}

		public bool CraftConfigAutoAssign
		{
			get
			{
				return _craftConfigAutoAssign;
			}
			set
			{
				_craftConfigAutoAssign = value;
			}
		}

		public ICraftConfiguration CraftConfiguration
		{
			get
			{
				if (!(_autoPilotEmulation == null))
				{
					return _autoPilotEmulation.Data.CraftConfiguration;
				}
				return _craftConfiguration;
			}
			private set
			{
				_craftConfiguration = value;
				_craftConfigType = value.Type;
			}
		}

		public int CurrentStage
		{
			get
			{
				return _currentStage;
			}
			set
			{
				_currentStage = value;
			}
		}

		public Vector3 PidGainPitch
		{
			get
			{
				return _pidPitch;
			}
			set
			{
				_pidPitch = value;
			}
		}

		public Vector3 PidGainRoll
		{
			get
			{
				return _pidRoll;
			}
			set
			{
				_pidRoll = value;
			}
		}

		public Vector3 PilotSeatRotation
		{
			get
			{
				if (!(_autoPilotEmulation == null))
				{
					return _autoPilotEmulation.Data.PilotSeatRotation;
				}
				return _pilotSeatRotation;
			}
			set
			{
				_pilotSeatRotation = value;
			}
		}

		public float PowerConsumption => _powerConsumption;

		public bool ReOrientCraftOnConfigChange => _reorientCraftOnConfigChange;

		public ActivationGroupReplicationMode ReplicateActivationGroups
		{
			get
			{
				return _replicateActivationGroups;
			}
			set
			{
				_replicateActivationGroups = value;
			}
		}

		public bool ReplicateControls
		{
			get
			{
				return _replicateControls;
			}
			set
			{
				_replicateControls = value;
			}
		}

		public bool ReplicateStageActivations
		{
			get
			{
				return _replicateStageActivations;
			}
			set
			{
				_replicateStageActivations = value;
			}
		}

		public int StageCalculationVersion
		{
			get
			{
				return _stageCalculationVersion;
			}
			set
			{
				_stageCalculationVersion = value;
			}
		}

		public bool SupressSwitchedToCraftMessage { get; set; }

		public bool UseDefaultPilotSeatRotation
		{
			get
			{
				return _useDefaultPilotSeatRotation;
			}
			set
			{
				_useDefaultPilotSeatRotation = value;
				if (_useDefaultPilotSeatRotation)
				{
					base.Part.PartScript.GetModifier<CommandPodScript>().SetPilotSeatRotationToDefault(updatePartData: true);
				}
			}
		}

		public event CraftConfigChangedHandler CraftConfigChanged;

		private void UpdateDesignerPropertiesFromPids()
		{
			_autoPilotPitchProportional = _pidPitch.x / _autoPilotMaxPitchPid;
			_autoPilotPitchIntegral = _pidPitch.y / _autoPilotMaxPitchPid;
			_autoPilotPitchDerivative = _pidPitch.z / _autoPilotMaxPitchPid;
			_autoPilotRollProportional = _pidRoll.x / _autoPilotMaxRollPid;
			_autoPilotRollIntegral = _pidRoll.y / _autoPilotMaxRollPid;
			_autoPilotRollDerivative = _pidRoll.z / _autoPilotMaxRollPid;
			base.DesignerPartProperties?.Manager?.RefreshUI();
		}

		private void UpdatePidsFromDesignerProperties()
		{
			_pidPitch = new Vector3(_autoPilotPitchProportional * _autoPilotMaxPitchPid, _autoPilotPitchIntegral * _autoPilotMaxPitchPid, _autoPilotPitchDerivative * _autoPilotMaxPitchPid);
			_pidRoll = new Vector3(_autoPilotRollProportional * _autoPilotMaxRollPid, _autoPilotRollIntegral * _autoPilotMaxRollPid, _autoPilotRollDerivative * _autoPilotMaxRollPid);
		}

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = base.GenerateStateXml(optimizeXml);
			base.Script?.GenerateStateXml(xElement);
			return xElement;
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			if (ActivationGroupNames.Count < 10)
			{
				while (ActivationGroupNames.Count < 10)
				{
					ActivationGroupNames.Add(string.Empty);
				}
				ActivationGroupNames[9] = "RCS";
				ActivationGroupNames[8] = "Solar Panels";
				ActivationGroupNames[7] = "Landing Gear";
			}
			while (ActivationGroupStates.Count < ActivationGroupNames.Count)
			{
				bool item = ActivationGroupNames[ActivationGroupStates.Count] == "RCS" || ActivationGroupNames[ActivationGroupStates.Count] == "Landing Gear";
				ActivationGroupStates.Add(item);
			}
			_controlsStateElement = stateElement.Element("Controls");
			if (stateElement.Attribute("_pidPitch".Remove(0, 1)) == null)
			{
				GetDefaultPids(out _pidPitch, out _pidRoll);
			}
			if (Game.InDesignerScene)
			{
				UpdateDesignerPropertiesFromPids();
			}
		}

		public void SetCraftConfiguration(ICraftConfiguration newConfig, bool? reorientCraft)
		{
			ICraftConfiguration craftConfiguration = CraftConfiguration;
			ICraftScript craftScript = base.Script.PartScript.CraftScript;
			CraftConfiguration = newConfig;
			if (Game.InDesignerScene)
			{
				Game.Instance.Designer.CreateUndoStep("SetCraftConfiguration");
			}
			bool valueOrDefault = reorientCraft == true;
			if (!reorientCraft.HasValue)
			{
				valueOrDefault = _reorientCraftOnConfigChange;
				reorientCraft = valueOrDefault;
			}
			if (reorientCraft.Value)
			{
				if (craftScript.RootPart == base.Part.PartScript)
				{
					Transform transform = craftScript.Transform;
					Utilities.UnityTransform.RotateChildrenAround(transform, transform.position, newConfig.PartPulloutRotation - craftConfiguration.PartPulloutRotation);
				}
				else
				{
					PartSelection partSelection = new PartSelection(PartGraph.GetPartsConnectedToPartButNotConnectedToRootPart(base.Part.PartScript).ConvertAll((PartData x) => x.PartScript), base.Part.PartScript.Transform.position, Quaternion.identity);
					Transform containerParent = partSelection.ContainerParent;
					Utilities.UnityTransform.RotateChildrenAround(containerParent, containerParent.position, newConfig.PartPulloutRotation - craftConfiguration.PartPulloutRotation);
					partSelection.Deselect();
				}
			}
			this.CraftConfigChanged?.Invoke(newConfig, craftConfiguration);
		}

		public void UpdateOtherModifiersAndStuff()
		{
			FuselageScript fuselageScript = base.Part?.PartScript?.GetModifier<FuselageScript>();
			if (_configurableContents && fuselageScript != null)
			{
				FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
				if (modifier != null)
				{
					modifier.Utilization = (1f - FuelType.Battery.StorageOverhead) * _configureBattery;
				}
				GyroscopeData modifier2 = base.Part.GetModifier<GyroscopeData>();
				if (modifier2 != null)
				{
					modifier2.Utilization = 0.7f * _configureGyros;
					modifier2.Script?.CalculateMassAndPowerFromFuselage();
				}
				fuselageScript.UpdateFuel();
			}
		}

		protected override CommandPodScript CreateScriptComponent(IPartScript partScript)
		{
			CommandPodScript commandPodScript = base.CreateScriptComponent(partScript);
			commandPodScript.CreateControls(_controlsStateElement);
			_controlsStateElement = null;
			return commandPodScript;
		}

		protected override void OnCreated(XElement partModifierXml)
		{
			base.OnCreated(partModifierXml);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnVisibilityRequested(() => _primaryButton, (bool x) => !base.Part.IsRootPart);
			d.OnPropertyChanged(() => _primaryButton, delegate
			{
				CraftScript craftScript = base.Part.PartScript.CraftScript as CraftScript;
				ICommandPod script = base.Script;
				if (craftScript.RootPart != base.Part.PartScript)
				{
					craftScript.SetPrimaryCommandPod(script);
				}
			});
			d.OnVisibilityRequested(() => _configureBattery, (bool x) => _configurableContents);
			d.OnPropertyChanged(() => _configureBattery, delegate(float newValue, float oldValue)
			{
				Battery = newValue;
			});
			d.OnVisibilityRequested(() => _configureGyros, (bool x) => _configurableContents);
			d.OnPropertyChanged(() => _configureGyros, delegate(float newValue, float oldValue)
			{
				Gyros = newValue;
			});
			d.OnVisibilityRequested(() => _autoPilotMaxRollPid, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnVisibilityRequested(() => _autoPilotPitchPidLabel, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnVisibilityRequested(() => _autoPilotRollPidLabel, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnVisibilityRequested(() => _autoPilotRollProportional, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnVisibilityRequested(() => _autoPilotRollIntegral, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnVisibilityRequested(() => _autoPilotRollDerivative, (bool x) => _craftConfigType == CrafConfigurationType.Plane);
			d.OnValueLabelRequested(() => _configureBattery, (float x) => GetBatteryLabel(x));
			d.OnValueLabelRequested(() => _configureGyros, (float x) => GetGyroPowerLabel(x));
			d.OnValueLabelRequested(() => _autoPilotRollProportional, (float x) => PidGainRoll.x.ToString("0.##"));
			d.OnValueLabelRequested(() => _autoPilotRollIntegral, (float x) => PidGainRoll.y.ToString("0.##"));
			d.OnValueLabelRequested(() => _autoPilotRollDerivative, (float x) => PidGainRoll.z.ToString("0.##"));
			d.OnValueLabelRequested(() => _autoPilotPitchProportional, (float x) => PidGainPitch.x.ToString("0.##"));
			d.OnValueLabelRequested(() => _autoPilotPitchIntegral, (float x) => PidGainPitch.y.ToString("0.##"));
			d.OnValueLabelRequested(() => _autoPilotPitchDerivative, (float x) => PidGainPitch.z.ToString("0.##"));
			d.OnPropertyChanged(() => _autoPilotMaxPitchPid, delegate
			{
				UpdateDesignerPropertiesFromPids();
			});
			d.OnPropertyChanged(() => _autoPilotMaxRollPid, delegate
			{
				UpdateDesignerPropertiesFromPids();
			});
			d.OnPropertyChanged(() => _autoPilotPitchProportional, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _autoPilotPitchIntegral, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _autoPilotPitchDerivative, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _autoPilotRollProportional, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _autoPilotRollIntegral, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _autoPilotRollDerivative, delegate
			{
				UpdatePidsFromDesignerProperties();
			});
			d.OnPropertyChanged(() => _craftConfigType, OnCraftConfigChanged);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_originalPilotSeatRotation = _pilotSeatRotation;
			CraftConfiguration = CreateCraftConfig(_craftConfigType);
		}

		private static ICraftConfiguration CreateCraftConfig(CrafConfigurationType type)
		{
			ICraftConfiguration result;
			switch (type)
			{
			case CrafConfigurationType.Plane:
				result = new CraftConfiguration(CrafConfigurationType.Plane, "Plane", Vector3.zero, new Vector3(90f, 0f, 0f));
				break;
			case CrafConfigurationType.Rocket:
				result = new CraftConfiguration(CrafConfigurationType.Rocket, "Rocket", new Vector3(-90f, 0f, 0f), Vector3.zero);
				break;
			default:
				result = CreateCraftConfig(CrafConfigurationType.Rocket);
				Debug.LogError($"Cannot auto-create craft configuartion of type \"{type}\"");
				break;
			}
			return result;
		}

		private string GetBatteryLabel(float x)
		{
			FuelTankData modifier = base.Part.GetModifier<FuelTankData>();
			if (modifier?.FuelType == FuelType.Battery)
			{
				return Units.GetEnergyString((float)modifier.Fuel * 1000f) + " / " + Utilities.FormatPercentage(x);
			}
			return Utilities.FormatPercentage(x) ?? "";
		}

		private void GetDefaultPids(out Vector3 pidPitch, out Vector3 pidRoll)
		{
			if (_craftConfigType == CrafConfigurationType.Plane)
			{
				pidPitch = new Vector3(10f, 0f, 0f);
				pidRoll = new Vector3(0.6f, 0f, 0f);
			}
			else
			{
				pidRoll = (pidPitch = new Vector3(10f, 0f, 25f));
			}
		}

		private string GetGyroPowerLabel(float x)
		{
			GyroscopeData modifier = base.Part.GetModifier<GyroscopeData>();
			if (modifier != null)
			{
				return Units.GetTorqueString(modifier.Power) + " / " + Utilities.FormatPercentage(x);
			}
			return Utilities.FormatPercentage(x) ?? "";
		}

		private void OnCraftConfigChanged(CrafConfigurationType newType, CrafConfigurationType oldType)
		{
			SetCraftConfiguration(CreateCraftConfig(newType), null);
			GetDefaultPids(out _pidPitch, out _pidRoll);
			base.Script.PartScript.CraftScript.SetStructureChanged();
			UpdateDesignerPropertiesFromPids();
			base.DesignerPartProperties.Manager.RefreshUI();
			(Game.Instance.Designer as DesignerScript).SetDefaultGizmosForCurrentPart();
		}
	}
}
