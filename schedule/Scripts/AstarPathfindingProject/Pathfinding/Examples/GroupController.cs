using System;
using System.Collections.Generic;
using Pathfinding.RVO;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_group_controller.php")]
	public class GroupController : MonoBehaviour
	{
		public GUIStyle selectionBox;

		public bool adjustCamera;

		private Vector2 start;

		private Vector2 end;

		private bool wasDown;

		private List<RVOExampleAgent> selection;

		private Simulator sim;

		private Camera cam;

		private const float rad2Deg = 180f / (float)Math.PI;

		public void Start()
		{
		}

		public void Update()
		{
		}

		private void OnGUI()
		{
		}

		public void Order()
		{
		}

		public void Select(Vector2 _start, Vector2 _end)
		{
		}

		public Color GetColor(float angle)
		{
			return default(Color);
		}
	}
}
