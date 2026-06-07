using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/MoveInCircle")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/moveincircle.html")]
	public class MoveInCircle : VersionedMonoBehaviour
	{
		public Transform target;

		public float radius;

		public float offset;

		private IAstarAI ai;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		public override void DrawGizmos()
		{
		}
	}
}
