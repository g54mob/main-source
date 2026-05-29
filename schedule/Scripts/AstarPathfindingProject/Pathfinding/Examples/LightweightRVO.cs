using System.Collections.Generic;
using Pathfinding.RVO;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_lightweight_r_v_o.php")]
	[RequireComponent(typeof(MeshFilter))]
	public class LightweightRVO : MonoBehaviour
	{
		public enum RVOExampleType
		{
			Circle = 0,
			Line = 1,
			Point = 2,
			RandomStreams = 3,
			Crossing = 4
		}

		public int agentCount;

		public float exampleScale;

		public RVOExampleType type;

		public float radius;

		public float maxSpeed;

		public float agentTimeHorizon;

		[HideInInspector]
		public float obstacleTimeHorizon;

		public int maxNeighbours;

		public Vector3 renderingOffset;

		public bool debug;

		private Mesh mesh;

		private Simulator sim;

		private List<IAgent> agents;

		private List<Vector3> goals;

		private List<Color> colors;

		private Vector3[] verts;

		private Vector2[] uv;

		private int[] tris;

		private Color[] meshColors;

		private Vector2[] interpolatedVelocities;

		private Vector2[] interpolatedRotations;

		public void Start()
		{
		}

		public void OnGUI()
		{
		}

		private float uniformDistance(float radius)
		{
			return 0f;
		}

		public void CreateAgents(int num)
		{
		}

		private void SetAgentSettings()
		{
		}

		public void Update()
		{
		}
	}
}
