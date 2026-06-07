using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IStackableData
	{
		int UID { get; }

		IStackable.EType StackableType { get; }

		Bounds Bounds { get; }
	}
}
