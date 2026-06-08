using KitchenData;
using UnityEngine;
using XNode;

namespace KitchenEditor
{
	[CreateAssetMenu(fileName = "ResearchGraph", menuName = "Kitchen/Graphs/Research Graph")]
	public class ResearchGraph : NodeGraph
	{
		public void AddData(IGameDataObjectMap map)
		{
			foreach (Node node2 in nodes)
			{
				if (!(node2 is ResearchNode researchNode))
				{
					continue;
				}
				Research research = (Research)map.Get(researchNode.RefersTo);
				foreach (NodePort connection in researchNode.GetOutputPort("LeadsTo").GetConnections())
				{
					Node node = connection.node;
					if (node.GetInputPort("UnlockedBy") == connection && node is ResearchNode researchNode2 && map.Get(researchNode2.RefersTo) is Research research2)
					{
						research.EnablesResearchOf.Add(research2);
						research2.RequiresForResearch.Add(research);
					}
				}
			}
		}
	}
}
