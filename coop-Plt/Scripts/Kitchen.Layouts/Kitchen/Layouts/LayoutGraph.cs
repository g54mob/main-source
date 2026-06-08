using System.Collections.Generic;
using System.Linq;
using Kitchen.Layouts.Modules;
using UnityEngine;
using XNode;

namespace Kitchen.Layouts
{
	[CreateAssetMenu(fileName = "LayoutGraph", menuName = "Kitchen/Graphs/Layout Graph")]
	public class LayoutGraph : NodeGraph
	{
		public LayoutBlueprint Build(int seed = 0)
		{
			if (seed != 0)
			{
				Random.InitState(seed);
			}
			Update();
			foreach (Node node in nodes)
			{
				if (node is Output output)
				{
					return output.GetResult();
				}
			}
			return null;
		}

		public void Update()
		{
			Queue<Node> queue = new Queue<Node>(nodes);
			int num = queue.Count * queue.Count;
			while (queue.Any() && num-- >= 0)
			{
				Node node = queue.Dequeue();
				if (node is Module module)
				{
					if (module.Parents.Intersect(queue).Any())
					{
						queue.Enqueue(node);
					}
					else
					{
						module.Update();
					}
				}
			}
			if (num <= 0)
			{
				throw new LayoutFailureException("Failed to update graph");
			}
		}
	}
}
