using System;
using UnityEngine;

namespace Pathfinding.RVO
{
	[ExecuteInEditMode]
	[AddComponentMenu("Pathfinding/Local Avoidance/RVO Simulator")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/rvosimulator.html")]
	public class RVOSimulator : VersionedMonoBehaviour
	{
		[Tooltip("Desired FPS for rvo simulation. It is usually not necessary to run a crowd simulation at a very high fps.\nUsually 10-30 fps is enough, but can be increased for better quality.\nThe rvo simulation will never run at a higher fps than the game")]
		public int desiredSimulationFPS;

		[Tooltip("Number of RVO worker threads. If set to None, no multithreading will be used.")]
		[Obsolete("The number of worker threads is now set by the unity job system", true)]
		public ThreadCount workerThreads;

		[Tooltip("Calculate local avoidance in between frames.\nThis can increase jitter in the agents' movement so use it only if you really need the performance boost. It will also reduce the responsiveness of the agents to the commands you send to them.")]
		[Obsolete("Double buffering has been removed")]
		public bool doubleBuffering;

		public bool hardCollisions;

		[Tooltip("Bias agents to pass each other on the right side.\nIf the desired velocity of an agent puts it on a collision course with another agent or an obstacle its desired velocity will be rotated this number of radians (1 radian is approximately 57°) to the right. This helps to break up symmetries and makes it possible to resolve some situations much faster.\n\nWhen many agents have the same goal this can however have the side effect that the group clustered around the target point may as a whole start to spin around the target point.")]
		[Range(0f, 0.2f)]
		public float symmetryBreakingBias;

		[Tooltip("Determines if the XY (2D) or XZ (3D) plane is used for movement")]
		public MovementPlane movementPlane;

		public bool useNavmeshAsObstacle;

		public bool drawQuadtree;

		private SimulatorBurst simulatorBurst;

		public static RVOSimulator active { get; private set; }

		public SimulatorBurst GetSimulator()
		{
			return null;
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		public override void DrawGizmos()
		{
		}
	}
}
