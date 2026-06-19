#define LOG_LEVEL_VERBOSE
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class HospitalPlot : MustCallDestroy
	{
		private readonly Level _level;

		private readonly WorldState _worldState;

		private readonly HospitalPlotDefinition _definition;

		private bool _bought;

		private PlotState _state;

		[CanBeNull]
		private HospitalMap _hospitalMap;

		private float _timeLeftToBuild;

		private bool _tilesBuilt;

		private bool[] _hiddenLayers = new bool[3] { false, false, true };

		private bool _challengeActive;

		[DontSave]
		private HospitalPlotFootprintMesh _footprintMesh;

		[DontSave]
		private ParticleSystem _buildingParticleSystem;

		[DontSave]
		private AudioEmitter _landPlotBuildLoop;

		public static bool DisableMerging;

		public HospitalPlotDefinition Definition => _definition;

		[CanBeNull]
		public HospitalMap HospitalMap => _hospitalMap;

		public bool Built => _state == PlotState.Built;

		public bool Building => _state == PlotState.Building;

		public bool Bought => _bought;

		public float TimeLeftToBuild => _timeLeftToBuild;

		public bool ChallengeActive => _challengeActive;

		public HospitalPlot(HospitalPlotDefinition definition, WorldState worldState, Level level)
		{
			_level = level;
			_worldState = worldState;
			_definition = definition;
			_bought = _definition.InitiallyOpen;
			_state = InitialState();
			SetLayerVisibilityBasedOnState();
			RefreshHospitalMap(animateWalls: false);
			if (_definition.BuildObjectiveAutoStart)
			{
				Level level2 = _level;
				level2.PostConstruct = (Action)Delegate.Combine(level2.PostConstruct, new Action(StartChallenge));
			}
		}

		private PlotState InitialState()
		{
			if (!_definition.InitiallyOpen)
			{
				if (!_definition.Built)
				{
					return PlotState.Unbuilt;
				}
				return PlotState.Built;
			}
			return PlotState.Built;
		}

		private void SetLayerVisibilityBasedOnState()
		{
			_hiddenLayers[0] = false;
			switch (_state)
			{
			case PlotState.Unbuilt:
			case PlotState.Building:
				_hiddenLayers[1] = true;
				_hiddenLayers[2] = false;
				break;
			case PlotState.Built:
				_hiddenLayers[1] = false;
				_hiddenLayers[2] = true;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private bool IsMergePlot()
		{
			return Definition.MergeInto.NotNull();
		}

		private void RefreshHospitalMap(bool animateWalls, bool build = true)
		{
			bool num = !DisableMerging && _bought && _state == PlotState.Built && IsMergePlot();
			Logging.Info(LogChannels.Building, "Refreshing plot " + Definition.NameLocalised.Translation);
			if (num)
			{
				HospitalPlotDefinition instance = Definition.MergeInto.Instance;
				foreach (HospitalPlot hospitalPlot in _worldState.HospitalPlots)
				{
					if (hospitalPlot.Definition == instance)
					{
						if (hospitalPlot.HospitalMap != null)
						{
							Logging.Info(LogChannels.Building, "Merging plot " + Definition.NameLocalised.Translation + " into plot " + hospitalPlot.Definition.NameLocalised.Translation);
							hospitalPlot.HospitalMap.Merge(this, build);
						}
						if (_hospitalMap != null)
						{
							Logging.Info(LogChannels.Building, "Destroying plot " + hospitalPlot.Definition.NameLocalised.Translation + " after merge");
							_worldState.DestroyHospitalMap(_hospitalMap);
							_hospitalMap = null;
						}
						return;
					}
				}
			}
			if (_hospitalMap != null)
			{
				Logging.Info(LogChannels.Building, "Destroy plot " + _hospitalMap.Plot.Definition.NameLocalised.Translation);
				_worldState.DestroyHospitalMap(_hospitalMap);
				_hospitalMap = null;
			}
			_hospitalMap = _worldState.CreateHospitalMap(this, animateWalls && !Definition.InstaBuild);
			if (_hospitalMap != null)
			{
				Logging.Info(LogChannels.Building, "Created plot " + _hospitalMap.Plot.Definition.NameLocalised.Translation);
			}
			if (_state == PlotState.Built)
			{
				_worldState.SetBuiltHospitalMap(_hospitalMap);
			}
			else
			{
				_worldState.SetUnbuiltHospitalPlot(_hospitalMap);
			}
			if (!_bought && _state == PlotState.Built && _hospitalMap != null)
			{
				_hospitalMap.Room.Close();
			}
		}

		public void Update(float deltaTime)
		{
			if (_state == PlotState.Building)
			{
				_timeLeftToBuild -= deltaTime;
				if (!_tilesBuilt && _timeLeftToBuild < Definition.TimeToBuild * 0.25f)
				{
					_tilesBuilt = true;
					_state = PlotState.Built;
					if (_hospitalMap != null)
					{
						_hospitalMap.RoomVisual.CreateFloorTileObjects(GetRoomDefinition()._roomFloorTile);
					}
					if (_hospitalMap != null && !Definition.InstaBuild)
					{
						_hospitalMap.RoomVisual.TriggerFloorConstructionAnimations(_hospitalMap.FloorPlan.WorldBounds.Min);
						AudioManager.Instance.Play("LandPlotTilesDown", _hospitalMap.RoomVisual.GameObject);
					}
					_state = PlotState.Building;
					if (_buildingParticleSystem != null)
					{
						_buildingParticleSystem.Stop();
					}
				}
				if (_timeLeftToBuild <= 0f)
				{
					_state = PlotState.Built;
					EndBuildEffects();
					SetLayerVisibilityBasedOnState();
					RefreshHospitalMap(animateWalls: true);
					_level.BuildEvents.OnHospitalPlotBuilt.InvokeSafe(this);
				}
			}
			else if (Definition.BuildObjectiveStartOnPrereqsMet && !_bought && Definition.Available(_level) && !ChallengeActive)
			{
				StartChallenge();
			}
		}

		private void SetItemsInBoughtPlot()
		{
			if (_hospitalMap == null)
			{
				return;
			}
			foreach (RoomItem item in _hospitalMap.FloorPlan.Items)
			{
				item.IsInBoughtPlot = true;
			}
		}

		public void SetBought()
		{
			if (!_bought)
			{
				_bought = true;
				_state = PlotState.Built;
				SetLayerVisibilityBasedOnState();
				RefreshHospitalMap(animateWalls: false);
				_worldState.SetBoughtHospitalMap(_hospitalMap);
			}
		}

		public void SetBoughtNoBuild()
		{
			if (!_bought)
			{
				_bought = true;
				_state = PlotState.Built;
				SetLayerVisibilityBasedOnState();
				RefreshHospitalMap(animateWalls: false, build: false);
			}
		}

		public void Buy()
		{
			if (_bought)
			{
				return;
			}
			_bought = true;
			_level.BuildEvents.OnHospitalPlotBought.InvokeSafe(this);
			if (_state == PlotState.Built)
			{
				_worldState.SetBoughtHospitalMap(_hospitalMap);
				if (IsMergePlot())
				{
					RefreshHospitalMap(animateWalls: false);
				}
				SetItemsInBoughtPlot();
			}
			else if (_state == PlotState.Unbuilt)
			{
				_state = PlotState.Building;
				_timeLeftToBuild = (Definition.InstaBuild ? 0f : Definition.TimeToBuild);
				if (_hospitalMap != null && !Definition.InstaBuild)
				{
					_hospitalMap.ApplyRemoveWallsEffect();
				}
				SetLayerVisibilityBasedOnState();
				RefreshHospitalMap(animateWalls: false);
				StartBuildEffects();
			}
		}

		public void BuyAndBuildImmediately()
		{
			if (!_bought)
			{
				_level.BuildEvents.OnHospitalPlotBought.InvokeSafe(this);
				SetBought();
			}
		}

		public void Sell()
		{
			if (_bought)
			{
				_bought = false;
				_state = InitialState();
				SetLayerVisibilityBasedOnState();
				RefreshHospitalMap(animateWalls: false);
			}
		}

		public void Open()
		{
			if (_hospitalMap != null)
			{
				_hospitalMap.Room.Open();
			}
		}

		public void Close()
		{
			if (_hospitalMap != null)
			{
				_hospitalMap.Room.Close();
			}
		}

		public void SetVisible(bool visible)
		{
			if (_hospitalMap != null)
			{
				_hospitalMap.Room.SetVisible(visible);
			}
		}

		public bool IsVisible()
		{
			if (_hospitalMap != null)
			{
				return _hospitalMap.Room.IsVisible();
			}
			return false;
		}

		public RoomDefinition GetRoomDefinition()
		{
			switch (_state)
			{
			case PlotState.Unbuilt:
				if (!(_definition.UnbuiltRoomDefinition != null))
				{
					return _worldState.GetUnbuiltRoomDefinition();
				}
				return _definition.UnbuiltRoomDefinition.Instance;
			case PlotState.Building:
				if (!(_definition.BuildingRoomDefinition != null))
				{
					return _worldState.GetBuildingRoomDefinition();
				}
				return _definition.BuildingRoomDefinition.Instance;
			case PlotState.Built:
				if (!(_definition.BuiltRoomDefinition != null))
				{
					return _worldState.GetBuiltRoomDefinition();
				}
				return _definition.BuiltRoomDefinition.Instance;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public RoomItemDefinition GetMainEntranceDefinition(bool force = false)
		{
			RoomDefinition roomDefinition = GetRoomDefinition();
			if (force || (_state == PlotState.Built && !roomDefinition._wallsExterior.NoExternalWalls))
			{
				if (!(Definition.MainEntranceDefinition != null))
				{
					return _worldState.GetMainEntranceDefinition();
				}
				return Definition.MainEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetSideEntranceDefinition(bool force = false)
		{
			RoomDefinition roomDefinition = GetRoomDefinition();
			if (force || (_state == PlotState.Built && !roomDefinition._wallsExterior.NoExternalWalls))
			{
				if (!(Definition.SideEntranceDefinition != null))
				{
					return _worldState.GetSideEntranceDefinition();
				}
				return Definition.SideEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetInternalEntranceDefinition(bool force = false)
		{
			RoomDefinition roomDefinition = GetRoomDefinition();
			if (force || (_state == PlotState.Built && !roomDefinition._wallsExterior.NoExternalWalls))
			{
				if (!(Definition.InternalEntranceDefinition != null))
				{
					return _worldState.GetInternalEntranceDefinition();
				}
				return Definition.InternalEntranceDefinition.Instance;
			}
			return null;
		}

		public RoomItemDefinition GetWindowDefinition()
		{
			if (_state == PlotState.Built)
			{
				if (!(Definition.WindowDefinition != null))
				{
					return _worldState.GetWindowDefinition();
				}
				return Definition.WindowDefinition.Instance;
			}
			return null;
		}

		public void SetLayerVisible(HospitalPlotLayer layer, bool visible)
		{
			_hiddenLayers[(int)layer] = !visible;
			RefreshHospitalMap(animateWalls: false);
		}

		public bool IsLayerVisible(HospitalPlotLayer layer)
		{
			return !_hiddenLayers[(int)layer];
		}

		private void StartBuildEffects()
		{
			if (!Definition.InstaBuild)
			{
				if (_hospitalMap != null)
				{
					_hospitalMap.ApplyBuildingEffectToWalls();
					_hospitalMap.DemolishUnbuiltLandscapeItems(Definition.TimeToBuild);
				}
				DestroyFootprintMesh();
				if (_hospitalMap != null)
				{
					_footprintMesh = new HospitalPlotFootprintMesh(_hospitalMap.FloorPlan);
				}
				ParticleSystem buildingParticleSystem = GetBuildingParticleSystem();
				_buildingParticleSystem = UnityEngine.Object.Instantiate(buildingParticleSystem.gameObject).GetComponent<ParticleSystem>();
				ParticleSystem.ShapeModule shape = _buildingParticleSystem.shape;
				shape.enabled = true;
				shape.shapeType = ParticleSystemShapeType.Mesh;
				shape.mesh = _footprintMesh.Mesh;
				if (_hospitalMap != null)
				{
					_landPlotBuildLoop = AudioManager.Instance.Play("LandPlotBuildLoop", _hospitalMap.RoomVisual.GameObject);
				}
			}
		}

		private ParticleSystem GetBuildingParticleSystem()
		{
			if (_definition.DemolishParticleSystemOverride != null)
			{
				return _definition.DemolishParticleSystemOverride;
			}
			return _level.Config.GetDemolishLandscapeItemEffectConfig().DemolishParticleSystem;
		}

		private void EndBuildEffects()
		{
			if (!Definition.InstaBuild)
			{
				if (_hospitalMap != null)
				{
					_hospitalMap.ApplyRemoveWallsEffect();
				}
				if (_buildingParticleSystem != null)
				{
					UnityEngine.Object.Destroy(_buildingParticleSystem.gameObject);
					_buildingParticleSystem = null;
				}
				DestroyFootprintMesh();
				if (_hospitalMap != null)
				{
					AudioManager.Instance.Play("LandPlotComplete", _hospitalMap.RoomVisual.GameObject);
				}
				if (_landPlotBuildLoop != null)
				{
					_landPlotBuildLoop.Stop();
					_landPlotBuildLoop = null;
				}
			}
		}

		public override void Destroy()
		{
			EndChallenge();
			DestroyFootprintMesh();
			base.Destroy();
		}

		private void DestroyFootprintMesh()
		{
			if (_footprintMesh != null)
			{
				_footprintMesh.Destroy();
				_footprintMesh = null;
			}
		}

		public void StartChallenge()
		{
			ObjectiveDefinition instance = _definition.BuildObjective.Instance;
			_level.LevelScriptManager.CreateObjective($"Plot_{Guid.NewGuid()}", instance, isVisible: true, isDiscovered: true, isReplayable: false, startImmediately: true, !instance.NotDismissable);
			ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
			objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			_challengeActive = true;
		}

		public void CompletePlotChallenges()
		{
			if (!_challengeActive)
			{
				return;
			}
			foreach (LevelObjective activeObjective in _level.LevelScriptManager.ActiveObjectives)
			{
				if (activeObjective.Definition == _definition.BuildObjective.Instance)
				{
					activeObjective.Finish(Objective.CompletionType.Successful);
					break;
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_challengeActive)
			{
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Combine(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
		}

		private void EndChallenge()
		{
			_challengeActive = false;
			if (!_definition.BuildObjective.IsNull())
			{
				ObjectiveEvents objectiveEvents = _level.ObjectiveEvents;
				objectiveEvents.OnObjectiveCompleted = (Action<Objective, Objective.CompletionType>)Delegate.Remove(objectiveEvents.OnObjectiveCompleted, new Action<Objective, Objective.CompletionType>(OnObjectiveCompleted));
			}
		}

		private void OnObjectiveCompleted(Objective objective, Objective.CompletionType completionType)
		{
			if (objective.Definition == _definition.BuildObjective.Instance)
			{
				if (completionType == Objective.CompletionType.Successful)
				{
					Buy();
				}
				EndChallenge();
			}
		}

		public bool IsHidden()
		{
			if (Definition.HideUntilAvailable && (!Definition.NotHiddenInSandbox || !_level.IsSandbox()))
			{
				if (Definition.Available(_level))
				{
					return !_bought;
				}
				return true;
			}
			return false;
		}

		public bool ContainsAmbulances()
		{
			if (!_definition.BuiltRoomDefinition.Instance.IsAmbulanceBayOnly || _hospitalMap?.Room?.FloorPlan?.Items == null)
			{
				return false;
			}
			foreach (RoomItem item in _hospitalMap.Room.FloorPlan.Items)
			{
				if (item.Definition.BaseAmbulanceConfig != null)
				{
					return true;
				}
			}
			return false;
		}
	}
}
