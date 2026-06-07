using Unity.Entities;
using UnityEngine;

namespace Pathfinding
{
	[UniqueComponent(tag = "ai.destination")]
	[AddComponentMenu("Pathfinding/AI/Behaviors/MoveInCircle")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/moveincircle.html")]
	public class MoveInCircle : VersionedMonoBehaviour
	{
		public struct DestinationMoveInCircle : IComponentData, IQueryTypeParameter, IEnableableComponent
		{
			public Entity target;

			public float radius;

			public float offset;
		}

		public Transform target;

		public float radius;

		public float offset;

		private IAstarAI ai;

		private void OnEnable()
		{
		}

		public static Vector3 CalculateDestination(Vector3 position, Vector3 target, Vector3 targetUp, float radius, float offset)
		{
			return default(Vector3);
		}

		private void Update()
		{
		}

		public override void DrawGizmos()
		{
		}
	}
}
