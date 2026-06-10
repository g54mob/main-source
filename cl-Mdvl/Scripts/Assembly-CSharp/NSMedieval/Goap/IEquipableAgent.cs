using System;
using NSMedieval.State;

namespace NSMedieval.Goap
{
	public interface IEquipableAgent : IPathfindingAgent, IGoapAgentOwner, IGameDisposable, IDisposable
	{
		InventoryInstance Inventory { get; }
	}
}
