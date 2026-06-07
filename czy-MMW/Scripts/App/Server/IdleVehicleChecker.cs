using System.Collections.Generic;
using FixMath;
using Motorways;
using Motorways.Models;

namespace Server
{
	public class IdleVehicleChecker : ISimulationObserver
	{
		public class VehicleInformation
		{
			public readonly VehicleModel vehicleModel;

			public Fix64? vehicleStoppedTimestamp;

			public VehicleInformation(VehicleModel vehicleModel)
			{
				this.vehicleModel = vehicleModel;
			}

			public override bool Equals(object obj)
			{
				if (obj is VehicleInformation vehicleInformation)
				{
					if (vehicleModel == null || vehicleInformation.vehicleModel == null)
					{
						return false;
					}
					return vehicleModel.id == vehicleInformation.vehicleModel.id;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return vehicleModel.id;
			}
		}

		public static readonly Fix64 MaxVehicleIdleTimeBeforeWarning = (Fix64)60f;

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("IdleVehicleChecker");

		private readonly List<VehicleInformation> _idleVehicles = new List<VehicleInformation>();

		private readonly List<VehicleInformation> _vehicleInformation = new List<VehicleInformation>();

		private MotorwaysGame _motorwaysGame;

		private ISimulation _simulation;

		private static readonly Fix64 SpeedEpsilon = (Fix64)0.01f;

		private bool HasSentReport { get; set; }

		public IReadOnlyList<VehicleInformation> IdleVehicles => _idleVehicles.AsReadOnly();

		public void Initialize(MotorwaysGame motorwaysGame)
		{
			_motorwaysGame = motorwaysGame;
			_simulation = motorwaysGame.Simulation;
			_simulation.Subscribe(this);
		}

		public void RunCheck()
		{
			if (!FeatureToggle.IsFeatureEnabled(Feature.IdleVehicleCheckerDiagnosticReport) && !FeatureToggle.IsFeatureEnabled(Feature.IdleVehicleCheckerGUI))
			{
				return;
			}
			ClockModel model = _simulation.GetModel<ClockModel>();
			if (model == null)
			{
				return;
			}
			foreach (VehicleInformation item in _vehicleInformation)
			{
				Fix64? vehicleStoppedTimestamp = item.vehicleStoppedTimestamp;
				VehicleModel vehicleModel = item.vehicleModel;
				if (vehicleStoppedTimestamp.HasValue)
				{
					if (!HasStoppedOnJourney(vehicleModel))
					{
						item.vehicleStoppedTimestamp = null;
						if (_idleVehicles.Contains(item))
						{
							_idleVehicles.Remove(item);
						}
					}
					else if (!_idleVehicles.Contains(item))
					{
						Fix64 fix = model.Time - vehicleStoppedTimestamp.Value;
						if (fix > MaxVehicleIdleTimeBeforeWarning)
						{
							Log.Warn("Vehicle ({0}) has been idle while driving to destination/home for {1} seconds", vehicleModel.id, fix);
							_idleVehicles.Add(item);
							SubmitReportIfNotSubmittedAlready(item, fix);
						}
					}
				}
				else if (HasStoppedOnJourney(vehicleModel))
				{
					item.vehicleStoppedTimestamp = model.Time;
				}
			}
		}

		private void SubmitReportIfNotSubmittedAlready(VehicleInformation vehicleInformation, Fix64 idleTime)
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.IdleVehicleCheckerDiagnosticReport) && !HasSentReport && FeatureToggle.IsFeatureEnabled(Feature.DiagnosticReports))
			{
				Diagnostics.Report report = _motorwaysGame.GenerateDiagnosticReport("VehicleIdle-Test", DiagnosticReportAttachments.SimCommandJournal | DiagnosticReportAttachments.Screenshot);
				report.SetMetadata("idleVehicleId", vehicleInformation.vehicleModel.id.ToString());
				report.SetMetadata("idleTime", idleTime.ToString());
				report.Upload();
				HasSentReport = true;
			}
		}

		private static bool HasStoppedOnJourney(VehicleModel vehicleModel)
		{
			if (vehicleModel.behaviorState != VehicleModel.BehaviorState.WaitingForDestination)
			{
				return vehicleModel.CurrentFrame.speed - Fix64.Zero < SpeedEpsilon;
			}
			return false;
		}

		public void OnModelAdded(ISimulation simulation, IModel model, Fix64 timestamp)
		{
			if (model is VehicleModel vehicleModel)
			{
				_vehicleInformation.Add(new VehicleInformation(vehicleModel));
			}
		}

		public void OnModelRemoved(ISimulation simulation, IModel model, Fix64 timestamp)
		{
		}
	}
}
