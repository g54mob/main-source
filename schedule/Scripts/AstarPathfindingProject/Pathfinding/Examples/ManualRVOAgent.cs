using Pathfinding.RVO;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_manual_r_v_o_agent.php")]
	[RequireComponent(typeof(RVOController))]
	public class ManualRVOAgent : MonoBehaviour
	{
		private RVOController rvo;

		public float speed;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
