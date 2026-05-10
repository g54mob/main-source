using System.Collections.Generic;
using Pathfinding.RVO;
using UnityEngine;

namespace Pathfinding.Examples
{
	[RequireComponent(typeof(RVOController))]
	[RequireComponent(typeof(Seeker))]
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_r_v_o_example_agent.php")]
	public class RVOExampleAgent : MonoBehaviour
	{
		public float repathRate;

		private float nextRepath;

		private Vector3 target;

		private bool canSearchAgain;

		private RVOController controller;

		public float maxSpeed;

		private Path path;

		private List<Vector3> vectorPath;

		private int wp;

		public float moveNextDist;

		public float slowdownDistance;

		public LayerMask groundMask;

		private Seeker seeker;

		private MeshRenderer[] rends;

		public void Awake()
		{
		}

		public void SetTarget(Vector3 target)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void RecalculatePath()
		{
		}

		public void OnPathComplete(Path _p)
		{
		}

		public void Update()
		{
		}
	}
}
