using System;
using CTS.BBT.AI;

namespace CTS
{
	public interface IMachine : IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		bool HasAVictim { get; }

		event Action<Agent> VictimChanged;
	}
}
