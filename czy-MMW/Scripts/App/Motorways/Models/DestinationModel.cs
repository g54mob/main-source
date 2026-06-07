using System.Collections.Generic;
using Factory;
using FixMath;
using Motorways.Processes;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class DestinationModel : Model<DestinationModel.Frame, DestinationModel.IObserver>
	{
		public enum DestinationType
		{
			Destination = 0,
			TrainStation = 1,
			BoatTerminal = 2
		}

		public class Frame : IFrame
		{
			private Fix64 _overcrowdingTime;

			private Fix64 _overcrowdingSpeed = Fix64.Zero;

			public Fix64 OvercrowdingSpeed
			{
				get
				{
					return _overcrowdingSpeed;
				}
				set
				{
					_overcrowdingSpeed = value;
				}
			}

			public Fix64 OvercrowdingTime
			{
				get
				{
					return _overcrowdingTime;
				}
				set
				{
					_overcrowdingTime = Fix64.Max(value, Fix64.Zero);
				}
			}

			public bool CloneInto(IFrame cloneFrame, IScope scope)
			{
				Frame obj = (Frame)cloneFrame;
				obj._overcrowdingTime = _overcrowdingTime;
				obj._overcrowdingSpeed = _overcrowdingSpeed;
				return true;
			}

			public void Reset()
			{
				OvercrowdingTime = Fix64.Zero;
				OvercrowdingSpeed = Fix64.Zero;
			}
		}

		public interface IObserver
		{
			void OnDestinationReceivedVehicle(DestinationModel destination, VehicleModel vehicle);

			void OnDestinationOvercrowded(DestinationModel destination);

			void OnDestinationChangedGroup(DestinationModel destination, int oldGroupIndex, int newGroupIndex);

			void OnDestinationRemoved(DestinationModel destination);
		}

		private const int LargeScoreForDiagnosticReport = 100000;

		[Dependency]
		private MotorwaysGame _motorwaysGame;

		[Dependency]
		private Simulation _simulation;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private TilemapModel _tilemap;

		[Dependency]
		private ScoreModel _scoreKeeper;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private GameBehaviourModel _behaviour;

		[Dependency]
		private DemandModel _demandModel;

		[Dependency]
		private ActivePlayer _player;

		private DestinationType _destinationType;

		private int _groupIndex;

		private RailTileModel _closestRailTile;

		public bool isActive;

		public Fix64 demandMultiplier;

		public Fix64 demandTimer;

		public Fix64 demandLevelUpTime = -Fix64.One;

		public readonly List<int> unassignedDemand = new List<int>();

		public readonly List<int> waitingDemand = new List<int>();

		[Serialize(false, null)]
		public int demandJustCleared;

		public Fix64 contributedSupply;

		public int totalServicedPins;

		public bool IsTrainStation => _destinationType == DestinationType.TrainStation;

		public bool IsBoatTerminal => _destinationType == DestinationType.BoatTerminal;

		public int GroupIndex
		{
			get
			{
				return _groupIndex;
			}
			set
			{
				if (_groupIndex != value)
				{
					int groupIndex = _groupIndex;
					_groupIndex = value;
					for (int i = 0; i < unassignedDemand.Count; i++)
					{
						unassignedDemand[i] = _groupIndex;
					}
					ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.OnDestinationChangedGroup(this, groupIndex, _groupIndex);
					}
					_demandModel.doesSupplyNeedRecalculation = true;
				}
			}
		}

		public Fix64 ActivationTime { get; private set; }

		public bool IsSupplySufficient
		{
			get
			{
				if (IsTrainStation)
				{
					return contributedSupply > Fix64.Zero;
				}
				return contributedSupply * _demandModel.GetSupplyScale(_groupIndex) >= RequiredSupply;
			}
		}

		public Fix64 RequiredSupply
		{
			get
			{
				Fix64 result = _constants.AverageCarsPerDay * _demandModel.spawnScale * _behaviour.GetDemandMultiplierForBuilding(this);
				if (_demandModel.extraDemand.TryGetValue(_groupIndex, out var value))
				{
					result += value;
				}
				return result;
			}
		}

		[Serialize(true, null)]
		public List<TileModel> TileModels { get; private set; }

		[Serialize(true, null)]
		public CarparkModel Carpark { get; private set; }

		public bool IsUpgraded
		{
			get
			{
				if (demandLevelUpTime < Fix64.Zero)
				{
					return false;
				}
				return _clock.ExpansionTime >= demandLevelUpTime;
			}
		}

		public bool IsScheduledToBeUpgraded => demandLevelUpTime > _clock.ExpansionTime;

		public int TotalDemand => unassignedDemand.Count + waitingDemand.Count;

		public int MaximumDemandBeforeTimerStarts
		{
			get
			{
				if (IsTrainStation)
				{
					return 7;
				}
				if (!IsUpgraded)
				{
					return 6;
				}
				return 9;
			}
		}

		public bool IsOvercrowding => TotalDemand > MaximumDemandBeforeTimerStarts;

		public TutorialIdentifier TutorialIdentifier { get; private set; }

		public float GetMidStepOvercrowdingTime(float stepAlpha)
		{
			if (base.CurrentFrame.OvercrowdingTime == Fix64.Zero && base.NextFrame.OvercrowdingTime == Fix64.Zero)
			{
				return 0f;
			}
			return Mathf.Lerp((float)base.CurrentFrame.OvercrowdingTime, (float)base.NextFrame.OvercrowdingTime, stepAlpha);
		}

		public void SetNextFrameOvercrowdingSpeed(Fix64 speed)
		{
			base.NextFrame.OvercrowdingSpeed = Fix64.Clamp(speed, _constants.MinimumOvercrowdTimerSpeed, _constants.MaximumOvercrowdTimerSpeed);
		}

		public void AcceptVehicleArrival(VehicleModel vehicle)
		{
			waitingDemand.Remove(vehicle.house.GroupIndex);
			_scoreKeeper.AddScore();
			_scoreKeeper.AddEfficiencyScoreFromTripLength(vehicle.pathLengthAtStartOfJourney);
			demandJustCleared++;
			totalServicedPins++;
			if (!Application.isEditor && _player.IsTelemetryEnabled && FeatureToggle.IsFeatureEnabled(Feature.LargeScoreDiagnosticReport) && _scoreKeeper.Score == 100000)
			{
				(_motorwaysGame?.GenerateDiagnosticReport("LargeScore", DiagnosticReportAttachments.SimCommandJournal | DiagnosticReportAttachments.SimArchive | DiagnosticReportAttachments.Screenshot))?.Upload();
			}
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnDestinationReceivedVehicle(this, vehicle);
			}
		}

		public void OnOvercrowded()
		{
			if (_behaviour.CanGameOver)
			{
				ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnDestinationOvercrowded(this);
				}
			}
		}

		public virtual void Initialize(int groupIndex, Fix64 demandMultiplier, Vector2Int footprint, Vector2Int coordinates, CarparkModel carpark, TutorialIdentifier tutorialIdentifier, DestinationType destinationType)
		{
			Diagnostics.Log.Info("DestinationModel", "Initialising destination of type {0}", destinationType);
			GroupIndex = groupIndex;
			Carpark = carpark;
			_destinationType = destinationType;
			this.demandMultiplier = demandMultiplier;
			demandTimer = _constants.DelayBeforeFirstPinOfDestination;
			carpark.AddDestination(this);
			if (!carpark.SupportsTwoDestinations && _destinationType == DestinationType.TrainStation)
			{
				Diagnostics.FailAssert("Single destination carparks should not have train stations on them!");
			}
			ActivationTime = _clock.ExpansionTime;
			isActive = true;
			demandLevelUpTime = -Fix64.One;
			List<TileModel> list = new List<TileModel>();
			for (int i = 0; i < footprint.x; i++)
			{
				for (int j = 0; j < footprint.y; j++)
				{
					TileModel orCreateTileModel = _tilemap.GetOrCreateTileModel(coordinates + new Vector2Int(i, j));
					orCreateTileModel.Tile.SetContentType(TileContentType.Destination, this);
					list.Add(orCreateTileModel);
				}
			}
			TileModels = list;
			TutorialIdentifier = tutorialIdentifier;
			if (carpark.destinations.Count > 1)
			{
				return;
			}
			ModelList<RailTileModel> models = _simulation.GetModels<RailTileModel>();
			if (models.Count <= 0)
			{
				return;
			}
			RailTileModel railTileModel = models[0];
			if (_destinationType != DestinationType.TrainStation)
			{
				return;
			}
			ModelListEnumerator<RailTileModel> enumerator = models.GetEnumerator();
			while (enumerator.MoveNext())
			{
				RailTileModel current = enumerator.Current;
				if ((coordinates - current.Coordinates).magnitude < (coordinates - railTileModel.Coordinates).magnitude)
				{
					railTileModel = current;
				}
			}
			_closestRailTile = railTileModel;
			_closestRailTile?.SetTrainStation(this);
		}

		public void Remove()
		{
			isActive = false;
			_closestRailTile?.RemoveTrainStation();
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnDestinationRemoved(this);
			}
			ModelListEnumerator<VehicleModel> enumerator2 = _simulation.GetModels<VehicleModel>().GetEnumerator();
			while (enumerator2.MoveNext())
			{
				VehicleModel current = enumerator2.Current;
				if (current.destination == this)
				{
					current.ResetToHouse();
					current.destination = null;
					current.lastVisitedDestination = null;
				}
				if (current.lastVisitedDestination == this)
				{
					current.lastVisitedDestination = null;
					if (current.behaviorState != VehicleModel.BehaviorState.DrivingHome && current.behaviorState != VehicleModel.BehaviorState.WaitingForDestination && current.behaviorState != VehicleModel.BehaviorState.RealigningDriveway)
					{
						current.ResetToHouse();
					}
				}
				if (Carpark.entranceLanes.Contains(current.CurrentFrame.lane))
				{
					current.ResetToHouse();
				}
				foreach (LaneModel entranceLane in Carpark.entranceLanes)
				{
					if (entranceLane.OutboundLanes.Contains(current.CurrentFrame.lane))
					{
						current.ResetToHouse();
					}
					else if (entranceLane.InboundLanes.Contains(current.CurrentFrame.lane))
					{
						current.ResetToHouse();
					}
				}
			}
			foreach (TileModel tileModel in TileModels)
			{
				tileModel.Tile.SetContentType(TileContentType.None, null);
			}
			_simulation.RemoveModel(this);
			_demandModel.doesSupplyNeedRecalculation = true;
		}

		public override void Reset()
		{
			base.Reset();
			_groupIndex = 0;
			_closestRailTile = null;
			isActive = false;
			ActivationTime = Fix64Consts.Zero;
			demandMultiplier = Fix64Consts.Zero;
			demandTimer = Fix64Consts.Zero;
			demandLevelUpTime = -Fix64.One;
			unassignedDemand.Clear();
			waitingDemand.Clear();
			demandJustCleared = 0;
			contributedSupply = Fix64.Zero;
			TileModels = null;
			Carpark = null;
			TutorialIdentifier = TutorialIdentifier.None;
			totalServicedPins = 0;
			_destinationType = DestinationType.Destination;
		}

		public void RemoveVehicleAssignment()
		{
			if (Diagnostics.Verify(waitingDemand.Count > 0))
			{
				waitingDemand.Remove(0);
				unassignedDemand.Add(GroupIndex);
			}
		}

		public DestinationModel()
			: base(1)
		{
		}
	}
}
