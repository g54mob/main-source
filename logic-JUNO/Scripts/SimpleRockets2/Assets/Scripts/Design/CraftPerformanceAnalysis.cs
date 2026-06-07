using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design.Staging;
using Assets.Scripts.State;
using ModApi;
using ModApi.CelestialData;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class CraftPerformanceAnalysis : IPerformanceAnalysis
	{
		private static double _altitudePercentage = 1.0;

		private SliderModel _altitudeSlider;

		private AtmosphereSample _atmosphereSample;

		private Vector2? _currentOffset;

		private DesignerScript _designer;

		private List<PerformanceEnvironment> _environments = new List<PerformanceEnvironment>();

		private IInspectorPanel _inspectorPanel;

		private GroupModel _partGroup;

		private bool _recalculateDimensions;

		private bool _recalculateStagingAnalysis;

		private bool _refreshPending;

		private int _selectedStage = -1;

		private StageAnalysis _stageAnalysis;

		public AtmosphereSample AtmosphereSample
		{
			get
			{
				return _atmosphereSample;
			}
			set
			{
				_atmosphereSample = value;
				this.EnvironmentChanged?.Invoke(this, EventArgs.Empty);
				UpdateOrDirtyStageAnalysisInspectorModel();
			}
		}

		public double AtmosphereSampleAltitudePercentage { get; private set; }

		public float MachNumber { get; private set; }

		public PerformanceEnvironment SelectedEnvironment { get; private set; }

		public string SelectedStageName { get; private set; }

		public bool ShowMachNumber { get; private set; }

		public StageAnalysis StageAnalysis
		{
			get
			{
				if (_recalculateStagingAnalysis || _stageAnalysis == null)
				{
					RecalculateStagingAnalysis();
				}
				return _stageAnalysis;
			}
		}

		public string StageAnalysisBurnTime { get; private set; }

		public string StageAnalysisDeltaV { get; private set; }

		public string StageAnalysisEndingTwr { get; private set; }

		public string StageAnalysisIsp { get; private set; }

		public string StageAnalysisNumEngines { get; private set; }

		public string StageAnalysisStartingTwr { get; private set; }

		public string StageAnalysisThrust { get; private set; }

		public string StagePropellantMass { get; private set; }

		public IPlanetData Star { get; private set; }

		public double StarDistance => SelectedEnvironment.GuesstimatedStarDistance;

		public bool Visible
		{
			get
			{
				return _inspectorPanel != null;
			}
			set
			{
				if (value)
				{
					if (_inspectorPanel == null)
					{
						RefreshInspectorPanel(immediate: true);
					}
				}
				else
				{
					ClosePanel();
				}
			}
		}

		private ICraftScript CraftScript => _designer.CraftScript;

		private Vector3 CraftSize
		{
			get
			{
				if (_recalculateDimensions)
				{
					_recalculateDimensions = false;
					(CraftScript as CraftScript).CalculateStartingBounds();
				}
				return CraftScript.Data.Size;
			}
		}

		public event EventHandler<EventArgs> EnvironmentChanged;

		public event EventHandler<EventArgs> StageAnalysisChanged;

		public event EventHandler<EventArgs> StagingChanged;

		public CraftPerformanceAnalysis(DesignerScript designer)
		{
			_designer = designer;
			_designer.SelectedPartChanged += OnSelectedPartChanged;
			_designer.CraftStructureChanged += OnCraftStructureChanged;
			_designer.CraftLoaded += OnCraftLoaded;
			InitializeEnvironments();
			SetAltitudePercentage(_altitudePercentage);
		}

		public void ClosePanel()
		{
			if (_inspectorPanel != null)
			{
				_currentOffset = _inspectorPanel.Position;
				_inspectorPanel.Close();
				_inspectorPanel = null;
			}
		}

		public void ConfigureForVacuum()
		{
			SetAltitudePercentage(1.0);
			ClosePanel();
		}

		public string GetAltitudeDisplayValue(AtmosphereSample sample)
		{
			if (!(sample.AirDensity > 0f))
			{
				return "Vacuum";
			}
			return $"{sample.SampleAltitude / 1000f:n1}km";
		}

		public void OnDestroy()
		{
			this.EnvironmentChanged = null;
			this.StageAnalysisChanged = null;
			this.StagingChanged = null;
		}

		public void OnLateUpdate()
		{
			if (_refreshPending)
			{
				RefreshInspectorPanel(immediate: true);
			}
		}

		public void OnStagingChanged()
		{
			UpdateOrDirtyStageAnalysisInspectorModel();
			this.StagingChanged?.Invoke(this, EventArgs.Empty);
		}

		public void RecalculateStaging()
		{
			new StageCalculator(CraftScript.PrimaryCommandPod).CalculateStages(CraftScript.Data.DesignerSettings.UserStages);
			OnStagingChanged();
		}

		public void SelectEnvironment(string planetName)
		{
			PerformanceEnvironment performanceEnvironment = _environments.Where((PerformanceEnvironment x) => x.Name == planetName).FirstOrDefault();
			if (performanceEnvironment == null)
			{
				performanceEnvironment = _environments.First();
			}
			SelectedEnvironment = performanceEnvironment;
		}

		public void SetAltitudePercentage(double percentage)
		{
			_altitudePercentage = percentage;
			AtmosphereSampleAltitudePercentage = percentage;
			UpdateAtmosphereSample();
		}

		public void SetGroupCollapsed(string name, bool collapsed)
		{
			GroupModel groupModel = _inspectorPanel?.Model?.Groups.Where((GroupModel x) => x.Name == name).FirstOrDefault();
			if (groupModel != null)
			{
				groupModel.Collapsed = collapsed;
			}
		}

		public void ToggleInspectorPanel()
		{
			Visible = !Visible;
		}

		private void AdvanceStage(SpinnerModel spinner, int direction)
		{
			_selectedStage += direction;
			UpdateStageAnalysisInspectorModel();
		}

		private void CreateCraftDetailsGroup(InspectorModel inspectorModel)
		{
			GroupModel groupModel = new GroupModel("Craft Details");
			ICraftScript craftScript = CraftScript;
			if (Game.IsCareer && !Game.Instance.GameState.Validator.IsItemAvailable("Cheats.SkipValidation"))
			{
				groupModel.Add(new TextModel("Available Funds", () => Units.GetPriceString(Game.Instance.GameState.AvailableFunds)));
			}
			groupModel.Add(new TextModel("Price", () => Units.GetPriceString(craftScript.Data.Price)));
			groupModel.Add(new TextModel("Mass", () => Units.GetMassString(craftScript.Mass)));
			groupModel.Add(new TextModel("Width", () => Units.GetDistanceString(CraftSize.x)));
			groupModel.Add(new TextModel("Height", () => Units.GetDistanceString(CraftSize.y)));
			groupModel.Add(new TextModel("Depth", () => Units.GetDistanceString(CraftSize.z)));
			groupModel.Add(new TextModel("Part Count", () => craftScript.Data.Assembly.Parts.Where((PartData x) => !x.PartScript.Disconnected).Count().ToString()));
			inspectorModel.AddGroup(groupModel);
		}

		private void CreateEnvironmentGroup(InspectorModel inspectorModel)
		{
			GroupModel groupModel = new GroupModel("Environment");
			groupModel.Collapsed = true;
			inspectorModel.AddGroup(groupModel);
			groupModel.Add(new SpinnerModel(() => SelectedEnvironment.Name, delegate
			{
				SelectNextEnvironment(1);
			}, delegate
			{
				SelectNextEnvironment(-1);
			})).ElementName = "Performance.Environment";
			_altitudeSlider = groupModel.Add(new SliderModel("Altitude", () => (float)AtmosphereSampleAltitudePercentage, delegate(float x)
			{
				SetAltitudePercentage(x);
			}));
			_altitudeSlider.ElementName = "Performance.Altitude";
			_altitudeSlider.ValueFormatter = (float x) => GetAltitudeDisplayValue(AtmosphereSample);
			SliderModel sliderModel = groupModel.Add(new SliderModel("Mach Number", () => MachNumber, delegate(float x)
			{
				OnMachChanged(x);
			}, 0f, 3f));
			sliderModel.ElementName = "Performance.Mach";
			sliderModel.ValueFormatter = (float x) => $"{x:n2}";
			sliderModel.DetermineVisibility = () => ShowMachNumber;
		}

		private void CreateInitialPartGroup(InspectorModel inspectorModel)
		{
			GroupModel groupModel = GeneratePartGroup();
			inspectorModel.AddGroup(groupModel);
			_partGroup = groupModel;
		}

		private void CreateStagingAnalysisGroup(InspectorModel inspectorModel)
		{
			GroupModel groupModel = new GroupModel("Staging Analysis");
			GenerateStagingAnalysisInspectorModel(groupModel);
			groupModel.Collapsed = true;
			inspectorModel.AddGroup(groupModel);
			UpdateStageAnalysisInspectorModel();
		}

		private GroupModel GeneratePartGroup()
		{
			bool flag = false;
			IPartScript selectedPart = _designer.SelectedPart;
			GroupModel groupModel = null;
			if (selectedPart != null)
			{
				groupModel = new GroupModel(selectedPart?.Data?.Name);
				if (selectedPart != null)
				{
					foreach (IAnalyzePerformance item in selectedPart.GetModifiersWithInterface<IAnalyzePerformance>())
					{
						flag |= item.UsesMachNumber;
						item.OnGeneratePerformanceAnalysisModel(groupModel);
					}
				}
			}
			else
			{
				groupModel = new GroupModel("Selected Part");
				groupModel.Add(new TextModel("No part selected"));
			}
			ShowMachNumber = flag;
			return groupModel;
		}

		private void GenerateStagingAnalysisInspectorModel(GroupModel group)
		{
			SpinnerModel spinner = new SpinnerModel(() => SelectedStageName);
			spinner.ElementName = "Performance.Stage.StageNumber";
			spinner.NextClicked = delegate
			{
				AdvanceStage(spinner, 1);
			};
			spinner.PrevClicked = delegate
			{
				AdvanceStage(spinner, -1);
			};
			group.Add(spinner);
			group.Add(new TextModel("Delta V", () => StageAnalysisDeltaV)).ElementName = "Performance.Stage.DeltaV";
			group.Add(new TextModel("Isp", () => StageAnalysisIsp)).ElementName = "Performance.Stage.Isp";
			group.Add(new TextModel("Burn Time", () => StageAnalysisBurnTime)).ElementName = "Performance.Stage.BurnTime";
			group.Add(new TextModel("Starting TWR", () => StageAnalysisStartingTwr)).ElementName = "Performance.Stage.StartingTWR";
			group.Add(new TextModel("Ending TWR", () => StageAnalysisEndingTwr)).ElementName = "Performance.Stage.EndingTWR";
			group.Add(new TextModel("Engines", () => StageAnalysisNumEngines)).ElementName = "Performance.Stage.Engines";
			group.Add(new TextModel("Thrust", () => StageAnalysisThrust)).ElementName = "Performance.Stage.Thrust";
			group.Add(new TextModel("Propellant Mass", () => StagePropellantMass)).ElementName = "Performance.Stage.PropellantMass";
		}

		private void InitializeEnvironments()
		{
			try
			{
				FlightStateData flightStateData = Game.Instance.GameState.LoadFlightStateData();
				CelestialFile file = Game.Instance.CelestialDatabase.GetFile(flightStateData.PlanetarySystemFileReference);
				if (file != null)
				{
					SolarSystemDataScript solarSystemDataScript = SolarSystemDataScript.CreateFromFile(file, createTerrainData: false, applyScaleAndOverrides: true);
					foreach (PlanetDataScript planet in solarSystemDataScript.Planets)
					{
						if (planet.Parent != null)
						{
							_environments.Add(new PerformanceEnvironment(planet));
						}
						else
						{
							Star = planet;
						}
					}
					UnityEngine.Object.Destroy(solarSystemDataScript);
					string planetName = Game.Instance.GameState.SelectedLaunchLocation?.PlanetName;
					SelectEnvironment(planetName);
				}
				else
				{
					Debug.LogError("The current flight state's planetary system could not be found.");
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void OnCraftLoaded()
		{
			OnStagingChanged();
			_recalculateDimensions = true;
			if (_inspectorPanel != null)
			{
				RefreshInspectorPanel(immediate: false);
			}
		}

		private void OnCraftStructureChanged()
		{
			if (CraftScript.PrimaryCommandPod.AutoRecalculateStages)
			{
				RecalculateStaging();
			}
			_recalculateDimensions = true;
			UpdateOrDirtyStageAnalysisInspectorModel();
		}

		private void OnInspectorPanelCloseButtonClicked(IInspectorPanel panel)
		{
			ClosePanel();
		}

		private void OnMachChanged(float value)
		{
			MachNumber = value;
			this.EnvironmentChanged?.Invoke(this, EventArgs.Empty);
			UpdateOrDirtyStageAnalysisInspectorModel();
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (_inspectorPanel != null && _partGroup != null)
			{
				GroupModel groupModel = GeneratePartGroup();
				_inspectorPanel.ReplaceGroup(_partGroup, groupModel);
				_partGroup = groupModel;
			}
		}

		private void RecalculateStagingAnalysis()
		{
			ICraftScript craftScript = CraftScript;
			if (craftScript != null)
			{
				StagingData stages = new StageCalculator(craftScript.PrimaryCommandPod).GetStages();
				_stageAnalysis = StageAnalyzer.Analyze(craftScript, stages, (float)SelectedEnvironment.SurfaceGravity);
				_recalculateStagingAnalysis = false;
				UpdateStageAnalysisInspectorModel();
			}
		}

		private void RefreshInspectorPanel(bool immediate)
		{
			if (!immediate || StageAnalysis == null)
			{
				_refreshPending = true;
				return;
			}
			_refreshPending = false;
			ClosePanel();
			InspectorPanelCreationInfo inspectorPanelCreationInfo = new InspectorPanelCreationInfo();
			inspectorPanelCreationInfo.StartPosition = InspectorPanelCreationInfo.InspectorStartPosition.UpperRight;
			inspectorPanelCreationInfo.Resizable = !Device.IsMobileBuild;
			if (_currentOffset.HasValue)
			{
				inspectorPanelCreationInfo.StartOffset = _currentOffset.Value;
			}
			else if (Device.IsMobileBuild)
			{
				inspectorPanelCreationInfo.StartOffset = new Vector2(-60f, 0f);
			}
			else
			{
				inspectorPanelCreationInfo.StartOffset = new Vector2(-60f, -100f);
			}
			inspectorPanelCreationInfo.PanelWidth = 300;
			inspectorPanelCreationInfo.PanelMaxHeight = 0.6f;
			InspectorModel inspectorModel = new InspectorModel("PerformanceAnalyzer", "Design Info");
			CreateCraftDetailsGroup(inspectorModel);
			CreateInitialPartGroup(inspectorModel);
			CreateStagingAnalysisGroup(inspectorModel);
			CreateEnvironmentGroup(inspectorModel);
			_inspectorPanel = Game.Instance.UserInterface.CreateInspectorPanel(inspectorModel, inspectorPanelCreationInfo);
			_inspectorPanel.CloseButtonClicked += OnInspectorPanelCloseButtonClicked;
		}

		private void SelectNextEnvironment(int direction)
		{
			int num = _environments.IndexOf(SelectedEnvironment);
			num += direction;
			if (num < 0)
			{
				num = _environments.Count - 1;
			}
			else if (num >= _environments.Count)
			{
				num = 0;
			}
			SelectedEnvironment = _environments[num];
			UpdateAtmosphereSample();
			_altitudeSlider.ForceRefreshValueText = true;
		}

		private void UpdateAtmosphereSample()
		{
			AtmosphereSample = SelectedEnvironment.Sample(AtmosphereSampleAltitudePercentage);
		}

		private void UpdateOrDirtyStageAnalysisInspectorModel()
		{
			_recalculateStagingAnalysis = true;
			this.StageAnalysisChanged?.Invoke(this, EventArgs.Empty);
			if (_inspectorPanel != null)
			{
				UpdateStageAnalysisInspectorModel();
			}
		}

		private void UpdateStageAnalysisInspectorModel()
		{
			if (_selectedStage >= StageAnalysis.Stages.Count)
			{
				_selectedStage = -1;
			}
			else if (_selectedStage < -1)
			{
				_selectedStage = StageAnalysis.Stages.Count - 1;
			}
			if (_selectedStage == -1)
			{
				StageAnalysis stageAnalysis = StageAnalysis;
				SelectedStageName = "All Stages";
				StageAnalysisDeltaV = Units.GetVelocityString(stageAnalysis.TotalDeltaV);
				StageAnalysisIsp = "N/A";
				StageAnalysisBurnTime = Units.GetRelativeTimeString(stageAnalysis.TotalBurnTime);
				StageAnalysisNumEngines = stageAnalysis.NumEngines.ToString();
				StageAnalysisThrust = Units.GetForceString(stageAnalysis.TotalThrust * 0.01f);
				StageAnalysisStartingTwr = Units.GetRatioString(stageAnalysis.StartingThrustToWeightRatio);
				StageAnalysisEndingTwr = Units.GetRatioString(stageAnalysis.EndingThrustToWeightRatio);
				StagePropellantMass = Units.GetMassString(stageAnalysis.PropellantMass * 0.01f);
			}
			else
			{
				StageAnalysis.Stage stage = StageAnalysis.Stages[_selectedStage];
				SelectedStageName = $"Stage {stage.StageNumber}";
				StageAnalysisDeltaV = Units.GetVelocityString(stage.DeltaV);
				StageAnalysisIsp = Units.GetIspString(stage.AverageEngineIsp);
				StageAnalysisBurnTime = Units.GetRelativeTimeString(stage.BurnTime);
				StageAnalysisNumEngines = stage.NumEngines.ToString();
				StageAnalysisThrust = Units.GetForceString(stage.TotalThrust * 0.01f);
				StageAnalysisStartingTwr = Units.GetRatioString(stage.StartingThrustToWeightRatio);
				StageAnalysisEndingTwr = Units.GetRatioString(stage.EndingThrustToWeightRatio);
				StagePropellantMass = Units.GetMassString(stage.PropellantMass * 0.01f);
			}
		}
	}
}
