using Pathfinding.Drawing;
using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/MoveInCircle")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/moveincircle.html")]
	public class MoveInCircle : VersionedMonoBehaviour
	{
		public Transform target;

		public float radius = 5f;

		public float offset = 2f;

		private IAstarAI ai;

		private void OnEnable()
		{
			ai = GetComponent<IAstarAI>();
		}

		private void Update()
		{
			Vector3 normalized = (ai.position - target.position).normalized;
			Vector3 vector = Vector3.Cross(normalized, target.up);
			ai.destination = target.position + normalized * radius + vector * offset;
		}

		public override void DrawGizmos()
		{
			if ((bool)target)
			{
				Draw.Circle(target.position, target.up, radius, Color.white);
			}
		}
	}
}
