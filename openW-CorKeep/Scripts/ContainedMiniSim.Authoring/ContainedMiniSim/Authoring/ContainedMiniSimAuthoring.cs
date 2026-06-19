using UnityEngine;

namespace ContainedMiniSim.Authoring
{
	public class ContainedMiniSimAuthoring : MonoBehaviour
	{
		public int maxNumberOfSimulatedElements;

		public Vector2 simulateAreaMinMaxWidth;

		public Vector2 simulateAreaMinMaxHeight;

		public Vector2 simulateAreaMinMaxLength;

		public ContainedMiniSimElementAuthoring simulatedEntity;
	}
}
