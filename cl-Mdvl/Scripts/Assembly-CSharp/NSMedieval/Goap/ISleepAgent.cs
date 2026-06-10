using System;
using NSMedieval.BuildingComponents;
using NSMedieval.State;
using NSMedieval.StatsSystem;

namespace NSMedieval.Goap
{
	public interface ISleepAgent : IPathfindingAgent, IGoapAgentOwner, IGameDisposable, IDisposable
	{
		StatsInstance Stats { get; }

		bool IsSleeping { get; set; }

		void SnapToBed(BedComponentInstance bed);
	}
}
