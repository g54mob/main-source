using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/localspacerichai.html")]
	public class LocalSpaceRichAI : RichAI
	{
		public LocalSpaceGraph graph;

		protected override Vector3 ClampPositionToGraph(Vector3 newPosition)
		{
			RefreshTransform();
			NNInfo nNInfo = ((AstarPath.active != null) ? AstarPath.active.GetNearest(graph.transformation.InverseTransform(newPosition)) : default(NNInfo));
			movementPlane.ToPlane(newPosition, out var elevation);
			return movementPlane.ToWorld(movementPlane.ToPlane((nNInfo.node != null) ? graph.transformation.Transform(nNInfo.position) : newPosition), elevation);
		}

		private void RefreshTransform()
		{
			graph.Refresh();
			richPath.transform = graph.transformation;
			movementPlane = graph.transformation.ToSimpleMovementPlane();
		}

		protected override void Start()
		{
			RefreshTransform();
			base.Start();
		}

		protected override void CalculatePathRequestEndpoints(out Vector3 start, out Vector3 end)
		{
			RefreshTransform();
			base.CalculatePathRequestEndpoints(out start, out end);
			start = graph.transformation.InverseTransform(start);
			end = graph.transformation.InverseTransform(end);
		}

		protected override void OnUpdate(float dt)
		{
			RefreshTransform();
			base.OnUpdate(dt);
		}
	}
}
