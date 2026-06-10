using System;
using NSMedieval.State;

namespace NSMedieval.StatsSystem
{
	public interface IStatsOwner : IGameDisposable, IDisposable
	{
		StatsInstance Stats { get; }

		Attribute GetAttributeOverride(AttributeType type);

		string GetDebugName()
		{
			return "Undefined";
		}
	}
}
