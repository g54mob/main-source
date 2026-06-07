using System.Collections.Generic;
using Factory;
using FixMath;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class TrafficLightModel : Model<EmptyModelFrame, TrafficLightModel.IObserver>
	{
		public interface IObserver
		{
			void OnTrafficLightGreen(TrafficLightModel model, TileDirectionBitfield rightOfWay);

			void OnTrafficLightAmber(TrafficLightModel model);

			void OnLanesChanged();
		}

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private ClockModel _clock;

		public Fix64 durationOnCurrentPair = Fix64.Zero;

		private int _currentPairIndex = -1;

		public readonly List<TileDirectionBitfield> greenLightPairs = new List<TileDirectionBitfield>();

		private RoadChunkModel _owningChunk;

		public bool requiresPairCalculation = true;

		public bool isInOvertime;

		public bool amberLightsOn;

		private const int InvalidIndex = -1;

		public static readonly TileDirectionBitfield AllBlockedDirectionBitfield = new TileDirectionBitfield(-1);

		public TileDirectionBitfield ActivePair
		{
			get
			{
				if (_currentPairIndex < 0 || _currentPairIndex >= greenLightPairs.Count)
				{
					return default(TileDirectionBitfield);
				}
				return greenLightPairs[_currentPairIndex];
			}
		}

		public TileDirectionBitfield BlockedLanes => ~ActivePair;

		public virtual void Initialize(RoadChunkModel roadChunk)
		{
			_owningChunk = roadChunk;
			greenLightPairs.Clear();
			CalculatePairs();
			RotateLights();
		}

		public void CalculatePairs()
		{
			greenLightPairs.Clear();
			TileDirectionBitfield inboundDirections = _owningChunk.GetInboundDirections();
			for (int i = 0; i < 4; i++)
			{
				TileDirection tileDirection = (TileDirection)i;
				TileDirection oppositeDirection = TileUtilities.GetOppositeDirection(tileDirection);
				if (inboundDirections[tileDirection] && inboundDirections[oppositeDirection])
				{
					greenLightPairs.Add(new TileDirectionBitfield(new TileDirection[2] { tileDirection, oppositeDirection }));
					inboundDirections[tileDirection] = false;
					inboundDirections[oppositeDirection] = false;
				}
			}
			for (int j = 0; j < 8; j++)
			{
				TileDirection tileDirection2 = (TileDirection)j;
				TileDirection rotatedDirection = TileUtilities.GetRotatedDirection(tileDirection2, 3);
				TileDirection rotatedDirection2 = TileUtilities.GetRotatedDirection(tileDirection2, -3);
				if (!inboundDirections[rotatedDirection] || !inboundDirections[rotatedDirection2])
				{
					if (inboundDirections[tileDirection2] && inboundDirections[rotatedDirection])
					{
						greenLightPairs.Add(new TileDirectionBitfield(new TileDirection[2] { tileDirection2, rotatedDirection }));
						inboundDirections[tileDirection2] = false;
						inboundDirections[rotatedDirection] = false;
					}
					else if (inboundDirections[tileDirection2] && inboundDirections[rotatedDirection2])
					{
						greenLightPairs.Add(new TileDirectionBitfield(new TileDirection[2] { tileDirection2, rotatedDirection2 }));
						inboundDirections[tileDirection2] = false;
						inboundDirections[rotatedDirection2] = false;
					}
				}
			}
			TileDirectionBitfield.Enumerator enumerator = inboundDirections.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				greenLightPairs.Add(new TileDirectionBitfield(new TileDirection[1] { current }));
				inboundDirections[current] = false;
			}
			requiresPairCalculation = false;
		}

		public bool SetActivePair(TileDirectionBitfield pair)
		{
			bool result = true;
			int num = greenLightPairs.IndexOf(pair);
			if (num == -1)
			{
				num = -1;
				result = false;
			}
			_currentPairIndex = num;
			return result;
		}

		public void OnLanesChanged()
		{
			requiresPairCalculation = true;
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnLanesChanged();
			}
		}

		public void ChangeGreenToAmber()
		{
			amberLightsOn = true;
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnTrafficLightAmber(this);
			}
		}

		public void RotateLights()
		{
			if (greenLightPairs.Count == 0)
			{
				return;
			}
			_currentPairIndex = NextValidPairIndex();
			amberLightsOn = false;
			if (_currentPairIndex != -1)
			{
				ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnTrafficLightGreen(this, greenLightPairs[_currentPairIndex]);
				}
			}
		}

		public bool RequiresRotation()
		{
			if (requiresPairCalculation)
			{
				TileDirectionBitfield activePair = ActivePair;
				CalculatePairs();
				SetActivePair(activePair);
			}
			if (greenLightPairs.Count == 0)
			{
				return false;
			}
			if (_owningChunk.inboundVehicles.Count > 0)
			{
				if (_constants.distanceToCountForNearbyCars > Fix64.Zero)
				{
					int num = NumberOfCarsForPair(_currentPairIndex, ignoreBlockedVehicles: true, onlyNearbyCars: true);
					if (num < _constants.minimumNearbyCarsBeforeSwapping && num > 0)
					{
						return false;
					}
				}
				int num2 = HighestWeightedGreenLightPair();
				if (_currentPairIndex == num2)
				{
					return false;
				}
				return _currentPairIndex != NextValidPairIndex();
			}
			return false;
		}

		private int NextValidPairIndex()
		{
			if (greenLightPairs.Count == 0)
			{
				return -1;
			}
			if (_owningChunk.inboundVehicles.Count > 0)
			{
				return HighestWeightedGreenLightPair(ignoreCurrentPair: true);
			}
			return (_currentPairIndex + 1) % greenLightPairs.Count;
		}

		private int HighestWeightedGreenLightPair(bool ignoreCurrentPair = false)
		{
			Fix64 fix = Fix64.Zero;
			int result = 0;
			for (int i = 0; i < greenLightPairs.Count; i++)
			{
				if (!ignoreCurrentPair || i != _currentPairIndex)
				{
					Fix64 fix2 = WeightForPair(i);
					if (fix2 > fix)
					{
						result = i;
						fix = fix2;
					}
				}
			}
			if (fix == Fix64.Zero)
			{
				result = Mathf.Max(_currentPairIndex, 0);
			}
			return result;
		}

		public Fix64 WeightForPair(int index, bool onlyNearbyCars = false)
		{
			Fix64 zero = Fix64.Zero;
			TileDirectionBitfield.Enumerator enumerator = greenLightPairs[index].GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				bool flag = true;
				foreach (RoadChunkModel.InboundVehicle item in _owningChunk.InboundVehiclesEnteringFromDirection(current, onlyNearbyCars ? _constants.distanceToCountForNearbyCars : (-Fix64.One)))
				{
					if (flag && _owningChunk.ConnectionCrossesLane(item.chosenLane.connection.input.direction, item.chosenLane.connection.output.direction))
					{
						flag = false;
					}
					Fix64 fix = Fix64.Clamp01((_clock.Time - item.committedTimestamp) / _constants.MaximumIdleTimeAtTrafficLightBeforeMaxWeight);
					fix = fix * fix * _constants.IdleTimeAtTrafficLightWeightMultiplier;
					if (item.chosenLane.state == RoadState.Mothballed)
					{
						fix *= _constants.IdleTimeAtTrafficLightWeightMultiplierOnMothballedLane;
					}
					if (flag)
					{
						fix *= _constants.CanTurnRightWeightModifier;
					}
					if (item.vehicle.CurrentFrame.lane.connection.input.type == RoadType.Carpark || item.vehicle.CurrentFrame.lane.connection.input.type == RoadType.ParkingSpace)
					{
						fix *= _constants.CarparkPriorityModifier;
					}
					fix += Fix64.One;
					if (item.vehicle.CurrentFrame.blockingLane?.roadChunk == _owningChunk && _currentPairIndex == index)
					{
						fix *= _constants.BlockedCarWeightModifier;
					}
					zero += fix;
				}
			}
			return zero;
		}

		private int NumberOfCarsForPair(int index, bool ignoreBlockedVehicles = false, bool onlyNearbyCars = false)
		{
			if (index < 0 || index >= greenLightPairs.Count)
			{
				return 0;
			}
			int num = 0;
			TileDirectionBitfield.Enumerator enumerator = greenLightPairs[index].GetEnumerator();
			while (enumerator.MoveNext())
			{
				TileDirection current = enumerator.Current;
				num += _owningChunk.NumberOfCarsEnteringFromDirection(current, ignoreBlockedVehicles, onlyNearbyCars ? _constants.distanceToCountForNearbyCars : (-Fix64.One));
			}
			return num;
		}

		public override void Reset()
		{
			base.Reset();
			greenLightPairs.Clear();
			isInOvertime = false;
			durationOnCurrentPair = Fix64.Zero;
			_owningChunk = null;
			amberLightsOn = false;
			isInOvertime = false;
			_currentPairIndex = -1;
			requiresPairCalculation = true;
		}

		public TrafficLightModel()
			: base(1)
		{
		}
	}
}
