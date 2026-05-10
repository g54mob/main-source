using Pathfinding.RVO;
using UnityEngine;

namespace Pathfinding.Legacy
{
	[AddComponentMenu("Pathfinding/Legacy/Local Avoidance/Legacy RVO Controller")]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_legacy_1_1_legacy_r_v_o_controller.php")]
	public class LegacyRVOController : RVOController
	{
		[Tooltip("Layer mask for the ground. The RVOController will raycast down to check for the ground to figure out where to place the agent")]
		public new LayerMask mask;

		public new bool enableRotation;

		public new float rotationSpeed;

		public void Update()
		{
		}
	}
}
