using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class FullWallToggle : MonoBehaviour
	{
		private static readonly HashSet<FullWallToggle> AllFullWallToggles;

		public bool activeWhenFullWallsVisible;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void UpdateVisibility()
		{
		}

		private void UpdateVisibility(bool fullWall)
		{
		}

		public void OnDestroy()
		{
		}

		public void Awake()
		{
		}
	}
}
