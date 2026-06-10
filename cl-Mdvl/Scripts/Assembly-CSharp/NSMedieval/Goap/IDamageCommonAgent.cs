using System;
using System.Collections.Generic;
using NSEipix;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Village.Map;
using NSMedieval.Village.Map.Pathfinding;
using UnityEngine;

namespace NSMedieval.Goap
{
	public interface IDamageCommonAgent : IGoapTargetable, IGameDisposable, IDisposable
	{
		StatsInstance Stats { get; }

		bool HasDied { get; }

		bool HasActivePath { get; }

		bool HasDiedOrFainted => HasDied;

		PathfinderAgentDriver PathDriver => null;

		bool IsMidStrike => false;

		bool HasView => (object)GetTransform() != null;

		VillageMap Map { get; }

		List<EquipmentInstance> GetEquipment();

		Transform GetTransform();

		MapNode GetNode();

		EquipmentInstance GetBestCombatCoverEquipment(DamageType damageType)
		{
			return null;
		}

		float Distance(IDamageCommonAgent other)
		{
			return GetPosition().Distance(other.GetPosition());
		}

		float DistanceSquared(IDamageCommonAgent other)
		{
			return GetPosition().DistanceSquared(other.GetPosition());
		}
	}
}
