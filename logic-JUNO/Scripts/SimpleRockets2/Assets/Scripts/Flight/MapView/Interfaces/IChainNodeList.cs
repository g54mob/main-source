using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IChainNodeList
	{
		bool AllowEncounterNodeCreation { get; }

		LinkedList<IChainableOrbit> ChainNodes { get; }

		int ConsecutiveEncounterNodesAtEndOfList { get; }

		SoiEncounterNodeScript FirstEncounter { get; }

		ManeuverNodeScript FirstIncompleteManeuverNode { get; }

		ManeuverNodeScript FirstManeuverNode { get; }

		IChainableOrbit FirstNode { get; }

		IChainableOrbit FirstNonCraftNode { get; }

		IChainableOrbit LastNode { get; }

		double? TimeToNextNode { get; }

		event NodeListChangedDelegate NodeAdded;

		event NodeListChangedDelegate NodeListChanged;

		event NodeListChangedDelegate RemovingNode;

		LinkedListNode<IChainableOrbit> AddAfter(LinkedListNode<IChainableOrbit> addAfter, Func<LinkedListNode<IChainableOrbit>, IChainableOrbit> creationMethod, NodeListChangeCategory category);

		void DestroyNodes();

		void DestroyOrphanedNodes();

		void Remove(LinkedListNode<IChainableOrbit> orbitLineNode, bool deleteChildren, bool destroy, NodeListChangeCategory category);

		void RemoveAfter<T>(LinkedListNode<IChainableOrbit> orbitLineNode, bool consecutiveOccurrencesOnly, NodeListChangeCategory category) where T : IChainableOrbit;

		void RemoveType<T>(LinkedListNode<IChainableOrbit> startingNodeToDelete, bool consecutiveOccurrencesOnly, NodeListChangeCategory category) where T : IChainableOrbit;

		void SetOrphaned(ManeuverNodeScript maneuverNodeScript);
	}
}
