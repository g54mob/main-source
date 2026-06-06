using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/localspacerichai.html")]
	public class LocalSpaceRichAI : RichAI
	{
		public LocalSpaceGraph graph;

		protected override Vector3 ClampPositionToGraph(Vector3 newPosition)
		{
			return default(Vector3);
		}

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

		protected override void OnUpdate(float dt)
		{
		}
	}
}
