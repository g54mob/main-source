using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class OuterWallPost : WallPost
	{
		public static HashSet<OuterWallPost> AllOuterWallPosts;

		public List<Wall> outerWalls;

		private GameObject _fullPost;

		private GameObject _lowPost;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void Start()
		{
		}

		public override void UpdateVisibility()
		{
		}
	}
}
