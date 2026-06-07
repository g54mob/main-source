using System.Collections.Generic;
using Factory;
using Factory.Pools;
using JetBrains.Annotations;
using Server;
using UnityEngine;

namespace Motorways.Models
{
	public class IntersectionDecisionDatabaseModel : IModel, IReusable, IReleasedFromScopeHandler, IDeserializedHandler
	{
		[Serialize(false, null)]
		private int _nextId = 1;

		private readonly List<IntersectionEntryDecision> _decisions = new List<IntersectionEntryDecision>();

		private readonly Dictionary<VehicleModel, List<IntersectionEntryDecision>> _queryingVehicleIndex = new Dictionary<VehicleModel, List<IntersectionEntryDecision>>();

		[Dependency]
		private IScope _scope;

		public void AddDecision(IntersectionEntryDecision newDecision)
		{
			if (newDecision.Verdict == IntersectionEntryVerdict.Unknown || newDecision.Verdict == IntersectionEntryVerdict.NoReservedLane || newDecision.Verdict == IntersectionEntryVerdict.NoIntersectingLanes)
			{
				_scope.Release(newDecision);
				return;
			}
			IntersectionEntryDecision latestDecision = GetLatestDecision(newDecision.QueryingVehicle);
			if (latestDecision != null && newDecision.IsRepeatOfEarlierDecision(latestDecision))
			{
				latestDecision.ExtendDuration(newDecision.LatestFrameCount);
				_scope.Release(newDecision);
				return;
			}
			newDecision.SetId(_nextId);
			_nextId++;
			_decisions.Add(newDecision);
			if (!_queryingVehicleIndex.TryGetValue(newDecision.QueryingVehicle, out var value))
			{
				value = new List<IntersectionEntryDecision>();
				_queryingVehicleIndex.Add(newDecision.QueryingVehicle, value);
			}
			value.Insert(0, newDecision);
		}

		[CanBeNull]
		public IntersectionEntryDecision GetLatestDecision([NotNull] VehicleModel vehicleModel)
		{
			if (_queryingVehicleIndex.TryGetValue(vehicleModel, out var value) && value.Count > 0)
			{
				return value[0];
			}
			return null;
		}

		public List<IntersectionEntryDecision> GetDecisions([NotNull] VehicleModel vehicleModel)
		{
			if (_queryingVehicleIndex.TryGetValue(vehicleModel, out var value))
			{
				return value;
			}
			return null;
		}

		public void OnDeserialized(IScope context)
		{
			foreach (IntersectionEntryDecision decision in _decisions)
			{
				_nextId = Mathf.Max(_nextId, decision.Id + 1);
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			foreach (IntersectionEntryDecision decision in _decisions)
			{
				scope.Release(decision);
			}
			_decisions.Clear();
		}

		public void Reset()
		{
			_nextId = 1;
			_decisions.Clear();
			_queryingVehicleIndex.Clear();
		}
	}
}
