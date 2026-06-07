using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;

namespace Motorways.Processes
{
	public class FailureStateProcess : IProcess, IReusable
	{
		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private DemandModel _demand;

		[Dependency]
		private City _city;

		[Dependency]
		private ClockModel _clock;

		public void Reset()
		{
		}

		public void Step(ISimulation simulation, Fix64 timestep)
		{
			ModelListEnumerator<DestinationModel> enumerator = simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				Fix64 fix = -_constants.OvercrowdTimerReturnSpeed;
				Fix64 fix2 = current.CurrentFrame.OvercrowdingTime;
				if (current.IsOvercrowding && _city.Rules.CanDestinationsOvercrowd)
				{
					Fix64 currentTimerProgress = current.CurrentFrame.OvercrowdingTime / _constants.MaxOvercrowdTime;
					Fix64 overcrowdingSpeedMultiplier = _city.Rules.GetOvercrowdingSpeedMultiplier(currentTimerProgress);
					if (_demand.extraDemand.TryGetValue(current.GroupIndex, out var value))
					{
						overcrowdingSpeedMultiplier *= _constants.GetOvercrowdTimerSpeedMultiplierForExtraDemand(value);
					}
					fix = current.CurrentFrame.OvercrowdingSpeed * overcrowdingSpeedMultiplier;
					Fix64 overcrowdingSpeed = current.CurrentFrame.OvercrowdingSpeed;
					if (current.demandJustCleared > 0)
					{
						fix2 = Fix64.Min(fix2, _constants.MaxOvercrowdTime - _constants.GracePeriodTime);
						for (int i = 0; i < current.demandJustCleared; i++)
						{
							overcrowdingSpeed *= _constants.OvercrowdTimerCarArrivalDeceleration;
							Fix64 value2 = _constants.PercentageToReduceTimerOnCarArrival / (Fix64)100L * fix2;
							value2 *= _constants.GetCarArrivalPinReductionMultiplierOverTime(_clock.Time);
							value2 = Fix64.Clamp(value2, _constants.MinimumAmountToReduceTimerOnCarArrival, _constants.MaximumAmountToReduceTimerOnCarArrival);
							fix2 -= value2;
							fix2 = Fix64.Max(fix2, Fix64.Zero);
						}
						current.demandJustCleared = 0;
					}
					overcrowdingSpeed += _constants.OvercrowdTimerAcceleration * timestep;
					current.SetNextFrameOvercrowdingSpeed(overcrowdingSpeed);
				}
				else
				{
					current.SetNextFrameOvercrowdingSpeed(_constants.MinimumOvercrowdTimerSpeed);
					fix2 = Fix64.Min(fix2, _constants.MaxOvercrowdTime - _constants.GracePeriodTime);
				}
				current.NextFrame.OvercrowdingTime = fix2 + fix * timestep;
				if (current.CurrentFrame.OvercrowdingTime > _constants.MaxOvercrowdTime && !simulation.IsPaused)
				{
					current.OnOvercrowded();
				}
			}
		}
	}
}
