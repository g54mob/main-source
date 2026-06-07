using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class OuterWallController : MonoBehaviour
	{
		private WallVisibilityController _wallVisibilityController;

		private GridController _gc;

		private Dictionary<Vector3Int, OuterWallPost> _wallPosts;

		private GameObject _wallPostPrefab;

		private void Start()
		{
		}

		public void ConfigureOuterWallsVisibility()
		{
		}

		private void ViewDirectionChanged(object sender, EventArgs e)
		{
		}

		public void UpdateVisibility()
		{
		}

		private void ConfigureWallVisibility(List<Wall> walls, WallVisibilityController controller, bool horizontal)
		{
		}

		private void AddWallPosts(Wall first, Wall last, bool horizontal)
		{
		}
	}
}
