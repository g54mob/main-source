using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class WallPost : MonoBehaviour
	{
		private GameObject _model;

		public static HashSet<WallPost> AllWallPosts;

		private Transform[] _visualFullWall;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void DoorOnDoorPositionChanged(object sender, EventArgs e)
		{
		}

		protected bool IsBlockedByDoor()
		{
			return false;
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		[ContextMenu("updateVisibility")]
		public virtual void UpdateVisibility()
		{
		}

		private void Start()
		{
		}

		private void UpdateVisibility(bool full)
		{
		}
	}
}
