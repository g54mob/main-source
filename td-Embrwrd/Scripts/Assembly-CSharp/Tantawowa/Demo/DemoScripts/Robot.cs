using Game.General.Navigation;
using UnityEngine;
using UnityEngine.AI;

namespace Tantawowa.Demo.DemoScripts
{
	public class Robot : MonoBehaviour
	{
		[SerializeField]
		private int points;

		[SerializeField]
		private RobotState currentState;

		public TextMesh Message;

		public NavMeshAgent Agent;

		public NavMeshFollower NavMeshFollower;

		public Transform Work;

		public Transform Home;

		public int Points
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void AddScore(int points)
		{
		}

		public void ResetScore()
		{
		}

		public void SetState(RobotState state)
		{
		}

		private void Update()
		{
		}
	}
}
