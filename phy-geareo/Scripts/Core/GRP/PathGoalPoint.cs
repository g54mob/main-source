using UnityEngine;

namespace GRP
{
	public class PathGoalPoint : MonoBehaviour
	{
		public GameObject current;

		private PathGoal goal;

		private int index;

		private void OnTriggerEnter(Collider other)
		{
		}

		public void Setup(PathGoal goal, int index)
		{
		}

		public void UpdateView()
		{
		}
	}
}
