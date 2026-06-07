using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces
{
	public delegate void ChainNodeSelectionHandler(LinkedListNode<IChainableOrbit> chainNode);
}
