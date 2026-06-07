using System.Collections.Generic;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public delegate void NodeListChangedDelegate(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category);
}
