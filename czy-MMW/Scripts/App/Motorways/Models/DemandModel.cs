using System.Collections.Generic;
using System.Diagnostics;
using Factory;
using Factory.Pools;
using FixMath;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class DemandModel : IModel, IReusable
	{
		public Fix64 spawnScale;

		public bool doesSupplyNeedRecalculation;

		private readonly Dictionary<int, Fix64> _supplyScales = new Dictionary<int, Fix64>();

		private readonly Dictionary<int, Fix64> _demandOscillationOffsets = new Dictionary<int, Fix64>();

		public readonly Dictionary<int, Fix64> extraDemand = new Dictionary<int, Fix64>();

		[Serialize(false, null)]
		public readonly Dictionary<int, int> failedDestinationUpgrades = new Dictionary<int, int>();

		[Serialize(false, null)]
		public readonly Dictionary<int, List<Fix64>> allocatedPinsInLastWeek = new Dictionary<int, List<Fix64>>();

		[Serialize(false, null)]
		public readonly Dictionary<int, List<Fix64>> reallocatedPinsInLastWeek = new Dictionary<int, List<Fix64>>();

		[Serialize(false, null)]
		public readonly Dictionary<int, List<Fix64>> reallocatedToOtherGroupsPinsInLastWeek = new Dictionary<int, List<Fix64>>();

		[Serialize(false, null)]
		public readonly Dictionary<int, List<Fix64>> discardedPinsInLastWeek = new Dictionary<int, List<Fix64>>();

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private City _city;

		[Dependency]
		private CityModel _cityModel;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private SimulationConstantsData _constants;

		public void ApplyIncrementalSupplyFromHouse(HouseModel newHouse)
		{
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.GroupIndex == newHouse.GroupIndex)
				{
					current.contributedSupply += CalculateSupplyContributionFromHouseToDestination(newHouse, current);
				}
			}
		}

		public void ApplyAbsoluteSupplyToDestination(DestinationModel destination)
		{
			int groupIndex = destination.GroupIndex;
			Fix64 zero = Fix64.Zero;
			ModelListEnumerator<HouseModel> enumerator = _simulation.GetModels<HouseModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				HouseModel current = enumerator.Current;
				if (current.GroupIndex == groupIndex)
				{
					zero += CalculateSupplyContributionFromHouseToDestination(current, destination);
				}
			}
			destination.contributedSupply = zero;
		}

		public void CalculateSupplyScale(int groupIndex)
		{
			int num = 0;
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				if (current.isActive && current.GroupIndex == groupIndex && !current.IsTrainStation)
				{
					num++;
				}
			}
			_supplyScales[groupIndex] = _constants.EvaluateDestinationCountHouseValueMultiplier(num);
		}

		public Fix64 GetSupplyScale(int groupIndex)
		{
			if (_supplyScales.TryGetValue(groupIndex, out var value))
			{
				return value;
			}
			CalculateSupplyScale(groupIndex);
			return _supplyScales[groupIndex];
		}

		public void RecalculateSupply()
		{
			ModelListEnumerator<DestinationModel> enumerator = _simulation.GetModels<DestinationModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DestinationModel current = enumerator.Current;
				ApplyAbsoluteSupplyToDestination(current);
			}
			_supplyScales.Clear();
			doesSupplyNeedRecalculation = false;
		}

		public Fix64 GetGroupDemandOscillationOffset(int groupIndex)
		{
			if (!_demandOscillationOffsets.TryGetValue(groupIndex, out var value))
			{
				CitySchedulePlanner schedulePlanner = _city.Definition.schedulePlanner;
				if (Diagnostics.Verify(schedulePlanner.demandOscillationData != null && schedulePlanner.demandOscillationData.Count > 0, "We have no demand oscillation for this city {0}! Defaulting to no offset", _city.Definition.name))
				{
					if (Diagnostics.Verify(groupIndex >= 0 && groupIndex < schedulePlanner.demandOscillationData.Count, "Group index {0} out of range for demand oscillation data (count {1}) for this city {2}! Defaulting to no offset", groupIndex, schedulePlanner.demandOscillationData.Count, _city.Definition.name))
					{
						GroupDemandOscillation groupDemandOscillation = schedulePlanner.demandOscillationData[groupIndex];
						value = _cityModel.pseudorandomGenerator.Fix64((Fix64)groupDemandOscillation.periodInDays);
					}
					else
					{
						value = Fix64.Zero;
					}
				}
				else
				{
					value = Fix64.Zero;
				}
				_demandOscillationOffsets.Add(groupIndex, value);
			}
			return value;
		}

		[Conditional("UNITY_EDITOR")]
		public void OnPinAllocated(int groupIndex)
		{
			if (allocatedPinsInLastWeek.TryGetValue(groupIndex, out var value))
			{
				value.Add(_clock.Time);
				return;
			}
			value = new List<Fix64> { _clock.Time };
			allocatedPinsInLastWeek.Add(groupIndex, value);
		}

		[Conditional("UNITY_EDITOR")]
		public void OnPinReallocated(int receivingDestinationGroupIndex, int originalDestinationGroupIndex)
		{
			Dictionary<int, List<Fix64>> dictionary = ((receivingDestinationGroupIndex != originalDestinationGroupIndex) ? reallocatedToOtherGroupsPinsInLastWeek : reallocatedPinsInLastWeek);
			if (dictionary.TryGetValue(originalDestinationGroupIndex, out var value))
			{
				value.Add(_clock.Time);
				return;
			}
			value = new List<Fix64> { _clock.Time };
			dictionary.Add(originalDestinationGroupIndex, value);
		}

		[Conditional("UNITY_EDITOR")]
		public void OnPinDiscarded(int groupIndex)
		{
			if (discardedPinsInLastWeek.TryGetValue(groupIndex, out var value))
			{
				value.Add(_clock.Time);
				return;
			}
			value = new List<Fix64> { _clock.Time };
			discardedPinsInLastWeek.Add(groupIndex, value);
		}

		[Conditional("UNITY_EDITOR")]
		public void ClearOldestPinTrackingEntries()
		{
			_ = _clock.Time - (Fix64)140.0;
		}

		[Conditional("UNITY_EDITOR")]
		private void ClearPinsOlderThan(Fix64 oldestTime, Dictionary<int, List<Fix64>> group)
		{
			foreach (int key in group.Keys)
			{
				while (group[key].Count > 0 && group[key][0] < oldestTime)
				{
					group[key].RemoveAt(0);
				}
			}
		}

		public Fix64 CalculateSupplyContributionFromHouseToDestination(HouseModel house, DestinationModel destination)
		{
			Vector2Int vector2Int = (destination.Carpark.entranceAtTopLeft ? destination.Carpark.TopLeftDrivewayTileCoordinates : destination.Carpark.BottomRightDrivewayTileCoordinates) - house.tileModel.Coordinates;
			int num = Mathf.Min(Mathf.Abs(vector2Int.x), Mathf.Abs(vector2Int.y));
			int num2 = Mathf.Max(Mathf.Abs(vector2Int.x), Mathf.Abs(vector2Int.y)) - num;
			Fix64 distance = (Fix64)num * Fix64Consts.SqrtTwo + (Fix64)num2;
			return _constants.EvaluateHouseContributionFromDistance(distance);
		}

		public void Reset()
		{
			spawnScale = Fix64.Zero;
			doesSupplyNeedRecalculation = false;
			_supplyScales.Clear();
			_demandOscillationOffsets.Clear();
			extraDemand.Clear();
			failedDestinationUpgrades.Clear();
			allocatedPinsInLastWeek.Clear();
			reallocatedPinsInLastWeek.Clear();
			reallocatedToOtherGroupsPinsInLastWeek.Clear();
			discardedPinsInLastWeek.Clear();
		}

		public void Inspect()
		{
		}
	}
}
