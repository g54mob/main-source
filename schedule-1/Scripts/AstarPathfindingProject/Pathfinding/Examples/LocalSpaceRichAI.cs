using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_local_space_rich_a_i.php")]
	public class LocalSpaceRichAI : RichAI
	{
		public LocalSpaceGraph graph;

		private void RefreshTransform()
		{
		}

		protected override void Start()
		{
		}

		protected override void CalculatePathRequestEndpoints(out Vector3 start, out Vector3 end)
		{
			start = default(Vector3);
			end = default(Vector3);
		}

		protected override void Update()
		{
		}
	}
}
